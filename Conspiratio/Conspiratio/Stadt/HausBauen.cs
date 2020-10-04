using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class HausBauen : frmBasis
    {
        private int _stadtID;

        #region Konstruktor
        public HausBauen(int sid)
        {
            InitializeComponent();

            btn_bild.BackgroundImage = Properties.Resources.AnwNV;
            btn_bauen.BackgroundImage = Properties.Resources.SymbUnchecked;
            btn_renovieren.BackgroundImage = Properties.Resources.SymbUnchecked;
            btn_erweitern.BackgroundImage = Properties.Resources.SymbUnchecked;
            btn_verkaufen.BackgroundImage = Properties.Resources.SymbUnchecked;

            _stadtID = sid;

            AnzeigeAktualisieren();
        }
        #endregion

        #region AnzeigeAktualisieren
        private void AnzeigeAktualisieren()
        {
            btn_renovieren.Visible = false;
            lbl_renovieren.Visible = false;
            btn_erweitern.Visible = false;
            lbl_erweitern.Visible = false;
            btn_verkaufen.Visible = false;
            lbl_verkaufen.Visible = false;

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetHausID() == 0)
            {
                lbl_text.Text = "Ihr besitzt hier keinen Wohnsitz";
            }
            else
            {
                lbl_bauen.Text = "Umbauen";

                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetRestlicheBauzeit() == 0)
                {
                    // schon fertig
                    lbl_text.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetNameInklPronomen();

                    switchHaus("btn_bild", SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetHausID());
                    lbl_zustand.Text = "Zustand: " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).ZustandInProzent + " %";

                    btn_renovieren.Visible = true;
                    lbl_renovieren.Visible = true;
                    btn_erweitern.Visible = true;
                    lbl_erweitern.Visible = true;
                    btn_verkaufen.Visible = true;
                    lbl_verkaufen.Visible = true;
                }
                else
                {
                    // wird noch gebaut
                    lbl_text.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetNameInklPronomen(false) + " wird erst errichtet";
                    btn_bild.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.AnwImBau);
                }
            }
        }
        #endregion

        private void btn_bauen_Click(object sender, EventArgs e)
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetRestlicheBauzeit() == 0)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetHausID() == 0)
                {
                    HausWaehlen hw = new HausWaehlen(_stadtID, 0);
                    hw.ShowDialog();
                    AnzeigeAktualisieren();
                }
                else
                {
                    // Umbauen
                    HausWaehlen hw = new HausWaehlen(_stadtID, 1);
                    hw.ShowDialog();
                    AnzeigeAktualisieren();
                }
            }
            else
            {
                // Gerade im Bau
                SW.Dynamisch.BelTextAnzeigen("Euer Wohnsitz wird bereits umgebaut");
            }
        }

        private void HausBauen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_verkaufen_Click(object sender, EventArgs e)
        {
            int w_counter = 0;

            for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(i, _stadtID).GetEnabled() == true)
                    w_counter++;
            }

            if (w_counter == 0)
            {
                int hausid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetHausID();
                int wert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetAktuellerWert();

                if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr Euren Wohnsitz wirklich\n für " + wert.ToStringGeld() + " verkaufen?", "Ja", "Lieber nicht!") == DialogResult.Yes)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(wert);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).SetHausID(0);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).SetStadtID(0);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).HausErweiterungen = null;
                    SW.Dynamisch.BelTextAnzeigen("Ihr habt Euren Wohnsitz für " + wert.ToStringGeld() + " verkauft!");
                    AnzeigeAktualisieren();
                }
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr könnt diesen Wohnsitz nicht verkaufen, da Ihr noch Werkstätten in " + SW.Dynamisch.GetStadtwithID(_stadtID).GetGebietsName() + " besitzt");
            }
        }

        private void btn_bild_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();

            if (e.Button == MouseButtons.Left)
            {
                //Baustelleninformationen anzeigen
                int hausid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetHausID();
                if (hausid != 0)
                {
                    int restlBauzeit = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetRestlicheBauzeit();

                    if (restlBauzeit > 1)
                    {
                        SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetNameInklPronomen(false) + " wird in " + restlBauzeit.ToString() + " Jahren fertiggestellt");
                    }
                    else if (restlBauzeit > 0)
                    {
                        SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetNameInklPronomen(false) + " wird in " + restlBauzeit.ToString() + " Jahr fertiggestellt");
                    }
                }
                else
                {
                    SW.Dynamisch.BelTextAnzeigen("Ihr besitzt hier keinen Wohnsitz");
                }
            }
        }

        private void btn_bauen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void switchHaus(string btn_name, int value)
        {
            switch (value)
            {
                case 1:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 2:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 3:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 4:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 5:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 6:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 7:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 8:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
                case 9:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.AnwHaus1;
                    break;
            }
        }

        private void btn_renovieren_Click(object sender, EventArgs e)
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).ZustandInProzent != 100)
            {
                if (!SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).InDiesemJahrRenovieren)
                {
                    int hausid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetHausID();
                    int wert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetAktuellerWert();
                    double faktorReduzierung = 1;

                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(15))
                        faktorReduzierung = ((PrivSparplan)SW.Statisch.GetPrivX(15)).FaktorReduzierung;

                    int preis = Convert.ToInt32((wert * ((100 - SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).ZustandInProzent) * 0.01)) * faktorReduzierung);

                    if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr Euren Wohnsitz wirklich\n für " + preis.ToStringGeld() + " renovieren lassen?", "Ja", "Lieber nicht!") == DialogResult.Yes)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-preis);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).InDiesemJahrRenovieren = true;
                        SW.Dynamisch.BelTextAnzeigen("Ihr lasst Handwerker kommen! Im nächsten Jahr ist die Renovierung abgeschlossen.");
                    }
                }
                else
                {
                    SW.Dynamisch.BelTextAnzeigen("Ihr habt in diesem Jahr bereits eine Renovierung in Auftrag gegeben.");
                }
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Euer Wohnsitz befindet sich in tadellosem Zustand und benötigt keine Renovierungsarbeiten.");
            }
        }

        private void btn_erweitern_Click(object sender, EventArgs e)
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetFehlendeOderVorhandeneHauserweiterungen().Count > 0)
            {
                HausErweiterungen hausErweiterungen = new HausErweiterungen(_stadtID);
                hausErweiterungen.ShowDialog();
                AnzeigeAktualisieren();
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr besitzt bereits alle möglichen Erweiterungen für diesen Wohnsitz.");
            }
        }
    }
}
