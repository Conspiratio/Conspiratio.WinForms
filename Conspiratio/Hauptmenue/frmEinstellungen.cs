using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;

namespace Conspiratio.Hauptmenue
{
    public partial class frmEinstellungen : frmBasis
    {
        private C_Musik foC_MusikInstanz = null;

        #region Konstruktor frmEinstellungen
        public frmEinstellungen(ref C_Musik oC_MusikInstanz)
        {
            InitializeComponent();

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            lbl_ueberschrift.Left = this.Width / 2 - lbl_ueberschrift.Width / 2;

            foC_MusikInstanz = oC_MusikInstanz;
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
            foC_MusikInstanz.MusikLautstaerke = trb_musik_lautstaerke.Value;
        }
        #endregion

        #region trb_effekt_lautstaerke_Scroll
        private void trb_effekt_lautstaerke_Scroll(object sender, EventArgs e)
        {
            lbl_effekt_lautstaerke.Text = "Effekt Lautstärke - " + trb_effekt_lautstaerke.Value + " %";
            foC_MusikInstanz.SoundLautstaerke = trb_effekt_lautstaerke.Value;
        }
        #endregion
    }
}