using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Privilegien.FestGeben;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Lib.Gameplay.Titel;
using Conspiratio.Musik;

namespace Conspiratio
{
    public partial class TitelVerleihForm : frmBasis
    {
        #region Konstruktor
        public TitelVerleihForm()
        {
            InitializeComponent();
            this.TransparencyKey = Color.White;

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            lbl_ueberschrift.Left = this.Width / 2 - lbl_ueberschrift.Width / 2;
            lbl_text.Left = this.Width / 2 - lbl_text.Width / 2;
            int verltitelid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBekamTitelX();
            string text = "Wir, " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetRegent()).GetKompletterName() + ", verfügen hiermit, dass Ihr, " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetName() + ", Euch fortan\n\n\"" + SW.Statisch.GetTitelX(verltitelid).GetName(SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich()) + "\"\n\nnennen dürft.\n\n" + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetRegent()).GetKompletterName();
            lbl_text.Text = text;
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetTitel(verltitelid);

            // Sound anhand Titel ermitteln
            Stream titelSound;  
            Adelstitel titel = SW.Statisch.GetTitelX(verltitelid);
            bool maennlich = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich();

            switch (titel.GetType().Name)
            {
                case nameof(Buerger):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_buerger : Properties.Resources._31_wir_verfuegen_hiermit_buergerin;
                    break;
                case nameof(Edelmann):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_edelmann : Properties.Resources._31_wir_verfuegen_hiermit_edelfrau;
                    break;
                case nameof(Ritter):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_ritter : Properties.Resources._31_wir_verfuegen_hiermit_hofdame;
                    break;
                case nameof(Landherr):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_landherr : Properties.Resources._31_wir_verfuegen_hiermit_landfrau;
                    break;
                case nameof(Freiherr):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_freiherr : Properties.Resources._31_wir_verfuegen_hiermit_freifrau;
                    break;
                case nameof(Baron):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_baron : Properties.Resources._31_wir_verfuegen_hiermit_baronin;
                    break;
                case nameof(Graf):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_graf : Properties.Resources._31_wir_verfuegen_hiermit_graefin;
                    break;
                case nameof(Herzog):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_herzog : Properties.Resources._31_wir_verfuegen_hiermit_herzogin;
                    break;
                case nameof(Fuerst):
                    titelSound = maennlich ? Properties.Resources._31_wir_verfuegen_hiermit_fuerst : Properties.Resources._31_wir_verfuegen_hiermit_fuerstin;
                    break;
                default:
                    titelSound = null;
                    break;
            }

            SoundQueuePlayer player = new SoundQueuePlayer();
            List<QueuedSound> queue = new List<QueuedSound>();
            queue.Add(new QueuedSound(Properties.Resources.fanfare));

            if (titelSound != null)
                queue.Add(new QueuedSound(titelSound, SoundType.Voice, startMillisecondsEarlier: 5000));
            
            player.PlayAllSoundsFromQueue(queue);

        }
        #endregion


        private void TitelVerleihForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
