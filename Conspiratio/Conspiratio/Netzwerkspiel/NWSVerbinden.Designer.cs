namespace Conspiratio
{
    partial class NWSVerbinden
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
            this.lbl_kreditb_0 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_verbinden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_kreditb_0
            // 
            this.lbl_kreditb_0.BackColor = System.Drawing.Color.Transparent;
            this.lbl_kreditb_0.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_kreditb_0.ForeColor = System.Drawing.Color.Black;
            this.lbl_kreditb_0.Location = new System.Drawing.Point(48, 32);
            this.lbl_kreditb_0.Name = "lbl_kreditb_0";
            this.lbl_kreditb_0.Size = new System.Drawing.Size(180, 36);
            this.lbl_kreditb_0.TabIndex = 181;
            this.lbl_kreditb_0.Text = "Server-IP";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(71, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 36);
            this.label1.TabIndex = 182;
            this.label1.Text = "Name";
            // 
            // txt_ip
            // 
            this.txt_ip.BackColor = System.Drawing.Color.White;
            this.txt_ip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ip.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_ip.ForeColor = System.Drawing.Color.Black;
            this.txt_ip.Location = new System.Drawing.Point(30, 71);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(221, 33);
            this.txt_ip.TabIndex = 229;
            this.txt_ip.Text = "10.0.0.190";
            // 
            // txt_name
            // 
            this.txt_name.BackColor = System.Drawing.Color.White;
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_name.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.txt_name.ForeColor = System.Drawing.Color.Black;
            this.txt_name.Location = new System.Drawing.Point(30, 174);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(221, 33);
            this.txt_name.TabIndex = 230;
            this.txt_name.Text = "Conspiratius";
            // 
            // btn_verbinden
            // 
            this.btn_verbinden.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_verbinden.AutoSize = true;
            this.btn_verbinden.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_verbinden.BackColor = System.Drawing.Color.Transparent;
            this.btn_verbinden.FlatAppearance.BorderSize = 0;
            this.btn_verbinden.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_verbinden.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_verbinden.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_verbinden.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_verbinden.ForeColor = System.Drawing.Color.Black;
            this.btn_verbinden.Location = new System.Drawing.Point(54, 236);
            this.btn_verbinden.Margin = new System.Windows.Forms.Padding(0);
            this.btn_verbinden.Name = "btn_verbinden";
            this.btn_verbinden.Size = new System.Drawing.Size(147, 41);
            this.btn_verbinden.TabIndex = 231;
            this.btn_verbinden.Text = "Verbinden";
            this.btn_verbinden.UseVisualStyleBackColor = false;
            this.btn_verbinden.Click += new System.EventHandler(this.btn_verbinden_Click);
            // 
            // NWSVerbinden
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 327);
            this.Controls.Add(this.btn_verbinden);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_kreditb_0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NWSVerbinden";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NWSpielVerbinden";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_kreditb_0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_verbinden;
    }
}