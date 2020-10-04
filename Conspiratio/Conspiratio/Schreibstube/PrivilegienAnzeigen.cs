using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class PrivilegienAnzeigen : frmBasis
    {
        #region Variablen
        private int _seitencounter;
        private int _privcounter;
        private int[] _privilegs;

        private int _maxPrivProSeite;
        private int _aktuelleSeite;
        #endregion

        #region Konstruktor
        public PrivilegienAnzeigen()
        {
            InitializeComponent();

            btn_w.BackgroundImage = new Bitmap(Properties.Resources.SymbPfeilR1);
            btn_z.BackgroundImage = new Bitmap(Properties.Resources.SymbPfeilL1);

            NeuAnlegen();
        }
        #endregion


        #region Initiieren
        private void NeuAnlegen()
        {
            btn_priv0.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_priv1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_priv2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_priv3.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_priv4.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            int counter = 0;
            _seitencounter = 0;
            _privcounter = 0;
            _maxPrivProSeite = 5;
            _aktuelleSeite = 0;

            _privilegs = new int[SW.Statisch.GetMaxPriv()];

            for (int i = 1; i < SW.Statisch.GetMaxPriv(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(i) == true)
                {
                    _privilegs[_privcounter] = i;
                    _privcounter++;

                    if (counter >= _maxPrivProSeite)
                    {
                        counter = 0;
                        _seitencounter++;
                    }

                    if (_seitencounter == 0)
                    {
                        this.Controls["lbl_priv" + counter.ToString()].Text = SW.Statisch.GetPrivX(i).Name;
                        this.Controls["lbl_priv" + counter.ToString()].Visible = true;
                        this.Controls["btn_priv" + counter.ToString()].Visible = true;
                    }
                    counter++;
                }
            }

            if (_seitencounter >= 1)
            {
                btn_w.Visible = true;
                btn_z.Visible = true;
            }

            lbl_seite.Text = (_aktuelleSeite + 1).ToString() + "/" + (_seitencounter + 1).ToString();
        }
        #endregion

        private void PrivilegienAnzeigen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_priv1_Click(object sender, EventArgs e)
        {
            privAusfuehren(0);
        }

        private void btn_priv2_Click(object sender, EventArgs e)
        {
            privAusfuehren(1);
        }

        private void btn_priv3_Click(object sender, EventArgs e)
        {
            privAusfuehren(2);
        }

        private void btn_priv4_Click(object sender, EventArgs e)
        {
            privAusfuehren(3);
        }

        private void btn_priv5_Click(object sender, EventArgs e)
        {
            privAusfuehren(4);
        }

        public void privAusfuehren(int bnr)
        {
            int priv = _maxPrivProSeite * _aktuelleSeite + bnr;
            SW.Statisch.GetPrivX(_privilegs[priv]).PrivExecute();

            if ((SpE.getBoolKurzSpeicher() == true) && (SW.Statisch.GetPrivX(_privilegs[priv]).ID == 2))  // Amt Niederlegung und 'Ja' geklickt?
            {
                SpE.setBoolKurzSpeicher(false);
                this.Close();
            }
        }

        private void privDarstellen()
        {
            for (int i = 0; i < _maxPrivProSeite; i++)
            {
                if (_privilegs[i + _aktuelleSeite * _maxPrivProSeite] != 0)
                {
                    this.Controls["lbl_priv" + i.ToString()].Text = SW.Statisch.GetPrivX(_privilegs[i + _aktuelleSeite * _maxPrivProSeite]).Name;
                    this.Controls["lbl_priv" + i.ToString()].Visible = true;
                    this.Controls["btn_priv" + i.ToString()].Visible = true;
                }
                else
                {
                    this.Controls["lbl_priv" + i.ToString()].Visible = false;
                    this.Controls["btn_priv" + i.ToString()].Visible = false;
                }
            }
        }

        private void btn_w_Click_1(object sender, EventArgs e)
        {
            if (_aktuelleSeite < _seitencounter)
            {
                _aktuelleSeite++;
                privDarstellen();
                lbl_seite.Text = (_aktuelleSeite + 1).ToString() + "/" + (_seitencounter+1).ToString();
            }
        }

        private void btn_z_Click(object sender, EventArgs e)
        {
            if (_aktuelleSeite >= 1)
            {
                _aktuelleSeite--;
                privDarstellen();
                lbl_seite.Text = (_aktuelleSeite + 1).ToString() + "/" + (_seitencounter + 1).ToString();
            }
        }
    }
}
