using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;

namespace Conspiratio
{
    public partial class Beleidigen : frmBasis
    {
        int beleidCounter;
        int KIID;

        #region Konstruktor
        public Beleidigen(int ID, int glaktsp)
        {
            InitializeComponent();



            btn_durchfuehren.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_abbrechen.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);

            KIID = ID;

            beleidCounter = 0;
            lbl_header.Text = "Beleidigen";
            lbl_header.Left = (this.Width - lbl_header.Width) / 2;

            //btn_beleidtext.Text = SW.Dynamisch.getBeleidigungX(beleidCounter);
            btn_beleidtext.Top = 53;
            btn_beleidtext.Left = 35;
            btn_beleidtext.Height = 140;
            btn_beleidtext.Width = 240;

            btn_durchfuehren.Top = 60;
            btn_durchfuehren.Left = 20;

            btn_abbrechen.Text = "Abbrechen";
            btn_abbrechen.Left = 20;
            btn_abbrechen.Top = 205;
            lbl_abbrechen.Left = 35;
            lbl_abbrechen.Top = 203;
        }
        #endregion

        private void btn_beleidtext_Click(object sender, EventArgs e)
        {
            beleidCounter++;

            if (beleidCounter >= 10)
                beleidCounter = 0;

            //btn_beleidtext.Text = SW.Statisch.getBeleidigungX(beleidCounter);
        }

        private void Beleidigen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_abbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_durchfuehren_Click(object sender, EventArgs e)
        {
            //if (RandomNames.getDuelvonSpielerX(RandomNames.getAktiverSpieler()) == false)
            //{
            //    //btn_durchfuehren.BackgroundImage = Image.FromFile(@"../../../Images\\" + "Diamantleuchtend." + "gif");

            //    //Sound abspielen von der Beleidigung


            //    //Stimmt der KI dem Duell zu?
            //    if (SW.Statisch.rnd.Next(0, 100) < RandomNames.getKIwithID(KIID).getAggressiv())
            //    {
            //        //Duell
            //        RandomNames.setDuelvonSpielerXgegenY(RandomNames.getAktiverSpieler(), KIID);
            //        MessageBox.Show(RandomNames.getNamenUeberID(KIID) + " verlangt Satisfaktion!");
            //    }
            //    else
            //    {
            //        //KI verliert Ansehen/Einfluss
            //        MessageBox.Show(RandomNames.getNamenUeberID(KIID) + " lacht über Eure müden Worte!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ihr könnt nicht mehr als ein Duel austragen!");
            //}
        }

        private void btn_beleidtext_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void lbl_abbrechen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
