using Conspiratio.Controls;

namespace Conspiratio
{
    partial class HausErweiterungen
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
            this.button_design_dummy = new CrystalButton();
            this.label_design_dummy = new System.Windows.Forms.Label();
            this.lbl_frage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_design_dummy
            // 
            this.button_design_dummy.BackColor = System.Drawing.Color.Transparent;
            this.button_design_dummy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_design_dummy.FlatAppearance.BorderSize = 0;
            this.button_design_dummy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_design_dummy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_design_dummy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_design_dummy.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_design_dummy.ForeColor = System.Drawing.Color.Black;
            this.button_design_dummy.Location = new System.Drawing.Point(55, 134);
            this.button_design_dummy.Margin = new System.Windows.Forms.Padding(0);
            this.button_design_dummy.Name = "button_design_dummy";
            this.button_design_dummy.Size = new System.Drawing.Size(20, 20);
            this.button_design_dummy.TabIndex = 223;
            this.button_design_dummy.UseVisualStyleBackColor = false;
            this.button_design_dummy.Visible = false;
            this.button_design_dummy.Click += new System.EventHandler(this.btnErweiterungBauen_Click);
            this.button_design_dummy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnErweiterungBauen_MouseDown);
            // 
            // label_design_dummy
            // 
            this.label_design_dummy.AutoSize = true;
            this.label_design_dummy.BackColor = System.Drawing.Color.Transparent;
            this.label_design_dummy.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_design_dummy.ForeColor = System.Drawing.Color.Black;
            this.label_design_dummy.Location = new System.Drawing.Point(87, 131);
            this.label_design_dummy.MaximumSize = new System.Drawing.Size(363, 0);
            this.label_design_dummy.Name = "label_design_dummy";
            this.label_design_dummy.Size = new System.Drawing.Size(162, 29);
            this.label_design_dummy.TabIndex = 225;
            this.label_design_dummy.Text = "Was wollt Ihr";
            this.label_design_dummy.Visible = false;
            this.label_design_dummy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnErweiterungBauen_MouseDown);
            // 
            // lbl_frage
            // 
            this.lbl_frage.AutoSize = true;
            this.lbl_frage.BackColor = System.Drawing.Color.Transparent;
            this.lbl_frage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_frage.ForeColor = System.Drawing.Color.Black;
            this.lbl_frage.Location = new System.Drawing.Point(50, 35);
            this.lbl_frage.MaximumSize = new System.Drawing.Size(510, 0);
            this.lbl_frage.Name = "lbl_frage";
            this.lbl_frage.Size = new System.Drawing.Size(485, 48);
            this.lbl_frage.TabIndex = 240;
            this.lbl_frage.Text = "Welche Erweiterung wollt Ihr an Eure prächtige Kate mit Garten anbauen?";
            this.lbl_frage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnErweiterungBauen_MouseDown);
            // 
            // HausErweiterungen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 550);
            this.Controls.Add(this.lbl_frage);
            this.Controls.Add(this.label_design_dummy);
            this.Controls.Add(this.button_design_dummy);
            this.Name = "HausErweiterungen";
            this.Text = "HausWaehlen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnErweiterungBauen_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CrystalButton button_design_dummy;
        private System.Windows.Forms.Label label_design_dummy;
        private System.Windows.Forms.Label lbl_frage;
    }
}