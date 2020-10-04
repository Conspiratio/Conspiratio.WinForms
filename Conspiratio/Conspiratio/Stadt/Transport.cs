using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Niederlassung;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Transport : frmBasis
    {
        private int _stadtID;
        private int _aktuelleKaraID;

        #region Konstruktor
        public Transport(int sid)
        {
            InitializeComponent();

            lbl_text.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            btn_bild.BackgroundImage = new Bitmap(Properties.Resources.HintKaravane);

            txt_frage.Text = "Welche Karawane wollt Ihr mit \nEurem Transport beauftragen?";
            lbl_text.Left = (this.Width - lbl_text.Width) / 2;

            _stadtID = sid;

            _aktuelleKaraID = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKarawaneInStadtX(_stadtID);

            aktualisieren();
        }
        #endregion


        private void btn_weiter_Click(object sender, EventArgs e)
        {
            _aktuelleKaraID++;

            if (_aktuelleKaraID >= SW.Statisch.GetMaxKarawane())
                _aktuelleKaraID = SW.Statisch.GetMinKarawane();

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetKarawaneInStadtXzuY(_stadtID, _aktuelleKaraID);

            aktualisieren();
        }

        public void aktualisieren()
        {
            Karawane kar = SW.Statisch.GetKarawane(_aktuelleKaraID);

            lbl_fixpreis.Text = kar.Fixpreis.ToString();
            lbl_pps.Text = kar.PreisProStueck.ToString();
            lbl_verlass.Text = kar.Verlaesslichkeit.ToString() + "%";
            lbl_sicherheit.Text = kar.Sicherheit.ToString() + "%";
            lbl_karawanenfuehrer.Text = "Karawanenführer: " + kar.Beschreibung;
        }

        private void Transport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}