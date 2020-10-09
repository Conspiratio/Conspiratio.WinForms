using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class RohstoffpreiseForm : frmBasis
    {
        int GlobalAktiveStadt;
        int level;

        #region Konstruktor
        public RohstoffpreiseForm(int sid, int lev)
        {
            InitializeComponent();

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            level = lev;

            GlobalAktiveStadt = sid;

            lbl_ueberschrift.Text = "Rohstoffpreise in " + SW.Dynamisch.GetStadtwithID(GlobalAktiveStadt).GetGebietsName();
            lbl_ueberschrift.Left = (this.Width - lbl_ueberschrift.Width) / 2;

            for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
            {
                // Bild laden
                if (Grafik.GetRohstoffIcons80px().Count >= i)
                {
                    this.Controls["btn_" + i.ToString()].BackgroundImage = Grafik.GetRohstoffIcons80px()[i];
                    ttRohstoffe.SetToolTip(this.Controls["btn_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(i).GetRohName());
                }

                // Preis laden
                this.Controls["lbl_" + i.ToString()].Text = SW.Dynamisch.GetStadtwithID(GlobalAktiveStadt).GetRohstoffPreisVonIDX(i).ToString();
                this.Controls["lbl_" + i.ToString()].Left = this.Controls["btn_" + i.ToString()].Left + (this.Controls["btn_" + i.ToString()].Width - this.Controls["lbl_" + i.ToString()].Width) / 2;
            }
        }
        #endregion


        private void RohstoffpreiseForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void lbl_ueberschrift_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            RohstoffXclick(1);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            RohstoffXclick(2);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            RohstoffXclick(3);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            RohstoffXclick(4);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            RohstoffXclick(5);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            RohstoffXclick(6);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            RohstoffXclick(7);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            RohstoffXclick(8);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            RohstoffXclick(9);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            RohstoffXclick(10);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            RohstoffXclick(11);
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            RohstoffXclick(12);
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            RohstoffXclick(13);
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            RohstoffXclick(14);
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            RohstoffXclick(15);
        }

        private void btn_16_Click(object sender, EventArgs e)
        {
            RohstoffXclick(16);
        }

        private void btn_17_Click(object sender, EventArgs e)
        {
            RohstoffXclick(17);
        }

        private void btn_18_Click(object sender, EventArgs e)
        {
            RohstoffXclick(18);
        }

        private void btn_19_Click(object sender, EventArgs e)
        {
            RohstoffXclick(19);
        }

        private void btn_20_Click(object sender, EventArgs e)
        {
            RohstoffXclick(20);
        }

        private void btn_21_Click(object sender, EventArgs e)
        {
            RohstoffXclick(21);
        }

        private void RohstoffXclick(int X)
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetPrivilegKaufmannBenutzt() == false)
            {
                int value = 0;
                string temp = "";

                if (level == 0)
                {
                    temp = "Ihr besitzt zu wenig Einfluss um an\n den Preisen zu rütteln";
                }
                else if (level == 1)
                {
                    if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr falsche Informationen verbreiten um\n den Grundpreis von " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " ins schwanken zu bringen?", "Ja", "Nein") == DialogResult.Yes)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetPrivilegKaufmannBenutzt(true);

                        value = SW.Statisch.Rnd.Next(-2, 3);

                        if (value == 0)
                        {
                            temp = "Eure Versuche den Grundpreis von " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + "\n zu ändern, sind gescheitert";
                        }
                        else if (value < 0)
                        {
                            temp = "Es ist Euch gelungen den Grundpreis\nvon " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " zu senken";
                        }
                        else
                        {
                            temp = "Es ist Euch gelungen den Grundpreis\nvon " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " zu steigern";
                        }
                    }
                }
                else if (level == 2)
                {
                    DialogResult result = SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr Euren Einfluss auf die Großhändler dazu\n nutzen um den Grundpreis von " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " zu", "steigern", "senken");

                    if (result == DialogResult.Yes)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetPrivilegKaufmannBenutzt(true);
                        value = SW.Statisch.Rnd.Next(1, 3);
                        temp = "Ihr habt den Grundpreis\nvon " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " gesteigert";
                    }
                    else if(result == DialogResult.No)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetPrivilegKaufmannBenutzt(true);
                        value = SW.Statisch.Rnd.Next(-2, 0);
                        temp = "Ihr habt den Grundpreis\nvon " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " gesenkt";
                    }
                }

                if (temp != "")
                    SW.Dynamisch.BelTextAnzeigen(temp);

                for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                {
                    // Preis laden
                    this.Controls["lbl_" + i.ToString()].Text = SW.Dynamisch.GetStadtwithID(GlobalAktiveStadt).GetRohstoffPreisVonIDX(i).ToString();
                    this.Controls["lbl_" + i.ToString()].Left = this.Controls["btn_" + i.ToString()].Left + (this.Controls["btn_" + i.ToString()].Width - this.Controls["lbl_" + i.ToString()].Width) / 2;
                }
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr solltet dieses Jahr keine weiteren Aktionen dieser Art durchführen, da man Euch sonst auf die Schliche kommen würde");
            }
        }
    }
}
