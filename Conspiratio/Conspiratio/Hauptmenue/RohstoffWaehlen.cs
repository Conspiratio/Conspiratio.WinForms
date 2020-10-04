using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class RohstoffWaehlen : frmBasis
    {
        int roh1, roh2;

        #region Konstruktor
        public RohstoffWaehlen(int r1, int r2)
        {
            InitializeComponent();

            roh1 = r1;
            roh2 = r2;

            if (Grafik.GetRohstoffIcons80px().Count >= r1)
            {
                this.Controls["btn_roh1"].BackgroundImage = Grafik.GetRohstoffIcons80px()[r1];
                ttRohstoffe.SetToolTip(this.Controls["btn_roh1"], SW.Dynamisch.GetRohstoffwithID(r1).GetRohName());
            }

            if (Grafik.GetRohstoffIcons80px().Count >= r2)
            {
                this.Controls["btn_roh2"].BackgroundImage = Grafik.GetRohstoffIcons80px()[r2];
                ttRohstoffe.SetToolTip(this.Controls["btn_roh2"], SW.Dynamisch.GetRohstoffwithID(r2).GetRohName());
            }
        }
        #endregion


        private void btn_roh1_Click(object sender, EventArgs e)
        {
            Ausfuehren(roh1, 1);
        }

        private void btn_roh2_Click(object sender, EventArgs e)
        {
            Ausfuehren(roh2, 2);
        }

        public void Ausfuehren(int rohid, int platz)
        {
            int stadtid = SpE.getIntKurzSpeicher();
            SpE.setIntKurzSpeicher(rohid);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(platz, stadtid).SetRohstoffID(rohid);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(platz, stadtid).SetSkillX(1, SW.Statisch.GetStartLagerraum()); //Startlagerraum
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(platz, stadtid).SetEnabled(true);

            this.Close();
        }

        private void closethis()
        {
            SpE.setBoolKurzSpeicher(true);
            this.CloseMitSound();
        }

        private void RohstoffWaehlen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                closethis();
            }
        }

        private void btn_roh1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                closethis();
            }
        }

        private void btn_roh2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                closethis();
            }
        }
    }
}
