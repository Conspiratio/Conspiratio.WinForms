using System;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;

namespace Conspiratio
{
    public partial class JaNeinFrage : frmBasis, IJaNeinFrage
    {
        /// <summary>
        /// Zeigt ein DialogFenster mit dem angegebenen Text und zwei Buttons (i.d.R. Ja und Nein) an. Die Texte können frei angepasst werden.
        /// Als Rückgabewert wird DialogResult.Yes, DialogResult.No oder DialogResult.Cancel beim Schließen des Dialogs über Rechtsklick zurückgeben.
        /// </summary>
        /// <param name="textFrage">Text der Frage</param>
        /// <param name="textJa">Beschriftung des linken "Ja"-Buttons</param>
        /// <param name="textNein">Beschriftung des rechten "Nein"-Buttons</param>
        /// <returns>Kann DialogResult.Yes, DialogResult.No und DialogResult.Cancel beim Schließen des Dialogs über Rechtsklick zurückgeben.</returns>
        public DialogResultGame ShowDialogText(string textFrage, string textJa = "Ja", string textNein = "Nein")
        {
            lbl_frage_20.Text = textFrage;
            Width = lbl_frage_20.Left * 2 + lbl_frage_20.Width;

            btn_ja_20.Text = textJa;
            btn_ja_20.Left = Width / 3 - btn_ja_20.Width / 2;

            btn_nein_20.Text = textNein;
            btn_nein_20.Left = Width / 3 * 2 - btn_nein_20.Width / 2;

            DialogResult dialogResult = ShowDialog();

            if ((dialogResult != DialogResult.Yes) && (dialogResult != DialogResult.No))
                dialogResult = DialogResult.Cancel;

            return dialogResult.ToDialogResultGame();
        }

        // Protected Konstruktor, damit keine direkten Instanzen dieser Klasse erzeugt werden können.
        // Der Aufrufer soll damit gezwungen werden, die static Show-Methoden zu nutzen.
        public JaNeinFrage()
        {
            InitializeComponent();
        }

        private void btn_ja_Click(object sender, EventArgs e)
        {
            SpE.setBoolKurzSpeicher(true);
            Close();
        }

        private void btn_nein_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JaNeinFrage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SpE.setBoolKurzSpeicher(false);
                CloseMitSound();
            }
        }
    }
}
