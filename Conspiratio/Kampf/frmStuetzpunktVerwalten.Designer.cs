using Conspiratio.Controls;

namespace Conspiratio.Kampf
{
    partial class frmStuetzpunktVerwalten
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
            this.components = new System.ComponentModel.Container();
            this.btn_zoll = new FlatButton();
            this.btn_sicherheit_tarnung = new FlatButton();
            this.btn_manoever = new FlatButton();
            this.btn_reperatur = new FlatButton();
            this.btn_ausbau = new FlatButton();
            this.btn_einheit_1 = new FlatButton();
            this.btn_einheit_2 = new FlatButton();
            this.btn_einheit_3 = new FlatButton();
            this.btn_einheit_4 = new FlatButton();
            this.nb_einheit_1 = new Conspiratio.NumericButton();
            this.nb_einheit_2 = new Conspiratio.NumericButton();
            this.nb_einheit_3 = new Conspiratio.NumericButton();
            this.nb_einheit_4 = new Conspiratio.NumericButton();
            this.ttButtons = new System.Windows.Forms.ToolTip(this.components);
            this.lbl_aktionsart_1 = new System.Windows.Forms.Label();
            this.lbl_aktionsart_2 = new System.Windows.Forms.Label();
            this.lbl_aktion_1_text_1 = new System.Windows.Forms.Label();
            this.lbl_aktion_1_text_2 = new System.Windows.Forms.Label();
            this.lbl_aktion_1_text_3 = new System.Windows.Forms.Label();
            this.nb_aktion_1_zielland = new Conspiratio.NumericButton();
            this.nb_aktion_1_zielstuetzpunkt = new Conspiratio.NumericButton();
            this.nb_aktion_1_einheit_1 = new Conspiratio.NumericButton();
            this.nb_aktion_1_einheit_2 = new Conspiratio.NumericButton();
            this.lbl_aktion_1_plus_1 = new System.Windows.Forms.Label();
            this.lbl_aktion_1_plus_2 = new System.Windows.Forms.Label();
            this.nb_aktion_1_einheit_3 = new Conspiratio.NumericButton();
            this.lbl_aktion_1_plus_3 = new System.Windows.Forms.Label();
            this.nb_aktion_1_einheit_4 = new Conspiratio.NumericButton();
            this.lbl_aktion_2_plus_3 = new System.Windows.Forms.Label();
            this.nb_aktion_2_einheit_4 = new Conspiratio.NumericButton();
            this.lbl_aktion_2_plus_2 = new System.Windows.Forms.Label();
            this.nb_aktion_2_einheit_3 = new Conspiratio.NumericButton();
            this.lbl_aktion_2_plus_1 = new System.Windows.Forms.Label();
            this.nb_aktion_2_einheit_2 = new Conspiratio.NumericButton();
            this.nb_aktion_2_einheit_1 = new Conspiratio.NumericButton();
            this.nb_aktion_2_zielstuetzpunkt = new Conspiratio.NumericButton();
            this.nb_aktion_2_zielland = new Conspiratio.NumericButton();
            this.lbl_aktion_2_text_3 = new System.Windows.Forms.Label();
            this.lbl_aktion_2_text_2 = new System.Windows.Forms.Label();
            this.lbl_aktion_2_text_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_zoll
            // 
            this.btn_zoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_zoll.BackColor = System.Drawing.Color.Transparent;
            this.btn_zoll.BackgroundImage = global::Conspiratio.Properties.Resources.SymbJustiz;
            this.btn_zoll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_zoll.FlatAppearance.BorderSize = 0;
            this.btn_zoll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_zoll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_zoll.ForeColor = System.Drawing.Color.Transparent;
            this.btn_zoll.Location = new System.Drawing.Point(898, 592);
            this.btn_zoll.Margin = new System.Windows.Forms.Padding(0);
            this.btn_zoll.Name = "btn_zoll";
            this.btn_zoll.Size = new System.Drawing.Size(100, 100);
            this.btn_zoll.TabIndex = 78;
            this.ttButtons.SetToolTip(this.btn_zoll, "Zollsatz festlegen");
            this.btn_zoll.UseVisualStyleBackColor = false;
            this.btn_zoll.Visible = false;
            this.btn_zoll.Click += new System.EventHandler(this.btn_zoll_Click);
            this.btn_zoll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_sicherheit_tarnung
            // 
            this.btn_sicherheit_tarnung.BackColor = System.Drawing.Color.Transparent;
            this.btn_sicherheit_tarnung.BackgroundImage = global::Conspiratio.Properties.Resources.SymbDoor;
            this.btn_sicherheit_tarnung.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_sicherheit_tarnung.FlatAppearance.BorderSize = 0;
            this.btn_sicherheit_tarnung.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_sicherheit_tarnung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sicherheit_tarnung.ForeColor = System.Drawing.Color.Transparent;
            this.btn_sicherheit_tarnung.Location = new System.Drawing.Point(51, 414);
            this.btn_sicherheit_tarnung.Margin = new System.Windows.Forms.Padding(0);
            this.btn_sicherheit_tarnung.Name = "btn_sicherheit_tarnung";
            this.btn_sicherheit_tarnung.Size = new System.Drawing.Size(100, 100);
            this.btn_sicherheit_tarnung.TabIndex = 79;
            this.ttButtons.SetToolTip(this.btn_sicherheit_tarnung, "Sicherheit");
            this.btn_sicherheit_tarnung.UseVisualStyleBackColor = false;
            this.btn_sicherheit_tarnung.Click += new System.EventHandler(this.btn_sicherheit_tarnung_Click);
            this.btn_sicherheit_tarnung.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_manoever
            // 
            this.btn_manoever.BackColor = System.Drawing.Color.Transparent;
            this.btn_manoever.BackgroundImage = global::Conspiratio.Properties.Resources.Roh17;
            this.btn_manoever.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_manoever.FlatAppearance.BorderSize = 0;
            this.btn_manoever.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_manoever.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_manoever.ForeColor = System.Drawing.Color.Transparent;
            this.btn_manoever.Location = new System.Drawing.Point(342, 414);
            this.btn_manoever.Margin = new System.Windows.Forms.Padding(0);
            this.btn_manoever.Name = "btn_manoever";
            this.btn_manoever.Size = new System.Drawing.Size(100, 100);
            this.btn_manoever.TabIndex = 80;
            this.ttButtons.SetToolTip(this.btn_manoever, "Manöver durchführen");
            this.btn_manoever.UseVisualStyleBackColor = false;
            this.btn_manoever.Click += new System.EventHandler(this.btn_manoever_Click);
            this.btn_manoever.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_reperatur
            // 
            this.btn_reperatur.BackColor = System.Drawing.Color.Transparent;
            this.btn_reperatur.BackgroundImage = global::Conspiratio.Properties.Resources.SymbAnwImBau;
            this.btn_reperatur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_reperatur.FlatAppearance.BorderSize = 0;
            this.btn_reperatur.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_reperatur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reperatur.ForeColor = System.Drawing.Color.Transparent;
            this.btn_reperatur.Location = new System.Drawing.Point(898, 414);
            this.btn_reperatur.Margin = new System.Windows.Forms.Padding(0);
            this.btn_reperatur.Name = "btn_reperatur";
            this.btn_reperatur.Size = new System.Drawing.Size(100, 100);
            this.btn_reperatur.TabIndex = 81;
            this.ttButtons.SetToolTip(this.btn_reperatur, "Reparatur");
            this.btn_reperatur.UseVisualStyleBackColor = false;
            this.btn_reperatur.Click += new System.EventHandler(this.btn_reperatur_Click);
            this.btn_reperatur.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_ausbau
            // 
            this.btn_ausbau.BackColor = System.Drawing.Color.Transparent;
            this.btn_ausbau.BackgroundImage = global::Conspiratio.Properties.Resources.SymbAnwHaus1;
            this.btn_ausbau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ausbau.FlatAppearance.BorderSize = 0;
            this.btn_ausbau.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_ausbau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ausbau.ForeColor = System.Drawing.Color.Transparent;
            this.btn_ausbau.Location = new System.Drawing.Point(618, 414);
            this.btn_ausbau.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ausbau.Name = "btn_ausbau";
            this.btn_ausbau.Size = new System.Drawing.Size(100, 100);
            this.btn_ausbau.TabIndex = 82;
            this.ttButtons.SetToolTip(this.btn_ausbau, "Unterkünfte ausbauen");
            this.btn_ausbau.UseVisualStyleBackColor = false;
            this.btn_ausbau.Click += new System.EventHandler(this.btn_ausbau_Click);
            this.btn_ausbau.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_einheit_1
            // 
            this.btn_einheit_1.BackColor = System.Drawing.Color.Transparent;
            this.btn_einheit_1.BackgroundImage = global::Conspiratio.Properties.Resources.SymbSoeldner;
            this.btn_einheit_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_einheit_1.FlatAppearance.BorderSize = 0;
            this.btn_einheit_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_einheit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_einheit_1.ForeColor = System.Drawing.Color.Transparent;
            this.btn_einheit_1.Location = new System.Drawing.Point(51, 136);
            this.btn_einheit_1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_einheit_1.Name = "btn_einheit_1";
            this.btn_einheit_1.Size = new System.Drawing.Size(100, 100);
            this.btn_einheit_1.TabIndex = 83;
            this.btn_einheit_1.UseVisualStyleBackColor = false;
            this.btn_einheit_1.Click += new System.EventHandler(this.btn_einheit_1_Click);
            this.btn_einheit_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_einheit_2
            // 
            this.btn_einheit_2.BackColor = System.Drawing.Color.Transparent;
            this.btn_einheit_2.BackgroundImage = global::Conspiratio.Properties.Resources.SymbSoeldner;
            this.btn_einheit_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_einheit_2.FlatAppearance.BorderSize = 0;
            this.btn_einheit_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_einheit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_einheit_2.ForeColor = System.Drawing.Color.Transparent;
            this.btn_einheit_2.Location = new System.Drawing.Point(342, 136);
            this.btn_einheit_2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_einheit_2.Name = "btn_einheit_2";
            this.btn_einheit_2.Size = new System.Drawing.Size(100, 100);
            this.btn_einheit_2.TabIndex = 84;
            this.btn_einheit_2.UseVisualStyleBackColor = false;
            this.btn_einheit_2.Click += new System.EventHandler(this.btn_einheit_2_Click);
            this.btn_einheit_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_einheit_3
            // 
            this.btn_einheit_3.BackColor = System.Drawing.Color.Transparent;
            this.btn_einheit_3.BackgroundImage = global::Conspiratio.Properties.Resources.SymbSoeldner;
            this.btn_einheit_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_einheit_3.FlatAppearance.BorderSize = 0;
            this.btn_einheit_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_einheit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_einheit_3.ForeColor = System.Drawing.Color.Transparent;
            this.btn_einheit_3.Location = new System.Drawing.Point(618, 136);
            this.btn_einheit_3.Margin = new System.Windows.Forms.Padding(0);
            this.btn_einheit_3.Name = "btn_einheit_3";
            this.btn_einheit_3.Size = new System.Drawing.Size(100, 100);
            this.btn_einheit_3.TabIndex = 85;
            this.btn_einheit_3.UseVisualStyleBackColor = false;
            this.btn_einheit_3.Click += new System.EventHandler(this.btn_einheit_3_Click);
            this.btn_einheit_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // btn_einheit_4
            // 
            this.btn_einheit_4.BackColor = System.Drawing.Color.Transparent;
            this.btn_einheit_4.BackgroundImage = global::Conspiratio.Properties.Resources.SymbSoeldner;
            this.btn_einheit_4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_einheit_4.FlatAppearance.BorderSize = 0;
            this.btn_einheit_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_einheit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_einheit_4.ForeColor = System.Drawing.Color.Transparent;
            this.btn_einheit_4.Location = new System.Drawing.Point(898, 136);
            this.btn_einheit_4.Margin = new System.Windows.Forms.Padding(0);
            this.btn_einheit_4.Name = "btn_einheit_4";
            this.btn_einheit_4.Size = new System.Drawing.Size(100, 100);
            this.btn_einheit_4.TabIndex = 86;
            this.btn_einheit_4.UseVisualStyleBackColor = false;
            this.btn_einheit_4.Click += new System.EventHandler(this.btn_einheit_4_Click);
            this.btn_einheit_4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_einheit_1
            // 
            this.nb_einheit_1.BackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_1.FlatAppearance.BorderSize = 0;
            this.nb_einheit_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_einheit_1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_einheit_1.ForeColor = System.Drawing.Color.Gold;
            this.nb_einheit_1.Location = new System.Drawing.Point(69, 239);
            this.nb_einheit_1.MaximalerWert = 100;
            this.nb_einheit_1.MaximaleStellen = 3;
            this.nb_einheit_1.MinimalerWert = 0;
            this.nb_einheit_1.Name = "nb_einheit_1";
            this.nb_einheit_1.NurEinserSchritte = false;
            this.nb_einheit_1.Size = new System.Drawing.Size(66, 62);
            this.nb_einheit_1.TabIndex = 87;
            this.nb_einheit_1.TausenderTrenner = true;
            this.nb_einheit_1.Text = "000";
            this.nb_einheit_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_einheit_1.UseVisualStyleBackColor = false;
            this.nb_einheit_1.Wert = 0;
            this.nb_einheit_1.WertAnzeigen = true;
            this.nb_einheit_1.Click += new System.EventHandler(this.nb_einheit_1_Click);
            this.nb_einheit_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_einheit_2
            // 
            this.nb_einheit_2.BackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_2.FlatAppearance.BorderSize = 0;
            this.nb_einheit_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_einheit_2.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_einheit_2.ForeColor = System.Drawing.Color.Gold;
            this.nb_einheit_2.Location = new System.Drawing.Point(361, 239);
            this.nb_einheit_2.MaximalerWert = 100;
            this.nb_einheit_2.MaximaleStellen = 3;
            this.nb_einheit_2.MinimalerWert = 0;
            this.nb_einheit_2.Name = "nb_einheit_2";
            this.nb_einheit_2.NurEinserSchritte = false;
            this.nb_einheit_2.Size = new System.Drawing.Size(66, 62);
            this.nb_einheit_2.TabIndex = 88;
            this.nb_einheit_2.TausenderTrenner = true;
            this.nb_einheit_2.Text = "000";
            this.nb_einheit_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_einheit_2.UseVisualStyleBackColor = false;
            this.nb_einheit_2.Wert = 0;
            this.nb_einheit_2.WertAnzeigen = true;
            this.nb_einheit_2.Click += new System.EventHandler(this.nb_einheit_2_Click);
            this.nb_einheit_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_einheit_3
            // 
            this.nb_einheit_3.BackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_3.FlatAppearance.BorderSize = 0;
            this.nb_einheit_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_einheit_3.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_einheit_3.ForeColor = System.Drawing.Color.Gold;
            this.nb_einheit_3.Location = new System.Drawing.Point(636, 239);
            this.nb_einheit_3.MaximalerWert = 100;
            this.nb_einheit_3.MaximaleStellen = 3;
            this.nb_einheit_3.MinimalerWert = 0;
            this.nb_einheit_3.Name = "nb_einheit_3";
            this.nb_einheit_3.NurEinserSchritte = false;
            this.nb_einheit_3.Size = new System.Drawing.Size(66, 62);
            this.nb_einheit_3.TabIndex = 89;
            this.nb_einheit_3.TausenderTrenner = true;
            this.nb_einheit_3.Text = "000";
            this.nb_einheit_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_einheit_3.UseVisualStyleBackColor = false;
            this.nb_einheit_3.Wert = 0;
            this.nb_einheit_3.WertAnzeigen = true;
            this.nb_einheit_3.Click += new System.EventHandler(this.nb_einheit_3_Click);
            this.nb_einheit_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_einheit_4
            // 
            this.nb_einheit_4.BackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_4.FlatAppearance.BorderSize = 0;
            this.nb_einheit_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_einheit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_einheit_4.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_einheit_4.ForeColor = System.Drawing.Color.Gold;
            this.nb_einheit_4.Location = new System.Drawing.Point(917, 239);
            this.nb_einheit_4.MaximalerWert = 100;
            this.nb_einheit_4.MaximaleStellen = 3;
            this.nb_einheit_4.MinimalerWert = 0;
            this.nb_einheit_4.Name = "nb_einheit_4";
            this.nb_einheit_4.NurEinserSchritte = false;
            this.nb_einheit_4.Size = new System.Drawing.Size(66, 62);
            this.nb_einheit_4.TabIndex = 90;
            this.nb_einheit_4.TausenderTrenner = true;
            this.nb_einheit_4.Text = "000";
            this.nb_einheit_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_einheit_4.UseVisualStyleBackColor = false;
            this.nb_einheit_4.Wert = 0;
            this.nb_einheit_4.WertAnzeigen = true;
            this.nb_einheit_4.Click += new System.EventHandler(this.nb_einheit_4_Click);
            this.nb_einheit_4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // ttButtons
            // 
            this.ttButtons.IsBalloon = true;
            // 
            // lbl_aktionsart_1
            // 
            this.lbl_aktionsart_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktionsart_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktionsart_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktionsart_1.Location = new System.Drawing.Point(64, 540);
            this.lbl_aktionsart_1.Name = "lbl_aktionsart_1";
            this.lbl_aktionsart_1.Size = new System.Drawing.Size(660, 48);
            this.lbl_aktionsart_1.TabIndex = 241;
            this.lbl_aktionsart_1.Tag = "0";
            this.lbl_aktionsart_1.Text = "Kein Auftrag";
            this.lbl_aktionsart_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktionsart_1.Click += new System.EventHandler(this.lbl_aktionsart_1_Click);
            this.lbl_aktionsart_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktionsart_2
            // 
            this.lbl_aktionsart_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktionsart_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktionsart_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktionsart_2.Location = new System.Drawing.Point(64, 619);
            this.lbl_aktionsart_2.Name = "lbl_aktionsart_2";
            this.lbl_aktionsart_2.Size = new System.Drawing.Size(660, 48);
            this.lbl_aktionsart_2.TabIndex = 242;
            this.lbl_aktionsart_2.Tag = "0";
            this.lbl_aktionsart_2.Text = "Kein Auftrag";
            this.lbl_aktionsart_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktionsart_2.Click += new System.EventHandler(this.lbl_aktionsart_2_Click);
            this.lbl_aktionsart_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktion_1_text_1
            // 
            this.lbl_aktion_1_text_1.AutoSize = true;
            this.lbl_aktion_1_text_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_1_text_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_1_text_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_1_text_1.Location = new System.Drawing.Point(64, 588);
            this.lbl_aktion_1_text_1.Name = "lbl_aktion_1_text_1";
            this.lbl_aktion_1_text_1.Size = new System.Drawing.Size(153, 32);
            this.lbl_aktion_1_text_1.TabIndex = 243;
            this.lbl_aktion_1_text_1.Tag = "0";
            this.lbl_aktion_1_text_1.Text = "Überwacht";
            this.lbl_aktion_1_text_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktion_1_text_1.Visible = false;
            // 
            // lbl_aktion_1_text_2
            // 
            this.lbl_aktion_1_text_2.AutoSize = true;
            this.lbl_aktion_1_text_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_1_text_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_1_text_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_1_text_2.Location = new System.Drawing.Point(367, 588);
            this.lbl_aktion_1_text_2.Name = "lbl_aktion_1_text_2";
            this.lbl_aktion_1_text_2.Size = new System.Drawing.Size(56, 32);
            this.lbl_aktion_1_text_2.TabIndex = 244;
            this.lbl_aktion_1_text_2.Tag = "0";
            this.lbl_aktion_1_text_2.Text = "mit";
            this.lbl_aktion_1_text_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktion_1_text_2.Visible = false;
            // 
            // lbl_aktion_1_text_3
            // 
            this.lbl_aktion_1_text_3.AutoSize = true;
            this.lbl_aktion_1_text_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_1_text_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_1_text_3.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_1_text_3.Location = new System.Drawing.Point(633, 588);
            this.lbl_aktion_1_text_3.Name = "lbl_aktion_1_text_3";
            this.lbl_aktion_1_text_3.Size = new System.Drawing.Size(121, 32);
            this.lbl_aktion_1_text_3.TabIndex = 245;
            this.lbl_aktion_1_text_3.Tag = "0";
            this.lbl_aktion_1_text_3.Text = "Truppen";
            this.lbl_aktion_1_text_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktion_1_text_3.Visible = false;
            // 
            // nb_aktion_1_zielland
            // 
            this.nb_aktion_1_zielland.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nb_aktion_1_zielland.AutoSize = true;
            this.nb_aktion_1_zielland.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nb_aktion_1_zielland.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_zielland.FlatAppearance.BorderSize = 0;
            this.nb_aktion_1_zielland.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_zielland.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_zielland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_1_zielland.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_1_zielland.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_1_zielland.Location = new System.Drawing.Point(210, 583);
            this.nb_aktion_1_zielland.MaximalerWert = 999999999;
            this.nb_aktion_1_zielland.MaximaleStellen = 9;
            this.nb_aktion_1_zielland.MinimalerWert = 0;
            this.nb_aktion_1_zielland.Name = "nb_aktion_1_zielland";
            this.nb_aktion_1_zielland.NurEinserSchritte = true;
            this.nb_aktion_1_zielland.Size = new System.Drawing.Size(40, 42);
            this.nb_aktion_1_zielland.TabIndex = 246;
            this.nb_aktion_1_zielland.TausenderTrenner = false;
            this.nb_aktion_1_zielland.Text = "0";
            this.nb_aktion_1_zielland.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_1_zielland.UseVisualStyleBackColor = false;
            this.nb_aktion_1_zielland.Visible = false;
            this.nb_aktion_1_zielland.Wert = 0;
            this.nb_aktion_1_zielland.WertAnzeigen = false;
            this.nb_aktion_1_zielland.Click += new System.EventHandler(this.nb_aktion_1_zielland_Click);
            // 
            // nb_aktion_1_zielstuetzpunkt
            // 
            this.nb_aktion_1_zielstuetzpunkt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nb_aktion_1_zielstuetzpunkt.AutoSize = true;
            this.nb_aktion_1_zielstuetzpunkt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nb_aktion_1_zielstuetzpunkt.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_zielstuetzpunkt.FlatAppearance.BorderSize = 0;
            this.nb_aktion_1_zielstuetzpunkt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_zielstuetzpunkt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_zielstuetzpunkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_1_zielstuetzpunkt.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_1_zielstuetzpunkt.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_1_zielstuetzpunkt.Location = new System.Drawing.Point(751, 583);
            this.nb_aktion_1_zielstuetzpunkt.MaximalerWert = 999999999;
            this.nb_aktion_1_zielstuetzpunkt.MaximaleStellen = 9;
            this.nb_aktion_1_zielstuetzpunkt.MinimalerWert = 0;
            this.nb_aktion_1_zielstuetzpunkt.Name = "nb_aktion_1_zielstuetzpunkt";
            this.nb_aktion_1_zielstuetzpunkt.NurEinserSchritte = true;
            this.nb_aktion_1_zielstuetzpunkt.Size = new System.Drawing.Size(40, 42);
            this.nb_aktion_1_zielstuetzpunkt.TabIndex = 247;
            this.nb_aktion_1_zielstuetzpunkt.TausenderTrenner = false;
            this.nb_aktion_1_zielstuetzpunkt.Text = "0";
            this.nb_aktion_1_zielstuetzpunkt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_1_zielstuetzpunkt.UseVisualStyleBackColor = false;
            this.nb_aktion_1_zielstuetzpunkt.Visible = false;
            this.nb_aktion_1_zielstuetzpunkt.Wert = 0;
            this.nb_aktion_1_zielstuetzpunkt.WertAnzeigen = false;
            this.nb_aktion_1_zielstuetzpunkt.Click += new System.EventHandler(this.nb_aktion_1_zielstuetzpunkt_Click);
            // 
            // nb_aktion_1_einheit_1
            // 
            this.nb_aktion_1_einheit_1.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_1.FlatAppearance.BorderSize = 0;
            this.nb_aktion_1_einheit_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_1_einheit_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_1_einheit_1.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_1_einheit_1.Location = new System.Drawing.Point(416, 585);
            this.nb_aktion_1_einheit_1.MaximalerWert = 99;
            this.nb_aktion_1_einheit_1.MaximaleStellen = 2;
            this.nb_aktion_1_einheit_1.MinimalerWert = 0;
            this.nb_aktion_1_einheit_1.Name = "nb_aktion_1_einheit_1";
            this.nb_aktion_1_einheit_1.NurEinserSchritte = false;
            this.nb_aktion_1_einheit_1.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_1_einheit_1.TabIndex = 248;
            this.nb_aktion_1_einheit_1.TausenderTrenner = true;
            this.nb_aktion_1_einheit_1.Text = "00";
            this.nb_aktion_1_einheit_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_1_einheit_1.UseVisualStyleBackColor = false;
            this.nb_aktion_1_einheit_1.Visible = false;
            this.nb_aktion_1_einheit_1.Wert = 0;
            this.nb_aktion_1_einheit_1.WertAnzeigen = true;
            this.nb_aktion_1_einheit_1.Click += new System.EventHandler(this.nb_aktion_1_einheit_1_Click);
            // 
            // nb_aktion_1_einheit_2
            // 
            this.nb_aktion_1_einheit_2.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_2.FlatAppearance.BorderSize = 0;
            this.nb_aktion_1_einheit_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_1_einheit_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_1_einheit_2.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_1_einheit_2.Location = new System.Drawing.Point(473, 585);
            this.nb_aktion_1_einheit_2.MaximalerWert = 99;
            this.nb_aktion_1_einheit_2.MaximaleStellen = 2;
            this.nb_aktion_1_einheit_2.MinimalerWert = 0;
            this.nb_aktion_1_einheit_2.Name = "nb_aktion_1_einheit_2";
            this.nb_aktion_1_einheit_2.NurEinserSchritte = false;
            this.nb_aktion_1_einheit_2.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_1_einheit_2.TabIndex = 249;
            this.nb_aktion_1_einheit_2.TausenderTrenner = true;
            this.nb_aktion_1_einheit_2.Text = "00";
            this.nb_aktion_1_einheit_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_1_einheit_2.UseVisualStyleBackColor = false;
            this.nb_aktion_1_einheit_2.Visible = false;
            this.nb_aktion_1_einheit_2.Wert = 0;
            this.nb_aktion_1_einheit_2.WertAnzeigen = true;
            this.nb_aktion_1_einheit_2.Click += new System.EventHandler(this.nb_aktion_1_einheit_2_Click);
            // 
            // lbl_aktion_1_plus_1
            // 
            this.lbl_aktion_1_plus_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_1_plus_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_1_plus_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_1_plus_1.Location = new System.Drawing.Point(462, 589);
            this.lbl_aktion_1_plus_1.Name = "lbl_aktion_1_plus_1";
            this.lbl_aktion_1_plus_1.Size = new System.Drawing.Size(19, 32);
            this.lbl_aktion_1_plus_1.TabIndex = 250;
            this.lbl_aktion_1_plus_1.Tag = "0";
            this.lbl_aktion_1_plus_1.Text = "+";
            this.lbl_aktion_1_plus_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_aktion_1_plus_1.Visible = false;
            // 
            // lbl_aktion_1_plus_2
            // 
            this.lbl_aktion_1_plus_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_1_plus_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_1_plus_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_1_plus_2.Location = new System.Drawing.Point(519, 589);
            this.lbl_aktion_1_plus_2.Name = "lbl_aktion_1_plus_2";
            this.lbl_aktion_1_plus_2.Size = new System.Drawing.Size(19, 32);
            this.lbl_aktion_1_plus_2.TabIndex = 252;
            this.lbl_aktion_1_plus_2.Tag = "0";
            this.lbl_aktion_1_plus_2.Text = "+";
            this.lbl_aktion_1_plus_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_aktion_1_plus_2.Visible = false;
            // 
            // nb_aktion_1_einheit_3
            // 
            this.nb_aktion_1_einheit_3.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_3.FlatAppearance.BorderSize = 0;
            this.nb_aktion_1_einheit_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_1_einheit_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_1_einheit_3.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_1_einheit_3.Location = new System.Drawing.Point(530, 585);
            this.nb_aktion_1_einheit_3.MaximalerWert = 99;
            this.nb_aktion_1_einheit_3.MaximaleStellen = 2;
            this.nb_aktion_1_einheit_3.MinimalerWert = 0;
            this.nb_aktion_1_einheit_3.Name = "nb_aktion_1_einheit_3";
            this.nb_aktion_1_einheit_3.NurEinserSchritte = false;
            this.nb_aktion_1_einheit_3.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_1_einheit_3.TabIndex = 251;
            this.nb_aktion_1_einheit_3.TausenderTrenner = true;
            this.nb_aktion_1_einheit_3.Text = "00";
            this.nb_aktion_1_einheit_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_1_einheit_3.UseVisualStyleBackColor = false;
            this.nb_aktion_1_einheit_3.Visible = false;
            this.nb_aktion_1_einheit_3.Wert = 0;
            this.nb_aktion_1_einheit_3.WertAnzeigen = true;
            this.nb_aktion_1_einheit_3.Click += new System.EventHandler(this.nb_aktion_1_einheit_3_Click);
            // 
            // lbl_aktion_1_plus_3
            // 
            this.lbl_aktion_1_plus_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_1_plus_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_1_plus_3.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_1_plus_3.Location = new System.Drawing.Point(576, 589);
            this.lbl_aktion_1_plus_3.Name = "lbl_aktion_1_plus_3";
            this.lbl_aktion_1_plus_3.Size = new System.Drawing.Size(19, 32);
            this.lbl_aktion_1_plus_3.TabIndex = 254;
            this.lbl_aktion_1_plus_3.Tag = "0";
            this.lbl_aktion_1_plus_3.Text = "+";
            this.lbl_aktion_1_plus_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_aktion_1_plus_3.Visible = false;
            // 
            // nb_aktion_1_einheit_4
            // 
            this.nb_aktion_1_einheit_4.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_4.FlatAppearance.BorderSize = 0;
            this.nb_aktion_1_einheit_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_1_einheit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_1_einheit_4.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_1_einheit_4.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_1_einheit_4.Location = new System.Drawing.Point(587, 585);
            this.nb_aktion_1_einheit_4.MaximalerWert = 99;
            this.nb_aktion_1_einheit_4.MaximaleStellen = 2;
            this.nb_aktion_1_einheit_4.MinimalerWert = 0;
            this.nb_aktion_1_einheit_4.Name = "nb_aktion_1_einheit_4";
            this.nb_aktion_1_einheit_4.NurEinserSchritte = false;
            this.nb_aktion_1_einheit_4.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_1_einheit_4.TabIndex = 253;
            this.nb_aktion_1_einheit_4.TausenderTrenner = true;
            this.nb_aktion_1_einheit_4.Text = "00";
            this.nb_aktion_1_einheit_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_1_einheit_4.UseVisualStyleBackColor = false;
            this.nb_aktion_1_einheit_4.Visible = false;
            this.nb_aktion_1_einheit_4.Wert = 0;
            this.nb_aktion_1_einheit_4.WertAnzeigen = true;
            this.nb_aktion_1_einheit_4.Click += new System.EventHandler(this.nb_aktion_1_einheit_4_Click);
            // 
            // lbl_aktion_2_plus_3
            // 
            this.lbl_aktion_2_plus_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_2_plus_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_2_plus_3.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_2_plus_3.Location = new System.Drawing.Point(580, 668);
            this.lbl_aktion_2_plus_3.Name = "lbl_aktion_2_plus_3";
            this.lbl_aktion_2_plus_3.Size = new System.Drawing.Size(19, 32);
            this.lbl_aktion_2_plus_3.TabIndex = 266;
            this.lbl_aktion_2_plus_3.Tag = "0";
            this.lbl_aktion_2_plus_3.Text = "+";
            this.lbl_aktion_2_plus_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_aktion_2_plus_3.Visible = false;
            this.lbl_aktion_2_plus_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_aktion_2_einheit_4
            // 
            this.nb_aktion_2_einheit_4.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_4.FlatAppearance.BorderSize = 0;
            this.nb_aktion_2_einheit_4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_2_einheit_4.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_2_einheit_4.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_2_einheit_4.Location = new System.Drawing.Point(591, 664);
            this.nb_aktion_2_einheit_4.MaximalerWert = 99;
            this.nb_aktion_2_einheit_4.MaximaleStellen = 2;
            this.nb_aktion_2_einheit_4.MinimalerWert = 0;
            this.nb_aktion_2_einheit_4.Name = "nb_aktion_2_einheit_4";
            this.nb_aktion_2_einheit_4.NurEinserSchritte = false;
            this.nb_aktion_2_einheit_4.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_2_einheit_4.TabIndex = 265;
            this.nb_aktion_2_einheit_4.TausenderTrenner = true;
            this.nb_aktion_2_einheit_4.Text = "00";
            this.nb_aktion_2_einheit_4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_2_einheit_4.UseVisualStyleBackColor = false;
            this.nb_aktion_2_einheit_4.Visible = false;
            this.nb_aktion_2_einheit_4.Wert = 0;
            this.nb_aktion_2_einheit_4.WertAnzeigen = true;
            this.nb_aktion_2_einheit_4.Click += new System.EventHandler(this.nb_aktion_2_einheit_4_Click);
            this.nb_aktion_2_einheit_4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktion_2_plus_2
            // 
            this.lbl_aktion_2_plus_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_2_plus_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_2_plus_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_2_plus_2.Location = new System.Drawing.Point(523, 668);
            this.lbl_aktion_2_plus_2.Name = "lbl_aktion_2_plus_2";
            this.lbl_aktion_2_plus_2.Size = new System.Drawing.Size(19, 32);
            this.lbl_aktion_2_plus_2.TabIndex = 264;
            this.lbl_aktion_2_plus_2.Tag = "0";
            this.lbl_aktion_2_plus_2.Text = "+";
            this.lbl_aktion_2_plus_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_aktion_2_plus_2.Visible = false;
            this.lbl_aktion_2_plus_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_aktion_2_einheit_3
            // 
            this.nb_aktion_2_einheit_3.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_3.FlatAppearance.BorderSize = 0;
            this.nb_aktion_2_einheit_3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_2_einheit_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_2_einheit_3.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_2_einheit_3.Location = new System.Drawing.Point(534, 664);
            this.nb_aktion_2_einheit_3.MaximalerWert = 99;
            this.nb_aktion_2_einheit_3.MaximaleStellen = 2;
            this.nb_aktion_2_einheit_3.MinimalerWert = 0;
            this.nb_aktion_2_einheit_3.Name = "nb_aktion_2_einheit_3";
            this.nb_aktion_2_einheit_3.NurEinserSchritte = false;
            this.nb_aktion_2_einheit_3.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_2_einheit_3.TabIndex = 263;
            this.nb_aktion_2_einheit_3.TausenderTrenner = true;
            this.nb_aktion_2_einheit_3.Text = "00";
            this.nb_aktion_2_einheit_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_2_einheit_3.UseVisualStyleBackColor = false;
            this.nb_aktion_2_einheit_3.Visible = false;
            this.nb_aktion_2_einheit_3.Wert = 0;
            this.nb_aktion_2_einheit_3.WertAnzeigen = true;
            this.nb_aktion_2_einheit_3.Click += new System.EventHandler(this.nb_aktion_2_einheit_3_Click);
            this.nb_aktion_2_einheit_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktion_2_plus_1
            // 
            this.lbl_aktion_2_plus_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_2_plus_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_2_plus_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_2_plus_1.Location = new System.Drawing.Point(466, 668);
            this.lbl_aktion_2_plus_1.Name = "lbl_aktion_2_plus_1";
            this.lbl_aktion_2_plus_1.Size = new System.Drawing.Size(19, 32);
            this.lbl_aktion_2_plus_1.TabIndex = 262;
            this.lbl_aktion_2_plus_1.Tag = "0";
            this.lbl_aktion_2_plus_1.Text = "+";
            this.lbl_aktion_2_plus_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_aktion_2_plus_1.Visible = false;
            this.lbl_aktion_2_plus_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_aktion_2_einheit_2
            // 
            this.nb_aktion_2_einheit_2.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_2.FlatAppearance.BorderSize = 0;
            this.nb_aktion_2_einheit_2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_2_einheit_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_2_einheit_2.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_2_einheit_2.Location = new System.Drawing.Point(477, 664);
            this.nb_aktion_2_einheit_2.MaximalerWert = 99;
            this.nb_aktion_2_einheit_2.MaximaleStellen = 2;
            this.nb_aktion_2_einheit_2.MinimalerWert = 0;
            this.nb_aktion_2_einheit_2.Name = "nb_aktion_2_einheit_2";
            this.nb_aktion_2_einheit_2.NurEinserSchritte = false;
            this.nb_aktion_2_einheit_2.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_2_einheit_2.TabIndex = 261;
            this.nb_aktion_2_einheit_2.TausenderTrenner = true;
            this.nb_aktion_2_einheit_2.Text = "00";
            this.nb_aktion_2_einheit_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_2_einheit_2.UseVisualStyleBackColor = false;
            this.nb_aktion_2_einheit_2.Visible = false;
            this.nb_aktion_2_einheit_2.Wert = 0;
            this.nb_aktion_2_einheit_2.WertAnzeigen = true;
            this.nb_aktion_2_einheit_2.Click += new System.EventHandler(this.nb_aktion_2_einheit_2_Click);
            this.nb_aktion_2_einheit_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_aktion_2_einheit_1
            // 
            this.nb_aktion_2_einheit_1.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_1.FlatAppearance.BorderSize = 0;
            this.nb_aktion_2_einheit_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_einheit_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_2_einheit_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_2_einheit_1.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_2_einheit_1.Location = new System.Drawing.Point(420, 664);
            this.nb_aktion_2_einheit_1.MaximalerWert = 99;
            this.nb_aktion_2_einheit_1.MaximaleStellen = 2;
            this.nb_aktion_2_einheit_1.MinimalerWert = 0;
            this.nb_aktion_2_einheit_1.Name = "nb_aktion_2_einheit_1";
            this.nb_aktion_2_einheit_1.NurEinserSchritte = false;
            this.nb_aktion_2_einheit_1.Size = new System.Drawing.Size(54, 40);
            this.nb_aktion_2_einheit_1.TabIndex = 260;
            this.nb_aktion_2_einheit_1.TausenderTrenner = true;
            this.nb_aktion_2_einheit_1.Text = "00";
            this.nb_aktion_2_einheit_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_2_einheit_1.UseVisualStyleBackColor = false;
            this.nb_aktion_2_einheit_1.Visible = false;
            this.nb_aktion_2_einheit_1.Wert = 0;
            this.nb_aktion_2_einheit_1.WertAnzeigen = true;
            this.nb_aktion_2_einheit_1.Click += new System.EventHandler(this.nb_aktion_2_einheit_1_Click);
            this.nb_aktion_2_einheit_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_aktion_2_zielstuetzpunkt
            // 
            this.nb_aktion_2_zielstuetzpunkt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nb_aktion_2_zielstuetzpunkt.AutoSize = true;
            this.nb_aktion_2_zielstuetzpunkt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nb_aktion_2_zielstuetzpunkt.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_zielstuetzpunkt.FlatAppearance.BorderSize = 0;
            this.nb_aktion_2_zielstuetzpunkt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_zielstuetzpunkt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_zielstuetzpunkt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_2_zielstuetzpunkt.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_2_zielstuetzpunkt.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_2_zielstuetzpunkt.Location = new System.Drawing.Point(755, 662);
            this.nb_aktion_2_zielstuetzpunkt.MaximalerWert = 999999999;
            this.nb_aktion_2_zielstuetzpunkt.MaximaleStellen = 9;
            this.nb_aktion_2_zielstuetzpunkt.MinimalerWert = 0;
            this.nb_aktion_2_zielstuetzpunkt.Name = "nb_aktion_2_zielstuetzpunkt";
            this.nb_aktion_2_zielstuetzpunkt.NurEinserSchritte = true;
            this.nb_aktion_2_zielstuetzpunkt.Size = new System.Drawing.Size(40, 42);
            this.nb_aktion_2_zielstuetzpunkt.TabIndex = 259;
            this.nb_aktion_2_zielstuetzpunkt.TausenderTrenner = false;
            this.nb_aktion_2_zielstuetzpunkt.Text = "0";
            this.nb_aktion_2_zielstuetzpunkt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_2_zielstuetzpunkt.UseVisualStyleBackColor = false;
            this.nb_aktion_2_zielstuetzpunkt.Visible = false;
            this.nb_aktion_2_zielstuetzpunkt.Wert = 0;
            this.nb_aktion_2_zielstuetzpunkt.WertAnzeigen = false;
            this.nb_aktion_2_zielstuetzpunkt.Click += new System.EventHandler(this.nb_aktion_2_zielstuetzpunkt_Click);
            this.nb_aktion_2_zielstuetzpunkt.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // nb_aktion_2_zielland
            // 
            this.nb_aktion_2_zielland.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nb_aktion_2_zielland.AutoSize = true;
            this.nb_aktion_2_zielland.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nb_aktion_2_zielland.BackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_zielland.FlatAppearance.BorderSize = 0;
            this.nb_aktion_2_zielland.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_zielland.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nb_aktion_2_zielland.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nb_aktion_2_zielland.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_aktion_2_zielland.ForeColor = System.Drawing.Color.Black;
            this.nb_aktion_2_zielland.Location = new System.Drawing.Point(214, 662);
            this.nb_aktion_2_zielland.MaximalerWert = 999999999;
            this.nb_aktion_2_zielland.MaximaleStellen = 9;
            this.nb_aktion_2_zielland.MinimalerWert = 0;
            this.nb_aktion_2_zielland.Name = "nb_aktion_2_zielland";
            this.nb_aktion_2_zielland.NurEinserSchritte = true;
            this.nb_aktion_2_zielland.Size = new System.Drawing.Size(40, 42);
            this.nb_aktion_2_zielland.TabIndex = 258;
            this.nb_aktion_2_zielland.TausenderTrenner = false;
            this.nb_aktion_2_zielland.Text = "0";
            this.nb_aktion_2_zielland.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nb_aktion_2_zielland.UseVisualStyleBackColor = false;
            this.nb_aktion_2_zielland.Visible = false;
            this.nb_aktion_2_zielland.Wert = 0;
            this.nb_aktion_2_zielland.WertAnzeigen = false;
            this.nb_aktion_2_zielland.Click += new System.EventHandler(this.nb_aktion_2_zielland_Click);
            this.nb_aktion_2_zielland.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktion_2_text_3
            // 
            this.lbl_aktion_2_text_3.AutoSize = true;
            this.lbl_aktion_2_text_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_2_text_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_2_text_3.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_2_text_3.Location = new System.Drawing.Point(637, 667);
            this.lbl_aktion_2_text_3.Name = "lbl_aktion_2_text_3";
            this.lbl_aktion_2_text_3.Size = new System.Drawing.Size(121, 32);
            this.lbl_aktion_2_text_3.TabIndex = 257;
            this.lbl_aktion_2_text_3.Tag = "0";
            this.lbl_aktion_2_text_3.Text = "Truppen";
            this.lbl_aktion_2_text_3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktion_2_text_3.Visible = false;
            this.lbl_aktion_2_text_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktion_2_text_2
            // 
            this.lbl_aktion_2_text_2.AutoSize = true;
            this.lbl_aktion_2_text_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_2_text_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_2_text_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_2_text_2.Location = new System.Drawing.Point(371, 667);
            this.lbl_aktion_2_text_2.Name = "lbl_aktion_2_text_2";
            this.lbl_aktion_2_text_2.Size = new System.Drawing.Size(56, 32);
            this.lbl_aktion_2_text_2.TabIndex = 256;
            this.lbl_aktion_2_text_2.Tag = "0";
            this.lbl_aktion_2_text_2.Text = "mit";
            this.lbl_aktion_2_text_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktion_2_text_2.Visible = false;
            this.lbl_aktion_2_text_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // lbl_aktion_2_text_1
            // 
            this.lbl_aktion_2_text_1.AutoSize = true;
            this.lbl_aktion_2_text_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_aktion_2_text_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_aktion_2_text_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_aktion_2_text_1.Location = new System.Drawing.Point(68, 667);
            this.lbl_aktion_2_text_1.Name = "lbl_aktion_2_text_1";
            this.lbl_aktion_2_text_1.Size = new System.Drawing.Size(153, 32);
            this.lbl_aktion_2_text_1.TabIndex = 255;
            this.lbl_aktion_2_text_1.Tag = "0";
            this.lbl_aktion_2_text_1.Text = "Überwacht";
            this.lbl_aktion_2_text_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_aktion_2_text_1.Visible = false;
            this.lbl_aktion_2_text_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            // 
            // frmStuetzpunktVerwalten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Conspiratio.Properties.Resources.Stadt1;
            this.ClientSize = new System.Drawing.Size(1044, 730);
            this.Controls.Add(this.lbl_aktion_2_plus_3);
            this.Controls.Add(this.nb_aktion_2_einheit_4);
            this.Controls.Add(this.lbl_aktion_2_plus_2);
            this.Controls.Add(this.nb_aktion_2_einheit_3);
            this.Controls.Add(this.lbl_aktion_2_plus_1);
            this.Controls.Add(this.nb_aktion_2_einheit_2);
            this.Controls.Add(this.nb_aktion_2_einheit_1);
            this.Controls.Add(this.nb_aktion_2_zielstuetzpunkt);
            this.Controls.Add(this.nb_aktion_2_zielland);
            this.Controls.Add(this.lbl_aktion_2_text_3);
            this.Controls.Add(this.lbl_aktion_2_text_2);
            this.Controls.Add(this.lbl_aktion_2_text_1);
            this.Controls.Add(this.lbl_aktion_1_plus_3);
            this.Controls.Add(this.nb_aktion_1_einheit_4);
            this.Controls.Add(this.lbl_aktion_1_plus_2);
            this.Controls.Add(this.nb_aktion_1_einheit_3);
            this.Controls.Add(this.lbl_aktion_1_plus_1);
            this.Controls.Add(this.nb_aktion_1_einheit_2);
            this.Controls.Add(this.nb_aktion_1_einheit_1);
            this.Controls.Add(this.nb_aktion_1_zielstuetzpunkt);
            this.Controls.Add(this.nb_aktion_1_zielland);
            this.Controls.Add(this.lbl_aktion_1_text_3);
            this.Controls.Add(this.lbl_aktion_1_text_2);
            this.Controls.Add(this.lbl_aktion_1_text_1);
            this.Controls.Add(this.lbl_aktionsart_2);
            this.Controls.Add(this.lbl_aktionsart_1);
            this.Controls.Add(this.nb_einheit_4);
            this.Controls.Add(this.nb_einheit_3);
            this.Controls.Add(this.nb_einheit_2);
            this.Controls.Add(this.nb_einheit_1);
            this.Controls.Add(this.btn_einheit_4);
            this.Controls.Add(this.btn_einheit_3);
            this.Controls.Add(this.btn_einheit_2);
            this.Controls.Add(this.btn_einheit_1);
            this.Controls.Add(this.btn_ausbau);
            this.Controls.Add(this.btn_reperatur);
            this.Controls.Add(this.btn_manoever);
            this.Controls.Add(this.btn_sicherheit_tarnung);
            this.Controls.Add(this.btn_zoll);
            this.Name = "frmStuetzpunktVerwalten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmStuetzpunktVerwalten";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmStuetzpunktVerwalten_Activated);
            this.Load += new System.EventHandler(this.frmStuetzpunktVerwalten_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmStuetzpunktVerwalten_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlatButton btn_zoll;
        private FlatButton btn_sicherheit_tarnung;
        private FlatButton btn_manoever;
        private FlatButton btn_reperatur;
        private FlatButton btn_ausbau;
        private FlatButton btn_einheit_1;
        private FlatButton btn_einheit_2;
        private FlatButton btn_einheit_3;
        private FlatButton btn_einheit_4;
        private NumericButton nb_einheit_1;
        private NumericButton nb_einheit_2;
        private NumericButton nb_einheit_3;
        private NumericButton nb_einheit_4;
        private System.Windows.Forms.ToolTip ttButtons;
        private System.Windows.Forms.Label lbl_aktionsart_1;
        private System.Windows.Forms.Label lbl_aktionsart_2;
        private System.Windows.Forms.Label lbl_aktion_1_text_1;
        private System.Windows.Forms.Label lbl_aktion_1_text_2;
        private System.Windows.Forms.Label lbl_aktion_1_text_3;
        private NumericButton nb_aktion_1_zielland;
        private NumericButton nb_aktion_1_zielstuetzpunkt;
        private NumericButton nb_aktion_1_einheit_1;
        private NumericButton nb_aktion_1_einheit_2;
        private System.Windows.Forms.Label lbl_aktion_1_plus_1;
        private System.Windows.Forms.Label lbl_aktion_1_plus_2;
        private NumericButton nb_aktion_1_einheit_3;
        private System.Windows.Forms.Label lbl_aktion_1_plus_3;
        private NumericButton nb_aktion_1_einheit_4;
        private System.Windows.Forms.Label lbl_aktion_2_plus_3;
        private NumericButton nb_aktion_2_einheit_4;
        private System.Windows.Forms.Label lbl_aktion_2_plus_2;
        private NumericButton nb_aktion_2_einheit_3;
        private System.Windows.Forms.Label lbl_aktion_2_plus_1;
        private NumericButton nb_aktion_2_einheit_2;
        private NumericButton nb_aktion_2_einheit_1;
        private NumericButton nb_aktion_2_zielstuetzpunkt;
        private NumericButton nb_aktion_2_zielland;
        private System.Windows.Forms.Label lbl_aktion_2_text_3;
        private System.Windows.Forms.Label lbl_aktion_2_text_2;
        private System.Windows.Forms.Label lbl_aktion_2_text_1;
    }
}