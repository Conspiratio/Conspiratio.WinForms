using Conspiratio.Controls;

namespace Conspiratio
{
    partial class JaNeinFrage
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
            this.lbl_frage_20 = new System.Windows.Forms.Label();
            this.btn_nein_20 = new Conspiratio.Controls.LinkButton();
            this.btn_ja_20 = new Conspiratio.Controls.LinkButton();
            this.SuspendLayout();
            // 
            // lbl_frage_20
            // 
            this.lbl_frage_20.AutoSize = true;
            this.lbl_frage_20.BackColor = System.Drawing.Color.Transparent;
            this.lbl_frage_20.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_frage_20.Location = new System.Drawing.Point(45, 65);
            this.lbl_frage_20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_frage_20.Name = "lbl_frage_20";
            this.lbl_frage_20.Size = new System.Drawing.Size(136, 47);
            this.lbl_frage_20.TabIndex = 2;
            this.lbl_frage_20.Text = "label1";
            this.lbl_frage_20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_frage_20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JaNeinFrage_MouseDown);
            // 
            // btn_nein_20
            // 
            this.btn_nein_20.AutoSize = true;
            this.btn_nein_20.BackColor = System.Drawing.Color.Transparent;
            this.btn_nein_20.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btn_nein_20.FensterBeiRechtsklickSchliessen = false;
            this.btn_nein_20.FlatAppearance.BorderSize = 0;
            this.btn_nein_20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_nein_20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_nein_20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nein_20.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nein_20.ForeColor = System.Drawing.Color.Black;
            this.btn_nein_20.Location = new System.Drawing.Point(255, 265);
            this.btn_nein_20.Margin = new System.Windows.Forms.Padding(0);
            this.btn_nein_20.Name = "btn_nein_20";
            this.btn_nein_20.Size = new System.Drawing.Size(158, 65);
            this.btn_nein_20.TabIndex = 99;
            this.btn_nein_20.Text = "Nein";
            this.btn_nein_20.UseVisualStyleBackColor = false;
            this.btn_nein_20.Click += new System.EventHandler(this.btn_nein_Click);
            this.btn_nein_20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JaNeinFrage_MouseDown);
            // 
            // btn_ja_20
            // 
            this.btn_ja_20.AutoSize = true;
            this.btn_ja_20.BackColor = System.Drawing.Color.Transparent;
            this.btn_ja_20.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btn_ja_20.FensterBeiRechtsklickSchliessen = false;
            this.btn_ja_20.FlatAppearance.BorderSize = 0;
            this.btn_ja_20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ja_20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ja_20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ja_20.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ja_20.ForeColor = System.Drawing.Color.Black;
            this.btn_ja_20.Location = new System.Drawing.Point(90, 265);
            this.btn_ja_20.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ja_20.Name = "btn_ja_20";
            this.btn_ja_20.Size = new System.Drawing.Size(158, 65);
            this.btn_ja_20.TabIndex = 98;
            this.btn_ja_20.Text = "Ja";
            this.btn_ja_20.UseVisualStyleBackColor = false;
            this.btn_ja_20.Click += new System.EventHandler(this.btn_ja_Click);
            this.btn_ja_20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JaNeinFrage_MouseDown);
            // 
            // JaNeinFrage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 383);
            this.Controls.Add(this.btn_nein_20);
            this.Controls.Add(this.btn_ja_20);
            this.Controls.Add(this.lbl_frage_20);
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "JaNeinFrage";
            this.Text = "JaNeinFrage";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.JaNeinFrage_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_frage_20;
        private LinkButton btn_nein_20;
        private LinkButton btn_ja_20;
    }
}