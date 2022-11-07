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
            this.lbl_musik_lautstaerke = new System.Windows.Forms.Label();
            this.lbl_musik_ausschalten = new System.Windows.Forms.Label();
            this.btn_musik_ausschalten = new Conspiratio.Controls.CrystalButton();
            this.btn_tipps_anzeigen = new Conspiratio.Controls.CrystalButton();
            this.lbl_tipps_anzeigen = new System.Windows.Forms.Label();
            this.btn_statistik_anzeigen = new Conspiratio.Controls.CrystalButton();
            this.lbl_statistik_anzeigen = new System.Windows.Forms.Label();
            this.lbl_effekt_lautstaerke = new System.Windows.Forms.Label();
            this.btn_aggressivitaet_niedrig = new Conspiratio.Controls.CrystalButton();
            this.lbl_aggressivitaet_ki_spieler = new System.Windows.Forms.Label();
            this.lbl_aggressivitaet_niedrig = new System.Windows.Forms.Label();
            this.lbl_aggressivitaet_mittel = new System.Windows.Forms.Label();
            this.btn_aggressivitaet_mittel = new Conspiratio.Controls.CrystalButton();
            this.lbl_aggressivitaet_hoch = new System.Windows.Forms.Label();
            this.btn_aggressivitaet_hoch = new Conspiratio.Controls.CrystalButton();
            this.lbl_stimmen_lautstaerke = new System.Windows.Forms.Label();
            this.btn_stuetzpunktereignisse_ki_anzeigen = new Conspiratio.Controls.CrystalButton();
            this.lbl_stuetzpunktereignisse_ki_anzeigen = new System.Windows.Forms.Label();
            this.btn_militaerereignisse_ki_anzeigen = new Conspiratio.Controls.CrystalButton();
            this.lbl_militaerereignisse_ki_anzeigen = new System.Windows.Forms.Label();
            this.scr_stimmen_lautstaerke = new System.Windows.Forms.HScrollBar();
            this.scr_effekt_lautstaerke = new System.Windows.Forms.HScrollBar();
            this.scr_musik_lautstaerke = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // lbl_ueberschrift
            // 
            this.lbl_ueberschrift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ueberschrift.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ueberschrift.Font = new System.Drawing.Font("Arial", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ueberschrift.ForeColor = System.Drawing.Color.Black;
            this.lbl_ueberschrift.Location = new System.Drawing.Point(0, 36);
            this.lbl_ueberschrift.Name = "lbl_ueberschrift";
            this.lbl_ueberschrift.Size = new System.Drawing.Size(857, 40);
            this.lbl_ueberschrift.TabIndex = 238;
            this.lbl_ueberschrift.Text = "Optionen";
            this.lbl_ueberschrift.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_ueberschrift.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_musik_lautstaerke
            // 
            this.lbl_musik_lautstaerke.BackColor = System.Drawing.Color.Transparent;
            this.lbl_musik_lautstaerke.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_musik_lautstaerke.ForeColor = System.Drawing.Color.Black;
            this.lbl_musik_lautstaerke.Location = new System.Drawing.Point(478, 143);
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
            this.lbl_musik_ausschalten.Location = new System.Drawing.Point(478, 103);
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
            this.btn_musik_ausschalten.Location = new System.Drawing.Point(445, 107);
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
            this.btn_tipps_anzeigen.Location = new System.Drawing.Point(50, 112);
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
            this.lbl_tipps_anzeigen.Location = new System.Drawing.Point(83, 108);
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
            this.btn_statistik_anzeigen.Location = new System.Drawing.Point(50, 153);
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
            this.lbl_statistik_anzeigen.Location = new System.Drawing.Point(83, 149);
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
            this.lbl_effekt_lautstaerke.Location = new System.Drawing.Point(478, 232);
            this.lbl_effekt_lautstaerke.Name = "lbl_effekt_lautstaerke";
            this.lbl_effekt_lautstaerke.Size = new System.Drawing.Size(310, 29);
            this.lbl_effekt_lautstaerke.TabIndex = 250;
            this.lbl_effekt_lautstaerke.Text = "Effekt Lautstärke - 100 %";
            this.lbl_effekt_lautstaerke.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_aggressivitaet_niedrig
            // 
            this.btn_aggressivitaet_niedrig.BackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_niedrig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_aggressivitaet_niedrig.BackgroundImage")));
            this.btn_aggressivitaet_niedrig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_aggressivitaet_niedrig.Checkbox = true;
            this.btn_aggressivitaet_niedrig.Checked = false;
            this.btn_aggressivitaet_niedrig.FlatAppearance.BorderSize = 0;
            this.btn_aggressivitaet_niedrig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_niedrig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_niedrig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aggressivitaet_niedrig.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aggressivitaet_niedrig.ForeColor = System.Drawing.Color.Black;
            this.btn_aggressivitaet_niedrig.Location = new System.Drawing.Point(50, 369);
            this.btn_aggressivitaet_niedrig.Margin = new System.Windows.Forms.Padding(0);
            this.btn_aggressivitaet_niedrig.Name = "btn_aggressivitaet_niedrig";
            this.btn_aggressivitaet_niedrig.Size = new System.Drawing.Size(20, 20);
            this.btn_aggressivitaet_niedrig.TabIndex = 251;
            this.btn_aggressivitaet_niedrig.Tag = false;
            this.btn_aggressivitaet_niedrig.UseVisualStyleBackColor = false;
            this.btn_aggressivitaet_niedrig.Click += new System.EventHandler(this.btn_aggressivitaet_niedrig_Click);
            this.btn_aggressivitaet_niedrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_aggressivitaet_ki_spieler
            // 
            this.lbl_aggressivitaet_ki_spieler.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aggressivitaet_ki_spieler.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aggressivitaet_ki_spieler.ForeColor = System.Drawing.Color.Black;
            this.lbl_aggressivitaet_ki_spieler.Location = new System.Drawing.Point(83, 332);
            this.lbl_aggressivitaet_ki_spieler.Name = "lbl_aggressivitaet_ki_spieler";
            this.lbl_aggressivitaet_ki_spieler.Size = new System.Drawing.Size(354, 29);
            this.lbl_aggressivitaet_ki_spieler.TabIndex = 252;
            this.lbl_aggressivitaet_ki_spieler.Text = "Aggressivität der KI-Spieler";
            this.lbl_aggressivitaet_ki_spieler.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_aggressivitaet_niedrig
            // 
            this.lbl_aggressivitaet_niedrig.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aggressivitaet_niedrig.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aggressivitaet_niedrig.ForeColor = System.Drawing.Color.Black;
            this.lbl_aggressivitaet_niedrig.Location = new System.Drawing.Point(83, 367);
            this.lbl_aggressivitaet_niedrig.Name = "lbl_aggressivitaet_niedrig";
            this.lbl_aggressivitaet_niedrig.Size = new System.Drawing.Size(96, 29);
            this.lbl_aggressivitaet_niedrig.TabIndex = 253;
            this.lbl_aggressivitaet_niedrig.Text = "Niedrig";
            this.lbl_aggressivitaet_niedrig.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_aggressivitaet_mittel
            // 
            this.lbl_aggressivitaet_mittel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aggressivitaet_mittel.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aggressivitaet_mittel.ForeColor = System.Drawing.Color.Black;
            this.lbl_aggressivitaet_mittel.Location = new System.Drawing.Point(235, 367);
            this.lbl_aggressivitaet_mittel.Name = "lbl_aggressivitaet_mittel";
            this.lbl_aggressivitaet_mittel.Size = new System.Drawing.Size(92, 29);
            this.lbl_aggressivitaet_mittel.TabIndex = 255;
            this.lbl_aggressivitaet_mittel.Text = "Mittel";
            this.lbl_aggressivitaet_mittel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_aggressivitaet_mittel
            // 
            this.btn_aggressivitaet_mittel.BackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_mittel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_aggressivitaet_mittel.BackgroundImage")));
            this.btn_aggressivitaet_mittel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_aggressivitaet_mittel.Checkbox = true;
            this.btn_aggressivitaet_mittel.Checked = false;
            this.btn_aggressivitaet_mittel.FlatAppearance.BorderSize = 0;
            this.btn_aggressivitaet_mittel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_mittel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_mittel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aggressivitaet_mittel.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aggressivitaet_mittel.ForeColor = System.Drawing.Color.Black;
            this.btn_aggressivitaet_mittel.Location = new System.Drawing.Point(202, 369);
            this.btn_aggressivitaet_mittel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_aggressivitaet_mittel.Name = "btn_aggressivitaet_mittel";
            this.btn_aggressivitaet_mittel.Size = new System.Drawing.Size(20, 20);
            this.btn_aggressivitaet_mittel.TabIndex = 254;
            this.btn_aggressivitaet_mittel.Tag = false;
            this.btn_aggressivitaet_mittel.UseVisualStyleBackColor = false;
            this.btn_aggressivitaet_mittel.Click += new System.EventHandler(this.btn_aggressivitaet_mittel_Click);
            this.btn_aggressivitaet_mittel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_aggressivitaet_hoch
            // 
            this.lbl_aggressivitaet_hoch.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aggressivitaet_hoch.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aggressivitaet_hoch.ForeColor = System.Drawing.Color.Black;
            this.lbl_aggressivitaet_hoch.Location = new System.Drawing.Point(363, 369);
            this.lbl_aggressivitaet_hoch.Name = "lbl_aggressivitaet_hoch";
            this.lbl_aggressivitaet_hoch.Size = new System.Drawing.Size(96, 29);
            this.lbl_aggressivitaet_hoch.TabIndex = 257;
            this.lbl_aggressivitaet_hoch.Text = "Hoch";
            this.lbl_aggressivitaet_hoch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_aggressivitaet_hoch
            // 
            this.btn_aggressivitaet_hoch.BackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_hoch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_aggressivitaet_hoch.BackgroundImage")));
            this.btn_aggressivitaet_hoch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_aggressivitaet_hoch.Checkbox = true;
            this.btn_aggressivitaet_hoch.Checked = false;
            this.btn_aggressivitaet_hoch.FlatAppearance.BorderSize = 0;
            this.btn_aggressivitaet_hoch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_hoch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_aggressivitaet_hoch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_aggressivitaet_hoch.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_aggressivitaet_hoch.ForeColor = System.Drawing.Color.Black;
            this.btn_aggressivitaet_hoch.Location = new System.Drawing.Point(330, 371);
            this.btn_aggressivitaet_hoch.Margin = new System.Windows.Forms.Padding(0);
            this.btn_aggressivitaet_hoch.Name = "btn_aggressivitaet_hoch";
            this.btn_aggressivitaet_hoch.Size = new System.Drawing.Size(20, 20);
            this.btn_aggressivitaet_hoch.TabIndex = 256;
            this.btn_aggressivitaet_hoch.Tag = false;
            this.btn_aggressivitaet_hoch.UseVisualStyleBackColor = false;
            this.btn_aggressivitaet_hoch.Click += new System.EventHandler(this.btn_aggressivitaet_hoch_Click);
            this.btn_aggressivitaet_hoch.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_stimmen_lautstaerke
            // 
            this.lbl_stimmen_lautstaerke.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stimmen_lautstaerke.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stimmen_lautstaerke.ForeColor = System.Drawing.Color.Black;
            this.lbl_stimmen_lautstaerke.Location = new System.Drawing.Point(478, 323);
            this.lbl_stimmen_lautstaerke.Name = "lbl_stimmen_lautstaerke";
            this.lbl_stimmen_lautstaerke.Size = new System.Drawing.Size(331, 29);
            this.lbl_stimmen_lautstaerke.TabIndex = 259;
            this.lbl_stimmen_lautstaerke.Text = "Stimmen Lautstärke - 100 %";
            this.lbl_stimmen_lautstaerke.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_stuetzpunktereignisse_ki_anzeigen
            // 
            this.btn_stuetzpunktereignisse_ki_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.btn_stuetzpunktereignisse_ki_anzeigen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_stuetzpunktereignisse_ki_anzeigen.BackgroundImage")));
            this.btn_stuetzpunktereignisse_ki_anzeigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_stuetzpunktereignisse_ki_anzeigen.Checkbox = true;
            this.btn_stuetzpunktereignisse_ki_anzeigen.Checked = false;
            this.btn_stuetzpunktereignisse_ki_anzeigen.FlatAppearance.BorderSize = 0;
            this.btn_stuetzpunktereignisse_ki_anzeigen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_stuetzpunktereignisse_ki_anzeigen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_stuetzpunktereignisse_ki_anzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_stuetzpunktereignisse_ki_anzeigen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stuetzpunktereignisse_ki_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.btn_stuetzpunktereignisse_ki_anzeigen.Location = new System.Drawing.Point(50, 195);
            this.btn_stuetzpunktereignisse_ki_anzeigen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_stuetzpunktereignisse_ki_anzeigen.Name = "btn_stuetzpunktereignisse_ki_anzeigen";
            this.btn_stuetzpunktereignisse_ki_anzeigen.Size = new System.Drawing.Size(20, 20);
            this.btn_stuetzpunktereignisse_ki_anzeigen.TabIndex = 261;
            this.btn_stuetzpunktereignisse_ki_anzeigen.Tag = false;
            this.btn_stuetzpunktereignisse_ki_anzeigen.UseVisualStyleBackColor = false;
            this.btn_stuetzpunktereignisse_ki_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_stuetzpunktereignisse_ki_anzeigen
            // 
            this.lbl_stuetzpunktereignisse_ki_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_stuetzpunktereignisse_ki_anzeigen.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_stuetzpunktereignisse_ki_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.lbl_stuetzpunktereignisse_ki_anzeigen.Location = new System.Drawing.Point(83, 191);
            this.lbl_stuetzpunktereignisse_ki_anzeigen.Name = "lbl_stuetzpunktereignisse_ki_anzeigen";
            this.lbl_stuetzpunktereignisse_ki_anzeigen.Size = new System.Drawing.Size(354, 60);
            this.lbl_stuetzpunktereignisse_ki_anzeigen.TabIndex = 260;
            this.lbl_stuetzpunktereignisse_ki_anzeigen.Text = "Stützpunktereignisse von KI-Spielern anzeigen";
            this.lbl_stuetzpunktereignisse_ki_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // btn_militaerereignisse_ki_anzeigen
            // 
            this.btn_militaerereignisse_ki_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.btn_militaerereignisse_ki_anzeigen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_militaerereignisse_ki_anzeigen.BackgroundImage")));
            this.btn_militaerereignisse_ki_anzeigen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_militaerereignisse_ki_anzeigen.Checkbox = true;
            this.btn_militaerereignisse_ki_anzeigen.Checked = false;
            this.btn_militaerereignisse_ki_anzeigen.FlatAppearance.BorderSize = 0;
            this.btn_militaerereignisse_ki_anzeigen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_militaerereignisse_ki_anzeigen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_militaerereignisse_ki_anzeigen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_militaerereignisse_ki_anzeigen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_militaerereignisse_ki_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.btn_militaerereignisse_ki_anzeigen.Location = new System.Drawing.Point(50, 267);
            this.btn_militaerereignisse_ki_anzeigen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_militaerereignisse_ki_anzeigen.Name = "btn_militaerereignisse_ki_anzeigen";
            this.btn_militaerereignisse_ki_anzeigen.Size = new System.Drawing.Size(20, 20);
            this.btn_militaerereignisse_ki_anzeigen.TabIndex = 263;
            this.btn_militaerereignisse_ki_anzeigen.Tag = false;
            this.btn_militaerereignisse_ki_anzeigen.UseVisualStyleBackColor = false;
            this.btn_militaerereignisse_ki_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // lbl_militaerereignisse_ki_anzeigen
            // 
            this.lbl_militaerereignisse_ki_anzeigen.BackColor = System.Drawing.Color.Transparent;
            this.lbl_militaerereignisse_ki_anzeigen.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_militaerereignisse_ki_anzeigen.ForeColor = System.Drawing.Color.Black;
            this.lbl_militaerereignisse_ki_anzeigen.Location = new System.Drawing.Point(83, 263);
            this.lbl_militaerereignisse_ki_anzeigen.Name = "lbl_militaerereignisse_ki_anzeigen";
            this.lbl_militaerereignisse_ki_anzeigen.Size = new System.Drawing.Size(354, 60);
            this.lbl_militaerereignisse_ki_anzeigen.TabIndex = 262;
            this.lbl_militaerereignisse_ki_anzeigen.Text = "Militärereignisse (Überfälle) von KI-Spieler anzeigen";
            this.lbl_militaerereignisse_ki_anzeigen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            // 
            // scr_stimmen_lautstaerke
            // 
            this.scr_stimmen_lautstaerke.Location = new System.Drawing.Point(483, 352);
            this.scr_stimmen_lautstaerke.Maximum = 109;
            this.scr_stimmen_lautstaerke.Name = "scr_stimmen_lautstaerke";
            this.scr_stimmen_lautstaerke.Size = new System.Drawing.Size(289, 20);
            this.scr_stimmen_lautstaerke.TabIndex = 264;
            this.scr_stimmen_lautstaerke.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scr_stimmen_lautstaerke_Scroll);
            // 
            // scr_effekt_lautstaerke
            // 
            this.scr_effekt_lautstaerke.Location = new System.Drawing.Point(483, 261);
            this.scr_effekt_lautstaerke.Maximum = 109;
            this.scr_effekt_lautstaerke.Name = "scr_effekt_lautstaerke";
            this.scr_effekt_lautstaerke.Size = new System.Drawing.Size(289, 20);
            this.scr_effekt_lautstaerke.TabIndex = 265;
            this.scr_effekt_lautstaerke.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scr_effekt_lautstaerke_Scroll);
            // 
            // scr_musik_lautstaerke
            // 
            this.scr_musik_lautstaerke.Location = new System.Drawing.Point(483, 172);
            this.scr_musik_lautstaerke.Maximum = 109;
            this.scr_musik_lautstaerke.Name = "scr_musik_lautstaerke";
            this.scr_musik_lautstaerke.Size = new System.Drawing.Size(289, 20);
            this.scr_musik_lautstaerke.TabIndex = 266;
            this.scr_musik_lautstaerke.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scr_musik_lautstaerke_Scroll);
            // 
            // frmEinstellungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 431);
            this.Controls.Add(this.scr_musik_lautstaerke);
            this.Controls.Add(this.scr_effekt_lautstaerke);
            this.Controls.Add(this.scr_stimmen_lautstaerke);
            this.Controls.Add(this.btn_militaerereignisse_ki_anzeigen);
            this.Controls.Add(this.lbl_militaerereignisse_ki_anzeigen);
            this.Controls.Add(this.btn_stuetzpunktereignisse_ki_anzeigen);
            this.Controls.Add(this.lbl_stuetzpunktereignisse_ki_anzeigen);
            this.Controls.Add(this.lbl_stimmen_lautstaerke);
            this.Controls.Add(this.lbl_aggressivitaet_hoch);
            this.Controls.Add(this.btn_aggressivitaet_hoch);
            this.Controls.Add(this.lbl_aggressivitaet_mittel);
            this.Controls.Add(this.btn_aggressivitaet_mittel);
            this.Controls.Add(this.lbl_aggressivitaet_niedrig);
            this.Controls.Add(this.lbl_aggressivitaet_ki_spieler);
            this.Controls.Add(this.btn_aggressivitaet_niedrig);
            this.Controls.Add(this.lbl_effekt_lautstaerke);
            this.Controls.Add(this.btn_statistik_anzeigen);
            this.Controls.Add(this.lbl_statistik_anzeigen);
            this.Controls.Add(this.btn_tipps_anzeigen);
            this.Controls.Add(this.lbl_tipps_anzeigen);
            this.Controls.Add(this.btn_musik_ausschalten);
            this.Controls.Add(this.lbl_musik_ausschalten);
            this.Controls.Add(this.lbl_musik_lautstaerke);
            this.Controls.Add(this.lbl_ueberschrift);
            this.Name = "frmEinstellungen";
            this.Text = "frmEinstellungen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEinstellungen_FormClosing);
            this.Load += new System.EventHandler(this.frmEinstellungen_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmEinstellungen_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ueberschrift;
        private System.Windows.Forms.Label lbl_musik_lautstaerke;
        private System.Windows.Forms.Label lbl_musik_ausschalten;
        private Conspiratio.Controls.CrystalButton btn_musik_ausschalten;
        private Conspiratio.Controls.CrystalButton btn_tipps_anzeigen;
        private System.Windows.Forms.Label lbl_tipps_anzeigen;
        private Conspiratio.Controls.CrystalButton btn_statistik_anzeigen;
        private System.Windows.Forms.Label lbl_statistik_anzeigen;
        private System.Windows.Forms.Label lbl_effekt_lautstaerke;
        private Controls.CrystalButton btn_aggressivitaet_niedrig;
        private System.Windows.Forms.Label lbl_aggressivitaet_ki_spieler;
        private System.Windows.Forms.Label lbl_aggressivitaet_niedrig;
        private System.Windows.Forms.Label lbl_aggressivitaet_mittel;
        private Controls.CrystalButton btn_aggressivitaet_mittel;
        private System.Windows.Forms.Label lbl_aggressivitaet_hoch;
        private Controls.CrystalButton btn_aggressivitaet_hoch;
        private System.Windows.Forms.Label lbl_stimmen_lautstaerke;
        private Controls.CrystalButton btn_stuetzpunktereignisse_ki_anzeigen;
        private System.Windows.Forms.Label lbl_stuetzpunktereignisse_ki_anzeigen;
        private Controls.CrystalButton btn_militaerereignisse_ki_anzeigen;
        private System.Windows.Forms.Label lbl_militaerereignisse_ki_anzeigen;
        private System.Windows.Forms.HScrollBar scr_stimmen_lautstaerke;
        private System.Windows.Forms.HScrollBar scr_effekt_lautstaerke;
        private System.Windows.Forms.HScrollBar scr_musik_lautstaerke;
    }
}