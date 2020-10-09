namespace Conspiratio
{
    partial class NetzwerkspielStarten
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txb_namenEingeben = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.btn_beitreten = new System.Windows.Forms.Button();
            this.btn_hosten = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(133, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 34);
            this.label1.TabIndex = 229;
            this.label1.Text = "Netzwerkspiel";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetzwerkspielStarten_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(54, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 28);
            this.label4.TabIndex = 238;
            this.label4.Text = "Name:";
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetzwerkspielStarten_MouseDown);
            // 
            // txb_namenEingeben
            // 
            this.txb_namenEingeben.BackColor = System.Drawing.Color.White;
            this.txb_namenEingeben.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_namenEingeben.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_namenEingeben.ForeColor = System.Drawing.Color.Black;
            this.txb_namenEingeben.Location = new System.Drawing.Point(214, 97);
            this.txb_namenEingeben.Name = "txb_namenEingeben";
            this.txb_namenEingeben.Size = new System.Drawing.Size(190, 30);
            this.txb_namenEingeben.TabIndex = 237;
            this.txb_namenEingeben.Text = "Tester";
            this.txb_namenEingeben.TextChanged += new System.EventHandler(this.txb_namenEingeben_TextChanged);
            this.txb_namenEingeben.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetzwerkspielStarten_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(54, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 28);
            this.label2.TabIndex = 239;
            this.label2.Text = "Server-IP:";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetzwerkspielStarten_MouseDown);
            // 
            // txt_ip
            // 
            this.txt_ip.BackColor = System.Drawing.Color.White;
            this.txt_ip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ip.Font = new System.Drawing.Font("Arial", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ip.ForeColor = System.Drawing.Color.Black;
            this.txt_ip.Location = new System.Drawing.Point(214, 147);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(190, 30);
            this.txt_ip.TabIndex = 240;
            this.txt_ip.Text = "10.0.0.139";
            this.txt_ip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetzwerkspielStarten_MouseDown);
            // 
            // btn_beitreten
            // 
            this.btn_beitreten.BackColor = System.Drawing.Color.Transparent;
            this.btn_beitreten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_beitreten.FlatAppearance.BorderSize = 0;
            this.btn_beitreten.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_beitreten.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_beitreten.Location = new System.Drawing.Point(238, 201);
            this.btn_beitreten.Name = "btn_beitreten";
            this.btn_beitreten.Size = new System.Drawing.Size(166, 42);
            this.btn_beitreten.TabIndex = 244;
            this.btn_beitreten.Text = "beitreten";
            this.btn_beitreten.UseVisualStyleBackColor = false;
            this.btn_beitreten.Click += new System.EventHandler(this.btn_beitreten_Click);
            this.btn_beitreten.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_c_aus_MouseDown);
            // 
            // btn_hosten
            // 
            this.btn_hosten.BackColor = System.Drawing.Color.Transparent;
            this.btn_hosten.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_hosten.FlatAppearance.BorderSize = 0;
            this.btn_hosten.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_hosten.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_hosten.Location = new System.Drawing.Point(59, 201);
            this.btn_hosten.Name = "btn_hosten";
            this.btn_hosten.Size = new System.Drawing.Size(156, 42);
            this.btn_hosten.TabIndex = 243;
            this.btn_hosten.Text = "hosten";
            this.btn_hosten.UseVisualStyleBackColor = false;
            this.btn_hosten.Click += new System.EventHandler(this.btn_hosten_Click);
            this.btn_hosten.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_c_an_MouseDown);
            // 
            // NetzwerkspielStarten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(471, 286);
            this.Controls.Add(this.btn_beitreten);
            this.Controls.Add(this.btn_hosten);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txb_namenEingeben);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NetzwerkspielStarten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetzwerkspielStarten";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NetzwerkspielStarten_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txb_namenEingeben;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Button btn_beitreten;
        private System.Windows.Forms.Button btn_hosten;
    }
}