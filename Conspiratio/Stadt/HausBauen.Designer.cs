using Conspiratio.Controls;

namespace Conspiratio
{
    partial class HausBauen
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
            this.btn_bild = new System.Windows.Forms.Button();
            this.lbl_bauen = new System.Windows.Forms.Label();
            this.btn_bauen = new CrystalButton();
            this.lbl_verkaufen = new System.Windows.Forms.Label();
            this.btn_verkaufen = new CrystalButton();
            this.lbl_renovieren = new System.Windows.Forms.Label();
            this.btn_renovieren = new CrystalButton();
            this.lbl_erweitern = new System.Windows.Forms.Label();
            this.btn_erweitern = new CrystalButton();
            this.lbl_zustand = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.Location = new System.Drawing.Point(50, 43);
            this.lbl_text.MaximumSize = new System.Drawing.Size(485, 0);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(80, 28);
            this.lbl_text.TabIndex = 2;
            this.lbl_text.Text = "label1";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // btn_bild
            // 
            this.btn_bild.BackColor = System.Drawing.Color.Transparent;
            this.btn_bild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_bild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_bild.ForeColor = System.Drawing.Color.Transparent;
            this.btn_bild.Location = new System.Drawing.Point(242, 133);
            this.btn_bild.Margin = new System.Windows.Forms.Padding(0);
            this.btn_bild.Name = "btn_bild";
            this.btn_bild.Size = new System.Drawing.Size(300, 300);
            this.btn_bild.TabIndex = 202;
            this.btn_bild.UseVisualStyleBackColor = false;
            this.btn_bild.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bild_MouseDown);
            // 
            // lbl_bauen
            // 
            this.lbl_bauen.AutoSize = true;
            this.lbl_bauen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_bauen.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_bauen.ForeColor = System.Drawing.Color.Black;
            this.lbl_bauen.Location = new System.Drawing.Point(85, 133);
            this.lbl_bauen.Name = "lbl_bauen";
            this.lbl_bauen.Size = new System.Drawing.Size(96, 32);
            this.lbl_bauen.TabIndex = 226;
            this.lbl_bauen.Text = "Bauen";
            this.lbl_bauen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // btn_bauen
            // 
            this.btn_bauen.BackColor = System.Drawing.Color.Transparent;
            this.btn_bauen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bauen.FlatAppearance.BorderSize = 0;
            this.btn_bauen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_bauen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_bauen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bauen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_bauen.ForeColor = System.Drawing.Color.Black;
            this.btn_bauen.Location = new System.Drawing.Point(55, 139);
            this.btn_bauen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_bauen.Name = "btn_bauen";
            this.btn_bauen.Size = new System.Drawing.Size(20, 20);
            this.btn_bauen.TabIndex = 225;
            this.btn_bauen.UseVisualStyleBackColor = false;
            this.btn_bauen.Click += new System.EventHandler(this.btn_bauen_Click);
            this.btn_bauen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // lbl_verkaufen
            // 
            this.lbl_verkaufen.AutoSize = true;
            this.lbl_verkaufen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_verkaufen.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_verkaufen.ForeColor = System.Drawing.Color.Black;
            this.lbl_verkaufen.Location = new System.Drawing.Point(85, 259);
            this.lbl_verkaufen.Name = "lbl_verkaufen";
            this.lbl_verkaufen.Size = new System.Drawing.Size(143, 32);
            this.lbl_verkaufen.TabIndex = 228;
            this.lbl_verkaufen.Text = "Verkaufen";
            this.lbl_verkaufen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // btn_verkaufen
            // 
            this.btn_verkaufen.BackColor = System.Drawing.Color.Transparent;
            this.btn_verkaufen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_verkaufen.FlatAppearance.BorderSize = 0;
            this.btn_verkaufen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_verkaufen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_verkaufen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verkaufen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verkaufen.ForeColor = System.Drawing.Color.Black;
            this.btn_verkaufen.Location = new System.Drawing.Point(55, 265);
            this.btn_verkaufen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_verkaufen.Name = "btn_verkaufen";
            this.btn_verkaufen.Size = new System.Drawing.Size(20, 20);
            this.btn_verkaufen.TabIndex = 227;
            this.btn_verkaufen.UseVisualStyleBackColor = false;
            this.btn_verkaufen.Click += new System.EventHandler(this.btn_verkaufen_Click);
            this.btn_verkaufen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // lbl_renovieren
            // 
            this.lbl_renovieren.AutoSize = true;
            this.lbl_renovieren.BackColor = System.Drawing.Color.Transparent;
            this.lbl_renovieren.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_renovieren.ForeColor = System.Drawing.Color.Black;
            this.lbl_renovieren.Location = new System.Drawing.Point(85, 175);
            this.lbl_renovieren.Name = "lbl_renovieren";
            this.lbl_renovieren.Size = new System.Drawing.Size(160, 32);
            this.lbl_renovieren.TabIndex = 230;
            this.lbl_renovieren.Text = "Renovieren";
            this.lbl_renovieren.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // btn_renovieren
            // 
            this.btn_renovieren.BackColor = System.Drawing.Color.Transparent;
            this.btn_renovieren.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_renovieren.FlatAppearance.BorderSize = 0;
            this.btn_renovieren.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_renovieren.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_renovieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_renovieren.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_renovieren.ForeColor = System.Drawing.Color.Black;
            this.btn_renovieren.Location = new System.Drawing.Point(55, 181);
            this.btn_renovieren.Margin = new System.Windows.Forms.Padding(0);
            this.btn_renovieren.Name = "btn_renovieren";
            this.btn_renovieren.Size = new System.Drawing.Size(20, 20);
            this.btn_renovieren.TabIndex = 229;
            this.btn_renovieren.UseVisualStyleBackColor = false;
            this.btn_renovieren.Click += new System.EventHandler(this.btn_renovieren_Click);
            this.btn_renovieren.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // lbl_erweitern
            // 
            this.lbl_erweitern.AutoSize = true;
            this.lbl_erweitern.BackColor = System.Drawing.Color.Transparent;
            this.lbl_erweitern.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_erweitern.ForeColor = System.Drawing.Color.Black;
            this.lbl_erweitern.Location = new System.Drawing.Point(85, 217);
            this.lbl_erweitern.Name = "lbl_erweitern";
            this.lbl_erweitern.Size = new System.Drawing.Size(138, 32);
            this.lbl_erweitern.TabIndex = 232;
            this.lbl_erweitern.Text = "Erweitern";
            this.lbl_erweitern.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // btn_erweitern
            // 
            this.btn_erweitern.BackColor = System.Drawing.Color.Transparent;
            this.btn_erweitern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_erweitern.FlatAppearance.BorderSize = 0;
            this.btn_erweitern.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_erweitern.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_erweitern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_erweitern.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_erweitern.ForeColor = System.Drawing.Color.Black;
            this.btn_erweitern.Location = new System.Drawing.Point(55, 223);
            this.btn_erweitern.Margin = new System.Windows.Forms.Padding(0);
            this.btn_erweitern.Name = "btn_erweitern";
            this.btn_erweitern.Size = new System.Drawing.Size(20, 20);
            this.btn_erweitern.TabIndex = 231;
            this.btn_erweitern.UseVisualStyleBackColor = false;
            this.btn_erweitern.Click += new System.EventHandler(this.btn_erweitern_Click);
            this.btn_erweitern.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // lbl_zustand
            // 
            this.lbl_zustand.AutoSize = true;
            this.lbl_zustand.BackColor = System.Drawing.Color.Transparent;
            this.lbl_zustand.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_zustand.ForeColor = System.Drawing.Color.Black;
            this.lbl_zustand.Location = new System.Drawing.Point(50, 401);
            this.lbl_zustand.Name = "lbl_zustand";
            this.lbl_zustand.Size = new System.Drawing.Size(186, 28);
            this.lbl_zustand.TabIndex = 233;
            this.lbl_zustand.Text = "Zustand: 100 %";
            this.lbl_zustand.Visible = false;
            this.lbl_zustand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_bauen_MouseDown);
            // 
            // HausBauen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 475);
            this.Controls.Add(this.lbl_zustand);
            this.Controls.Add(this.lbl_erweitern);
            this.Controls.Add(this.btn_erweitern);
            this.Controls.Add(this.lbl_renovieren);
            this.Controls.Add(this.btn_renovieren);
            this.Controls.Add(this.lbl_verkaufen);
            this.Controls.Add(this.btn_verkaufen);
            this.Controls.Add(this.lbl_bauen);
            this.Controls.Add(this.btn_bauen);
            this.Controls.Add(this.btn_bild);
            this.Controls.Add(this.lbl_text);
            this.Name = "HausBauen";
            this.Text = "HausBauen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HausBauen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Button btn_bild;
        private System.Windows.Forms.Label lbl_bauen;
        private CrystalButton btn_bauen;
        private System.Windows.Forms.Label lbl_verkaufen;
        private CrystalButton btn_verkaufen;
        private System.Windows.Forms.Label lbl_renovieren;
        private CrystalButton btn_renovieren;
        private System.Windows.Forms.Label lbl_erweitern;
        private CrystalButton btn_erweitern;
        private System.Windows.Forms.Label lbl_zustand;
    }
}