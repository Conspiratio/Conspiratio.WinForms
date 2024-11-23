using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Allgemein;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class BauwerkStiftenForm : frmBasis, IBauwerkStiftenDialog
    {
        int aktive_stadt;
        int[] preise;
        string[] Bauwerke;

        #region Konstruktor
        public BauwerkStiftenForm()
        {
            InitializeComponent();

            btn_d1.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d2.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d3.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_d4.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);

            preise = new int[4];
            preise[0] = 5000;
            preise[1] = 5000;
            preise[2] = 5000;
            preise[3] = 5000;
            //preise[4] = 5000;

            Bauwerke = new string[4];
            Bauwerke[0] = "eine Kirche";
            Bauwerke[1] = "einen Kerker";
            Bauwerke[2] = "eine Feuerwehr";
            Bauwerke[3] = "ein Hospital";
            // einen Damm/Deich? gegen Flut

            for (int i = 1; i < 5; i++)
                this.Controls["label" + i.ToString()].Text = Bauwerke[i-1] + " für " + preise[i-1].ToStringGeld();
        }
        #endregion

        public new DialogResultGame ShowDialog()
        {
            return base.ShowDialog().ToDialogResultGame();
        }

        private void BauwerkStiftenForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_stadt_Click(object sender, EventArgs e)
        {
            aktive_stadt++;
            if(aktive_stadt >= SW.Statisch.GetMaxStadtID())
            {
                aktive_stadt = 1;
            }

            btn_stadt.Text = SW.Dynamisch.GetStadtwithID(aktive_stadt).GetGebietsName();
        }

        private async void btn_d1_Click(object sender, EventArgs e)
        {
            await btnXexecute(1);
        }

        private async void btn_d2_Click(object sender, EventArgs e)
        {
            await btnXexecute(2);
        }

        private async void btn_d3_Click(object sender, EventArgs e)
        {
            await btnXexecute(3);
        }

        private async void btn_d4_Click(object sender, EventArgs e)
        {
            await btnXexecute(4);
        }

        private async Task btnXexecute(int x)
        {
            if (SW.Dynamisch.CheckIfenoughGold(preise[x-1]))
            {
                if (await SW.UI.YesNoQuestion.ShowDialogText("Wollt Ihr wirklich für " + preise[x-1].ToStringGeld() + "\nder Stadt " + SW.Dynamisch.GetStadtwithID(aktive_stadt).GetGebietsName() + " " + Bauwerke[x-1] + " stiften?", "Ja", "Nein") == DialogResultGame.Yes)
                {
                    // Permaansehen erhöhen
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(Convert.ToInt16(preise[x-1] / 1000));

                    // TODO: Katastrophen adjustieren

                    // Geld abziehen
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-preise[x-1]);
                }
                this.Close();
            }
        }

        private void BauwerkStiftenForm_Load(object sender, EventArgs e)
        {
            aktive_stadt = 1;
            btn_stadt.Text = SW.Dynamisch.GetStadtwithID(aktive_stadt).GetGebietsName();
        }
    }
}
