using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conspiratio.Controls;

namespace Conspiratio.Allgemein
{
    public partial class frmBasis : Form
    {
        #region Variablen

        private C_Musik _sounds = new C_Musik();

        /// <summary>
        /// Globale Task Variable als auto implemented Property für Warten auf Rechtsklick
        /// </summary>
        public TaskCompletionSource<bool> tcsRechtsklick { get; set; } = null;

        /// <summary>
        /// Globale Task Variable als auto implemented Property für Warten auf Buttonklick
        /// </summary>
        public TaskCompletionSource<bool> tcsButtonklick { get; set; } = null;

        /// <summary>
        /// Globale Task Variable als auto implemented Property für Warten auf Enterdruck
        /// </summary>
        public TaskCompletionSource<bool> tcsEnterdruck { get; set; } = null;

        #endregion


        #region frmBasis
        /// <summary>
        /// Konstruktor, hier wird der Standardcursor sowie das Standard BackgroundImage gesetzt.
        /// </summary>
        public frmBasis()
        {
            InitializeComponent();

            if (File.Exists(Application.StartupPath + "\\" + Grafik.GetStandardCursorName()))
                this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\" + Grafik.GetStandardCursorName());

            this.BackgroundImage = new Bitmap(Properties.Resources.SonstPergament);
        }
        #endregion

        #region frmBasis_Load
        /// <summary>
        /// Hier wird allen Objekten einheitlich die Standard Schriftart zugewiesen. Zusätzlich wird allen TransparentRichText Controls der Standardcursor zugeordnet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmBasis_Load(object sender, EventArgs e)
        {
            // Allen Objekten einheitlich die Schrift zuweisen
            // Muss im Load, statt im Konstruktor passieren, damit die Controls und auch der Standardfont schon vorhanden sind

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)  // Nicht im Design Mode von VS?
            {
                foreach (Control C in this.Controls)
                {
                    C.Font = Grafik.GetStandardFont(Convert.ToInt16(C.Font.Size));

                    if (C is TransparentRichText)
                        C.Cursor = this.Cursor;
                }
            }
        }
        #endregion

        #region AufRechtsklickWarten
        public async Task AufRechtsklickWarten()
        {
            CurWaitActive();
            await RechtsklickTask();
            CurStandardActive();
        }
        #endregion

        #region AufButtonKlickWarten
        public async Task AufButtonKlickWarten()
        {
            // Cursor nicht verändern
            await ButtonklickTask();
        }
        #endregion

        #region AufEnterdruckWarten
        public async Task AufEnterdruckWarten()
        {
            // Cursor nicht verändern
            await EnterdruckTask();
        }
        #endregion


        #region RechtsklickTask
        private Task RechtsklickTask()
        {
            tcsRechtsklick = new TaskCompletionSource<bool>();
            return tcsRechtsklick.Task;
        }
        #endregion

        #region ButtonklickTask
        private Task ButtonklickTask()
        {
            tcsButtonklick = new TaskCompletionSource<bool>();
            return tcsButtonklick.Task;
        }
        #endregion

        #region EnterdruckTask
        private Task EnterdruckTask()
        {
            tcsEnterdruck = new TaskCompletionSource<bool>();
            return tcsEnterdruck.Task;
        }
        #endregion

        #region CurStandardActive
        protected void CurStandardActive()
        {
            Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\" + Grafik.GetStandardCursorName());
            SetCursorForControls();
        }
        #endregion

        #region CurWaitActive
        protected void CurWaitActive()
        {
            Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurWait.ani");
            SetCursorForControls();
        }
        #endregion

        #region SetCursorForControls
        private void SetCursorForControls()
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)  // Nicht im Design Mode von VS?
            {
                foreach (Control C in Controls)
                {
                    if (C is TransparentRichText)
                        C.Cursor = Cursor;
                }
            }
        }
        #endregion

        #region CloseMitSound
        public void CloseMitSound()
        {
            _sounds.PlaySound(Properties.Resources.bongo_hell);
            Close();
        }
        #endregion
    }
}