using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class KontrahentDetails : frmBasis
    {
        private int _spielerID;

        #region Konstruktor
        public KontrahentDetails(int spielerID)
        {
            InitializeComponent();

            lbl_name.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            label2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            _spielerID = spielerID;

            lbl_name.Text = SW.Dynamisch.GetSpWithID(_spielerID).GetName();
            lbl_name.Left = (this.Width - lbl_name.Width) / 2;

            lbl_titel.Text = SW.Dynamisch.GetSpWithID(_spielerID).GetTitelGegendert();
            lbl_alter.Text = SW.Dynamisch.GetSpWithID(_spielerID).GetAlter().ToString();
            lbl_amt.Text = SW.Dynamisch.GetSpWithID(_spielerID).GetAmtNameUndOrt();

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(_spielerID).GetKosten() > 0 && SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(_spielerID).GetDauer() > 1)
            {
                lbl_vermoe.Text = SW.Dynamisch.GetSpWithID(_spielerID).GetGesamtVermoegen(_spielerID).ToString();
                lbl_ges.Text = SW.Dynamisch.GetSpWithID(_spielerID).BeurteileGesundheitString();
                lbl_delikte.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(_spielerID).GetDelikte().ToString();
                lbl_stand.Text = "Stand " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(_spielerID).GetJahr().ToString();
                lbl_stand.Visible = true;
            }
        }
        #endregion

        private void KontrahentDetails_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
