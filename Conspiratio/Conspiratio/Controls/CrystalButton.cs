using System;
using System.Windows.Forms;

namespace Conspiratio.Controls
{
    public class CrystalButton: Button
    {
        private C_Musik _sounds = new C_Musik();
        private bool _checked = false;

        /// <summary>
        /// Gibt an, ob der Button eine Checkbox Funktion besitzt, ob der Button also den Status "an" und "aus" besitzen kann.
        /// </summary>
        public bool Checkbox { get; set; } = false;

        #region Konstruktor
        public CrystalButton()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeComponent
        void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CrystalButton
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Location = new System.Drawing.Point(50, 112);
            this.Margin = new Padding(0);
            this.Name = "CrystalButton";
            this.Size = new System.Drawing.Size(20, 20);
            this.TabIndex = 243;
            this.UseVisualStyleBackColor = false;
            this.Click += new EventHandler(this.CrystalButton_Click);
            this.BackgroundImage = Properties.Resources.SymbUnchecked;
            this.Tag = false;  // Checked-Status setzen
            this.ResumeLayout();
        }
        #endregion

        #region CrystalButton_Click
        private void CrystalButton_Click(object sender, EventArgs e)
        {
            if (Checkbox)
            {
                _sounds.PlaySound(Properties.Resources.checkbox_klick);
                Checked = !Checked;
            }
            else
                _sounds.PlaySound(Properties.Resources.bongo_dunkel);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Wenn die Eigenschaft "Checkbox" gesetzt ist, dann ist kann über die Eigenschaft "Checked" gesteuert oder abgefragt werden, ob der Button gesetzt ist (true) oder nicht (false).
        /// Der Status beeinflusst das Hintergrundbild des Buttons.
        /// </summary>
        public bool Checked
        {
            get { return _checked; }
            set {
                _checked = value;

                if (_checked)
                    this.BackgroundImage = Properties.Resources.SymbChecked;
                else
                    this.BackgroundImage = Properties.Resources.SymbUnchecked;
            }
        }
        #endregion
    }
}
