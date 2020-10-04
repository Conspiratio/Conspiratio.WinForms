using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class FormKonfessionslos : frmBasis
    {
        #region Konstruktor
        public FormKonfessionslos()
        {
            InitializeComponent();

            label1.Text = "Ihr seid konfessionslos. Welchen\nGlauben wollt Ihr annehmen?";

            btn_1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_3.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            label2.Text = "Den evangelischen,";
            label3.Text = "den kaholischen oder";
            label4.Text = "besser doch keinen";
        }
        #endregion


        private void btn_1_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetReligion(SW.Statisch.GetRelEvanID());
            this.Close();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetReligion(SW.Statisch.GetRelKathID());
            this.Close();
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormKonfessionslos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
