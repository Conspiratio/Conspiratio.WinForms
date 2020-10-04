using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Conspiratio.Controls
{
    public class TransparentRichText : RichTextBox
    {
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;

        [DefaultValue(false)]
        public bool Selektierbar { get; set; }

        #region Konstruktor
        public TransparentRichText()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.TextChanged += TransparentLabel_TextChanged;
            this.VScroll += TransparentLabel_TextChanged;
            this.HScroll += TransparentLabel_TextChanged;
        }
        #endregion

        #region CreateParams
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ExStyle |= 0x20;  // WS_EX_TRANSPARENT einschalten
                return parms;
            }
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS && !Selektierbar)
                m.Msg = WM_KILLFOCUS;

            base.WndProc(ref m);
        }
        #endregion

        #region TransparentLabel_TextChanged
        private void TransparentLabel_TextChanged(object sender, EventArgs e)
        {
            this.ForceRefresh();
        }
        #endregion

        #region ForceRefresh
        /// <summary>
        /// Control Styles aktualisieren.
        /// </summary>
        public void ForceRefresh()
        {
            this.UpdateStyles();
        }
        #endregion

        public void AddText(string text)
        {
            AddText(text, ForeColor);
        }

        public void AddText(string text, Color col, Font font = null)
        {
            int pos = TextLength;

            if (font == null)
                font = Font;
            
            AppendText(text);
            Select(pos, text.Length);
            SelectionColor = col;
            SelectionFont = font;
            Select();
        }
    }
}
