using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class TippsAnzeigen : frmBasis
    {
        int active_tipp;

        #region Konstruktor
        public TippsAnzeigen(bool bOhneButtons = false)
        {
            InitializeComponent();

            if (bOhneButtons)
            {
                this.Height = 340;
                btn_weiter.Visible = false;
                btn_zurueck.Visible = false;
            }

            active_tipp = SW.Statisch.Rnd.Next(0, SW.Statisch.GetTippsMaxIndex());
            tippladen();

            lbl_uebeschrift.Left = this.Width / 2 - lbl_uebeschrift.Width / 2;
            lbl_text.Left = this.Width / 2 - lbl_text.Width / 2;
        }
        #endregion


        private void btn_zurueck_Click(object sender, EventArgs e)
        {
            if (active_tipp > 0)
            {
                active_tipp--;
                tippladen();
            }
        }

        private void btn_weiter_Click(object sender, EventArgs e)
        {
            if (active_tipp < SW.Statisch.GetTippsMaxIndex())
            {
                if (SW.Statisch.Tipps[active_tipp + 1] != "")
                {
                    active_tipp++;
                    tippladen();
                }
            }
        }

        private void tippladen()
        {
            lbl_text.Text = SW.Statisch.Tipps[active_tipp];
            lbl_uebeschrift.Text = "Tipp #" + (active_tipp + 1).ToString();
        }

        private void lbl_uebeschrift_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void lbl_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_zurueck_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_weiter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void TippsAnzeigen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
