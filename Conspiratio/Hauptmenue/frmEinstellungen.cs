using System;
using System.Collections.Generic;
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
        private SoundQueuePlayer player = new SoundQueuePlayer();

        public frmEinstellungen(ref MusicAndSoundPlayer musicPlayer)
        {
            InitializeComponent();

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            lbl_ueberschrift.Left = this.Width / 2 - lbl_ueberschrift.Width / 2;

            _musicPlayer = musicPlayer;
        }

        private void frmEinstellungen_Load(object sender, EventArgs e)
        {
            // Einstellungen auslesen
            btn_musik_ausschalten.Checked = Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]);
            btn_tipps_anzeigen.Checked = Convert.ToBoolean(Properties.Settings.Default["Tipp_anzeigen"]);
            btn_statistik_anzeigen.Checked = Convert.ToBoolean(Properties.Settings.Default["Statistik_anzeigen"]);
            btn_stuetzpunktereignisse_ki_anzeigen.Checked = Convert.ToBoolean(Properties.Settings.Default["Stuetzpunktereignisse_KISpieler_anzeigen"]);
            btn_militaerereignisse_ki_anzeigen.Checked = Convert.ToBoolean(Properties.Settings.Default["Militaerereignisse_KISpieler_anzeigen"]);

            scr_musik_lautstaerke.Value = Convert.ToInt32(Properties.Settings.Default["Musik_Lautstaerke"]);
            scr_effekt_lautstaerke.Value = Convert.ToInt32(Properties.Settings.Default["Sound_Lautstaerke"]);
            scr_stimmen_lautstaerke.Value = Convert.ToInt32(Properties.Settings.Default["Stimmen_Lautstaerke"]);

            UpdateVolumeLabel(lbl_musik_lautstaerke, "Musik", scr_musik_lautstaerke.Value);
            UpdateVolumeLabel(lbl_effekt_lautstaerke, "Effekt", scr_effekt_lautstaerke.Value);
            UpdateVolumeLabel(lbl_stimmen_lautstaerke, "Stimmen", scr_stimmen_lautstaerke.Value);

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

        private void frmEinstellungen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CloseMitSound();
        }
        
        private void frmEinstellungen_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Einstellungen speichern
            Properties.Settings.Default["Musik_ausschalten"] = btn_musik_ausschalten.Checked;
            Properties.Settings.Default["Tipp_anzeigen"] = btn_tipps_anzeigen.Checked;
            Properties.Settings.Default["Statistik_anzeigen"] = btn_statistik_anzeigen.Checked;
            Properties.Settings.Default["Stuetzpunktereignisse_KISpieler_anzeigen"] = btn_stuetzpunktereignisse_ki_anzeigen.Checked;
            Properties.Settings.Default["Militaerereignisse_KISpieler_anzeigen"] = btn_militaerereignisse_ki_anzeigen.Checked;

            Properties.Settings.Default.Save(); // Settings in application configuration file speichern
        }

        private void scr_musik_lautstaerke_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateVolumeLabel(lbl_musik_lautstaerke, "Musik", (sender as ScrollBar).Value);
            Properties.Settings.Default["Musik_Lautstaerke"] = (sender as ScrollBar).Value;
            _musicPlayer.MusikLautstaerke = (sender as ScrollBar).Value;
        }

        private void scr_effekt_lautstaerke_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateVolumeLabel(lbl_effekt_lautstaerke, "Effekt", (sender as ScrollBar).Value);
            Properties.Settings.Default["Sound_Lautstaerke"] = (sender as ScrollBar).Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                List<QueuedSound> queue = new List<QueuedSound>
                {
                    new QueuedSound(Properties.Resources.bongo_dunkel, SoundType.Effect)
                };
                player.PlayAllSoundsFromQueue(queue);
            }
        }

        private void scr_stimmen_lautstaerke_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateVolumeLabel(lbl_stimmen_lautstaerke, "Stimmen", (sender as ScrollBar).Value);
            Properties.Settings.Default["Stimmen_Lautstaerke"] = (sender as ScrollBar).Value;

            if (e.Type == ScrollEventType.EndScroll)
            {
                List<QueuedSound> queue = new List<QueuedSound>
                {
                    new QueuedSound(Properties.Resources._31_bin_ich_laut_genug, SoundType.Voice)
                };
                player.PlayAllSoundsFromQueue(queue);
            }
        }

        private void UpdateVolumeLabel(Label label, string typeText, int value)
        {
            label.Text = $"{typeText} Lautstärke - " + value + " %";
        }

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