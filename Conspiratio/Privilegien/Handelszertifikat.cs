using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Musik;

namespace Conspiratio
{
    public partial class Handelszertifikat : frmBasis
    {
        #region Konstruktor
        public Handelszertifikat(int rohid)
        {
            InitializeComponent();

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());

            string text = "";

            if (rohid < 8)
            {
                // Entweder die Stadt in der der Spieler das Amt innehat
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID() != 0 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID() < SW.Statisch.GetMaxAmtStadtID())
                {
                    text = " der Rat der Stadt " + SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetGebietsName();
                }
                // oder die Stadt, in der er eine Niederlassung besitzt
                else
                {
                    for (int i = SW.Statisch.GetMinStadtID(); i < SW.Statisch.GetMaxStadtID(); i++)
                    {
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetHausID() != 0)
                        {
                            text = " der Rat der Stadt " + SW.Dynamisch.GetStadtwithID(i).GetGebietsName();
                        }
                    }
                }
            }
            else if (rohid < 15)
            {
                for (int i = 1; i < SW.Statisch.GetMaxLandID(); i++)
                {
                    int LandStaedte = SW.Dynamisch.GetLandWithID(i).GetAnzahlStaedte();
                    int hauscounter = 0;

                    for (int j = 0; j < LandStaedte; j++)
                    {
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(SW.Dynamisch.GetLandWithID(i).GetStadtX(j)).GetHausID() != 0)
                        {
                            hauscounter++;
                        }
                    }

                    if (hauscounter >= 2)
                    {
                        text = " der Rat des Landes " + SW.Dynamisch.GetLandWithID(i).GetGebietsName();
                        break;
                    }
                }

                if (string.IsNullOrEmpty(text))
                    text = " der Rat des Reichs " + SW.Dynamisch.GetReichWithID(1).GetGebietsName();
            }
            else
            {
                text = " der Rat des Reichs " + SW.Dynamisch.GetReichWithID(1).GetGebietsName();
            }

            lbl_text.Text = "Aufgrund Eurer besonderen\nHandelserfolge wird Euch,\n" + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetName() + ",\n ab heute gestattet, auch mit\n" + SW.Dynamisch.GetRohstoffwithID(rohid).GetRohName() + " zu handeln.\n \n" + text;

            MusicAndSoundPlayer musicPlayer = new MusicAndSoundPlayer();
            musicPlayer.PlaySound(Properties.Resources.fanfare);
        }
        #endregion

        private void lbl_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void Handelszertifikat_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
