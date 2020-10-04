using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class Geldleiher : frmBasis
    {
        private int _randomKIID;
        private int _summe;
        private int _zins;
        private int _jahre;
        private Label _lbl_taler;

        #region Konstruktor
        public Geldleiher(int globk, ref Label lblgold)
        {
            InitializeComponent();




            lbl_text.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());
            lbl_2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgKlein());

            btn_d1.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbUnchecked);

            _lbl_taler = lblgold;
            
            _randomKIID = SW.Statisch.Rnd.Next(SW.Statisch.GetMinKIID(), SW.Statisch.GetMaxKIID());
            _summe = Convert.ToInt32(0.1 * SW.Dynamisch.GetKIwithID(_randomKIID).GetTaler());
            _zins = SW.Statisch.Rnd.Next(SW.Statisch.GetKreditZinsMin(), SW.Statisch.GetKreditZinsMax() + 1);
            if(SW.Dynamisch.GetAktHum().CheckPrivilegX(30) == true)
            {
                _zins = Convert.ToInt16(_zins / 2);
            }


            _jahre = SW.Statisch.Rnd.Next(4, 8);

            lbl_text.Text = SW.Dynamisch.GetKIwithID(_randomKIID).GetName() + " bietet Euch " + _summe.ToStringGeld() + " zu " + _zins.ToString() + "% Zinsen jährlich, rückzahlbar bis zum Jahre " + (SW.Dynamisch.GetAktuellesJahr() + _jahre).ToString() + ". Wollt Ihr";
        }
        #endregion


        private void btn_d2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_d1_Click(object sender, EventArgs e)
        {
            int kid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetEmptyKreditID();
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kid).SetDauer(_jahre);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kid).SetTaler(_summe);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kid).SetZinsen(_zins);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kid).SetKIID(_randomKIID);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(_summe);
            _lbl_taler.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler().ToStringGeld();
            SW.Dynamisch.GetKIwithID(_randomKIID).ErhoeheTaler(-_summe);

            // Falls verboten...
            if (SW.Dynamisch.GetGesetzX(0) != 0)
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(0);

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().SgenommeneKredite++;

            this.Close();
        }

        private void KreditNehmen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
