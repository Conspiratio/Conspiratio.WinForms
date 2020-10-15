using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;

namespace Conspiratio
{
    public partial class Textanzeigen : frmBasis, ITextAnzeigen
    {
        public Textanzeigen()
        {
            InitializeComponent();
        }

        public void ShowDialog(string text)
        {
            label1.MaximumSize = new Size(600, 0);
            label1.Text = text;

            ShowDialog();
        }

        private void Text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CloseMitSound();
        }
    }
}
