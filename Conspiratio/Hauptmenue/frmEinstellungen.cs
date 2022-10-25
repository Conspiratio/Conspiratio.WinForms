using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Einstellungen;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Musik;

namespace Conspiratio.Hauptmenue
{
    public partial class frmEinstellungen : frmBasis
    {
        private MusicAndSoundPlayer _musicPlayer = null;

        #region Konstruktor frmEinstellungen
        public frmEinstellungen(ref MusicAndSoundPlayer oC_MusikInstanz)
        {
            InitializeComponent();

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            lbl_ueberschrift.Left = this.Width / 2 - lbl_ueberschrift.Width / 2;

            _musicPlayer = oC_MusikInstanz;
        }
        #endregion

        #region frmEinstellungen_Load
        private void frmEinstellungen_Load(object sender, EventArgs e)
        {
            // Einstellungen auslesen
            btn_musik_ausschalten.Checked = Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]);
            btn_tipps_anzeigen.Checked = Convert.ToBoolean(Properties.Settings.Default["Tipp_anzeigen"]);
            btn_statistik_anzeigen.Checked = Convert.ToBoolean(Properties.Settings.Default["Statistik_anzeigen"]);

            trb_musik_lautstaerke.Value = Convert.ToInt32(Properties.Settings.Default["Musik_Lautstaerke"]);
            trb_effekt_lautstaerke.Value = Convert.ToInt32(Properties.Settings.Default["Sound_Lautstaerke"]);
            trb_musik_lautstaerke_Scroll(this, new EventArgs());  // Label aktualisieren
            trb_effekt_lautstaerke_Scroll(this, new EventArgs());  // Label aktualisieren

            switch (SW.Dynamisch.Spielstand.Einstellungen.AggressivitaetKISpieler)
            {
                case EnumSchwierigkeitsgrad.Niedrig:
                    btn_aggressivitaet_niedrig.Checked = true;
                    btn_aggressivitaet_mittel.Checked = false;
                    btn_aggressivitaet_hoch.Checked = false;
                    break;
                case EnumSchwierigkeitsgrad.Mittel:
                    btn_aggressivitaet_niedrig.Checked = false;
                    btn_aggressivitaet_mittel.Checked = true;
                    btn_aggressivitaet_hoch.Checked = false;
                    break;
                case EnumSchwierigkeitsgrad.Hoch:
                    btn_aggressivitaet_niedrig.Checked = false;
                    btn_aggressivitaet_mittel.Checked = false;
                    btn_aggressivitaet_hoch.Checked = true;
                    break;
            }
        }
        #endregion

        #region frmEinstellungen_MouseDown
        private void frmEinstellungen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
        #endregion

        #region frmEinstellungen_FormClosing
        private void frmEinstellungen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Einstellungen speichern
            Properties.Settings.Default["Musik_ausschalten"] = btn_musik_ausschalten.Checked;
            Properties.Settings.Default["Tipp_anzeigen"] = btn_tipps_anzeigen.Checked;
            Properties.Settings.Default["Statistik_anzeigen"] = btn_statistik_anzeigen.Checked;
            Properties.Settings.Default["Musik_Lautstaerke"] = trb_musik_lautstaerke.Value;
            Properties.Settings.Default["Sound_Lautstaerke"] = trb_effekt_lautstaerke.Value;

            Properties.Settings.Default.Save(); // Settings in application configuration file speichern
        }
        #endregion

        #region trb_musik_lautstaerke_Scroll
        private void trb_musik_lautstaerke_Scroll(object sender, EventArgs e)
        {
            lbl_musik_lautstaerke.Text = "Musik Lautstärke - " + trb_musik_lautstaerke.Value + " %";
            _musicPlayer.MusikLautstaerke = trb_musik_lautstaerke.Value;
        }
        #endregion

        #region trb_effekt_lautstaerke_Scroll
        private void trb_effekt_lautstaerke_Scroll(object sender, EventArgs e)
        {
            lbl_effekt_lautstaerke.Text = "Effekt Lautstärke - " + trb_effekt_lautstaerke.Value + " %";
            _musicPlayer.SoundLautstaerke = trb_effekt_lautstaerke.Value;
        }
        #endregion

        private void btn_aggressivitaet_niedrig_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.Spielstand.Einstellungen.AggressivitaetKISpieler = EnumSchwierigkeitsgrad.Niedrig;
            btn_aggressivitaet_niedrig.Checked = true;
            btn_aggressivitaet_mittel.Checked = false;
            btn_aggressivitaet_hoch.Checked = false;
        }

        private void btn_aggressivitaet_mittel_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.Spielstand.Einstellungen.AggressivitaetKISpieler = EnumSchwierigkeitsgrad.Mittel;
            btn_aggressivitaet_niedrig.Checked = false;
            btn_aggressivitaet_mittel.Checked = true;
            btn_aggressivitaet_hoch.Checked = false;
        }

        private void btn_aggressivitaet_hoch_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.Spielstand.Einstellungen.AggressivitaetKISpieler = EnumSchwierigkeitsgrad.Hoch;
            btn_aggressivitaet_niedrig.Checked = false;
            btn_aggressivitaet_mittel.Checked = false;
            btn_aggressivitaet_hoch.Checked = true;
        }
    }
}