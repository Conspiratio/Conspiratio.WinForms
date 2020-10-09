namespace Conspiratio
{
    partial class Bestechen
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
            this.lbl_header = new System.Windows.Forms.Label();
            this.lbl_text = new System.Windows.Forms.Label();
            this.btn_bestechen = new System.Windows.Forms.Button();
            this.btn_abbrechen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Taler = new Conspiratio.NumericButton();
            this.SuspendLayout();
            // 
            // lbl_header
            // 
            this.lbl_header.AutoSize = true;
            this.lbl_header.BackColor = System.Drawing.Color.Transparent;
            this.lbl_header.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_header.ForeColor = System.Drawing.Color.Black;
            this.lbl_header.Location = new System.Drawing.Point(127, 57);
            this.lbl_header.Name = "lbl_header";
            this.lbl_header.Size = new System.Drawing.Size(117, 24);
            this.lbl_header.TabIndex = 109;
            this.lbl_header.Text = "Beziehung";
            this.lbl_header.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_header_MouseDown);
            // 
            // lbl_text
            // 
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_text.Location = new System.Drawing.Point(46, 96);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(304, 120);
            this.lbl_text.TabIndex = 112;
            this.lbl_text.Text = "Abbrechen";
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_text_MouseDown);
            // 
            // btn_bestechen
            // 
            this.btn_bestechen.BackColor = System.Drawing.Color.Transparent;
            this.btn_bestechen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bestechen.FlatAppearance.BorderSize = 0;
            this.btn_bestechen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_bestechen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_bestechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bestechen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bestechen.ForeColor = System.Drawing.Color.Black;
            this.btn_bestechen.Location = new System.Drawing.Point(84, 233);
            this.btn_bestechen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_bestechen.Name = "btn_bestechen";
            this.btn_bestechen.Size = new System.Drawing.Size(20, 20);
            this.btn_bestechen.TabIndex = 113;
            this.btn_bestechen.UseVisualStyleBackColor = false;
            this.btn_bestechen.Click += new System.EventHandler(this.btn_bestechen_Click);
            this.btn_bestechen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_bestechen_MouseMove);
            // 
            // btn_abbrechen
            // 
            this.btn_abbrechen.BackColor = System.Drawing.Color.Transparent;
            this.btn_abbrechen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_abbrechen.FlatAppearance.BorderSize = 0;
            this.btn_abbrechen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_abbrechen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_abbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_abbrechen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_abbrechen.ForeColor = System.Drawing.Color.Black;
            this.btn_abbrechen.Location = new System.Drawing.Point(84, 270);
            this.btn_abbrechen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_abbrechen.Name = "btn_abbrechen";
            this.btn_abbrechen.Size = new System.Drawing.Size(20, 20);
            this.btn_abbrechen.TabIndex = 114;
            this.btn_abbrechen.UseVisualStyleBackColor = false;
            this.btn_abbrechen.Click += new System.EventHandler(this.btn_abbrechen_Click);
            this.btn_abbrechen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btn_abbrechen_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(115, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 115;
            this.label1.Text = "Abbrechen";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // btn_Taler
            // 
            this.btn_Taler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Taler.BackColor = System.Drawing.Color.Transparent;
            this.btn_Taler.FlatAppearance.BorderSize = 0;
            this.btn_Taler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Taler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Taler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Taler.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.btn_Taler.ForeColor = System.Drawing.Color.Black;
            this.btn_Taler.Location = new System.Drawing.Point(111, 223);
            this.btn_Taler.Name = "btn_Taler";
            this.btn_Taler.Size = new System.Drawing.Size(146, 40);
            this.btn_Taler.TabIndex = 117;
            this.btn_Taler.Text = "000.000.000";
            this.btn_Taler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Taler.UseVisualStyleBackColor = false;
            this.btn_Taler.Wert = 0;
            // 
            // Bestechen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 364);
            this.Controls.Add(this.btn_Taler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_abbrechen);
            this.Controls.Add(this.btn_bestechen);
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.lbl_header);
            this.Name = "Bestechen";
            this.Text = "Bestechen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Bestechen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_header;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Button btn_bestechen;
        private System.Windows.Forms.Button btn_abbrechen;
        private System.Windows.Forms.Label label1;
        private NumericButton btn_Taler;
    }
}