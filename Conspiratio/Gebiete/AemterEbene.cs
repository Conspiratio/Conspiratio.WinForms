using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class AemterEbene : frmBasis
    {
        //Modus = In welchem Modus wird die Karte geoeffnet
        //0 = Beziehungen
        //1 = Sabotage
        //2 = Anschwärzen
        //3 = Spione
        //4 = Ermordung
        //5 = Erpressung
        //6 = Stadt auswaehlen
        //7 = Ehepartner waehlen
        //8 = Prozess initiieren
        //9 = Händler
        //10 = Kaufmann
        //11 = Merchant
        //12 = VergifteterWein

        #region Globale Variablen
        Graphics g;
        int ObjektID;
        int AktuelleEbene;
        string[] modeText = new string[20];

        int Stufe;
        //Stufen sind Grafschaft, Fürstentum, Königreich
        //Grafschaft = 0
        //Fürstentum = 1
        //Königreich = 2

        string[] Ebenentext = new string[4];

        int linkeAusrichtungslinie;
        int rechteAusrichtungslinie;
        int halblinkeAusrichtungslinie;
        int halbrechteAusrichtungslinie;

        int modus;

        #endregion

        #region Konstruktor: 1
        public AemterEbene(int oID, int mod, int stuf)
        {
            InitializeComponent();

            this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintAemter);

            Initialisieren(oID, mod, stuf);
        }
        #endregion


        #region Initialisieren
        private void Initialisieren(int oID, int mod, int stuf)
        {
            btn_wechsel.Left = (this.Width - btn_wechsel.Width) / 2;

            pct_sabo1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);
            pct_sabo2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);
            pct_sabo3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);
            pct_sabo4.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);
            pct_sabo5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);
            pct_sabo6.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);
            pct_sabo7.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbSabotage);

            pct_spio1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);
            pct_spio2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);
            pct_spio3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);
            pct_spio4.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);
            pct_spio5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);
            pct_spio6.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);
            pct_spio7.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Symbspionage);

            pct_ehe1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);
            pct_ehe2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);
            pct_ehe3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);
            pct_ehe4.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);
            pct_ehe5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);
            pct_ehe6.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);
            pct_ehe7.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);

            pct_eheringe.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbVerheiratet);

            //pct_krone1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Krone);
            //pct_krone2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Krone);

            modus = mod;

            
            modeText[0] = "Beziehungen pflegen in ";
            modeText[1] = "Sabotage in ";
            modeText[2] = "Anschwärzen in ";
            modeText[3] = "Spionage in ";
            modeText[4] = "Ermordung in ";
            modeText[5] = "Erpressung in ";
            modeText[7] = "Partnerwahl in ";
            modeText[8] = "Prozess initiieren in ";
            modeText[9] = "Händler in ";
            modeText[10] = "Kaufmann in ";
            modeText[11] = "Merchant in ";
            modeText[12] = "Wein vergiften in ";

            ObjektID = oID;
            Stufe = stuf;

            AktuelleEbene = 0;

            Ebenentext[0] = "Politische Ebene";
            Ebenentext[1] = "Kirchliche Ebene";
            Ebenentext[2] = "Militärische Ebene";
            Ebenentext[3] = "Grafschaft";

            btn_titel.Text = modeText[modus] + SW.Dynamisch.GetGebietwithID(ObjektID, Stufe).GetGebietsName();


            if (SpE.getAnschwaerzID() != 0)
            {
                btn_titel.Text = SW.Dynamisch.GetSpWithID(SpE.getAnschwaerzID()).GetName() + " anschwärzen bei...";
            }

            btn_titel.Left = (this.Width - btn_titel.Width) / 2;

            pct_krone1.Left = btn_titel.Left - pct_krone1.Width - 8;
            pct_krone2.Left = btn_titel.Left + btn_titel.Width + 8;

            btn_titel.Visible = true;
            btn_wechsel.Visible = true;

            linkeAusrichtungslinie = this.Width / 5;
            rechteAusrichtungslinie = this.Width / 5 * 4;

            halblinkeAusrichtungslinie = this.Width / 3;
            halbrechteAusrichtungslinie = this.Width / 3 * 2;

            pct_eheringe.SendToBack();

            AemterButtonsPositionieren(AktuelleEbene);
        }
        #endregion

        #region AemterEbene_MouseDown
        private void AemterEbene_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SpE.setIntKurzSpeicher(0);
                this.CloseMitSound();
            }
        }
        #endregion

        #region Paint
        private void AemterEbene_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            int temp;

            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    //Bürgermeister
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetBuergermeister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetBuergermeister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Baumeister
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetBaumeister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetBaumeister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Richter
                    if(SW.Dynamisch.GetStadtwithID(ObjektID).GetRichter() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetRichter()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                    g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //Kämmerer
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetKaemmerer() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetKaemmerer()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //Ratsherr1
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }

                    //Ratsherr2
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt6.Top + btn_amt6.Height, temp, 10);
                    }

                    //Ratsherr3
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr3() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr3()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt7.Top + btn_amt7.Height, temp, 10);
                    }
                }
                else if (Stufe == 1)
                {
                    //Vogt
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetVogt() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetVogt()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Justizberater
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetJustizberater() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetJustizberater()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Finanzberater
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetFinanzberater() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetFinanzberater()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //Geheimrat1
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //Geheimrat2
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }

                    //Geheimrat3
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat3() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat3()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt6.Top + btn_amt6.Height, temp, 10);
                    }
                }
                else if (Stufe == 2)
                {
                    //Regent
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetRegent() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetRegent()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Justizminister
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetJustizminister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetJustizminister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Finanzminister
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetFinanzminister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetFinanzminister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //Hofrat1
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //Hofrat2
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }

                    //Hofrat3
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat3() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat3()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt6.Top + btn_amt6.Height, temp, 10);
                    }
                }
            }
            if (AktuelleEbene == 1)
            {
                if (Stufe == 0)
                {
                    //Domherr
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetDomherr() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetDomherr()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Priester1
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Priester2
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }
                }
                else if (Stufe == 1)
                {
                    //Bischof
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetBischof() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetBischof()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Abt
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetAbt() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetAbt()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Diakon
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetDiakon() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetDiakon()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //Kellermeister
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetKellermeister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetKellermeister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //Sakristan
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetSakristan() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetSakristan()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }
                }
                else if (Stufe == 2)
                {
                    //Erzbischof
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetErzbischof() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetErzbischof()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Inquisitor
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetInquisitor() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetInquisitor()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Erzdiakon
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetErzdiakon() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetErzdiakon()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }
                }
            }
            if (AktuelleEbene == 2)
            {
                if (Stufe == 0)
                {
                    //Stadtkommandant
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtkommandant() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtkommandant()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Wachkommandant1
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetWachkommandant() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetWachkommandant()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Wachkommandant2
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetKerkermeister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetKerkermeister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //Stadtwache1
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtwache() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtwache()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //Stadtwache2
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetFolterknecht() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetFolterknecht()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }

                    //Stadtwache3
                    if (SW.Dynamisch.GetStadtwithID(ObjektID).GetHenker() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(ObjektID).GetHenker()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt6.Top + btn_amt6.Height, temp, 10);
                    }
                }
                else if (Stufe == 1)
                {
                    //Hauptmann
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetHauptmann() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetHauptmann()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //KommandantderKavallerie1
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetBefehlshaber() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetBefehlshaber()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //KommandantderKavallerie2
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetZollmeister() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetZollmeister()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //KommandantderInfantrie1
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetStellvertretenderBefehlshaber() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetStellvertretenderBefehlshaber()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //KommandantderInfantrie2
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }

                    //KommandantderInfantrie3
                    if (SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt6.Top + btn_amt6.Height, temp, 10);
                    }
                }
                else if (Stufe == 2)
                {
                    //Marschall
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetFeldmarschall() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetFeldmarschall()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt1.Top + btn_amt1.Height, temp, 10);
                    }

                    //Armeekommandant1
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halblinkeAusrichtungslinie - (temp / 2), btn_amt2.Top + btn_amt2.Height, temp, 10);
                    }

                    //Armeekommandant2
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, halbrechteAusrichtungslinie - (temp / 2), btn_amt3.Top + btn_amt3.Height, temp, 10);
                    }

                    //Ritter1
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier1() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier1()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, linkeAusrichtungslinie - (temp / 2), btn_amt4.Top + btn_amt4.Height, temp, 10);
                    }

                    //Ritter2
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier2() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier2()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, (this.Width - temp) / 2, btn_amt5.Top + btn_amt5.Height, temp, 10);
                    }

                    //Ritter3
                    if (SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier3() >= SW.Statisch.GetMinKIID())
                    {
                        temp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier3()).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        g.FillRectangle(Brushes.Black, rechteAusrichtungslinie - (temp / 2), btn_amt6.Top + btn_amt6.Height, temp, 10);
                    }
                }
            }

            if (AktuelleEbene == 3)
            {
                g.FillRectangle(Brushes.Black, btn_amt1.Left + btn_amt1.Width / 2, btn_amt1.Top + btn_amt1.Height, 6, 50);
                g.FillRectangle(Brushes.Black, btn_amt2.Left + btn_amt2.Width / 2, btn_amt2.Top + btn_amt2.Height, 6, 50);
                g.FillRectangle(Brushes.Black, btn_amt1.Left + btn_amt1.Width / 2, btn_amt1.Top + btn_amt1.Height + 50, btn_amt2.Left + btn_amt2.Width - btn_amt1.Left - btn_amt1.Width - 3, 6);
                g.FillRectangle(Brushes.Black, this.Width / 2 - 3, btn_amt1.Top + btn_amt1.Height + 50, 5, 65);
            }
        }
        #endregion

        #region Button-Wechsel
        private void btn_wechsel_Click(object sender, EventArgs e)
        {
            // 0 = politische Ebene
            // 1 = kirchliche Ebene
            // 2 = militärische Ebene
            // 3 = Grafschaft

            AktuelleEbene++;
            if (AktuelleEbene >= 3)
            {
                AktuelleEbene = 0;
            }

            btn_wechsel.Text = Ebenentext[AktuelleEbene];
            btn_wechsel.Left = (this.Width - btn_wechsel.Width) / 2;

            AemterButtonsPositionieren(AktuelleEbene);
        }
        #endregion

        #region SaboSymbsZeigen
        public void SaboSymbsZeigen(int id, int pctnr)
        {
            this.Controls["pct_sabo" + pctnr.ToString()].Top = this.Controls["btn_amt" + pctnr.ToString()].Top + 5;
            this.Controls["pct_sabo" + pctnr.ToString()].Left = this.Controls["btn_amt" + pctnr.ToString()].Left - this.Controls["pct_sabo" + pctnr.ToString()].Width + 4;

            if (SW.Dynamisch.GetAktHum().GetAktiveSabotage(id).GetDauer() > 0)
            {
                this.Controls["pct_sabo" + pctnr.ToString()].Visible = true;
            }
        }
        #endregion

        #region SpioSymbsZeigen
        public void SpioSymbsZeigen(int id, int pctnr)
        {
            this.Controls["pct_spio" + pctnr.ToString()].Top = this.Controls["btn_amt" + pctnr.ToString()].Top + 5;
            this.Controls["pct_spio" + pctnr.ToString()].Left = this.Controls["btn_amt" + pctnr.ToString()].Left + this.Controls["btn_amt" + pctnr.ToString()].Width;

            if (SW.Dynamisch.GetAktHum().GetAktiveSpionage(id).GetKosten() > 0)
            {
                this.Controls["pct_spio" + pctnr.ToString()].Visible = true;
            }
        }
        #endregion

        #region EheSymbsZeigen
        public void EheSymbsZeigen(int id, int pctnr)
        {
            if (SW.Dynamisch.GetSpWithID(id).GetVerheiratet() != 0)
            {
                this.Controls["pct_ehe" + pctnr.ToString()].Top = this.Controls["btn_amt" + pctnr.ToString()].Top + this.Controls["btn_amt" + pctnr.ToString()].Height - this.Controls["pct_ehe" + pctnr.ToString()].Height - 5;
                this.Controls["pct_ehe" + pctnr.ToString()].Left = this.Controls["btn_amt" + pctnr.ToString()].Left + this.Controls["btn_amt" + pctnr.ToString()].Width;
                this.Controls["pct_ehe" + pctnr.ToString()].Visible = true;
            }
        }
        #endregion

        #region RelSymbsZeigen

        public void RelSymbsZeigen(int id, int pctnr)
        {
            this.Controls["pct_rel" + pctnr.ToString()].Top = this.Controls["pct_sabo" + pctnr.ToString()].Top + this.Controls["pct_sabo" + pctnr.ToString()].Height + 10;
            this.Controls["pct_rel" + pctnr.ToString()].Left = this.Controls["pct_sabo" + pctnr.ToString()].Left;

            if (SW.Dynamisch.GetSpWithID(id).GetReligion() == SW.Statisch.GetRelKathID())
            {
                this.Controls["pct_rel" + pctnr.ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbRel1);
                this.Controls["pct_rel" + pctnr.ToString()].Visible = true;
            }
            else if (SW.Dynamisch.GetSpWithID(id).GetReligion() == SW.Statisch.GetRelEvanID())
            {
                this.Controls["pct_rel" + pctnr.ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbRel2);
                this.Controls["pct_rel" + pctnr.ToString()].Visible = true;
            }

        }
        #endregion

        #region AemterButtonsPositionieren
        public void AemterButtonsPositionieren(int Ebene)
        {
            pct_sabo1.Visible = false;
            pct_sabo2.Visible = false;
            pct_sabo3.Visible = false;
            pct_sabo4.Visible = false;
            pct_sabo5.Visible = false;
            pct_sabo6.Visible = false;
            pct_sabo7.Visible = false;

            pct_spio1.Visible = false;
            pct_spio2.Visible = false;
            pct_spio3.Visible = false;
            pct_spio4.Visible = false;
            pct_spio5.Visible = false;
            pct_spio6.Visible = false;
            pct_spio7.Visible = false;

            pct_ehe1.Visible = false;
            pct_ehe2.Visible = false;
            pct_ehe3.Visible = false;
            pct_ehe4.Visible = false;
            pct_ehe5.Visible = false;
            pct_ehe6.Visible = false;
            pct_ehe7.Visible = false;

            pct_rel1.Visible = false;
            pct_rel2.Visible = false;
            pct_rel3.Visible = false;
            pct_rel4.Visible = false;
            pct_rel5.Visible = false;
            pct_rel6.Visible = false;
            pct_rel7.Visible = false;

            //Positionieren und anzeigen der Politische Ebene
            if (Ebene == 0)
            {
                pct_eheringe.Visible = false;

                int id;

                if (Stufe == 0)
                {
                    //Bürgermeister
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetBuergermeister();
                    AmtIDist0check(id, 7, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Baumeister
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetBaumeister();
                    AmtIDist0check(id, 4, 2);
                    btn_amt2.Left = linkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Richter
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetRichter();
                    AmtIDist0check(id, 5, 3);
                    btn_amt3.Left = (this.Width - btn_amt3.Width) / 2;
                    SymboleAnzeigen(id, 3);

                    //Kämmerer
                    btn_amt4.Top = 220;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetKaemmerer();
                    AmtIDist0check(id, 6, 4);
                    btn_amt4.Left = rechteAusrichtungslinie - (btn_amt4.Width / 2);
                    SymboleAnzeigen(id, 4);

                    //Ratsherr 1
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr1();
                    AmtIDist0check(id, 1, 5);
                    btn_amt5.Left = linkeAusrichtungslinie - (btn_amt5.Width / 2);
                    SymboleAnzeigen(id, 5);

                    //Ratsherr 2
                    btn_amt6.Top = 330;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr2();
                    AmtIDist0check(id, 2, 6);
                    btn_amt6.Left = (this.Width - btn_amt6.Width) / 2;
                    SymboleAnzeigen(id, 6);

                    //Ratsherr 3
                    btn_amt7.Top = 330;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr3();
                    AmtIDist0check(id, 3, 7);
                    btn_amt7.Left = rechteAusrichtungslinie - (btn_amt7.Width / 2);
                    SymboleAnzeigen(id, 7);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = true;
                    btn_amt7.Visible = true;
                }
                else if (Stufe == 1)
                {
                    //Vogt
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetVogt();
                    AmtIDist0check(id, 22, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Justizberater
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetJustizberater();
                    AmtIDist0check(id, 20, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Finanzberater
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetFinanzberater();
                    AmtIDist0check(id, 21, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    //Geheimrat1
                    btn_amt4.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat1();
                    AmtIDist0check(id, 17, 4);
                    btn_amt4.Left = linkeAusrichtungslinie - (btn_amt4.Width / 2);
                    SymboleAnzeigen(id, 4);

                    //Geheimrat2
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat2();
                    AmtIDist0check(id, 18, 5);
                    btn_amt5.Left = (this.Width - btn_amt5.Width) / 2;
                    SymboleAnzeigen(id, 5);

                    //Geheimrat3
                    btn_amt6.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat3();
                    AmtIDist0check(id, 19, 6);
                    btn_amt6.Left = rechteAusrichtungslinie - (btn_amt6.Width / 2);
                    SymboleAnzeigen(id, 6);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = true;
                    btn_amt7.Visible = false;
                }
                else if (Stufe == 2)
                {
                    //Regent
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetRegent();
                    AmtIDist0check(id, 39, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Justizminister
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetJustizminister();
                    AmtIDist0check(id, 37, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Finanzminister
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetFinanzminister();
                    AmtIDist0check(id, 38, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    //Hofrat1
                    btn_amt4.Top = 330;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat1();
                    AmtIDist0check(id, 34, 4);
                    btn_amt4.Left = linkeAusrichtungslinie - (btn_amt4.Width / 2); 
                    SymboleAnzeigen(id, 4);

                    //Hofrat2
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat2();
                    AmtIDist0check(id, 35, 5);
                    btn_amt5.Left = (this.Width - btn_amt5.Width) / 2;
                    SymboleAnzeigen(id, 5);

                    //Hofrat3
                    btn_amt6.Top = 330;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat3();
                    AmtIDist0check(id, 36, 6);
                    btn_amt6.Left = rechteAusrichtungslinie - (btn_amt6.Width / 2); 
                    SymboleAnzeigen(id, 6);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = true;
                    btn_amt7.Visible = false;
                }
            }

            //Kirchliche Ebene
            if (Ebene == 1)
            {
                int id;

                if (Stufe == 0)
                {
                    //Domherr
                    btn_amt1.Top = 160;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetDomherr();
                    AmtIDist0check(id, 10, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Priester1
                    btn_amt2.Top = 270;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester1();
                    AmtIDist0check(id, 8, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Priester2
                    btn_amt3.Top = 270;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester2();
                    AmtIDist0check(id, 9, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = false;
                    btn_amt5.Visible = false;
                    btn_amt6.Visible = false;
                    btn_amt7.Visible = false;
                }
                else if (Stufe == 1)
                {
                    //Bischof
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetBischof();
                    AmtIDist0check(id, 27, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Abt
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetAbt();
                    AmtIDist0check(id, 26, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Diakon
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetDiakon();
                    AmtIDist0check(id, 25, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    //Kellermeister
                    btn_amt4.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetKellermeister();
                    AmtIDist0check(id, 23, 4);
                    btn_amt4.Left = linkeAusrichtungslinie - (btn_amt4.Width / 2);
                    SymboleAnzeigen(id, 4);

                    //Sakristan
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetSakristan();
                    AmtIDist0check(id, 24, 5);
                    btn_amt5.Left = (this.Width - btn_amt5.Width) / 2;
                    SymboleAnzeigen(id, 5);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = false;
                    btn_amt7.Visible = false;
                }
                else if (Stufe == 2)
                {
                    //Erzbischof
                    btn_amt1.Top = 160;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetErzbischof();
                    AmtIDist0check(id, 42, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Inquisitor
                    btn_amt2.Top = 270;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetInquisitor();
                    AmtIDist0check(id, 40, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Erzdiakon
                    btn_amt3.Top = 270;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetErzdiakon();
                    AmtIDist0check(id, 41, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = false;
                    btn_amt5.Visible = false;
                    btn_amt6.Visible = false;
                    btn_amt7.Visible = false;
                }
            }

            //Militärische Ebene
            if (Ebene == 2)
            {
                int id;

                if (Stufe == 0)
                {
                    //Stadtkommandant
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtkommandant();
                    AmtIDist0check(id, 16, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Wachkommandant1
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetWachkommandant();
                    AmtIDist0check(id, 14, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Wachkommandant2
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetKerkermeister();
                    AmtIDist0check(id, 15, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    //Stadtwache1
                    btn_amt4.Top = 330;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtwache();
                    AmtIDist0check(id, 11, 4);
                    btn_amt4.Left = linkeAusrichtungslinie - (btn_amt4.Width / 2);
                    SymboleAnzeigen(id, 4);

                    //Stadtwache2
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetFolterknecht();
                    AmtIDist0check(id, 12, 5);
                    btn_amt5.Left = (this.Width - btn_amt5.Width) / 2;
                    SymboleAnzeigen(id, 5);

                    //Stadtwache3
                    btn_amt6.Top = 330;
                    id = SW.Dynamisch.GetStadtwithID(ObjektID).GetHenker();
                    AmtIDist0check(id, 13, 6);
                    btn_amt6.Left = rechteAusrichtungslinie - (btn_amt6.Width / 2);
                    SymboleAnzeigen(id, 6);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = true;
                    btn_amt7.Visible = false;
                }
                else if (Stufe == 1)
                {
                    //Hauptmann
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetHauptmann();
                    AmtIDist0check(id, 33, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //KommandantderKavallerie1
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetBefehlshaber();
                    AmtIDist0check(id, 31, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //KommandantderKavallerie2
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetZollmeister();
                    AmtIDist0check(id, 32, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    //KommandantderInfantrie1
                    btn_amt4.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetStellvertretenderBefehlshaber();
                    AmtIDist0check(id, 28, 4);
                    btn_amt4.Left = linkeAusrichtungslinie - (btn_amt4.Width / 2);
                    SymboleAnzeigen(id, 4);

                    //KommandantderInfantrie2
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner1();
                    AmtIDist0check(id, 29, 5);
                    btn_amt5.Left = (this.Width - btn_amt5.Width) / 2;
                    SymboleAnzeigen(id, 5);

                    //KommandantderInfantrie3
                    btn_amt6.Top = 330;
                    id = SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner2();
                    AmtIDist0check(id, 30, 6);
                    btn_amt6.Left = rechteAusrichtungslinie - (btn_amt6.Width / 2);
                    SymboleAnzeigen(id, 6);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = true;
                    btn_amt7.Visible = false;
                }
                else if (Stufe == 2)
                {
                    //Marschall
                    btn_amt1.Top = 110;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetFeldmarschall();
                    AmtIDist0check(id, 48, 1);
                    btn_amt1.Left = (this.Width - btn_amt1.Width) / 2;
                    SymboleAnzeigen(id, 1);

                    //Armeekommandant1
                    btn_amt2.Top = 220;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall1();
                    AmtIDist0check(id, 46, 2);
                    btn_amt2.Left = halblinkeAusrichtungslinie - (btn_amt2.Width / 2);
                    SymboleAnzeigen(id, 2);

                    //Armeekommandant2
                    btn_amt3.Top = 220;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall2();
                    AmtIDist0check(id, 47, 3);
                    btn_amt3.Left = halbrechteAusrichtungslinie - (btn_amt3.Width / 2);
                    SymboleAnzeigen(id, 3);

                    //Ritter1
                    btn_amt4.Top = 330;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier1();
                    AmtIDist0check(id, 43, 4);
                    btn_amt4.Left = linkeAusrichtungslinie - (btn_amt4.Width / 2);
                    SymboleAnzeigen(id, 4);

                    //Ritter2
                    btn_amt5.Top = 330;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier2();
                    AmtIDist0check(id, 44, 5);
                    btn_amt5.Left = (this.Width - btn_amt5.Width) / 2;
                    SymboleAnzeigen(id, 5);

                    //Ritter3
                    btn_amt6.Top = 330;
                    id = SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier3();
                    AmtIDist0check(id, 45, 6);
                    btn_amt6.Left = rechteAusrichtungslinie - (btn_amt6.Width / 2);
                    SymboleAnzeigen(id, 6);

                    btn_amt1.Visible = true;
                    btn_amt2.Visible = true;
                    btn_amt3.Visible = true;
                    btn_amt4.Visible = true;
                    btn_amt5.Visible = true;
                    btn_amt6.Visible = true;
                    btn_amt7.Visible = false;
                }
            }

            //Grafschaft
            if (Ebene == 3)
            {
                //Graf
                btn_amt1.Text = "Graf " + "Name";
                btn_amt1.Top = 150;
                btn_amt1.Left = halblinkeAusrichtungslinie - btn_amt1.Width / 2;

                //Gräfin
                btn_amt2.Text = "Gräfin " + "Name";
                btn_amt2.Top = btn_amt1.Top;
                btn_amt2.Left = halbrechteAusrichtungslinie - btn_amt2.Width /2;

                //Erbe
                btn_amt3.Text = "Erbe " + "Name";
                btn_amt3.Top = 300;
                btn_amt3.Left = this.Width / 2 - btn_amt3.Width / 2;

                btn_amt1.Visible = true;
                btn_amt2.Visible = true;
                btn_amt3.Visible = true;
                btn_amt4.Visible = false;
                btn_amt5.Visible = false;
                btn_amt6.Visible = false;
                btn_amt7.Visible = false;
                pct_eheringe.Visible = true;
            }

            Invalidate();
        }
        #endregion

        #region Buttons
        private void btn_amt7_Click(object sender, EventArgs e)
        {
            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr3());
                }
            }
        }

        private void btn_amt6_Click(object sender, EventArgs e)
        {
            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr2());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat3());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat3());
                }
            }
            if (AktuelleEbene == 2)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetHenker());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner2());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier3());
                }
            }
        }

        private void btn_amt5_Click(object sender, EventArgs e)
        {
            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetRatsherr1());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat2());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat2());
                }
            }
            if (AktuelleEbene == 1)
            {
                if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetSakristan());
                }
            }

            if (AktuelleEbene == 2)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetFolterknecht());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetZoellner1());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier2());
                }
            }
        }

        private void btn_amt4_Click(object sender, EventArgs e)
        {
            if (AktuelleEbene == 0)
            {
                if(Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetKaemmerer());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetGeheimrat1());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetHofrat1());
                }
            }
            if (AktuelleEbene == 1)
            {
                if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetKellermeister());
                }
            }
            if (AktuelleEbene == 2)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtwache());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetStellvertretenderBefehlshaber());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetOffizier1());
                }
            }
        }

        private void btn_amt3_Click(object sender, EventArgs e)
        {
            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetRichter());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetFinanzberater());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetFinanzminister());
                }
            }
            if (AktuelleEbene == 1)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester2());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetDiakon());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetErzdiakon());
                }
            }
            if (AktuelleEbene == 2)
            {
                if(Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetKerkermeister());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetZollmeister());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall2());
                }
            }
        }

        private void btn_amt2_Click(object sender, EventArgs e)
        {

            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetBaumeister());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetJustizberater());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetJustizminister());
                }
            }
            if (AktuelleEbene == 1)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetPriester1());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetAbt());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetInquisitor());
                }
            }
            if (AktuelleEbene == 2)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetWachkommandant());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetBefehlshaber());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetMarschall1());
                }
            }
        }

        private void btn_amt1_Click(object sender, EventArgs e)
        {
            if (AktuelleEbene == 0)
            {
                if (Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetBuergermeister());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetVogt());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetRegent());
                }
            }
            if (AktuelleEbene == 1)
            {
                if(Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetDomherr());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetBischof());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetErzbischof());
                }
            }
            if (AktuelleEbene == 2)
            {
                if(Stufe == 0)
                {
                    PersonAusfuehren(SW.Dynamisch.GetStadtwithID(ObjektID).GetStadtkommandant());
                }
                else if (Stufe == 1)
                {
                    PersonAusfuehren(SW.Dynamisch.GetLandWithID(ObjektID).GetHauptmann());
                }
                else if (Stufe == 2)
                {
                    PersonAusfuehren(SW.Dynamisch.GetReichWithID(ObjektID).GetFeldmarschall());
                }
            }
        }
        #endregion

        #region AmtIDist0check
        public void AmtIDist0check(int SPID, int AmtsID, int ButtonNr)
        {
            if (SPID != 0)
            {
                this.Controls["btn_amt" + ButtonNr.ToString()].Text = SW.Statisch.GetAmtwithID(AmtsID).GetAmtsname(SW.Dynamisch.GetSpWithID(SPID).GetMaennlich()) + "\n" + SW.Dynamisch.GetSpWithID(SPID).GetName();
            }
            else
            {
                this.Controls["btn_amt" + ButtonNr.ToString()].Text = SW.Statisch.GetAmtwithID(AmtsID).GetAmtsname(true) + "\n" + "(unbesetzt)";
            }
        }
        #endregion

        #region SymboleAnzeigen
        public void SymboleAnzeigen(int ID, int ButtonNr)
        {
            if (ID != 0)
            {
                SaboSymbsZeigen(ID, ButtonNr);
                SpioSymbsZeigen(ID, ButtonNr);
                EheSymbsZeigen(ID, ButtonNr);
                RelSymbsZeigen(ID, ButtonNr);
            }
        }
        #endregion

        #region FormSchliessen
        public void FormSchliessen()
        {
            SpE.setIntKurzSpeicher(0);
            this.Close();
        }
        #endregion

        private void PersonAusfuehren(int id)
        {
            if (id != 0)  // Verhindert eine Exception, wenn bei einer Aktion auf ein nicht besetztes Amt geklickt wird
            {
                UI.PersonWasMachen(id, modus);
                AemterButtonsPositionieren(AktuelleEbene);
                Invalidate();

                if (modus == 8)
                    FormSchliessen();

                if (modus == 2)
                {
                    if (SpE.getAnschwaerzID() != 0)
                        btn_titel.Text = SW.Dynamisch.GetSpWithID(id).GetName() + " anschwärzen bei...";
                    else
                        btn_titel.Text = modeText[modus] + SW.Dynamisch.GetGebietwithID(ObjektID, Stufe).GetGebietsName();
                }
            }
        }
    }
}
