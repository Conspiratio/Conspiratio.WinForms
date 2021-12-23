using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Privilegien.FestGeben;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio.Privilegien
{
    public partial class frmFestGeben : frmBasis, IFestGebenDialog
    {
        private FestManager _festManager;

        public frmFestGeben()
        {
            InitializeComponent();

            btn_fest_art.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_fest_ort.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
            btn_fest_jahr.BackgroundImage = new Bitmap(Properties.Resources.SymbUnchecked);
        }

        private void frmFestGeben_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CloseMitSound();
        }

        private void btn_stadt_Click(object sender, EventArgs e)
        {
            _festManager.SetNextStadtID();
            btn_ort.Text = _festManager.GetStadtName();
        }

        private void btn_fest_art_Click(object sender, EventArgs e)
        {
            btn_ort.Visible = true;
            btn_fest_ort.Visible = true;
            lbl_fest_ort_1.Visible = true;
            lbl_fest_ort_2.Visible = true;

            btn_fest_art.Enabled = false;
            btn_groesse.Enabled = false;
            btn_musiker.Enabled = false;
        }

        private void btn_fest_ort_Click(object sender, EventArgs e)
        {
            btn_jahr.Visible = true;
            btn_fest_jahr.Visible = true;
            lbl_fest_jahr_1.Visible = true;
            lbl_fest_jahr_2.Visible = true;

            btn_fest_ort.Enabled = false;
            btn_ort.Enabled = false;
        }

        private void btn_fest_jahr_Click(object sender, EventArgs e)
        {
            try
            {
                string message = _festManager.ErstelleNeuesFest(_festManager.StadtID, _festManager.Groesse, _festManager.Musiker, btn_jahr.Wert);

                SW.UI.TextAnzeigen.ShowDialog(message);
                Close();
            }
            catch (Exception ex)
            {
                SW.UI.TextAnzeigen.ShowDialog(ex.Message);
            }
        }

        private void btn_groesse_Click(object sender, EventArgs e)
        {
            _festManager.SetNextGroesse();
            btn_groesse.Text = _festManager.Groesse.ToString();
        }

        private void btn_musiker_Click(object sender, EventArgs e)
        {
            _festManager.SetNextMusiker();
            btn_musiker.Text = _festManager.Musiker.ToString();
        }

        private void frmFestGeben_Load(object sender, EventArgs e)
        {
            _festManager = new FestManager();

            btn_ort.Text = _festManager.GetStadtName();
            btn_groesse.Text = _festManager.Groesse.ToString();
            btn_musiker.Text = _festManager.Musiker.ToString();

            btn_jahr.Wert = _festManager.Jahr;
            btn_jahr.MinimalerWert = _festManager.Jahr;
            btn_jahr.MaximalerWert = _festManager.GetMaxJahr();

            btn_ort.Visible = false;
            btn_fest_ort.Visible = false;
            lbl_fest_ort_1.Visible = false;
            lbl_fest_ort_2.Visible = false;
            btn_jahr.Visible = false;
            btn_fest_jahr.Visible = false;
            lbl_fest_jahr_1.Visible = false;
            lbl_fest_jahr_2.Visible = false;

            btn_fest_ort.Enabled = true;
            btn_ort.Enabled = true;
            btn_fest_art.Enabled = true;
            btn_groesse.Enabled = true;
            btn_musiker.Enabled = true;
        }
    }
}
