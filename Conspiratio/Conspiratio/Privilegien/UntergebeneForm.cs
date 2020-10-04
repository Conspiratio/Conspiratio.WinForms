using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class UntergebeneForm : frmBasis, IUntergebeneDialog
    {
        int[] untergebene;

        #region Konstruktor
        public UntergebeneForm()
        {
            InitializeComponent();

            Ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            btn_d1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d3.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d4.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d5.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d6.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
        }
        #endregion


        private void btn_d1_Click(object sender, EventArgs e)
        {
            aufrufen(0);
        }

        private void btn_d2_Click(object sender, EventArgs e)
        {
            aufrufen(1);
        }

        private void btn_d3_Click(object sender, EventArgs e)
        {
            aufrufen(2);
        }

        private void btn_d4_Click(object sender, EventArgs e)
        {
            aufrufen(3);
        }

        private void btn_d5_Click(object sender, EventArgs e)
        {
            aufrufen(4);
        }

        private void btn_d6_Click(object sender, EventArgs e)
        {
            aufrufen(5);
        }

        public void aufrufen(int id)
        {
            UntergebenenOptionen ugopt = new UntergebenenOptionen(untergebene[id]);
            ugopt.ShowDialog();
            this.Close();
        }

        private void UntergebeneForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void UntergebeneForm_Load(object sender, EventArgs e)
        {
            untergebene = SW.Dynamisch.GetUntergebene(SW.Dynamisch.GetAktiverSpieler());
            int u_len = untergebene.Length;

            if (u_len == 0)
            {
                lbl_text.Visible = true;
                lbl_1.Visible = false;
                lbl_2.Visible = false;
                lbl_3.Visible = false;
                lbl_4.Visible = false;
                btn_d1.Visible = false;
                btn_d2.Visible = false;
                btn_d3.Visible = false;
                btn_d4.Visible = false;
            }
            else
            {
                for (int c = 0; c < u_len; c++)
                {
                    if (untergebene[c] != 0)
                    {
                        this.Controls["lbl_" + (c + 1).ToString()].Text = SW.Dynamisch.GetSpWithID(untergebene[c]).GetKompletterName();
                        this.Controls["lbl_" + (c + 1).ToString()].Visible = true;
                        this.Controls["btn_d" + (c + 1).ToString()].Visible = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
