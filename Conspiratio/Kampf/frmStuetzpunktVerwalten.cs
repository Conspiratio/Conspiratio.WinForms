using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Kampf;
using Conspiratio.Lib.Gameplay.Kampf.Einheiten;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio.Kampf
{
    public partial class frmStuetzpunktVerwalten : frmBasis
    {
        #region Variablen

        private int _stuetzpunktID;
        private int _stuetzpunktIndex;
        private int _aktuellerWert;

        private int _aktuelleAnzahlEinheit1;
        private int _aktuelleAnzahlEinheit2;
        private int _aktuelleAnzahlEinheit3;
        private int _aktuelleAnzahlEinheit4;

        private Stuetzpunkt _stuetzpunkt;
        private Kampfberechnung _kampf = new Kampfberechnung();

        #endregion

        #region Konstruktor
        public frmStuetzpunktVerwalten(int stuetzpunktID)
        {
            InitializeComponent();

            _stuetzpunktID = stuetzpunktID;
            _stuetzpunktIndex = stuetzpunktID - 1;
            _stuetzpunkt = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex];
            _aktuellerWert = _stuetzpunkt.BerechneWert();

            UI.SpielerInfosAnzeigenUndAusrichten(this, false, _stuetzpunkt.Name, frmStuetzpunktVerwalten_MouseDown);

            nb_einheit_1.ForeColor = Grafik.GetStandardSchriftFarbeGold();

            if (_stuetzpunkt.Art == EnumStuetzpunktArt.Zollburg)
            {
                btn_zoll.Visible = true;
                btn_einheit_1.BackgroundImage = Properties.Resources.SymbSoeldner;
                btn_einheit_2.BackgroundImage = Properties.Resources.SymbMusketier;
                btn_einheit_3.BackgroundImage = Properties.Resources.SymbKanonier;
                btn_einheit_4.BackgroundImage = Properties.Resources.SymbOffizier;

                // Einheitobjekte der Tag Property der Buttons zuweisen für spätere Verwendung
                btn_einheit_1.Tag = new ZollSoeldner();
                btn_einheit_2.Tag = new ZollMusketier();
                btn_einheit_3.Tag = new ZollKanonier();
                btn_einheit_4.Tag = new ZollOffizier();
            }
            else
            {
                btn_zoll.Visible = false;
                btn_einheit_1.BackgroundImage = Properties.Resources.SymbRaeuber;
                btn_einheit_2.BackgroundImage = Properties.Resources.SymbBombenleger;
                btn_einheit_3.BackgroundImage = Properties.Resources.SymbKanonier;
                btn_einheit_4.BackgroundImage = Properties.Resources.SymbSchuetze;

                // Einheitobjekte der Tag Property der Buttons zuweisen für spätere Verwendung
                btn_einheit_1.Tag = new RaubRaeuber();
                btn_einheit_2.Tag = new RaubBombenleger();
                btn_einheit_3.Tag = new RaubKanonier();
                btn_einheit_4.Tag = new RaubSchuetze();
            }

            ttButtons.SetToolTip(btn_sicherheit_tarnung, _stuetzpunkt.SicherheitTarnungAlsString());

            ttButtons.SetToolTip(btn_einheit_1, ((Einheit)btn_einheit_1.Tag).NamePlural);
            ttButtons.SetToolTip(btn_einheit_2, ((Einheit)btn_einheit_2.Tag).NamePlural);
            ttButtons.SetToolTip(btn_einheit_3, ((Einheit)btn_einheit_3.Tag).NamePlural);
            ttButtons.SetToolTip(btn_einheit_4, ((Einheit)btn_einheit_4.Tag).NamePlural);

            nb_einheit_1.Wert = _stuetzpunkt.GetAnzahlTruppen((btn_einheit_1.Tag as Einheit).GetType());
            nb_einheit_2.Wert = _stuetzpunkt.GetAnzahlTruppen((btn_einheit_2.Tag as Einheit).GetType());
            nb_einheit_3.Wert = _stuetzpunkt.GetAnzahlTruppen((btn_einheit_3.Tag as Einheit).GetType());
            nb_einheit_4.Wert = _stuetzpunkt.GetAnzahlTruppen((btn_einheit_4.Tag as Einheit).GetType());

            SetzeMaximalerWertTruppenAktion(true);

            _aktuelleAnzahlEinheit1 = nb_einheit_1.Wert;
            _aktuelleAnzahlEinheit2 = nb_einheit_2.Wert;
            _aktuelleAnzahlEinheit3 = nb_einheit_3.Wert;
            _aktuelleAnzahlEinheit4 = nb_einheit_4.Wert;

            nb_aktion_1_zielland.MaximalerWert = SW.Statisch.GetMaxLandID() - 1;
            nb_aktion_1_zielland.MinimalerWert = SW.Statisch.GetMinLandID();
            nb_aktion_1_zielstuetzpunkt.MaximalerWert = SW.Dynamisch.GetStuetzpunkte().Length;
            nb_aktion_1_zielstuetzpunkt.MinimalerWert = 1;

            nb_aktion_2_zielland.MaximalerWert = SW.Statisch.GetMaxLandID() - 1;
            nb_aktion_2_zielland.MinimalerWert = SW.Statisch.GetMinLandID();
            nb_aktion_2_zielstuetzpunkt.MaximalerWert = SW.Dynamisch.GetStuetzpunkte().Length;
            nb_aktion_2_zielstuetzpunkt.MinimalerWert = 1;
        }
        #endregion

        #region frmStuetzpunktVerwalten_MouseDown
        private void frmStuetzpunktVerwalten_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CloseMitSound();
        }
        #endregion

        #region frmStuetzpunktVerwalten_Load
        private void frmStuetzpunktVerwalten_Load(object sender, System.EventArgs e)
        {
            UI.SpielerInfosAnzeigenUndAusrichten(this, true);

            // Controls ausrichten

            // 1. Spalte: links
            btn_sicherheit_tarnung.Left = UI.NormB(btn_sicherheit_tarnung.Left, this.Width);
            btn_sicherheit_tarnung.Top = UI.NormH(btn_sicherheit_tarnung.Top, this.Height);

            btn_einheit_1.Left = UI.NormB(btn_einheit_1.Left, this.Width);
            btn_einheit_1.Top = UI.NormH(btn_einheit_1.Top, this.Height);

            nb_einheit_1.Left = btn_einheit_1.Left + btn_einheit_1.Width / 2 - nb_einheit_1.Width / 2;
            nb_einheit_1.Top = btn_einheit_1.Top + btn_einheit_1.Height + 8;

            // 2. Spalte: halb links
            btn_manoever.Left = (this.Width / 3) + (btn_manoever.Width / 3);  
            btn_manoever.Top = UI.NormH(btn_manoever.Top, this.Height);

            btn_einheit_2.Left = (this.Width / 3) + (btn_einheit_2.Width / 3);
            btn_einheit_2.Top = UI.NormH(btn_einheit_2.Top, this.Height);

            nb_einheit_2.Left = btn_einheit_2.Left + btn_einheit_2.Width / 2 - nb_einheit_2.Width / 2;
            nb_einheit_2.Top = btn_einheit_2.Top + btn_einheit_2.Height + 8;

            // 3. Spalte: halb rechts
            btn_ausbau.Left = (this.Width / 3) * 2 - btn_ausbau.Width / 3;
            btn_ausbau.Top = UI.NormH(btn_ausbau.Top, this.Height);

            btn_einheit_3.Left = (this.Width / 3) * 2 - btn_einheit_3.Width / 3;
            btn_einheit_3.Top = UI.NormH(btn_einheit_3.Top, this.Height);

            nb_einheit_3.Left = btn_einheit_3.Left + btn_einheit_3.Width / 2 - nb_einheit_3.Width / 2;
            nb_einheit_3.Top = btn_einheit_3.Top + btn_einheit_3.Height + 8;

            // 4. Spalte: ganz rechts (rechtsbündig)
            btn_reperatur.Left = this.Width - btn_reperatur.Width - UI.NormB(35, this.Width);
            btn_reperatur.Top = UI.NormH(btn_reperatur.Top, this.Height);

            btn_einheit_4.Left = this.Width - btn_einheit_4.Width - UI.NormB(35, this.Width);
            btn_einheit_4.Top = UI.NormH(btn_einheit_4.Top, this.Height);

            nb_einheit_4.Left = btn_einheit_4.Left + btn_einheit_4.Width / 2 - nb_einheit_4.Width / 2;
            nb_einheit_4.Top = btn_einheit_4.Top + btn_einheit_4.Height + 8;

            // Aktionen
            lbl_aktionsart_1.Top = UI.NormH(590, this.Height);
            lbl_aktionsart_1.Left = this.Width / 22;

            lbl_aktionsart_2.Top = lbl_aktionsart_1.Top + UI.NormH(70, this.Height);
            lbl_aktionsart_2.Left = lbl_aktionsart_1.Left;

            AktionInFormSetzen(1);
            AktionInFormSetzen(2);
        }
        #endregion

        #region frmStuetzpunktVerwalten_Activated
        private void frmStuetzpunktVerwalten_Activated(object sender, System.EventArgs e)
        {
            UI.SpielerInfosAnzeigenUndAusrichten(this, false, _stuetzpunkt.Name, frmStuetzpunktVerwalten_MouseDown);
        }
        #endregion


        #region btn_zoll_Click
        private void btn_zoll_Click(object sender, EventArgs e)
        {
            SW.UI.ProzentwertFestlegenDialog.ShowDialog(ProzentwertArt.ZollsatzZollburg, _stuetzpunktID);
        }
        #endregion

        #region btn_sicherheit_tarnung_Click
        private void btn_sicherheit_tarnung_Click(object sender, EventArgs e)
        {
            SW.UI.ProzentwertFestlegenDialog.ShowDialog(ProzentwertArt.SicherheitTarnungStuetzpunkt, _stuetzpunktID);
        }
        #endregion

        #region btn_ausbau_Click
        private void btn_ausbau_Click(object sender, EventArgs e)
        {
            SW.UI.ProzentwertFestlegenDialog.ShowDialog(ProzentwertArt.KapazitaetStuetzpunkt, _stuetzpunktID);
        }
        #endregion

        #region btn_reperatur_Click
        private void btn_reperatur_Click(object sender, EventArgs e)
        {
            SW.UI.ProzentwertFestlegenDialog.ShowDialog(ProzentwertArt.ZustandStuetzpunkt, _stuetzpunktID);
        }
        #endregion

        #region btn_manoever_Click
        private void btn_manoever_Click(object sender, System.EventArgs e)
        {
            SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].ManoeverDurchfuehrenSpieler();
        }
        #endregion

        #region btn_einheit_1_Click
        private async void btn_einheit_1_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_1.Wert > _aktuelleAnzahlEinheit1)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenAnheuern(nb_einheit_1.Wert - _aktuelleAnzahlEinheit1, (btn_einheit_1.Tag as Einheit).GetType()))
                {
                    _aktuelleAnzahlEinheit1 = nb_einheit_1.Wert;
                    UI.SpielerInfosAnzeigenUndAusrichten(this);  // Taler aktualisieren
                }
                else
                    nb_einheit_1.Wert = _aktuelleAnzahlEinheit1;
            }
            else if (nb_einheit_1.Wert < _aktuelleAnzahlEinheit1)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenEntlassen(_aktuelleAnzahlEinheit1 - nb_einheit_1.Wert, (btn_einheit_1.Tag as Einheit).GetType()))
                    _aktuelleAnzahlEinheit1 = nb_einheit_1.Wert;
                else
                    nb_einheit_1.Wert = _aktuelleAnzahlEinheit1;
            }

            SetzeMaximalerWertTruppenAktion();
        }
        #endregion

        #region btn_einheit_2_Click
        private async void btn_einheit_2_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_2.Wert > _aktuelleAnzahlEinheit2)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenAnheuern(nb_einheit_2.Wert - _aktuelleAnzahlEinheit2, (btn_einheit_2.Tag as Einheit).GetType()))
                {
                    _aktuelleAnzahlEinheit2 = nb_einheit_2.Wert;
                    UI.SpielerInfosAnzeigenUndAusrichten(this);  // Taler aktualisieren
                }
                else
                    nb_einheit_2.Wert = _aktuelleAnzahlEinheit2;
            }
            else if (nb_einheit_2.Wert < _aktuelleAnzahlEinheit2)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenEntlassen(_aktuelleAnzahlEinheit2 - nb_einheit_2.Wert, (btn_einheit_2.Tag as Einheit).GetType()))
                    _aktuelleAnzahlEinheit2 = nb_einheit_2.Wert;
                else
                    nb_einheit_2.Wert = _aktuelleAnzahlEinheit2;
            }

            SetzeMaximalerWertTruppenAktion();
        }
        #endregion

        #region btn_einheit_3_Click
        private async void btn_einheit_3_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_3.Wert > _aktuelleAnzahlEinheit3)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenAnheuern(nb_einheit_3.Wert - _aktuelleAnzahlEinheit3, (btn_einheit_3.Tag as Einheit).GetType()))
                {
                    _aktuelleAnzahlEinheit3 = nb_einheit_3.Wert;
                    UI.SpielerInfosAnzeigenUndAusrichten(this);  // Taler aktualisieren
                }
                else
                    nb_einheit_3.Wert = _aktuelleAnzahlEinheit3;
            }
            else if (nb_einheit_3.Wert < _aktuelleAnzahlEinheit3)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenEntlassen(_aktuelleAnzahlEinheit3 - nb_einheit_3.Wert, (btn_einheit_3.Tag as Einheit).GetType()))
                    _aktuelleAnzahlEinheit3 = nb_einheit_3.Wert;
                else
                    nb_einheit_3.Wert = _aktuelleAnzahlEinheit3;
            }

            SetzeMaximalerWertTruppenAktion();
        }
        #endregion

        #region btn_einheit_4_Click
        private async void btn_einheit_4_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_4.Wert > _aktuelleAnzahlEinheit4)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenAnheuern(nb_einheit_4.Wert - _aktuelleAnzahlEinheit4, (btn_einheit_4.Tag as Einheit).GetType()))
                {
                    _aktuelleAnzahlEinheit4 = nb_einheit_4.Wert;
                    UI.SpielerInfosAnzeigenUndAusrichten(this);  // Taler aktualisieren
                }
                else
                    nb_einheit_4.Wert = _aktuelleAnzahlEinheit4;
            }
            else if (nb_einheit_4.Wert < _aktuelleAnzahlEinheit4)
            {
                if (await SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].TruppenEntlassen(_aktuelleAnzahlEinheit4 - nb_einheit_4.Wert, (btn_einheit_4.Tag as Einheit).GetType()))
                    _aktuelleAnzahlEinheit4 = nb_einheit_4.Wert;
                else
                    nb_einheit_4.Wert = _aktuelleAnzahlEinheit4;
            }

            SetzeMaximalerWertTruppenAktion();
        }
        #endregion


        #region nb_einheit_1_Click
        private void nb_einheit_1_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_1.Wert > _aktuelleAnzahlEinheit1)
                ttButtons.SetToolTip(btn_einheit_1, ((Einheit)btn_einheit_1.Tag).NamePlural + " anheuern");
            else if (nb_einheit_1.Wert < _aktuelleAnzahlEinheit1)
                ttButtons.SetToolTip(btn_einheit_1, ((Einheit)btn_einheit_1.Tag).NamePlural + " entlassen");
            else
                ttButtons.SetToolTip(btn_einheit_1, ((Einheit)btn_einheit_1.Tag).NamePlural);
        }

        #endregion

        #region nb_einheit_2_Click
        private void nb_einheit_2_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_2.Wert > _aktuelleAnzahlEinheit2)
                ttButtons.SetToolTip(btn_einheit_2, ((Einheit)btn_einheit_2.Tag).NamePlural + " anheuern");
            else if (nb_einheit_2.Wert < _aktuelleAnzahlEinheit2)
                ttButtons.SetToolTip(btn_einheit_2, ((Einheit)btn_einheit_2.Tag).NamePlural + " entlassen");
            else
                ttButtons.SetToolTip(btn_einheit_2, ((Einheit)btn_einheit_2.Tag).NamePlural);
        }
        #endregion

        #region nb_einheit_3_Click
        private void nb_einheit_3_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_3.Wert > _aktuelleAnzahlEinheit3)
                ttButtons.SetToolTip(btn_einheit_3, ((Einheit)btn_einheit_3.Tag).NamePlural + " anheuern");
            else if (nb_einheit_3.Wert < _aktuelleAnzahlEinheit3)
                ttButtons.SetToolTip(btn_einheit_3, ((Einheit)btn_einheit_3.Tag).NamePlural + " entlassen");
            else
                ttButtons.SetToolTip(btn_einheit_3, ((Einheit)btn_einheit_3.Tag).NamePlural);
        }
        #endregion

        #region nb_einheit_4_Click
        private void nb_einheit_4_Click(object sender, System.EventArgs e)
        {
            if (nb_einheit_4.Wert > _aktuelleAnzahlEinheit4)
                ttButtons.SetToolTip(btn_einheit_4, ((Einheit)btn_einheit_4.Tag).NamePlural + " anheuern");
            else if (nb_einheit_4.Wert < _aktuelleAnzahlEinheit4)
                ttButtons.SetToolTip(btn_einheit_4, ((Einheit)btn_einheit_4.Tag).NamePlural + " entlassen");
            else
                ttButtons.SetToolTip(btn_einheit_4, ((Einheit)btn_einheit_4.Tag).NamePlural);
        }
        #endregion

        #region lbl_aktionsart_1_Click
        private void lbl_aktionsart_1_Click(object sender, EventArgs e)
        {
            AktionInFormSetzen(1, true);
        }
        #endregion

        #region lbl_aktionsart_2_Click
        private void lbl_aktionsart_2_Click(object sender, EventArgs e)
        {
            AktionInFormSetzen(2, true);
        }
        #endregion

        #region nb_aktion_1_zielland_Click
        private void nb_aktion_1_zielland_Click(object sender, EventArgs e)
        {
            if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].ZielLandID == nb_aktion_1_zielland.Wert) && (nb_aktion_1_zielland.Wert == nb_aktion_1_zielland.MaximalerWert))
                nb_aktion_1_zielland.Wert = nb_aktion_1_zielland.MinimalerWert;
            else if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].ZielLandID == nb_aktion_1_zielland.Wert) && (nb_aktion_1_zielland.Wert == nb_aktion_1_zielland.MinimalerWert))
                nb_aktion_1_zielland.Wert = nb_aktion_1_zielland.MaximalerWert;

            nb_aktion_1_zielland.Text = SW.Dynamisch.GetLandWithID(nb_aktion_1_zielland.Wert).GetGebietsName();
            SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].ZielLandID = nb_aktion_1_zielland.Wert;
            AktionAusrichten(1);
        }
        #endregion

        #region nb_aktion_2_zielland_Click
        private void nb_aktion_2_zielland_Click(object sender, EventArgs e)
        {
            if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].ZielLandID == nb_aktion_2_zielland.Wert) && (nb_aktion_2_zielland.Wert == nb_aktion_2_zielland.MaximalerWert))
                nb_aktion_2_zielland.Wert = nb_aktion_2_zielland.MinimalerWert;
            else if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].ZielLandID == nb_aktion_2_zielland.Wert) && (nb_aktion_2_zielland.Wert == nb_aktion_2_zielland.MinimalerWert))
                nb_aktion_2_zielland.Wert = nb_aktion_2_zielland.MaximalerWert;

            nb_aktion_2_zielland.Text = SW.Dynamisch.GetLandWithID(nb_aktion_2_zielland.Wert).GetGebietsName();
            SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].ZielLandID = nb_aktion_2_zielland.Wert;
            AktionAusrichten(2);
        }
        #endregion

        #region nb_aktion_1_zielstuetzpunkt_Click
        private void nb_aktion_1_zielstuetzpunkt_Click(object sender, EventArgs e)
        {
            if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].ZielStuetzpunktID == nb_aktion_1_zielstuetzpunkt.Wert) && (nb_aktion_1_zielstuetzpunkt.Wert == nb_aktion_1_zielstuetzpunkt.MaximalerWert))
                nb_aktion_1_zielstuetzpunkt.Wert = nb_aktion_1_zielstuetzpunkt.MinimalerWert;
            else if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].ZielStuetzpunktID == nb_aktion_1_zielstuetzpunkt.Wert) && (nb_aktion_1_zielstuetzpunkt.Wert == nb_aktion_1_zielstuetzpunkt.MinimalerWert))
                nb_aktion_1_zielstuetzpunkt.Wert = nb_aktion_1_zielstuetzpunkt.MaximalerWert;

            nb_aktion_1_zielstuetzpunkt.Text = SW.Dynamisch.GetStuetzpunkte()[nb_aktion_1_zielstuetzpunkt.Wert - 1].Name;
            SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].ZielStuetzpunktID = nb_aktion_1_zielstuetzpunkt.Wert;
            AktionAusrichten(1);
        }
        #endregion

        #region nb_aktion_2_zielstuetzpunkt_Click
        private void nb_aktion_2_zielstuetzpunkt_Click(object sender, EventArgs e)
        {
            if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].ZielStuetzpunktID == nb_aktion_2_zielstuetzpunkt.Wert) && (nb_aktion_2_zielstuetzpunkt.Wert == nb_aktion_2_zielstuetzpunkt.MaximalerWert))
                nb_aktion_2_zielstuetzpunkt.Wert = nb_aktion_2_zielstuetzpunkt.MinimalerWert;
            else if ((SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].ZielStuetzpunktID == nb_aktion_2_zielstuetzpunkt.Wert) && (nb_aktion_2_zielstuetzpunkt.Wert == nb_aktion_2_zielstuetzpunkt.MinimalerWert))
                nb_aktion_2_zielstuetzpunkt.Wert = nb_aktion_2_zielstuetzpunkt.MaximalerWert;

            nb_aktion_2_zielstuetzpunkt.Text = SW.Dynamisch.GetStuetzpunkte()[nb_aktion_2_zielstuetzpunkt.Wert - 1].Name;
            SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].ZielStuetzpunktID = nb_aktion_2_zielstuetzpunkt.Wert;
            AktionAusrichten(2);
        }
        #endregion

        #region nb_aktion_1_einheit_1_Click
        private void nb_aktion_1_einheit_1_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(0, nb_aktion_1_einheit_1);
        }
        #endregion

        #region nb_aktion_1_einheit_2_Click
        private void nb_aktion_1_einheit_2_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(0, nb_aktion_1_einheit_2);
        }
        #endregion

        #region nb_aktion_1_einheit_3_Click
        private void nb_aktion_1_einheit_3_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(0, nb_aktion_1_einheit_3);
        }
        #endregion

        #region nb_aktion_1_einheit_4_Click
        private void nb_aktion_1_einheit_4_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(0, nb_aktion_1_einheit_4);
        }
        #endregion

        #region nb_aktion_2_einheit_1_Click
        private void nb_aktion_2_einheit_1_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(1, nb_aktion_2_einheit_1);
        }
        #endregion

        #region nb_aktion_2_einheit_2_Click
        private void nb_aktion_2_einheit_2_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(1, nb_aktion_2_einheit_2);
        }
        #endregion

        #region nb_aktion_2_einheit_3_Click
        private void nb_aktion_2_einheit_3_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(1, nb_aktion_2_einheit_3);
        }
        #endregion

        #region nb_aktion_2_einheit_4_Click
        private void nb_aktion_2_einheit_4_Click(object sender, EventArgs e)
        {
            AktualisiereEinheitInAktion(1, nb_aktion_2_einheit_4);
        }
        #endregion


        #region AktionAusrichten
        private void AktionAusrichten(int Nummer)
        {
            StuetzpunktAktion AktuelleAktion = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[Nummer - 1];
            string Text = "";
            string[] Textabschnitte;
            int Zaehler = 1;
            int AktuellerWertLeft = 0;
            int AktuellerWertTop = 0;

            if ((AktuelleAktion != null) && (Convert.ToInt32((Controls["lbl_aktionsart_" + Nummer] as Label).Tag) != 0))
            {
                (Controls["lbl_aktion_" + Nummer + "_text_1"] as Label).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_text_2"] as Label).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_text_3"] as Label).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Visible = false;

                if (_stuetzpunkt.Art == EnumStuetzpunktArt.Zollburg)
                    Text = ((ZollburgAktion)AktuelleAktion).getAktionText();  // z.B.: Überwacht |{ZielLand} mit |{Truppen} Truppen
                else if (_stuetzpunkt.Art == EnumStuetzpunktArt.Raeuberlager)
                    Text = ((RaeuberlagerAktion)AktuelleAktion).GetAktionText();  // z.B.: Plündert |{ZielLand} mit |{Truppen} Truppen

                Textabschnitte = Text.Split('|');

                foreach (string Abschnitt in Textabschnitte)
                {
                    string AktuellerText = Abschnitt;

                    if (Zaehler == 1)
                    {
                        AktuellerWertLeft = Controls["lbl_aktionsart_" + Nummer].Left + 30;
                        AktuellerWertTop = Controls["lbl_aktionsart_" + Nummer].Top + Controls["lbl_aktionsart_" + Nummer].Height - UI.NormH(5, this.Height);
                    }

                    if (Abschnitt.Contains("{ZielLand}"))
                    {
                        AktuellerText = Abschnitt.Replace("{ZielLand}", "");

                        (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Wert = AktuelleAktion.ZielLandID;
                        (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Left = AktuellerWertLeft;
                        (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Top = AktuellerWertTop - 5;
                        (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Visible = true;

                        AktuellerWertLeft += (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Width;
                    }

                    if (Abschnitt.Contains("{ZielStuetzpunkt}"))
                    {
                        AktuellerText = Abschnitt.Replace("{ZielStuetzpunkt}", "");

                        (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Wert = AktuelleAktion.ZielStuetzpunktID;
                        (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Left = AktuellerWertLeft;
                        (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Top = AktuellerWertTop - 5;
                        (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Visible = true;

                        AktuellerWertLeft += (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Width;
                    }

                    if (Abschnitt.Contains("{Truppen}"))
                    {
                        AktuellerText = Abschnitt.Replace("{Truppen}", "");

                        (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Wert = _kampf.GetAnzahlEinheit(AktuelleAktion.Einheiten, (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Tag.GetType());
                        (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Left = AktuellerWertLeft;
                        (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Top = AktuellerWertTop - 5;
                        (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Visible = true;

                        AktuellerWertLeft += (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Width;

                        (Controls["lbl_aktion_" + Nummer + "_plus_1"] as Label).Left = AktuellerWertLeft;
                        (Controls["lbl_aktion_" + Nummer + "_plus_1"] as Label).Top = AktuellerWertTop + 1;
                        (Controls["lbl_aktion_" + Nummer + "_plus_1"] as Label).Visible = true;

                        AktuellerWertLeft += (Controls["lbl_aktion_" + Nummer + "_plus_1"] as Label).Width;

                        (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Wert = _kampf.GetAnzahlEinheit(AktuelleAktion.Einheiten, (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Tag.GetType());
                        (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Left = AktuellerWertLeft;
                        (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Top = AktuellerWertTop - 5;
                        (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Visible = true;

                        AktuellerWertLeft += (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Width;

                        (Controls["lbl_aktion_" + Nummer + "_plus_2"] as Label).Left = AktuellerWertLeft;
                        (Controls["lbl_aktion_" + Nummer + "_plus_2"] as Label).Top = AktuellerWertTop + 1;
                        (Controls["lbl_aktion_" + Nummer + "_plus_2"] as Label).Visible = true;

                        AktuellerWertLeft += (Controls["lbl_aktion_" + Nummer + "_plus_2"] as Label).Width;

                        (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Wert = _kampf.GetAnzahlEinheit(AktuelleAktion.Einheiten, (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Tag.GetType());
                        (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Left = AktuellerWertLeft;
                        (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Top = AktuellerWertTop - 5;
                        (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Visible = true;

                        AktuellerWertLeft += (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Width;

                        (Controls["lbl_aktion_" + Nummer + "_plus_3"] as Label).Left = AktuellerWertLeft;
                        (Controls["lbl_aktion_" + Nummer + "_plus_3"] as Label).Top = AktuellerWertTop + 1;
                        (Controls["lbl_aktion_" + Nummer + "_plus_3"] as Label).Visible = true;

                        AktuellerWertLeft += (Controls["lbl_aktion_" + Nummer + "_plus_3"] as Label).Width;

                        (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Wert = _kampf.GetAnzahlEinheit(AktuelleAktion.Einheiten, (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Tag.GetType());
                        (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Left = AktuellerWertLeft;
                        (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Top = AktuellerWertTop - 5;
                        (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Visible = true;

                        AktuellerWertLeft += (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Width;
                    }

                    (Controls["lbl_aktion_" + Nummer + "_text_" + Zaehler] as Label).Text = AktuellerText;
                    (Controls["lbl_aktion_" + Nummer + "_text_" + Zaehler] as Label).Left = AktuellerWertLeft;  // + 5;
                    (Controls["lbl_aktion_" + Nummer + "_text_" + Zaehler] as Label).Top = AktuellerWertTop;
                    (Controls["lbl_aktion_" + Nummer + "_text_" + Zaehler] as Label).Visible = true;

                    AktuellerWertLeft += (Controls["lbl_aktion_" + Nummer + "_text_" + Zaehler] as Label).Width;

                    Zaehler++;
                }
            }
            else
            {
                // Keine Aktion aktiv
                (Controls["lbl_aktion_" + Nummer + "_text_1"] as Label).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_text_2"] as Label).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_text_3"] as Label).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_zielland"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_zielstuetzpunkt"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_1"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_2"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_3"] as NumericButton).Visible = false;
                (Controls["nb_aktion_" + Nummer + "_einheit_4"] as NumericButton).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_plus_1"] as Label).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_plus_2"] as Label).Visible = false;
                (Controls["lbl_aktion_" + Nummer + "_plus_3"] as Label).Visible = false;
            }
        }
        #endregion

        #region AktionInFormSetzen
        private void AktionInFormSetzen(int AktionNummer, bool AktionsartAenderung = false)
        {
            if (_stuetzpunkt.Art == EnumStuetzpunktArt.Zollburg)
            {
                EnumAktionsartZollburg Aktionsart = EnumAktionsartZollburg.Kein_Auftrag;
                SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).AktionenInitialisieren();

                if ((SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1] == null) || (AktionsartAenderung))
                    SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1] = new ZollburgAktion(Aktionsart, SW.Statisch.GetMinLandID(), 1, _stuetzpunktID, AktionNummer - 1, new List<Einheit>());

                if (AktionsartAenderung)
                {
                    if ((Convert.ToInt32(Controls["lbl_aktionsart_" + AktionNummer].Tag) + 1) >= Enum.GetValues(typeof(EnumAktionsartZollburg)).Length)
                        Controls["lbl_aktionsart_" + AktionNummer].Tag = 0;
                    else
                        Controls["lbl_aktionsart_" + AktionNummer].Tag = Convert.ToInt32(Controls["lbl_aktionsart_" + AktionNummer].Tag) + 1;
                }
                else
                    Controls["lbl_aktionsart_" + AktionNummer].Tag = Convert.ToInt32(((ZollburgAktion)SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1]).Aktionsart);

                Aktionsart = (EnumAktionsartZollburg)Enum.ToObject(typeof(EnumAktionsartZollburg), Convert.ToInt32(Controls["lbl_aktionsart_" + AktionNummer].Tag));
                ((ZollburgAktion)SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1]).Aktionsart = Aktionsart;

                Controls["lbl_aktionsart_" + AktionNummer].Text = Aktionsart.ToString().Replace("_", " ");

                (Controls["nb_aktion_" + AktionNummer + "_zielland"] as NumericButton).Wert = SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].ZielLandID;
                (Controls["nb_aktion_" + AktionNummer + "_zielland"] as NumericButton).Text = SW.Dynamisch.GetLandWithID((Controls["nb_aktion_" + AktionNummer + "_zielland"] as NumericButton).Wert).GetGebietsName();

                (Controls["nb_aktion_" + AktionNummer + "_zielstuetzpunkt"] as NumericButton).Wert = SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].ZielStuetzpunktID;
                (Controls["nb_aktion_" + AktionNummer + "_zielstuetzpunkt"] as NumericButton).Text = SW.Dynamisch.GetStuetzpunkte()[(Controls["nb_aktion_" + AktionNummer + "_zielstuetzpunkt"] as NumericButton).Wert - 1].Name;

                // Truppen setzen
                (Controls["nb_aktion_" + AktionNummer + "_einheit_1"] as NumericButton).Wert = SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_1"] as NumericButton).Tag.GetType());
                (Controls["nb_aktion_" + AktionNummer + "_einheit_2"] as NumericButton).Wert = SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_2"] as NumericButton).Tag.GetType());
                (Controls["nb_aktion_" + AktionNummer + "_einheit_3"] as NumericButton).Wert = SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_3"] as NumericButton).Tag.GetType());
                (Controls["nb_aktion_" + AktionNummer + "_einheit_4"] as NumericButton).Wert = SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_4"] as NumericButton).Tag.GetType());

                AktionAusrichten(AktionNummer);
            }
            else if (_stuetzpunkt.Art == EnumStuetzpunktArt.Raeuberlager)
            {
                EnumAktionsartRaeuberlager Aktionsart = EnumAktionsartRaeuberlager.Kein_Auftrag;
                SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).AktionenInitialisieren();

                if ((SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1] == null) || (AktionsartAenderung))
                    SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1] = new RaeuberlagerAktion(Aktionsart, SW.Statisch.GetMinLandID(), 1, _stuetzpunktID, AktionNummer - 1, new List<Einheit>());

                if (AktionsartAenderung)
                {
                    if ((Convert.ToInt32(Controls["lbl_aktionsart_" + AktionNummer].Tag) + 1) >= Enum.GetValues(typeof(EnumAktionsartRaeuberlager)).Length)
                        Controls["lbl_aktionsart_" + AktionNummer].Tag = 0;
                    else
                        Controls["lbl_aktionsart_" + AktionNummer].Tag = Convert.ToInt32(Controls["lbl_aktionsart_" + AktionNummer].Tag) + 1;
                }
                else
                    Controls["lbl_aktionsart_" + AktionNummer].Tag = Convert.ToInt32(((RaeuberlagerAktion)SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1]).Aktionsart);

                Aktionsart = (EnumAktionsartRaeuberlager)Enum.ToObject(typeof(EnumAktionsartRaeuberlager), Convert.ToInt32(Controls["lbl_aktionsart_" + AktionNummer].Tag));
                ((RaeuberlagerAktion)SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1]).Aktionsart = Aktionsart;

                Controls["lbl_aktionsart_" + AktionNummer].Text = Aktionsart.ToString().Replace("_", " ");

                (Controls["nb_aktion_" + AktionNummer + "_zielland"] as NumericButton).Wert = SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].ZielLandID;
                (Controls["nb_aktion_" + AktionNummer + "_zielland"] as NumericButton).Text = SW.Dynamisch.GetLandWithID((Controls["nb_aktion_" + AktionNummer + "_zielland"] as NumericButton).Wert).GetGebietsName();

                (Controls["nb_aktion_" + AktionNummer + "_zielstuetzpunkt"] as NumericButton).Wert = SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].ZielStuetzpunktID;
                (Controls["nb_aktion_" + AktionNummer + "_zielstuetzpunkt"] as NumericButton).Text = SW.Dynamisch.GetStuetzpunkte()[(Controls["nb_aktion_" + AktionNummer + "_zielstuetzpunkt"] as NumericButton).Wert - 1].Name;

                // Truppen setzen
                (Controls["nb_aktion_" + AktionNummer + "_einheit_1"] as NumericButton).Wert = SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_1"] as NumericButton).Tag.GetType());
                (Controls["nb_aktion_" + AktionNummer + "_einheit_2"] as NumericButton).Wert = SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_2"] as NumericButton).Tag.GetType());
                (Controls["nb_aktion_" + AktionNummer + "_einheit_3"] as NumericButton).Wert = SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_3"] as NumericButton).Tag.GetType());
                (Controls["nb_aktion_" + AktionNummer + "_einheit_4"] as NumericButton).Wert = SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).Aktionen[AktionNummer - 1].GetAnzahlTruppen((Controls["nb_aktion_" + AktionNummer + "_einheit_4"] as NumericButton).Tag.GetType());

                AktionAusrichten(AktionNummer);
            }
        }
        #endregion

        #region SetzeMaximalerWertTruppenAktion
        private void SetzeMaximalerWertTruppenAktion(bool ErsteInitialisierung = false)
        {
            int AnzahlEinheit1Aktion1 = 0;
            int AnzahlEinheit2Aktion1 = 0;
            int AnzahlEinheit3Aktion1 = 0;
            int AnzahlEinheit4Aktion1 = 0;
            int AnzahlEinheit1Aktion2 = 0;
            int AnzahlEinheit2Aktion2 = 0;
            int AnzahlEinheit3Aktion2 = 0;
            int AnzahlEinheit4Aktion2 = 0;

            if (_stuetzpunkt.Art == EnumStuetzpunktArt.Zollburg)
            {
                SW.Dynamisch.GetZollburgWithIDx(_stuetzpunktIndex).AktionenInitialisieren();

                nb_aktion_1_einheit_1.Tag = new ZollSoeldner();
                nb_aktion_1_einheit_2.Tag = new ZollMusketier();
                nb_aktion_1_einheit_3.Tag = new ZollKanonier();
                nb_aktion_1_einheit_4.Tag = new ZollOffizier();

                nb_aktion_2_einheit_1.Tag = new ZollSoeldner();
                nb_aktion_2_einheit_2.Tag = new ZollMusketier();
                nb_aktion_2_einheit_3.Tag = new ZollKanonier();
                nb_aktion_2_einheit_4.Tag = new ZollOffizier();
            }
            else if (_stuetzpunkt.Art == EnumStuetzpunktArt.Raeuberlager)
            {
                SW.Dynamisch.GetRaeuberlagerWithIDx(_stuetzpunktIndex).AktionenInitialisieren();

                nb_aktion_1_einheit_1.Tag = new RaubRaeuber();
                nb_aktion_1_einheit_2.Tag = new RaubBombenleger();
                nb_aktion_1_einheit_3.Tag = new RaubKanonier();
                nb_aktion_1_einheit_4.Tag = new RaubSchuetze();

                nb_aktion_2_einheit_1.Tag = new RaubRaeuber();
                nb_aktion_2_einheit_2.Tag = new RaubBombenleger();
                nb_aktion_2_einheit_3.Tag = new RaubKanonier();
                nb_aktion_2_einheit_4.Tag = new RaubSchuetze();
            }

            if (SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0] != null)
            {
                AnzahlEinheit1Aktion1 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].Einheiten, nb_aktion_1_einheit_1.Tag.GetType());
                AnzahlEinheit2Aktion1 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].Einheiten, nb_aktion_1_einheit_2.Tag.GetType());
                AnzahlEinheit3Aktion1 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].Einheiten, nb_aktion_1_einheit_3.Tag.GetType());
                AnzahlEinheit4Aktion1 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].Einheiten, nb_aktion_1_einheit_4.Tag.GetType());
            }

            if (SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1] != null)
            {
                AnzahlEinheit1Aktion2 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].Einheiten, nb_aktion_2_einheit_1.Tag.GetType());
                AnzahlEinheit2Aktion2 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].Einheiten, nb_aktion_2_einheit_2.Tag.GetType());
                AnzahlEinheit3Aktion2 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].Einheiten, nb_aktion_2_einheit_3.Tag.GetType());
                AnzahlEinheit4Aktion2 = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].Einheiten, nb_aktion_2_einheit_4.Tag.GetType());
            }

            nb_aktion_1_einheit_1.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_1_einheit_1.Tag.GetType()) - AnzahlEinheit1Aktion2;
            nb_aktion_1_einheit_2.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_1_einheit_2.Tag.GetType()) - AnzahlEinheit2Aktion2;
            nb_aktion_1_einheit_3.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_1_einheit_3.Tag.GetType()) - AnzahlEinheit3Aktion2;
            nb_aktion_1_einheit_4.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_1_einheit_4.Tag.GetType()) - AnzahlEinheit4Aktion2;

            nb_aktion_2_einheit_1.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_2_einheit_1.Tag.GetType()) - AnzahlEinheit1Aktion1;
            nb_aktion_2_einheit_2.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_2_einheit_2.Tag.GetType()) - AnzahlEinheit2Aktion1;
            nb_aktion_2_einheit_3.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_2_einheit_3.Tag.GetType()) - AnzahlEinheit3Aktion1;
            nb_aktion_2_einheit_4.MaximalerWert = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].GetAnzahlTruppen(nb_aktion_2_einheit_4.Tag.GetType()) - AnzahlEinheit4Aktion1; 

            if (!ErsteInitialisierung)
            {
                // Hat sich die Truppenanzahl durch Veränderung des Maximalwertes verändert? Dann aktualisiere die Anzahl in der Aktion
                if (nb_aktion_1_einheit_1.Wert < AnzahlEinheit1Aktion1)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].VerringereTruppen(AnzahlEinheit1Aktion1 - nb_aktion_1_einheit_1.Wert, nb_aktion_1_einheit_1.Tag.GetType());

                if (nb_aktion_1_einheit_2.Wert < AnzahlEinheit2Aktion1)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].VerringereTruppen(AnzahlEinheit2Aktion1 - nb_aktion_1_einheit_2.Wert, nb_aktion_1_einheit_2.Tag.GetType());

                if (nb_aktion_1_einheit_3.Wert < AnzahlEinheit3Aktion1)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].VerringereTruppen(AnzahlEinheit3Aktion1 - nb_aktion_1_einheit_3.Wert, nb_aktion_1_einheit_3.Tag.GetType());

                if (nb_aktion_1_einheit_4.Wert < AnzahlEinheit4Aktion1)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[0].VerringereTruppen(AnzahlEinheit4Aktion1 - nb_aktion_1_einheit_4.Wert, nb_aktion_1_einheit_4.Tag.GetType());

                if (nb_aktion_2_einheit_1.Wert < AnzahlEinheit1Aktion2)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].VerringereTruppen(AnzahlEinheit1Aktion2 - nb_aktion_2_einheit_1.Wert, nb_aktion_2_einheit_1.Tag.GetType());

                if (nb_aktion_2_einheit_2.Wert < AnzahlEinheit2Aktion2)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].VerringereTruppen(AnzahlEinheit2Aktion2 - nb_aktion_2_einheit_2.Wert, nb_aktion_2_einheit_2.Tag.GetType());

                if (nb_aktion_2_einheit_3.Wert < AnzahlEinheit3Aktion2)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].VerringereTruppen(AnzahlEinheit3Aktion2 - nb_aktion_2_einheit_3.Wert, nb_aktion_2_einheit_3.Tag.GetType());

                if (nb_aktion_2_einheit_4.Wert < AnzahlEinheit4Aktion2)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[1].VerringereTruppen(AnzahlEinheit4Aktion2 - nb_aktion_2_einheit_4.Wert, nb_aktion_2_einheit_4.Tag.GetType());
            }
        }
        #endregion

        #region AktualisiereEinheitInAktion
        private void AktualisiereEinheitInAktion(int AktionIndex, NumericButton ButtonEinheit)
        {
            if (SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[AktionIndex] != null)
            {
                int AnzahlEinheitVorher = _kampf.GetAnzahlEinheit(SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[AktionIndex].Einheiten, ButtonEinheit.Tag.GetType());

                if (ButtonEinheit.Wert > AnzahlEinheitVorher)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[AktionIndex].ErhoeheTruppen(ButtonEinheit.Wert - AnzahlEinheitVorher, ButtonEinheit.Tag.GetType());
                else if (ButtonEinheit.Wert < AnzahlEinheitVorher)
                    SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktIndex].Aktionen[AktionIndex].VerringereTruppen(AnzahlEinheitVorher - ButtonEinheit.Wert, ButtonEinheit.Tag.GetType());

                SetzeMaximalerWertTruppenAktion();
            }
        }
        #endregion
    }
}