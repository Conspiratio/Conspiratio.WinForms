using Conspiratio.Controls;

namespace Conspiratio
{
    partial class Optionen
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
            this.btn_hpt_beenden = new FlatButton();
            this.btn_Zurueck = new FlatButton();
            this.btn_speichern = new FlatButton();
            this.btn_laden = new FlatButton();
            this.btn_hauptmenue = new FlatButton();
            this.btn_SpHinaus = new FlatButton();
            this.btn_Sphinzu = new FlatButton();
            this.btn_optionen = new FlatButton();
            this.SuspendLayout();
            // 
            // btn_hpt_beenden
            // 
            this.btn_hpt_beenden.BackColor = System.Drawing.Color.Transparent;
            this.btn_hpt_beenden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_hpt_beenden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_hpt_beenden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_hpt_beenden.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hpt_beenden.ForeColor = System.Drawing.Color.Gold;
            this.btn_hpt_beenden.Location = new System.Drawing.Point(477, 301);
            this.btn_hpt_beenden.Margin = new System.Windows.Forms.Padding(0);
            this.btn_hpt_beenden.Name = "btn_hpt_beenden";
            this.btn_hpt_beenden.Size = new System.Drawing.Size(319, 54);
            this.btn_hpt_beenden.TabIndex = 250;
            this.btn_hpt_beenden.Text = "Spiel beenden";
            this.btn_hpt_beenden.UseVisualStyleBackColor = false;
            this.btn_hpt_beenden.Click += new System.EventHandler(this.btn_hpt_beenden_Click);
            this.btn_hpt_beenden.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_hpt_beenden_MouseDown);
            // 
            // btn_Zurueck
            // 
            this.btn_Zurueck.BackColor = System.Drawing.Color.Transparent;
            this.btn_Zurueck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Zurueck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_Zurueck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Zurueck.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Zurueck.ForeColor = System.Drawing.Color.Gold;
            this.btn_Zurueck.Location = new System.Drawing.Point(97, 60);
            this.btn_Zurueck.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Zurueck.Name = "btn_Zurueck";
            this.btn_Zurueck.Size = new System.Drawing.Size(319, 54);
            this.btn_Zurueck.TabIndex = 249;
            this.btn_Zurueck.Text = "Zurück zum Spiel";
            this.btn_Zurueck.UseVisualStyleBackColor = false;
            this.btn_Zurueck.Click += new System.EventHandler(this.btn_Zurueck_Click);
            this.btn_Zurueck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Zurueck_MouseDown);
            // 
            // btn_speichern
            // 
            this.btn_speichern.BackColor = System.Drawing.Color.Transparent;
            this.btn_speichern.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_speichern.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_speichern.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_speichern.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_speichern.ForeColor = System.Drawing.Color.Gold;
            this.btn_speichern.Location = new System.Drawing.Point(97, 220);
            this.btn_speichern.Margin = new System.Windows.Forms.Padding(0);
            this.btn_speichern.Name = "btn_speichern";
            this.btn_speichern.Size = new System.Drawing.Size(319, 54);
            this.btn_speichern.TabIndex = 248;
            this.btn_speichern.Text = "Spiel speichern";
            this.btn_speichern.UseVisualStyleBackColor = false;
            this.btn_speichern.Click += new System.EventHandler(this.btn_speichern_Click);
            this.btn_speichern.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_speichern_MouseDown);
            // 
            // btn_laden
            // 
            this.btn_laden.BackColor = System.Drawing.Color.Transparent;
            this.btn_laden.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_laden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_laden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_laden.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_laden.ForeColor = System.Drawing.Color.Gold;
            this.btn_laden.Location = new System.Drawing.Point(97, 301);
            this.btn_laden.Margin = new System.Windows.Forms.Padding(0);
            this.btn_laden.Name = "btn_laden";
            this.btn_laden.Size = new System.Drawing.Size(319, 54);
            this.btn_laden.TabIndex = 247;
            this.btn_laden.Text = "Spiel laden";
            this.btn_laden.UseVisualStyleBackColor = false;
            this.btn_laden.Click += new System.EventHandler(this.btn_laden_Click);
            this.btn_laden.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_laden_MouseDown);
            // 
            // btn_hauptmenue
            // 
            this.btn_hauptmenue.BackColor = System.Drawing.Color.Transparent;
            this.btn_hauptmenue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_hauptmenue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_hauptmenue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_hauptmenue.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hauptmenue.ForeColor = System.Drawing.Color.Gold;
            this.btn_hauptmenue.Location = new System.Drawing.Point(97, 140);
            this.btn_hauptmenue.Margin = new System.Windows.Forms.Padding(0);
            this.btn_hauptmenue.Name = "btn_hauptmenue";
            this.btn_hauptmenue.Size = new System.Drawing.Size(319, 54);
            this.btn_hauptmenue.TabIndex = 246;
            this.btn_hauptmenue.Text = "Hauptmenü";
            this.btn_hauptmenue.UseVisualStyleBackColor = false;
            this.btn_hauptmenue.Click += new System.EventHandler(this.btn_hauptmenue_Click);
            this.btn_hauptmenue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_hauptmenue_MouseDown);
            // 
            // btn_SpHinaus
            // 
            this.btn_SpHinaus.BackColor = System.Drawing.Color.Transparent;
            this.btn_SpHinaus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SpHinaus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_SpHinaus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SpHinaus.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SpHinaus.ForeColor = System.Drawing.Color.Gold;
            this.btn_SpHinaus.Location = new System.Drawing.Point(477, 140);
            this.btn_SpHinaus.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SpHinaus.Name = "btn_SpHinaus";
            this.btn_SpHinaus.Size = new System.Drawing.Size(319, 54);
            this.btn_SpHinaus.TabIndex = 251;
            this.btn_SpHinaus.Text = "Spieler hinauswerfen";
            this.btn_SpHinaus.UseVisualStyleBackColor = false;
            this.btn_SpHinaus.Click += new System.EventHandler(this.btn_SpHinaus_Click);
            this.btn_SpHinaus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_SpHinaus_MouseDown);
            // 
            // btn_Sphinzu
            // 
            this.btn_Sphinzu.BackColor = System.Drawing.Color.Transparent;
            this.btn_Sphinzu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Sphinzu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_Sphinzu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Sphinzu.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sphinzu.ForeColor = System.Drawing.Color.Gold;
            this.btn_Sphinzu.Location = new System.Drawing.Point(477, 60);
            this.btn_Sphinzu.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Sphinzu.Name = "btn_Sphinzu";
            this.btn_Sphinzu.Size = new System.Drawing.Size(319, 54);
            this.btn_Sphinzu.TabIndex = 252;
            this.btn_Sphinzu.Text = "Spieler hinzufügen";
            this.btn_Sphinzu.UseVisualStyleBackColor = false;
            this.btn_Sphinzu.Click += new System.EventHandler(this.btn_Sphinzu_Click);
            this.btn_Sphinzu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Sphinzu_MouseDown);
            // 
            // btn_optionen
            // 
            this.btn_optionen.BackColor = System.Drawing.Color.Transparent;
            this.btn_optionen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_optionen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_optionen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_optionen.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_optionen.ForeColor = System.Drawing.Color.Gold;
            this.btn_optionen.Location = new System.Drawing.Point(477, 220);
            this.btn_optionen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_optionen.Name = "btn_optionen";
            this.btn_optionen.Size = new System.Drawing.Size(319, 54);
            this.btn_optionen.TabIndex = 253;
            this.btn_optionen.Text = "Optionen";
            this.btn_optionen.UseVisualStyleBackColor = false;
            this.btn_optionen.Click += new System.EventHandler(this.btn_optionen_Click);
            // 
            // Optionen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 409);
            this.Controls.Add(this.btn_optionen);
            this.Controls.Add(this.btn_Sphinzu);
            this.Controls.Add(this.btn_SpHinaus);
            this.Controls.Add(this.btn_hpt_beenden);
            this.Controls.Add(this.btn_Zurueck);
            this.Controls.Add(this.btn_speichern);
            this.Controls.Add(this.btn_laden);
            this.Controls.Add(this.btn_hauptmenue);
            this.Name = "Optionen";
            this.Text = "Optionen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Optionen_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatButton btn_hpt_beenden;
        private FlatButton btn_Zurueck;
        private FlatButton btn_speichern;
        private FlatButton btn_laden;
        private FlatButton btn_hauptmenue;
        private FlatButton btn_SpHinaus;
        private FlatButton btn_Sphinzu;
        private FlatButton btn_optionen;
    }
}