using Conspiratio.Controls;

namespace Conspiratio
{
    partial class ProzentwertFestlegenForm
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
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.btn_1 = new Conspiratio.NumericButton();
            this.lbl_kosten = new System.Windows.Forms.Label();
            this.lbl_auftrag = new System.Windows.Forms.Label();
            this.btn_auftrag = new Conspiratio.Controls.CrystalButton();
            this.SuspendLayout();
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.ForeColor = System.Drawing.Color.Black;
            this.lbl1.Location = new System.Drawing.Point(24, 38);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(358, 165);
            this.lbl1.TabIndex = 314;
            this.lbl1.Text = "Text...";
            this.lbl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl1_MouseDown);
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.BackColor = System.Drawing.Color.Transparent;
            this.lbl2.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.ForeColor = System.Drawing.Color.Black;
            this.lbl2.Location = new System.Drawing.Point(209, 218);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(163, 32);
            this.lbl2.TabIndex = 315;
            this.lbl2.Text = "% betragen";
            this.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl1_MouseDown);
            // 
            // btn_1
            // 
            this.btn_1.BackColor = System.Drawing.Color.Transparent;
            this.btn_1.FensterBeiRechtsklickSchliessen = false;
            this.btn_1.FlatAppearance.BorderSize = 0;
            this.btn_1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_1.ForeColor = System.Drawing.Color.Black;
            this.btn_1.Location = new System.Drawing.Point(115, 213);
            this.btn_1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_1.MaximalerWert = 999999999;
            this.btn_1.MaximaleStellen = 2;
            this.btn_1.MinimalerWert = 0;
            this.btn_1.Name = "btn_1";
            this.btn_1.NurEinserSchritte = false;
            this.btn_1.Size = new System.Drawing.Size(100, 42);
            this.btn_1.TabIndex = 316;
            this.btn_1.TausenderTrenner = false;
            this.btn_1.Text = "15";
            this.btn_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_1.UseVisualStyleBackColor = false;
            this.btn_1.Wert = 15;
            this.btn_1.WertAnzeigen = true;
            this.btn_1.Click += new System.EventHandler(this.btn_1_Click);
            // 
            // lbl_kosten
            // 
            this.lbl_kosten.AutoSize = true;
            this.lbl_kosten.BackColor = System.Drawing.Color.Transparent;
            this.lbl_kosten.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_kosten.ForeColor = System.Drawing.Color.Black;
            this.lbl_kosten.Location = new System.Drawing.Point(26, 266);
            this.lbl_kosten.Name = "lbl_kosten";
            this.lbl_kosten.Size = new System.Drawing.Size(282, 32);
            this.lbl_kosten.TabIndex = 317;
            this.lbl_kosten.Text = "Kosten: 10.000 Taler";
            this.lbl_kosten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_kosten.Visible = false;
            this.lbl_kosten.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl1_MouseDown);
            // 
            // lbl_auftrag
            // 
            this.lbl_auftrag.AutoSize = true;
            this.lbl_auftrag.BackColor = System.Drawing.Color.Transparent;
            this.lbl_auftrag.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_auftrag.ForeColor = System.Drawing.Color.Black;
            this.lbl_auftrag.Location = new System.Drawing.Point(61, 313);
            this.lbl_auftrag.Name = "lbl_auftrag";
            this.lbl_auftrag.Size = new System.Drawing.Size(233, 32);
            this.lbl_auftrag.TabIndex = 318;
            this.lbl_auftrag.Text = "In Auftrag geben";
            this.lbl_auftrag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_auftrag.Visible = false;
            this.lbl_auftrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl1_MouseDown);
            // 
            // btn_auftrag
            // 
            this.btn_auftrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_auftrag.BackColor = System.Drawing.Color.Transparent;
            this.btn_auftrag.BackgroundImage = global::Conspiratio.Properties.Resources.SymbUnchecked;
            this.btn_auftrag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_auftrag.Checkbox = false;
            this.btn_auftrag.Checked = false;
            this.btn_auftrag.FlatAppearance.BorderSize = 0;
            this.btn_auftrag.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_auftrag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_auftrag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_auftrag.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_auftrag.ForeColor = System.Drawing.Color.Black;
            this.btn_auftrag.Location = new System.Drawing.Point(35, 318);
            this.btn_auftrag.Margin = new System.Windows.Forms.Padding(0);
            this.btn_auftrag.Name = "btn_auftrag";
            this.btn_auftrag.Size = new System.Drawing.Size(20, 20);
            this.btn_auftrag.TabIndex = 319;
            this.btn_auftrag.Tag = false;
            this.btn_auftrag.UseVisualStyleBackColor = false;
            this.btn_auftrag.Visible = false;
            this.btn_auftrag.Click += new System.EventHandler(this.btn_auftrag_Click);
            this.btn_auftrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl1_MouseDown);
            // 
            // ProzentwertFestlegenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 380);
            this.Controls.Add(this.btn_auftrag);
            this.Controls.Add(this.lbl_auftrag);
            this.Controls.Add(this.lbl_kosten);
            this.Controls.Add(this.btn_1);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Name = "ProzentwertFestlegenForm";
            this.Text = "UmsatzsteuerFestlegenForm";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbl1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private NumericButton btn_1;
        private System.Windows.Forms.Label lbl_kosten;
        private System.Windows.Forms.Label lbl_auftrag;
        private CrystalButton btn_auftrag;
    }
}