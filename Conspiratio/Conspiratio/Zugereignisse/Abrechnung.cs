using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Kampf;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Kampf;
using Conspiratio.Lib.Gameplay.Kampf.Einheiten;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Abrechnung : frmBasis
    {
        private Label _lblTaler;

        #region Konstruktor
        public Abrechnung(ref Label lblgold)
        {
            InitializeComponent();
            

            label1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            
            _lblTaler = lblgold;
            int Gesamtkosten = 0;

            #region Arbeiter-, Betriebs- und Transportkosten
            int Arbeiterkosten = 0;
            int Betriebskosten = 0;
            int Transportkosten = 0;

            //Von jeder Stadt
            for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
            {
                //und jedem Slot berechnen
                for (int j = 0; j < SW.Statisch.GetMaxProdSlots(); j++)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == 1)
                    {
                        int rohid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetProduktionRohstoff();
                        int a_preis = SW.Dynamisch.GetRohstoffwithID(rohid).GetWSArbeiterpreis();
                        int a_kosten = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetProduktionArbeiter() * a_preis;
                        Arbeiterkosten += a_kosten;
                        a_kosten = 0;
                        a_preis = 0;

                        int p_preis = SW.Dynamisch.GetRohstoffwithID(rohid).GetWSEinzelpreis();
                        int p_kosten = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetProduktionStaetten() * p_preis;
                        Betriebskosten += p_kosten;
                        p_preis = 0;
                        p_kosten = 0;
                    }

                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == 2 || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == 3)
                    {
                        int anz_exp = 0;
                        int kara_id = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKarawaneInStadtX(i);
                        int karaPreisPro100Stueck = SW.Statisch.GetKarawane(kara_id).PreisProStueck;
                        int karaGrundPreis = SW.Statisch.GetKarawane(kara_id).Fixpreis;

                        anz_exp = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufAnzahl();


                        if (anz_exp != 0)
                        {
                            double d_bruch = (anz_exp - 1) / SW.Statisch.GetKarawane(kara_id).Kapazitaet; //anz_exp-1 weil: Damit bei 400 Waren noch 4 Karren und nicht 5 genommen werden
                            double anz_fuhren = Convert.ToInt32(d_bruch) + 1; //Da immer abgerundet wird

                            Transportkosten += Convert.ToInt32(karaGrundPreis + karaPreisPro100Stueck * anz_fuhren);
                        }
                    }

                }
            }

            Gesamtkosten += Arbeiterkosten;
            lbl_k_arbeiter.Text = Arbeiterkosten.ToStringGeld(false);
            Gesamtkosten += Betriebskosten;
            lbl_k_betriebs.Text = Betriebskosten.ToStringGeld(false);
            Gesamtkosten += Transportkosten;
            lbl_k_transport.Text = Transportkosten.ToStringGeld(false);
            #endregion

            #region Verkaufssteuern
            int verkaufssteuern = 0;

            for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
            {
                double umsatzsteuerInStadtI = SW.Dynamisch.GetStadtwithID(i).GetUmsatzsteuer();
                int umsatzInStadtI = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetUmsatzInStadtX(i);

                verkaufssteuern += Convert.ToInt32(umsatzsteuerInStadtI * umsatzInStadtI);
            }

            double steuerhinterziehung = 0;
            if (SW.Dynamisch.GetAktHum().CheckPrivilegX(27) == true)
            {
                steuerhinterziehung = 0.2;
            }
            if (SW.Dynamisch.GetAktHum().CheckPrivilegX(28) == true)
            {
                steuerhinterziehung = 0.4;
            }
            if (SW.Dynamisch.GetAktHum().CheckPrivilegX(29) == true)
            {
                steuerhinterziehung = 0.6;
            }

            Gesamtkosten +=  Convert.ToInt32(verkaufssteuern * (1-steuerhinterziehung));
            lbl_k_verkaufssteuern.Text = verkaufssteuern.ToStringGeld(false);
            #endregion

            #region Informanten
            int Informantenkosten = 0;

            for (int i = 1; i < SW.Statisch.GetMaxKIID(); i++)
            {
                Informantenkosten += SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).GetKosten();
            }

            Gesamtkosten += Informantenkosten;
            lbl_k_Informanten.Text = Informantenkosten.ToStringGeld(false);
            #endregion

            #region Saboteure
            int Saboteurekosten = 0;

            for (int i = 1; i < SW.Statisch.GetMaxKIID(); i++)
            {
                Saboteurekosten += SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(i).GetKosten();
            }

            Gesamtkosten += Saboteurekosten;
            lbl_k_Saboteure.Text = Saboteurekosten.ToStringGeld(false);
            #endregion

            #region Kreditzinsen
            int Kreditzinsenkosten = 0;

            for (int i = 0; i < SW.Statisch.GetMaxKredite(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetTaler() != 0)
                {
                    int goldstke = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetTaler();
                    double zins = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetZinsen();
                    zins = zins / 100;
                    double tsum = goldstke * zins;
                    Kreditzinsenkosten += Convert.ToInt32(tsum);
                }
            }

            lbl_k_kreditzinsen.Text = Kreditzinsenkosten.ToStringGeld(false);
            Gesamtkosten += Kreditzinsenkosten;
            #endregion

            #region Kirchenzehnt

            int Kirchenzehntkosten = 0;

            int GesamtUmsatz = 0;
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(16) == false)
            {
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    GesamtUmsatz += SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetUmsatzInStadtX(i);
                }
            }
            Kirchenzehntkosten = Convert.ToInt32(SW.Statisch.GetKirchenzehnt() * GesamtUmsatz);
            lbl_k_kirchenzehnt.Text = Kirchenzehntkosten.ToStringGeld(false);
            Gesamtkosten += Kirchenzehntkosten;
            #endregion

            #region Zoelle
            int zollkosten = 0;

            for (int j = 0; j < SW.Statisch.GetMaxProdSlots(); j++)
            {
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    //Überprüfen ob Exportieren eingestellt ist
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == 2 || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == 3)
                    {
                        //Exportierter Rohstoff in Stadt i
                        int rohNr = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufRohstoff();

                        //Rohstoff mit rohNr wurde exportiert
                        int anzahl = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufAnzahl();
                        int zielstadt = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufStadt();

                        //Zollkosten berechnen
                        int startland = SW.Dynamisch.GetStadtwithID(i).GetLandID();
                        int zielland = SW.Dynamisch.GetStadtwithID(zielstadt).GetLandID();
                        int rohgrundpreis = SW.Dynamisch.GetRohstoffwithID(rohNr).GetPreisStd();
                        int grundumsatz = rohgrundpreis * anzahl;

                        //Dann wird mindestens eine Grenze überschritten
                        if (startland != zielland)
                        {
                            double zollsatz1 = SW.Dynamisch.GetZollburgWithIDx(SW.Dynamisch.GetLandWithID(startland).GetZollburgIndex()).Zoll;
                            double zollsatz2 = SW.Dynamisch.GetZollburgWithIDx(SW.Dynamisch.GetLandWithID(zielland).GetZollburgIndex()).Zoll;

                            if (SW.Dynamisch.GetZollburgWithIDx(SW.Dynamisch.GetLandWithID(startland).GetZollburgIndex()).Besitzer == SW.Dynamisch.GetAktiverSpieler())
                                zollsatz1 = 0;
                            else
                                SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetZollburgWithIDx(SW.Dynamisch.GetLandWithID(startland).GetZollburgIndex()).Besitzer).ErhoeheTaler(Convert.ToInt32(zollsatz1 * grundumsatz));

                            if (SW.Dynamisch.GetZollburgWithIDx(SW.Dynamisch.GetLandWithID(zielland).GetZollburgIndex()).Besitzer == SW.Dynamisch.GetAktiverSpieler())
                                zollsatz2 = 0;
                            else
                                SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetZollburgWithIDx(SW.Dynamisch.GetLandWithID(zielland).GetZollburgIndex()).Besitzer).ErhoeheTaler(Convert.ToInt32(zollsatz2 * grundumsatz));

                            double geszollsatz = zollsatz1 + zollsatz2;
                            zollkosten += Convert.ToInt32(geszollsatz * grundumsatz);
                        }
                    }
                }
            }

            //Privilegien
            if (SW.Dynamisch.GetAktHum().CheckPrivilegX(23) == true)
            {
                zollkosten = 0;
            }
            if (SW.Dynamisch.GetAktHum().CheckPrivilegX(31) == true)
            {
                if (SW.Statisch.Rnd.Next(0, 2) == 0)
                {
                    zollkosten = 0;
                }
            }

            Gesamtkosten += zollkosten;

            lbl_k_zoelle.Text = zollkosten.ToStringGeld(false);

            for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetUmsatzInStadtX(0, i);
            }
            #endregion

            #region Sold

            int Sold = 0;

            foreach (Stuetzpunkt oStuetzpunkt in SW.Dynamisch.GetStuetzpunkte())
            {
                if (oStuetzpunkt.Besitzer == SW.Dynamisch.GetAktiverSpieler())
                {
                    foreach (Einheit oEinheit in oStuetzpunkt.Einheiten)
                    {
                        Sold += oEinheit.Basispreis;
                    }
                }
            }

            lbl_k_sold.Text = Sold.ToStringGeld(false);
            Gesamtkosten += Sold;
            #endregion

            #region Gesamtkosten
            lbl_k_gesamt.Text = Gesamtkosten.ToStringGeld(false);
            UI.TalerAendern(-Gesamtkosten, ref lblgold);
            #endregion

            #region Umsaetze des Spielers wieder auf 0 setzen
            for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetUmsatzInStadtX(0, i);
            }
            #endregion
        }
        #endregion


        private void Abrechnung_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
