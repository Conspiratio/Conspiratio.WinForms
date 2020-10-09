using System;
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

            this.Width = 470;
            this.Height = 250;
            label1.Left = 15;
            label1.Top = 15;
            int widthhh = this.Width - 2 * label1.Left;
            label1.Width = widthhh;
            int heigthhh = this.Height - 2 * label1.Top;
            label1.Height = heigthhh;
        }

        public void ShowDialog(string text)
        {
            label1.Text = text;
            base.ShowDialog();
        }

        private void Text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
