using Conspiratio.Controls;

namespace Conspiratio.Kampf
{
    partial class frmStuetzpunktKaufen
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
            this.lbl_ueberschrift = new System.Windows.Forms.Label();
            this.lbl_zustand = new System.Windows.Forms.Label();
            this.btn_bild = new System.Windows.Forms.Button();
            this.lbl_sicherheit_tarnung = new System.Windows.Forms.Label();
            this.lbl_beschreibung = new System.Windows.Forms.Label();
            this.lbl_kaufangebot = new System.Windows.Forms.Label();
            this.btn_kaufangebot = new CrystalButton();
            this.lbl_wert = new System.Windows.Forms.Label();
            this.btn_Taler = new Conspiratio.NumericButton();
            this.SuspendLayout();
            // 
            // lbl_ueberschrift
            // 
            this.lbl_ueberschrift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ueberschrift.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ueberschrift.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ueberschrift.Location = new System.Drawing.Point(39, 32);
            this.lbl_ueberschrift.MaximumSize = new System.Drawing.Size(485, 39);
            this.lbl_ueberschrift.Name = "lbl_ueberschrift";
            this.lbl_ueberschrift.Size = new System.Drawing.Size(323, 39);
            this.lbl_ueberschrift.TabIndex = 3;
            this.lbl_ueberschrift.Text = "Redcastle";
            this.lbl_ueberschrift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ueberschrift.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // lbl_zustand
            // 
            this.lbl_zustand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_zustand.AutoSize = true;
            this.lbl_zustand.BackColor = System.Drawing.Color.Transparent;
            this.lbl_zustand.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_zustand.ForeColor = System.Drawing.Color.Black;
            this.lbl_zustand.Location = new System.Drawing.Point(374, 269);
            this.lbl_zustand.Name = "lbl_zustand";
            this.lbl_zustand.Size = new System.Drawing.Size(184, 29);
            this.lbl_zustand.TabIndex = 234;
            this.lbl_zustand.Text = "Zustand: 100 %";
            this.lbl_zustand.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // btn_bild
            // 
            this.btn_bild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_bild.BackColor = System.Drawing.Color.Transparent;
            this.btn_bild.BackgroundImage = global::Conspiratio.Properties.Resources.SymbDoor;
            this.btn_bild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_bild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_bild.ForeColor = System.Drawing.Color.Transparent;
            this.btn_bild.Location = new System.Drawing.Point(379, 32);
            this.btn_bild.Margin = new System.Windows.Forms.Padding(0);
            this.btn_bild.Name = "btn_bild";
            this.btn_bild.Size = new System.Drawing.Size(236, 227);
            this.btn_bild.TabIndex = 235;
            this.btn_bild.UseVisualStyleBackColor = false;
            this.btn_bild.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // lbl_sicherheit_tarnung
            // 
            this.lbl_sicherheit_tarnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_sicherheit_tarnung.AutoSize = true;
            this.lbl_sicherheit_tarnung.BackColor = System.Drawing.Color.Transparent;
            this.lbl_sicherheit_tarnung.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sicherheit_tarnung.ForeColor = System.Drawing.Color.Black;
            this.lbl_sicherheit_tarnung.Location = new System.Drawing.Point(374, 299);
            this.lbl_sicherheit_tarnung.Name = "lbl_sicherheit_tarnung";
            this.lbl_sicherheit_tarnung.Size = new System.Drawing.Size(207, 29);
            this.lbl_sicherheit_tarnung.TabIndex = 236;
            this.lbl_sicherheit_tarnung.Text = "Sicherheit: 100 %";
            this.lbl_sicherheit_tarnung.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // lbl_beschreibung
            // 
            this.lbl_beschreibung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_beschreibung.BackColor = System.Drawing.Color.Transparent;
            this.lbl_beschreibung.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_beschreibung.Location = new System.Drawing.Point(39, 94);
            this.lbl_beschreibung.MaximumSize = new System.Drawing.Size(323, 204);
            this.lbl_beschreibung.Name = "lbl_beschreibung";
            this.lbl_beschreibung.Size = new System.Drawing.Size(323, 204);
            this.lbl_beschreibung.TabIndex = 237;
            this.lbl_beschreibung.Text = "Zollburg im Besitz von Graf Markus, Regent in Lottringen.";
            this.lbl_beschreibung.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // lbl_kaufangebot
            // 
            this.lbl_kaufangebot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_kaufangebot.AutoSize = true;
            this.lbl_kaufangebot.BackColor = System.Drawing.Color.Transparent;
            this.lbl_kaufangebot.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_kaufangebot.ForeColor = System.Drawing.Color.Black;
            this.lbl_kaufangebot.Location = new System.Drawing.Point(73, 353);
            this.lbl_kaufangebot.Name = "lbl_kaufangebot";
            this.lbl_kaufangebot.Size = new System.Drawing.Size(261, 28);
            this.lbl_kaufangebot.TabIndex = 239;
            this.lbl_kaufangebot.Text = "Kaufangebot machen:";
            this.lbl_kaufangebot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // btn_kaufangebot
            // 
            this.btn_kaufangebot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_kaufangebot.BackColor = System.Drawing.Color.Transparent;
            this.btn_kaufangebot.BackgroundImage = global::Conspiratio.Properties.Resources.SymbUnchecked;
            this.btn_kaufangebot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kaufangebot.FlatAppearance.BorderSize = 0;
            this.btn_kaufangebot.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_kaufangebot.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_kaufangebot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kaufangebot.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kaufangebot.ForeColor = System.Drawing.Color.Black;
            this.btn_kaufangebot.Location = new System.Drawing.Point(44, 356);
            this.btn_kaufangebot.Margin = new System.Windows.Forms.Padding(0);
            this.btn_kaufangebot.Name = "btn_kaufangebot";
            this.btn_kaufangebot.Size = new System.Drawing.Size(20, 20);
            this.btn_kaufangebot.TabIndex = 238;
            this.btn_kaufangebot.UseVisualStyleBackColor = false;
            this.btn_kaufangebot.Click += new System.EventHandler(this.btn_kaufangebot_Click);
            this.btn_kaufangebot.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // lbl_wert
            // 
            this.lbl_wert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_wert.AutoSize = true;
            this.lbl_wert.BackColor = System.Drawing.Color.Transparent;
            this.lbl_wert.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_wert.ForeColor = System.Drawing.Color.Black;
            this.lbl_wert.Location = new System.Drawing.Point(39, 299);
            this.lbl_wert.Name = "lbl_wert";
            this.lbl_wert.Size = new System.Drawing.Size(214, 29);
            this.lbl_wert.TabIndex = 240;
            this.lbl_wert.Text = "Wert: 37.500 Taler";
            this.lbl_wert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            // 
            // btn_Taler
            // 
            this.btn_Taler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Taler.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Taler.BackColor = System.Drawing.Color.Transparent;
            this.btn_Taler.FlatAppearance.BorderSize = 0;
            this.btn_Taler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Taler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Taler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Taler.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Taler.ForeColor = System.Drawing.Color.Black;
            this.btn_Taler.Location = new System.Drawing.Point(307, 347);
            this.btn_Taler.MaximalerWert = 999999999;
            this.btn_Taler.MaximaleStellen = 9;
            this.btn_Taler.MinimalerWert = 0;
            this.btn_Taler.Name = "btn_Taler";
            this.btn_Taler.NurEinserSchritte = false;
            this.btn_Taler.Size = new System.Drawing.Size(161, 40);
            this.btn_Taler.TabIndex = 241;
            this.btn_Taler.TausenderTrenner = true;
            this.btn_Taler.Text = "000.000.000";
            this.btn_Taler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Taler.UseVisualStyleBackColor = false;
            this.btn_Taler.Wert = 0;
            this.btn_Taler.WertAnzeigen = true;
            // 
            // frmStuetzpunktKaufen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 417);
            this.Controls.Add(this.btn_Taler);
            this.Controls.Add(this.lbl_wert);
            this.Controls.Add(this.lbl_kaufangebot);
            this.Controls.Add(this.btn_kaufangebot);
            this.Controls.Add(this.lbl_beschreibung);
            this.Controls.Add(this.lbl_sicherheit_tarnung);
            this.Controls.Add(this.btn_bild);
            this.Controls.Add(this.lbl_zustand);
            this.Controls.Add(this.lbl_ueberschrift);
            this.Name = "frmStuetzpunktKaufen";
            this.Text = "frmStuetzpunktKaufen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktKaufen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ueberschrift;
        private System.Windows.Forms.Label lbl_zustand;
        private System.Windows.Forms.Button btn_bild;
        private System.Windows.Forms.Label lbl_sicherheit_tarnung;
        private System.Windows.Forms.Label lbl_beschreibung;
        private System.Windows.Forms.Label lbl_kaufangebot;
        private CrystalButton btn_kaufangebot;
        private System.Windows.Forms.Label lbl_wert;
        private NumericButton btn_Taler;
    }
}