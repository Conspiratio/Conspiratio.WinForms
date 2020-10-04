using System;
using System.Windows.Forms;
using Conspiratio.Allgemein;

namespace Conspiratio
{
    public partial class NWSVerbinden : frmBasis
    {
        string nws_ip;
        string nws_name;

        #region Konstruktor
        public NWSVerbinden()
        {
            InitializeComponent();
        }
        #endregion




        private void btn_verbinden_Click(object sender, EventArgs e)
        {
            nws_ip = txt_ip.Text;
            nws_name = txt_name.Text;

            string temp = nws_ip + "§" + nws_name;
            SpE.setStringKurzSpeicher(temp);
            this.Close();
        }


    }
}
