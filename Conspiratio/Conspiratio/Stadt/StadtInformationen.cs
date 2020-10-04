using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class StadtInformationen : frmBasis
    {
        #region Konstruktor
        public StadtInformationen(int stadtid)
        {
            InitializeComponent();






            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());

            pct_c_1.BackgroundImage = Conspiratio.Properties.Resources.SymbCrime;
            pct_c_2.BackgroundImage = Conspiratio.Properties.Resources.SymbCrime;
            pct_c_3.BackgroundImage = Conspiratio.Properties.Resources.SymbCrime;
            pct_c_4.BackgroundImage = Conspiratio.Properties.Resources.SymbCrime;
            pct_c_5.BackgroundImage = Conspiratio.Properties.Resources.SymbCrime;

            pct_r_1.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_2.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_3.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_4.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_5.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_6.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_7.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_8.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_9.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_10.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_11.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_12.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_13.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;
            pct_r_14.BackgroundImage = Conspiratio.Properties.Resources.SymbReichtum;

            // Überschrift
            lbl_ueberschrift.Text = SW.Dynamisch.GetStadtwithID(stadtid).GetGebietsName();
            lbl_ueberschrift.Left = (this.Width - lbl_ueberschrift.Width) / 2;

            // Einwohner
            lbl_einwohner.Text = SW.Dynamisch.GetStadtwithID(stadtid).GetEinwohner().ToString();

            // Umsatzsteuer
            lbl_umsatz.Text = (SW.Dynamisch.GetStadtwithID(stadtid).GetUmsatzsteuer() * 100).ToString() + "%";

            // Kriminalität
            int counter = SW.Dynamisch.GetStadtwithID(stadtid).GetKriminalitaet();
            for (int i = 1; i <= counter; i++)
            {
                this.Controls["pct_c_" + i.ToString()].Visible = true;
            }

            // Hauptproduktion
            int[] produktion = SW.Dynamisch.GetStadtwithID(stadtid).GetHauptproduktion(6);

            for (int i = 1; i <= 3; i++)
            {
                if (Grafik.GetRohstoffIcons46px().Count >= produktion[i - 1])
                {
                    this.Controls["pct_hp_" + i.ToString()].BackgroundImage = Grafik.GetRohstoffIcons46px()[produktion[i - 1]];
                    ttRohstoffe.SetToolTip(this.Controls["pct_hp_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(produktion[i - 1]).GetRohName());
                }
            }

            // Nebenproduktion
            for (int i = 3; i < 6; i++)
            {
                if (Grafik.GetRohstoffIcons46px().Count >= produktion[i])
                {
                    this.Controls["pct_nebenproduktion_" + (i - 2).ToString()].BackgroundImage = Grafik.GetRohstoffIcons46px()[produktion[i]];
                    ttRohstoffe.SetToolTip(this.Controls["pct_nebenproduktion_" + (i - 2).ToString()], SW.Dynamisch.GetRohstoffwithID(produktion[i]).GetRohName());
                }
            }

            // Bedarf
            int[] np = SW.Dynamisch.GetStadtwithID(stadtid).GetBedarf(stadtid);

            for (int i = 1; i <= 3; i++)
            {
                if (Grafik.GetRohstoffIcons46px().Count >= np[i - 1])
                {
                    this.Controls["pct_np_" + i.ToString()].BackgroundImage = Grafik.GetRohstoffIcons46px()[np[i - 1]];
                    ttRohstoffe.SetToolTip(this.Controls["pct_np_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(np[i - 1]).GetRohName());
                }
            }

            // Werkstätten für (Rohstoffe, die in der Stadt produziert werden können)
            int[] werkstaetten = SW.Dynamisch.GetStadtwithID(stadtid).GetRohstoffe();

            for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
            {
                if (Grafik.GetRohstoffIcons46px().Count >= werkstaetten[i])
                {
                    this.Controls["pct_werkstatt_" + i.ToString()].BackgroundImage = Grafik.GetRohstoffIcons46px()[werkstaetten[i]];
                    ttRohstoffe.SetToolTip(this.Controls["pct_werkstatt_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(werkstaetten[i]).GetRohName());
                }
            }

            // Lagerstand
            int[] lagerstand = SW.Dynamisch.BerechneAnteilRohstoffvorratImLand(stadtid);

            for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
            {
                if (Grafik.GetRohstoffIcons46px().Count >= i)
                {
                    ((PictureBox)this.Controls["pct_lagerstand_" + i.ToString()]).Image = Grafik.GetRohstoffIcons46px()[i];
                    ((PictureBox)this.Controls["pct_lagerstand_" + i.ToString()]).Padding = new Padding(3);

                    if (lagerstand[i] <= 33)
                    {
                        this.Controls["pct_lagerstand_" + i.ToString()].BackColor = System.Drawing.Color.DarkRed;
                        ttRohstoffe.SetToolTip(this.Controls["pct_lagerstand_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + " (niedrig)");
                    }
                    else if (lagerstand[i] <= 66)
                    {
                        this.Controls["pct_lagerstand_" + i.ToString()].BackColor = System.Drawing.Color.Orange;
                        ttRohstoffe.SetToolTip(this.Controls["pct_lagerstand_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + " (normal)");
                    }
                    else
                    {
                        this.Controls["pct_lagerstand_" + i.ToString()].BackColor = System.Drawing.Color.DarkGreen;
                        ttRohstoffe.SetToolTip(this.Controls["pct_lagerstand_" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + " (hoch)");
                    }
                }
            }

            ////Katastrohpen
            //int[] ks = SW.Dynamisch.getStadtwithID(stadtid).getKatastrophen();

            //int k_count = 0;
            //for (int i = 0; i < SW.Dynamisch.getMaxKatastrohpen(); i++)
            //{
            //    if (ks[i] != 0)
            //    {
            //        SwitchKatastrophen("pct_kat_" + k_count.ToString(), i + 1);
            //        //this.Controls["pct_kat_" + k_count.ToString()].Visible = true;
            //        k_count++;
            //    }
            //}

            // Reichtum
            int reich = SW.Dynamisch.GetStadtwithID(stadtid).GetReichtum();

            for (int i = 1; i <= reich; i++)
            {
                this.Controls["pct_r_" + i.ToString()].Visible = true;

                if (reich <= 7)
                {
                    this.Controls["pct_r_" + i.ToString()].Top += 13;
                }
            }
        }
        #endregion


        private void pictureBox12_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void StadtInformationen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        #region Katastrophen
        private void SwitchKatastrophen(string btn_name, int value)
        {
            switch (value)
            {
                case 1:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.SymbKatas1;
                    break;
                case 2:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.SymbKatas2;
                    break;
                case 3:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.SymbKatas3;
                    break;
                case 4:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.SymbKatas4;
                    break;
                case 5:
                    this.Controls[btn_name].BackgroundImage = Properties.Resources.SymbKatas5;
                    break;
            }
        }
        #endregion

        private void pct_r_14_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}