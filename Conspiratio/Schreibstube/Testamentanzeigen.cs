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
                SW.Dynamisch.TestamentVollstrecken();
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
