using Conspiratio.Controls;

namespace Conspiratio
{
    partial class TippsAnzeigen
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
            this.btn_weiter = new LinkButton();
            this.btn_zurueck = new LinkButton();
            this.lbl_text = new System.Windows.Forms.Label();
            this.lbl_uebeschrift = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_weiter
            // 
            this.btn_weiter.AutoSize = true;
            this.btn_weiter.BackColor = System.Drawing.Color.Transparent;
            this.btn_weiter.FlatAppearance.BorderSize = 0;
            this.btn_weiter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_weiter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_weiter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_weiter.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_weiter.ForeColor = System.Drawing.Color.Black;
            this.btn_weiter.Location = new System.Drawing.Point(246, 302);
            this.btn_weiter.Margin = new System.Windows.Forms.Padding(0);
            this.btn_weiter.Name = "btn_weiter";
            this.btn_weiter.Size = new System.Drawing.Size(156, 42);
            this.btn_weiter.TabIndex = 257;
            this.btn_weiter.Text = "Weiter";
            this.btn_weiter.UseVisualStyleBackColor = false;
            this.btn_weiter.Click += new System.EventHandler(this.btn_weiter_Click);
            this.btn_weiter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_weiter_MouseDown);
            // 
            // btn_zurueck
            // 
            this.btn_zurueck.AutoSize = true;
            this.btn_zurueck.BackColor = System.Drawing.Color.Transparent;
            this.btn_zurueck.FlatAppearance.BorderSize = 0;
            this.btn_zurueck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_zurueck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_zurueck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_zurueck.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_zurueck.ForeColor = System.Drawing.Color.Black;
            this.btn_zurueck.Location = new System.Drawing.Point(57, 302);
            this.btn_zurueck.Margin = new System.Windows.Forms.Padding(0);
            this.btn_zurueck.Name = "btn_zurueck";
            this.btn_zurueck.Size = new System.Drawing.Size(156, 42);
            this.btn_zurueck.TabIndex = 258;
            this.btn_zurueck.Text = "Zurück";
            this.btn_zurueck.UseVisualStyleBackColor = false;
            this.btn_zurueck.Click += new System.EventHandler(this.btn_zurueck_Click);
            this.btn_zurueck.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_zurueck_MouseDown);
            // 
            // lbl_text
            // 
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_text.Location = new System.Drawing.Point(46, 81);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(372, 209);
            this.lbl_text.TabIndex = 260;
            this.lbl_text.Text = "j";
            this.lbl_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_text_MouseDown);
            // 
            // lbl_uebeschrift
            // 
            this.lbl_uebeschrift.AutoSize = true;
            this.lbl_uebeschrift.BackColor = System.Drawing.Color.Transparent;
            this.lbl_uebeschrift.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_uebeschrift.ForeColor = System.Drawing.Color.Black;
            this.lbl_uebeschrift.Location = new System.Drawing.Point(161, 21);
            this.lbl_uebeschrift.Name = "lbl_uebeschrift";
            this.lbl_uebeschrift.Size = new System.Drawing.Size(116, 34);
            this.lbl_uebeschrift.TabIndex = 261;
            this.lbl_uebeschrift.Text = "Tipp Nr";
            this.lbl_uebeschrift.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl_uebeschrift_MouseDown);
            // 
            // TippsAnzeigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 402);
            this.Controls.Add(this.lbl_uebeschrift);
            this.Controls.Add(this.lbl_text);
            this.Controls.Add(this.btn_zurueck);
            this.Controls.Add(this.btn_weiter);
            this.Name = "TippsAnzeigen";
            this.Text = "TippsAnzeigen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TippsAnzeigen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkButton btn_weiter;
        private LinkButton btn_zurueck;
        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label lbl_uebeschrift;
    }
}