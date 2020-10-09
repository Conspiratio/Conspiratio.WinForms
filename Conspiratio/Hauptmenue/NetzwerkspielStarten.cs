using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class NetzwerkspielStarten : frmBasis
    {
        #region Konstruktor
        public NetzwerkspielStarten()
        {
            InitializeComponent();

            label1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
            txb_namenEingeben.Focus();
        }
        #endregion



        private void txb_namenEingeben_TextChanged(object sender, EventArgs e)
        {
            int maxlen = SW.Statisch.GetMaxNameLength();

            //Zu lange Namen abfangen
            if (txb_namenEingeben.Text.Length > maxlen)
            {
                txb_namenEingeben.Text = txb_namenEingeben.Text.Substring(0, maxlen);
                txb_namenEingeben.Select(txb_namenEingeben.Text.Length, 0);
            }

            if (txb_namenEingeben.Text.Contains(" ") == true)
            {
                for (int i = 0; i < txb_namenEingeben.Text.Length; i++)
                {
                    if (txb_namenEingeben.Text.Substring(i, 1) == " ")
                    {
                        string s1 = txb_namenEingeben.Text.Substring(0, i);
                        string s2 = "";
                        if ((txb_namenEingeben.Text.Length - 1) > (i + 1))
                        {
                            s2 = txb_namenEingeben.Text.Substring(i + 1, txb_namenEingeben.Text.Length - i - 1);
                        }
                        txb_namenEingeben.Text = s1 + s2;
                        txb_namenEingeben.Select(txb_namenEingeben.Text.Length, 0);
                    }
                }
            }
        }

        private void NetzwerkspielStarten_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }


        private void btn_c_an_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_c_aus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void btn_hosten_Click(object sender, EventArgs e)
        {
            SpE.setBoolKurzSpeicher(true);
            SpE.setStringKurzSpeicher(txb_namenEingeben.Text + "~" + txt_ip.Text);
            this.Close();
        }

        private void btn_beitreten_Click(object sender, EventArgs e)
        {

        }
    }
}
