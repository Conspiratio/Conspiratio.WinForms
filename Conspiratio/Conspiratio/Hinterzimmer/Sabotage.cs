using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Sabotage : frmBasis
    {
        #region Globale Variablen
        int OpferID;
        
        int SaboKosten;
        int Jahre;
        bool bereitsAktiv;
        #endregion

        #region Konstruktor
        public Sabotage(int ID, bool bA)
        {
            InitializeComponent();

            btn_d1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            bereitsAktiv = bA;
            OpferID = ID;
            
            if (bereitsAktiv == false)
            {
                double Malfaktor = 0.04;

                SaboKosten = Convert.ToInt32(SW.Dynamisch.GetSpWithID(OpferID).GetGesamtVermoegen(OpferID) * Malfaktor);

                if (SaboKosten < 1000)
                    SaboKosten = 1000;

                Jahre = 5;
                string sNamensSuffix = "s";

                if (SW.Dynamisch.GetSpWithID(OpferID).GetName().EndsWith("s"))
                    sNamensSuffix = "'";

                lbl_text.Text = "Einige zwielichtige Gestalten bieten Euch an, " + Jahre.ToString() + " Jahre für jeweils " + SaboKosten.ToStringGeld() + " zu versuchen, " + SW.Dynamisch.GetSpWithID(OpferID).GetName() + sNamensSuffix + " Besitzungen mit Unheil zu überziehen. Wollt Ihr";
            }
            else
            {
                lbl_text.Text = "Ihr habt bereits einige Gesetzlose mit dem Auftrag betraut, " + SW.Dynamisch.GetSpWithID(OpferID).GetName() + " Ärger zu bereiten. Wollt Ihr Eure Leute ";
                lbl_1.Text = "zurückpfeifen";
                lbl_2.Text = "oder weitermachen lassen?";
            }
        }
        #endregion


        #region Buttons, Mousedown
        private void btn_d2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_d1_Click(object sender, EventArgs e)
        {
            if (bereitsAktiv == false)
            {
                //Dauer setzen
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(OpferID).SetDauer(Jahre);
                //Kosten setzen
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(OpferID).SetKosten(SaboKosten);

                //Wenns verboten ist
                if (SW.Dynamisch.GetGesetzX(21) != 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(21);
                }

                SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetSpWithID(OpferID).GetName() + " wird Ärger bekommen...");
                this.Close();
            }
            else
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).AktiveSabotageEntfernen(OpferID);

                SW.Dynamisch.BelTextAnzeigen("Ihr pfeift Eure Leute zurück...");
                this.Close();
            }
        }

        private void Sabotage_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
        #endregion
    }
}
