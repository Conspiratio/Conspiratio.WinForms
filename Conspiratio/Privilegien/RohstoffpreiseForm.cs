using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;
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

        private async void btn_1_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(1);
        }

        private async void btn_2_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(2);
        }

        private async void btn_3_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(3);
        }

        private async void btn_4_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(4);
        }

        private async void btn_5_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(5);
        }

        private async void btn_6_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(6);
        }

        private async void btn_7_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(7);
        }

        private async void btn_8_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(8);
        }

        private async void btn_9_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(9);
        }

        private async void btn_10_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(10);
        }

        private async void btn_11_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(11);
        }

        private async void btn_12_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(12);
        }

        private async void btn_13_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(13);
        }

        private async void btn_14_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(14);
        }

        private async void btn_15_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(15);
        }

        private async void btn_16_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(16);
        }

        private async void btn_17_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(17);
        }

        private async void btn_18_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(18);
        }

        private async void btn_19_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(19);
        }

        private async void btn_20_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(20);
        }

        private async void btn_21_Click(object sender, EventArgs e)
        {
            await RohstoffXclick(21);
        }

        private async Task RohstoffXclick(int X)
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
                    if (await SW.UI.YesNoQuestion.ShowDialogText("Wollt Ihr falsche Informationen verbreiten um\n den Grundpreis von " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " ins schwanken zu bringen?", "Ja", "Nein") == DialogResultGame.Yes)
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
                    DialogResultGame result = await SW.UI.YesNoQuestion.ShowDialogText("Wollt Ihr Euren Einfluss auf die Großhändler dazu\n nutzen um den Grundpreis von " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " zu", "steigern", "senken");

                    if (result == DialogResultGame.Yes)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetPrivilegKaufmannBenutzt(true);
                        value = SW.Statisch.Rnd.Next(1, 3);
                        temp = "Ihr habt den Grundpreis\nvon " + SW.Dynamisch.GetRohstoffwithID(X).GetRohName() + " gesteigert";
                    }
                    else if(result == DialogResultGame.No)
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
