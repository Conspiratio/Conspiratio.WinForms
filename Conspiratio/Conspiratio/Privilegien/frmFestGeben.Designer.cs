using Conspiratio.Controls;

namespace Conspiratio.Privilegien
{
    partial class frmFestGeben
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFestGeben));
            this.btn_ort = new Conspiratio.Controls.LinkButton();
            this.lbl_priv0 = new System.Windows.Forms.Label();
            this.lbl_fest_art_1 = new System.Windows.Forms.Label();
            this.lbl_fest_ort_2 = new System.Windows.Forms.Label();
            this.lbl_fest_jahr_2 = new System.Windows.Forms.Label();
            this.btn_fest_art = new Conspiratio.Controls.CrystalButton();
            this.btn_fest_ort = new Conspiratio.Controls.CrystalButton();
            this.btn_fest_jahr = new Conspiratio.Controls.CrystalButton();
            this.lbl_fest_art_2 = new System.Windows.Forms.Label();
            this.btn_groesse = new Conspiratio.Controls.LinkButton();
            this.btn_musiker = new Conspiratio.Controls.LinkButton();
            this.lbl_fest_art_3 = new System.Windows.Forms.Label();
            this.lbl_fest_ort_1 = new System.Windows.Forms.Label();
            this.lbl_fest_jahr_1 = new System.Windows.Forms.Label();
            this.btn_jahr = new Conspiratio.NumericButton();
            this.SuspendLayout();
            // 
            // btn_ort
            // 
            this.btn_ort.AutoSize = true;
            this.btn_ort.BackColor = System.Drawing.Color.Transparent;
            this.btn_ort.FensterBeiRechtsklickSchliessen = false;
            this.btn_ort.FlatAppearance.BorderSize = 0;
            this.btn_ort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ort.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ort.ForeColor = System.Drawing.Color.Black;
            this.btn_ort.Location = new System.Drawing.Point(103, 194);
            this.btn_ort.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ort.Name = "btn_ort";
            this.btn_ort.Size = new System.Drawing.Size(208, 42);
            this.btn_ort.TabIndex = 257;
            this.btn_ort.Text = "Stadt";
            this.btn_ort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ort.UseVisualStyleBackColor = false;
            this.btn_ort.Visible = false;
            this.btn_ort.Click += new System.EventHandler(this.btn_stadt_Click);
            this.btn_ort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_priv0
            // 
            this.lbl_priv0.AutoSize = true;
            this.lbl_priv0.BackColor = System.Drawing.Color.Transparent;
            this.lbl_priv0.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_priv0.ForeColor = System.Drawing.Color.Black;
            this.lbl_priv0.Location = new System.Drawing.Point(45, 36);
            this.lbl_priv0.Name = "lbl_priv0";
            this.lbl_priv0.Size = new System.Drawing.Size(436, 32);
            this.lbl_priv0.TabIndex = 260;
            this.lbl_priv0.Text = "Was für ein Fest wollt Ihr geben?";
            this.lbl_priv0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_art_1
            // 
            this.lbl_fest_art_1.AutoSize = true;
            this.lbl_fest_art_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_art_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_art_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_art_1.Location = new System.Drawing.Point(72, 75);
            this.lbl_fest_art_1.Name = "lbl_fest_art_1";
            this.lbl_fest_art_1.Size = new System.Drawing.Size(56, 32);
            this.lbl_fest_art_1.TabIndex = 261;
            this.lbl_fest_art_1.Text = "Ein";
            this.lbl_fest_art_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_ort_2
            // 
            this.lbl_fest_ort_2.AutoSize = true;
            this.lbl_fest_ort_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_ort_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_ort_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_ort_2.Location = new System.Drawing.Point(72, 199);
            this.lbl_fest_ort_2.Name = "lbl_fest_ort_2";
            this.lbl_fest_ort_2.Size = new System.Drawing.Size(39, 32);
            this.lbl_fest_ort_2.TabIndex = 262;
            this.lbl_fest_ort_2.Text = "In";
            this.lbl_fest_ort_2.Visible = false;
            this.lbl_fest_ort_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_jahr_2
            // 
            this.lbl_fest_jahr_2.AutoSize = true;
            this.lbl_fest_jahr_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_jahr_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_jahr_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_jahr_2.Location = new System.Drawing.Point(72, 296);
            this.lbl_fest_jahr_2.Name = "lbl_fest_jahr_2";
            this.lbl_fest_jahr_2.Size = new System.Drawing.Size(128, 32);
            this.lbl_fest_jahr_2.TabIndex = 263;
            this.lbl_fest_jahr_2.Text = "Im Jahre";
            this.lbl_fest_jahr_2.Visible = false;
            this.lbl_fest_jahr_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // btn_fest_art
            // 
            this.btn_fest_art.BackColor = System.Drawing.Color.Transparent;
            this.btn_fest_art.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_fest_art.BackgroundImage")));
            this.btn_fest_art.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_fest_art.Checkbox = false;
            this.btn_fest_art.Checked = false;
            this.btn_fest_art.FlatAppearance.BorderSize = 0;
            this.btn_fest_art.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_fest_art.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_fest_art.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fest_art.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fest_art.ForeColor = System.Drawing.Color.Black;
            this.btn_fest_art.Location = new System.Drawing.Point(48, 81);
            this.btn_fest_art.Margin = new System.Windows.Forms.Padding(0);
            this.btn_fest_art.Name = "btn_fest_art";
            this.btn_fest_art.Size = new System.Drawing.Size(20, 20);
            this.btn_fest_art.TabIndex = 267;
            this.btn_fest_art.Tag = false;
            this.btn_fest_art.UseVisualStyleBackColor = false;
            this.btn_fest_art.Click += new System.EventHandler(this.btn_fest_art_Click);
            this.btn_fest_art.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // btn_fest_ort
            // 
            this.btn_fest_ort.BackColor = System.Drawing.Color.Transparent;
            this.btn_fest_ort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_fest_ort.BackgroundImage")));
            this.btn_fest_ort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_fest_ort.Checkbox = false;
            this.btn_fest_ort.Checked = false;
            this.btn_fest_ort.FlatAppearance.BorderSize = 0;
            this.btn_fest_ort.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_fest_ort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_fest_ort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fest_ort.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fest_ort.ForeColor = System.Drawing.Color.Black;
            this.btn_fest_ort.Location = new System.Drawing.Point(48, 205);
            this.btn_fest_ort.Margin = new System.Windows.Forms.Padding(0);
            this.btn_fest_ort.Name = "btn_fest_ort";
            this.btn_fest_ort.Size = new System.Drawing.Size(20, 20);
            this.btn_fest_ort.TabIndex = 268;
            this.btn_fest_ort.Tag = false;
            this.btn_fest_ort.UseVisualStyleBackColor = false;
            this.btn_fest_ort.Visible = false;
            this.btn_fest_ort.Click += new System.EventHandler(this.btn_fest_ort_Click);
            this.btn_fest_ort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // btn_fest_jahr
            // 
            this.btn_fest_jahr.BackColor = System.Drawing.Color.Transparent;
            this.btn_fest_jahr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_fest_jahr.BackgroundImage")));
            this.btn_fest_jahr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_fest_jahr.Checkbox = false;
            this.btn_fest_jahr.Checked = false;
            this.btn_fest_jahr.FlatAppearance.BorderSize = 0;
            this.btn_fest_jahr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_fest_jahr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_fest_jahr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_fest_jahr.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fest_jahr.ForeColor = System.Drawing.Color.Black;
            this.btn_fest_jahr.Location = new System.Drawing.Point(48, 302);
            this.btn_fest_jahr.Margin = new System.Windows.Forms.Padding(0);
            this.btn_fest_jahr.Name = "btn_fest_jahr";
            this.btn_fest_jahr.Size = new System.Drawing.Size(20, 20);
            this.btn_fest_jahr.TabIndex = 270;
            this.btn_fest_jahr.Tag = false;
            this.btn_fest_jahr.UseVisualStyleBackColor = false;
            this.btn_fest_jahr.Visible = false;
            this.btn_fest_jahr.Click += new System.EventHandler(this.btn_fest_jahr_Click);
            this.btn_fest_jahr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_art_2
            // 
            this.lbl_fest_art_2.AutoSize = true;
            this.lbl_fest_art_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_art_2.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_art_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_art_2.Location = new System.Drawing.Point(282, 75);
            this.lbl_fest_art_2.Name = "lbl_fest_art_2";
            this.lbl_fest_art_2.Size = new System.Drawing.Size(119, 32);
            this.lbl_fest_art_2.TabIndex = 271;
            this.lbl_fest_art_2.Text = "Fest mit";
            this.lbl_fest_art_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // btn_groesse
            // 
            this.btn_groesse.AutoSize = true;
            this.btn_groesse.BackColor = System.Drawing.Color.Transparent;
            this.btn_groesse.FensterBeiRechtsklickSchliessen = false;
            this.btn_groesse.FlatAppearance.BorderSize = 0;
            this.btn_groesse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_groesse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_groesse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_groesse.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_groesse.ForeColor = System.Drawing.Color.Black;
            this.btn_groesse.Location = new System.Drawing.Point(131, 70);
            this.btn_groesse.Margin = new System.Windows.Forms.Padding(0);
            this.btn_groesse.Name = "btn_groesse";
            this.btn_groesse.Size = new System.Drawing.Size(145, 42);
            this.btn_groesse.TabIndex = 272;
            this.btn_groesse.Text = "normales";
            this.btn_groesse.UseVisualStyleBackColor = false;
            this.btn_groesse.Click += new System.EventHandler(this.btn_groesse_Click);
            this.btn_groesse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // btn_musiker
            // 
            this.btn_musiker.AutoSize = true;
            this.btn_musiker.BackColor = System.Drawing.Color.Transparent;
            this.btn_musiker.FensterBeiRechtsklickSchliessen = false;
            this.btn_musiker.FlatAppearance.BorderSize = 0;
            this.btn_musiker.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_musiker.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_musiker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_musiker.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_musiker.ForeColor = System.Drawing.Color.Black;
            this.btn_musiker.Location = new System.Drawing.Point(404, 70);
            this.btn_musiker.Margin = new System.Windows.Forms.Padding(0);
            this.btn_musiker.Name = "btn_musiker";
            this.btn_musiker.Size = new System.Drawing.Size(208, 42);
            this.btn_musiker.TabIndex = 273;
            this.btn_musiker.Text = "mittelmäßigen";
            this.btn_musiker.UseVisualStyleBackColor = false;
            this.btn_musiker.Click += new System.EventHandler(this.btn_musiker_Click);
            this.btn_musiker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_art_3
            // 
            this.lbl_fest_art_3.AutoSize = true;
            this.lbl_fest_art_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_art_3.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_art_3.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_art_3.Location = new System.Drawing.Point(72, 107);
            this.lbl_fest_art_3.Name = "lbl_fest_art_3";
            this.lbl_fest_art_3.Size = new System.Drawing.Size(134, 32);
            this.lbl_fest_art_3.TabIndex = 274;
            this.lbl_fest_art_3.Text = "Musikern";
            this.lbl_fest_art_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_ort_1
            // 
            this.lbl_fest_ort_1.AutoSize = true;
            this.lbl_fest_ort_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_ort_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_ort_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_ort_1.Location = new System.Drawing.Point(45, 162);
            this.lbl_fest_ort_1.Name = "lbl_fest_ort_1";
            this.lbl_fest_ort_1.Size = new System.Drawing.Size(386, 32);
            this.lbl_fest_ort_1.TabIndex = 275;
            this.lbl_fest_ort_1.Text = "Wo soll das Fest stattfinden?";
            this.lbl_fest_ort_1.Visible = false;
            this.lbl_fest_ort_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // lbl_fest_jahr_1
            // 
            this.lbl_fest_jahr_1.AutoSize = true;
            this.lbl_fest_jahr_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fest_jahr_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fest_jahr_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_fest_jahr_1.Location = new System.Drawing.Point(45, 257);
            this.lbl_fest_jahr_1.Name = "lbl_fest_jahr_1";
            this.lbl_fest_jahr_1.Size = new System.Drawing.Size(417, 32);
            this.lbl_fest_jahr_1.TabIndex = 276;
            this.lbl_fest_jahr_1.Text = "Wann soll das Fest stattfinden?";
            this.lbl_fest_jahr_1.Visible = false;
            this.lbl_fest_jahr_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // btn_jahr
            // 
            this.btn_jahr.AutoSize = true;
            this.btn_jahr.BackColor = System.Drawing.Color.Transparent;
            this.btn_jahr.FensterBeiRechtsklickSchliessen = false;
            this.btn_jahr.FlatAppearance.BorderSize = 0;
            this.btn_jahr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_jahr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_jahr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_jahr.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_jahr.ForeColor = System.Drawing.Color.Black;
            this.btn_jahr.Location = new System.Drawing.Point(190, 291);
            this.btn_jahr.Margin = new System.Windows.Forms.Padding(0);
            this.btn_jahr.MaximalerWert = 1610;
            this.btn_jahr.MaximaleStellen = 4;
            this.btn_jahr.MinimalerWert = 1605;
            this.btn_jahr.Name = "btn_jahr";
            this.btn_jahr.NurEinserSchritte = false;
            this.btn_jahr.Size = new System.Drawing.Size(85, 42);
            this.btn_jahr.TabIndex = 277;
            this.btn_jahr.TausenderTrenner = false;
            this.btn_jahr.Text = "1605";
            this.btn_jahr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_jahr.UseVisualStyleBackColor = false;
            this.btn_jahr.Visible = false;
            this.btn_jahr.Wert = 1605;
            this.btn_jahr.WertAnzeigen = true;
            this.btn_jahr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            // 
            // frmFestGeben
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 364);
            this.Controls.Add(this.btn_jahr);
            this.Controls.Add(this.lbl_fest_jahr_1);
            this.Controls.Add(this.lbl_fest_ort_1);
            this.Controls.Add(this.lbl_fest_art_3);
            this.Controls.Add(this.btn_musiker);
            this.Controls.Add(this.btn_groesse);
            this.Controls.Add(this.lbl_fest_art_2);
            this.Controls.Add(this.btn_fest_jahr);
            this.Controls.Add(this.btn_fest_ort);
            this.Controls.Add(this.btn_fest_art);
            this.Controls.Add(this.lbl_fest_jahr_2);
            this.Controls.Add(this.lbl_fest_ort_2);
            this.Controls.Add(this.lbl_fest_art_1);
            this.Controls.Add(this.lbl_priv0);
            this.Controls.Add(this.btn_ort);
            this.Name = "frmFestGeben";
            this.Text = "BauwerkStiftenForm";
            this.Load += new System.EventHandler(this.frmFestGeben_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmFestGeben_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkButton btn_ort;
        private System.Windows.Forms.Label lbl_priv0;
        private System.Windows.Forms.Label lbl_fest_art_1;
        private System.Windows.Forms.Label lbl_fest_ort_2;
        private System.Windows.Forms.Label lbl_fest_jahr_2;
        private CrystalButton btn_fest_art;
        private CrystalButton btn_fest_ort;
        private CrystalButton btn_fest_jahr;
        private System.Windows.Forms.Label lbl_fest_art_2;
        private LinkButton btn_groesse;
        private LinkButton btn_musiker;
        private System.Windows.Forms.Label lbl_fest_art_3;
        private System.Windows.Forms.Label lbl_fest_ort_1;
        private System.Windows.Forms.Label lbl_fest_jahr_1;
        private NumericButton btn_jahr;
    }
}