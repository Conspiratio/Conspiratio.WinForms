using System;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Kampf;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class ProzentwertFestlegenForm : frmBasis, IProzentwertFestlegenDialog
    {
        #region Variablen

        ProzentwertArt ProzentwertArt;
        int ZielStuetzpunktIndex = 0;
        int AktuelleKosten = 0;

        #endregion

        /// <summary>
        /// Dient zur Initialisierung der Controls des Fensters.
        /// </summary>
        public ProzentwertFestlegenForm()
        {
            InitializeComponent();
        }


        #region ShowDialog
        /// <summary>
        /// Dient zum Anzeigen des Fensters als Dialog
        /// </summary>
        /// <param name="ProzentwertArt">Art des Prozentwertes</param>
        /// <param name="ZielStuetzpunktID">OPTIONAL: ID des Stützpunktes (z.B. Zollburg), auf den sich der Prozentwert bezieht</param>
        public void ShowDialog(ProzentwertArt prozentwertArt, int zielStuetzpunktID = 0)
        {
            ProzentwertArt = prozentwertArt;
            ZielStuetzpunktIndex = zielStuetzpunktID - 1;

            if (ProzentwertArt == ProzentwertArt.UmsatzsteuerStadt)
            {
                lbl1.Text = "Als Bürgermeister von " + SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetGebietsName() + " könnt Ihr die Umsatzsteuer festlegen. Die Umsatzsteuer soll";
                lbl2.Text = "% betragen";
                btn_1.Wert = Convert.ToInt32(SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetUmsatzsteuer() * 100);
                btn_1.MinimalerWert = Convert.ToInt32(SW.Statisch.GetMinUmsatzsteuer() * 100);
                btn_1.MaximalerWert = Convert.ToInt32(SW.Statisch.GetMaxUmsatzsteuer() * 100);
                btn_1.MaximaleStellen = 2;
                this.Height = 280;
            }
            else if ((ProzentwertArt == ProzentwertArt.ZollsatzZollburg) && (zielStuetzpunktID > 0))
            {
                lbl1.Text = "Als Besitzer von " + SW.Dynamisch.GetZollburgWithIDx(ZielStuetzpunktIndex).Name + " könnt Ihr den Zollsatz festlegen. Der Zollsatz soll";
                lbl2.Text = "% betragen";
                btn_1.Wert = Convert.ToInt32(SW.Dynamisch.GetZollburgWithIDx(ZielStuetzpunktIndex).Zoll * 100);
                btn_1.MinimalerWert = Convert.ToInt32(SW.Statisch.GetMinZollsatz() * 100);
                btn_1.MaximalerWert = Convert.ToInt32(SW.Statisch.GetMaxZollsatz() * 100);
                btn_1.MaximaleStellen = 2;
                this.Height = 280;
            }
            else if ((ProzentwertArt == ProzentwertArt.SicherheitTarnungStuetzpunkt) && (zielStuetzpunktID > 0))
            {
                lbl1.Text = "Verbessern: Auf welchen Wert wollt Ihr die " + SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungAlsString() + " von " + SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Name + " erhöhen? Sie soll";
                lbl2.Text = "% betragen";
                btn_1.Wert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungInProzent;
                btn_1.MinimalerWert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungInProzent;
                btn_1.MaximalerWert = 100;
                btn_1.MaximaleStellen = 3;
                lbl_kosten.Text = "Kosten: " + 0.ToStringGeld(); ;
                lbl_kosten.Visible = true;
                btn_auftrag.Visible = true;
                lbl_auftrag.Visible = true;
                this.Height = 380;
            }
            else if ((ProzentwertArt == ProzentwertArt.ZustandStuetzpunkt) && (zielStuetzpunktID > 0))
            {
                lbl1.Text = "Reparieren: Um welchen Wert wollt Ihr den Zustand von " + SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Name + " verbessern? Der Zustand soll";
                lbl2.Text = "% betragen";
                btn_1.Wert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].ZustandInProzent;
                btn_1.MinimalerWert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].ZustandInProzent;
                btn_1.MaximalerWert = 100;
                btn_1.MaximaleStellen = 3;
                lbl_kosten.Text = "Kosten: " + 0.ToStringGeld();
                lbl_kosten.Visible = true;
                btn_auftrag.Visible = true;
                lbl_auftrag.Visible = true;
                this.Height = 380;
            }
            else if ((ProzentwertArt == ProzentwertArt.KapazitaetStuetzpunkt) && (zielStuetzpunktID > 0))
            {
                string KapazitaetBezeichnung = "Unterkünfte";

                if (SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Art == EnumStuetzpunktArt.Zollburg)
                    KapazitaetBezeichnung = ((Zollburg)SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex]).KapazitaetBezeichnung;
                else if (SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Art == EnumStuetzpunktArt.Raeuberlager)
                    KapazitaetBezeichnung = ((Raeuberlager)SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex]).KapazitaetBezeichnung;

                lbl1.Text = $"Ausbauen: Um welche Anzahl wollt Ihr die {KapazitaetBezeichnung} von {SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Name} erweitern? Es soll insgesamt";
                lbl2.Text = "geben";
                btn_1.Wert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Kapazitaet;
                btn_1.MinimalerWert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Kapazitaet;
                btn_1.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].MaximaleKapazitaet;
                btn_1.MaximaleStellen = 3;
                lbl_kosten.Text = "Kosten: " + 0.ToStringGeld();
                lbl_kosten.Visible = true;
                btn_auftrag.Visible = true;
                lbl_auftrag.Visible = true;
                this.Height = 380;
            }

            ShowDialog();
        }
        #endregion

        #region btn_1_Click
        private void btn_1_Click(object sender, EventArgs e)
        {
            double dProzentwert = Convert.ToDouble(btn_1.Wert) / 100.0;

            if (ProzentwertArt == ProzentwertArt.UmsatzsteuerStadt)
                SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).SetUmsatzsteuerAufX(dProzentwert);
            else if (ProzentwertArt == ProzentwertArt.ZollsatzZollburg)
                SW.Dynamisch.GetZollburgWithIDx(ZielStuetzpunktIndex).Zoll = dProzentwert;
            else if (ProzentwertArt == ProzentwertArt.SicherheitTarnungStuetzpunkt)
            {
                if (btn_1.Wert > SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungInProzent)
                {
                    int ErhoehungInProzent = btn_1.Wert - SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungInProzent;
                    AktuelleKosten = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].BerechneKostenSicherheitTarnung(ErhoehungInProzent);
                }
                else
                    AktuelleKosten = 0;

                lbl_kosten.Text = "Kosten: " + AktuelleKosten.ToStringGeld();
            }
            else if (ProzentwertArt == ProzentwertArt.ZustandStuetzpunkt)
            {
                if (btn_1.Wert > SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].ZustandInProzent)
                {
                    int ErhoehungInProzent = btn_1.Wert - SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].ZustandInProzent;
                    AktuelleKosten = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].BerechneKostenZustand(ErhoehungInProzent);
                }
                else
                    AktuelleKosten = 0;

                lbl_kosten.Text = "Kosten: " + AktuelleKosten.ToStringGeld();
            }
            else if (ProzentwertArt == ProzentwertArt.KapazitaetStuetzpunkt)
            {
                if (btn_1.Wert > SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Kapazitaet)
                {
                    int Erhoehung = btn_1.Wert - SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Kapazitaet;
                    AktuelleKosten = SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].BerechneKostenKapazitaet(Erhoehung);
                }
                else
                    AktuelleKosten = 0;

                lbl_kosten.Text = "Kosten: " + AktuelleKosten.ToStringGeld();
            }
        }
        #endregion

        #region lbl1_MouseDown
        private void lbl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
        #endregion

        #region btn_auftrag_Click
        private void btn_auftrag_Click(object sender, EventArgs e)
        {
            if (AktuelleKosten <= 0)
                return;

            if (!SW.Dynamisch.CheckIfenoughGold(AktuelleKosten))
                return;

            if (ProzentwertArt == ProzentwertArt.SicherheitTarnungStuetzpunkt)
            {
                SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungInProzent = btn_1.Wert;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-AktuelleKosten);
                SW.Dynamisch.BelTextAnzeigen("Eure Investition hat sich bezahlt gemacht und die " + SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].SicherheitTarnungAlsString() + " von " +
                                   SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Name + " hat sich auf " + btn_1.Wert + " % erhöht.");
                Close();
            }
            else if (ProzentwertArt == ProzentwertArt.ZustandStuetzpunkt)
            {
                SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].ZustandInProzent = btn_1.Wert;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-AktuelleKosten);
                SW.Dynamisch.BelTextAnzeigen("Lasst die Handwerker kommen! Der Zustand von " + SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Name +
                                   " hat sich aufgrund Eurer Renovierungsarbeiten auf " + btn_1.Wert + " % erhöht.");
                Close();
            }
            else if (ProzentwertArt == ProzentwertArt.KapazitaetStuetzpunkt)
            {
                SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Kapazitaet = btn_1.Wert;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-AktuelleKosten);
                SW.Dynamisch.BelTextAnzeigen("Lasst die Arbeiter kommen! Die Kapazität von " + SW.Dynamisch.GetStuetzpunkte()[ZielStuetzpunktIndex].Name +
                                   " hat sich aufgrund Eurer Bauarbeiten auf " + btn_1.Wert + " erhöht.");
                Close();
            }
        }
        #endregion
    }
}