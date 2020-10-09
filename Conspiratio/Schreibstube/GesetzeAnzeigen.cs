using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class GesetzeAnzeigen : frmBasis
    {
        private int _gesetzesebene;
        // 0 = Finanzen
        //1 = Straf
        // 2 = Kirche

        private string[] _allgBewertung;

        private int _mouse_x;
        private int _mouse_y;

        #region Konstruktor
        public GesetzeAnzeigen()
        {
            InitializeComponent();

            this.Width += 100;
            lbl_mittelland.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            ControlZentrieren(lbl_mittelland, null, null);

            lbl_g1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g3.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g4.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g5.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g6.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g7.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g8.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g9.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g10.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_g1.AutoSize = true;
            lbl_g2.AutoSize = true;
            lbl_g3.AutoSize = true;
            lbl_g4.AutoSize = true;
            lbl_g5.AutoSize = true;
            lbl_g6.AutoSize = true;
            lbl_g7.AutoSize = true;
            lbl_g8.AutoSize = true;
            lbl_g9.AutoSize = true;
            lbl_g10.AutoSize = true;

            btn_finanzen.BackgroundImage = new Bitmap(Properties.Resources.SymbFinanzen);
            btn_justiz.BackgroundImage = new Bitmap(Properties.Resources.SymbJustiz);
            btn_kirche.BackgroundImage = new Bitmap(Properties.Resources.SymbKirche);

            ControlZentrieren(btn_justiz, null, null);
            ControlZentrieren(btn_finanzen, null, btn_justiz);
            ControlZentrieren(btn_kirche, btn_justiz, null);

            _gesetzesebene = 0;

            _allgBewertung = new string[5];
            _allgBewertung[0] = "sehr locker";
            _allgBewertung[1] = "locker";
            _allgBewertung[2] = "neutral";
            _allgBewertung[3] = "repressiv";
            _allgBewertung[4] = "sehr repressiv";

            EbenePositionieren(_gesetzesebene);
        }
        #endregion


        #region EbenePositionieren
        private void EbenePositionieren(int ebene)
        {
            int strenge = 0;
            string temp = "";

            if (ebene == 0)
            {
                strenge = SW.Dynamisch.GetGesetzX(0) + SW.Dynamisch.GetGesetzX(1) + Convert.ToInt32(SW.Dynamisch.GetGesetzX(2) / 10) + Convert.ToInt32(SW.Dynamisch.GetGesetzX(3) / 10) + SW.Dynamisch.GetGesetzX(4);
                temp = "Finanzgesetze: ";
            }
            if (ebene == 1)
            {
                strenge = SW.Dynamisch.GetGesetzX(20) + SW.Dynamisch.GetGesetzX(21) + SW.Dynamisch.GetGesetzX(22) + SW.Dynamisch.GetGesetzX(23) + SW.Dynamisch.GetGesetzX(24);
                temp = "Strafgesetze: ";
            }
            if (ebene == 2)
            {
                strenge = SW.Dynamisch.GetGesetzX(40) + SW.Dynamisch.GetGesetzX(41) + SW.Dynamisch.GetGesetzX(42) + SW.Dynamisch.GetGesetzX(43) + SW.Dynamisch.GetGesetzX(44);
                temp = "Kirchengesetze: ";
            }

            if (strenge < 2)
            {
                temp += _allgBewertung[0];
            }
            else if (strenge < 3)
            {
                temp += _allgBewertung[1];
            }
            else if (strenge < 4)
            {
                temp += _allgBewertung[2];
            }
            else if (strenge < 5)
            {
                temp += _allgBewertung[3];
            }
            else
            {
                temp += _allgBewertung[4];
            }

            lbl_ebene.Text = temp;
            ControlZentrieren(lbl_ebene, null, null);

            lbl_g1.Text = SW.Dynamisch.GetGesetzXinText(0 + ebene * 20);
            lbl_g2.Text = SW.Dynamisch.GetGesetzXinText(1 + ebene * 20);
            lbl_g3.Text = SW.Dynamisch.GetGesetzXinText(2 + ebene * 20);
            lbl_g4.Text = SW.Dynamisch.GetGesetzXinText(3 + ebene * 20);
            lbl_g5.Text = SW.Dynamisch.GetGesetzXinText(4 + ebene * 20);
            lbl_g6.Text = SW.Dynamisch.GetGesetzXinText(5 + ebene * 20);
            lbl_g7.Text = SW.Dynamisch.GetGesetzXinText(6 + ebene * 20);
            lbl_g8.Text = SW.Dynamisch.GetGesetzXinText(7 + ebene * 20);
            lbl_g9.Text = SW.Dynamisch.GetGesetzXinText(8 + ebene * 20);
            lbl_g10.Text = SW.Dynamisch.GetGesetzXinText(9 + ebene * 20);
            ControlZentrieren(lbl_g1, null, null);
            ControlZentrieren(lbl_g2, null, null);
            ControlZentrieren(lbl_g3, null, null);
            ControlZentrieren(lbl_g4, null, null);
            ControlZentrieren(lbl_g5, null, null);
            ControlZentrieren(lbl_g6, null, null);
            ControlZentrieren(lbl_g7, null, null);
            ControlZentrieren(lbl_g8, null, null);
            ControlZentrieren(lbl_g9, null, null);
            ControlZentrieren(lbl_g10, null, null);
        }
        #endregion

        private void ControlZentrieren(Control ParaC, Control ParaCLeft, Control ParaCRight)
        {
            if (ParaCLeft == null && ParaCRight == null)
            {
                ParaC.Left = (this.Width - ParaC.Width) / 2;
            }
            else if(ParaCLeft != null)
            {
                ParaC.Left = ParaCLeft.Right + (this.Width - ParaCLeft.Right - ParaC.Width) / 2;
            }
            else if(ParaCRight != null)
            {
                ParaC.Left = (ParaCRight.Left - ParaC.Width) / 2;
            }
            else
            {
                ParaC.Left = (ParaCRight.Left - ParaCLeft.Right - ParaC.Width) / 2;
            }
        }

        private void GesetzXaendern(int X, int plus)
        {
            if (_gesetzesebene == 0 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(25))
            {
                //Dann kann er die Finanzgesetze ändern
                SW.Dynamisch.GesetzXschaltenUmY(0 + X, plus);
            }

            if (_gesetzesebene == 1 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(26))
            {
                //Dann kann er die Strafgesetze ändern
                SW.Dynamisch.GesetzXschaltenUmY(SW.Statisch.GetGesetzgrenzeFinanz() + X, plus);
            }

            if (_gesetzesebene == 2 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(24))
            {
                //Dann kann er die Kirchengesetze  ändern
                SW.Dynamisch.GesetzXschaltenUmY(SW.Statisch.GetGesetzgrenzeStraf() + X, plus);
            }

            EbenePositionieren(_gesetzesebene);
        }

        private void CurPlusActive()
        {
            this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurPlus.ani");
        }

        private void CurMinusActive()
        {
            this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurMinus.ani");
        }

        #region Clicks
        private void btn_finanzen_Click(object sender, EventArgs e)
        {
            _gesetzesebene = 0;
            EbenePositionieren(_gesetzesebene);
        }

        private void btn_justiz_Click(object sender, EventArgs e)
        {
            _gesetzesebene = 1;
            EbenePositionieren(_gesetzesebene);
        }

        private void btn_kirche_Click(object sender, EventArgs e)
        {
            _gesetzesebene = 2;
            EbenePositionieren(_gesetzesebene);
        }
        #endregion

        #region Mousedowns
        private void Gesetze_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void lbl_g1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(0, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(1, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(2, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(3, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(4, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(5, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(6, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g8_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(7, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g9_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(8, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }

        private void lbl_g10_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int plus = -1;
                if (_mouse_y < lbl_g1.Height / 2)
                {
                    plus = 1;
                }
                GesetzXaendern(9, plus);
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.CloseMitSound();
            }
        }
        #endregion

        #region MouseMove
        private void lbl_g1_MouseMove(object sender, MouseEventArgs e)
        {
            _mouse_x = e.X;
            _mouse_y = e.Y;
            if (_gesetzesebene == 0 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(25))
            {
                if (_mouse_y >= lbl_g1.Height / 2)
                {
                    CurMinusActive();
                }
                else
                {
                    CurPlusActive();
                }
            }

            if (_gesetzesebene == 1 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(26))
            {
                if (_mouse_y >= lbl_g1.Height / 2)
                {
                    CurMinusActive();
                }
                else
                {
                    CurPlusActive();
                }
            }

            if (_gesetzesebene == 2 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(24))
            {
                if (_mouse_y >= lbl_g1.Height / 2)
                {
                    CurMinusActive();
                }
                else
                {
                    CurPlusActive();
                }
            }
        }

        private void GesetzeAnzeigen_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurSword.ani");
        }
        #endregion
    }
}
