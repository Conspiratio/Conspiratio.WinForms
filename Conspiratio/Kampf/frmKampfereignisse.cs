using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Kampf;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio.Kampf
{
    public partial class frmKampfereignisse : frmBasis
    {
        private C_Musik foC_MusikInstanz = null;

        #region Konstruktor
        public frmKampfereignisse(ref C_Musik oC_MusikInstanz)
        {
            InitializeComponent();

            foC_MusikInstanz = oC_MusikInstanz;
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Workaround für das Flackern des Mauszeigers auf dem Richtextcontrol bei mir, sobald man den Standardcursor umstellt
            // Quelle: http://www.vbforums.com/showthread.php?833547-RESOLVED-Cursor-flicker-RichTextBox-on-Windows-10-Bug
            const int WM_SETCURSOR = 0x20;

            if (m.Msg == WM_SETCURSOR && m.WParam == trtText.Handle)
            {
                m.Result = (IntPtr)1;
            }
        }
        #endregion

        #region frmKampfereignisse_Load
        private void frmKampfereignisse_Load(object sender, System.EventArgs e)
        {
            trtText.Left = UI.NormB(trtText.Left, this.Width);
            trtText.Top = UI.NormH(trtText.Top, this.Height);

            trtText.Width = UI.NormB(trtText.Width, this.Width);
            trtText.Height = UI.NormH(trtText.Height, this.Height);

            lbl_nachrichten_titel.Left = UI.NormB(lbl_nachrichten_titel.Left, this.Width);
            lbl_nachrichten_titel.Top = UI.NormH(lbl_nachrichten_titel.Top, this.Height);

            lbl_nachrichten_titel.Width = UI.NormB(lbl_nachrichten_titel.Width, this.Width);

            trtText.Font = Grafik.GetStandardFont(Convert.ToInt16(trtText.Font.Size));
            trtText.SelectionFont = Grafik.GetStandardFont(Convert.ToInt16(trtText.Font.Size));
            trtText.Text = "";
            lbl_nachrichten_titel.Text = "Militärische Ereignisse " + SW.Dynamisch.GetAktuellesJahr().ToString();
        }
        #endregion

        #region frmKampfereignisse_Shown
        private async void frmKampfereignisse_Shown(object sender, EventArgs e)
        {
            Kampfberechnung Kampfklasse = new Kampfberechnung();
            KampfErgebnis Ergebnis;

            // KI Aktionen ermitteln und durchführen (bezogen auf den Stützpunkt)
            foreach (Stuetzpunkt Stuetzpunkt in SW.Dynamisch.GetStuetzpunkte())
            {
                if (Stuetzpunkt.Besitzer <= SW.Statisch.GetMinKIID())  // Ist es ein menschlicher Spieler?
                    continue;

                string text = "";

                if (Stuetzpunkt.Art == EnumStuetzpunktArt.Zollburg)
                {
                    text = (Stuetzpunkt as Zollburg).RundenendeKIAktionenDurchfuehren();
                }
                else if (Stuetzpunkt.Art == EnumStuetzpunktArt.Raeuberlager)
                {
                    text = (Stuetzpunkt as Raeuberlager).RundenendeKIAktionenDurchfuehren();
                }

                if (text != "")
                {
                    trtText.AppendText(text + "\n\n");
                    ZumEndeScrollen();
                    await AufRechtsklickWarten();
                }
            }

            SW.Dynamisch.LandsicherheitenInitialisieren();

            List<Lib.Gameplay.Kampf.Kampf> lstKaempfe = Kampfklasse.ErmittleStattfindendeKaempfe();

            string NameAngreifer = "";
            string NameVerteidiger = "";
            string NameSpielerKarawane = "";
            Color TextColor = trtText.ForeColor;

            foreach (Lib.Gameplay.Kampf.Kampf Kampf in lstKaempfe)
            {
                Ergebnis = Kampfklasse.BerechneKampfErgebnis(Kampf);
                Kampfklasse.KampfErgebnisAnwenden(Ergebnis);

                string[] Texte = Ergebnis.Zusammenfassung.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);
                NameAngreifer = SW.Dynamisch.GetSpWithID(Ergebnis.SpielerIDAngreifer).GetKompletterName();

                if (Ergebnis.SpielerIDVerteidiger > 0)
                    NameVerteidiger = SW.Dynamisch.GetSpWithID(Ergebnis.SpielerIDVerteidiger).GetKompletterName();
                else
                    NameVerteidiger = "";

                if (Ergebnis.KampfArt == EnumKampfArt.KarawanenPluenderung)
                    NameSpielerKarawane = SW.Dynamisch.GetSpWithID(Ergebnis.Karawane.SpielerID).GetKompletterName();
                else
                    NameSpielerKarawane = "";

                foreach (string Text in Texte)
                {
                    foC_MusikInstanz.MusikEinschieben_Kampf();

                    if (Text.Contains("Kampf entbrennt"))
                        foC_MusikInstanz.PlaySound(Properties.Resources.kampf_loop);
                    else if (Text.Contains("Triumph"))
                        foC_MusikInstanz.StopSound();

                    if (Text.Contains("|"))
                    {
                        string[] Teilstrings = Text.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string teilstring in Teilstrings)
                        {
                            if ((teilstring != NameAngreifer) && (teilstring != NameVerteidiger) && (teilstring != NameSpielerKarawane))
                            {
                                trtText.AddText(teilstring, trtText.ForeColor, Grafik.GetStandardFont(Convert.ToInt16(trtText.Font.Size)));
                                continue;
                            }

                            TextColor = trtText.ForeColor;

                            for (int i = 1; i <= SW.Dynamisch.GetAktivSpielerAnzahl(); i++)  // Alle menschlichen Spieler durchgehen
                            {
                                if (SW.Dynamisch.GetSpWithID(i).GetKompletterName() == teilstring)
                                {
                                    TextColor = Color.DarkRed;
                                    break;
                                }
                            }

                            trtText.AddText(teilstring, TextColor, new Font(Grafik.GetStandardFont(Convert.ToInt16(trtText.Font.Size)), FontStyle.Bold));  // Text eine Spielers immer fett formatieren (wenn menschlich, dann auch dunkelrot)
                        }

                        trtText.AppendText("\n\n");
                    }
                    else  // Kommt theoretisch nie vor, da jeder Textblock (Absatz) immer mind. einen Spielernamen enthält
                        trtText.AppendText(Text + "\n\n");  

                    ZumEndeScrollen();
                    await AufRechtsklickWarten();
                }
            }

            if (trtText.Text == "")
            {
                trtText.AppendText("Dieses Jahr hat sich nichts Besonderes ereignet.");
                ZumEndeScrollen();
                await AufRechtsklickWarten();
            }

            Close();
        }
        #endregion

        #region frmKampfereignisse_MouseDown
        private void frmKampfereignisse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }
        #endregion

        #region ZumEndeScrollen
        private void ZumEndeScrollen()
        {
            trtText.SelectionStart = trtText.Text.Length;
            trtText.SelectionLength = 0;
            trtText.ScrollToCaret();
        }
        #endregion
    }
}
