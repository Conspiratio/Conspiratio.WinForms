using Conspiratio.Controls;

namespace Conspiratio
{
    partial class Transport
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
            this.btn_bild = new System.Windows.Forms.Button();
            this.lbl_text = new System.Windows.Forms.Label();
            this.txt_frage = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_3 = new System.Windows.Forms.Label();
            this.lbl_4 = new System.Windows.Forms.Label();
            this.lbl_karawanenfuehrer = new System.Windows.Forms.Label();
            this.btn_weiter = new Conspiratio.Controls.LinkButton();
            this.lbl_fixpreis = new System.Windows.Forms.Label();
            this.lbl_pps = new System.Windows.Forms.Label();
            this.lbl_verlass = new System.Windows.Forms.Label();
            this.lbl_sicherheit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_bild
            // 
            this.btn_bild.BackColor = System.Drawing.Color.Transparent;
            this.btn_bild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_bild.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_bild.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_bild.ForeColor = System.Drawing.Color.Transparent;
            this.btn_bild.Location = new System.Drawing.Point(72, 139);
            this.btn_bild.Margin = new System.Windows.Forms.Padding(0);
            this.btn_bild.Name = "btn_bild";
            this.btn_bild.Size = new System.Drawing.Size(400, 225);
            this.btn_bild.TabIndex = 203;
            this.btn_bild.UseVisualStyleBackColor = false;
            this.btn_bild.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_text
            // 
            this.lbl_text.AutoSize = true;
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.Location = new System.Drawing.Point(259, 58);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(164, 36);
            this.lbl_text.TabIndex = 204;
            this.lbl_text.Text = "Transport";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // txt_frage
            // 
            this.txt_frage.AutoSize = true;
            this.txt_frage.BackColor = System.Drawing.Color.Transparent;
            this.txt_frage.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_frage.Location = new System.Drawing.Point(491, 128);
            this.txt_frage.Name = "txt_frage";
            this.txt_frage.Size = new System.Drawing.Size(40, 28);
            this.txt_frage.TabIndex = 205;
            this.txt_frage.Text = "kh";
            this.txt_frage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_frage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_1.Location = new System.Drawing.Point(491, 207);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(119, 28);
            this.lbl_1.TabIndex = 206;
            this.lbl_1.Text = "Fixpreis: ";
            this.lbl_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_2.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_2.Location = new System.Drawing.Point(491, 252);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(195, 28);
            this.lbl_2.TabIndex = 207;
            this.lbl_2.Text = "Preis/100 Stück:";
            this.lbl_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_3
            // 
            this.lbl_3.AutoSize = true;
            this.lbl_3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_3.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_3.Location = new System.Drawing.Point(491, 297);
            this.lbl_3.Name = "lbl_3";
            this.lbl_3.Size = new System.Drawing.Size(186, 28);
            this.lbl_3.TabIndex = 208;
            this.lbl_3.Text = "Verlässlichkeit:";
            this.lbl_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_4
            // 
            this.lbl_4.AutoSize = true;
            this.lbl_4.BackColor = System.Drawing.Color.Transparent;
            this.lbl_4.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_4.Location = new System.Drawing.Point(491, 337);
            this.lbl_4.Name = "lbl_4";
            this.lbl_4.Size = new System.Drawing.Size(136, 28);
            this.lbl_4.TabIndex = 209;
            this.lbl_4.Text = "Sicherheit:";
            this.lbl_4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_karawanenfuehrer
            // 
            this.lbl_karawanenfuehrer.AutoSize = true;
            this.lbl_karawanenfuehrer.BackColor = System.Drawing.Color.Transparent;
            this.lbl_karawanenfuehrer.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_karawanenfuehrer.Location = new System.Drawing.Point(68, 426);
            this.lbl_karawanenfuehrer.Name = "lbl_karawanenfuehrer";
            this.lbl_karawanenfuehrer.Size = new System.Drawing.Size(215, 28);
            this.lbl_karawanenfuehrer.TabIndex = 210;
            this.lbl_karawanenfuehrer.Text = "Karawanenführer:";
            this.lbl_karawanenfuehrer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_karawanenfuehrer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // btn_weiter
            // 
            this.btn_weiter.AutoSize = true;
            this.btn_weiter.BackColor = System.Drawing.Color.Transparent;
            this.btn_weiter.FensterBeiRechtsklickSchliessen = false;
            this.btn_weiter.FlatAppearance.BorderSize = 0;
            this.btn_weiter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_weiter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_weiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_weiter.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_weiter.ForeColor = System.Drawing.Color.Black;
            this.btn_weiter.Location = new System.Drawing.Point(714, 438);
            this.btn_weiter.Margin = new System.Windows.Forms.Padding(0);
            this.btn_weiter.Name = "btn_weiter";
            this.btn_weiter.Size = new System.Drawing.Size(107, 42);
            this.btn_weiter.TabIndex = 211;
            this.btn_weiter.Text = "weiter";
            this.btn_weiter.UseVisualStyleBackColor = false;
            this.btn_weiter.Click += new System.EventHandler(this.btn_weiter_Click);
            this.btn_weiter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_fixpreis
            // 
            this.lbl_fixpreis.AutoSize = true;
            this.lbl_fixpreis.BackColor = System.Drawing.Color.Transparent;
            this.lbl_fixpreis.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fixpreis.Location = new System.Drawing.Point(729, 205);
            this.lbl_fixpreis.Name = "lbl_fixpreis";
            this.lbl_fixpreis.Size = new System.Drawing.Size(40, 28);
            this.lbl_fixpreis.TabIndex = 212;
            this.lbl_fixpreis.Text = "kh";
            this.lbl_fixpreis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_fixpreis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_pps
            // 
            this.lbl_pps.AutoSize = true;
            this.lbl_pps.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pps.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pps.Location = new System.Drawing.Point(729, 250);
            this.lbl_pps.Name = "lbl_pps";
            this.lbl_pps.Size = new System.Drawing.Size(40, 28);
            this.lbl_pps.TabIndex = 213;
            this.lbl_pps.Text = "kh";
            this.lbl_pps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_pps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_verlass
            // 
            this.lbl_verlass.AutoSize = true;
            this.lbl_verlass.BackColor = System.Drawing.Color.Transparent;
            this.lbl_verlass.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_verlass.Location = new System.Drawing.Point(729, 295);
            this.lbl_verlass.Name = "lbl_verlass";
            this.lbl_verlass.Size = new System.Drawing.Size(40, 28);
            this.lbl_verlass.TabIndex = 214;
            this.lbl_verlass.Text = "kh";
            this.lbl_verlass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_verlass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // lbl_sicherheit
            // 
            this.lbl_sicherheit.AutoSize = true;
            this.lbl_sicherheit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_sicherheit.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_sicherheit.Location = new System.Drawing.Point(729, 335);
            this.lbl_sicherheit.Name = "lbl_sicherheit";
            this.lbl_sicherheit.Size = new System.Drawing.Size(40, 28);
            this.lbl_sicherheit.TabIndex = 215;
            this.lbl_sicherheit.Text = "kh";
            this.lbl_sicherheit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_sicherheit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            // 
            // Transport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 549);
            this.Controls.Add(this.lbl_sicherheit);
            this.Controls.Add(this.lbl_verlass);
            this.Controls.Add(this.lbl_pps);
            this.Controls.Add(this.lbl_fixpreis);
            this.Controls.Add(this.btn_weiter);
            this.Controls.Add(this.lbl_karawanenfuehrer);
            this.Controls.Add(this.lbl_4);
            this.Controls.Add(this.lbl_3);
            this.Controls.Add(this.lbl_2);
            this.Controls.Add(this.lbl_1);
            this.Controls.Add(this.txt_frage);
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.btn_bild);
            this.Name = "Transport";
            this.Text = "Transport";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Transport_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_bild;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label txt_frage;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_3;
        private System.Windows.Forms.Label lbl_4;
        private System.Windows.Forms.Label lbl_karawanenfuehrer;
        private LinkButton btn_weiter;
        private System.Windows.Forms.Label lbl_fixpreis;
        private System.Windows.Forms.Label lbl_pps;
        private System.Windows.Forms.Label lbl_verlass;
        private System.Windows.Forms.Label lbl_sicherheit;
    }
}