namespace Conspiratio.Hauptmenue
{
    partial class frmEinstellungen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEinstellungen));
            this.lbl_ueberschrift = new System.Windows.Forms.Label();
            this.trb_musik_lautstaerke = new System.Windows.Forms.TrackBar();
            this.lbl_musik_lautstaerke = new System.Windows.Forms.Label();
            this.lbl_musik_ausschalten = new System.Windows.Forms.Label();
            this.btn_musik_ausschalten = new Conspiratio.Controls.CrystalButton();
            this.btn_tipps_anzeigen = new Conspiratio.Controls.CrystalButton();
            this.lbl_tipps_anzeigen = new System.Windows.Forms.Label();
            this.btn_statistik_anzeigen = new Conspiratio.Controls.CrystalButton();
            this.lbl_statistik_anzeigen = new System.Windows.Forms.Label();
            this.lbl_effekt_lautstaerke = new System.Windows.Forms.Label();
            this.trb_effekt_lautstaerke = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trb_musik_lautstaerke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_effekt_lautstaerke)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_ueberschrift
            // 
            this.lbl_ueberschrift.AutoSize = true;
            this.lbl_ueberschrift.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ueberschrift.Font = new System.Drawing.Font("Arial", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ueberschrift.ForeColor = System.Drawing.Color.Black;
            this.lbl_ueberschrift.Location = new System.Drawing.Point(142, 36);
            this.lbl_ueberschrift.Name = "lbl_ueberschrift";
            this.lbl_ueberschrift.Size = new System.Drawing.Size(167, 40);
            this.lbl_ueberschrift.TabIndex = 238;
            this.lbl_ueberschrift.Text = "Optionen";
            this.lbl_ueberschrift.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // trb_musik_lautstaerke
            // 
            this.trb_musik_lautstaerke.Location = new System.Drawing.Point(88, 263);
            this.trb_musik_lautstaerke.Maximum = 100;
            this.trb_musik_lautstaerke.Name = "trb_musik_lautstaerke";
            this.trb_musik_lautstaerke.Size = new System.Drawing.Size(289, 45);
            this.trb_musik_lautstaerke.TabIndex = 240;
            this.trb_musik_lautstaerke.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trb_musik_lautstaerke.Value = 100;
            this.trb_musik_lautstaerke.Scroll += new System.EventHandler(this.trb_musik_lautstaerke_Scroll);
            this.trb_musik_lautstaerke.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_musik_lautstaerke
            // 
            this.lbl_musik_lautstaerke.BackColor = System.Drawing.Color.Transparent;
            this.lbl_musik_lautstaerke.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_musik_lautstaerke.ForeColor = System.Drawing.Color.Black;
            this.lbl_musik_lautstaerke.Location = new System.Drawing.Point(83, 230);
            this.lbl_musik_lautstaerke.Name = "lbl_musik_lautstaerke";
            this.lbl_musik_lautstaerke.Size = new System.Drawing.Size(310, 29);
            this.lbl_musik_lautstaerke.TabIndex = 241;
            this.lbl_musik_lautstaerke.Text = "Musik Lautstärke - 100 %";
            this.lbl_musik_lautstaerke.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_musik_ausschalten
            // 
            this.lbl_musik_ausschalten.BackColor = System.Drawing.Color.Transparent;
            this.lbl_musik_ausschalten.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_musik_ausschalten.ForeColor = System.Drawing.Color.Black;
            this.lbl_musik_ausschalten.Location = new System.Drawing.Point(83, 108);
            this.lbl_musik_ausschalten.Name = "lbl_musik_ausschalten";
            this.lbl_musik_ausschalten.Size = new System.Drawing.Size(354, 29);
            this.lbl_musik_ausschalten.TabIndex = 242;
            this.lbl_musik_ausschalten.Text = "Musik ausschalten";
            this.lbl_musik_ausschalten.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_musik_ausschalten
            // 
            this.btn_musik_ausschalten.BackColor = System.Drawing.Color.Transparent;
            this.btn_musik_ausschalten.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_musik_ausschalten.BackgroundImage")));
            this.btn_musik_ausschalten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_musik_ausschalten.Checkbox = true;
            this.btn_musik_ausschalten.Checked = false;
            this.btn_musik_ausschalten.FlatAppearance.BorderSize = 0;
            this.btn_musik_ausschalten.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_musik_ausschalten.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_musik_ausschalten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_musik_ausschalten.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_musik_ausschalten.ForeColor = System.Drawing.Color.Black;
            this.btn_musik_ausschalten.Location = new System.Drawing.Point(50, 112);
            this.btn_musik_ausschalten.Margin = new System.Windows.Forms.Padding(0);
            this.btn_musik_ausschalten.Name = "btn_musik_ausschalten";
            this.btn_musik_ausschalten.Size = new System.Drawing.Size(20, 20);
            this.btn_musik_ausschalten.TabIndex = 243;
            this.btn_musik_ausschalten.Tag = false;
            this.btn_musik_ausschalten.UseVisualStyleBackColor = false;
            this.btn_musik_ausschalten.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_tipps_anzeigen
            // 
            this.btn_tipps_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.btn_tipps_anzeigen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_tipps_anzeigen.BackgroundImage")));
            this.btn_tipps_anzeigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_tipps_anzeigen.Checkbox = true;
            this.btn_tipps_anzeigen.Checked = false;
            this.btn_tipps_anzeigen.FlatAppearance.BorderSize = 0;
            this.btn_tipps_anzeigen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_tipps_anzeigen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_tipps_anzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tipps_anzeigen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tipps_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.btn_tipps_anzeigen.Location = new System.Drawing.Point(50, 152);
            this.btn_tipps_anzeigen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_tipps_anzeigen.Name = "btn_tipps_anzeigen";
            this.btn_tipps_anzeigen.Size = new System.Drawing.Size(20, 20);
            this.btn_tipps_anzeigen.TabIndex = 245;
            this.btn_tipps_anzeigen.Tag = false;
            this.btn_tipps_anzeigen.UseVisualStyleBackColor = false;
            this.btn_tipps_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_tipps_anzeigen
            // 
            this.lbl_tipps_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_tipps_anzeigen.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tipps_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.lbl_tipps_anzeigen.Location = new System.Drawing.Point(83, 148);
            this.lbl_tipps_anzeigen.Name = "lbl_tipps_anzeigen";
            this.lbl_tipps_anzeigen.Size = new System.Drawing.Size(354, 29);
            this.lbl_tipps_anzeigen.TabIndex = 244;
            this.lbl_tipps_anzeigen.Text = "Tipps anzeigen";
            this.lbl_tipps_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_statistik_anzeigen
            // 
            this.btn_statistik_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.btn_statistik_anzeigen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_statistik_anzeigen.BackgroundImage")));
            this.btn_statistik_anzeigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_statistik_anzeigen.Checkbox = true;
            this.btn_statistik_anzeigen.Checked = false;
            this.btn_statistik_anzeigen.FlatAppearance.BorderSize = 0;
            this.btn_statistik_anzeigen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_statistik_anzeigen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_statistik_anzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_statistik_anzeigen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_statistik_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.btn_statistik_anzeigen.Location = new System.Drawing.Point(50, 193);
            this.btn_statistik_anzeigen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_statistik_anzeigen.Name = "btn_statistik_anzeigen";
            this.btn_statistik_anzeigen.Size = new System.Drawing.Size(20, 20);
            this.btn_statistik_anzeigen.TabIndex = 247;
            this.btn_statistik_anzeigen.Tag = false;
            this.btn_statistik_anzeigen.UseVisualStyleBackColor = false;
            this.btn_statistik_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_statistik_anzeigen
            // 
            this.lbl_statistik_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_statistik_anzeigen.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_statistik_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.lbl_statistik_anzeigen.Location = new System.Drawing.Point(83, 189);
            this.lbl_statistik_anzeigen.Name = "lbl_statistik_anzeigen";
            this.lbl_statistik_anzeigen.Size = new System.Drawing.Size(354, 29);
            this.lbl_statistik_anzeigen.TabIndex = 246;
            this.lbl_statistik_anzeigen.Text = "Statistik bei Spielende anzeigen";
            this.lbl_statistik_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_effekt_lautstaerke
            // 
            this.lbl_effekt_lautstaerke.BackColor = System.Drawing.Color.Transparent;
            this.lbl_effekt_lautstaerke.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_effekt_lautstaerke.ForeColor = System.Drawing.Color.Black;
            this.lbl_effekt_lautstaerke.Location = new System.Drawing.Point(83, 319);
            this.lbl_effekt_lautstaerke.Name = "lbl_effekt_lautstaerke";
            this.lbl_effekt_lautstaerke.Size = new System.Drawing.Size(310, 29);
            this.lbl_effekt_lautstaerke.TabIndex = 250;
            this.lbl_effekt_lautstaerke.Text = "Effekt Lautstärke - 100 %";
            // 
            // trb_effekt_lautstaerke
            // 
            this.trb_effekt_lautstaerke.Location = new System.Drawing.Point(88, 352);
            this.trb_effekt_lautstaerke.Maximum = 100;
            this.trb_effekt_lautstaerke.Name = "trb_effekt_lautstaerke";
            this.trb_effekt_lautstaerke.Size = new System.Drawing.Size(289, 45);
            this.trb_effekt_lautstaerke.TabIndex = 249;
            this.trb_effekt_lautstaerke.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trb_effekt_lautstaerke.Value = 100;
            this.trb_effekt_lautstaerke.Scroll += new System.EventHandler(this.trb_effekt_lautstaerke_Scroll);
            // 
            // frmEinstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 431);
            this.Controls.Add(this.lbl_effekt_lautstaerke);
            this.Controls.Add(this.trb_effekt_lautstaerke);
            this.Controls.Add(this.btn_statistik_anzeigen);
            this.Controls.Add(this.lbl_statistik_anzeigen);
            this.Controls.Add(this.btn_tipps_anzeigen);
            this.Controls.Add(this.lbl_tipps_anzeigen);
            this.Controls.Add(this.btn_musik_ausschalten);
            this.Controls.Add(this.lbl_musik_ausschalten);
            this.Controls.Add(this.lbl_musik_lautstaerke);
            this.Controls.Add(this.trb_musik_lautstaerke);
            this.Controls.Add(this.lbl_ueberschrift);
            this.Name = "frmEinstellungen";
            this.Text = "frmEinstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEinstellungen_FormClosing);
            this.Load += new System.EventHandler(this.frmEinstellungen_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trb_musik_lautstaerke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_effekt_lautstaerke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ueberschrift;
        private System.Windows.Forms.TrackBar trb_musik_lautstaerke;
        private System.Windows.Forms.Label lbl_musik_lautstaerke;
        private System.Windows.Forms.Label lbl_musik_ausschalten;
        private Conspiratio.Controls.CrystalButton btn_musik_ausschalten;
        private Conspiratio.Controls.CrystalButton btn_tipps_anzeigen;
        private System.Windows.Forms.Label lbl_tipps_anzeigen;
        private Conspiratio.Controls.CrystalButton btn_statistik_anzeigen;
        private System.Windows.Forms.Label lbl_statistik_anzeigen;
        private System.Windows.Forms.Label lbl_effekt_lautstaerke;
        private System.Windows.Forms.TrackBar trb_effekt_lautstaerke;
    }
}