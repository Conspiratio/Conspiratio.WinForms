using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class LagerraumKaufen : frmBasis
    {
        private int _aktuellerLagerraum;
        private int _aktuelleWerkstaette;
        private int _globalAktuelleStadtID;
        private int[] _p;
        private int[] _l;
        private int _stadtreichtum;
        private int _lagerraumBasispreis;
        private Label _lblTaler;

        #region Konstruktor
        public LagerraumKaufen(int akt_wks, int glaktstd, ref Label lblgold)
        {
            InitializeComponent();

            _lblTaler = lblgold;
            _p = new int[3];
            _l = new int[3];

            _aktuelleWerkstaette = akt_wks;
            _globalAktuelleStadtID = glaktstd;
            _aktuellerLagerraum = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_aktuelleWerkstaette, _globalAktuelleStadtID).GetSKillX(1);
            txt_lg.Text = _aktuellerLagerraum.ToString() + " m²";

            _stadtreichtum = SW.Dynamisch.GetStadtwithID(_globalAktuelleStadtID).GetReichtum();
            _lagerraumBasispreis = SW.Statisch.GetLagerraumBasisPreis();

            _l[0] = Convert.ToInt32(_aktuellerLagerraum * SW.Statisch.Rnd.Next(10, 30) / 100);
            _l[1] = Convert.ToInt32(_aktuellerLagerraum * SW.Statisch.Rnd.Next(20, 40) / 100);
            _l[2] = Convert.ToInt32(_aktuellerLagerraum * SW.Statisch.Rnd.Next(40, 60) / 100);
            btn_lg1.Text = _l[0].ToString() + " m²";
            btn_lg2.Text = _l[1].ToString() + " m²";
            btn_lg3.Text = _l[2].ToString() + " m²";

            double proz_preiszuschlag;
            proz_preiszuschlag = _stadtreichtum / SW.Statisch.GetMaxReichtum();
            _p[0] = Convert.ToInt32(_l[0] * (_lagerraumBasispreis + (_lagerraumBasispreis * proz_preiszuschlag)));
            _p[1] = Convert.ToInt32(_l[1] * (_lagerraumBasispreis + (_lagerraumBasispreis * proz_preiszuschlag)));
            _p[2] = Convert.ToInt32(_l[2] * (_lagerraumBasispreis + (_lagerraumBasispreis * proz_preiszuschlag)));

            lbl_p1.Text = "für " + _p[0].ToStringGeld();
            lbl_p2.Text = "für " + _p[1].ToStringGeld();
            lbl_p3.Text = "für " + _p[2].ToStringGeld();
        }
        #endregion


        private void btn_lg1_Click(object sender, EventArgs e)
        {  
            btn_execute(1);
        }

        private void btn_lg2_Click(object sender, EventArgs e)
        {
            btn_execute(2);
        }

        private void btn_lg3_Click(object sender, EventArgs e)
        {
            btn_execute(3);
        }
        private void btn_execute(int nr)
        {
            // Überprüfen, ob der Spieler genug Taler hat
            int sp_geld = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler();

            if (SW.Dynamisch.CheckIfenoughGold(_p[nr - 1]))
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_aktuelleWerkstaette, _globalAktuelleStadtID).SetSkillX(1, _aktuellerLagerraum + _l[nr - 1]);

                _aktuellerLagerraum = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(_aktuelleWerkstaette, _globalAktuelleStadtID).GetSKillX(1);
                this.Controls["btn_lg" + nr.ToString()].Visible = false;
                this.Controls["lbl_p" + nr.ToString()].Visible = false;
                txt_lg.Text = _aktuellerLagerraum.ToString() + " m²";

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-_p[nr - 1]);
                _lblTaler.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler().ToStringGeld();
            }
        }

        private void LagerraumKaufen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
