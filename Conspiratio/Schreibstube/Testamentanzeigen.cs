using System;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Testamentanzeigen : frmBasis, ITestamentAnzeigenDialog
    {
        private int _erbe;
        private int[] _erben;
        private int _counter;
        private int _arraygroesse;
        private bool _testamentsverlesung;

        public Testamentanzeigen()
        {
            InitializeComponent();
        }


        #region ShowDialog
        /// <summary>
        /// Erklärung: Testamentanzeigen über ShowDialog wird entweder vom Spieler aufgerufen während seinen Lebzeiten.
        /// Dann ist der Spieler noch am Leben und die Variable tod ist FALSE. Wenn der Spieler aber
        /// stirbt, dann ist die Variable tod TRUE und schränkt damit Änderungen am Testament ein.
        /// </summary>
        /// <param name="tod"></param>
        public void ShowDialog(bool tod)
        {
            _testamentsverlesung = tod;

            lbl_text.Text = "Hiermit sei bestimmt, dass nach meinem hoffentlich noch in weiter Ferne liegendem Ableben all' mein Hab' und Gut vererbt werde an:";
            lbl_erblasser.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetName();
            _erbe = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetErbeSpielerID();

            int kindercounter = 0;

            for (int i = 1; i < SW.Statisch.GetMaxKinderAnzahl(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(i).GetKindName() != "")
                    kindercounter++;
            }

            int frauencounter = 0;

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet() != 0)
                frauencounter++;

            _arraygroesse = 1 + kindercounter + frauencounter;
            _erben = new int[_arraygroesse];

            int j = 1;

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet() != 0)
            {
                _erben[j] = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet();
                j++;

            }

            int kcounter = 1;

            while (j < _arraygroesse)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(kcounter).GetKindName() != "")
                {
                    _erben[j] = kcounter;
                    j++;
                }

                kcounter++;

                if (kcounter >= 5)
                    break;
            }

            if (_erbe == 0) //Erzbistum
            {
                btn_erbe.Text = "Das Erzbistum";
                _counter = 0;
            }
            else if (_erbe >= SW.Statisch.GetMinKIID())
            {
                if (SW.Dynamisch.GetKIwithID(_erbe).GetMaennlich() == true)
                    btn_erbe.Text = "Meinen Gatten " + SW.Dynamisch.GetKIwithID(_erbe).GetName();
                else
                    btn_erbe.Text = "Meine Gattin " + SW.Dynamisch.GetKIwithID(_erbe).GetName();

                _counter++;
            }
            else
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(_erbe).GetMaennlich() == true)
                    btn_erbe.Text = "Meinen Sohn " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(_erbe).GetKindName();
                else
                    btn_erbe.Text = "Meine Tochter " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(_erbe).GetKindName();

                _counter++;
            }

            if (_testamentsverlesung)
            {
                // Alle Attribute vom Erben werden nun übernommen
                int fixerErbe = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetErbeSpielerID();

                if (fixerErbe == 0)
                {
                    // Spieler scheidet aus

                    // Die Frau soll nicht mehr verheiratet sein
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet() != 0)
                        SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet()).SetVerheiratet(0);

                    string name = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetName();

                    bool last = false;

                    if (SW.Dynamisch.GetAktiverSpieler() == SW.Dynamisch.GetAktivSpielerAnzahl() && SW.Dynamisch.GetAktiverSpieler() > 1)
                        last = true;

                    // Stützpunkte des verstorbenen Spielers wieder zufälligen KI-Spielern zuteilen
                    for (int i = 0; i < SW.Dynamisch.GetStuetzpunkte().Length; i++)
                    {
                        if (SW.Dynamisch.GetStuetzpunkte()[i].Besitzer == SW.Dynamisch.GetAktiverSpieler())
                            SW.Dynamisch.GetStuetzpunkte()[i].BesitzerStuetzpunktZufaelligSetzen();
                    }

                    SW.Dynamisch.CreateSpielerX(SW.Dynamisch.GetAktiverSpieler(), 0, "", true, 0, 0);  // Aktuelles Spieler Objekt initialisieren (auf null setzen führt ansonsten z.B. in der Statistik zu Problemen beim Zugriff: NullReference Exception)
                    SW.Dynamisch.SetAktivSpielerAnzahl(SW.Dynamisch.GetAktivSpielerAnzahl() - 1);

                    // Ist der Spieler der letzte und nicht einzige in der Liste? Dann wird nicht geordnet und einfach ein neues Jahr gestartet
                    if (last)
                    {
                        SW.Dynamisch.SetAktiverSpieler(1);
                        SW.Dynamisch.ErhoehAktuellesJahrUmEins();
                    }
                    else
                    {
                        // Ist der Spieler nicht der letzte, so muss die Liste neu geordnet werden (Spieler rücken nach)
                        int i = SW.Dynamisch.GetAktiverSpieler();

                        while (i + 1 <= SW.Dynamisch.GetAktivSpielerAnzahl() + 1)
                        {
                            SW.Dynamisch.SetHumX(i, SW.Dynamisch.GetHumWithID(i + 1), i + 1);
                            i++;
                        }
                    }
                }
                else if (fixerErbe > SW.Statisch.GetMinKIID())
                {
                    // Frau erbt
                    int FrauKIID = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet();

                    string nname = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet()).GetName();

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(SW.Dynamisch.GetSpWithID(FrauKIID).GetTaler());
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetName(nname);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetAlter(SW.Dynamisch.GetSpWithID(FrauKIID).GetAlter());
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetMaennlich(SW.Dynamisch.GetSpWithID(FrauKIID).GetMaennlich());
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetVerheiratet(0);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetErbeSpielerID(0);

                    // +2 Damit die Frau nicht womöglich in derselben Runde stirbt
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetVerbleibendeJahre(SW.Dynamisch.GetSpWithID(FrauKIID).GetVerbleibendeJahre() + 2);

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetGesundheit(SW.Dynamisch.GetSpWithID(FrauKIID).GetGesundheit());

                    // Kinder bleiben die gleichen

                    // Amt wird uebernommen
                    SW.Dynamisch.AmtAufStufeXGebietYidZanWvergeben(SW.Dynamisch.GetStufeVonAmtmitIDx(SW.Dynamisch.GetKIwithID(FrauKIID).GetAmtsInformationen().GetAmtsID()), SW.Dynamisch.GetKIwithID(FrauKIID).GetAmtsInformationen().GetGebietsID(), SW.Dynamisch.GetKIwithID(FrauKIID).GetAmtsInformationen().GetAmtsID(), SW.Dynamisch.GetAktiverSpieler());

                    // KI neu anlegen da die Frau sonst doppelt existieren würde
                    SW.Dynamisch.KIXneuAnlegen(FrauKIID);
                }
                else
                {
                    // Kind erbt
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetErbeSpielerID(0);

                    string nname = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(fixerErbe).GetKindName();
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetName(nname);

                    int nalter = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(fixerErbe).GetAlter();
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetAlter(nalter);

                    bool maennlich = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(fixerErbe).GetMaennlich();
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetMaennlich(maennlich);

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetGesundheit(SW.Statisch.GetMaxGesundheit());

                    int verbleibendeJahre = SW.Statisch.Rnd.Next(SW.Statisch.GetHumminVerblJahre(), SW.Statisch.GetHummaxVerblJahre());
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetVerbleibendeJahre(verbleibendeJahre);

                    // Das Kind hat noch keine Kinder!!!
                    for (int i = SW.Statisch.GetMinKindSlotNr(); i < SW.Statisch.GetMaxKinderAnzahl(); i++)
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(i).SetName("");

                    // Das Kind ist nicht verheiratet
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetVerheiratet(0);
                }
            }

            ShowDialog();
        }
        #endregion

        private void btn_erbe_Click(object sender, EventArgs e)
        {
            if (_testamentsverlesung == false)
            {
                _counter++;

                if (_counter >= _arraygroesse)
                    _counter = 0;

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetErbeSpielerID(_erben[_counter]);

                if (_erben[_counter] == 0) //Erzbistum
                {
                    btn_erbe.Text = "Das Erzbistum";
                }
                else if (_erben[_counter] >= SW.Statisch.GetMinKIID())
                {
                    if (SW.Dynamisch.GetSpWithID(_erben[_counter]).GetMaennlich() == false)
                        btn_erbe.Text = "Meine Gattin " + SW.Dynamisch.GetKIwithID(_erben[_counter]).GetName();
                    else
                        btn_erbe.Text = "Meinen Gatten " + SW.Dynamisch.GetKIwithID(_erben[_counter]).GetName();
                }
                else
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(_erben[_counter]).GetMaennlich() == true)
                        btn_erbe.Text = "Meinen Sohn " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(_erben[_counter]).GetKindName();
                    else
                        btn_erbe.Text = "Meine Tochter " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(_erben[_counter]).GetKindName();
                }
            }
        }

        private void Testamentanzeigen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
