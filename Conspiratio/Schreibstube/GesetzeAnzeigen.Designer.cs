using Conspiratio.Controls;

namespace Conspiratio
{
    partial class GesetzeAnzeigen
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
            this.lbl_mittelland = new System.Windows.Forms.Label();
            this.lbl_ebene = new System.Windows.Forms.Label();
            this.lbl_g1 = new System.Windows.Forms.Label();
            this.lbl_g2 = new System.Windows.Forms.Label();
            this.lbl_g3 = new System.Windows.Forms.Label();
            this.lbl_g4 = new System.Windows.Forms.Label();
            this.lbl_g5 = new System.Windows.Forms.Label();
            this.lbl_g6 = new System.Windows.Forms.Label();
            this.lbl_g7 = new System.Windows.Forms.Label();
            this.lbl_g8 = new System.Windows.Forms.Label();
            this.lbl_g9 = new System.Windows.Forms.Label();
            this.lbl_g10 = new System.Windows.Forms.Label();
            this.btn_finanzen = new FlatButton();
            this.btn_justiz = new FlatButton();
            this.btn_kirche = new FlatButton();
            this.SuspendLayout();
            // 
            // lbl_mittelland
            // 
            this.lbl_mittelland.AutoSize = true;
            this.lbl_mittelland.BackColor = System.Drawing.Color.Transparent;
            this.lbl_mittelland.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mittelland.ForeColor = System.Drawing.Color.Black;
            this.lbl_mittelland.Location = new System.Drawing.Point(65, 58);
            this.lbl_mittelland.Name = "lbl_mittelland";
            this.lbl_mittelland.Size = new System.Drawing.Size(289, 32);
            this.lbl_mittelland.TabIndex = 6;
            this.lbl_mittelland.Text = "Gesetze in Lottringen";
            this.lbl_mittelland.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gesetze_MouseDown);
            this.lbl_mittelland.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GesetzeAnzeigen_MouseMove);
            // 
            // lbl_ebene
            // 
            this.lbl_ebene.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ebene.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ebene.ForeColor = System.Drawing.Color.Black;
            this.lbl_ebene.Location = new System.Drawing.Point(21, 105);
            this.lbl_ebene.Name = "lbl_ebene";
            this.lbl_ebene.Size = new System.Drawing.Size(376, 26);
            this.lbl_ebene.TabIndex = 7;
            this.lbl_ebene.Text = "Finanzgesetze: Neutral";
            this.lbl_ebene.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ebene.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gesetze_MouseDown);
            this.lbl_ebene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GesetzeAnzeigen_MouseMove);
            // 
            // lbl_g1
            // 
            this.lbl_g1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g1.ForeColor = System.Drawing.Color.Black;
            this.lbl_g1.Location = new System.Drawing.Point(28, 142);
            this.lbl_g1.Name = "lbl_g1";
            this.lbl_g1.Size = new System.Drawing.Size(365, 26);
            this.lbl_g1.TabIndex = 8;
            this.lbl_g1.Text = "Finanzgesetze: Neutral";
            this.lbl_g1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseDown);
            this.lbl_g1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g2
            // 
            this.lbl_g2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g2.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g2.ForeColor = System.Drawing.Color.Black;
            this.lbl_g2.Location = new System.Drawing.Point(28, 168);
            this.lbl_g2.Name = "lbl_g2";
            this.lbl_g2.Size = new System.Drawing.Size(365, 26);
            this.lbl_g2.TabIndex = 9;
            this.lbl_g2.Text = "Finanzgesetze: Neutral";
            this.lbl_g2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g2_MouseDown);
            this.lbl_g2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g3
            // 
            this.lbl_g3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g3.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g3.ForeColor = System.Drawing.Color.Black;
            this.lbl_g3.Location = new System.Drawing.Point(28, 194);
            this.lbl_g3.Name = "lbl_g3";
            this.lbl_g3.Size = new System.Drawing.Size(365, 26);
            this.lbl_g3.TabIndex = 10;
            this.lbl_g3.Text = "Finanzgesetze: Neutral";
            this.lbl_g3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g3_MouseDown);
            this.lbl_g3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g4
            // 
            this.lbl_g4.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g4.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g4.ForeColor = System.Drawing.Color.Black;
            this.lbl_g4.Location = new System.Drawing.Point(28, 220);
            this.lbl_g4.Name = "lbl_g4";
            this.lbl_g4.Size = new System.Drawing.Size(365, 26);
            this.lbl_g4.TabIndex = 11;
            this.lbl_g4.Text = "Finanzgesetze: Neutral";
            this.lbl_g4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g4_MouseDown);
            this.lbl_g4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g5
            // 
            this.lbl_g5.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g5.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g5.ForeColor = System.Drawing.Color.Black;
            this.lbl_g5.Location = new System.Drawing.Point(28, 246);
            this.lbl_g5.Name = "lbl_g5";
            this.lbl_g5.Size = new System.Drawing.Size(365, 26);
            this.lbl_g5.TabIndex = 12;
            this.lbl_g5.Text = "Finanzgesetze: Neutral";
            this.lbl_g5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g5_MouseDown);
            this.lbl_g5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g6
            // 
            this.lbl_g6.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g6.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g6.ForeColor = System.Drawing.Color.Black;
            this.lbl_g6.Location = new System.Drawing.Point(28, 272);
            this.lbl_g6.Name = "lbl_g6";
            this.lbl_g6.Size = new System.Drawing.Size(365, 26);
            this.lbl_g6.TabIndex = 13;
            this.lbl_g6.Text = "Finanzgesetze: Neutral";
            this.lbl_g6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g6_MouseDown);
            this.lbl_g6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g7
            // 
            this.lbl_g7.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g7.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g7.ForeColor = System.Drawing.Color.Black;
            this.lbl_g7.Location = new System.Drawing.Point(28, 298);
            this.lbl_g7.Name = "lbl_g7";
            this.lbl_g7.Size = new System.Drawing.Size(365, 26);
            this.lbl_g7.TabIndex = 14;
            this.lbl_g7.Text = "Finanzgesetze: Neutral";
            this.lbl_g7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g7_MouseDown);
            this.lbl_g7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g8
            // 
            this.lbl_g8.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g8.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g8.ForeColor = System.Drawing.Color.Black;
            this.lbl_g8.Location = new System.Drawing.Point(28, 324);
            this.lbl_g8.Name = "lbl_g8";
            this.lbl_g8.Size = new System.Drawing.Size(365, 26);
            this.lbl_g8.TabIndex = 15;
            this.lbl_g8.Text = "Finanzgesetze: Neutral";
            this.lbl_g8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g8_MouseDown);
            this.lbl_g8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g9
            // 
            this.lbl_g9.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g9.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g9.ForeColor = System.Drawing.Color.Black;
            this.lbl_g9.Location = new System.Drawing.Point(28, 350);
            this.lbl_g9.Name = "lbl_g9";
            this.lbl_g9.Size = new System.Drawing.Size(365, 26);
            this.lbl_g9.TabIndex = 16;
            this.lbl_g9.Text = "Finanzgesetze: Neutral";
            this.lbl_g9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g9_MouseDown);
            this.lbl_g9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // lbl_g10
            // 
            this.lbl_g10.BackColor = System.Drawing.Color.Transparent;
            this.lbl_g10.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_g10.ForeColor = System.Drawing.Color.Black;
            this.lbl_g10.Location = new System.Drawing.Point(28, 376);
            this.lbl_g10.Name = "lbl_g10";
            this.lbl_g10.Size = new System.Drawing.Size(365, 26);
            this.lbl_g10.TabIndex = 17;
            this.lbl_g10.Text = "Finanzgesetze: Neutral";
            this.lbl_g10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_g10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_g10_MouseDown);
            this.lbl_g10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lbl_g1_MouseMove);
            // 
            // btn_finanzen
            // 
            this.btn_finanzen.BackColor = System.Drawing.Color.Transparent;
            this.btn_finanzen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_finanzen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_finanzen.Location = new System.Drawing.Point(66, 300);
            this.btn_finanzen.Margin = new System.Windows.Forms.Padding(0);
            this.btn_finanzen.Name = "btn_finanzen";
            this.btn_finanzen.Size = new System.Drawing.Size(62, 62);
            this.btn_finanzen.TabIndex = 18;
            this.btn_finanzen.UseVisualStyleBackColor = false;
            this.btn_finanzen.Click += new System.EventHandler(this.btn_finanzen_Click);
            this.btn_finanzen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gesetze_MouseDown);
            this.btn_finanzen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GesetzeAnzeigen_MouseMove);
            // 
            // btn_justiz
            // 
            this.btn_justiz.BackColor = System.Drawing.Color.Transparent;
            this.btn_justiz.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_justiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_justiz.Location = new System.Drawing.Point(177, 300);
            this.btn_justiz.Margin = new System.Windows.Forms.Padding(0);
            this.btn_justiz.Name = "btn_justiz";
            this.btn_justiz.Size = new System.Drawing.Size(62, 62);
            this.btn_justiz.TabIndex = 19;
            this.btn_justiz.UseVisualStyleBackColor = false;
            this.btn_justiz.Click += new System.EventHandler(this.btn_justiz_Click);
            this.btn_justiz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gesetze_MouseDown);
            this.btn_justiz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GesetzeAnzeigen_MouseMove);
            // 
            // btn_kirche
            // 
            this.btn_kirche.BackColor = System.Drawing.Color.Transparent;
            this.btn_kirche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_kirche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_kirche.Location = new System.Drawing.Point(292, 300);
            this.btn_kirche.Margin = new System.Windows.Forms.Padding(0);
            this.btn_kirche.Name = "btn_kirche";
            this.btn_kirche.Size = new System.Drawing.Size(62, 62);
            this.btn_kirche.TabIndex = 20;
            this.btn_kirche.UseVisualStyleBackColor = false;
            this.btn_kirche.Click += new System.EventHandler(this.btn_kirche_Click);
            this.btn_kirche.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gesetze_MouseDown);
            this.btn_kirche.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GesetzeAnzeigen_MouseMove);
            // 
            // GesetzeAnzeigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 416);
            this.Controls.Add(this.btn_kirche);
            this.Controls.Add(this.btn_justiz);
            this.Controls.Add(this.btn_finanzen);
            this.Controls.Add(this.lbl_g10);
            this.Controls.Add(this.lbl_g9);
            this.Controls.Add(this.lbl_g8);
            this.Controls.Add(this.lbl_g7);
            this.Controls.Add(this.lbl_g6);
            this.Controls.Add(this.lbl_g5);
            this.Controls.Add(this.lbl_g4);
            this.Controls.Add(this.lbl_g3);
            this.Controls.Add(this.lbl_g2);
            this.Controls.Add(this.lbl_g1);
            this.Controls.Add(this.lbl_ebene);
            this.Controls.Add(this.lbl_mittelland);
            this.Name = "GesetzeAnzeigen";
            this.Text = "Gesetze";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Gesetze_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GesetzeAnzeigen_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_mittelland;
        private System.Windows.Forms.Label lbl_ebene;
        private System.Windows.Forms.Label lbl_g1;
        private System.Windows.Forms.Label lbl_g2;
        private System.Windows.Forms.Label lbl_g3;
        private System.Windows.Forms.Label lbl_g4;
        private System.Windows.Forms.Label lbl_g5;
        private System.Windows.Forms.Label lbl_g6;
        private System.Windows.Forms.Label lbl_g7;
        private System.Windows.Forms.Label lbl_g8;
        private System.Windows.Forms.Label lbl_g9;
        private System.Windows.Forms.Label lbl_g10;
        private FlatButton btn_finanzen;
        private FlatButton btn_justiz;
        private FlatButton btn_kirche;
    }
}