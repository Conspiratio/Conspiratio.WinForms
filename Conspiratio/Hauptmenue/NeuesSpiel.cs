using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class NeuesSpiel : frmBasis
    {
        int anzahlspieler;
        bool cheaten;
        bool todesfaelle;
        bool testmodus;

        #region Konstruktor
        public NeuesSpiel()
        {
            InitializeComponent();

            label1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());

            setAnzSpieler(1);

            btn_c_aus.ForeColor = Color.Red;
            cheaten = false;

            btn_tf_aus.ForeColor = Color.Red;
            todesfaelle = false;

            btn_tm_aus.ForeColor = Color.Red;
            testmodus = false;
        }
        #endregion


        private void setAnzSpieler(int X)
        {
            anzahlspieler = X;

            for (int i = 1; i <= 9; i++)
                this.Controls["button" + i.ToString()].ForeColor = Color.Black;

            this.Controls["button" + X.ToString()].ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setAnzSpieler(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setAnzSpieler(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setAnzSpieler(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setAnzSpieler(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setAnzSpieler(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setAnzSpieler(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setAnzSpieler(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setAnzSpieler(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setAnzSpieler(9);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (txb_namenEingeben.Text.Length > 2)
            {
                SW.Dynamisch.SpielName = txb_namenEingeben.Text;
                SW.Dynamisch.SetAktivSpielerAnzahl(anzahlspieler);
                SW.Dynamisch.Cheatmodus = cheaten;
                SW.Dynamisch.TodesfaelleAnzeigen = todesfaelle;
                SW.Dynamisch.Testmodus = testmodus;

                this.Close();
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Der Spielname muss aus mindestens drei Zeichen bestehen");
                txb_namenEingeben.Focus();
            }
        }

        private void btn_c_an_Click(object sender, EventArgs e)
        {
            cheaten = true;
            btn_c_an.ForeColor = Color.Red;
            btn_c_aus.ForeColor = Color.Black;
        }

        private void btn_c_aus_Click(object sender, EventArgs e)
        {
            cheaten = false;
            btn_c_an.ForeColor = Color.Black;
            btn_c_aus.ForeColor = Color.Red;
        }

        private void btn_tf_an_Click(object sender, EventArgs e)
        {
            todesfaelle = true;
            btn_tf_an.ForeColor = Color.Red;
            btn_tf_aus.ForeColor = Color.Black;
        }

        private void btn_tf_aus_Click(object sender, EventArgs e)
        {
            todesfaelle = false;
            btn_tf_an.ForeColor = Color.Black;
            btn_tf_aus.ForeColor = Color.Red;
        }

        private void NeuesSpiel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }

        private void txb_namenEingeben_TextChanged(object sender, EventArgs e)
        {
            var savegamePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Conspiratio");
            savegamePath = Path.Combine(savegamePath, "_1600.dat");
            
            int savegamePathLength = savegamePath.Length;

            int maxlen = 256 - savegamePathLength;

            if (maxlen < 0)  // Fallback aus den Einstellungen (Standard: 12), wenn der Savegamepfad bereits länger als 256 Zeichen sein sollte
                maxlen = SW.Statisch.GetMaxNameLength();

            // Zu lange Namen abfangen und kürzen
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

        private void btn_tm_an_Click(object sender, EventArgs e)
        {
            testmodus = true;
            btn_tm_an.ForeColor = Color.Red;
            btn_tm_aus.ForeColor = Color.Black;
        }

        private void btn_tm_aus_Click(object sender, EventArgs e)
        {
            testmodus = false;
            btn_tm_an.ForeColor = Color.Black;
            btn_tm_aus.ForeColor = Color.Red;
        }

        private void NeuesSpiel_Shown(object sender, EventArgs e)
        {
            txb_namenEingeben.Focus();
        }

        private void txb_namenEingeben_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                e.Handled = true;  // Verhindert den Windows-Fehler-Sound (Piep)

            if (e.KeyChar == (char)Keys.Enter)
                btn_start_Click(sender, new EventArgs());
        }
    }
}
