using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class BewerbForm : frmBasis
    {
        private int[] _wahlids;

        #region Konstruktor
        public BewerbForm()
        {
            InitializeComponent();

            SetAllUncheckedExceptX(-1);

            if (SW.Dynamisch.GetAnzahlFreieAemterFuerSpX(SW.Dynamisch.GetAktiverSpieler()) == 0)
            {
                lbl_keineaemter.Visible = true;

                this.Height = 160;
                this.Width = 460;
            }
            else
            {
                lbl_keineaemter.Visible = false;
                this.Height = 220;
                this.Width = 650;
            }

            int max = SW.Dynamisch.GetAnzahlFreieAemterFuerSpX(SW.Dynamisch.GetAktiverSpieler());

            if (max > 10)
                max = 10;

            _wahlids = SW.Dynamisch.GetFreieAemterFuerSpX(SW.Dynamisch.GetAktiverSpieler());

            for (int i = 0; i < max; i++)
            {
                this.Controls["lbl_amt" + i.ToString()].Text = SW.Statisch.GetAmtwithID(SW.Dynamisch.GetWahlX(_wahlids[i]).AmtID).GetAmtsname(true) + " in " + SW.Dynamisch.GetGebietwithID(SW.Dynamisch.GetWahlX(_wahlids[i]).GebietID, SW.Dynamisch.GetWahlX(_wahlids[i]).Stufe).GetGebietsName();
                this.Controls["lbl_amt" + i.ToString()].Visible = true;
                this.Controls["btn_amt" + i.ToString()].Visible = true;
                this.Controls["lbl_info" + i.ToString()].Visible = true;
                this.Height += lbl_amt0.Height + 7;
            }
            
            // wenn er bereits angemeldet ist, soll dieses Amt markiert sein
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme() != 0)
            {
                int wahlid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme();
                int angemeldetamtid = SW.Dynamisch.GetWahlX(wahlid).AmtID;
                int angemeldetgebid = SW.Dynamisch.GetWahlX(wahlid).GebietID;
                int angemeldetstuid = SW.Dynamisch.GetWahlX(wahlid).Stufe;

                // die Position dieses Amts ermitteln
                for (int i = 0; i < max; i++)
                {
                    if (angemeldetamtid == SW.Dynamisch.GetWahlX(_wahlids[i]).AmtID && angemeldetgebid == SW.Dynamisch.GetWahlX(_wahlids[i]).GebietID && angemeldetstuid == SW.Dynamisch.GetWahlX(_wahlids[i]).Stufe)
                    {
                        this.Controls["btn_amt" + i.ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbChecked);
                        break;
                    }
                }
            }
        }
        #endregion


        private void SetAllUncheckedExceptX(int X)
        {
            btn_amt0.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt3.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt4.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt5.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt6.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt7.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt8.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_amt9.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            
            if (X >= 0 && X <= 9)
                Controls["btn_amt" + X.ToString()].BackgroundImage = new Bitmap(Properties.Resources.SymbChecked);
        }

        private void btn_amt0_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(0);
        }

        private void btn_amt1_Click_1(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(1);
        }

        private void btn_amt2_Click_1(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(2);
        }

        private void btn_amt3_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(3);
        }

        private void btn_amt4_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(4);
        }

        private void btn_amt5_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(5);
        }

        private void btn_amt6_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(6);
        }

        private void btn_amt7_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(7);
        }

        private void btn_amt8_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(8);
        }

        private void btn_amt9_Click(object sender, EventArgs e)
        {
            SpielerBeiWahlXAnmelden(9);
        }

        private void SpielerBeiWahlXAnmelden(int btn_x)
        {
            int x = _wahlids[btn_x];

            // Wenn er schon zu dieser Wahl angemeldet ist
            if (x == SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme())
            {
                //Spieler suchen und abmelden
                int u = 0;
                while (true)
                {
                    if (SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).GetKandidaten()[u] == SW.Dynamisch.GetAktiverSpieler())
                    {
                        SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).SetKandidatenXAufY(u, 0);
                        break;
                    }
                    u++;
                }

                SW.Dynamisch.BelTextAnzeigen("Ihr zieht Eure Bewerbung für das Amt des " + SW.Statisch.GetAmtwithID(SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).AmtID).GetAmtsname(true) + " zurück.");
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetWahlTeilnahme(0);
                this.Controls["btn_amt" + btn_x.ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            }
            // Falls er noch zu keiner Wahl angemeldet oder einer anderen angemeldet ist
            else
            {
                // Wenn er zu einer anderen Wahl gemeldet ist, abmelden
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme() != 0)
                {
                    // Position suchen
                    int u = 0;

                    while (true)
                    {
                        if ((SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).GetKandidaten().Length - 1) >= u)
                        {
                            if (SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).GetKandidaten()[u] == SW.Dynamisch.GetAktiverSpieler())
                            {
                                SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).SetKandidatenXAufY(u, 0);
                                break;
                            }

                            u++;
                        }
                        else
                            break;  // Fehlerhafter Wert in SW.Dynamisch.getAktiverSpieler()).getWahlTeilnahme(), Schleife abbrechen
                    }
                }

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetWahlTeilnahme(x);
                // Spieler wird an der ersten freien Stelle eingetragen
                for (int i = 0; i < SW.Statisch.GetMaxWahlKandidaten(); i++)
                {
                    if (SW.Dynamisch.GetWahlX(x).GetKandidaten()[i] == 0)
                    {
                        SW.Dynamisch.GetWahlX(x).SetKandidatenXAufY(i, SW.Dynamisch.GetAktiverSpieler());
                        break;
                    }
                }

                SetAllUncheckedExceptX(btn_x);

                SW.Dynamisch.BelTextAnzeigen("Ihr wurdet für die Wahl des Amts " + SW.Statisch.GetAmtwithID(SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).AmtID).GetAmtsname(true) + " aufgestellt.");
            }
        }

        private void lbl_info0_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[0]);
        }

        private void lbl_info1_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[1]);
        }

        private void lbl_info2_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[2]);
        }

        private void lbl_info3_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[3]);
        }

        private void lbl_info4_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[4]);
        }

        private void lbl_info5_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[5]);
        }

        private void lbl_info6_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[6]);
        }

        private void lbl_info7_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[7]);
        }

        private void lbl_info8_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[8]);
        }

        private void lbl_info9_Click(object sender, EventArgs e)
        {
            InfoAufrufen(_wahlids[9]);
        }

        private void InfoAufrufen(int wah)
        {
            BewerbInfos bwi = new BewerbInfos(wah);
            bwi.ShowDialog();
        }

        private void BewerbForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
