using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Kirche;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class KupplerinAngebot : frmBasis
    {
        private readonly int _aktiverSpieler;
        private readonly int _optimalerPartnerId;
        private readonly int _preis;

        #region Konstruktor
        public KupplerinAngebot(int optimalerPartnerId, int spielerId)
        {
            InitializeComponent();

            btn_d1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            _aktiverSpieler = spielerId;
            _optimalerPartnerId = optimalerPartnerId;
            _preis = Kupplerin.BerechnePreisFuerKupplerin(_optimalerPartnerId);
            lbl_text.Text = "Die Kupplerin könnte bei " + SW.Dynamisch.GetKIwithID(_optimalerPartnerId).GetKompletterName() + " großes Interesse an Euch wecken. Für " + _preis.ToStringGeld() + " kann sie Eure Werbung unterstützen. Wollt Ihr";
        }
        #endregion


        private void KupplerinAngebot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CloseMitSound();
        }

        private void btn_d1_Click(object sender, EventArgs e)
        {
            Kupplerin.BeginneWerbungUmOptimalenPartner(_aktiverSpieler, _optimalerPartnerId, _preis);
            Close();
        }

        private void btn_d2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
