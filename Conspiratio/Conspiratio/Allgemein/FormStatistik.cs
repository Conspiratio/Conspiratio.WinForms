using System;
using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class FormStatistik : frmBasis
    {
        int[] sparray;

        #region Konstruktor
        public FormStatistik()
        {
            InitializeComponent();

            lbl_titel.Left = (this.Width - lbl_titel.Width) / 2;

            lbl_spalte1.Text = "Spionagen\nSabotagen\nAnschläge\nErfolgreiche Anschnläge\nBestechungen\nBestechungssumme\nGlücksspiele\nAnschwärzungen\n\n";
            lbl_spalte1.Text += "gekaufte Ablässe\nabgelegte Beichten\nHochzeiten\nKonvertierungen\n\n";
            lbl_spalte1.Text += "Kredite genommen\nWahlen Teilgenommen\nWahlen gewonnen\n\n";
            
            lbl_spalte3.Text = "Waren verkauft\nWaren eingekauft\nEntrichtete Steuern\nEntrichtete Zölle\n\n";
            lbl_spalte3.Text += "Gesetzesverstöße\nGeklagter\nSchuldturmaufenthalte\nHöchstes Amt\nGesamtumsatz\nGezeugte Kinder\nAmtseinkommen\n\n";
            lbl_spalte3.Text += "Gesamtvermögen\nTaler";

            sparray = new int[SW.Statisch.GetMinKIID()];
            int arrcounter = 0;

            //spieler suchen
            for (int i = 1; i < SW.Statisch.GetMinKIID(); i++)
            {
                if(SW.Dynamisch.GetHumWithID(i).GetName() != "")
                {
                    sparray[arrcounter] = i;
                    arrcounter++;
                }
            }

            loadSpStat(sparray[0]);
        }
        #endregion

        private void loadSpStat(int id)
        {
            SwitchBanner("pictureBox" + id.ToString(), SW.Dynamisch.GetHumWithID(id).GetBanner());
            this.Controls["pictureBox" + id.ToString()].Visible = true;

            lbl_subtitel.Text = SW.Dynamisch.GetHumWithID(id).GetName();
            lbl_subtitel.Left = (this.Width - lbl_subtitel.Width) / 2;

            lbl_spalte2.Text = SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiSpionagen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiSabotagen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiVersuchteErmordungen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiErfolgreicheErmordungen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiBestechungen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiBestechungssumme.ToStringGeld() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiKartenSpielen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HiAnschwaerzungen.ToString() + "\n" + "\n";

            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().KgekaufteAblaesse.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().KabgelegteBeichten.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().KHochzeiten.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().KKonvertierungen.ToString() + "\n" + "\n";

            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SgenommeneKredite.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SWahlenTeilgenommen.ToString() + "\n";
            lbl_spalte2.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SWahlenGewonnen.ToString();



            lbl_spalte4.Text = SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HaWarenVerkauft.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HaWarenEingekauft.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HaentrichteteSteuern.ToStringGeld() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().HaentrichteteZoelle.ToStringGeld() + "\n" + "\n";

            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SogebrocheneGesetze.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().Soangeklagt.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SoSchuldturmaufenthalte.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SoHoechstesAmt.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SoGesamtumsatz.ToStringGeld() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SogezeugteKinder.ToString() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetSpielerStatistik().SoAmtseinkommen.ToStringGeld() + "\n\n";

            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetGesamtVermoegen(id).ToStringGeld() + "\n";
            lbl_spalte4.Text += SW.Dynamisch.GetHumWithID(id).GetTaler().ToStringGeld();
        }


        private void SwitchBanner(string btn_name, int value)
        {
            //wurde von main kopiert
            switch (value)
            {
                case 1:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban1);
                    break;
                case 2:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban2);
                    break;
                case 3:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban3);
                    break;
                case 4:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban4);
                    break;
                case 5:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban5);
                    break;
                case 6:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban6);
                    break;
                case 7:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban7);
                    break;
                case 8:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban8);
                    break;
                case 9:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban9);
                    break;
                case 10:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban10);
                    break;
                case 11:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban11);
                    break;
                case 12:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban12);
                    break;
                case 13:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban13);
                    break;
                case 14:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.ban14);
                    break;
            }
        }

        private void FormStatistik_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void lbl_spalte1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[0]);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[1]);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[2]);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[3]);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[4]);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[5]);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[6]);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[7]);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            loadSpStat(sparray[8]);
        }
    }
}
