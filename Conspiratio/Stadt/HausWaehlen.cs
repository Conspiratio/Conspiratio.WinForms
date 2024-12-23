using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class HausWaehlen : frmBasis
    {
        private int _stadtid;
        private int[] _hausXpreis;
        private double _faktorReduzierung = 1;
        private int _modus;

        // 0 = Haus bauen
        // 1 = Haus umbauen

        #region Konstruktor
        public HausWaehlen(int sid, int mod)
        {
            InitializeComponent();

            button0.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button3.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button4.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button5.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button6.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button7.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            button8.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            _modus = mod;
            _stadtid = sid;
            _hausXpreis = new int[SW.Statisch.GetMaxHausID()];

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(15))
                _faktorReduzierung = ((PrivSparplan)SW.Statisch.GetPrivX(15)).FaktorReduzierung;

            int fixpreisreduzierung = 0;

            if (_modus == 1)
                fixpreisreduzierung = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).GetAktuellerWert() / 2;

            for (int i = 0; i < SW.Statisch.GetMaxHausID() - 1; i++)
            {
                _hausXpreis[i] = Convert.ToInt32(SW.Statisch.GetHaus(i + 1).Kaufpreis * _faktorReduzierung - fixpreisreduzierung);
                this.Controls["label" + i.ToString()].Text = SW.Statisch.GetHaus(i+1).Name + " für "  + _hausXpreis[i].ToStringGeld();
            }
        }
        #endregion


        private void button0_Click(object sender, EventArgs e)
        {
            ausgewaehlt(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ausgewaehlt(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ausgewaehlt(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ausgewaehlt(4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ausgewaehlt(5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ausgewaehlt(6);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ausgewaehlt(7);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ausgewaehlt(8);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ausgewaehlt(9);
        }

        public async void ausgewaehlt(int x)
        {
            if (x != SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).GetHausID())
            {
                if (SW.Dynamisch.CheckIfenoughGold(_hausXpreis[x - 1]))
                {
                    if (await SW.UI.YesNoQuestion.ShowDialogText("Wollt Ihr wirklich für\n" + _hausXpreis[x - 1].ToStringGeld() + " ein/e " + SW.Statisch.GetHaus(x).Name + "\n bauen lassen?", "Ja", "Nein") == DialogResultGame.Yes)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-_hausXpreis[x - 1]);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).SetHausID(x);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).SetStadtID(_stadtid);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).SetRestlicheBauzeit(SW.Statisch.GetHaus(x).Bauzeit);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).HausErweiterungen = null;
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtid).ZustandInProzent = 100;  // Es kann sein, dass es an diesen Slot bereits einen Wohnsitz gibt, der heruntergekommen ist
                        this.Close();
                    }
                }
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr besitzt hier bereits genau diesen Wohnsitz");
            }
        }

        private void HausWaehlen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
