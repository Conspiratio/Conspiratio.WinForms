using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class KupplerinAngebot : frmBasis
    {
        double Kupplerprozente;
        int globAktivSpieler;
        int optimalerPartner;
        int Preis;

        #region Konstruktor
        public KupplerinAngebot(int optPartner, int globakt)
        {
            InitializeComponent();

            btn_d1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            Kupplerprozente = SW.Statisch.GetKupplerProzente();
            globAktivSpieler = globakt;
            optimalerPartner = optPartner;
            Preis = Convert.ToInt32(SW.Dynamisch.GetKIwithID(optimalerPartner).GetTaler() * Kupplerprozente);
            lbl_text.Text = "Die Kupplerin könnte bei " + SW.Dynamisch.GetKIwithID(optimalerPartner).GetKompletterName() + " großes Interesse an Euch wecken. Für " + Preis.ToStringGeld() + " kann sie Eure Werbung unterstützen. Wollt Ihr";
        }
        #endregion


        private void KupplerinAngebot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_d1_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.GetHumWithID(globAktivSpieler).WirbtUmSpielerID = optimalerPartner;
            SW.Dynamisch.GetSpWithID(globAktivSpieler).ErhoeheTaler(-Preis);
            SW.Dynamisch.GetKIwithID(optimalerPartner).ErhoeheVerliebt(50);
            SW.Dynamisch.BelTextAnzeigen("Die Kupplerin leitet alle Vorkehrungen in die Wege...");
            this.Close();
        }

        private void btn_d2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
