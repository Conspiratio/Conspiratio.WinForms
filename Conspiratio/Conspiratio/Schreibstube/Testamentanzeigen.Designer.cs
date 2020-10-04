using Conspiratio.Controls;

namespace Conspiratio
{
    partial class Testamentanzeigen
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
            this.lbl_erblasser = new System.Windows.Forms.Label();
            this.btn_erbe = new Conspiratio.Controls.LinkButton();
            this.SuspendLayout();
            // 
            // lbl_text
            // 
            this.lbl_text.BackColor = System.Drawing.Color.Transparent;
            this.lbl_text.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text.ForeColor = System.Drawing.Color.Black;
            this.lbl_text.Location = new System.Drawing.Point(87, 75);
            this.lbl_text.Name = "lbl_text";
            this.lbl_text.Size = new System.Drawing.Size(357, 150);
            this.lbl_text.TabIndex = 196;
            this.lbl_text.Text = "jj";
            this.lbl_text.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Testamentanzeigen_MouseDown);
            // 
            // lbl_erblasser
            // 
            this.lbl_erblasser.BackColor = System.Drawing.Color.Transparent;
            this.lbl_erblasser.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_erblasser.ForeColor = System.Drawing.Color.Black;
            this.lbl_erblasser.Location = new System.Drawing.Point(268, 328);
            this.lbl_erblasser.Name = "lbl_erblasser";
            this.lbl_erblasser.Size = new System.Drawing.Size(176, 28);
            this.lbl_erblasser.TabIndex = 197;
            this.lbl_erblasser.Text = "jj";
            this.lbl_erblasser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Testamentanzeigen_MouseDown);
            // 
            // btn_erbe
            // 
            this.btn_erbe.AutoSize = true;
            this.btn_erbe.BackColor = System.Drawing.Color.Transparent;
            this.btn_erbe.FensterBeiRechtsklickSchliessen = false;
            this.btn_erbe.FlatAppearance.BorderSize = 0;
            this.btn_erbe.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_erbe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_erbe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_erbe.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_erbe.ForeColor = System.Drawing.Color.Black;
            this.btn_erbe.Location = new System.Drawing.Point(92, 241);
            this.btn_erbe.Margin = new System.Windows.Forms.Padding(0);
            this.btn_erbe.Name = "btn_erbe";
            this.btn_erbe.Size = new System.Drawing.Size(195, 41);
            this.btn_erbe.TabIndex = 198;
            this.btn_erbe.Text = "Kein Auftrag";
            this.btn_erbe.UseVisualStyleBackColor = false;
            this.btn_erbe.Click += new System.EventHandler(this.btn_erbe_Click);
            this.btn_erbe.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Testamentanzeigen_MouseDown);
            // 
            // Testamentanzeigen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 441);
            this.Controls.Add(this.btn_erbe);
            this.Controls.Add(this.lbl_erblasser);
            this.Controls.Add(this.lbl_text);
            this.Name = "Testamentanzeigen";
            this.Text = "Testamentanzeigen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Testamentanzeigen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_text;
        private System.Windows.Forms.Label lbl_erblasser;
        private LinkButton btn_erbe;
    }
}