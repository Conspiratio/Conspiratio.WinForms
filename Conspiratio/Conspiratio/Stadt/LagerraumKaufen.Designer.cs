using Conspiratio.Controls;

namespace Conspiratio
{
    partial class LagerraumKaufen
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
            this.lbl_nachrichten_titel = new System.Windows.Forms.Label();
            this.txt_lg = new System.Windows.Forms.Label();
            this.btn_lg1 = new Conspiratio.Controls.LinkButton();
            this.btn_lg2 = new Conspiratio.Controls.LinkButton();
            this.btn_lg3 = new Conspiratio.Controls.LinkButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_p1 = new System.Windows.Forms.Label();
            this.lbl_p2 = new System.Windows.Forms.Label();
            this.lbl_p3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_nachrichten_titel
            // 
            this.lbl_nachrichten_titel.AutoSize = true;
            this.lbl_nachrichten_titel.BackColor = System.Drawing.Color.Transparent;
            this.lbl_nachrichten_titel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nachrichten_titel.ForeColor = System.Drawing.Color.Black;
            this.lbl_nachrichten_titel.Location = new System.Drawing.Point(12, 34);
            this.lbl_nachrichten_titel.Name = "lbl_nachrichten_titel";
            this.lbl_nachrichten_titel.Size = new System.Drawing.Size(284, 29);
            this.lbl_nachrichten_titel.TabIndex = 168;
            this.lbl_nachrichten_titel.Text = "Verfügbarer Lagerraum:";
            this.lbl_nachrichten_titel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_nachrichten_titel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // txt_lg
            // 
            this.txt_lg.AutoSize = true;
            this.txt_lg.BackColor = System.Drawing.Color.Transparent;
            this.txt_lg.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_lg.ForeColor = System.Drawing.Color.Black;
            this.txt_lg.Location = new System.Drawing.Point(230, 62);
            this.txt_lg.Name = "txt_lg";
            this.txt_lg.Size = new System.Drawing.Size(39, 29);
            this.txt_lg.TabIndex = 169;
            this.txt_lg.Text = "30";
            this.txt_lg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txt_lg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // btn_lg1
            // 
            this.btn_lg1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_lg1.AutoSize = true;
            this.btn_lg1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_lg1.BackColor = System.Drawing.Color.Transparent;
            this.btn_lg1.FensterBeiRechtsklickSchliessen = false;
            this.btn_lg1.FlatAppearance.BorderSize = 0;
            this.btn_lg1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_lg1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_lg1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lg1.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lg1.ForeColor = System.Drawing.Color.Black;
            this.btn_lg1.Location = new System.Drawing.Point(104, 160);
            this.btn_lg1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_lg1.Name = "btn_lg1";
            this.btn_lg1.Size = new System.Drawing.Size(59, 38);
            this.btn_lg1.TabIndex = 170;
            this.btn_lg1.Text = "but";
            this.btn_lg1.UseVisualStyleBackColor = false;
            this.btn_lg1.Click += new System.EventHandler(this.btn_lg1_Click);
            this.btn_lg1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // btn_lg2
            // 
            this.btn_lg2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_lg2.AutoSize = true;
            this.btn_lg2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_lg2.BackColor = System.Drawing.Color.Transparent;
            this.btn_lg2.FensterBeiRechtsklickSchliessen = false;
            this.btn_lg2.FlatAppearance.BorderSize = 0;
            this.btn_lg2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_lg2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_lg2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lg2.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lg2.ForeColor = System.Drawing.Color.Black;
            this.btn_lg2.Location = new System.Drawing.Point(104, 198);
            this.btn_lg2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_lg2.Name = "btn_lg2";
            this.btn_lg2.Size = new System.Drawing.Size(59, 38);
            this.btn_lg2.TabIndex = 171;
            this.btn_lg2.Text = "but";
            this.btn_lg2.UseVisualStyleBackColor = false;
            this.btn_lg2.Click += new System.EventHandler(this.btn_lg2_Click);
            this.btn_lg2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // btn_lg3
            // 
            this.btn_lg3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_lg3.AutoSize = true;
            this.btn_lg3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_lg3.BackColor = System.Drawing.Color.Transparent;
            this.btn_lg3.FensterBeiRechtsklickSchliessen = false;
            this.btn_lg3.FlatAppearance.BorderSize = 0;
            this.btn_lg3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_lg3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_lg3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lg3.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_lg3.ForeColor = System.Drawing.Color.Black;
            this.btn_lg3.Location = new System.Drawing.Point(104, 236);
            this.btn_lg3.Margin = new System.Windows.Forms.Padding(0);
            this.btn_lg3.Name = "btn_lg3";
            this.btn_lg3.Size = new System.Drawing.Size(59, 38);
            this.btn_lg3.TabIndex = 172;
            this.btn_lg3.Text = "but";
            this.btn_lg3.UseVisualStyleBackColor = false;
            this.btn_lg3.Click += new System.EventHandler(this.btn_lg3_Click);
            this.btn_lg3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 29);
            this.label1.TabIndex = 173;
            this.label1.Text = "Erweitern um:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // lbl_p1
            // 
            this.lbl_p1.AutoSize = true;
            this.lbl_p1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_p1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p1.ForeColor = System.Drawing.Color.Black;
            this.lbl_p1.Location = new System.Drawing.Point(224, 165);
            this.lbl_p1.Name = "lbl_p1";
            this.lbl_p1.Size = new System.Drawing.Size(39, 29);
            this.lbl_p1.TabIndex = 174;
            this.lbl_p1.Text = "30";
            this.lbl_p1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_p1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // lbl_p2
            // 
            this.lbl_p2.AutoSize = true;
            this.lbl_p2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_p2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p2.ForeColor = System.Drawing.Color.Black;
            this.lbl_p2.Location = new System.Drawing.Point(224, 203);
            this.lbl_p2.Name = "lbl_p2";
            this.lbl_p2.Size = new System.Drawing.Size(39, 29);
            this.lbl_p2.TabIndex = 175;
            this.lbl_p2.Text = "30";
            this.lbl_p2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_p2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // lbl_p3
            // 
            this.lbl_p3.AutoSize = true;
            this.lbl_p3.BackColor = System.Drawing.Color.Transparent;
            this.lbl_p3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_p3.ForeColor = System.Drawing.Color.Black;
            this.lbl_p3.Location = new System.Drawing.Point(224, 241);
            this.lbl_p3.Name = "lbl_p3";
            this.lbl_p3.Size = new System.Drawing.Size(39, 29);
            this.lbl_p3.TabIndex = 176;
            this.lbl_p3.Text = "30";
            this.lbl_p3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_p3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            // 
            // LagerraumKaufen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 316);
            this.Controls.Add(this.lbl_p3);
            this.Controls.Add(this.lbl_p2);
            this.Controls.Add(this.lbl_p1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_lg3);
            this.Controls.Add(this.btn_lg2);
            this.Controls.Add(this.btn_lg1);
            this.Controls.Add(this.txt_lg);
            this.Controls.Add(this.lbl_nachrichten_titel);
            this.Name = "LagerraumKaufen";
            this.Text = "LagerraumKaufen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LagerraumKaufen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_nachrichten_titel;
        private System.Windows.Forms.Label txt_lg;
        private LinkButton btn_lg1;
        private LinkButton btn_lg2;
        private LinkButton btn_lg3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_p1;
        private System.Windows.Forms.Label lbl_p2;
        private System.Windows.Forms.Label lbl_p3;
    }
}