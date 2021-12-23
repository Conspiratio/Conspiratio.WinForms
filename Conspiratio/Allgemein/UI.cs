using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio.Allgemein
{
    public static class UI
    {
        /// <summary>
        /// Blendet die Spielerinfo (Name und Amt, Taler und Ort sowie Datum) oben im Bereich ein, z.B. bei der Verwaltung eine Stützpunktes.
        /// Die Labels werden dafür auf dem Form gesucht bzw. automatisch erstellt und hinzugefügt, wenn sie noch nicht vorhanden sind.
        /// </summary>
        /// <param name="Form">Aktuelles Form, in dem die Infos angezeigt und ausgerichtet werden sollen</param>
        /// <param name="NurAusrichten">OPTIONAL: Gibt an, ob die Labels nur ausgerichtet oder aber aktualisiert und erstellt werden sollen</param>
        /// <param name="Ort">OPTIONAL: Aktueller Ort, z.B. die Stadt oder der Stützpunkt</param>
        /// <param name="EventHandlerMouseDown">OPTIONAL: Der gewünschte Handler für das Event "MouseDown" auf den Labels</param>
        public static void SpielerInfosAnzeigenUndAusrichten(frmBasis Form, bool NurAusrichten = false, string Ort = "", MouseEventHandler EventHandlerMouseDown = null)
        {
            Label lbl_spielernameundamt = null;
            Label lbl_taler = null;
            Label lbl_ortdatum = null;
            Control[] ControlSucheSpielername = Form.Controls.Find("lbl_spielernameundamt", true);
            Control[] ControlSucheTaler = Form.Controls.Find("lbl_taler", true);
            Control[] ControlSucheOrtDatum = Form.Controls.Find("lbl_ortdatum", true);

            if (ControlSucheSpielername.Length > 0)
                lbl_spielernameundamt = (Label)ControlSucheSpielername[0];
            else if (!NurAusrichten)
            {
                lbl_spielernameundamt = LabelErstellen("lbl_spielernameundamt", "Herr/Frau Spielername, ohne Amt", new Point(375, 94), new Size(445, 32), 1, EventHandlerMouseDown);
                lbl_spielernameundamt.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                Form.Controls.Add(lbl_spielernameundamt);
            }
            else
                return;

            if (ControlSucheTaler.Length > 0)
                lbl_taler = (Label)ControlSucheTaler[0];
            else if (!NurAusrichten)
            {
                lbl_taler = LabelErstellen("lbl_taler", 789910.ToStringGeld(), new Point(113, 29), new Size(176, 32), 2, EventHandlerMouseDown);
                Form.Controls.Add(lbl_taler);
            }
            else
                return;

            if (ControlSucheOrtDatum.Length > 0)
                lbl_ortdatum = (Label)ControlSucheOrtDatum[0];
            else if (!NurAusrichten)
            {
                lbl_ortdatum = LabelErstellen("lbl_ortdatum", "Kontor A.D. 1400", new Point(983, 19), new Size(231, 32), 3, EventHandlerMouseDown);
                Form.Controls.Add(lbl_ortdatum);
            }
            else
                return;

            // Ausrichten
            if (lbl_spielernameundamt != null)
                lbl_spielernameundamt.Left = Form.Width / 2 - lbl_spielernameundamt.Width / 2;
            lbl_spielernameundamt.Top = UI.NormH(51, Form.Height);

            lbl_taler.Left = UI.NormB(35, Form.Width);
            lbl_taler.Top = UI.NormH(23, Form.Height);

            lbl_ortdatum.Left = Form.Width - lbl_ortdatum.Width - UI.NormB(35, Form.Width);
            lbl_ortdatum.Top = lbl_taler.Top;

            if (!NurAusrichten)
            {
                // Inhalte aktualisieren
                lbl_spielernameundamt.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKompletterName();
                TalerAendern(0, ref lbl_taler);

                if (Ort != "")
                    lbl_ortdatum.Text = Ort + " A.D. " + SW.Dynamisch.GetAktuellesJahr().ToString();
            }
        }

        public static int NormH(int value, int height, int? bildschirmhoehe = null)
        {
            int BildschirmHoehe = Grafik.GetNormBildschirmHoehe();

            if (bildschirmhoehe.HasValue)
                BildschirmHoehe = bildschirmhoehe.Value;

            return Convert.ToInt32(value * height / BildschirmHoehe);
        }

        public static int NormB(int value, int width, int? bildschirmbreite = null)
        {
            int BildschirmBreite = Grafik.GetNormBildschirmBreite();

            if (bildschirmbreite.HasValue)
                BildschirmBreite = bildschirmbreite.Value;

            return Convert.ToInt32(value * width / BildschirmBreite);
        }

        public static void TalerAendern(int wert, ref Label lbltaler)
        {
            try
            {
                //Aktuellen Stand ermitteln
                int Taler = SW.Dynamisch.GetAktHum().GetTaler();

                //Neuen Stand berechen
                int neuerStand = Taler + wert;

                SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).SetTaler(neuerStand);

                lbltaler.Text = neuerStand.ToStringGeld();
            }
            catch { }
        }

        #region PersonWasMachen
        public static void PersonWasMachen(int id, int modus)
        {
            if (id == 0)   // Ungültige SpielerID?
                return;

            if (id == SW.Dynamisch.GetAktiverSpieler())
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr könnt diese Aktion nicht auf Euch selbst anwenden");
                return;
            }

            switch (modus)
            {
                case 0:
                    SW.UI.BeziehungPflegen.ShowDialog(id);
                    break;
                case 1:
                    #region Sabotage
                    Sabotage sab;
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(id).GetDauer() > 0)
                    {
                        sab = new Sabotage(id, true);
                    }
                    else
                    {
                        sab = new Sabotage(id, false);
                    }

                    sab.ShowDialog();
                    break;
                #endregion
                case 2:
                    #region Anschwärzen
                    // TODO: Auslagern
                    if (SpE.getAnschwaerzID() == 0)
                    {
                        SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetSpWithID(id).GetName() + " anschwärzen bei...");
                        SpE.setAnschwaerzID(id);
                    }
                    else
                    {
                        if (id < SW.Statisch.GetMinKIID())
                        {
                            // TODO: Siehe Issue https://github.com/DerEinzehnte/Conspiratio-Programm/issues/57
                            SW.Dynamisch.BelTextAnzeigen("Ihr könnt nicht bei einem Mitspieler anschwärzen.");
                            break;
                        }

                        #region X bei Y anschwärzen
                        int x = SpE.getAnschwaerzID();
                        int y = id;

                        bool glaubtAnschuldigung = false;

                        if (x == y)
                        {
                            SW.Dynamisch.BelTextAnzeigen("Ihr könnt nicht jemanden bei sich selbst anschwärzen");
                            SpE.setAnschwaerzID(0);
                        }
                        else
                        {
                            //Wenn es verboten ist
                            if (SW.Dynamisch.GetGesetzX(22) != 0)
                            {
                                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(22);
                            }

                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiAnschwaerzungen++;

                            if (y >= SW.Statisch.GetMinKIID())
                            {
                                if (SW.Dynamisch.GetKIwithID(y).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler()) >= 80)
                                    glaubtAnschuldigung = true;
                            }
                            else
                            {
                                // TODO: Dem Mitspieler y die Vergehen anzeigen und ihn entscheiden lassen, ob er diesen Glauben schenkt
                            }

                            if (glaubtAnschuldigung)
                            {
                                if (y >= SW.Statisch.GetMinKIID())
                                {
                                    //Beziehung um 30 herabsetzen
                                    SW.Dynamisch.GetKIwithID(y).ErhoeheBeziehungZuX(x, -30);
                                    SW.Dynamisch.GetKIwithID(y).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), -10);
                                    SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetKIwithID(y).GetKompletterName() + " schenkt Euren Worten Glauben.");
                                }
                                else
                                {
                                    // TODO: Dem Mitspieler y mitteilen, dass bei ihm angeschwärzt wurde
                                }
                            }
                            else
                            {
                                if (x >= SW.Statisch.GetMinKIID())
                                {
                                    SW.Dynamisch.GetKIwithID(x).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), -50);
                                    SW.Dynamisch.GetKIwithID(y).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), -20);
                                    SW.Dynamisch.BelTextAnzeigen(SW.Dynamisch.GetSpWithID(y).GetKompletterName() + " glaubt Euch kein Wort und berichtet " + SW.Dynamisch.GetSpWithID(x).GetKompletterName() + " von Euren Anschuldigungen.");
                                }
                                else
                                {
                                    // TODO: Dem Mitspieler x mitteilen, dass er bei y angeschwärzt wurde
                                }
                            }
                        }

                        SpE.setAnschwaerzID(0);
                        #endregion
                    }
                    break;
                #endregion
                case 3:
                    #region Spionage
                    Spionage spi;
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(id).GetKosten() > 0)
                    {
                        spi = new Spionage(id, true);
                    }
                    else
                    {
                        spi = new Spionage(id, false);
                    }
                    spi.ShowDialog();
                    break;
                #endregion
                case 4:
                    SW.Dynamisch.Ermordung(id);
                    break;
                case 5:
                    SW.Dynamisch.Erpressen(id);
                    break;
                case 7:
                    SW.Dynamisch.PartnerSuchen(id);
                    break;
                case 8:
                    SW.Dynamisch.ProzessInitiieren(id);
                    break;
                case 12:
                    SW.Dynamisch.WeinVergiften(id);
                    break;
                case 13:
                    SW.Dynamisch.HenkersHand(id);
                    break;
            }
        }
        #endregion

        private static Label LabelErstellen(string Name, string Text, Point Location, Size ControlSize, int TabIndex, MouseEventHandler EventHandler)
        {
            Label lbl_control = null;
            lbl_control = new Label();
            lbl_control.AutoSize = true;
            lbl_control.BackColor = Color.Transparent;
            lbl_control.Font = new Font("Arial", 20.25F, (FontStyle.Bold | FontStyle.Italic), GraphicsUnit.Point, ((byte)(0)));
            lbl_control.ForeColor = Color.Black;
            lbl_control.Location = Location;
            lbl_control.Name = Name;
            lbl_control.Size = ControlSize;
            lbl_control.TabIndex = TabIndex;
            lbl_control.Text = Text;
            lbl_control.MouseDown += new MouseEventHandler(EventHandler);

            return lbl_control;
        }
    }
}