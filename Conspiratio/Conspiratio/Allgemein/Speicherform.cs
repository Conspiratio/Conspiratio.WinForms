using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Speicherform : frmBasis
    {
        #region Konstruktor
        public Speicherform()
        {
            InitializeComponent();

            lbl_text.Text = "Welchen Namen soll Euer Spielstand tragen?";

            textBox1.Text = SW.Dynamisch.SpielName;
            textBox1.Focus();
        }
        #endregion


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SpE.setStringKurzSpeicher(textBox1.Text.ToString());
                this.Close();
            }
        }

        private void lbl_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SpE.setStringKurzSpeicher("");
                this.CloseMitSound();
            }
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SpE.setStringKurzSpeicher("");
                this.CloseMitSound();
            }
        }

        private void Speicherform_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SpE.setStringKurzSpeicher("");
                this.CloseMitSound();
            }
        }
    }
}
