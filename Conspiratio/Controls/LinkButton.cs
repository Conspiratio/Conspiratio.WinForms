using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Musik;

namespace Conspiratio.Controls
{
    public class LinkButton : Button
    {
        #region Variablen

        private MusicAndSoundPlayer _sounds = new MusicAndSoundPlayer();
        private Color _standardForeColor = Color.Black;
        private bool _fensterBeiRechtsklickSchliessen = false;

        #endregion

        #region Konstruktor
        public LinkButton()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeComponent
        void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LinkButton
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Arial", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "LinkButton";
            this.Size = new System.Drawing.Size(100, 40);
            this.Text = "LinkButton";
            this.UseVisualStyleBackColor = false;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LinkButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.LinkButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.LinkButton_MouseLeave);
            this.ResumeLayout();
        }
        #endregion


        #region LinkButton_MouseDown
        private void LinkButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.Parent is Form && _fensterBeiRechtsklickSchliessen)
                {
                    _sounds.PlaySound(Properties.Resources.bongo_hell);
                    (this.Parent as Form).Close();
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                _sounds.PlaySound(Properties.Resources.bongo_dunkel);
            }
        }
        #endregion

        #region LinkButton_MouseEnter
        private void LinkButton_MouseEnter(object sender, EventArgs e)
        {
            if (this.ForeColor != Color.Red)
                _standardForeColor = this.ForeColor;

            this.ForeColor = Color.Red;
        }
        #endregion

        #region LinkButton_MouseLeave
        private void LinkButton_MouseLeave(object sender, EventArgs e)
        {
            this.ForeColor = _standardForeColor;
        }
        #endregion

        #region Properties

        public bool FensterBeiRechtsklickSchliessen
        {
            get { return _fensterBeiRechtsklickSchliessen; }
            set { _fensterBeiRechtsklickSchliessen = value; }
        }

        #endregion
    }
}