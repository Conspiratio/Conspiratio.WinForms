using System;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class RohstoffWaehlen : frmBasis
    {
        private readonly int _rohstoffId1, _rohstoffId2;

        public int GewaehlterRohstoffId;
        public int GewaehlterRohstoffPlatz;

        public RohstoffWaehlen(int stadtId)
        {
            InitializeComponent();
            _rohstoffId1 = SW.Dynamisch.GetStadtwithID(stadtId).GetSingleRohstoff(1);  
            _rohstoffId2 = SW.Dynamisch.GetStadtwithID(stadtId).GetSingleRohstoff(2);

            if (Grafik.GetRohstoffIcons80px().Count >= _rohstoffId1)
            {
                Controls["btn_roh1"].BackgroundImage = Grafik.GetRohstoffIcons80px()[_rohstoffId1];
                ttRohstoffe.SetToolTip(Controls["btn_roh1"], SW.Dynamisch.GetRohstoffwithID(_rohstoffId1).GetRohName());
            }

            if (Grafik.GetRohstoffIcons80px().Count >= _rohstoffId2)
            {
                Controls["btn_roh2"].BackgroundImage = Grafik.GetRohstoffIcons80px()[_rohstoffId2];
                ttRohstoffe.SetToolTip(Controls["btn_roh2"], SW.Dynamisch.GetRohstoffwithID(_rohstoffId2).GetRohName());
            }
        }

        private void btn_roh1_Click(object sender, EventArgs e)
        {
            Ausfuehren(_rohstoffId1, 1);
        }

        private void btn_roh2_Click(object sender, EventArgs e)
        {
            Ausfuehren(_rohstoffId2, 2);
        }

        public void Ausfuehren(int rohstoffId, int platz)
        {
            GewaehlterRohstoffId = rohstoffId;
            GewaehlterRohstoffPlatz = platz;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RohstoffWaehlen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DialogResult = DialogResult.Cancel;
                CloseMitSound();
            }
        }
    }
}
