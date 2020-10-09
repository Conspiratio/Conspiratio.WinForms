using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;

namespace Conspiratio
{
    public partial class WerkstaettenForm : frmBasis
    {
        private int _globalAktiveStadtID;
        private int _werkstattNr;
        private Label _lblTaler;

        #region Konstruktor
        public WerkstaettenForm(int gl_akt_std, int wks_nr, ref Label lbl_gold)
        {
            InitializeComponent();

            btn_lagerplatz.BackgroundImage = new Bitmap(Properties.Resources.SymbAusverkauf);
            btn_Antreiben.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_auszahlen.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_einbruch.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_koordination.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_manufaktur.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_qualitaet.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_sicherheit.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_sparen.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            btn_spezial.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);

            _globalAktiveStadtID = gl_akt_std;
            _werkstattNr = wks_nr;
            _lblTaler = lbl_gold;

            Invalidate();
        }
        #endregion


        private void WerkstaettenForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_stadt_staette2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void WerkstaettenForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics _graphics = e.Graphics;

            _graphics.FillRectangle(Brushes.Black, 300, 119, 5, 62);
            _graphics.FillRectangle(Brushes.Black, 300, 243, 5, 62);
            _graphics.FillRectangle(Brushes.Black, 96, 491, 5, 62);
            _graphics.FillRectangle(Brushes.Black, 96, 57, 5, 248);
            _graphics.FillRectangle(Brushes.Black, 205, 193, 5, 236);
            _graphics.FillRectangle(Brushes.Black, 300, 367, 5, 236);
            _graphics.FillRectangle(Brushes.Black, 96, 367, 5, 62);
        }

        private void WerkstaettenForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_sparen_Click(object sender, EventArgs e)
        {

        }

        private void btn_qualitaet_Click(object sender, EventArgs e)
        {

        }

        private void btn_spezial_Click(object sender, EventArgs e)
        {

        }

        private void btn_lagerplatz_Click(object sender, EventArgs e)
        {
            LagerraumKaufen lrk = new LagerraumKaufen(_werkstattNr, _globalAktiveStadtID, ref _lblTaler);
            lrk.ShowDialog();
        }
    }
}
