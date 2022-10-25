using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Hauptmenue;
using Conspiratio.Musik;

namespace Conspiratio
{
    public partial class Optionen : frmBasis
    {
        private int hptm, beenden, sphinaus, sphinzu;

        private MusicAndSoundPlayer _musicPlayer = null;

        #region Konstruktor
        public Optionen(ref MusicAndSoundPlayer musicPlayer)
        {
            InitializeComponent();

            btn_hauptmenue.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_Zurueck.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_laden.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_speichern.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_Sphinzu.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_SpHinaus.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_optionen.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);
            btn_hpt_beenden.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstHolzbrett);


            hptm = 1;
            beenden = 2;
            sphinaus = 3;
            sphinzu = 4;

            _musicPlayer = musicPlayer;
        }
        #endregion

        private void btn_hauptmenue_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(hptm);
            this.Close();
        }

        private void btn_laden_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(5);
            this.Close();
        }

        private void btn_speichern_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(6);
            this.Close();
        }

        private void btn_Zurueck_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(0);
            this.Close();
        }

        private void btn_hpt_beenden_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(beenden);
            this.Close();
        }

        private void btn_SpHinaus_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(sphinaus);
            this.Close();
        }

        private void btn_Sphinzu_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(sphinzu);
            this.Close();
        }

        private void Optionen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_hauptmenue_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_Zurueck_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_laden_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_speichern_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_Sphinzu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_SpHinaus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_hpt_beenden_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_optionen_Click(object sender, EventArgs e)
        {
            frmEinstellungen oEinstellungen = new frmEinstellungen(ref _musicPlayer);
            oEinstellungen.ShowDialog();

            if (Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]))
            {
                _musicPlayer.RequestStop();
            }
        }

    }
}
