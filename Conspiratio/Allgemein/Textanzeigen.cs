using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;

namespace Conspiratio
{
    public partial class Textanzeigen : frmBasis, IShowText
    {
        public Textanzeigen()
        {
            InitializeComponent();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task ShowDialog(string text)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
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
