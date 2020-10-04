using System.Windows.Forms;
using Conspiratio.Allgemein;

namespace Conspiratio
{
    public partial class Ladeform : frmBasis
    {
        #region Konstruktor
        public Ladeform()
        {
            InitializeComponent();

            lbl_text.Text = "Welcher Spielstand soll geladen werden?";
            this.Focus();
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
            SpE.setStringKurzSpeicher("");
            this.CloseMitSound();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            SpE.setStringKurzSpeicher("");
            this.CloseMitSound();
        }

        private void Ladeform_MouseDown(object sender, MouseEventArgs e)
        {
            SpE.setStringKurzSpeicher("");
            this.CloseMitSound();
        }
    }
}
