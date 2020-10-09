namespace Conspiratio
{
    partial class Handelszertifikat
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_text = new System.Windows.Forms.Label();
            this.lbl_ueberschrift = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_text.Location = new System.Drawing.Point(58, 123);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(386, 405);
            this.lbl_text.TabIndex = 234;
            this.lbl_text.Text = "Aufgrund Eurer besonderen\r\nHandelserfolge wird Euch,";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_text_MouseDown);
            // 
            // lbl_ueberschrift
            // 
            this.lbl_ueberschrift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ueberschrift.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ueberschrift.Font = new System.Drawing.Font("Arial", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ueberschrift.ForeColor = System.Drawing.Color.Black;
            this.lbl_ueberschrift.Location = new System.Drawing.Point(0, 66);
            this.lbl_ueberschrift.Name = "lbl_ueberschrift";
            this.lbl_ueberschrift.Size = new System.Drawing.Size(500, 40);
            this.lbl_ueberschrift.TabIndex = 235;
            this.lbl_ueberschrift.Text = "Handelszertifikat";
            this.lbl_ueberschrift.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Handelszertifikat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Conspiratio.Properties.Resources.pergament_klein;
            this.ClientSize = new System.Drawing.Size(500, 584);
            this.Controls.Add(this.lbl_ueberschrift);
            this.Controls.Add(this.lbl_text);
            this.Name = "Handelszertifikat";
            this.Text = "Handelszertifikat";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Handelszertifikat_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label lbl_ueberschrift;
    }
}