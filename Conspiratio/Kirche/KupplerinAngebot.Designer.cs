﻿using Conspiratio.Controls;

namespace Conspiratio
{
    partial class KupplerinAngebot
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
            this.lbl_text = new System.Windows.Forms.Label();
            this.btn_d2 = new CrystalButton();
            this.btn_d1 = new CrystalButton();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_text.Location = new System.Drawing.Point(48, 58);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(361, 215);
            this.lbl_text.TabIndex = 196;
            this.lbl_text.Text = "Derzeit sind keine Ämter zu besetzen, die Euren Fähigkeiten entsprechen";
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KupplerinAngebot_MouseDown);
            // 
            // btn_d2
            // 
            this.btn_d2.BackColor = System.Drawing.Color.Transparent;
            this.btn_d2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_d2.FlatAppearance.BorderSize = 0;
            this.btn_d2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_d2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_d2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_d2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_d2.ForeColor = System.Drawing.Color.Black;
            this.btn_d2.Location = new System.Drawing.Point(58, 299);
            this.btn_d2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_d2.Name = "btn_d2";
            this.btn_d2.Size = new System.Drawing.Size(20, 20);
            this.btn_d2.TabIndex = 200;
            this.btn_d2.UseVisualStyleBackColor = false;
            this.btn_d2.Click += new System.EventHandler(this.btn_d2_Click);
            this.btn_d2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KupplerinAngebot_MouseDown);
            // 
            // btn_d1
            // 
            this.btn_d1.BackColor = System.Drawing.Color.Transparent;
            this.btn_d1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_d1.FlatAppearance.BorderSize = 0;
            this.btn_d1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_d1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_d1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_d1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_d1.ForeColor = System.Drawing.Color.Black;
            this.btn_d1.Location = new System.Drawing.Point(58, 263);
            this.btn_d1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_d1.Name = "btn_d1";
            this.btn_d1.Size = new System.Drawing.Size(20, 20);
            this.btn_d1.TabIndex = 199;
            this.btn_d1.UseVisualStyleBackColor = false;
            this.btn_d1.Click += new System.EventHandler(this.btn_d1_Click);
            this.btn_d1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KupplerinAngebot_MouseDown);
            // 
            // lbl_2
            // 
            this.lbl_2.AutoSize = true;
            this.lbl_2.BackColor = System.Drawing.Color.Transparent;
            this.lbl_2.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_2.ForeColor = System.Drawing.Color.Black;
            this.lbl_2.Location = new System.Drawing.Point(80, 295);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(426, 24);
            this.lbl_2.TabIndex = 198;
            this.lbl_2.Text = "oder Euch einen anderen Partner suchen";
            this.lbl_2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KupplerinAngebot_MouseDown);
            // 
            // lbl_1
            // 
            this.lbl_1.AutoSize = true;
            this.lbl_1.BackColor = System.Drawing.Color.Transparent;
            this.lbl_1.Font = new System.Drawing.Font("Arial", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_1.ForeColor = System.Drawing.Color.Black;
            this.lbl_1.Location = new System.Drawing.Point(80, 261);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(281, 24);
            this.lbl_1.TabIndex = 197;
            this.lbl_1.Text = "mit der Werbung beginnen";
            this.lbl_1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KupplerinAngebot_MouseDown);
            // 
            // KupplerinAngebot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 391);
            this.Controls.Add(this.btn_d2);
            this.Controls.Add(this.btn_d1);
            this.Controls.Add(this.lbl_2);
            this.Controls.Add(this.lbl_1);
            this.Controls.Add(this.lbl_text);
            this.Name = "KupplerinAngebot";
            this.Text = "KupplerinAngebot";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.KupplerinAngebot_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_text;
        private CrystalButton btn_d2;
        private CrystalButton btn_d1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.Label lbl_1;
    }
}