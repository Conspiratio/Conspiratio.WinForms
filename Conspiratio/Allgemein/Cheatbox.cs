using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Aemter;
using Conspiratio.Lib.Gameplay.Gebiete;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Cheatbox : frmBasis
    {
        #region Konstruktor
        public Cheatbox()
        {
            InitializeComponent();

            foreach (Control C in this.Controls)
            {
                try
                {
                    C.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
                }
                catch { }
            }
            lbl_header_28.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            lbl_header_28.Left = (this.Width - lbl_header_28.Width) / 2;

            txt_goldd.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler().ToString();
            txt_ans.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetPermaAnsehen().ToString();

            for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
            {
                groupBox_1_16.Controls["ckb" + i.ToString()].Text = SW.Dynamisch.GetRohstoffwithID(i).GetRohName();

                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(i) == true)
                {
                    switch(i)
                    {
                        case 1:
                            ckb1.Checked = true;
                            break;
                        case 2:
                            ckb2.Checked = true;
                            break;
                        case 3:
                            ckb3.Checked = true;
                            break;
                        case 4:
                            ckb4.Checked = true;
                            break;
                        case 5:
                            ckb5.Checked = true;
                            break;
                        case 6:
                            ckb6.Checked = true;
                            break;
                        case 7:
                            ckb7.Checked = true;
                            break;
                        case 8:
                            ckb8.Checked = true;
                            break;
                        case 9:
                            ckb9.Checked = true;
                            break;
                        case 10:
                            ckb10.Checked = true;
                            break;
                        case 11:
                            ckb11.Checked = true;
                            break;
                        case 12:
                            ckb12.Checked = true;
                            break;
                        case 13:
                            ckb13.Checked = true;
                            break;
                        case 14:
                            ckb14.Checked = true;
                            break;
                        case 15:
                            ckb15.Checked = true;
                            break;
                        case 16:
                            ckb16.Checked = true;
                            break;
                        case 17:
                            ckb17.Checked = true;
                            break;
                        case 18:
                            ckb18.Checked = true;
                            break;
                        case 19:
                            ckb19.Checked = true;
                            break;
                        case 20:
                            ckb20.Checked = true;
                            break;
                        case 21:
                            ckb21.Checked = true;
                            break;

                    }

                    groupBox_1_16.Controls["ckb" + i.ToString()].Enabled = false;
                }
            }

            //Amt übernehmen: Stufe
            for (int i = 0; i < 3; i++)
            {
                comboBox1.Items.Add((SW.Statisch.GetStufenNameX(i).ToString()));
            }
           
            //Haus bauen: Stadt
            for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
            {
                comboBox6.Items.Add(SW.Dynamisch.GetStadtwithID(i).GetGebietsName());
            }
        }
        #endregion

        private void ausfueher(int id, bool bo)
        {
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetRohstoffrechteXZuY(id, bo);
        }

        private void ckb1_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(1,ckb1.Checked);
        }

        private void ckb2_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(2, ckb2.Checked);
        }

        private void ckb3_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(3, ckb3.Checked);
        }

        private void ckb4_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(4, ckb4.Checked);
        }

        private void ckb5_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(5, ckb5.Checked);
        }

        private void ckb6_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(6, ckb6.Checked);
        }

        private void ckb7_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(7, ckb7.Checked);
        }

        private void ckb8_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(8, ckb8.Checked);
        }

        private void ckb9_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(9, ckb9.Checked);
        }

        private void ckb10_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(10, ckb10.Checked);
        }

        private void ckb11_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(11, ckb11.Checked);
        }

        private void ckb12_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(12, ckb12.Checked);
        }

        private void ckb13_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(13, ckb13.Checked);
        }

        private void ckb14_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(14, ckb14.Checked);
        }

        private void ckb15_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(15, ckb15.Checked);
        }

        private void ckb16_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(16, ckb16.Checked);
        }

        private void ckb17_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(17, ckb17.Checked);
        }

        private void ckb18_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(18, ckb18.Checked);
        }

        private void ckb19_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(19, ckb19.Checked);
        }

        private void ckb20_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(20, ckb20.Checked);
        }

        private void ckb21_CheckedChanged(object sender, EventArgs e)
        {
            ausfueher(21, ckb21.Checked);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string texttt = txt_goldd.Text;
            for (int i = 0; i < texttt.Length - 1; i++)
            {
                if (texttt.Substring(i, 1) != "0" && texttt.Substring(i, 1) != "1" && texttt.Substring(i, 1) != "2" && texttt.Substring(i, 1) != "3" && texttt.Substring(i, 1) != "4" && texttt.Substring(i, 1) != "5" && texttt.Substring(i, 1) != "6" && texttt.Substring(i, 1) != "7" && texttt.Substring(i, 1) != "8" && texttt.Substring(i, 1) != "9")
                {
                    txt_goldd.Text = "";
                    break;
                }
            }
        }

        private void txt_ans_TextChanged(object sender, EventArgs e)
        {
            string texttt = txt_ans.Text;
            for (int i = 0; i < texttt.Length - 1; i++)
            {
                if (texttt.Substring(i, 1) != "0" && texttt.Substring(i, 1) != "1" && texttt.Substring(i, 1) != "2" && texttt.Substring(i, 1) != "3" && texttt.Substring(i, 1) != "4" && texttt.Substring(i, 1) != "5" && texttt.Substring(i, 1) != "6" && texttt.Substring(i, 1) != "7" && texttt.Substring(i, 1) != "8" && texttt.Substring(i, 1) != "9")
                {
                    txt_ans.Text = "";
                    break;
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help))
            {
                e.SuppressKeyPress = true;
            }
            if (txt_goldd.Text.Length > 8)
            {
                txt_goldd.Text = txt_goldd.Text.Substring(1, 8);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SauberBeenden();
        }

        private void txt_ans_KeyDown(object sender, KeyEventArgs e)
        {
            if (!(('0' <= e.KeyValue && e.KeyValue <= '9') || e.KeyCode < Keys.Help))
            {
                e.SuppressKeyPress = true;
            }
            if (txt_ans.Text.Length > 4)
            {
                txt_ans.Text = txt_ans.Text.Substring(1, 4);
            }
        }

        private void ckb_alle_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
            {
                ausfueher(i, true);
                groupBox_1_16.Controls["ckb" + i.ToString()].Enabled = false;
            }
        }

        private void btn_kindbekommen_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetKindBekommen(true);
        }


        private void btn_sterben_16_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetAlter(999);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stufe = comboBox1.SelectedIndex;

            comboBox2.Items.Clear();
            int max = 0;
            if(stufe == 0)
            {
                max = SW.Statisch.GetMaxStadtID();
            }
            else if (stufe == 1)
            {
                max = SW.Statisch.GetMaxLandID();
            }
            else if (stufe == 2)
            {
                max = SW.Statisch.GetMaxReichID();
            }

            for(int i = 1; i < max; i++)
            {
                comboBox2.Items.Add(SW.Dynamisch.GetGebietwithID(i, stufe).GetGebietsName());
            }

            comboBox3.Items.Clear();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();

            int stufe = comboBox1.SelectedIndex;
            int gebiet = comboBox2.SelectedIndex;

            int minid = 0;
            int maxid = 0;

            if (stufe == 0)
            {
                minid = 0;
                maxid = SW.Statisch.GetMaxAmtStadtID();
            }
            else if (stufe == 1)
            {
                minid = SW.Statisch.GetMaxAmtStadtID();
                maxid = SW.Statisch.GetMaxAmtLandID();
            }
            else if (stufe == 2)
            {
                minid = SW.Statisch.GetMaxAmtLandID();
                maxid = SW.Statisch.GetMaxAmtID();
            }

            for (int i = minid; i < maxid; i++)
            {
                comboBox3.Items.Add(SW.Statisch.GetAmtwithID(i).GetAmtsname(true));
            }
        }

        private void btn_amtuebernehmen_Click(object sender, EventArgs e)
        {
            // Amt mit der KI tauschen
            int stuf = comboBox1.SelectedIndex;
            int geb = comboBox2.SelectedIndex + 1;
            int amt = comboBox3.SelectedIndex + 1;

            if (amt > 0)
            {
                if (stuf == 0)
                {
                    amt -= 1;
                }
                if (stuf == 1)
                {
                    amt += (SW.Statisch.GetMaxAmtStadtID() - 1);
                }
                if (stuf == 2)
                {
                    amt += (SW.Statisch.GetMaxAmtLandID() - 1);
                }

                // Das Amt gehört einer KI
                if (SW.Dynamisch.GetGebietwithID(geb, stuf).GetAmtX(amt) >= SW.Statisch.GetMinKIID())
                {
                    int altgeb = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet();
                    int altamt = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID();
                    int altGebstuf = SW.Dynamisch.GetStufeVonAmtmitIDx(altamt);
                    int kiid = SW.Dynamisch.GetGebietwithID(geb, stuf).GetAmtX(amt);

                    // Dem Spieler das Amt geben
                    int amtStufe = SW.Dynamisch.GetStufeVonAmtmitIDx(amt);
                    SW.Dynamisch.AmtAufStufeXGebietYidZanWvergeben(amtStufe, geb, amt, SW.Dynamisch.GetAktiverSpieler());

                    // Der KI das alte Amt vom Spieler geben
                    SW.Dynamisch.GetSpWithID(kiid).SetAmt(altamt, altgeb);
                    if (altamt != 0)
                    {
                        SW.Dynamisch.GetGebietwithID(altgeb, altGebstuf).SetAmtXtoY(altamt, kiid);
                    }
                    else
                    {
                        SW.Dynamisch.GetSpWithID(kiid).SetAmt(0, 0);
                    }

                    SW.Dynamisch.BelTextAnzeigen("Ihr seid nun " + SW.Statisch.GetAmtwithID(amt).GetAmtsname(true));
                }
                // Das Amt ist nicht besetzt
                else if (SW.Dynamisch.GetGebietwithID(geb, stuf).GetAmtX(amt) == 0)
                {
                    // Dem Spieler das Amt geben
                    int amtStufe = SW.Dynamisch.GetStufeVonAmtmitIDx(amt);
                    SW.Dynamisch.AmtAufStufeXGebietYidZanWvergeben(amtStufe, geb, amt, SW.Dynamisch.GetAktiverSpieler());

                    SW.Dynamisch.BelTextAnzeigen("Ihr seid nun " + SW.Statisch.GetAmtwithID(amt).GetAmtsname(true));
                }
                else
                {
                    SW.Dynamisch.BelTextAnzeigen("Das gewählte Amt gehört einem menschlichem Mitspieler");
                }
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Bitte ein Amt auswählen");
            }
        }


        private void btn_hausbauen_Click(object sender, EventArgs e)
        {
            int stadtid = comboBox6.SelectedIndex + 1;
            int hausid = comboBox5.SelectedIndex + 1;

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(stadtid).SetHausID(hausid);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(stadtid).SetStadtID(stadtid);
        }

        private void btn_verklagtwerden_Click(object sender, EventArgs e)
        {
            if (!(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWirdBereitsVerklagt()))
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBegingVerbrechenX(0, 20);


                int minamtid = SW.Dynamisch.GetMinGegnerAmtID(SW.Dynamisch.GetAktiverSpieler());
                int maxamtid = SW.Dynamisch.GetMaxGegnerAmtID(SW.Dynamisch.GetAktiverSpieler());

                int klaeger = SW.Dynamisch.GetKIthatDislikesHumX(SW.Dynamisch.GetAktiverSpieler(), minamtid, maxamtid);
                int gebietsid = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxStadtID());

                //Falls der Spieler zufälligerweise in dieser Stadt Richter ist
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID() == 5)
                {
                    while (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet() == gebietsid)
                    {
                        gebietsid = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxStadtID());
                    }
                }

                int gebietsstufe = 0;

                int klageid = SW.Dynamisch.GetEmptyGerichtsverhandlung();

                //Richter ermitteln
                int r1 = SW.Dynamisch.GetStadtwithID(gebietsid).GetRichter();

                if (r1 == 0) //Ersatzrichter finden
                {
                    while (r1 == 0)
                    {
                        int randstd = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxStadtID());
                        if (SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != 0 && SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != SW.Dynamisch.GetAktiverSpieler())
                        {
                            r1 = SW.Dynamisch.GetStadtwithID(randstd).GetRichter();
                        }
                    }
                }

                int r2 = 0;
                int loopcounter = 0;

                while (r2 == 0)
                {
                    int randstd = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxStadtID());
                    if (SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != 0 && SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != SW.Dynamisch.GetAktiverSpieler() && SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != r1)
                    {
                        r2 = SW.Dynamisch.GetStadtwithID(randstd).GetRichter();
                    }
                    loopcounter++;

                    if (loopcounter > 1000)
                    {
                        SW.Dynamisch.BelTextAnzeigen("Fehlercode 17. Bitte melde mir diesen Fehler");
                        break;
                    }
                }

                loopcounter = 0;

                int r3 = 0;
                while (r3 == 0)
                {
                    int randstd = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxStadtID());
                    if (SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != 0 && SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != SW.Dynamisch.GetAktiverSpieler() && SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != r1 && SW.Dynamisch.GetStadtwithID(randstd).GetRichter() != r2)
                    {
                        r3 = SW.Dynamisch.GetStadtwithID(randstd).GetRichter();
                    }

                    loopcounter++;
                    if (loopcounter > 1000)
                    {
                        SW.Dynamisch.BelTextAnzeigen("Fehlercode 82. Bitte melde mir diesen Fehler dringend");
                        break;
                    }
                }

                SW.Dynamisch.GetGerichtsverhandlungX(klageid).SetAll(r1, r2, r3, gebietsid, gebietsstufe, SW.Dynamisch.GetAktiverSpieler(), klaeger);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetWirdBereitsVerklagt(true);
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr werdet diese Runde bereits verklagt");
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            for (int i = 1; i < SW.Statisch.GetMaxHausID(); i++)
            {
                comboBox5.Items.Add(SW.Statisch.GetHaus(i).Name);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_verklagtwerden_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SauberBeenden();
            }
        }

        private void SauberBeenden()
        {
            string texttt = txt_goldd.Text;
            for (int i = 0; i < texttt.Length - 1; i++)
            {
                if (texttt.Substring(i, 1) != "0" && texttt.Substring(i, 1) != "1" && texttt.Substring(i, 1) != "2" && texttt.Substring(i, 1) != "3" && texttt.Substring(i, 1) != "4" && texttt.Substring(i, 1) != "5" && texttt.Substring(i, 1) != "6" && texttt.Substring(i, 1) != "7" && texttt.Substring(i, 1) != "8" && texttt.Substring(i, 1) != "9")
                {
                    txt_goldd.Text = "0";
                    break;
                }
            }

            texttt = txt_ans.Text;
            for (int i = 0; i < texttt.Length - 1; i++)
            {
                if (texttt.Substring(i, 1) != "0" && texttt.Substring(i, 1) != "1" && texttt.Substring(i, 1) != "2" && texttt.Substring(i, 1) != "3" && texttt.Substring(i, 1) != "4" && texttt.Substring(i, 1) != "5" && texttt.Substring(i, 1) != "6" && texttt.Substring(i, 1) != "7" && texttt.Substring(i, 1) != "8" && texttt.Substring(i, 1) != "9")
                {
                    txt_ans.Text = "";
                    break;
                }
            }
            if (txt_goldd.Text != "")
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(Convert.ToInt32(txt_goldd.Text) - SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler());
            }
            if (txt_ans.Text != "")
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(Convert.ToInt32(txt_ans.Text) - SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetPermaAnsehen());
            }
            this.Close();
        }

        private void btn_abgesetztWerden_Click(object sender, EventArgs e)
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID() != 0)
            {
                SW.Dynamisch.SetAmtsenthebungVonID(SW.Dynamisch.GetAktiverSpieler());
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr besitzt kein Amt");
            }
        }

        private void btn_verheiraten_Click(object sender, EventArgs e)
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet() == 0)
            {

            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr seid bereits verheiratet");
            }
        }

    }
}