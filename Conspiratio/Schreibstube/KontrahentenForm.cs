using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class KontrahentenForm : frmBasis
    {
        // modus:
        // 1 = ... 
        // ...
        // 13 = ... siehe politische Weltkarte
        // 14 = Von Schreibstube zur reinen Übersicht

        private int _modus;
        private int _seite;
        private int _maxSeite;
        private int _eintraegeProSeite;
        private int[] _liste;
        private int _counter;
        private int _mcounter;

        #region Konstruktor
        public KontrahentenForm(int modus)
        {
            InitializeComponent();

            lbl_mittelland.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());

            _modus = modus;

            btn_1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_4.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_6.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_7.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_8.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_9.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_10.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);

            btn_w.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbPfeilR1);
            btn_w5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbPfeilR2);
            btn_z.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbPfeilL1);
            btn_z5.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbPfeilL2);

            btn_w.Left = this.Width / 2 + 30;
            btn_w5.Left = btn_w.Left + btn_w.Width + 5;
            btn_z.Left = this.Width / 2 - 30 - btn_z.Width;
            btn_z5.Left = btn_z.Left - 5 - btn_z5.Width;

            //Liste anfertigen
            _liste = new int[SW.Statisch.GetMaxKIID()];
            _eintraegeProSeite = 10;
            _counter = 0;
            

            //Menschliche Kontrahenten reinspeichern
            for (int i = 1; i <= SW.Dynamisch.GetAktivSpielerAnzahl(); i++)
            {
                if (i != SW.Dynamisch.GetAktiverSpieler()) //Der Spieler, der das Buch öffnet soll natürlich nicht selbst darin aufscheinen
                {
                    _liste[_counter] = i;
                    _mcounter++;
                    _counter++;
                }
            }

            //KI Kontrahenten reinspeichern
            for (int i = SW.Statisch.GetMinKIID(); i < SW.Statisch.GetMaxKIID(); i++)
            {
                _liste[_counter] = i;
                _counter++;
            }

            _maxSeite = (_counter-1) / _eintraegeProSeite;


            EintraegeAktualisieren();
        }
        #endregion


        private void KontrahentenForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_w_Click(object sender, EventArgs e)
        {
            _seite++;
            if (_seite > _maxSeite)
            {
                _seite = _maxSeite;
            }
            EintraegeAktualisieren();
        }

        private void btn_z_Click(object sender, EventArgs e)
        {
            _seite--;
            if (_seite < 0)
            {
                _seite = 0;
            }
            EintraegeAktualisieren();
        }

        private void btn_w5_Click(object sender, EventArgs e)
        {
            _seite+=5;
            if (_seite > _maxSeite)
            {
                _seite = _maxSeite;
            }
            EintraegeAktualisieren();
        }

        private void btn_z5_Click(object sender, EventArgs e)
        {
            _seite-=5;
            if (_seite < 0)
            {
                _seite = 0;
            }
            EintraegeAktualisieren();
        }

        private void EintraegeAktualisieren()
        {
            for (int i = 1; i <= _eintraegeProSeite; i++)
            {
                if (_liste[_seite * _eintraegeProSeite + (i - 1)] != 0)
                {
                    this.Controls["lbl_g" + i.ToString()].Text = SW.Dynamisch.GetSpWithID(_liste[_seite * _eintraegeProSeite + (i - 1)]).GetCompleteNameOhneTitel();
                    this.Controls["lbl_g" + i.ToString()].Left = (this.Width - this.Controls["lbl_g" + i.ToString()].Width) / 2;

                    if ((_seite * _eintraegeProSeite + (i - 1)) < _mcounter)
                    {
                        this.Controls["lbl_g" + i.ToString()].ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        this.Controls["lbl_g" + i.ToString()].ForeColor = Color.Black;
                    }


                    this.Controls["lbl_g" + i.ToString()].Visible = true;
                    this.Controls["btn_" + i.ToString()].Visible = true;
                }
                else
                {
                    this.Controls["lbl_g" + i.ToString()].Visible = false;
                    this.Controls["btn_" + i.ToString()].Visible = false;
                }
            }

            lbl_seite.Text = (_seite + 1).ToString() + "/" + (_maxSeite + 1).ToString();
            lbl_seite.Left = (this.Width - lbl_seite.Width) / 2;
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 9);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 8);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 7);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 6);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 5);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 4);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 3);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 2);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 1);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            KontExecute(_seite * _eintraegeProSeite + 0);
        }

        private void KontExecute(int lpos)
        {
            if (_modus == 14)
            {
                KontrahentDetails kd = new KontrahentDetails(_liste[lpos]);
                kd.ShowDialog();
            }
            else
            {
                UI.PersonWasMachen(_liste[lpos], _modus);
            }
        }
    }
}
