using System.Drawing;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class TitelVerleihForm : frmBasis
    {
        #region Konstruktor
        public TitelVerleihForm()
        {
            InitializeComponent();
            this.TransparencyKey = Color.White;

            lbl_ueberschrift.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            lbl_ueberschrift.Left = this.Width / 2 - lbl_ueberschrift.Width / 2;
            lbl_text.Left = this.Width / 2 - lbl_text.Width / 2;
            int verltitelid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBekamTitelX();
            string text = "Wir, " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetRegent()).GetKompletterName() + ", verfügen hiermit, dass Ihr, " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetName() + ", Euch fortan\n\n\"" + SW.Statisch.GetTitelX(verltitelid).GetName(SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich()) + "\"\n\nnennen dürft.\n\n" + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetRegent()).GetKompletterName();
            lbl_text.Text = text;
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetTitel(verltitelid);

            C_Musik musik = new C_Musik();
            musik.PlaySound(Properties.Resources.fanfare);
        }
        #endregion


        private void TitelVerleihForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
