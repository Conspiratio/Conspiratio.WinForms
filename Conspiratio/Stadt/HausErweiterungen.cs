using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Controls;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Lib.Gameplay.Wohnsitz;

namespace Conspiratio
{
    public partial class HausErweiterungen : frmBasis
    {
        private int _stadtID;
        private double _reduzierung;

        private CrystalButton _btnErweiterungBauen;
        private Label _lblErweiterungBauen;

        private List<HausErweiterung> _hausErweiterungen;

        #region Konstruktor
        public HausErweiterungen(int iStadtID)
        {
            InitializeComponent();

            int iTopButton = 136;
            int iTopLabel = 131;
            int i = 0;

            _stadtID = iStadtID;
            _reduzierung = 1;

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(15))
                _reduzierung = ((PrivSparplan)SW.Statisch.GetPrivX(15)).FaktorReduzierung;

            lbl_frage.Text = "Welche Erweiterung wollt Ihr an " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetNameInklPronomen() + " anbauen?";

            _hausErweiterungen = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).GetFehlendeOderVorhandeneHauserweiterungen();

            if (_hausErweiterungen.Count > 0)
            {
                // Alle nicht bereits vorhandenen Hauserweiterungen auslesen und anzeigen
                foreach (HausErweiterung oErweiterung in _hausErweiterungen)
                {
                    #region Controls erstellen

                    _btnErweiterungBauen = new CrystalButton();
                    _btnErweiterungBauen.BackColor = System.Drawing.Color.Transparent;
                    _btnErweiterungBauen.BackgroundImageLayout = ImageLayout.Stretch;
                    _btnErweiterungBauen.FlatAppearance.BorderSize = 0;
                    _btnErweiterungBauen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
                    _btnErweiterungBauen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
                    _btnErweiterungBauen.FlatStyle = FlatStyle.Flat;
                    _btnErweiterungBauen.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    _btnErweiterungBauen.ForeColor = System.Drawing.Color.Black;
                    _btnErweiterungBauen.Location = new System.Drawing.Point(55, iTopButton);
                    _btnErweiterungBauen.Margin = new Padding(0);
                    _btnErweiterungBauen.Name = "btnErweiterungBauen" + i.ToString();
                    _btnErweiterungBauen.Size = new System.Drawing.Size(20, 20);
                    _btnErweiterungBauen.TabIndex = 223;
                    _btnErweiterungBauen.UseVisualStyleBackColor = false;
                    _btnErweiterungBauen.Tag = i;
                    _btnErweiterungBauen.Click += new EventHandler(this.btnErweiterungBauen_Click);
                    _btnErweiterungBauen.MouseDown += new MouseEventHandler(this.btnErweiterungBauen_MouseDown);
                    _btnErweiterungBauen.BackgroundImage = Properties.Resources.SymbUnchecked;
                    this.Controls.Add(_btnErweiterungBauen);

                    _lblErweiterungBauen = new Label();
                    _lblErweiterungBauen.AutoSize = true;
                    _lblErweiterungBauen.BackColor = System.Drawing.Color.Transparent;
                    _lblErweiterungBauen.Font = Grafik.GetStandardFont(18);  //new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    _lblErweiterungBauen.ForeColor = System.Drawing.Color.Black;
                    _lblErweiterungBauen.Location = new System.Drawing.Point(87, iTopLabel);
                    _lblErweiterungBauen.MaximumSize = new System.Drawing.Size(473, 0);
                    _lblErweiterungBauen.Name = "lblErweiterungBauen" + i.ToString();
                    _lblErweiterungBauen.Size = new System.Drawing.Size(162, 29);
                    _lblErweiterungBauen.TabIndex = 225;
                    _lblErweiterungBauen.Text = oErweiterung.NameFuerKauf + " für " + Convert.ToInt32(oErweiterung.Kaufpreis * _reduzierung).ToStringGeld();
                    _lblErweiterungBauen.MouseDown += new MouseEventHandler(this.btnErweiterungBauen_MouseDown);
                    this.Controls.Add(_lblErweiterungBauen);

                    if (_lblErweiterungBauen.Height <= 29)
                    {
                        iTopButton += 35;
                        iTopLabel += 35;
                    }
                    else
                    {
                        iTopButton += 70;
                        iTopLabel += 70;
                    }

                    i++;

                    #endregion
                }

                this.Height = iTopLabel + 40;
            }
        }
        #endregion

        private void btnErweiterungBauen_Click(object sender, EventArgs e)
        {
            int preis = Convert.ToInt32(_hausErweiterungen[Convert.ToInt32((sender as Control).Tag)].Kaufpreis * _reduzierung);

            if (SW.Dynamisch.CheckIfenoughGold(preis))
            {
                if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr wirklich\n" + this.Controls["lblErweiterungBauen" + (sender as Control).Tag.ToString()].Text + "\n bauen lassen?", "Ja", "Lieber nicht!") == DialogResult.Yes)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-preis);

                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).HausErweiterungen == null)
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).HausErweiterungen = new List<int>();

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(_stadtID).HausErweiterungen.Add(_hausErweiterungen[Convert.ToInt32((sender as Control).Tag)].HausErweiterungID);
                    this.Close();
                }
            }
        }

        private void btnErweiterungBauen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                this.CloseMitSound();
        }
    }
}
