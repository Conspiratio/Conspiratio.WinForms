using System;
using System.Drawing;
using System.Windows.Forms;

namespace Conspiratio
{
    public class NumericButton : Button
    {
        #region Private Variablen

        private int iMouse_x;
        private int iMouse_y;

        private int iWert = 0;
        private int iMaximalerWert = 999999999;
        private int iMinimalerWert = 0;
        private int iMaximaleStellen = 9;

        private bool bTausenderTrenner = true;
        private bool bNurEinserSchritte = false;
        private bool bWertAnzeigen = true;
        private bool bFensterBeiRechtsklickSchliessen = false;

        private Color StandardForeColor = Color.Black;

        #endregion


        #region Konstruktor NumericButton
        public NumericButton()
        {
            InitializeComponent();
        }
        #endregion

        #region InitializeComponent
        void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // NumericButton
            // 
            this.BackColor = Color.Transparent;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Arial", 15.75F, (FontStyle.Bold | FontStyle.Italic));
            this.ForeColor = Color.Black;
            this.Name = "NumericInput";
            this.Size = new Size(146, 40);
            this.Wert = iWert;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.UseVisualStyleBackColor = false;
            this.Click += new EventHandler(this.NumericButton_Click);
            this.MouseDown += new MouseEventHandler(this.NumericButton_MouseDown);
            this.MouseEnter += new EventHandler(this.NumericButton_MouseEnter);
            this.MouseLeave += new EventHandler(this.NumericButton_MouseLeave);
            this.MouseMove += new MouseEventHandler(this.NumericButton_MouseMove);
            this.ResumeLayout(false);
        }
        #endregion

        #region NumericButton_Click
        private void NumericButton_Click(object sender, System.EventArgs e)
        {
            int erhoehen = 1;

            if (iMouse_y > this.Height / 2)
            {
                erhoehen *= -1;
            }

            if (!bNurEinserSchritte)
            {
                if (iMouse_x < 137)
                {
                    if (iMouse_x < 25 && iWert >= 10)
                    {
                        erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 1));  // Bei 9 Stellen: 100000000
                    }
                    else if (iMouse_x < 25 + (this.Font.Size - 2))   // 37
                    {

                        if ((iMaximaleStellen - 2) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 2));  // Bei 9 Stellen: 10000000
                        }
                    }
                    else if (iMouse_x < 25 + ((this.Font.Size - 2) * 2))   // 50
                    {
                        if ((iMaximaleStellen - 3) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 3));  // Bei 9 Stellen: 1000000
                        }
                    }
                    else if (iMouse_x < 25 + ((this.Font.Size - 2) * 3))   // 68
                    {
                        if ((iMaximaleStellen - 4) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 4));  // Bei 9 Stellen: 100000
                        }
                    }
                    else if (iMouse_x < 25 + ((this.Font.Size - 2) * 4))  // 80
                    {
                        if ((iMaximaleStellen - 5) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 5));  // Bei 9 Stellen: 10000
                        }
                    }
                    else if (iMouse_x < 25 + ((this.Font.Size - 2) * 5))  // 94
                    {
                        if ((iMaximaleStellen - 6) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 6));  // Bei 9 Stellen: 1000
                        }
                    }
                    else if (iMouse_x < 25 + ((this.Font.Size - 2) * 6))  // 112
                    {
                        if ((iMaximaleStellen - 7) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 7));  // Bei 9 Stellen: 100
                        }
                    }
                    else if (iMouse_x < 25 + ((this.Font.Size - 2) * 7))  // 124
                    {
                        if ((iMaximaleStellen - 8) > 0)
                        {
                            erhoehen *= Convert.ToInt32(Math.Pow(10, iMaximaleStellen - 8));  // Bei 9 Stellen: 10
                        }
                    }
                }
            }

            int erg = erhoehen + iWert;

            this.Wert = erg;
        }
        #endregion

        #region NumericButton_MouseMove
        private void NumericButton_MouseMove(object sender, MouseEventArgs e)
        {
            iMouse_x = e.X;
            iMouse_y = e.Y;

            if (iMouse_y > this.Height / 2)
            {
                this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurMinus.ani");
            }
            else
            {
                this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurPlus.ani");
            }
        }
        #endregion

        #region NumericButton_MouseDown
        private void NumericButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (this.Parent is Form && bFensterBeiRechtsklickSchliessen)
                {
                    (this.Parent as Form).Close();
                }
            }
        }
        #endregion

        #region NumericButton_MouseEnter
        private void NumericButton_MouseEnter(object sender, EventArgs e)
        {
            if (this.ForeColor != Color.Red)
                StandardForeColor = this.ForeColor;

            this.ForeColor = Color.Red;
        }
        #endregion

        #region NumericButton_MouseLeave
        private void NumericButton_MouseLeave(object sender, EventArgs e)
        {
            this.ForeColor = StandardForeColor;
        }
        #endregion


        #region Properties

        public int Wert
        {
            get { return iWert; }
            set
            {
                iWert = value;

                if (iWert < 0)
                {
                    iWert = 0;
                }

                if (iWert > iMaximalerWert)
                {
                    iWert = iMaximalerWert;
                }
                    
                if (iWert < iMinimalerWert)
                {
                    iWert = iMinimalerWert;
                }

                if (bWertAnzeigen)
                {
                    string sWert = iWert.ToString();

                    if (bTausenderTrenner)
                    {
                        // Mit Nullen auffüllen bis zur maximalen Länge
                        while (sWert.Length < iMaximaleStellen)
                        {
                            sWert = "0" + sWert;
                        }

                        // Tausender Punkte setzen
                        if (sWert.Length > 3)
                        {
                            if (sWert.Length > 6)
                            {
                                sWert = sWert.Substring(0, sWert.Length - 6) + "." + sWert.Substring(sWert.Length - 6, 3) + "." + sWert.Substring(sWert.Length - 3, 3);
                            }
                            else
                            {
                                sWert = sWert.Substring(0, sWert.Length - 3) + "." + sWert.Substring(sWert.Length - 3, 3);
                            }
                        }
                    }

                    this.Text = sWert;
                }
            }
        }

        public int MaximaleStellen
        {
            get { return iMaximaleStellen; }
            set
            {
                iMaximaleStellen = value;
                Wert = iWert;
            }
        }

        public int MaximalerWert
        {
            get { return iMaximalerWert; }
            set
            {
                iMaximalerWert = value;

                if (iWert > iMaximalerWert)
                {
                    Wert = iMaximalerWert;
                }
                else
                {
                    Wert = iWert;
                }
            }
        }

        public int MinimalerWert
        {
            get { return iMinimalerWert; }
            set
            {
                iMinimalerWert = value;

                if (iWert < iMinimalerWert)
                {
                    Wert = iMinimalerWert;
                }
                else
                {
                    Wert = iWert;
                }
            }
        }

        public bool TausenderTrenner
        {
            get { return bTausenderTrenner; }
            set
            {
                bTausenderTrenner = value;
                Wert = iWert;
            }
        }

        public bool NurEinserSchritte
        {
            get { return bNurEinserSchritte; }
            set { bNurEinserSchritte = value; }
        }

        public bool WertAnzeigen
        {
            get { return bWertAnzeigen; }
            set
            {
                bWertAnzeigen = value;

                if (bWertAnzeigen)
                    Wert = iWert;
            }
        }

        public bool FensterBeiRechtsklickSchliessen
        {
            get { return bFensterBeiRechtsklickSchliessen; }
            set { bFensterBeiRechtsklickSchliessen = value; }
        }

        #endregion
    }
}
