using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;

namespace Conspiratio
{
    public partial class Einzelspieler : frmBasis
    {
        #region Konstruktor
        public Einzelspieler()
        {
            InitializeComponent();

            lbl_hot_seat_text.Left = (this.Width - lbl_hot_seat_text.Width) / 2;

            btn_spiel_fortsetzen.Enabled = (Properties.Settings.Default["Letzter_Spielstand"].ToString() != "");
        }
        #endregion


        private void btn_neuesSpiel_Click(object sender, EventArgs e)
        {
            NeuesSpiel wvs = new NeuesSpiel();
            wvs.ShowDialog();
            SpE.setIntKurzSpeicher(2);
            Close();
        }

        private void btn_spielLaden_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(1);
            Close();
        }

        private void btn_spiel_fortsetzen_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(3);
            SpE.setStringKurzSpeicher(Properties.Settings.Default["Letzter_Spielstand"].ToString());
            Close();
        }

        private void lbl_hot_seat_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SpE.setIntKurzSpeicher(0);
                CloseMitSound();
            }
        }
    }
}
