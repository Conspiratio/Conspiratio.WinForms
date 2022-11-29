using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Lib.Gameplay.Titel;
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

            lbl_text.Text = "Aufgrund Eurer besonderen Erfolge\nin Amt und Würden wird Euch,\n" + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetName() + ",\n ab heute gestattet, mit\n" + SW.Dynamisch.GetRohstoffwithID(rohid).GetRohName() + " zu handeln.\n \n" + text;

            // Sound anhand Rohstoff ermitteln
            Stream rohstoffSound;

            switch (SW.Dynamisch.GetRohstoffwithID(rohid).GetRohName())
            {
                case "Korn":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_korn;
                    break;
                case "Wolle":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_wolle;
                    break;
                case "Obst":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_obst;
                    break;
                case "Bier":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_bier;
                    break;
                case "Holz":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_holz;
                    break;
                case "Fisch":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_fisch;
                    break;
                case "Ziegel":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_ziegel;
                    break;
                case "Glas":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_glas;
                    break;
                case "Wein":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_wein;
                    break;
                case "Rind":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_rind;
                    break;
                case "Fell":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_fell;
                    break;
                case "Rum":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_rum;
                    break;
                case "Erz":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_erz;
                    break;
                case "Kupfer":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_kupfer;
                    break;
                case "Pfeffer":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_pfeffer;
                    break;
                case "Salz":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_salz;
                    break;
                case "Waffen":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_waffen;
                    break;
                case "Diamant":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_diamant;
                    break;
                case "Gold":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_gold;
                    break;
                case "Medizin":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_medizin;
                    break;
                case "Silber":
                    rohstoffSound = Properties.Resources._31_wird_euch_ab_heute_gestattet_silber;
                    break;
                default:
                    rohstoffSound = null;
                    break;
            }

            SoundQueuePlayer player = new SoundQueuePlayer();
            List<QueuedSound> queue = new List<QueuedSound>();
            queue.Add(new QueuedSound(Properties.Resources.fanfare));
            queue.Add(new QueuedSound(Properties.Resources._31_auf_grund_eurer_besonderen_erfolge, SoundType.Voice, startMillisecondsEarlier: 5000));

            if (rohstoffSound != null)
                queue.Add(new QueuedSound(rohstoffSound, SoundType.Voice, startMillisecondsEarlier: 100));

            player.PlayAllSoundsFromQueue(queue);
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
