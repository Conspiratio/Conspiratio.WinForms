using System;
using System.Windows.Forms;

namespace Conspiratio.Controls
{
    public class FlatButton: Button
    {
        private C_Musik _sounds = new C_Musik();

        #region Konstruktor
        public FlatButton()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeComponent
        void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FlatButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Popup;
            this.Font = new System.Drawing.Font("Arial", 20.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(48, 97);
            this.Name = "FlatButton";
            this.Size = new System.Drawing.Size(224, 42);
            this.TabIndex = 228;
            this.Text = "";
            this.UseVisualStyleBackColor = false;
            this.Click += new EventHandler(this.FlatButton_Click);
            this.ResumeLayout();
        }
        #endregion

        #region FlatButton_Click
        private void FlatButton_Click(object sender, EventArgs e)
        {
            _sounds.PlaySound(Properties.Resources.bongo_dunkel);
        }
        #endregion
    }
}
