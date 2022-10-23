using Conspiratio.Controls;

namespace Conspiratio
{
    partial class RohstoffWaehlen
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
            this.components = new System.ComponentModel.Container();
            this.btn_roh1 = new FlatButton();
            this.btn_roh2 = new FlatButton();
            this.ttRohstoffe = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btn_roh1
            // 
            this.btn_roh1.BackColor = System.Drawing.Color.Transparent;
            this.btn_roh1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_roh1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_roh1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_roh1.ForeColor = System.Drawing.Color.Transparent;
            this.btn_roh1.Location = new System.Drawing.Point(43, 59);
            this.btn_roh1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_roh1.Name = "btn_roh1";
            this.btn_roh1.Size = new System.Drawing.Size(80, 80);
            this.btn_roh1.TabIndex = 205;
            this.btn_roh1.UseVisualStyleBackColor = false;
            this.btn_roh1.Click += new System.EventHandler(this.btn_roh1_Click);
            this.btn_roh1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RohstoffWaehlen_MouseDown);
            // 
            // btn_roh2
            // 
            this.btn_roh2.BackColor = System.Drawing.Color.Transparent;
            this.btn_roh2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_roh2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gold;
            this.btn_roh2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_roh2.ForeColor = System.Drawing.Color.Transparent;
            this.btn_roh2.Location = new System.Drawing.Point(152, 59);
            this.btn_roh2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_roh2.Name = "btn_roh2";
            this.btn_roh2.Size = new System.Drawing.Size(80, 80);
            this.btn_roh2.TabIndex = 206;
            this.btn_roh2.UseVisualStyleBackColor = false;
            this.btn_roh2.Click += new System.EventHandler(this.btn_roh2_Click);
            this.btn_roh2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RohstoffWaehlen_MouseDown);
            // 
            // ttRohstoffe
            // 
            this.ttRohstoffe.IsBalloon = true;
            // 
            // RohstoffWaehlen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 195);
            this.Controls.Add(this.btn_roh2);
            this.Controls.Add(this.btn_roh1);
            this.Name = "RohstoffWaehlen";
            this.Text = "RohstoffWaehlen";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RohstoffWaehlen_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatButton btn_roh1;
        private FlatButton btn_roh2;
        private System.Windows.Forms.ToolTip ttRohstoffe;
    }
}