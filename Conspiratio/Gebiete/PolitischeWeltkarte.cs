using System;
using System.Drawing;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Privilegien;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public partial class PolitischeWeltkarte : frmBasis, IPolitischeWeltkarteDialog
    {
        #region Globale Variablen
        Graphics g;

        int mouse_x;
        int mouse_y;

        int switch_case;

        bool NurStaedteMarkieren;
        int Level;
        int vorige_switch_case;

        // Stadtkoordinaten
        int f_left, f_right, f_top, f_bottom;
        int i_left, i_right, i_top, i_bottom;
        int h_left, h_right, h_top, h_bottom;
        int n_left, n_right, n_top, n_bottom;
        int d_left, d_right, d_top, d_bottom;
        int c_left, c_right, c_top, c_bottom;
        int a_left, a_right, a_top, a_bottom;
        int o_left, o_right, o_top, o_bottom;
        int k_left, k_right, k_top, k_bottom;
        int e_left, e_right, e_top, e_bottom;
        int b_left, b_right, b_top, b_bottom;
        int t_left, t_right, t_top, t_bottom;
        int s_left, s_right, s_top, s_bottom;
        int j_left, j_right, j_top, j_bottom;

        // Stadtrechtecke
        Rectangle rect_f;
        Rectangle rect_i;
        Rectangle rect_h;
        Rectangle rect_n;
        Rectangle rect_d;
        Rectangle rect_c;
        Rectangle rect_a;
        Rectangle rect_o;
        Rectangle rect_k;
        Rectangle rect_e;
        Rectangle rect_b;
        Rectangle rect_t;
        Rectangle rect_s;
        Rectangle rect_j;

        int modus;
        #endregion

        #region Konstruktor
        public PolitischeWeltkarte()
        {
            InitializeComponent();

            this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK);
            btn_liste.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SonstPergament);
        }
        #endregion


        #region ShowDialogModus
        /// <summary>
        /// Anzeigen des Fensters
        /// </summary>
        /// <param name="mod">
        /// Modus = In welchem Modus wird die Karte geoeffnet
        /// 0 = Beziehungen
        /// 1 = Sabotage
        /// 2 = Anschwärzen
        /// 3 = Spione
        /// 4 = Ermordung
        /// 5 = Erpressung
        /// 6 = Stadt auswaehlen
        /// 7 = Ehepartner waehlen
        /// 8 = Prozess initiieren
        /// 9 = Händler
        /// 10 = Kaufmann
        /// 11 = Merchant
        /// 12 = VergifteterWein
        /// 13 = Des Henkers Hand
        /// 14 !!!! gesperrt. Dieser wird von der Schreibstube aus bei der Liste der Kontrahenten verwendet
        /// </param>
        /// <param name="flaggenEinblenden"></param>
        public void ShowDialogModus(int mod, bool flaggenEinblenden = false)
        {
            modus = mod;

            if (flaggenEinblenden)
            {
                #region Flaggen einblenden
                for (int i = SW.Statisch.GetMinStadtID(); i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    this.Controls["btn_ban" + i.ToString()].Visible = false;

                    // Wenn er ein Haus besitzt soll die Flagge angezeigt werden
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetHausID() != 0)
                    {
                        Grafik.SwitchBanner("btn_ban" + i.ToString(), SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBanner(), this);
                        this.Controls["btn_ban" + i.ToString()].Visible = true;
                        this.Controls["btn_ban" + i.ToString()].BringToFront();
                    }
                    // oder wenn er eine Werkstaette besitzt
                    else
                    {
                        for (int j = 1; j <= SW.Statisch.GetMaxWerkstaettenProStadt(); j++)
                        {
                            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(j, i).GetSKillX(1) != 0) //Lagerraum
                            {
                                Grafik.SwitchBanner("btn_ban" + i.ToString(), SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBanner(), this);
                                this.Controls["btn_ban" + i.ToString()].Visible = true;
                                this.Controls["btn_ban" + i.ToString()].BringToFront();
                                break;
                            }
                        }
                    }
                }
                #endregion
            }
            else
            {
                if (modus == 10 || modus == 11)
                {
                    Level = modus - 9;
                    modus = 9;
                }

                if (modus == 6 || modus == 9 || modus == 12)
                {
                    NurStaedteMarkieren = true;
                }
            }

            ShowDialog();
        }
        #endregion

        #region PolitischeWeltkarte_Shown
        private void PolitischeWeltkarte_Shown(object sender, EventArgs e)
        {
            #region Stadtkoordinaten

            f_left = NormB(SW.Statisch.GetStadtRechteck(1, 0));
            f_right = NormB(SW.Statisch.GetStadtRechteck(1, 1));
            f_top = NormH(SW.Statisch.GetStadtRechteck(1, 2));
            f_bottom = NormH(SW.Statisch.GetStadtRechteck(1, 3));

            i_left = NormB(SW.Statisch.GetStadtRechteck(2, 0));
            i_right = NormB(SW.Statisch.GetStadtRechteck(2, 1));
            i_top = NormH(SW.Statisch.GetStadtRechteck(2, 2));
            i_bottom = NormH(SW.Statisch.GetStadtRechteck(2, 3));

            h_left = NormB(SW.Statisch.GetStadtRechteck(3, 0));
            h_right = NormB(SW.Statisch.GetStadtRechteck(3, 1));
            h_top = NormH(SW.Statisch.GetStadtRechteck(3, 2));
            h_bottom = NormH(SW.Statisch.GetStadtRechteck(3, 3));

            n_left = NormB(SW.Statisch.GetStadtRechteck(4, 0));
            n_right = NormB(SW.Statisch.GetStadtRechteck(4, 1));
            n_top = NormH(SW.Statisch.GetStadtRechteck(4, 2));
            n_bottom = NormH(SW.Statisch.GetStadtRechteck(4, 3));

            d_left = NormB(SW.Statisch.GetStadtRechteck(5, 0));
            d_right = NormB(SW.Statisch.GetStadtRechteck(5, 1));
            d_top = NormH(SW.Statisch.GetStadtRechteck(5, 2));
            d_bottom = NormH(SW.Statisch.GetStadtRechteck(5, 3));

            c_left = NormB(SW.Statisch.GetStadtRechteck(6, 0));
            c_right = NormB(SW.Statisch.GetStadtRechteck(6, 1));
            c_top = NormH(SW.Statisch.GetStadtRechteck(6, 2));
            c_bottom = NormH(SW.Statisch.GetStadtRechteck(6, 3));

            a_left = NormB(SW.Statisch.GetStadtRechteck(7, 0));
            a_right = NormB(SW.Statisch.GetStadtRechteck(7, 1));
            a_top = NormH(SW.Statisch.GetStadtRechteck(7, 2));
            a_bottom = NormH(SW.Statisch.GetStadtRechteck(7, 3));

            o_left = NormB(SW.Statisch.GetStadtRechteck(8, 0));
            o_right = NormB(SW.Statisch.GetStadtRechteck(8, 1));
            o_top = NormH(SW.Statisch.GetStadtRechteck(8, 2));
            o_bottom = NormH(SW.Statisch.GetStadtRechteck(8, 3));

            k_left = NormB(SW.Statisch.GetStadtRechteck(9, 0));
            k_right = NormB(SW.Statisch.GetStadtRechteck(9, 1));
            k_top = NormH(SW.Statisch.GetStadtRechteck(9, 2));
            k_bottom = NormH(SW.Statisch.GetStadtRechteck(9, 3));

            e_left = NormB(SW.Statisch.GetStadtRechteck(10, 0));
            e_right = NormB(SW.Statisch.GetStadtRechteck(10, 1));
            e_top = NormH(SW.Statisch.GetStadtRechteck(10, 2));
            e_bottom = NormH(SW.Statisch.GetStadtRechteck(10, 3));

            b_left = NormB(SW.Statisch.GetStadtRechteck(11, 0));
            b_right = NormB(SW.Statisch.GetStadtRechteck(11, 1));
            b_top = NormH(SW.Statisch.GetStadtRechteck(11, 2));
            b_bottom = NormH(SW.Statisch.GetStadtRechteck(11, 3));

            t_left = NormB(SW.Statisch.GetStadtRechteck(12, 0));
            t_right = NormB(SW.Statisch.GetStadtRechteck(12, 1));
            t_top = NormH(SW.Statisch.GetStadtRechteck(12, 2));
            t_bottom = NormH(SW.Statisch.GetStadtRechteck(12, 3));

            s_left = NormB(SW.Statisch.GetStadtRechteck(13, 0));
            s_right = NormB(SW.Statisch.GetStadtRechteck(13, 1));
            s_top = NormH(SW.Statisch.GetStadtRechteck(13, 2));
            s_bottom = NormH(SW.Statisch.GetStadtRechteck(13, 3));

            j_left = NormB(SW.Statisch.GetStadtRechteck(14, 0));
            j_right = NormB(SW.Statisch.GetStadtRechteck(14, 1));
            j_top = NormH(SW.Statisch.GetStadtRechteck(14, 2));
            j_bottom = NormH(SW.Statisch.GetStadtRechteck(14, 3));
           

            rect_f = new Rectangle(f_left, f_top, f_right - f_left, f_bottom - f_top);
            rect_i = new Rectangle(i_left, i_top, i_right - i_left, i_bottom - i_top);
            rect_h = new Rectangle(h_left, h_top, h_right - h_left, h_bottom - h_top);
            rect_n = new Rectangle(n_left, n_top, n_right - n_left, n_bottom - n_top);
            rect_d = new Rectangle(d_left, d_top, d_right - d_left, d_bottom - d_top);
            rect_c = new Rectangle(c_left, c_top, c_right - c_left, c_bottom - c_top);
            rect_a = new Rectangle(a_left, a_top, a_right - a_left, a_bottom - a_top);
            rect_o = new Rectangle(o_left, o_top, o_right - o_left, o_bottom - o_top);
            rect_k = new Rectangle(k_left, k_top, k_right - k_left, k_bottom - k_top);
            rect_e = new Rectangle(e_left, e_top, e_right - e_left, e_bottom - e_top);
            rect_b = new Rectangle(b_left, b_top, b_right - b_left, b_bottom - b_top);
            rect_t = new Rectangle(t_left, t_top, t_right - t_left, t_bottom - t_top);
            rect_s = new Rectangle(s_left, s_top, s_right - s_left, s_bottom - s_top);
            rect_j = new Rectangle(j_left, j_top, j_right - j_left, j_bottom - j_top);
            #endregion

            btn_ban1.Top = f_top;
            btn_ban2.Top = i_top;
            btn_ban3.Top = h_top;
            btn_ban4.Top = n_top;
            btn_ban5.Top = d_top;
            btn_ban6.Top = c_top;
            btn_ban7.Top = a_top;
            btn_ban8.Top = o_top;
            btn_ban9.Top = k_top;
            btn_ban10.Top = e_top;
            btn_ban11.Top = b_top;
            btn_ban12.Top = t_top;
            btn_ban13.Top = s_top;
            btn_ban14.Top = j_top;

            btn_ban1.Left = f_right + 3;
            btn_ban2.Left = i_right + 3;
            btn_ban3.Left = h_right + 3;
            btn_ban4.Left = n_right + 3;
            btn_ban5.Left = d_right + 3;
            btn_ban6.Left = c_right + 3;
            btn_ban7.Left = a_right + 3;
            btn_ban8.Left = o_right + 3;
            btn_ban9.Left = k_right + 3;
            btn_ban10.Left = e_right + 3;
            btn_ban11.Left = b_right + 3;
            btn_ban12.Left = t_right + 3;
            btn_ban13.Left = s_right + 3;
            btn_ban14.Left = j_right + 3;

            // Listenbutton
            if (modus != 6 && modus != 9 && modus != 10 && modus != 11)
            {
                btn_liste.Left = this.Width - btn_liste.Width;
                btn_liste.Top = 0;
                btn_liste.Visible = true;
            }
        }
        #endregion

        #region MouseDown
        private void PolitischeWeltkarte_MouseDown(object sender, MouseEventArgs e)
        {
            if (modus != 6)
            {
                if (e.Button == MouseButtons.Right)
                {
                    SpE.setAnschwaerzID(0);
                    this.CloseMitSound();
                }
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    SpE.setBoolKurzSpeicher(true);
                    this.CloseMitSound();
                }
            }

            #region Regionen anklicken
            if (e.Button == MouseButtons.Left)
            {
                if (switch_case == 1)
                {
                    showAemterEinerStadt(1);
                }

                if (switch_case == 2)
                {
                    showAemterEinerStadt(2);
                }

                if (switch_case == 3)
                {
                    showAemterEinerStadt(3);
                }

                if (switch_case == 4)
                {
                    showAemterEinerStadt(4);
                }

                if (switch_case == 5)
                {
                    showAemterEinerStadt(5);
                }

                if (switch_case == 6)
                {
                    showAemterEinerStadt(6);
                }

                if (switch_case == 7)
                {
                    showAemterEinerStadt(7);
                }

                if (switch_case == 8)
                {
                    showAemterEinerStadt(8);
                }

                if (switch_case == 9)
                {
                    showAemterEinerStadt(9);
                }

                if (switch_case == 10)
                {
                    showAemterEinerStadt(10);
                }

                if (switch_case == 11)
                {
                    showAemterEinerStadt(11);
                }

                if (switch_case == 12)
                {
                    showAemterEinerStadt(12);
                }

                if (switch_case == 13)
                {
                    showAemterEinerStadt(13);
                }
                if (switch_case == 14)
                {
                    showAemterEinerStadt(14);
                }

                //Laender
                //Wenn keine einzige Stadt markiert ist
                if (modus != 6)
                {
                    if (switch_case == 101)
                    {
                        showAemterEinesLands(1);
                    }
                    if (switch_case == 102)
                    {
                        showAemterEinesLands(2);
                    }
                    if (switch_case == 103)
                    {
                        showAemterEinesLands(3);
                    }
                    if (switch_case == 104)
                    {
                        showAemterEinesLands(4);
                    }


                    //Königreich
                    if (switch_case == 201)
                    {
                        showAemterDesReichs(1);
                    }

                }

            }
            #endregion
        }
        #endregion

        #region MouseMove
        private void PolitischeWeltkarte_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            switch_case = 0;

            //1
            if (mouse_x > f_left && mouse_x < f_right && mouse_y > f_top && mouse_y < f_bottom)
            {
                switch_case = 1;
            }
            //2
            else if (mouse_x > i_left && mouse_x < i_right && mouse_y > i_top && mouse_y < i_bottom)
            {
                switch_case = 2;
            }
            //3
            else if (mouse_x > h_left && mouse_x < h_right && mouse_y > h_top && mouse_y < h_bottom)
            {
                switch_case = 3;
            }
            //4
            else if (mouse_x > n_left && mouse_x < n_right && mouse_y > n_top && mouse_y < n_bottom)
            {
                switch_case = 4;
            }
            //5
            else if (mouse_x > d_left && mouse_x < d_right && mouse_y > d_top && mouse_y < d_bottom)
            {
                switch_case = 5;
            }
            //6
            else if (mouse_x > c_left && mouse_x < c_right && mouse_y > c_top && mouse_y < c_bottom)
            {
                switch_case = 6;
            }
            //7
            else if (mouse_x > a_left && mouse_x < a_right && mouse_y > a_top && mouse_y < a_bottom)
            {
                switch_case = 7;
            }
            //8
            else if (mouse_x > o_left && mouse_x < o_right && mouse_y > o_top && mouse_y < o_bottom)
            {
                switch_case = 8;
            }
            //9
            else if (mouse_x > k_left && mouse_x < k_right && mouse_y > k_top && mouse_y < k_bottom)
            {
                switch_case = 9;
            }
            //10
            else if (mouse_x > e_left && mouse_x < e_right && mouse_y > e_top && mouse_y < e_bottom)
            {
                switch_case = 10;
            }
            //11
            else if (mouse_x > b_left && mouse_x < b_right && mouse_y > b_top && mouse_y < b_bottom)
            {
                switch_case = 11;
            }
            //12
            else if (mouse_x > t_left && mouse_x < t_right && mouse_y > t_top && mouse_y < t_bottom)
            {
                switch_case = 12;
            }
            //13
            else if (mouse_x > s_left && mouse_x < s_right && mouse_y > s_top && mouse_y < s_bottom)
            {
                switch_case = 13;
            }
            //14
            else if (mouse_x > j_left && mouse_x < j_right && mouse_y > j_top && mouse_y < j_bottom)
            {
                switch_case = 14;
            }
            else
            {
                if (!NurStaedteMarkieren)
                {
                    //Wenn keine einzige Stadt markiert ist
                    //101
                    if (mouse_x > 0 && mouse_x < 862 && mouse_y > 0 & mouse_y < 279)
                    {
                        switch_case = 101;
                        this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK_101);
                        Invalidate();
                    }

                    //102
                    else if (mouse_x > 863 && mouse_x < this.Width && mouse_y > 75 & mouse_y < 358)
                    {
                        switch_case = 102;
                        this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK_102);
                    }

                    //103
                    else if ((mouse_x > 0 && mouse_x < 862 && mouse_y > 279 & mouse_y < 517) || (mouse_x > 0 && mouse_x < 150 && mouse_y > 518 & mouse_y < this.Height))
                    {
                        switch_case = 103;
                        this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK_103);
                    }

                    //104
                    else if ((mouse_x > 356 && mouse_x < 954 && mouse_y > 553 & mouse_y < this.Height) || (mouse_x > 953 && mouse_x < this.Width && mouse_y > 468 & mouse_y < this.Height))
                    {
                        switch_case = 104;
                        this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK_104);
                    }

                    else
                    {
                        switch_case = 201;
                        this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK_201);
                    }
                }
            }



            if (vorige_switch_case != switch_case)
            {
                if (switch_case < 100)
                {
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.PWK);
                }

                vorige_switch_case = switch_case;
                Invalidate();
            }
        }
        


        #endregion

        #region Paint
        private void PolitischeWeltkarte_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            if (switch_case == 1)
            {
                g.DrawRectangle(Pens.Black, 10, 10, 10, 10);
                g.DrawRectangle(Pens.Gold, rect_f);
            }

            if (switch_case == 2)
            {
                g.DrawRectangle(Pens.Gold, rect_i);
            }

            if (switch_case == 3)
            {
                g.DrawRectangle(Pens.Gold, rect_h);
            }

            if (switch_case == 4)
            {
                g.DrawRectangle(Pens.Gold, rect_n);
            }

            if (switch_case == 5)
            {
                g.DrawRectangle(Pens.Gold, rect_d);
            }

            if (switch_case == 6)
            {
                g.DrawRectangle(Pens.Gold, rect_c);
            }

            if (switch_case == 7)
            {
                g.DrawRectangle(Pens.Gold, rect_a);
            }

            if (switch_case == 8)
            {
                g.DrawRectangle(Pens.Gold, rect_o);
            }

            if (switch_case == 9)
            {
                g.DrawRectangle(Pens.Gold, rect_k);
            }

            if (switch_case == 10)
            {
                g.DrawRectangle(Pens.Gold, rect_e);
            }

            if (switch_case == 11)
            {
                g.DrawRectangle(Pens.Gold, rect_b);
            }

            if (switch_case == 12)
            {
                g.DrawRectangle(Pens.Gold, rect_t);
            }

            if (switch_case == 13)
            {
                g.DrawRectangle(Pens.Gold, rect_s);
            }

            if (switch_case == 14)
            {
                g.DrawRectangle(Pens.Gold, rect_j);
            }
        }
        #endregion

        #region ShowAemter
        // Falls eine Stadt geoeffnet wird
        public void showAemterEinerStadt(int StadtID)
        {
            if (modus != 6)
            {
                if (modus == 8)
                {
                    AemterEbene AE = new AemterEbene(StadtID, 8, 0);
                    AE.ShowDialog();
                    this.Close();
                }
                else if (modus == 9)
                {
                    RohstoffpreiseForm rpf = new RohstoffpreiseForm(StadtID, Level);
                    rpf.ShowDialog();
                }
                else
                {

                    AemterEbene AE = new AemterEbene(StadtID, modus, 0);
                    AE.ShowDialog();

                    if (modus == 7 || modus == 12 || modus == 13)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                SpE.setIntKurzSpeicher(StadtID);
                this.Close();
            }
        }

        //Falls ein Land geoeffnet wird
        public void showAemterEinesLands(int LandID)
        {
            if (modus == 8)
            {
                AemterEbene AE = new AemterEbene(LandID, 8, 1);
                AE.ShowDialog();
                this.Close();
            }
            else
            {
                AemterEbene AE = new AemterEbene(LandID, modus, 1);
                AE.ShowDialog();
            }
        }

        //Falls das gesamte Reich geoeffnet wird
        public void showAemterDesReichs(int ReichID)
        {
            if (modus == 8)
            {
                AemterEbene AE = new AemterEbene(ReichID, 8, 2);
                AE.ShowDialog();
                this.Close();
            }
            else
            {
                AemterEbene AE = new AemterEbene(ReichID, modus, 2);
                AE.ShowDialog();
            }
        }
        #endregion

        #region Normen
        private int NormH(int value)
        {
            return Convert.ToInt32(value * this.Height / Grafik.GetNormBildschirmHoehe());
        }

        private int NormB(int value)
        {
            return Convert.ToInt32(value * this.Width / Grafik.GetNormBildschirmBreite());
        }
        #endregion

        private void btn_liste_Click(object sender, EventArgs e)
        {
            KontrahentenForm kf = new KontrahentenForm(modus);
            kf.ShowDialog();
        }
    }
}
