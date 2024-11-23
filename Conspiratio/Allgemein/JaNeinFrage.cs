using System;
using System.Threading.Tasks;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;

namespace Conspiratio
{
    public partial class JaNeinFrage : frmBasis, IYesNoQuestion
    {
        /// <summary>
        /// Zeigt ein DialogFenster mit dem angegebenen Text und zwei Buttons (i.d.R. Ja und Nein) an. Die Texte können frei angepasst werden.
        /// Als Rückgabewert wird <see cref="DialogResultGame.Yes"/>, <see cref="DialogResultGame.No"/> oder <see cref="DialogResultGame.Cancel"/> beim Schließen des Dialogs über Rechtsklick zurückgeben.
        /// </summary>
        /// <remarks>Beim Aufruf aus dem WinForms Client wird eine synchrone Variante verwendet und diese nutzt intern die Methode <see cref="Form.ShowDialog()"/>,
        /// um einen modalen Dialog anzuzeigen. Ansonsten wird in einer Engine über await auf das Schließen des Dialogs durch den Spieler gewartet.</remarks>
        /// <param name="textQuestion">Text der Frage</param>
        /// <param name="textYes">Beschriftung des linken "Ja"-Buttons</param>
        /// <param name="textNo">Beschriftung des rechten "Nein"-Buttons</param>
        /// <returns>Kann <see cref="DialogResultGame.Yes"/>, <see cref="DialogResultGame.No"/> und <see cref="DialogResultGame.Cancel"/> beim Schließen des Dialogs über Rechtsklick zurückgeben.</returns>
        public async Task<DialogResultGame> ShowDialogText(string textQuestion, string textYes = "Ja", string textNo = "Nein")
        {
            lbl_frage_20.Text = textQuestion;
            Width = lbl_frage_20.Left * 2 + lbl_frage_20.Width;

            btn_ja_20.Text = textYes;
            btn_ja_20.Left = Width / 3 - btn_ja_20.Width / 2;

            btn_nein_20.Text = textNo;
            btn_nein_20.Left = Width / 3 * 2 - btn_nein_20.Width / 2;

            return await Task.Run(ShowDialogText);
        }

        // Protected Konstruktor, damit keine direkten Instanzen dieser Klasse erzeugt werden können.
        // Der Aufrufer soll damit gezwungen werden, die static Show-Methoden zu nutzen.
        public JaNeinFrage()
        {
            InitializeComponent();
        }

        private DialogResultGame ShowDialogText()
        {
            var dialogResult = ShowDialog();

            if ((dialogResult != DialogResult.Yes) && (dialogResult != DialogResult.No))
                dialogResult = DialogResult.Cancel;

            return dialogResult.ToDialogResultGame();
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
            if (e.Button != MouseButtons.Right) 
                return;

            SpE.setBoolKurzSpeicher(false);
            CloseMitSound();
        }
    }
}
