namespace Conspiratio
{
    partial class Einzelspieler
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
            this.btn_neuesSpiel = new Conspiratio.Controls.FlatButton();
            this.btn_spielLaden = new Conspiratio.Controls.FlatButton();
            this.lbl_hot_seat_text = new System.Windows.Forms.Label();
            this.btn_spiel_fortsetzen = new Conspiratio.Controls.FlatButton();
            this.SuspendLayout();
            // 
            // btn_neuesSpiel
            // 
            this.btn_neuesSpiel.BackColor = System.Drawing.Color.Transparent;
            this.btn_neuesSpiel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_neuesSpiel.FlatAppearance.BorderSize = 0;
            this.btn_neuesSpiel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_neuesSpiel.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_neuesSpiel.Location = new System.Drawing.Point(48, 97);
            this.btn_neuesSpiel.Name = "btn_neuesSpiel";
            this.btn_neuesSpiel.Size = new System.Drawing.Size(224, 42);
            this.btn_neuesSpiel.TabIndex = 228;
            this.btn_neuesSpiel.Text = "Spiel starten";
            this.btn_neuesSpiel.UseVisualStyleBackColor = false;
            this.btn_neuesSpiel.Click += new System.EventHandler(this.btn_neuesSpiel_Click);
            this.btn_neuesSpiel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_hot_seat_text_MouseDown);
            // 
            // btn_spielLaden
            // 
            this.btn_spielLaden.BackColor = System.Drawing.Color.Transparent;
            this.btn_spielLaden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_spielLaden.FlatAppearance.BorderSize = 0;
            this.btn_spielLaden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_spielLaden.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_spielLaden.Location = new System.Drawing.Point(48, 155);
            this.btn_spielLaden.Name = "btn_spielLaden";
            this.btn_spielLaden.Size = new System.Drawing.Size(224, 42);
            this.btn_spielLaden.TabIndex = 229;
            this.btn_spielLaden.Text = "Spiel laden";
            this.btn_spielLaden.UseVisualStyleBackColor = false;
            this.btn_spielLaden.Click += new System.EventHandler(this.btn_spielLaden_Click);
            this.btn_spielLaden.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_hot_seat_text_MouseDown);
            // 
            // lbl_hot_seat_text
            // 
            this.lbl_hot_seat_text.AutoSize = true;
            this.lbl_hot_seat_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_hot_seat_text.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hot_seat_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_hot_seat_text.Location = new System.Drawing.Point(55, 36);
            this.lbl_hot_seat_text.Name = "lbl_hot_seat_text";
            this.lbl_hot_seat_text.Size = new System.Drawing.Size(148, 37);
            this.lbl_hot_seat_text.TabIndex = 230;
            this.lbl_hot_seat_text.Text = "Hot-Seat";
            this.lbl_hot_seat_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_hot_seat_text_MouseDown);
            // 
            // btn_spiel_fortsetzen
            // 
            this.btn_spiel_fortsetzen.BackColor = System.Drawing.Color.Transparent;
            this.btn_spiel_fortsetzen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_spiel_fortsetzen.Enabled = false;
            this.btn_spiel_fortsetzen.FlatAppearance.BorderSize = 0;
            this.btn_spiel_fortsetzen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_spiel_fortsetzen.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_spiel_fortsetzen.Location = new System.Drawing.Point(48, 214);
            this.btn_spiel_fortsetzen.Name = "btn_spiel_fortsetzen";
            this.btn_spiel_fortsetzen.Size = new System.Drawing.Size(224, 42);
            this.btn_spiel_fortsetzen.TabIndex = 231;
            this.btn_spiel_fortsetzen.Text = "Spiel fortsetzen";
            this.btn_spiel_fortsetzen.UseVisualStyleBackColor = false;
            this.btn_spiel_fortsetzen.Click += new System.EventHandler(this.btn_spiel_fortsetzen_Click);
            this.btn_spiel_fortsetzen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_hot_seat_text_MouseDown);
            // 
            // Einzelspieler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 289);
            this.Controls.Add(this.btn_spiel_fortsetzen);
            this.Controls.Add(this.lbl_hot_seat_text);
            this.Controls.Add(this.btn_spielLaden);
            this.Controls.Add(this.btn_neuesSpiel);
            this.Name = "Einzelspieler";
            this.Text = "Einzelspieler";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_hot_seat_text_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Conspiratio.Controls.FlatButton btn_neuesSpiel;
        private Conspiratio.Controls.FlatButton btn_spielLaden;
        private System.Windows.Forms.Label lbl_hot_seat_text;
        private Conspiratio.Controls.FlatButton btn_spiel_fortsetzen;
    }
}