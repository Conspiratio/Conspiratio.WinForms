using Conspiratio.Controls;

namespace Conspiratio.Kampf
{
    partial class frmKampfereignisse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trtText = new Conspiratio.Controls.TransparentRichText();
            this.lbl_nachrichten_titel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trtText
            // 
            this.trtText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trtText.Cursor = System.Windows.Forms.Cursors.No;
            this.trtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trtText.Location = new System.Drawing.Point(304, 131);
            this.trtText.Name = "trtText";
            this.trtText.ReadOnly = true;
            this.trtText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.trtText.ShortcutsEnabled = false;
            this.trtText.Size = new System.Drawing.Size(745, 530);
            this.trtText.TabIndex = 0;
            this.trtText.Text = "Text der Ereignisse ...\nZeile 2 usw.";
            this.trtText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmKampfereignisse_MouseDown);
            // 
            // lbl_nachrichten_titel
            // 
            this.lbl_nachrichten_titel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nachrichten_titel.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nachrichten_titel.ForeColor = System.Drawing.Color.Black;
            this.lbl_nachrichten_titel.Location = new System.Drawing.Point(298, 84);
            this.lbl_nachrichten_titel.Name = "lbl_nachrichten_titel";
            this.lbl_nachrichten_titel.Size = new System.Drawing.Size(751, 44);
            this.lbl_nachrichten_titel.TabIndex = 168;
            this.lbl_nachrichten_titel.Text = "Nachrichten";
            this.lbl_nachrichten_titel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmKampfereignisse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Conspiratio.Properties.Resources.HintRundenNachrichten;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.lbl_nachrichten_titel);
            this.Controls.Add(this.trtText);
            this.Name = "frmKampfereignisse";
            this.Text = "frmKampfereignisse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmKampfereignisse_Load);
            this.Shown += new System.EventHandler(this.frmKampfereignisse_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmKampfereignisse_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private TransparentRichText trtText;
        private System.Windows.Forms.Label lbl_nachrichten_titel;
    }
}