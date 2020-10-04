using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Bestechen : frmBasis
    {
        #region Globale Variablen
        int SPID;

        #endregion

        #region Konstruktor
        public Bestechen(int ID)
        {
            InitializeComponent();

            btn_bestechen.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_abbrechen.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);

            SPID = ID;
            
            lbl_header.Text = "Bestechen";
            lbl_header.Left = (this.Width - lbl_header.Width) / 2;

            lbl_text.Text = "Gebt an wieviel Taler Ihr " + SW.Dynamisch.GetSpWithID(ID).GetName() + " zukommen lassen wollt.";
            btn_Taler.MaximalerWert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler();
        }
        #endregion


        #region Buttons, Mousedown,...
        private void btn_abbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_bestechen_Click(object sender, EventArgs e)
        {
            int wert = btn_Taler.Wert;

            if (wert > 0)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiBestechungssumme += wert;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiBestechungen++;

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-wert);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheBestechungVonSpielerMitIDXUmY(SPID, wert);

                //wenns verboten ist...
                if (SW.Dynamisch.GetGesetzX(1) != 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(1);
                }

                SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetSpWithID(SPID).GetName() + " wird Eure Taler erhalten.");

                this.Close();
            }
        }

        private void lbl_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.Close();
            }
        }        

        private void Bestechen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_taler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void lbl_header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
        #endregion      

        private void btn_bestechen_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurSword.ani");
        }

        private void btn_abbrechen_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurSword.ani");
        }
    }
}
