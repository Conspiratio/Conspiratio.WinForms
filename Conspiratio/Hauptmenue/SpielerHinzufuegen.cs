using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class SpielerHinzufuegen : frmBasis
    {
        private bool _nachtraeglich;
        private bool _finished;

        private int _bildschirmHoehe;
        private int _bildschirmBreite;
        private int _aktuellAktiverSpieler = 0;
        private int _anzahlAngelegteSpieler = 0;

        private int _stadtIdAktuellerSpieler;
        private int _rohstoffIdAktuellerSpieler;
        private int _rohstoffPlatzAktuellerSpieler;
        private int _abzugTalerWegenStadtwahl;
        private int _abzugTalerWegenRohstoffwahl;
        
        private bool _escPressed = false;

        #region Konstruktor
        public SpielerHinzufuegen(bool nachtr)
        {
            InitializeComponent();

            label1.Left = (this.Width - label1.Width) / 2;
            _nachtraeglich = nachtr;

            btn_nsp_ban1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban1);
            btn_nsp_ban2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban2);
            btn_nsp_ban3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban3);
            btn_nsp_ban4.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban4);
            btn_nsp_ban5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban5);
            btn_nsp_ban6.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban6);
            btn_nsp_ban7.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban7);
            btn_nsp_ban8.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban8);
            btn_nsp_ban9.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban9);
            btn_nsp_ban10.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban10);
            btn_nsp_ban11.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban11);
            btn_nsp_ban12.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban12);
            btn_nsp_ban13.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban13);
            btn_nsp_ban14.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban14);

            btn_nsp_rel1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbRel1);
            btn_nsp_rel2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbRel2);
            this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintBuchOffen);

            // Tooltips für Religionsicons setzen
            ttReligion.SetToolTip(btn_nsp_rel1, SW.Statisch.GetReligionsNamenX(SW.Statisch.GetRelKathID()));
            ttReligion.SetToolTip(btn_nsp_rel2, SW.Statisch.GetReligionsNamenX(SW.Statisch.GetRelEvanID()));

            _bildschirmBreite = 1024;
            _bildschirmHoehe = 768;
        }
        #endregion

        #region AllHumanPlayersWithNameToString (for Debugging)
        public static string AllHumanPlayersWithNameToString()
        {
            string allHumanPlayersString = "Aktiver Spieler Index: " + SW.Dynamisch.GetAktiverSpieler() + Environment.NewLine;

            for (int i = 1; i < SW.Statisch.GetMinKIID(); i++)
            {
                if (string.IsNullOrEmpty(SW.Dynamisch.GetHumWithID(i).GetName()))
                    continue;
                
                allHumanPlayersString += $"Id: {i} {SW.Dynamisch.GetHumWithID(i)}{Environment.NewLine}";
            }

            allHumanPlayersString += Environment.NewLine + "ENDE--------------------------------------------------------------------------------------------------" + Environment.NewLine + Environment.NewLine;

#if DEBUG
            System.Diagnostics.Debug.WriteLine(allHumanPlayersString);
#endif

            return allHumanPlayersString;
        }
        #endregion

        #region SpielerHinzufuegen_Shown
        private async void SpielerHinzufuegen_Shown(object sender, EventArgs e)
        {
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Top = UI.NormH(41, Height, _bildschirmHoehe);
 
            _aktuellAktiverSpieler = SW.Dynamisch.GetAktiverSpieler();

            if (_nachtraeglich == false)
            {
                SW.Dynamisch.SetAktiverSpieler(0);
                _anzahlAngelegteSpieler = 0;
            }
            else
            {
                SW.Dynamisch.SetAktivSpielerAnzahl(SW.Dynamisch.GetAktivSpielerAnzahl() + 1);
                SW.Dynamisch.SetAktiverSpieler(SW.Dynamisch.GetAktivSpielerAnzahl() - 1);
                _anzahlAngelegteSpieler = SW.Dynamisch.GetAktivSpielerAnzahl() - 1;
            }

            while (_anzahlAngelegteSpieler < SW.Dynamisch.GetAktivSpielerAnzahl())
            {
                #region Controls initialisieren

                txb_namenEingeben.Clear();
                btn_nsp_rohzuf.Visible = false;
                btn_nsp_stdwaeh.Visible = false;
                btn_nsp_rohwaeh.Visible = false;
                btn_nsp_stdzuf.Visible = false;
                lbl_nsp_Banner.Visible = false;
                lbl_nsp_name.Visible = false;
                lbl_nsp_Geschlecht.Visible = false;
                lbl_nsp_Rohstoff.Visible = false;
                lbl_nsp_Stadt.Visible = false;
                btn_nsp_maen.Visible = false;
                btn_nsp_weib.Visible = false;
                alleBannerEinblenden(false, 0);
                txb_namenEingeben.ReadOnly = false;
                btn_nsp_rel1.Enabled = true;
                btn_nsp_rel2.Enabled = true;
                btn_nsp_rel1.Visible = false;
                btn_nsp_rel2.Visible = false;
                lbl_nsp_religion.Visible = false;

                btn_nsp_rohzuf.Enabled = true;
                btn_nsp_rohwaeh.Enabled = true;
                btn_nsp_stdwaeh.Enabled = true;
                btn_nsp_stdzuf.Enabled = true;
                btn_nsp_maen.Enabled = true;
                txb_namenEingeben.Enabled = true;

                btn_nsp_ban1.Enabled = true;
                btn_nsp_ban2.Enabled = true;
                btn_nsp_ban3.Enabled = true;
                btn_nsp_ban4.Enabled = true;
                btn_nsp_ban5.Enabled = true;
                btn_nsp_ban6.Enabled = true;
                btn_nsp_ban7.Enabled = true;
                btn_nsp_ban8.Enabled = true;
                btn_nsp_ban9.Enabled = true;
                btn_nsp_ban10.Enabled = true;
                btn_nsp_ban11.Enabled = true;
                btn_nsp_ban12.Enabled = true;
                btn_nsp_ban13.Enabled = true;
                btn_nsp_ban14.Enabled = true;

                SW.Dynamisch.SetAktiverSpieler(SW.Dynamisch.GetAktiverSpieler() + 1);

                btn_nsp_stdzuf.Text = "Zufall";
                btn_nsp_stdwaeh.Text = "Wählen";
                btn_nsp_rohzuf.Text = "Zufall";
                btn_nsp_rohwaeh.Text = "Wählen";
                btn_nsp_maen.Text = "Männlich";

                _stadtIdAktuellerSpieler = 0;
                _rohstoffIdAktuellerSpieler = 0;
                _rohstoffPlatzAktuellerSpieler = 0;
                _abzugTalerWegenStadtwahl = 0;
                _abzugTalerWegenRohstoffwahl = 0;

                #endregion

#if DEBUG
                System.Diagnostics.Debug.WriteLine("Spielerstellung für Spieler " + SW.Dynamisch.GetAktiverSpieler() + " gestartet.");
                AllHumanPlayersWithNameToString();
#endif

                // Beginne mit dem Aufruf des ersten Schrittes, alle weiteren Schritte werden durch die Methoden selbst aufgerufen
                await NamenseingabeUmschalten();
            }

            SW.Dynamisch.SetAktiverSpieler(_aktuellAktiverSpieler);

            if (_finished)
            {
                await AufRechtsklickWarten();
                DialogResult = DialogResult.OK;
                CloseMitSound();
            }
        }
        #endregion

        #region SpielerHinzufuegen_MouseDown
        private void SpielerHinzufuegen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                tcsRechtsklick?.TrySetResult(true);
        }
        #endregion

        #region SpielerHinzufuegen_KeyPress
        private void SpielerHinzufuegen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)  // Schritt zurück?
            {
                CurStandardActive();

                _escPressed = true;

                tcsEnterdruck?.TrySetResult(true);
                tcsButtonklick?.TrySetResult(true);
            }
        }
        #endregion


        #region txb_namenEingeben_KeyPress
        private void txb_namenEingeben_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true; //Verhindert den Windows-Fehler-Sound (Piep)
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                bool check = true;

                //Überprüfen ob der Name auch die vorgegebene Mindestlänge hat
                if (txb_namenEingeben.Text.Length < SW.Statisch.GetMinNameLength())
                {
                    SW.Dynamisch.BelTextAnzeigen("Euer Name muss aus mindestens 3 Zeichen bestehen");
                    check = false;
                }

                // Auf ungültiges Zeichen prüfen
                if ((check) && (txb_namenEingeben.Text.Contains("~")))
                {
                    SW.Dynamisch.BelTextAnzeigen("Euer Name darf kein ~ Zeichen enthalten");
                    check = false;
                }

                //Auf gleiche Name abfragen
                if (check)
                {
                    for (int i = 1; i < SW.Dynamisch.GetAktiverSpieler(); i++)
                    {
                        if (SW.Dynamisch.GetHumWithID(i).GetName() == txb_namenEingeben.Text)
                        {
                            SW.Dynamisch.BelTextAnzeigen("Es ist bereits ein Mitspieler mit demselben Namen vorhanden. Bitte wählt einen anderen");
                            check = false;
                            break;
                        }
                    }
                }

                if (check)
                {
                    tcsEnterdruck?.TrySetResult(true);
                }
            }
        }
        #endregion

        #region txb_namenEingeben_TextChanged
        private void txb_namenEingeben_TextChanged(object sender, EventArgs e)
        {
            int maxlen = SW.Statisch.GetMaxNameLength();

            //Zu lange Namen abfangen
            if (txb_namenEingeben.Text.Length > maxlen)
            {
                txb_namenEingeben.Text = txb_namenEingeben.Text.Substring(0, maxlen);
                txb_namenEingeben.Select(txb_namenEingeben.Text.Length, 0);
            }
        }
        #endregion

        #region Button Events
        private void btn_nsp_stdwaeh_Click(object sender, EventArgs e)
        {
            SpE.setBoolKurzSpeicher(false);

            SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(6);

            if (SpE.getBoolKurzSpeicher() == false)
            {
                _abzugTalerWegenStadtwahl = SW.Statisch.GetNSPStadtwahlKosten();
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-_abzugTalerWegenStadtwahl);
                btn_nsp_stdzuf.Visible = false;
                int sid = SpE.getIntKurzSpeicher();
                HausInStadtHinzufuegen(sid);

                btn_nsp_stdwaeh.Text = "gewählt: " + SW.Dynamisch.GetStadtwithID(sid).GetGebietsName();

                btn_nsp_stdwaeh.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_stdwaeh.Width / 2;
                btn_nsp_stdwaeh.Enabled = false;

                SpE.setIntKurzSpeicher(sid);
                tcsButtonklick?.TrySetResult(true);
            }
            SpE.setBoolKurzSpeicher(false);
        }

        private void btn_nsp_stdzuf_Click(object sender, EventArgs e)
        {
            btn_nsp_stdzuf.Visible = false;
            int randstd = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxStadtID());

            HausInStadtHinzufuegen(randstd);

            btn_nsp_stdwaeh.Text = "zufällig: " + SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(randstd).GetStadtID()).GetGebietsName();
            btn_nsp_stdwaeh.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_stdwaeh.Width / 2;
            btn_nsp_stdwaeh.Top = lbl_nsp_Stadt.Top + 50;
            btn_nsp_stdwaeh.Enabled = false;

            SpE.setIntKurzSpeicher(randstd);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nsp_maen_Click(object sender, EventArgs e)
        {
            btn_nsp_weib.Visible = false;
            btn_nsp_maen.Enabled = false;
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetMaennlich(true);
            btn_nsp_maen.Text = "gewählt: Männlich";
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nsp_weib_Click(object sender, EventArgs e)
        {
            btn_nsp_weib.Visible = false;
            btn_nsp_maen.Enabled = false;
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetMaennlich(false);
            btn_nsp_maen.Text = "gewählt: Weiblich";
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nsp_rel1_Click(object sender, EventArgs e)
        {
            btn_nsp_rel2.Visible = false;
            btn_nsp_rel1.Enabled = false;
            btn_nsp_rel1.Left = lbl_nsp_religion.Left + lbl_nsp_religion.Width / 2 - btn_nsp_rel1.Width / 2;

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetReligion(SW.Statisch.GetRelKathID());
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nsp_rel2_Click(object sender, EventArgs e)
        {
            btn_nsp_rel1.Visible = false;
            btn_nsp_rel2.Enabled = false;
            btn_nsp_rel2.Left = lbl_nsp_religion.Left + lbl_nsp_religion.Width / 2 - btn_nsp_rel2.Width / 2;

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetReligion(SW.Statisch.GetRelEvanID());
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nsp_rohwaeh_Click(object sender, EventArgs e)
        {
            SpE.setBoolKurzSpeicher(false);

            RohstoffWaehlen rohstoffWaehlen = new RohstoffWaehlen(_stadtIdAktuellerSpieler);
            rohstoffWaehlen.ShowDialog();

            if (rohstoffWaehlen.DialogResult == DialogResult.OK)
            {
                _abzugTalerWegenRohstoffwahl = SW.Statisch.GetNSPRohwahlKosten();
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-_abzugTalerWegenRohstoffwahl);
                btn_nsp_rohzuf.Visible = false;
                btn_nsp_rohwaeh.Text = "Gewählt: " + SW.Dynamisch.GetRohstoffwithID(rohstoffWaehlen.GewaehlterRohstoffId).GetRohName();

                RohstoffrechteVerleihenUndWerkstattSetzen(rohstoffWaehlen.GewaehlterRohstoffId, rohstoffWaehlen.GewaehlterRohstoffPlatz, _stadtIdAktuellerSpieler);

                btn_nsp_rohwaeh.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_rohwaeh.Width / 2;
                btn_nsp_rohwaeh.Enabled = false;
                tcsButtonklick?.TrySetResult(true);
            }
        }

        private void btn_nsp_rohzuf_Click(object sender, EventArgs e)
        {
            int randomPlatz = SW.Statisch.Rnd.Next(1, 3);
            int rohid = SW.Dynamisch.GetStadtwithID(_stadtIdAktuellerSpieler).GetSingleRohstoff(randomPlatz);

            btn_nsp_rohzuf.Visible = false;

            RohstoffrechteVerleihenUndWerkstattSetzen(rohid, randomPlatz, _stadtIdAktuellerSpieler);

            btn_nsp_rohwaeh.Text = "zufällig: " + SW.Dynamisch.GetRohstoffwithID(rohid).GetRohName();
            btn_nsp_rohwaeh.Top = lbl_nsp_Rohstoff.Top + 50;
            btn_nsp_rohwaeh.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_rohwaeh.Width / 2;

            btn_nsp_rohwaeh.Enabled = false;
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nsp_ban1_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 1);
            btn_nsp_ban1.Enabled = false;
            btn_nsp_ban1.Visible = true;
        }

        private void btn_nsp_ban2_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 2);
            btn_nsp_ban2.Enabled = false;
            btn_nsp_ban2.Visible = true;
        }

        private void btn_nsp_ban3_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 3);
            btn_nsp_ban3.Enabled = false;
            btn_nsp_ban3.Visible = true;
        }

        private void btn_nsp_ban4_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 4);
            btn_nsp_ban4.Enabled = false;
            btn_nsp_ban4.Visible = true;
        }

        private void btn_nsp_ban5_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 5);
            btn_nsp_ban5.Enabled = false;
            btn_nsp_ban5.Visible = true;
        }

        private void btn_nsp_ban6_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 6);
            btn_nsp_ban6.Enabled = false;
            btn_nsp_ban6.Visible = true;
        }

        private void btn_nsp_ban7_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 7);
            btn_nsp_ban7.Enabled = false;
            btn_nsp_ban7.Visible = true;
        }

        private void btn_nsp_ban8_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 8);
            btn_nsp_ban8.Enabled = false;
            btn_nsp_ban8.Visible = true;
        }

        private void btn_nsp_ban9_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 9);
            btn_nsp_ban9.Enabled = false;
            btn_nsp_ban9.Visible = true;
        }

        private void btn_nsp_ban10_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 10);
            btn_nsp_ban10.Enabled = false;
            btn_nsp_ban10.Visible = true;
        }

        private void btn_nsp_ban11_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 11);
            btn_nsp_ban11.Enabled = false;
            btn_nsp_ban11.Visible = true;
        }

        private void btn_nsp_ban12_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 12);
            btn_nsp_ban12.Enabled = false;
            btn_nsp_ban12.Visible = true;
        }

        private void btn_nsp_ban13_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 13);
            btn_nsp_ban13.Enabled = false;
            btn_nsp_ban13.Visible = true;
        }

        private void btn_nsp_ban14_Click(object sender, EventArgs e)
        {
            alleBannerEinblenden(false, 14);
            btn_nsp_ban14.Enabled = false;
            btn_nsp_ban14.Visible = true;
        }
        #endregion


        #region NamenseingabeUmschalten
        private async Task NamenseingabeUmschalten()
        {
            label1.Text = "Spieler hinzufügen - Abbrechen mit ESC";

            lbl_nsp_name.Left = UI.NormB(145, Width, _bildschirmBreite);
            lbl_nsp_name.Top = UI.NormH(163, Height, _bildschirmHoehe);

            if (_nachtraeglich)
                lbl_nsp_name.Text = $"Spielernamen eingeben:";
            else
                lbl_nsp_name.Text = $"Spieler{_anzahlAngelegteSpieler + 1} Namen eingeben:";

            txb_namenEingeben.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - txb_namenEingeben.Width / 2;
            txb_namenEingeben.Top = UI.NormH(209, Height, _bildschirmHoehe);
            lbl_nsp_name.Visible = true;
            txb_namenEingeben.Visible = true;
            txb_namenEingeben.Enabled = true;
            txb_namenEingeben.ReadOnly = false;
            txb_namenEingeben.Focus();

            await AufEnterdruckWarten();

            if (_escPressed)  // Einen Schritt zurück gehen bzw. die Spielerstellung abbrechen
            {
                _escPressed = false;

                if (!_nachtraeglich &&  // Neues Spiel?
                SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr die Spielerstellung\n komplett abbrechen?", "Ja", "Nein") != DialogResult.Yes)
                {
                    await NamenseingabeUmschalten();
                    return;
                }

                // Fenster schließen
                SW.Dynamisch.SetAktiverSpieler(_aktuellAktiverSpieler);
                DialogResult = DialogResult.Cancel;
                Close();
            }

            Focus();  // Das scheint notwendig zu sein, damit KeyPress (für ESC) im Fenster gefeuert wird
            txb_namenEingeben.Enabled = false;
            string nam = txb_namenEingeben.Text;

            int verbleibendeJahre = SW.Statisch.Rnd.Next(SW.Statisch.GetHumminVerblJahre(), SW.Statisch.GetHummaxVerblJahre());

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetTaler(SW.Statisch.GetStartgold());
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetName(nam);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetVerbleibendeJahre(verbleibendeJahre);

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Nach Namenseingabe für Spieler " + SW.Dynamisch.GetAktiverSpieler());
            AllHumanPlayersWithNameToString();
#endif

            await GeschlechtAuswaehlenUmschalten();
        }
        #endregion

        #region GeschlechtAuswaehlenUmschalten
        private async Task GeschlechtAuswaehlenUmschalten()
        {
            label1.Text = "Spieler hinzufügen - Zurück mit ESC";

            lbl_nsp_Geschlecht.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - lbl_nsp_Geschlecht.Width / 2;
            lbl_nsp_Geschlecht.Top = UI.NormH(291, Height, _bildschirmHoehe);

            txb_namenEingeben.ReadOnly = true;
            lbl_nsp_Geschlecht.Visible = true;

            btn_nsp_maen.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - btn_nsp_maen.Width / 2;
            btn_nsp_maen.Top = UI.NormH(345, Height, _bildschirmHoehe);
            btn_nsp_maen.Text = "Männlich";
            btn_nsp_maen.Enabled = true;
            btn_nsp_maen.Visible = true;

            btn_nsp_weib.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - btn_nsp_weib.Width / 2;
            btn_nsp_weib.Top = UI.NormH(387, Height, _bildschirmHoehe);
            btn_nsp_weib.Visible = true;
            Focus();  // Das scheint notwendig zu sein, damit KeyPress (für ESC) im Fenster gefeuert wird

            await AufButtonKlickWarten();

            if (_escPressed)  // Einen Schritt zurück gehen
            {
                _escPressed = false;

                lbl_nsp_Geschlecht.Visible = false;
                btn_nsp_maen.Visible = false;
                btn_nsp_weib.Visible = false;

                await NamenseingabeUmschalten();
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Nach Geschlechtsauswahl für Spieler " + SW.Dynamisch.GetAktiverSpieler());
            AllHumanPlayersWithNameToString();
#endif

            await BannerAuswaehlenUmschalten();
        }
        #endregion

        #region BannerAuswaehlenUmschalten
        private async Task BannerAuswaehlenUmschalten()
        {
            lbl_nsp_Banner.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - lbl_nsp_Banner.Width / 2;
            lbl_nsp_Banner.Top = UI.NormH(484, Height, _bildschirmHoehe);

            btn_nsp_ban1.Top = UI.NormH(554, Height, _bildschirmHoehe);
            btn_nsp_ban2.Top = btn_nsp_ban1.Top;
            btn_nsp_ban3.Top = btn_nsp_ban1.Top;
            btn_nsp_ban4.Top = btn_nsp_ban1.Top;
            btn_nsp_ban5.Top = btn_nsp_ban1.Top;
            btn_nsp_ban6.Top = btn_nsp_ban1.Top;
            btn_nsp_ban7.Top = btn_nsp_ban1.Top;

            btn_nsp_ban8.Top = UI.NormH(616, Height, _bildschirmHoehe);
            btn_nsp_ban9.Top = btn_nsp_ban8.Top;
            btn_nsp_ban10.Top = btn_nsp_ban8.Top;
            btn_nsp_ban11.Top = btn_nsp_ban8.Top;
            btn_nsp_ban12.Top = btn_nsp_ban8.Top;
            btn_nsp_ban13.Top = btn_nsp_ban8.Top;
            btn_nsp_ban14.Top = btn_nsp_ban8.Top;
            lbl_nsp_Banner.Visible = true;

            int btnabstand = 6;
            btnabstand = UI.NormB(btnabstand, Width, _bildschirmBreite);
            btn_nsp_ban4.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - btn_nsp_ban4.Width / 2;
            btn_nsp_ban5.Left = btn_nsp_ban4.Right + btnabstand;
            btn_nsp_ban6.Left = btn_nsp_ban5.Right + btnabstand;
            btn_nsp_ban7.Left = btn_nsp_ban6.Right + btnabstand;
            btn_nsp_ban3.Left = btn_nsp_ban4.Left - btn_nsp_ban3.Width - btnabstand;
            btn_nsp_ban2.Left = btn_nsp_ban3.Left - btn_nsp_ban2.Width - btnabstand;
            btn_nsp_ban1.Left = btn_nsp_ban2.Left - btn_nsp_ban1.Width - btnabstand;

            btn_nsp_ban11.Left = lbl_nsp_name.Left + lbl_nsp_name.Width / 2 - btn_nsp_ban11.Width / 2;
            btn_nsp_ban12.Left = btn_nsp_ban11.Right + btnabstand;
            btn_nsp_ban13.Left = btn_nsp_ban12.Right + btnabstand;
            btn_nsp_ban14.Left = btn_nsp_ban13.Right + btnabstand;
            btn_nsp_ban10.Left = btn_nsp_ban11.Left - btn_nsp_ban10.Width - btnabstand;
            btn_nsp_ban9.Left = btn_nsp_ban10.Left - btn_nsp_ban9.Width - btnabstand;
            btn_nsp_ban8.Left = btn_nsp_ban9.Left - btn_nsp_ban8.Width - btnabstand;

            alleBannerEinblenden(true, 0);
            Focus();  // Das scheint notwendig zu sein, damit KeyPress (für ESC) im Fenster gefeuert wird

            await AufButtonKlickWarten();

            if (_escPressed)  // Einen Schritt zurück gehen
            {
                _escPressed = false;

                lbl_nsp_Banner.Visible = false;
                alleBannerEinblenden(false, 0);

                await GeschlechtAuswaehlenUmschalten();
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Nach Bannerauswahl für Spieler " + SW.Dynamisch.GetAktiverSpieler());
            AllHumanPlayersWithNameToString();
#endif

            await StadtAuswaehlenUmschalten();
        }
        #endregion

        #region StadtAuswaehlenUmschalten
        private async Task StadtAuswaehlenUmschalten()
        {
            lbl_nsp_Stadt.Top = lbl_nsp_name.Top;
            lbl_nsp_Stadt.Left = UI.NormB(692, Width, _bildschirmBreite);
            lbl_nsp_Stadt.Visible = true;

            btn_nsp_stdwaeh.Top = lbl_nsp_Stadt.Top + 50;
            btn_nsp_stdwaeh.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_stdwaeh.Width / 2;
            btn_nsp_stdwaeh.Enabled = true;
            btn_nsp_stdwaeh.Text = "Wählen";
            btn_nsp_stdwaeh.Visible = true;

            btn_nsp_stdzuf.Top = btn_nsp_stdwaeh.Top + 50;
            btn_nsp_stdzuf.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_stdzuf.Width / 2;
            btn_nsp_stdzuf.Visible = true;
            Focus();  // Das scheint notwendig zu sein, damit KeyPress (für ESC) im Fenster gefeuert wird

            await AufButtonKlickWarten();

            if (_escPressed)  // Einen Schritt zurück gehen
            {
                _escPressed = false;

                lbl_nsp_Stadt.Visible = false;
                btn_nsp_stdwaeh.Visible = false;
                btn_nsp_stdzuf.Visible = false;

                await BannerAuswaehlenUmschalten();
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Nach Stadtauswahl für Spieler " + SW.Dynamisch.GetAktiverSpieler());
            AllHumanPlayersWithNameToString();
#endif

            await RohstoffAuswaehlenUmschalten();
        }
        #endregion

        #region RohstoffAuswaehlenUmschalten
        private async Task RohstoffAuswaehlenUmschalten()
        {
            lbl_nsp_Rohstoff.Top = UI.NormH(327, Height, _bildschirmHoehe);
            lbl_nsp_Rohstoff.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - lbl_nsp_Rohstoff.Width / 2;
            lbl_nsp_Rohstoff.Visible = true;

            btn_nsp_rohwaeh.Top = UI.NormH(376, Height, _bildschirmHoehe);
            btn_nsp_rohwaeh.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_rohwaeh.Width / 2;
            btn_nsp_rohwaeh.Enabled = true;
            btn_nsp_rohwaeh.Text = "Wählen";
            btn_nsp_rohwaeh.Visible = true;

            btn_nsp_rohzuf.Top = UI.NormH(418, Height, _bildschirmHoehe);
            btn_nsp_rohzuf.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_rohzuf.Width / 2;
            btn_nsp_rohzuf.Visible = true;
            Focus();  // Das scheint notwendig zu sein, damit KeyPress (für ESC) im Fenster gefeuert wird

            await AufButtonKlickWarten();

            if (_escPressed)  // Einen Schritt zurück gehen
            {
                _escPressed = false;

                lbl_nsp_Rohstoff.Visible = false;
                btn_nsp_rohwaeh.Visible = false;
                btn_nsp_rohzuf.Visible = false;

                // Vorheriger Abzug der Taler für die Stadtwahl (sofern vorhanden) wieder auf die Taler des aktiven Spielers addieren
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(_abzugTalerWegenStadtwahl);
                _abzugTalerWegenStadtwahl = 0;

                await StadtAuswaehlenUmschalten();
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Nach Rohstoffauswahl für Spieler " + SW.Dynamisch.GetAktiverSpieler());
            AllHumanPlayersWithNameToString();
#endif

            await ReligionAuswaehlenUmschalten();
        }
        #endregion

        #region ReligionAuswaehlenUmschalten
        private async Task ReligionAuswaehlenUmschalten(bool Visible = true)
        {
            lbl_nsp_religion.Top = UI.NormH(484, Height, _bildschirmHoehe);
            lbl_nsp_religion.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - lbl_nsp_religion.Width / 2;
            lbl_nsp_religion.Visible = true;

            btn_nsp_rel1.Top = UI.NormH(554, Height, _bildschirmHoehe);
            btn_nsp_rel1.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 - btn_nsp_rel1.Width - UI.NormB(6, Width, _bildschirmBreite);
            btn_nsp_rel1.Enabled = true;
            btn_nsp_rel1.Visible = true;

            btn_nsp_rel2.Top = btn_nsp_rel1.Top;
            btn_nsp_rel2.Left = lbl_nsp_Stadt.Left + lbl_nsp_Stadt.Width / 2 + UI.NormB(6, Width, _bildschirmBreite);
            btn_nsp_rel2.Enabled = true;
            btn_nsp_rel2.Visible = true;
            Focus();  // Das scheint notwendig zu sein, damit KeyPress (für ESC) im Fenster gefeuert wird

            await AufButtonKlickWarten();

            if (_escPressed)  // Einen Schritt zurück gehen
            {
                _escPressed = false;

                lbl_nsp_religion.Visible = false;
                btn_nsp_rel1.Visible = false;
                btn_nsp_rel2.Visible = false;

                // Vorheriger Abzug der Taler für die Rohstoffwahl (sofern vorhanden) wieder auf die Taler des aktiven Spielers addieren
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(_abzugTalerWegenRohstoffwahl);
                _abzugTalerWegenRohstoffwahl = 0;

                await RohstoffAuswaehlenUmschalten();
                return;
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine("Nach Religionsauswahl für Spieler " + SW.Dynamisch.GetAktiverSpieler());
            AllHumanPlayersWithNameToString();
#endif

            _finished = true;
            _anzahlAngelegteSpieler++;
        }
        #endregion

        #region alleBannerEinblenden
        private void alleBannerEinblenden(bool einblenden, int x)
        {
            btn_nsp_ban1.Visible = einblenden;
            btn_nsp_ban1.Enabled = true;
            btn_nsp_ban2.Visible = einblenden;
            btn_nsp_ban2.Enabled = true;
            btn_nsp_ban3.Visible = einblenden;
            btn_nsp_ban3.Enabled = true;
            btn_nsp_ban4.Visible = einblenden;
            btn_nsp_ban4.Enabled = true;
            btn_nsp_ban5.Visible = einblenden;
            btn_nsp_ban5.Enabled = true;
            btn_nsp_ban6.Visible = einblenden;
            btn_nsp_ban6.Enabled = true;
            btn_nsp_ban7.Visible = einblenden;
            btn_nsp_ban7.Enabled = true;
            btn_nsp_ban8.Visible = einblenden;
            btn_nsp_ban8.Enabled = true;
            btn_nsp_ban9.Visible = einblenden;
            btn_nsp_ban9.Enabled = true;
            btn_nsp_ban10.Visible = einblenden;
            btn_nsp_ban10.Enabled = true;
            btn_nsp_ban11.Visible = einblenden;
            btn_nsp_ban11.Enabled = true;
            btn_nsp_ban12.Visible = einblenden;
            btn_nsp_ban12.Enabled = true;
            btn_nsp_ban13.Visible = einblenden;
            btn_nsp_ban13.Enabled = true;
            btn_nsp_ban14.Visible = einblenden;
            btn_nsp_ban14.Enabled = true;

            //bereits vergebene Banner ausblenden
            int i = 1;
            while (i < SW.Dynamisch.GetAktiverSpieler())
            {
                this.Controls["btn_nsp_ban" + SW.Dynamisch.GetHumWithID(i).GetBanner().ToString()].Visible = false;
                i++;
            }

            if (x != 0)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBanner(x);
                tcsButtonklick?.TrySetResult(true);
            }
        }
        #endregion

        #region HausInStadtHinzufuegen
        private void HausInStadtHinzufuegen(int stadtId)
        {
            // Prüfen, ob der aktive Spieler bereits eine Stadt über ein Haus zugewiesen hatte. Wenn ja, das Haus wieder löschen (zurücksetzen)
            if (_stadtIdAktuellerSpieler != 0 &&
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtIdAktuellerSpieler).GetHausID() > 0)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtIdAktuellerSpieler).SetHausID(0);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtIdAktuellerSpieler).SetStadtID(0);
            }

            _stadtIdAktuellerSpieler = stadtId;
            
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(stadtId).SetHausID(SW.Statisch.GetStartHausID());
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(stadtId).SetStadtID(stadtId);
        }
        #endregion

        #region RohstoffrechteVerleihen
        private void RohstoffrechteVerleihenUndWerkstattSetzen(int rohstoffId, int platz, int stadtId)
        {
            // Prüfen, ob der aktive Spieler bereits ein Rohstoffrecht zugewiesen hatte. Wenn ja, dieses löschen
            if (_rohstoffIdAktuellerSpieler != 0 &&
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(_rohstoffIdAktuellerSpieler))
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetRohstoffrechteXZuY(_rohstoffIdAktuellerSpieler, false);
            }

            // Prüfen, ob der aktive Spieler bereits eine Werkstatt für irgendeinen Rohstoff zugewiesen hatte. Wenn ja, diese Werstatt löschen (zurücksetzen)
            if (_rohstoffPlatzAktuellerSpieler != 0)
            {
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_rohstoffPlatzAktuellerSpieler, i).GetEnabled())
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_rohstoffPlatzAktuellerSpieler, i).SetRohstoffID(0);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_rohstoffPlatzAktuellerSpieler, i).SetSkillX(1, 0);  // Lagerraum zurücksetzen
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_rohstoffPlatzAktuellerSpieler, i).SetEnabled(false);
                    }
                }
            }
            
            _rohstoffIdAktuellerSpieler = rohstoffId;
            _rohstoffPlatzAktuellerSpieler = platz;

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(platz, stadtId).SetRohstoffID(rohstoffId);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(platz, stadtId).SetSkillX(1, SW.Statisch.GetStartLagerraum());  // Startlagerraum
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(platz, stadtId).SetEnabled(true);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetRohstoffrechteXZuY(rohstoffId, true);
        }
        #endregion
    }
}