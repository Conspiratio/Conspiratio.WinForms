using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class UntergebenenOptionen : frmBasis
    {
        int OpferID;

        #region Konstruktor
        public UntergebenenOptionen(int ID)
        {
            InitializeComponent();

            Ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            btn_d1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_d3.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);

            OpferID = ID;
            lbl_text.Text = "Was wollt Ihr " + SW.Dynamisch.GetSpWithID(ID).GetName() + " antun?";
        }
        #endregion


        private void btn_d1_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.SetAmtsenthebungVonID(OpferID);

            SW.Dynamisch.BelTextAnzeigen("Eine Amtsenthebung von " + SW.Dynamisch.GetSpWithID(OpferID).GetKompletterName() + " wird in die Wege geleitet...");
            this.Close();
        }

        private void btn_d2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_d3_Click(object sender, EventArgs e)
        {

        }

        private void UntergebenenOptionen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
