using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Spionage : frmBasis
    {
        int KIID;
        
        int Summe;
        bool bereitsAktiv;

        #region Konstruktor
        public Spionage(int ID, bool bA)
        {
            InitializeComponent();

            btn_d1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            lbl_1.Left = this.Width / 2 + lbl_1.Width / 2;
            lbl_2.Left = this.Width / 2 + lbl_2.Width / 2;

            KIID = ID;
            
            bereitsAktiv = bA;

            if (bereitsAktiv == false)
            {
                double Malfaktor = 0.02;

                Summe = Convert.ToInt32(SW.Dynamisch.GetSpWithID(KIID).GetTaler() * Malfaktor);

                if (Summe < 1000)
                    Summe = 1000;

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(20);
                lbl_text.Text = "In den nächsten Jahren werden Eure Spione " + SW.Dynamisch.GetSpWithID(KIID).GetName() + " überwachen und Euch von sämtlichen Verbrechen berichten. Die Spione verlangen dafür " + 
                                Summe.ToStringGeld() + ".";

                int id = ID;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(id).SetKosten(Summe);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(id).SetDauer(0);
            }
            else
            {
                lbl_text.Text = "Ihr habt bereits einige Spione auf " + SW.Dynamisch.GetSpWithID(KIID).GetName() + " angesetzt. Wollt Ihr diese";
                lbl_text.SendToBack();
                btn_d1.Visible = true;
                btn_d2.Visible = true;
                lbl_1.Visible = true;
                lbl_2.Visible = true;

                lbl_1.Left = this.Width / 2 - lbl_1.Width / 2;
                btn_d1.Left = lbl_1.Left - btn_d1.Width - 15;
                lbl_2.Left = lbl_1.Left;
                btn_d2.Left = btn_d1.Left;
            }
        }
        #endregion


        private void Spionage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_d2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_d1_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).AktiveSpionageEntfernen(KIID);

            SW.Dynamisch.BelTextAnzeigen("Ihr pfeift Eure Leute zurück...");
            this.Close();
        }
    }
}
