using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class BeziehungenPflegen : frmBasis, IBeziehungPflegen
    {
        private int _spID;

        public BeziehungenPflegen()
        {
            InitializeComponent();

            btn_d1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_d3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_d4.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
        }

        public void ShowDialog(int spielerID)
        {
            _spID = spielerID;
            lbl_erklaerung.Text = "Wie wollt Ihr Eure Beziehung" + "\n" + "zu " + SW.Dynamisch.GetSpWithID(_spID).GetName() + " verbessern?";
            base.ShowDialog();
        }

        private void BeziehungenPflegen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_d1_Click(object sender, EventArgs e)
        {
            //btn_d1.Image = Image.FromFile(@"../../../Images\\Diamantleuchtend.gif");
            //NochNichtImplementiert();
        }

        private void btn_d2_Click(object sender, EventArgs e)
        {
            if (_spID >= SW.Statisch.GetMinKIID())
            {
                // Karten spielen
                int ki_geld = SW.Dynamisch.GetSpWithID(_spID).GetTaler();
                if (ki_geld * SW.Statisch.GetKartenSpielenProzentsatz() < SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler())
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetSpieltKartenGegenSpielerID(_spID);
                    if (SW.Dynamisch.GetSpWithID(_spID).GetMaennlich() == true)
                    {
                        SW.Dynamisch.BelTextAnzeigen("Ihr kontaktiert " + SW.Dynamisch.GetSpWithID(_spID).GetName() + ", welcher Euch sofort zusagt");
                    }
                    else
                    {
                        SW.Dynamisch.BelTextAnzeigen("Ihr kontaktiert " + SW.Dynamisch.GetSpWithID(_spID).GetName() + ", welche Euch sofort zusagt");
                    }
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiKartenSpielen++;
                    this.Close();
                }
                else
                {
                    SW.Dynamisch.GetKIwithID(_spID).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), -10);
                    SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetKIwithID(_spID).GetName() + ": \"Fragt mich wieder, wenn Euer Münzbeutel praller ist\"");
                }
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr könnt (noch) nicht mit einem menschlichem Mitspieler Karten spielen");
            }
        }

        private void btn_d3_Click(object sender, EventArgs e)
        {
            // Bestechen
            Bestechen best = new Bestechen(_spID);
            best.ShowDialog();
            this.Close();
        }

        private void btn_d4_Click(object sender, EventArgs e)
        {
            //NochNichtImplementiert();
            ////Beleidigen
            //if (RandomNames.getDuelvonSpielerX(RandomNames.getAktiverSpieler()) == false)
            //{
            //    //btn_d4.Image = Image.FromFile(@"../../../Images\\Diamantleuchtend.gif");
            //    Beleidigen bel = new Beleidigen(KIID, RandomNames.getAktiverSpieler());
            //    bel.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Ihr könnt nicht mehr als ein Duel austragen!");
            //}
        }
    }
}