using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Kampf;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio.Kampf
{
    public partial class frmStuetzpunktKaufen : frmBasis
    {
        #region Variablen

        private int _stuetzpunktID;
        private int _aktuellerWert;
        private Stuetzpunkt _stuetzpunkt;

        #endregion

        #region Konstruktor
        public frmStuetzpunktKaufen(int stuetzpunktID)
        {
            InitializeComponent();

            _stuetzpunktID = stuetzpunktID;
            _stuetzpunkt = SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktID - 1];
            _aktuellerWert = _stuetzpunkt.BerechneWert();

            lbl_ueberschrift.Text = _stuetzpunkt.Name;

            string nameBesitzer = "";

            if (_stuetzpunkt.Besitzer >= SW.Statisch.GetMinKIID())
                nameBesitzer = SW.Dynamisch.GetKIwithID(_stuetzpunkt.Besitzer).GetKompletterName();
            else
                nameBesitzer = SW.Dynamisch.GetHumWithID(_stuetzpunkt.Besitzer).GetKompletterName();

            lbl_beschreibung.Text = _stuetzpunkt.StuetzpunktArtAlsString() + " im Besitz von " + nameBesitzer + ".";
            lbl_wert.Text = "Wert: " + _aktuellerWert.ToStringGeld();
            lbl_zustand.Text = "Zustand: " + _stuetzpunkt.ZustandInProzent + " %";
            lbl_sicherheit_tarnung.Text = _stuetzpunkt.SicherheitTarnungAlsString() + ": " + _stuetzpunkt.SicherheitTarnungInProzent + " %";

            btn_Taler.MaximalerWert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler();
            btn_Taler.Wert = _aktuellerWert;
        }

        #endregion

        #region frmStuetzpunktKaufen_MouseDown
        private void frmStuetzpunktKaufen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CloseMitSound();
        }
        #endregion

        #region btn_kaufangebot_Click
        private void btn_kaufangebot_Click(object sender, EventArgs e)
        {
            if (SW.Dynamisch.GetStuetzpunkte()[_stuetzpunktID - 1].KaufangebotAbgeben(btn_Taler.Wert))
                Close();
        }
        #endregion
    }
}
