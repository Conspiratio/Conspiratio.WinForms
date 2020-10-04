using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio.Kampf
{
    public partial class frmSoeldnerRaeuberKarte : frmBasis
    {
        #region Variablen

        private C_Musik _sounds = new C_Musik();

        int switch_case = 0;
        int vorige_switch_case = 0;

        int s1_left, s1_right, s1_top, s1_bottom;
        int s2_left, s2_right, s2_top, s2_bottom;
        int s3_left, s3_right, s3_top, s3_bottom;
        int s4_left, s4_right, s4_top, s4_bottom;
        int s5_left, s5_right, s5_top, s5_bottom;
        int s6_left, s6_right, s6_top, s6_bottom;
        int s7_left, s7_right, s7_top, s7_bottom;
        int s8_left, s8_right, s8_top, s8_bottom;

        Rectangle rect_s1;
        Rectangle rect_s2;
        Rectangle rect_s3;
        Rectangle rect_s4;
        Rectangle rect_s5;
        Rectangle rect_s6;
        Rectangle rect_s7;
        Rectangle rect_s8;
        
        #endregion

        #region Konstruktor
        public frmSoeldnerRaeuberKarte()
        {
            InitializeComponent();

            s1_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(1, 0), this.Width);
            s1_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(1, 1), this.Width);
            s1_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(1, 2), this.Height);
            s1_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(1, 3), this.Height);

            s2_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(2, 0), this.Width);
            s2_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(2, 1), this.Width);
            s2_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(2, 2), this.Height);
            s2_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(2, 3), this.Height);

            s3_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(3, 0), this.Width);
            s3_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(3, 1), this.Width);
            s3_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(3, 2), this.Height);
            s3_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(3, 3), this.Height);

            s4_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(4, 0), this.Width);
            s4_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(4, 1), this.Width);
            s4_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(4, 2), this.Height);
            s4_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(4, 3), this.Height);

            s5_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(5, 0), this.Width);
            s5_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(5, 1), this.Width);
            s5_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(5, 2), this.Height);
            s5_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(5, 3), this.Height);

            s6_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(6, 0), this.Width);
            s6_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(6, 1), this.Width);
            s6_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(6, 2), this.Height);
            s6_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(6, 3), this.Height);

            s7_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(7, 0), this.Width);
            s7_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(7, 1), this.Width);
            s7_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(7, 2), this.Height);
            s7_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(7, 3), this.Height);

            s8_left   = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(8, 0), this.Width);
            s8_right  = UI.NormB(SW.Statisch.GetStuetzpunktRechteck(8, 1), this.Width);
            s8_top    = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(8, 2), this.Height);
            s8_bottom = UI.NormH(SW.Statisch.GetStuetzpunktRechteck(8, 3), this.Height);

            rect_s1 = new Rectangle(s1_left, s1_top, s1_right - s1_left, s1_bottom - s1_top);
            rect_s2 = new Rectangle(s2_left, s2_top, s2_right - s2_left, s2_bottom - s2_top);
            rect_s3 = new Rectangle(s3_left, s3_top, s3_right - s3_left, s3_bottom - s3_top);
            rect_s4 = new Rectangle(s4_left, s4_top, s4_right - s4_left, s4_bottom - s4_top);
            rect_s5 = new Rectangle(s5_left, s5_top, s5_right - s5_left, s5_bottom - s5_top);
            rect_s6 = new Rectangle(s6_left, s6_top, s6_right - s6_left, s6_bottom - s6_top);
            rect_s7 = new Rectangle(s7_left, s7_top, s7_right - s7_left, s7_bottom - s7_top);
            rect_s8 = new Rectangle(s8_left, s8_top, s8_right - s8_left, s8_bottom - s8_top);

            // Platzhalter Icons positionieren
            stuetzpunkt_platzhalter1.Left = s3_left + 45;
            stuetzpunkt_platzhalter1.Top = s3_top + 30;

            stuetzpunkt_platzhalter2.Left = s5_left + 40;
            stuetzpunkt_platzhalter2.Top = s5_top + 30;

            stuetzpunkt_platzhalter3.Left = s6_left + 40;
            stuetzpunkt_platzhalter3.Top = s6_top + 30;

            stuetzpunkt_platzhalter4.Left = s7_left + 40;
            stuetzpunkt_platzhalter4.Top = s7_top + 30;

            stuetzpunkt_platzhalter5.Left = s8_left + 30;
            stuetzpunkt_platzhalter5.Top = s8_top + 23;

            StuetzpunktFlaggenEinblenden();
        }
        #endregion

        #region Private Funktionen

        #region frmSoeldnerRaeuberKarte_MouseDown
        private void frmSoeldnerRaeuberKarte_MouseDown(object sender, MouseEventArgs e)
        {
            // Für Debugging
            //if (e.Button == MouseButtons.Left)
            //    SW.Dynamisch.BelTextAnzeigen("X: " + UI.NormB(e.X, this.Width).ToString() + Environment.NewLine + "Y: " + UI.NormH(e.Y, this.Height).ToString());

            if (e.Button == MouseButtons.Right)
            {
                CloseMitSound();
            }
            else if ((e.Button == MouseButtons.Left) && (switch_case > 0))
            {
                _sounds.PlaySound(Properties.Resources.bongo_dunkel);

                if (SW.Dynamisch.GetStuetzpunkte()[switch_case - 1].Besitzer == SW.Dynamisch.GetAktiverSpieler())
                {
                    frmStuetzpunktVerwalten StuetzpunktVerwalten = new frmStuetzpunktVerwalten(switch_case);
                    StuetzpunktVerwalten.ShowDialog();
                }
                else
                {
                    frmStuetzpunktKaufen StuetzpunktKaufen = new frmStuetzpunktKaufen(switch_case);
                    StuetzpunktKaufen.ShowDialog();
                    StuetzpunktFlaggenEinblenden();
                }
            }
        }
        #endregion

        #region frmSoeldnerRaeuberKarte_Paint
        private void frmSoeldnerRaeuberKarte_Paint(object sender, PaintEventArgs e)
        {
            switch (switch_case)
            {
                case 1:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s1);
                    break;
                case 2:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s2);
                    break;
                case 3:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s3);
                    break;
                case 4:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s4);
                    break;
                case 5:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s5);
                    break;
                case 6:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s6);
                    break;
                case 7:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s7);
                    break;
                case 8:
                    e.Graphics.DrawRectangle(Pens.Gold, rect_s8);
                    break;
                default:
                    break;
            }

            if (vorige_switch_case != switch_case)
            {
                vorige_switch_case = switch_case;
                Invalidate();
            }
        }
        #endregion

        #region frmSoeldnerRaeuberKarte_MouseMove
        private void frmSoeldnerRaeuberKarte_MouseMove(object sender, MouseEventArgs e)
        {
            this.Focus();

            switch_case = 0;

            // Stützpunkt 1
            if (e.X > s1_left && e.X < s1_right && e.Y > s1_top && e.Y < s1_bottom)
            {
                switch_case = 1;
            }
            // Stützpunkt 2
            else if (e.X > s2_left && e.X < s2_right && e.Y > s2_top && e.Y < s2_bottom)
            {
                switch_case = 2;
            }
            // Stützpunkt 3
            else if (e.X > s3_left && e.X < s3_right && e.Y > s3_top && e.Y < s3_bottom)
            {
                switch_case = 3;
            }
            // Stützpunkt 4
            else if (e.X > s4_left && e.X < s4_right && e.Y > s4_top && e.Y < s4_bottom)
            {
                switch_case = 4;
            }
            // Stützpunkt 5
            else if (e.X > s5_left && e.X < s5_right && e.Y > s5_top && e.Y < s5_bottom)
            {
                switch_case = 5;
            }
            // Stützpunkt 6
            else if (e.X > s6_left && e.X < s6_right && e.Y > s6_top && e.Y < s6_bottom)
            {
                switch_case = 6;
            }
            // Stützpunkt 7
            else if (e.X > s7_left && e.X < s7_right && e.Y > s7_top && e.Y < s7_bottom)
            {
                switch_case = 7;
            }
            // Stützpunkt 8
            else if (e.X > s8_left && e.X < s8_right && e.Y > s8_top && e.Y < s8_bottom)
            {
                switch_case = 8;
            }

            if (vorige_switch_case != switch_case)
            {
                vorige_switch_case = switch_case;
                Invalidate();
            }
        }
        #endregion

        #region StuetzpunktFlaggenEinblenden
        private void StuetzpunktFlaggenEinblenden()
        {
            pictureBox1.Top = s1_top;
            pictureBox2.Top = s2_top;
            pictureBox3.Top = s3_top;
            pictureBox4.Top = s4_top;
            pictureBox5.Top = s5_top;
            pictureBox6.Top = s6_top;
            pictureBox7.Top = s7_top;
            pictureBox8.Top = s8_top;

            pictureBox1.Left = s1_right + 3;
            pictureBox2.Left = s2_right + 3;
            pictureBox3.Left = s3_right + 3;
            pictureBox4.Left = s4_right + 3;
            pictureBox5.Left = s5_right + 3;
            pictureBox6.Left = s6_right + 3;
            pictureBox7.Left = s7_right + 3;
            pictureBox8.Left = s8_right + 3;

            pictureBox1.Width = 25;
            pictureBox2.Width = pictureBox1.Width;
            pictureBox3.Width = pictureBox1.Width;
            pictureBox4.Width = pictureBox1.Width;
            pictureBox5.Width = pictureBox1.Width;
            pictureBox6.Width = pictureBox1.Width;
            pictureBox7.Width = pictureBox1.Width;
            pictureBox8.Width = pictureBox1.Width;

            pictureBox1.Height = 35;
            pictureBox2.Height = pictureBox1.Height;
            pictureBox3.Height = pictureBox1.Height;
            pictureBox4.Height = pictureBox1.Height;
            pictureBox5.Height = pictureBox1.Height;
            pictureBox6.Height = pictureBox1.Height;
            pictureBox7.Height = pictureBox1.Height;
            pictureBox8.Height = pictureBox1.Height;

            //Flaggen einblenden
            for (int i = 1; i <= SW.Dynamisch.GetStuetzpunkte().Length; i++)
            {
                this.Controls["pictureBox" + i.ToString()].Visible = false;

                // Wenn der Stützpunkt einem menschlichen Spieler gehört, soll die Flagge angezeigt werden
                if (SW.Dynamisch.GetStuetzpunkte()[i - 1].Besitzer < SW.Statisch.GetMinKIID())
                {
                    Grafik.SwitchBanner("pictureBox" + i.ToString(), SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetStuetzpunkte()[i - 1].Besitzer).GetBanner(), this);
                    this.Controls["pictureBox" + i.ToString()].Visible = true;
                    this.Controls["pictureBox" + i.ToString()].BringToFront();
                }
            }
        }
        #endregion

        #endregion
    }
}
