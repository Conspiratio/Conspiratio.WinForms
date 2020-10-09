using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Schreibstube;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class BewerbInfos : frmBasis
    {
        private int[] _waehlerX;
        private int[] _mitbewerberX;
        private WahlAbhalten _wahlAbhalten;

        #region Konstruktor
        public BewerbInfos(int wahlID)
        {
            InitializeComponent();

            _wahlAbhalten = SW.Dynamisch.GetWahlX(wahlID);
            _waehlerX = new int[SW.Statisch.GetMaxWahlWaehler()];
            
            // Die richtigen IDs der Wähler werden hier ermittelt
            for (int i = 0; i < SW.Statisch.GetMaxWahlWaehler(); i++)
            {
                int waehleramtid = _wahlAbhalten.GetWaehler()[i];

                // Stadtebene
                if (waehleramtid < SW.Statisch.GetMaxAmtStadtID())
                {
                    _waehlerX[i] = SW.Dynamisch.GetStadtwithID(_wahlAbhalten.GebietID).GetAmtX(waehleramtid);
                }
                // Landesebene
                else if (waehleramtid < SW.Statisch.GetMaxAmtLandID())
                {
                    int gebid = _wahlAbhalten.GebietID;
                    int lid = 0;

                    // z.B. Vogt wählt Bürgermeister dann ist das Gebiet noch immer mit der Stadtid angegeben
                    if (_wahlAbhalten.AmtID < SW.Statisch.GetMaxAmtStadtID())
                    {
                        // Hier muss die Stadt zu dem Land zugewiesen werden
                        lid = SW.Dynamisch.GetLandIDzuStadtX(gebid);
                    }
                    else
                    {
                        lid = gebid;
                    }
                    _waehlerX[i] = SW.Dynamisch.GetLandWithID(lid).GetAmtX(waehleramtid);
                }
                // Reichsebene
                else
                {
                    _waehlerX[i] = SW.Dynamisch.GetReichWithID(1).GetAmtX(waehleramtid);
                }
            }

            _mitbewerberX = new int[SW.Statisch.GetKITeilnehmerProWahl()];

            for (int i = 0; i < SW.Statisch.GetKITeilnehmerProWahl(); i++)
                _mitbewerberX[i] = SW.Dynamisch.GetWahlX(wahlID).GetKandidaten()[i];

            if (_waehlerX[0] == 0 && _waehlerX[1] == 0 && _waehlerX[2] == 0)
            {
                // Random Wahl
                lbl_w1.Text = "Die Wahl wird durch ein Los entschieden";
                lbl_w1.Visible = true;
            }
            else
            {
                // Zuerst Ornden
                // Wähler dürfen nicht mittig leer sein
                if (_waehlerX[0] == 0 && _waehlerX[1] == 0 && _waehlerX[2] != 0)
                {
                    _waehlerX[0] = _waehlerX[2];
                    _waehlerX[2] = 0;
                }
                if (_waehlerX[0] == 0 && _waehlerX[1] != 0 && _waehlerX[2] == 0)
                {
                    _waehlerX[0] = _waehlerX[1];
                    _waehlerX[1] = 0;
                }
                if (_waehlerX[0] == 0 && _waehlerX[1] != 0 && _waehlerX[2] != 0)
                {
                    _waehlerX[0] = _waehlerX[1];
                    _waehlerX[1] = _waehlerX[2];
                    _waehlerX[2] = 0;
                }
                if (_waehlerX[0] != 0 && _waehlerX[1] == 0 && _waehlerX[2] != 0)
                {
                    _waehlerX[1] = _waehlerX[2];
                    _waehlerX[2] = 0;
                }

                lbl_w1.Text = SW.Dynamisch.GetKIwithID(_waehlerX[0]).GetKompletterName();
                lbl_w1.Visible = true;

                if (_waehlerX[1] != 0)
                {
                    lbl_w2.Text = SW.Dynamisch.GetKIwithID(_waehlerX[1]).GetKompletterName();
                    lbl_w2.Visible = true;
                }

                if (_waehlerX[2] != 0)
                {
                    lbl_w3.Text = SW.Dynamisch.GetKIwithID(_waehlerX[2]).GetKompletterName();
                    lbl_w3.Visible = true;
                }
            }

            // Mitbewerber auflisten
            for (int i = 0; i < SW.Statisch.GetKITeilnehmerProWahl(); i++)
            {
                this.Controls["lbl_mbw" + (i + 1).ToString()].Text = SW.Dynamisch.GetKIwithID(_mitbewerberX[i]).GetKompletterName();
                this.Controls["lbl_mbw" + (i + 1).ToString()].Visible = true;
            }
        }
        #endregion


        private void BewerbInfos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
