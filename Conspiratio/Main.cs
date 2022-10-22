using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Conspiratio.Allgemein;
using Conspiratio.Hauptmenue;
using Conspiratio.Kampf;
using Conspiratio.Lib.Extensions;
using Conspiratio.Lib.Gameplay.Einstellungen;
using Conspiratio.Lib.Gameplay.Ereignisse;
using Conspiratio.Lib.Gameplay.Kampf;
using Conspiratio.Lib.Gameplay.Kampf.Einheiten;
using Conspiratio.Lib.Gameplay.Kirche;
using Conspiratio.Lib.Gameplay.Niederlassung;
using Conspiratio.Lib.Gameplay.Privilegien.FestGeben;
using Conspiratio.Lib.Gameplay.Schreibstube;
using Conspiratio.Lib.Gameplay.Spielwelt;

// Problem: Diese Types werden wohl nicht vom SerializationBinder aufgelöst sondern intern, was dann bei der Deserialisierung zu einer TypeLoadException führt, siehe auch: https://stackoverflow.com/a/55379118/13328804
// Exceptiondetails (System.Exception {System.TypeLoadException}):
// Message: Der Typ "Conspiratio.Kampf.RaubSchuetze" in der Assembly "Conspiratio, Version=1.4.3.0, Culture=neutral, PublicKeyToken=null" konnte nicht geladen werden.
// TypeName: Conspiratio.Kampf.RaubSchuetze"
//
// Lösung:
// In der alten Assembly folgendes Attribut für das Forwarding des Types einfügen:
[assembly: TypeForwardedTo(typeof(RaubBombenleger))]
[assembly: TypeForwardedTo(typeof(RaubRaeuber))]
[assembly: TypeForwardedTo(typeof(RaubKanonier))]
[assembly: TypeForwardedTo(typeof(RaubSchuetze))]
[assembly: TypeForwardedTo(typeof(ZollSoeldner))]
[assembly: TypeForwardedTo(typeof(ZollKanonier))]
[assembly: TypeForwardedTo(typeof(ZollMusketier))]
[assembly: TypeForwardedTo(typeof(ZollOffizier))]

namespace Conspiratio
{
    public partial class Form1 : frmBasis
    {
        #region Variablen

        #region Soundplayer
        
        C_Musik C_MusikInstanz;

        #endregion

        #region Sonstiges
        int mouse_x;
        int mouse_y;

        Graphics g;

        int switch_case;
        int vorige_switch_case;

        bool marked_einzelspieler;
        bool marked_credits;
        bool marked_beenden;
        bool marked_tutorial;
        bool marked_optionen;
        bool GameStarted;

        readonly int mBildschirmbreite;
        readonly int mBildschirmhoehe;
        readonly int maxVerschiedeneAuftraege;
        int BrautwerbungButtonKlick = 0;
        int globalAktiveStadt;

        #endregion

        #region Posi_Ort
        int aktuellePosition;

        const int Posi_Kontor = 1;
        const int Posi_Handel = 2;
        const int Posi_Stadt = 3;
        const int Posi_Hinter = 4;
        const int Posi_Buch = 5;
        const int Posi_ZugNachrichten = 6;
        const int Posi_NaechsterSpieler = 7;
        const int Posi_Schreibstube = 8;
        const int Posi_Kreditbuch = 9;
        const int Posi_Wahl = 10;
        const int Posi_Kirche = 11;
        const int Posi_Kupplerin = 12;
        const int Posi_Kirchgang = 13;
        const int Posi_Kind = 14;
        const int Posi_Tod = 15;
        const int Posi_Hochzeit = 16;
        const int Posi_Testament = 17;
        const int Posi_Kindstod = 19;
        const int Posi_Ende = 20;
        const int Posi_Intro = 21;
        const int Posi_Hauptmenue = 22;
        const int Posi_Kerker = 26;
        const int Posi_Amtsenthebung = 27;
        const int Posi_Gericht = 28;
        const int Posi_Credits = 29;
        const int Posi_Abstimmung = 30;
        const int Posi_RundenNachrichten = 31;
        #endregion

        #region Handelrechtecke
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
        #endregion

        #region Stadtkoordinaten
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

        int kont_handl, kont_handt, kont_handr, kont_handb;
        int kont_kircl, kont_kirct, kont_kircr, kont_kircb;
        int kont_schrl, kont_schrt, kont_schrr, kont_schrb;
        int kont_hintl, kont_hintt, kont_hintr, kont_hintb;
        int kont_kampf_l, kont_kampf_t, kont_kampf_r, kont_kampf_b;
        int kont_fenst_l, kont_fenst_t, kont_fenst_r, kont_fenst_b;

        int hint_spiol, hint_spiot, hint_spior, hint_spiob;
        int hint_sabol, hint_sabot, hint_sabor, hint_sabob;
        int hint_ermol, hint_ermot, hint_ermor, hint_ermob;
        int hint_erprl, hint_erprt, hint_erprr;
        int hint_bezil, hint_bezit, hint_bezir, hint_bezib;
        int hint_anscl, hint_ansct, hint_anscr, hint_anscb;

        int schr_geldl, schr_geldt, schr_geldr, schr_geldb;
        int schr_kredl, schr_kredt, schr_kredr, schr_kredb;
        int schr_bewel, schr_bewet, schr_bewer, schr_beweb;
        int schr_gesel, schr_geset, schr_geser, schr_geseb;
        int schr_privl, schr_privt, schr_privr, schr_privb;
        int schr_kontl, schr_kontt, schr_kontr, schr_kontb;

        int kirc_gangl, kirc_gangt, kirc_gangr, kirc_gangb;
        int kirc_konvl, kirc_konvt, kirc_konvr, kirc_konvb;
        int kirc_austl, kirc_austt, kirc_austr, kirc_austb;

        int gang_ablal, gang_ablat, gang_ablar, gang_ablab;
        int gang_beicl, gang_beict, gang_beicr, gang_beicb;
        int gang_braul, gang_braut, gang_braur, gang_braub;
        int gang_waisenkind_l, gang_waisenkind_t, gang_waisenkind_r, gang_waisenkind_b;

        int haup_spl, haup_spt, haup_spr, haup_spb;
        int haup_netzl, haup_netzt, haup_netzr, haup_netzb;
        int haup_optl, haup_optt, haup_optr, haup_optb;
        int haup_credl, haup_credt, haup_credr, haup_credb;
        int haup_beenl, haup_beent, haup_beenr, haup_beenb;
        #endregion

        #endregion

        #region Konstruktor
        public Form1()
        {
            //Beim ersten Mal aufrufen wird der Speicherort schnell gespeichert und die Schriftart festgelegt
            Grafik.InitialisiereSchriftarten();

            InitializeComponent();
            this.BackgroundImage = null;

            lbl_nachrichten_titel.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
            lbl_spielernameundamt.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
            
            ////Netzwerk
            //Application.ApplicationExit += new EventHandler(OnApplicationExit);

            CurSwordActive();

            #region Grafiken laden
            btn_kreditb_tilg_0.BackgroundImage = new Bitmap(Properties.Resources.SymbMuenzen);
            btn_kreditb_tilg_1.BackgroundImage = new Bitmap(Properties.Resources.SymbMuenzen);
            btn_kreditb_tilg_2.BackgroundImage = new Bitmap(Properties.Resources.SymbMuenzen);
            btn_kreditb_tilg_3.BackgroundImage = new Bitmap(Properties.Resources.SymbMuenzen);

            pct_w_st1.BackgroundImage = new Bitmap(Properties.Resources.SymbStimme);
            pct_w_st2.BackgroundImage = new Bitmap(Properties.Resources.SymbStimme);
            pct_w_st3.BackgroundImage = new Bitmap(Properties.Resources.SymbStimme);

            pct_amtsent_1.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            pct_amtsent_2.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);
            pct_amtsent_3.BackgroundImage = new Bitmap(Properties.Resources.SymbNV);

            btn_stadt_transport.BackgroundImage = new Bitmap(Properties.Resources.SymbKaravane);
            btn_runde_beenden.BackgroundImage = new Bitmap(Properties.Resources.SonstPergament);
            #endregion

            C_MusikInstanz = new C_Musik();

            #region Defines

            switch_case = 0;

            globalAktiveStadt = 1;
            maxVerschiedeneAuftraege = 4;

            mBildschirmbreite = Grafik.GetNormBildschirmBreite();
            mBildschirmhoehe = Grafik.GetNormBildschirmHoehe();

            lbl_kupplerin_text.Text = "Ihr begebt Euch zu einer Kupplerin um Euch eine ziemende\nGattin zu suchen. Wollt Ihr die Wahl Eurer zukünftigen \nFrau der erfahrenen";
            lbl_kupplerin_text.SendToBack();

            lbl_nachrichten_text.SendToBack();  // Damit der Text nicht die anderen verdeckt

            aktuellePosition = Posi_Intro;
            #endregion

            this.ShowInTaskbar = true;
        }
        #endregion

        #region Form1_Shown
        private async void Form1_Shown(object sender, EventArgs e)
        {
            this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurSword.ani");
            await IntroAusfuehren();
        }
        #endregion

        #region Form1_FormClosed
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Folgende Zeile verhindert, dass sich Conspiratio bei ALT + F4 nicht richtig beendet.
            // Liegt scheinbar irgendwie am Soundplayer, bei deaktivierter Musik tritt das Problem nicht auf.
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        #endregion

        #region Form1_Activated
        private void Form1_Activated(object sender, EventArgs e)
        {
            if (lbl_Taler != null && lbl_Taler.Visible)
                UI.TalerAendern(0, ref lbl_Taler);
        }
        #endregion


        #region Spielereingaben

        #region MouseMove
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;
            this.Focus();

            #region Kontor
            if (aktuellePosition == Posi_Kontor)
            {
                //Handel Label
                if (mouse_x > kont_handl && mouse_x < kont_handr && mouse_y > kont_handt && mouse_y < kont_handb)
                {
                    label1.Visible = true;
                }
                else
                {
                    label1.Visible = false;
                }

                //Hinterzimmer Label
                if (mouse_x > kont_hintl && mouse_x < kont_hintr && mouse_y > kont_hintt && mouse_y < kont_hintb)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                }

                //Kirche Label
                if (mouse_x > kont_kircl && mouse_x < kont_kircr && mouse_y > kont_kirct && mouse_y < kont_kircb)
                {
                    label4.Visible = true;
                }
                else
                {
                    label4.Visible = false;
                }

                //Schreibstube Label
                if (mouse_x > kont_schrl && mouse_x < kont_schrr && mouse_y > kont_schrt && mouse_y < kont_schrb)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                }

                // Söldner & Räuber Label
                if (mouse_x > kont_kampf_l && mouse_x < kont_kampf_r && mouse_y > kont_kampf_t && mouse_y < kont_kampf_b)
                    label5.Visible = true;
                else
                    label5.Visible = false;

                // Geld zum Fenster rauswerfen
                if (mouse_x > kont_fenst_l && mouse_x < kont_fenst_r && mouse_y > kont_fenst_t && mouse_y < kont_fenst_b)
                    label6.Visible = true;
                else
                    label6.Visible = false;

                if (label1.Visible == true || label2.Visible == true || label3.Visible == true || label4.Visible == true || label5.Visible == true || label6.Visible == true)
                {
                    CurInfoActive();
                }
                else
                {
                    CurSwordActive();
                }
            }
            #endregion

            #region Handel
            if (aktuellePosition == Posi_Handel)
            {
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
                    switch_case = 0;
                    CurSwordActive();
                }

                if (switch_case != 0)
                {
                    CurInfoActive();
                }

                if (vorige_switch_case != switch_case)
                {
                    vorige_switch_case = switch_case;
                    Invalidate();
                }
            }
            #endregion

            #region Hinterzimmer
            if (aktuellePosition == Posi_Hinter)
            {
                //Ermordung
                if (mouse_x > hint_ermol && mouse_x < hint_ermor && mouse_y > hint_ermot & mouse_y < hint_ermob)
                {
                    label5.Visible = true;
                }
                else
                {
                    label5.Visible = false;
                }

                //Spione
                if (mouse_x > hint_spiol && mouse_x < hint_spior && mouse_y > hint_spiot & mouse_y < hint_spiob)
                {
                    label6.Visible = true;
                }
                else
                {
                    label6.Visible = false;
                }

                //Anschwaerzen
                if (mouse_x > hint_anscl && mouse_x < hint_anscr && mouse_y > hint_ansct & mouse_y < hint_anscb)
                {
                    label1.Visible = true;
                }
                else
                {
                    label1.Visible = false;
                }

                //Sabotage
                if (mouse_x > hint_sabol && mouse_x < hint_sabor && mouse_y > hint_sabot & mouse_y < hint_sabob)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                }

                //Beziehungen
                if (mouse_x > hint_bezil && mouse_x < hint_bezir && mouse_y > hint_bezit & mouse_y < hint_bezib)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                }

                ////Erpressung
                //if (mouse_x > hint_erprl && mouse_x < hint_erprr && mouse_y > hint_erprt & mouse_y < hint_erprb)
                //{
                //    label4.Visible = true;
                //}
                //else
                //{
                //    label4.Visible = false;
                //}

                if (label1.Visible == true || label2.Visible == true || label3.Visible == true || label4.Visible == true || label5.Visible == true || label6.Visible == true)
                {
                    CurInfoActive();
                }
                else
                {
                    CurSwordActive();
                }
            }
            #endregion

            #region Schreibstube
            if (aktuellePosition == Posi_Schreibstube)
            {
                if (mouse_x > schr_geldl && mouse_x < schr_geldr && mouse_y > schr_geldt && mouse_y < schr_geldb)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                }

                if (mouse_x > schr_kredl && mouse_x < schr_kredr && mouse_y > schr_kredt && mouse_y < schr_kredb)
                {
                    label4.Visible = true;
                }
                else
                {
                    label4.Visible = false;
                }

                if (SW.Dynamisch.GetAnzahlFreieAemterFuerSpX(SW.Dynamisch.GetAktiverSpieler()) > 0)
                {
                    if (mouse_x > schr_bewel && mouse_x < schr_bewer && mouse_y > schr_bewet && mouse_y < schr_beweb)
                    {
                        label1.Visible = true;
                    }
                    else
                    {
                        label1.Visible = false;
                    }
                }

                if (mouse_x > schr_gesel && mouse_x < schr_geser && mouse_y > schr_geset & mouse_y < schr_geseb)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                }

                if (mouse_x > schr_privl && mouse_x < schr_privr && mouse_y > schr_privt & mouse_y < schr_privb)
                {
                    label5.Visible = true;
                }
                else
                {
                    label5.Visible = false;
                }

                if (mouse_x > schr_kontl && mouse_x < schr_kontr && mouse_y > schr_kontt & mouse_y < schr_kontb)
                {
                    label6.Visible = true;
                }
                else
                {
                    label6.Visible = false;
                }


                if (label1.Visible == true || label2.Visible == true || label3.Visible == true || label4.Visible == true || label5.Visible == true || label6.Visible == true)
                {
                    CurInfoActive();
                }
                else
                {
                    CurSwordActive();
                }
            }
            #endregion

            #region Kirche
            if (aktuellePosition == Posi_Kirche)
            {

                if (mouse_x > kirc_gangl && mouse_x < kirc_gangr && mouse_y > kirc_gangt && mouse_y < kirc_gangb)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                }

                if (mouse_x > kirc_konvl && mouse_x < kirc_konvr && mouse_y > kirc_konvt && mouse_y < kirc_konvb)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                }

                if (mouse_x > kirc_austl && mouse_x < kirc_austt && mouse_y > kirc_austt && mouse_y < kirc_austb)
                {
                    label1.Visible = true;
                }
                else
                {
                    label1.Visible = false;
                }

                if (mouse_x > gang_braul && mouse_x < gang_braur && mouse_y > gang_braut && mouse_y < gang_braub)
                {
                    label4.Visible = true;
                }
                else
                {
                    label4.Visible = false;
                }
            }
            #endregion

            #region Kirchgang
            if (aktuellePosition == Posi_Kirchgang)
            {
                if (mouse_x > gang_beicl && mouse_x < gang_beicr && mouse_y > gang_beict && mouse_y < gang_beicb)
                {
                    label2.Visible = true;
                }
                else
                {
                    label2.Visible = false;
                }

                if (mouse_x > gang_ablal && mouse_x < gang_ablar && mouse_y > gang_ablat && mouse_y < gang_ablab)
                {
                    label1.Visible = true;
                }
                else
                {
                    label1.Visible = false;
                }

                if (mouse_x > gang_waisenkind_l && mouse_x < gang_waisenkind_r && mouse_y > gang_waisenkind_t && mouse_y < gang_waisenkind_b)
                {
                    label3.Visible = true;
                }
                else
                {
                    label3.Visible = false;
                }
            }
            #endregion

            #region Hauptmenue

            if (aktuellePosition == Posi_Hauptmenue)
            {
                if (mouse_x > haup_netzl && mouse_x < haup_netzr && mouse_y > haup_netzt && mouse_y < haup_netzb)
                {
                    marked_tutorial = true;
                }
                else
                {
                    marked_tutorial = false;
                }


                if (mouse_x > haup_spl && mouse_x < haup_spr && mouse_y > haup_spt && mouse_y < haup_spb)
                {
                    marked_einzelspieler = true;
                }
                else
                {
                    marked_einzelspieler = false;
                }


                if (mouse_x > haup_credl && mouse_x < haup_credr && mouse_y > haup_credt && mouse_y < haup_credb)
                {
                    marked_credits = true;
                }
                else
                {
                    marked_credits = false;
                }


                if (mouse_x > haup_beenl && mouse_x < haup_beenr && mouse_y > haup_beent && mouse_y < haup_beenb)
                {
                    marked_beenden = true;
                }
                else
                {
                    marked_beenden = false;
                }


                if (mouse_x > haup_optl && mouse_x < haup_optr && mouse_y > haup_optt && mouse_y < haup_optb)
                {
                    marked_optionen = true;
                }
                else
                {
                    marked_optionen = false;
                }


            }

            #endregion

            #region Stadt

            if (aktuellePosition == Posi_Stadt)
            {
                CurSwordActive();
            }

            #endregion
        }

        private void btn_stadt_prod0_Produkt_MouseMove(object sender, MouseEventArgs e)
        {
            CurInfoActive();
        }

        private void btn_stadt_prod1_Produkt_MouseMove(object sender, MouseEventArgs e)
        {
            CurInfoActive();
        }

        private void btn_stadt_prod0_Taetigkeit_MouseMove(object sender, MouseEventArgs e)
        {
            CurSwordActive();
        }

        private void btn_stadt_prod1_Taetigkeit_MouseMove(object sender, MouseEventArgs e)
        {
            CurSwordActive();
        }

        private void lbl_stadt_prod0_text1_MouseMove(object sender, MouseEventArgs e)
        {
            CurSwordActive();
        }

        private void lbl_stadt_prod0_text2_MouseMove(object sender, MouseEventArgs e)
        {
            CurSwordActive();
        }

        private void lbl_stadt_prod1_kosten_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void lbl_stadt_prod1_text1_MouseMove(object sender, MouseEventArgs e)
        {
            CurSwordActive();
        }

        private void lbl_stadt_prod1_text2_MouseMove(object sender, MouseEventArgs e)
        {
            CurSwordActive();
        }

        private void lbl_stadt_roh1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (mouse_y >= lbl_stadt_roh1.Height / 2)
            {
                CurMinusActive();
            }
            else
            {
                CurPlusActive();
            }
        }

        private void lbl_stadt_roh2_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (mouse_y >= lbl_stadt_roh2.Height / 2)
            {
                CurMinusActive();
            }
            else
            {
                CurPlusActive();
            }
        }

        private void lbl_stadt_roh3_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (mouse_y >= lbl_stadt_roh3.Height / 2)
            {
                CurMinusActive();
            }
            else
            {
                CurPlusActive();
            }
        }

        private void lbl_stadt_roh4_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (mouse_y >= lbl_stadt_roh4.Height / 2)
            {
                CurMinusActive();
            }
            else
            {
                CurPlusActive();
            }
        }

        private void lbl_stadt_roh5_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (mouse_y >= lbl_stadt_roh5.Height / 2)
            {
                CurMinusActive();
            }
            else
            {
                CurPlusActive();
            }
        }

        private void lbl_stadt_roh6_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_x = e.X;
            mouse_y = e.Y;

            if (mouse_y >= lbl_stadt_roh6.Height / 2)
            {
                CurMinusActive();
            }
            else
            {
                CurPlusActive();
            }
        }
        #endregion

        #region MouseDown
        private async void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool Rechtsklick = false;

            //if (e.Button == MouseButtons.Left)
            //{
            //    MausKoordinatenAnzeigen();
            //}

            switch (aktuellePosition)
            {
                case Posi_Kontor:
                    {
                        #region Handel
                        if (label1.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label1.Visible = false;
                                PositionWechseln(Posi_Handel);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Waren herstellen, verkaufen, einkaufen, exportieren und vieles mehr");
                            }
                        }
                        #endregion

                        #region Hinterzimmer
                        else if (label2.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label2.Visible = false;
                                PositionWechseln(Posi_Hinter);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Euren Konkurrenten das Leben schwer machen oder auch einige als Verbündete gewinnen");
                            }
                        }
                        #endregion

                        #region Schreibstube
                        else if (label3.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label3.Visible = false;
                                PositionWechseln(Posi_Schreibstube);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Der meiste Papierkram wird hier erledigt. Hier könnt Ihr bei Wahlen kandidieren, Kredite aufnehmen, die Gesetze einsehen und vieles mehr");
                            }
                        }
                        #endregion

                        #region Kirche
                        else if (label4.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label4.Visible = false;
                                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetReligion() != SW.Statisch.GetRelFreiID())
                                {
                                    PositionWechseln(Posi_Kirche);
                                }
                                else
                                {
                                    FormKonfessionslos fkl = new FormKonfessionslos();
                                    fkl.ShowDialog();
                                }
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr fast alle religiösen Tätigkeiten ausüben. Ob heiraten, beichten oder anderes");
                            }
                        }
                        #endregion

                        #region Räuber und Söldner
                        else if (label5.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label5.Visible = false;

                                // Karte mit Burgen und Lagern anzeigen
                                frmSoeldnerRaeuberKarte oSoeldnerRaeuberKarte = new frmSoeldnerRaeuberKarte();
                                oSoeldnerRaeuberKarte.ShowDialog();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen($"Hier könnt Ihr Zollburgen und Räuberlager verwalten und ganz {SW.Dynamisch.GetReichWithID(SW.Statisch.GetMinReichID()).GetGebietsName()} mit Krieg überziehen.");
                            }
                        }
                        #endregion

                        #region Geld zum Fenster rauswerfen
                        else if (label6.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label6.Visible = false;
                                await SpielerHinauswerfen();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen($"Damit könnt Ihr Euch aus Euren Geschäften vollständig zurückziehen.");
                            }
                        }
                        #endregion

                        #region Runde beenden
                        else if (e.Button == MouseButtons.Right)
                        {
                            if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr Euren Zug \n wirklich beenden?") == DialogResult.Yes)
                            {
                                label1.Visible = false;
                                label2.Visible = false;
                                label3.Visible = false;
                                label4.Visible = false;
                                await ZugBeenden();
                            }
                        }
                        #endregion
                        break;
                    }
                case Posi_Handel:
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            // Zurückkehren zu Pos_Kontor
                            if (switch_case == 0)
                            {
                                this.Focus();
                                // Banner ausblenden
                                for (int i = SW.Statisch.GetMinStadtID(); i < SW.Statisch.GetMaxStadtID(); i++)
                                {
                                    this.Controls["pictureBox" + i.ToString()].Visible = false;
                                }

                                SpielerInfosEinAusBlenden(true);
                                PositionWechseln(Posi_Kontor);
                            }
                            else
                            {
                                StadtInformationen si = new StadtInformationen(switch_case);
                                si.ShowDialog();
                            }
                        }
                        else if (e.Button == MouseButtons.Left)
                        {
                            if (switch_case >= 1 && switch_case <= 14)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                VonHandelZuStadtXWechseln(switch_case);  // Zu Stadt wechseln
                            }
                        }
                        break;
                    }
                case Posi_Stadt:
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            // Zurückkehren zu Handel
                            PositionWechseln(Posi_Handel);
                        }
                        break;
                    }
                case Posi_Hinter:
                    {
                        #region Beziehungen
                        if (label3.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(0, true);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr die Beziehung zu Euren Konkurrenten verbessern");
                            }
                        }
                        #endregion

                        #region Sabotage
                        else if (label2.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(1, true);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Euren Konkurrenten den Geldbeutel erleichtern");
                            }
                        }
                        #endregion

                        #region Anschwaerzen
                        else if (label1.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(2, true);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Eure Konkurrenten gegeneinander aufhetzen. Allerdings benötigt Ihr für Eure Anschuldigen meistens auch Beweise");
                            }
                        }
                        #endregion

                        #region Spionage
                        else if (label6.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(3, true);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Informationen und Beweise über die kriminellen Machenschaften Eurer Konkurrenten ergattern");
                            }
                        }
                        #endregion

                        #region Ermordung
                        else if (label5.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(4, true);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Euren Konkurrenten wahrlich den Garaus machen");
                            }
                        }
                        #endregion

                        #region Verlassen
                        else if (e.Button == MouseButtons.Right)
                        {
                            PositionWechseln(Posi_Kontor);
                        }
                        #endregion
                        break;
                    }
                case Posi_Schreibstube:
                    {
                        #region Gesetze
                        if (label3.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label3.Visible = false;
                                GesetzeAnzeigen ge = new GesetzeAnzeigen();
                                ge.ShowDialog();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr die Gesetze des Königreichs einsehen");
                            }
                        }
                        #endregion

                        #region Geldleiher
                        else if (label2.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label2.Visible = false;
                                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetEmptyKreditID() == 5)
                                {
                                    SW.Dynamisch.BelTextAnzeigen("Niemand ist mehr bereit, Euch in diesem Jahr noch weitere Taler vorzustrecken");
                                }
                                else
                                {
                                    KreditNehmen();
                                }
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Kredite nehmen");
                            }
                        }
                        #endregion

                        #region Kreditbuch
                        else if (label4.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label4.Visible = false;
                                await KreditbuchZeigen();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Kredite tilgen");
                            }
                        }
                        #endregion

                        #region Bewerbung
                        else if (label1.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label1.Visible = false;
                                Bewerben();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr für freie Ämter kandidieren");
                            }
                        }
                        #endregion

                        #region Privilegien
                        else if (label5.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label5.Visible = false;
                                PrivilegienZeigen();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Eure Privilegien einsehen und ausführen. Diese Privilegien die Ihr besitzt sind abhängig von Eurem Amt, Familienstand und Titel");
                            }
                        }
                        #endregion

                        #region Kontrahenten
                        else if (label6.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                label6.Visible = false;
                                KontrahentenZeigen();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier führt Ihr Eure Aufzeichnungen über Eure Kontrahenten. Durch Spionage könnt Ihr diese Aufzeichungen ergänzen");
                            }
                        }
                        #endregion

                        #region Verlassen
                        else if (e.Button == MouseButtons.Right)
                        {
                            PositionWechseln(Posi_Kontor);
                        }
                        #endregion
                        break;
                    }
                case Posi_Kreditbuch:
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            C_MusikInstanz.PlaySound(Properties.Resources.bongo_hell);
                            Rechtsklick = true;
                            PositionWechseln(Posi_Schreibstube);
                        }
                        break;
                    }
                case Posi_Kirche:
                    {
                        #region Kirchengang
                        if (label2.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                PositionWechseln(Posi_Kirchgang);
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Hier werden Geschäfte mit der Kirche abgewickelt");
                            }
                        }
                        #endregion

                        #region KircheAustreten
                        else if (label1.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                KircheAustreten();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Durch das Austreten aus der Kirche werdet Ihr von der Kirchensteuer befreit. Allerdings ist Euch damit auch die Kandidatur für kirchliche Ämter untersagt");
                            }
                        }
                        #endregion

                        #region KircheKonvertieren
                        else if (label3.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                KircheKonvertieren();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Wechselt Euren Glauben. Dies kann Euch Sympathie Andersgläubiger einbringen");
                            }
                        }
                        #endregion

                        #region KircheBrautschau
                        else if (label4.Visible == true)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                KircheHochzeitsglocken();
                            }
                            else
                            {
                                SW.Dynamisch.BelTextAnzeigen("Um den Fortbestand Eurer Dynastie zu sichern, solltet Ihr rechtzeitig mit der Werbung um einen Ehepartner beginnen");
                            }
                        }
                        #endregion

                        #region Verlassen
                        else if (e.Button == MouseButtons.Right)
                        {
                            PositionWechseln(Posi_Kontor);
                        }
                        #endregion
                        break;
                    }
                case Posi_Kupplerin:
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            PositionWechseln(Posi_Kirche);
                        }
                        break;
                    }
                case Posi_Kirchgang:
                    {
                        var kirchgang = new Kirchgang();

                        if (e.Button == MouseButtons.Right)
                        {
                            PositionWechseln(Posi_Kirche);
                        }
                        else if (e.Button == MouseButtons.Left)
                        {
                            if (label1.Visible == true)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                kirchgang.AblassKaufen();
                            }
                            else if (label2.Visible == true)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                kirchgang.Beichten();
                            }
                            else if (label3.Visible == true)
                            {
                                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                                kirchgang.WaisenkindAdoptieren();
                            }
                        }
                        break;
                    }
                case Posi_Hauptmenue:
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);

                            if (marked_einzelspieler)
                            {
                                await NeuesSpielStarten();
                            }
                            else if (marked_tutorial)
                            {
                                TutorialHilfefAufrufen();
                            }
                            else if (marked_optionen)
                            {
                                OptionenAusfuehren();
                            }
                            else if (marked_credits)
                            {
                                await CreditsAusfuehren();
                            }
                            else if (marked_beenden)
                            {
                                await SpielBeenden();
                            }
                        }
                        break;
                    }
                case Posi_Buch:
                case Posi_ZugNachrichten:
                case Posi_NaechsterSpieler:
                case Posi_Wahl:
                case Posi_Hochzeit:
                case Posi_Tod:
                case Posi_Testament:
                case Posi_Kindstod:
                case Posi_Ende:
                case Posi_Intro:
                case Posi_Kerker:
                case Posi_Amtsenthebung:
                case Posi_Gericht:
                case Posi_Credits:
                    if (e.Button == MouseButtons.Right)
                    {
                        Rechtsklick = true;
                    }
                    break;
                default:
                    if (e.Button == MouseButtons.Right)
                    {
                        Rechtsklick = true;
                    }
                    break;
            }

            if (Rechtsklick)
                tcsRechtsklick?.TrySetResult(true);
        }

        #region Noch nicht zugeordnet
        private void lbl_spielernameundamt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_nachrichten_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_wahl_kand0_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand1_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand3_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand2_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void pct_w_st1_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void pct_w_st2_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void pct_w_st3_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (aktuellePosition == Posi_Wahl)
                {
                    tcsRechtsklick?.TrySetResult(true);
                }
                if (aktuellePosition == Posi_Credits)
                {
                    tcsRechtsklick?.TrySetResult(true);
                }
            }
        }

        private async void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (aktuellePosition == Posi_Hauptmenue)
                {
                    C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                    await NeuesSpielStarten();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (aktuellePosition == Posi_Gericht)
                {
                    tcsRechtsklick?.TrySetResult(true);
                }
                if (aktuellePosition == Posi_Credits)
                {
                    tcsRechtsklick?.TrySetResult(true);
                }
            }
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (aktuellePosition == Posi_Hauptmenue)
                {
                    C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                    TutorialHilfefAufrufen();
                }
            }
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (aktuellePosition == Posi_Hauptmenue)
                {
                    C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                    OptionenAusfuehren();
                }
            }
        }

        private async void label5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (aktuellePosition == Posi_Hauptmenue)
                {
                    C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                    await CreditsAusfuehren();
                }
            }
        }

        private async void label6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (aktuellePosition == Posi_Hauptmenue)
                {
                    C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                    await SpielBeenden();
                }
            }
        }

        private void lbl_wahl_kand4_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand5_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand6_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand7_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand8_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand9_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand10_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_wahl_kand11_MouseDown(object sender, MouseEventArgs e)
        {
            tcsRechtsklick?.TrySetResult(true);
        }

        private void lbl_buch_keineWarenprod_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_buch_Produktion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_buch_Exporte_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_buch_ex1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_verheiratet_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_nachrichten_titel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void lbl_kupplerin_text_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Kirche);
            }
        }

        private void btn_kup_selbst_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Kirche);
            }
        }

        private void btn_kup_kupplerin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Kirche);
            }
        }

        private void lbl_kreditb_0_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_tilg_0_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_tilg_1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_tilg_2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void lbl_kreditb_tilg_3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void btn_kreditb_tilg_0_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void btn_kreditb_tilg_1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void btn_kreditb_tilg_2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void btn_kreditb_tilg_3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Schreibstube);
            }
        }

        private void btn_stadt_ws1_MouseDown(object sender, MouseEventArgs e)
        {
            bool linksklick = false;
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                linksklick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                linksklick = false;
            }
            StadtWSXclick(linksklick, 1);
        }

        private void btn_stadt_ws2_MouseDown(object sender, MouseEventArgs e)
        {
            bool linksklick = false;
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                linksklick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                linksklick = false;
            }
            StadtWSXclick(linksklick, 2);
        }

        private void btn_stadt_ws3_MouseDown(object sender, MouseEventArgs e)
        {
            bool linksklick = false;
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                linksklick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                linksklick = false;
            }
            StadtWSXclick(linksklick, 3);
        }

        private void btn_stadt_ws4_MouseDown(object sender, MouseEventArgs e)
        {
            bool linksklick = false;
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                linksklick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                linksklick = false;
            }
            StadtWSXclick(linksklick, 4);
        }

        private void btn_stadt_ws5_MouseDown(object sender, MouseEventArgs e)
        {
            bool linksklick = false;
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                linksklick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                linksklick = false;
            }
            StadtWSXclick(linksklick, 5);
        }

        private void btn_stadt_ws6_MouseDown(object sender, MouseEventArgs e)
        {
            bool linksklick = false;
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                linksklick = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                linksklick = false;
            }
            StadtWSXclick(linksklick, 6);
        }

        private void lbl_stadt_roh1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_roh2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_roh3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_roh4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_roh5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_roh6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_Haus_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                HausBauen hb = new HausBauen(globalAktiveStadt);
                hb.ShowDialog();
                SpielerDatenAktualisieren();

                if (SpE.getBoolKurzSpeicher())
                {
                    SpE.setBoolKurzSpeicher(false);
                    HausAnzeigen();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr Euren Wohnsitz in dieser Stadt verwalten");
            }
        }

        private void btn_stadt_staette1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_staette2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_staette3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_staette4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_staette5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_staette6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_transport_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C_MusikInstanz.PlaySound(Properties.Resources.bongo_dunkel);
                Transport tr = new Transport(globalAktiveStadt);
                tr.ShowDialog();


                for (int i = 0; i < SW.Statisch.GetMaxProdSlots(); i++)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, i).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Verkaufen || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, i).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.PermanentVerkaufen)
                    {
                        StadtVerkTextLaden(i);
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                SW.Dynamisch.BelTextAnzeigen("Hier könnt Ihr eine Karawane auswählen, welche Eure Waren exportieren soll");
            }
        }

        private void btn_stadt_prod0_Arbeiter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_prod0_wastuter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_prod0_Werkstaetten_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_prod1_Arbeiter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_prod1_wastuter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_prod1_Werkstaetten_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_prod0_kosten_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_prod0_text1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_prod0_text2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_prod1_kosten_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_prod1_text1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void lbl_stadt_prod1_text2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PositionWechseln(Posi_Handel);
            }
        }

        private void btn_stadt_prod0_Produkt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                prodXProduktClick(0);
            }
            if (e.Button == MouseButtons.Right)
            {
                SW.Dynamisch.ProdVerhaeltnisAnzeigen(globalAktiveStadt, 0);
            }
        }

        private void btn_stadt_prod1_Produkt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                prodXProduktClick(1);
            }
            if (e.Button == MouseButtons.Right)
            {
                SW.Dynamisch.ProdVerhaeltnisAnzeigen(globalAktiveStadt, 1);
            }
        }

        private void btn_brautwerbung_m1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void btn_brautwerbung_m2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void btn_brautwerbung_m3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }

        private void btn_brautwerbung_m4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tcsRechtsklick?.TrySetResult(true);
            }
        }
        #endregion

        #endregion

        #region MouseClick

        private void btn_brautwerbung_m1_Click(object sender, EventArgs e)
        {
            if (BrautwerbungButtonKlick == 0)
            {
                BrautwerbungButtonKlick = 1;
            }

            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_brautwerbung_m2_Click(object sender, EventArgs e)
        {
            if (BrautwerbungButtonKlick == 0)
            {
                BrautwerbungButtonKlick = 2;
            }

            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_brautwerbung_m3_Click(object sender, EventArgs e)
        {
            if (BrautwerbungButtonKlick == 0)
            {
                BrautwerbungButtonKlick = 3;
            }

            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_brautwerbung_m4_Click(object sender, EventArgs e)
        {
            if (BrautwerbungButtonKlick == 0)
            {
                BrautwerbungButtonKlick = 4;
            }

            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_kup_kupplerin_Click(object sender, EventArgs e)
        {
            PartnerWaehlenKupplerin();
        }

        private void btn_kup_selbst_Click(object sender, EventArgs e)
        {
            PartnerWaehlenSelbst();
        }

        private void btn_kreditb_tilg_0_Click(object sender, EventArgs e)
        {
            KreditTilgen(0);
        }

        private void btn_kreditb_tilg_1_Click(object sender, EventArgs e)
        {
            KreditTilgen(1);
        }

        private void btn_kreditb_tilg_2_Click(object sender, EventArgs e)
        {
            KreditTilgen(2);
        }

        private void btn_kreditb_tilg_3_Click(object sender, EventArgs e)
        {
            KreditTilgen(3);
        }

        private void btn_stadt_prod0_Taetigkeit_Click(object sender, EventArgs e)
        {
            BtnStadtWasTutEr(true, 0);
        }

        private void btn_stadt_prod1_Taetigkeit_Click(object sender, EventArgs e)
        {
            BtnStadtWasTutEr(true, 1);
        }

        private void btn_stadt_prod0_Werkstaetten_Click(object sender, EventArgs e)
        {
            prodXWerkstaettenClick(0);
        }

        private void btn_stadt_prod1_Werkstaetten_Click(object sender, EventArgs e)
        {
            prodXWerkstaettenClick(1);
        }

        private void btn_stadt_roh1_Click(object sender, EventArgs e)
        {
            RohstoffXverkaufen(1);
        }

        private void btn_stadt_roh2_Click(object sender, EventArgs e)
        {
            RohstoffXverkaufen(2);
        }

        private void btn_stadt_roh3_Click(object sender, EventArgs e)
        {
            RohstoffXverkaufen(3);
        }

        private void btn_stadt_roh4_Click(object sender, EventArgs e)
        {
            RohstoffXverkaufen(4);
        }

        private void btn_stadt_roh5_Click(object sender, EventArgs e)
        {
            RohstoffXverkaufen(5);
        }

        private void btn_stadt_roh6_Click(object sender, EventArgs e)
        {
            RohstoffXverkaufen(6);
        }

        private void lbl_stadt_roh1_Click(object sender, EventArgs e)
        {
            RohstoffEinVerkaufen(1);
        }

        private void lbl_stadt_roh2_Click(object sender, EventArgs e)
        {
            RohstoffEinVerkaufen(2);
        }

        private void lbl_stadt_roh3_Click(object sender, EventArgs e)
        {
            RohstoffEinVerkaufen(3);
        }

        private void lbl_stadt_roh4_Click(object sender, EventArgs e)
        {
            RohstoffEinVerkaufen(4);
        }

        private void lbl_stadt_roh5_Click(object sender, EventArgs e)
        {
            RohstoffEinVerkaufen(5);
        }

        private void lbl_stadt_roh6_Click(object sender, EventArgs e)
        {
            RohstoffEinVerkaufen(6);
        }

        private void btn_stadt_prod0_Arbeiter_Click(object sender, EventArgs e)
        {
            prodXArbeiterClick(0);
        }

        private void btn_stadt_prod1_Arbeiter_Click(object sender, EventArgs e)
        {
            prodXArbeiterClick(1);
        }

        private async void btn_runde_beenden_Click(object sender, EventArgs e)
        {
            if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr Euren Zug \n wirklich beenden?") == DialogResult.Yes)
                await ZugBeenden();
        }
        #endregion 

        #region KeyDown
        private async void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (aktuellePosition == Posi_Kind)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    tcsEnterdruck?.TrySetResult(true);
                }
            }

            if (GameStarted == true)
            {
                if (e.KeyCode == Keys.U && SW.Dynamisch.Cheatmodus)
                {
                    if (SW.Dynamisch.GetAktiverSpieler() != 0)
                    {
                        if (aktuellePosition == Posi_Kontor)
                        {
                            Cheatbox cb = new Cheatbox();
                            cb.ShowDialog();
                            SpielerDatenAktualisieren();
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).AnsehenAktualisieren();
                            SW.Dynamisch.PrivilegienAktualisieren();

                        }
                    }
                }

                if (e.KeyCode == Keys.Escape)
                {
                    if (aktuellePosition == Posi_Kontor)
                    {
                        foreach (Control c in this.Controls)
                        {
                            c.Visible = false;
                        }

                        Optionen opt = new Optionen(ref C_MusikInstanz);
                        opt.ShowDialog();

                        SpielerInfosEinAusBlenden(true);

                        if (SpE.getIntKurzSpeicher() == 1)
                        {
                            //Statistik anzeigen
                            if (Convert.ToBoolean(Properties.Settings.Default["Statistik_anzeigen"]))
                            {
                                FormStatistik fs = new FormStatistik();
                                fs.ShowDialog();
                            }

                            HauptmenueAusfuehren();
                        }
                        else if (SpE.getIntKurzSpeicher() == 2)
                        {
                            //Statistik anzeigen
                            if (Convert.ToBoolean(Properties.Settings.Default["Statistik_anzeigen"]))
                            {
                                FormStatistik fs = new FormStatistik();
                                fs.ShowDialog();
                            }

                            await SpielBeenden();
                        }
                        else if (SpE.getIntKurzSpeicher() == 3)
                        {
                            await SpielerHinauswerfen();
                        }
                        else if (SpE.getIntKurzSpeicher() == 4)
                        {
                            SpielerHinzufuegen sh = new SpielerHinzufuegen(true);
                            sh.ShowDialog();
                        }
                        else if (SpE.getIntKurzSpeicher() == 5)
                        {
                            //Laden
                            await Laden();
                        }
                        else if (SpE.getIntKurzSpeicher() == 6)
                        {
                            //Speichern
                            SpE.setBoolKurzSpeicher(false);

                            Speicherform spf = new Speicherform();
                            spf.ShowDialog();

                            string name = SpE.getStringKurzSpeicher();
                            if (name != "")
                            {
                                SpE.setStringKurzSpeicher("");
                                Speichern(name, false);
                            }
                        }
                        else
                        {
                            btn_runde_beenden.Visible = true;
                        }

                        SpE.setIntKurzSpeicher(0);
                    }
                }

                if (aktuellePosition == Posi_Handel)
                {
                    // TODO:
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(1);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(2);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(3);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(4);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(5);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(6);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(7);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(8);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(9);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(10);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(11);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(12);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(13);
                    //}
                    //if (e.KeyCode == Keys.F)
                    //{
                    //    VonHandelZuStadtXWechseln(14);
                    //}
                }
            }
        }
        #endregion

        #region Namen Eingeben
        private void txb_namenEingeben_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true; //Verhindert den Windows-Fehler-Sound (Piep)
            }

            if (aktuellePosition == Posi_Kind) //Changed:  || aktuellePosition == Posi_SpielerHinzufuegen
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    //Überprüfen ob der Name auch die vorgegebene Mindestlänge hat
                    if (txb_namenEingeben.Text.Length >= SW.Statisch.GetMinNameLength())
                    {
                        bool check = true;
                        //Auf gleiche Name abfragen
                        for (int i = 1; i < SW.Dynamisch.GetAktiverSpieler(); i++)
                        {
                            if (SW.Dynamisch.GetHumWithID(i).GetName() == txb_namenEingeben.Text)
                            {
                                SW.Dynamisch.BelTextAnzeigen("Es ist bereits ein Mitspieler mit demselben Namen vorhanden. Bitte wählt einen anderen");
                                check = false;
                                break;
                            }
                        }
                        if (check)
                        {
                            tcsEnterdruck?.TrySetResult(true);
                        }
                    }
                    else
                    {
                        SW.Dynamisch.BelTextAnzeigen("Euer Name muss aus mindestens\n3 Zeichen bestehen");
                    }
                }
            }
        }

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
        #endregion

        #region Paint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            #region Handel
            if (aktuellePosition == Posi_Handel)
            {
                if (switch_case == 1)
                {
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
        }
        #endregion

        #endregion
        


        #region Graphische Darstellungen

        #region PositionWechseln
        private void PositionWechseln(int wechselnzu)
        {
            int vorigePosition = aktuellePosition;
            aktuellePosition = wechselnzu;
            string Hintergrundbildname = "";
            bool ortdatumAktualisieren = true;
            bool bMusikEinschieben = false;

            // Idee: Alle Objekte werden zuerst ausgeblendet. Dannach werden für den aufgerufenen Ort die benötigten Objekte eingeblendet
            foreach (Control C in this.Controls) 
            {
                C.Visible = false; 
            }

            switch (wechselnzu)
            {
                #region Case 1: Ort_Kontor
                case 1: //Kontor
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintKontor);
                    Hintergrundbildname = "Kontor";
                    SpielerInfosEinAusBlenden(true);

                    label1.Text = "Handel";
                    label1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label1.Left = (kont_handl + kont_handr - label1.Width) / 2;
                    label1.Top = kont_handt - label1.Height;

                    label2.Text = "Hinterzimmer";
                    label2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label2.Left = (kont_hintl + kont_hintr - label2.Width) / 2;
                    label2.Top = kont_hintt + NormH(35);

                    label3.Text = "Schreibstube";
                    label3.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label3.Left = (kont_schrl + kont_schrr - label3.Width) / 2;
                    label3.Top = kont_schrt - label3.Height - NormH(15);

                    label4.Text = "Kirche";
                    label4.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label4.Left = (kont_kircl + kont_kircr - label4.Width) / 2;
                    label4.Top = kont_kirct - label4.Height - NormH(10);

                    label5.Text = "Söldner && Räuber";
                    label5.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label5.Left = (kont_kampf_l + kont_kampf_r - label5.Width) / 2;
                    label5.Top = kont_kampf_t - label5.Height - NormH(10);

                    label6.Text = "Geld zum Fenster\nrauswerfen";
                    label6.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label6.Left = (kont_fenst_l + kont_fenst_r - label6.Width) / 2 - NormB(15);
                    label6.Top = kont_fenst_t - label6.Height + NormH(50);
                    label6.TextAlign = ContentAlignment.MiddleCenter;

                    btn_runde_beenden.Visible = true;

                    break;
                #endregion

                #region Case 2: Ort_Handel
                case 2:
                    this.BackgroundImage = new Bitmap(Properties.Resources.PWK);
                    Hintergrundbildname = "Handel";
                    SpielerInfosEinAusBlenden(false);

                    HandelFlaggenEinblenden();
                    this.Focus();

                    if (vorigePosition == Posi_Stadt)
                    {
                        //Rohstoffe von Spieler Speichern
                        for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
                        {
                            int anzah = RohstoffAnzahlZubereiten(this.Controls["lbl_stadt_roh" + (i).ToString()].Text);
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(globalAktiveStadt, SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i), anzah);
                        }  
                    }
                    break;
                #endregion

                #region Case 3: Ort_Stadt
                case 3:
                    SpielerInfosEinAusBlenden(true);

                    
                    break;
                #endregion

                #region Case 4: Ort_Hinterzimmer
                case 4: //Hinterzimmer
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintHinterzimmer);
                    Hintergrundbildname = "Hinterzimmer";
                    SpielerInfosEinAusBlenden(true);

                    label1.Text = "Anschwärzen";
                    label1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label1.Left = (hint_anscl + hint_anscr - label1.Width) / 2;
                    label1.Top = hint_ansct - label1.Height - NormH(10);

                    label2.Text = "Sabotage";
                    label2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label2.Left = (hint_sabol + hint_sabor - label2.Width) / 2;
                    label2.Top = hint_sabot - label2.Height - NormH(10);

                    label3.Text = "Beziehungen";
                    label3.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label3.Left = (hint_bezil + hint_bezir - label3.Width) / 2;
                    label3.Top = hint_bezit - label3.Height - NormH(10);

                    label4.Text = "Erpressung";
                    label4.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label4.Left = (hint_erprl + hint_erprr - label4.Width) / 2;
                    label4.Top = hint_erprt - label4.Height - NormH(10);

                    label5.Text = "Ermordung";
                    label5.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label5.Left = (hint_ermol + hint_ermor - label5.Width) / 2;
                    label5.Top = hint_ermot - label5.Height - NormH(10);

                    label6.Text = "Spione";
                    label6.Font = Grafik.GetStandardFont(Grafik.GetSchriftgGross());
                    label6.Left = (hint_spiol + hint_spior - label6.Width) / 2;
                    label6.Top = hint_spiot - label6.Height - NormH(10);

                    C_MusikInstanz.MusikEinschieben_HZ();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 5: Ort_Buch
                case 5:
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintBuchOffen);
                    Hintergrundbildname = "Buch";
                    SpielerInfosEinAusBlenden(true);
                    break;
                #endregion

                #region Case 6: Ort_Zugnachrichten
                case 6: //Zugnachrichten
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintZugNachrichten);
                    Hintergrundbildname = "Nachrichten";
                    SpielerInfosEinAusBlenden(true);

                    lbl_nachrichten_titel.Top = NormH(195);
                    lbl_nachrichten_titel.Width = NormB(800);
                    lbl_nachrichten_titel.Left = (this.Width - lbl_nachrichten_titel.Width) / 2;
                    lbl_nachrichten_titel.Visible = true;

                    lbl_nachrichten_text.Top = lbl_nachrichten_titel.Top + lbl_nachrichten_titel.Height + NormH(15);
                    lbl_nachrichten_text.Left = lbl_nachrichten_titel.Left;
                    lbl_nachrichten_text.Width = lbl_nachrichten_titel.Width;
                    lbl_nachrichten_text.Visible = true;

                    label1.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());
                    label2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());
                    label3.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());
                    label4.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());
                    label5.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());
                    label6.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());

                    break;
                #endregion

                #region Case 7: Ort_Ankuendigung
                case 7:
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintNaechsterSpieler);
                    Hintergrundbildname = "Ankündigung";
                    SpielerInfosEinAusBlenden(false);
                    label1.Visible = true;
                    break;
                #endregion

                #region Case 8: Ort_Schreibstube
                case 8:
                    if (SW.Dynamisch.GetAnzahlFreieAemterFuerSpX(SW.Dynamisch.GetAktiverSpieler()) > 0) 
                    { this.BackgroundImage = new Bitmap(Properties.Resources.HintSchreibstube2); }
                    else 
                    { this.BackgroundImage = new Bitmap(Properties.Resources.HintSchreibstube1); }
                    Hintergrundbildname = "Schreibstube";
                    SpielerInfosEinAusBlenden(true);

                    label1.Text = "Bewerbung";
                    label1.Left = (schr_bewel + schr_bewer - label1.Width) / 2;
                    label1.Top = schr_bewet - label1.Height - NormH(10);

                    label2.Text = "Geldleiher";
                    label2.Left = (schr_geldl + schr_geldr - label2.Width) / 2;
                    label2.Top = schr_geldt - label2.Height - NormH(10);

                    label3.Text = "Gesetze";
                    label3.Left = (schr_gesel + schr_geser - label3.Width) / 2;
                    label3.Top = schr_geset - label3.Height - NormH(10);

                    label4.Text = "Kreditbuch";
                    label4.Left = (schr_kredl + schr_kredr - label4.Width) / 2;
                    label4.Top = schr_kredt - label4.Height - NormH(10);

                    label5.Text = "Privilegien";
                    label5.Left = (schr_privl + schr_privr - label5.Width) / 2;
                    label5.Top = schr_privt - label5.Height - NormH(10);

                    label6.Text = "Kontrahenten";
                    label6.Left = (schr_kontl + schr_kontr - label6.Width) / 2;
                    label6.Top = schr_kontt - label6.Height - NormH(10);

                    break;
                #endregion

                #region Case 9: Ort_Buch
                case 9:
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintBuchOffen);
                    Hintergrundbildname = "Buch";
                    SpielerInfosEinAusBlenden(true);
                    break;
                #endregion

                #region Case 10: Ort_Wahl
                case 10:
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintWahl);
                    Hintergrundbildname = "Wahl";
                    SpielerInfosEinAusBlenden(false);

                    label1.Text = "";
                    label1.Top = this.Height - label1.Height - NormH(100);
                    label1.Visible = true;

                    label2.Top = NormH(130);
                    lbl_wahl_kand0.Top = label2.Top + label2.Height + NormH(50);
                    lbl_wahl_kand1.Top = lbl_wahl_kand0.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand2.Top = lbl_wahl_kand1.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand3.Top = lbl_wahl_kand2.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand4.Top = lbl_wahl_kand3.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand5.Top = lbl_wahl_kand4.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand6.Top = lbl_wahl_kand5.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand7.Top = lbl_wahl_kand6.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand8.Top = lbl_wahl_kand7.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand9.Top = lbl_wahl_kand8.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand10.Top = lbl_wahl_kand9.Top + lbl_wahl_kand1.Height + NormH(10);
                    lbl_wahl_kand11.Top = lbl_wahl_kand10.Top + lbl_wahl_kand1.Height + NormH(10);

                    btn_wahl_0.Top = lbl_wahl_kand0.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_1.Top = lbl_wahl_kand1.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_2.Top = lbl_wahl_kand2.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_3.Top = lbl_wahl_kand3.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_4.Top = lbl_wahl_kand4.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_5.Top = lbl_wahl_kand5.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_6.Top = lbl_wahl_kand6.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_7.Top = lbl_wahl_kand7.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_8.Top = lbl_wahl_kand8.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_9.Top = lbl_wahl_kand9.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_10.Top = lbl_wahl_kand10.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    btn_wahl_11.Top = lbl_wahl_kand11.Top + lbl_wahl_kand0.Height / 2 - btn_wahl_0.Height / 2;
                    break;
                #endregion

                #region Case 11: Ort_Kirche
                case 11:
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetReligion() == SW.Statisch.GetRelKathID())
                    {
                        this.BackgroundImage = new Bitmap(Properties.Resources.HintKirche1);
                    }
                    else if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetReligion() == SW.Statisch.GetRelEvanID())
                    {
                        this.BackgroundImage = new Bitmap(Properties.Resources.HintKirche2);
                    }
                    Hintergrundbildname = "Kirche";
                    SpielerInfosEinAusBlenden(true);

                    label1.Text = "Austreten";
                    label1.Left = (kirc_austl + kirc_austr - label1.Width) / 2;
                    label1.Top = kirc_austt - label1.Height - NormH(10);

                    label2.Text = "Kirchgang";
                    label2.Left = (kirc_gangl + kirc_gangr - label2.Width) / 2;
                    label2.Top = kirc_gangt - label2.Height - NormH(10);

                    label3.Text = "Konvertieren";
                    label3.Left = (kirc_konvl + kirc_konvr - label3.Width) / 2;
                    label3.Top = kirc_konvt - label3.Height - NormH(10);

                    label4.Text = "Hochzeitsglocken";
                    label4.Left = (gang_braul + gang_braur - label4.Width) / 2;
                    label4.Top = gang_braut - label4.Height + NormH(2);

                    C_MusikInstanz.MusikEinschieben_Kirche();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 12: Ort_Kupplerin
                case 12:
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintKupplerin);
                    Hintergrundbildname = "Kupplerin";
                    SpielerInfosEinAusBlenden(true);

                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                    {
                        lbl_kupplerin_text.Text = "Ihr begebt Euch zu einer Kupplerin um Euch eine ziemende\nGattin zu suchen. Wollt Ihr die Wahl Eurer zukünftigen \nFrau der erfahrenen";
                    }
                    else
                    {
                        lbl_kupplerin_text.Text = "Ihr begebt Euch zu einer Kupplerin um Euch einen ziemenden\nGatten zu suchen. Wollt Ihr die Wahl Eures zukünftigen \nEhepartners der erfahrenen";
                    }
                    lbl_kupplerin_text.Visible = true;
                    btn_kup_kupplerin.Visible = true;
                    btn_kup_selbst.Visible = true;
                    lbl_kup_1.Visible = true;
                    lbl_kup_2.Visible = true;

                    C_MusikInstanz.MusikEinschieben_Kirche();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 13: Ort_Kirchgang
                case 13:
                    this.BackgroundImage = new Bitmap(Properties.Resources.HintKirchgang);
                    Hintergrundbildname = "Kirchgang";
                    SpielerInfosEinAusBlenden(true);

                    

                    label1.Text = "Ablass kaufen";
                    label1.Left = (gang_ablal + gang_ablar - label1.Width) / 2;
                    label1.Top = gang_ablat - label1.Height - NormH(10);

                    label2.Text = "Beichten";
                    label2.Left = (gang_beicl + gang_beicr - label2.Width) / 2;
                    label2.Top = gang_beict - label2.Height - NormH(10);

                    label3.Text = "Waisenkind adoptieren";
                    label3.Left = (gang_waisenkind_l + gang_waisenkind_r - label3.Width) / 2;
                    label3.Top = gang_waisenkind_t - label3.Height + NormH(20);

                    this.Focus();

                    C_MusikInstanz.MusikEinschieben_Kirche();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 14: Ort_Geburt
                case 14:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintKindGeboren);
                    Hintergrundbildname = "Nachwuchs";
                    SpielerInfosEinAusBlenden(true);

                    txb_namenEingeben.Text = "";
                    label1.ForeColor = Color.Gold;
                    label1.Visible = true;
                    txb_namenEingeben.Visible = true;

                    C_MusikInstanz.MusikEinschieben_Geburt();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 15: Ort_Spielertod
                case 15:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintSpielerTod);
                    Hintergrundbildname = "Todesfall";
                    SpielerInfosEinAusBlenden(true);

                    C_MusikInstanz.MusikEinschieben_Tod();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 16: Trauung
                case 16:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintTrauung);
                    Hintergrundbildname = "Trauung";
                    SpielerInfosEinAusBlenden(true);

                    C_MusikInstanz.MusikEinschieben_Hochzeit();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 17: Testament
                case 17:
                    SpielerInfosEinAusBlenden(true);
                    break;
                #endregion

                case 18:
                    break;

                #region Case 19: Ort_Kindertod
                case 19:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintKindStirbt);
                    Hintergrundbildname = "Tragischer Verlust";
                    SpielerInfosEinAusBlenden(true);

                    C_MusikInstanz.MusikEinschieben_Tod();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 20: Ort_Outro
                case 20:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintOutro);
                    Hintergrundbildname = "Outro";
                    SpielerInfosEinAusBlenden(false);
                    ortdatumAktualisieren = false;

                    C_MusikInstanz.MusikEinschieben_Outro();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 21: Ort_Intro
                case 21:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintIntro);
                    Hintergrundbildname = "Intro";
                    SpielerInfosEinAusBlenden(false);
                    ortdatumAktualisieren = false;
                    break;
                #endregion

                #region Case 22: Ort_Hauptmenue
                case 22:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintHauptmenue);
                    Hintergrundbildname = "Hauptmenü";
                    SpielerInfosEinAusBlenden(false);
                    ortdatumAktualisieren = false;

                    Version v = Assembly.GetExecutingAssembly().GetName().Version;
                    label1.Text = string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
                    label1.Left = this.Width - 5 - label1.Width;
                    label1.Top = this.Height - 5 - label1.Height;
                    label1.ForeColor = Color.Gold;
                    label1.Visible = true;

                    label2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgRiesig());
                    label3.Font = label2.Font;
                    label4.Font = label2.Font;
                    label5.Font = label2.Font;
                    label6.Font = label2.Font;

                    int abstand = NormB(42);

                    label2.Text = "Hotseat-Spiel";
                    label2.Left = ((this.Width - label2.Width) / 2) + abstand;
                    label2.Top = ((haup_spt + haup_spb) - label2.Height) / 2;
                    label2.Visible = true;

                    label3.Text = "Tutorial / Hilfe";
                    label3.Left = ((this.Width - label3.Width) / 2) + abstand;
                    label3.Top = ((haup_netzt + haup_netzb) - label2.Height) / 2;
                    label3.Visible = true;

                    label4.Text = "Optionen";
                    label4.Left = ((this.Width - label4.Width) / 2) + abstand;
                    label4.Top = ((haup_optt + haup_optb) - label2.Height) / 2;
                    label4.Visible = true;

                    label5.Text = "Credits";
                    label5.Left = ((this.Width - label5.Width) / 2) + abstand;
                    label5.Top = ((haup_credt + haup_credb) - label2.Height) / 2;
                    label5.Visible = true;

                    label6.Text = "Beenden";
                    label6.Left = ((this.Width - label6.Width) / 2) + abstand;
                    label6.Top = ((haup_beent + haup_beenb) - label2.Height) / 2;
                    label6.Visible = true;

                    break;
                #endregion

                case 23:
                    break;

                #region Case 24: Ort_Netzwerkspiel
                case 24:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintNetzwerkspiel);
                    Hintergrundbildname = "Netzwerkspiel";
                    SpielerInfosEinAusBlenden(false);
                    ortdatumAktualisieren = false;

                    label1.Text = "Spieler 1";
                    label1.Left = NormB(180);
                    label1.Top = NormH(200);
                    label1.ForeColor = Color.Black;
                    label1.Visible = true;

                    break;
                #endregion

                #region Case 25: Ort_Buch
                case 25:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintBuchOffen);
                    Hintergrundbildname = "Buch";
                    SpielerInfosEinAusBlenden(true);
                    break;
                #endregion

                #region Case 26: Ort_Kerker
                case 26:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintKerker);
                    Hintergrundbildname = "Kerker";
                    SpielerInfosEinAusBlenden(true);

                    C_MusikInstanz.MusikEinschieben_HZ();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 27: Ort_Amtsenthebung
                case 27:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintSpielerAbsetzen);
                    Hintergrundbildname = "Amtsenthebung";
                    SpielerInfosEinAusBlenden(false);

                    label1.Text = "Absetzen";
                    label2.Text = "oder lieber nicht";
                    label5.Text = "Amtsenthebung";
                    label5.Visible = true;
                    break;
                #endregion

                #region Case 28: Ort_Gericht
                case 28:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintGericht);
                    Hintergrundbildname = "Gericht";
                    SpielerInfosEinAusBlenden(false);
                    break;
                #endregion

                #region Case 29: Ort_Credits
                case 29:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintCredits);
                    Hintergrundbildname = "Credits";
                    SpielerInfosEinAusBlenden(false);
                    ortdatumAktualisieren = false;

                    Version ve = Assembly.GetExecutingAssembly().GetName().Version;
                    label1.Text = string.Format("{0}.{1}.{2}", ve.Major, ve.Minor, ve.Build);
                    label1.Left = this.Width - 5 - label1.Width;
                    label1.Top = this.Height - 5 - label1.Height;
                    label1.ForeColor = Color.Gold;
                    label1.Visible = true;

                    C_MusikInstanz.MusikEinschieben_Outro();
                    bMusikEinschieben = true;
                    break;
                #endregion

                #region Case 30: Ort_Abstimmung
                case 30:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintAbstimmung);
                    Hintergrundbildname = "Abstimmung";
                    SpielerInfosEinAusBlenden(true);
                    break;
                #endregion

                #region Case 31: Ort_Nachrichten
                case 31:
                    this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.HintRundenNachrichten);
                    Hintergrundbildname = "Nachrichten";
                    SpielerInfosEinAusBlenden(false);

                    lbl_nachrichten_titel.Top = NormH(80);
                    lbl_nachrichten_titel.Width = NormB(800);
                    lbl_nachrichten_titel.Left = (this.Width - lbl_nachrichten_titel.Width) / 2;
                    lbl_nachrichten_titel.Visible = true;

                    lbl_nachrichten_text.Top = lbl_nachrichten_titel.Top + lbl_nachrichten_titel.Height + NormH(15);
                    lbl_nachrichten_text.Width = lbl_nachrichten_titel.Width;
                    lbl_nachrichten_text.Left = lbl_nachrichten_titel.Left;
                    lbl_nachrichten_text.Visible = true;
                    break;
                #endregion
            }

            if (!bMusikEinschieben)
                C_MusikInstanz.checkMusik();

            if (ortdatumAktualisieren)
            {
                lbl_ortdatum.Text = Hintergrundbildname + " A.D. " + SW.Dynamisch.GetAktuellesJahr().ToString();
            }

            SpielerDatenAusrichten();
            this.Focus();
        }
        #endregion

        #region Cursor Aendern

        private void CurSwordActive()
        {
            //this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurSword.ani");
        }

        private void CurInfoActive()
        {
            //this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurInfo.ani");
        }

        private void CurPlusActive()
        {
            //this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurPlus.ani");
        }

        private void CurMinusActive()
        {
            //this.Cursor = NativeMethods.LoadCustomCursor(Application.StartupPath + "\\CurMinus.ani");
        }

        #endregion

        #region Switch Operationen fuer die Grafiken

        #region WerkstaettenSwitch
        private void switchWerkstaetten(string btn_name, int value)
        {
            switch (value)
            {
                case 1:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh1);
                    break;
                case 2:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh2);
                    break;
                case 3:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh3);
                    break;
                case 4:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh4);
                    break;
                case 5:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh5);
                    break;
                case 6:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh6);
                    break;
                case 7:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh7);
                    break;
                case 8:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh8);
                    break;
                case 9:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh9);
                    break;
                case 10:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh10);
                    break;
                case 11:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh11);
                    break;
                case 12:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh12);
                    break;
                case 13:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh13);
                    break;
                case 14:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh14);
                    break;
                case 15:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh15);
                    break;
                case 16:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh16);
                    break;
                case 17:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh17);
                    break;
                case 18:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh18);
                    break;
                case 19:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh19);
                    break;
                case 20:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh20);
                    break;
                case 21:
                    this.Controls[btn_name].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.WSRoh21);
                    break;
            }
        }
        #endregion

        #region Banner
        private void SwitchBanner(string btn_name, int value)
        {
            //wurde nach politischeWeltkarte und formstatistik kopiert
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
        #endregion

        #region Haus

        private void switchHausSymb(string btn_name, int value)
        {
            //wurde nach hausbauen exportiert
            switch (value)
            {
                case 1:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 2:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 3:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 4:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 5:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 6:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 7:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 8:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
                case 9:
                    this.Controls[btn_name].BackgroundImage = Conspiratio.Properties.Resources.SymbAnwHaus1;
                    break;
            }
        }
        #endregion

        #endregion

        #region Hilfsfunktionen

        #region HandelFlaggenEinblenden
        private void HandelFlaggenEinblenden()
        {
            pictureBox1.Top = f_top;
            pictureBox2.Top = i_top;
            pictureBox3.Top = h_top;
            pictureBox4.Top = n_top;
            pictureBox5.Top = d_top;
            pictureBox6.Top = c_top;
            pictureBox7.Top = a_top;
            pictureBox8.Top = o_top;
            pictureBox9.Top = k_top;
            pictureBox10.Top = e_top;
            pictureBox11.Top = b_top;
            pictureBox12.Top = t_top;
            pictureBox13.Top = s_top;
            pictureBox14.Top = j_top;

            pictureBox1.Left = f_right + 3;
            pictureBox2.Left = i_right + 3;
            pictureBox3.Left = h_right + 3;
            pictureBox4.Left = n_right + 3;
            pictureBox5.Left = d_right + 3;
            pictureBox6.Left = c_right + 3;
            pictureBox7.Left = a_right + 3;
            pictureBox8.Left = o_right + 3;
            pictureBox9.Left = k_right + 3;
            pictureBox10.Left = e_right + 3;
            pictureBox11.Left = b_right + 3;
            pictureBox12.Left = t_right + 3;
            pictureBox13.Left = s_right + 3;
            pictureBox14.Left = j_right + 3;

            pictureBox1.Width = 25;
            pictureBox2.Width = pictureBox1.Width;
            pictureBox3.Width = pictureBox1.Width;
            pictureBox4.Width = pictureBox1.Width;
            pictureBox5.Width = pictureBox1.Width;
            pictureBox6.Width = pictureBox1.Width;
            pictureBox7.Width = pictureBox1.Width;
            pictureBox8.Width = pictureBox1.Width;
            pictureBox9.Width = pictureBox1.Width;
            pictureBox10.Width = pictureBox1.Width;
            pictureBox11.Width = pictureBox1.Width;
            pictureBox12.Width = pictureBox1.Width;
            pictureBox13.Width = pictureBox1.Width;
            pictureBox14.Width = pictureBox1.Width;

            pictureBox1.Height = 35;
            pictureBox2.Height = pictureBox1.Height;
            pictureBox3.Height = pictureBox1.Height;
            pictureBox4.Height = pictureBox1.Height;
            pictureBox5.Height = pictureBox1.Height;
            pictureBox6.Height = pictureBox1.Height;
            pictureBox7.Height = pictureBox1.Height;
            pictureBox8.Height = pictureBox1.Height;
            pictureBox9.Height = pictureBox1.Height;
            pictureBox10.Height = pictureBox1.Height;
            pictureBox11.Height = pictureBox1.Height;
            pictureBox12.Height = pictureBox1.Height;
            pictureBox13.Height = pictureBox1.Height;
            pictureBox14.Height = pictureBox1.Height;

            //Flaggen einblenden
            for (int i = SW.Statisch.GetMinStadtID(); i < SW.Statisch.GetMaxStadtID(); i++)
            {
                this.Controls["pictureBox" + i.ToString()].Visible = false;

                //Wenn er ein Haus besitzt soll die Flagge angezeigt werden
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetHausID() != 0)
                {
                    SwitchBanner("pictureBox" + i.ToString(), SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBanner());
                    this.Controls["pictureBox" + i.ToString()].Visible = true;
                    this.Controls["pictureBox" + i.ToString()].BringToFront();
                }
                //oder wenn er eine Werkstaette besitzt
                else
                {
                    for (int j = 1; j <= SW.Statisch.GetMaxWerkstaettenProStadt(); j++)
                    {
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(j, i).GetEnabled())  // WS vorhanden?
                        {
                            SwitchBanner("pictureBox" + i.ToString(), SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBanner());
                            this.Controls["pictureBox" + i.ToString()].Visible = true;
                            this.Controls["pictureBox" + i.ToString()].BringToFront();
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region HausAnzeigen
        private void HausAnzeigen()
        {
            // Haus anzeigen
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(globalAktiveStadt).GetStadtID() == globalAktiveStadt)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(globalAktiveStadt).GetRestlicheBauzeit() == 0)
                {
                    switchHausSymb("btn_stadt_Haus", SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(globalAktiveStadt).GetHausID());
                }
                else
                {
                    btn_stadt_Haus.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbAnwImBau);
                }
            }
            else
            {
                btn_stadt_Haus.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbAnwNV);
            }
        }
        #endregion

        #region Noch nicht implementiert anzeigen
        private void NochNichtImplementiert()
        {
            SW.Dynamisch.BelTextAnzeigen("Wurde noch nicht implementiert");
        }
        #endregion

        #region SpielerDatenAusrichten
        private void SpielerDatenAusrichten()
        {
            lbl_spielernameundamt.Left = this.Width / 2 - lbl_spielernameundamt.Width / 2;
            lbl_spielernameundamt.Top = NormH(51);

            lbl_Taler.Left = NormB(35);
            lbl_Taler.Top = NormH(23);

            lbl_ortdatum.Left = this.Width - lbl_ortdatum.Width - NormB(35);
            lbl_ortdatum.Top = lbl_Taler.Top;
        }
        #endregion   

        #region SpielerInfosEinAusBlenden

        private void SpielerInfosEinAusBlenden(bool Einblenden)
        {
            lbl_spielernameundamt.Visible = Einblenden;
            lbl_ortdatum.Visible = Einblenden;
            lbl_Taler.Visible = Einblenden;
        }
        #endregion

        #region Normen
        private int NormH(int value)
        {
            return Convert.ToInt32(value * this.Height / mBildschirmhoehe);
        }

        private int NormB(int value)
        {
            return Convert.ToInt32(value * this.Width / mBildschirmbreite);
        }
        #endregion

        #region MausKoordinatenAnzeigen
        /*
        private void MausKoordinatenAnzeigen()
        {
            SW.Dynamisch.BelTextAnzeigen("X: " + mouse_x.ToString() + Environment.NewLine + "Y: " + mouse_y.ToString());
        }
        */
        #endregion

        #endregion

        #endregion



        #region Spielablauf

        #region RundeBeginnen

        private void RundeBeginnen()
        {
            SW.Dynamisch.KIsVonWahlenAbmelden();
            SW.Dynamisch.KlagenAbgewickelt();

            SW.Dynamisch.ErhoehAktuellesJahrUmEins();
            lbl_ortdatum.Text = "Kontor A.D. " + SW.Dynamisch.GetAktuellesJahr().ToString();
        }

        #region Autosave
        private void Autosave()
        {
            Speichern(SW.Dynamisch.SpielName + "_" + SW.Dynamisch.GetAktuellesJahr(), true);
        }
        #endregion

        #endregion

        #region ZugBeginnen

        #region SpielerDatenLaden
        private async Task SpielerDatenLaden(bool geradeGeladen)
        {
            SpielerInfosEinAusBlenden(true);

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSitztImKerker() == true)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetSitztImKerker(false);
                UI.TalerAendern(0, ref lbl_Taler);

                lbl_spielernameundamt.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKompletterName();
                SpielerDatenAusrichten();

                await Ereignis_SpielerAnkuendigen();
                await SitztImKerker();
                await AktivenSpielerSchalten();
                await SpielerDatenLaden(false);
            }
            else
            {
                UI.TalerAendern(0, ref lbl_Taler);

                lbl_spielernameundamt.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKompletterName();
                SpielerDatenAusrichten();

                await Ereignis_SpielerAnkuendigen();

                if (geradeGeladen == false && SW.Dynamisch.GetAktuellesJahr() != SW.Statisch.StartJahr)
                {
                    await BuchAnzeigen();
                }

                PositionWechseln(Posi_Kontor);

                if (geradeGeladen == false)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).VersuchHandelszertifikatVerleihen();
                    HandelszertifikatAnzeigen();
                }
                SpielerDatenAktualisieren();
                Autosave();
            }
        }
        #endregion     

        #region BuchAnzeigen
        private async Task BuchAnzeigen()
        {
            //Buch
            PositionWechseln(Posi_Buch);

            #region Berechnung
            #region Verkauf
            bool EtwasExportiert = false;
            bool EtwasGestohlen = false;
            int[] exWaren = new int[SW.Statisch.GetMaxRohID()];
            int[] exWarenUeberfall = new int[SW.Statisch.GetMaxRohID()];
            int[] preisWaren = new int[SW.Statisch.GetMaxRohID()];


            //Beide Produktionsslots 0 und 1
            for (int j = 0; j < SW.Statisch.GetMaxProdSlots(); j++)
            {
                //Städte
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    //Überprüfen ob Exportieren eingestellt ist
                    if ((SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Verkaufen || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.PermanentVerkaufen) &&
                        (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufAnzahl() > 0))
                    {
                        EtwasExportiert = true;

                        //Exportierter Rohstoff in Stadt i
                        int rohNr = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufRohstoff();

                        SW.Dynamisch.CheckGesetzesVerstossMitRohIDx(rohNr);


                        //Rohstoff mit rohNr wurde exportiert
                        int anzahl = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufAnzahl();
                        int zielstadt = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufStadt();
                        int rohPreis = SW.Dynamisch.GetStadtwithID(zielstadt).GetRohstoffPreisVonIDX(rohNr);

                        exWaren[rohNr] += anzahl;
                        preisWaren[rohNr] += rohPreis * anzahl;

                        //Aenderung der Rohvorraete der Stadt speichern
                        SW.Dynamisch.GetAktHum().ErhoeheEinVerkaeufeInStadtXVonRohstoffIDYUmZ(i, rohNr, anzahl);

                        //Einnahmen zum Umsatz hinzuzählen
                        int umsatz = rohPreis * anzahl;
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheUmsatzInStadtX(umsatz, i);

                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).SetVerkaufAnzahl(0);

                        // Wurde Ware bei einem Überfall gestohlen?
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetGestohlenAnzahl() > 0)
                        {
                            EtwasGestohlen = true;
                            exWarenUeberfall[rohNr] += SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetGestohlenAnzahl();
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).SetGestohlenAnzahl(0);
                        }
                    }
                }
            }
            #endregion

            #region Produktion

            bool EtwasProduziert = false;
            bool EtwasVerloren = false;
            int[] prodWaren = new int[SW.Statisch.GetMaxRohID()];
            int[] prodWarenVerloren = new int[SW.Statisch.GetMaxRohID()];
            int[] prodWarenQualitaetProzent = new int[SW.Statisch.GetMaxRohID()];

            //Beide Produktionsslots 0 und 1
            for (int j = 0; j < SW.Statisch.GetMaxProdSlots(); j++)
            {
                //Städte
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    //Überprüfen ob Produzieren eingestellt ist
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Produzieren)
                    {
                        //Produzierter Rohstoff in Stadt i
                        int rohNr = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetProduktionRohstoff();
                        
                        int prodRohstoff = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetProduktion(i ,rohNr, ref prodWarenQualitaetProzent[rohNr]);
                        if(SW.Dynamisch.GetAktHum().CheckPrivilegX(32) == true)
                        {
                            prodRohstoff = Convert.ToInt32(prodRohstoff * 1.02);
                        }

                        int alteRohAnzahl = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetStadtRohstoffAnzahl(i, rohNr);
                        int neueRohAnzahl = alteRohAnzahl + prodRohstoff;

                        //Rohstoff mit rohNr wurde produziert
                        prodWaren[rohNr] += prodRohstoff;
                        if (prodRohstoff > 0)
                        {
                            EtwasProduziert = true;

                            //Rohstoff zuweisen
                            int AnzahlMoeglich = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(i, rohNr, neueRohAnzahl);

                            if (AnzahlMoeglich < prodRohstoff)
                            {
                                EtwasVerloren = true;
                                prodWarenVerloren[rohNr] += (prodRohstoff - AnzahlMoeglich);  // Rohstoff konnte (teilweise) nicht gelagert werden und ging verloren
                            }
                        }
                    }
                }
            }
            #endregion        

            #region PermanenterVerkauf

            //Beide Produktionsslots 0 und 1
            for (int j = 0; j < SW.Statisch.GetMaxProdSlots(); j++)
            {
                //Städte
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    //Überprüfen ob PermanenterVerkauf eingestellt ist
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.PermanentVerkaufen)
                    {
                        int rohid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).GetVerkaufRohstoff();
                        int vorhanz = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetStadtRohstoffAnzahl(i, rohid);

                        if (vorhanz != 0)
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(i, j).SetVerkaufAnzahl(vorhanz);
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(i, rohid, 0);
                        }
                    }
                }
            }

            #endregion
            #endregion

            #region Darstellung
            #region Produktion
            lbl_buch_Produktion.Visible = true;
            if (EtwasProduziert == false)
            {
                lbl_buch_Produktion.Text = "Im letzten Jahr habt Ihr keine \nWaren produziert.";
                await AufRechtsklickWarten();
            }
            else //wenn was produziert wurde
            {
                lbl_buch_Produktion.Text = "Produktion\n\n";
                await AufRechtsklickWarten();

                for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                {
                    if (prodWaren[i] != 0)
                    {
                        if (prodWarenQualitaetProzent[i] <= 20)
                            lbl_buch_Produktion.Text += string.Format(SW.Dynamisch.GetRohstoffwithID(i).GetTextQualitaetProduktion() + "\n", "schlecht");
                        else if (prodWarenQualitaetProzent[i] <= 40)
                            lbl_buch_Produktion.Text += string.Format(SW.Dynamisch.GetRohstoffwithID(i).GetTextQualitaetProduktion() + "\n", "mäßig");
                        else if (prodWarenQualitaetProzent[i] <= 60)
                            lbl_buch_Produktion.Text += string.Format(SW.Dynamisch.GetRohstoffwithID(i).GetTextQualitaetProduktion() + "\n", "normal");
                        else if (prodWarenQualitaetProzent[i] <= 80)
                            lbl_buch_Produktion.Text += string.Format(SW.Dynamisch.GetRohstoffwithID(i).GetTextQualitaetProduktion() + "\n", "gut");
                        else
                            lbl_buch_Produktion.Text += string.Format(SW.Dynamisch.GetRohstoffwithID(i).GetTextQualitaetProduktion() + "\n", "ausgezeichnet");                        
                    }
                }

                await AufRechtsklickWarten();
                lbl_buch_Produktion.Text = "Produktion\n\n";

                for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                {
                    if (prodWaren[i] != 0)
                    {
                        lbl_buch_Produktion.Text += prodWaren[i].ToString() + " " + SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + "\n";
                    }
                }

                await AufRechtsklickWarten();

                if (EtwasVerloren)
                {
                    bool bUeberschriftWarenVerloren = false;

                    for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                    {
                        if (prodWarenVerloren[i] != 0)
                        {
                            if (!bUeberschriftWarenVerloren)
                            {
                                lbl_buch_Produktion.Text += "\n\nAus Mangel an Lagerraum opfert Ihr folgende Waren an Bedürftige. Welch' edle Tat!\n\n";
                                bUeberschriftWarenVerloren = true;
                            }

                            lbl_buch_Produktion.Text += prodWarenVerloren[i].ToString() + " " + SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + "\n";
                        }
                    }

                    await AufRechtsklickWarten();
                }
            }

            #endregion

            #region Verkauf

            lbl_buch_Exporte.Visible = true;
            if (EtwasExportiert == false)
            {
                lbl_buch_Exporte.Text = "Im letzten Jahr habt Ihr keine Waren exportiert.";
                await AufRechtsklickWarten();
            }
            else //wenn was exportiert wurde
            {
                lbl_buch_Exporte.Text = "Exporte\n\n";

                for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                {
                    if (exWaren[i] != 0)
                    {
                        lbl_buch_Exporte.Text += exWaren[i].ToString() + " " + SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + " für " + preisWaren[i].ToStringGeld() + "\n";
                        UI.TalerAendern(preisWaren[i], ref lbl_Taler);
                    }
                }

                await AufRechtsklickWarten();

                if (EtwasGestohlen)
                {
                    lbl_buch_Exporte.Text += "\nAufgrund von Überfällen habt Ihr folgende Waren verloren.\n\n";

                    for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                    {
                        if (exWarenUeberfall[i] > 0)
                        {
                            lbl_buch_Exporte.Text += exWarenUeberfall[i].ToString() + " " + SW.Dynamisch.GetRohstoffwithID(i).GetRohName() + "\n";
                        }
                    }

                    await AufRechtsklickWarten();
                }
            }

            #endregion
            #endregion

            lbl_buch_Exporte.Visible = false;
            lbl_buch_Produktion.Visible = false;
        }


        #endregion

        #endregion

        #region ZugBeenden

        #region ZugBeenden
        private async Task ZugBeenden()
        {
            Abrechnung a = new Abrechnung(ref lbl_Taler);
            C_MusikInstanz.PlaySound(Properties.Resources.muenzen);
            a.ShowDialog();
            
            //Altern selbst und Kinder
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).AlterPlusEins();
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).KinderAltern();

            //Nachrichten anzeigen
            PositionWechseln(Posi_ZugNachrichten);
            int tempY = await ZugNachrichten();

            if (tempY == 0) //Spiel geht weiter
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetPrivilegKaufmannBenutzt(false);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetGebeichtet(false);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).HatAngebotFuerStuetzpunktAbgegeben = false;

                await AktivenSpielerSchalten();

                await SpielerDatenLaden(false);
            }
            else if (tempY == 1) //Es lebt kein Spieler mehr... Spiel muss beendet werden
            {
                //Statistik anzeigen //TODO: Statistik kann nicht geladen werden, wenn kein Spieler mehr lebt
                //FormStatistik fs = new FormStatistik();
                //fs.ShowDialog();
                HauptmenueAusfuehren();
            }
        }
        #endregion

        #region Aktiven Spieler schalten
        private async Task AktivenSpielerSchalten()
        {
            //nächster Spieler
            if (SW.Dynamisch.GetAktiverSpieler() >= SW.Dynamisch.GetAktivSpielerAnzahl())
            {
                //Dann soll ein neues Jahr beginnen
                await RundenEndnachrichtenAnzeigen();
                SW.Dynamisch.SetAktiverSpieler(1);
                RundeBeginnen();
            }
            else
            {
                SW.Dynamisch.SetAktiverSpieler(SW.Dynamisch.GetAktiverSpieler() + 1);
            }
        }
        #endregion

        #region Sitzt im Kerker
        private async Task SitztImKerker()
        {
            PositionWechseln(Posi_Kerker);
            SpielerInfosEinAusBlenden(true);

            //lbl_Taler.Visible = false;
            //lbl_ortdatum.Visible = false;


            label1.Text = "Ihr verbringt dieses Jahr im Schuldturm...";
            label1.Top = this.Height - NormH(75);
            label1.Left = this.Width / 2 - label1.Width / 2;
            label1.Visible = true;

            await AufRechtsklickWarten();

            SpielerInfosEinAusBlenden(false);
            label1.Visible = false;
            SpielerDatenAusrichten();
        }
        #endregion

        #region SpielerDatenAktualisieren
        private void SpielerDatenAktualisieren()
        {
            UI.TalerAendern(0, ref lbl_Taler);

            lbl_spielernameundamt.Text = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKompletterName();
            SpielerDatenAusrichten();
        }
        #endregion

        #endregion


        #region ZugEreignisse

        #region NachrichtenEtwasAnzeigen
        private async Task NachrichtenEtwasAnzeigen(string titel1, string text1)
        {
            lbl_nachrichten_titel.Text = titel1;
            lbl_nachrichten_titel.Visible = true;
            lbl_nachrichten_text.Text = text1;
            lbl_nachrichten_text.Visible = true;
            await AufRechtsklickWarten();
        }
        #endregion

        #region Nachrichten Ausfuehren
        private async Task<int> ZugNachrichten()
        {
            VersuchTitelVerleihen();
            await KindBekommen();
            await Hochzeit();
            TitelVerleihen();
            await KinderSterben();
            await Brautwerbung();


            await VerbrechenZaehlen();
            StatistikErweitern();

            await EinkommenBekommen();
            await AnwesenFertiggestellt();
            await KartenSpielen();


            await Korruptionsgelder();
            await Schmuggelgelder();
            await Kerkerklatsch();
            await SpionageNachrichten();
            await SabotageNachrichten();
            await Ermordung();
            await VergifteterWein();
            await FesteFeiern();

            await RandomEreignisse();

            SW.Dynamisch.AnklagenVonKISpielernErstellen();
            await CheckGerichtsVerhandlungen();
            
            
            int tempz = await checkHumSpielerStirbt();

            if (tempz == 0) //Wenn 0 returnt wird, heißt das, dass das Spiel weitergeht.
            {
                await CheckKerker();
                await KeineVorkommnisse();
            }
            else if (tempz == 1) //Bei 1 heißt dass das kein Spieler mehr spielen kann und das Spiel beendet werden muss
            {
                return 1;
            }
            return 0;
        }
        #endregion

        #region Familie

        #region VersuchTitelVerleihen
        private void VersuchTitelVerleihen()
        {
            //Falls nicht schon einer diese Runde verliehen wird
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBekamTitelX() == 0)
            {
                int aktTit = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTitel();

                if (aktTit < 1)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(1);
                }
                else if (aktTit < 2)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 5000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(2);
                    }
                }
                else if (aktTit < 3)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 15000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(3);
                    }
                }
                else if (aktTit < 4)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 50000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(4);
                    }
                }
                else if (aktTit < 5)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 100000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(5);
                    }
                }
                else if (aktTit < 6)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 200000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(6);
                    }
                }
                else if (aktTit < 7)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 500000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(7);
                    }
                }
                else if (aktTit < 8)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 750000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(8);
                    }
                }
                else if (aktTit < 9)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > 1000000)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(9);
                    }
                }
            }
        }
        #endregion

        #region KindBekommen
        private async Task KindBekommen()
        {
            bool getKind = false;

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetEmptyKindSlot() != SW.Statisch.GetMaxKinderAnzahl())
            {
                //cheatkind
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindBekommen() == true)
                {
                    getKind = true;
                }
                //legitkind
                else
                {
                    if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet() != 0)
                    {
                        //Chance für ein Kind
                        if (SW.Statisch.Rnd.Next(0, SW.Statisch.GetChanceFuerKind()) == 0)
                        {
                            getKind = true;
                        }
                    }
                }
            }

            if (getKind == true)
            {
                await Ereignis_Geburt();
                PositionWechseln(Posi_ZugNachrichten);
            }
        }
        #endregion

        #region Hochzeit
        private async Task Hochzeit()
        {
            int brautid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID;

            if (brautid != 0)
            {
                if (SW.Dynamisch.GetKIwithID(brautid).GetVerliebt() == 100)
                {
                    SW.Dynamisch.GetKIwithID(brautid).SetVerliebt(0);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID = 0;
                    PositionWechseln(Posi_Hochzeit);

                    string temp = "Eure Angebetete";
                    if (SW.Dynamisch.GetSpWithID(brautid).GetMaennlich())
                    {
                        temp = "Euer Angebeteter";
                    }

                    lbl_verheiratet.Text = "Große Ereignisse werfen ihre Schatten voraus! " + temp + " hat sich endlich bereit erklärt Euch zu heiraten. Ihr schwebt im siebten Himmel...";
                    lbl_verheiratet.Left = this.Width / 2 - lbl_verheiratet.Width / 2;
                    lbl_verheiratet.Top = (this.Height - lbl_verheiratet.Height) - 30;
                    lbl_verheiratet.Visible = true;

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().KHochzeiten++;

                    //Titel anpassen
                    SW.Dynamisch.VerheirateXundY(SW.Dynamisch.GetAktiverSpieler(), brautid);

                    //Titelverleihform anzeigen falls der Partner einen höheren Titel innehat
                    if (SW.Dynamisch.GetSpWithID(brautid).GetTitel() > SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetTitel())
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(SW.Dynamisch.GetSpWithID(brautid).GetTitel());
                        TitelVerleihForm tvf = new TitelVerleihForm();
                        tvf.ShowDialog();
                    }

                    await AufRechtsklickWarten();


                    lbl_verheiratet.Visible = false;
                    PositionWechseln(Posi_ZugNachrichten);
                }
            }
        }
        #endregion

        #region Titelverleihen
        private void TitelVerleihen()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBekamTitelX() != 0)
            {
                //Falls es zur Zeit keinen Regenten gibt, wird der Titel erst später verliehen
                if (SW.Dynamisch.GetReichWithID(1).GetRegent() != 0)
                {
                    PositionWechseln(Posi_ZugNachrichten);
                    
                    TitelVerleihForm tvf = new TitelVerleihForm();
                    tvf.ShowDialog();

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamTitelX(0);
                }
                SpielerDatenAktualisieren();
            }
        }
        #endregion

        #region Kinder sterben
        private async Task KinderSterben()
        {
            //Kinder sterben
            for (int i = SW.Statisch.GetMinKIID(); i < SW.Statisch.GetMaxKinderAnzahl(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(i).GetKindName() != "")
                {
                    int chance = SW.Statisch.Rnd.Next(0, SW.Statisch.GetChanceFuerKindStirbt());
                    if (chance == 0)
                    {
                        await KindXStirbt(i);
                    }
                }
            }
        }
        #endregion

        #region KindXStirbt
        private async Task KindXStirbt(int x)
        {

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetErbeSpielerID() == x)
            {
                //Anderen Erben suchen

                //Zur Zeit einfach Erzbistum als Erben setzen
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetErbeSpielerID(0);
                SW.Dynamisch.BelTextAnzeigen("Da Euer im Testament erwähnter Erbe verstorben ist, ist aktuell das Erzbistum der Erbe eures gesamten Vermögens!");
            }

            PositionWechseln(Posi_Kindstod);
            string sohntochter = "Eure Tochter ";
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(x).GetMaennlich() == true)
            {
                sohntochter = "Euer Sohn ";
            }

            label1.Text = sohntochter + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(x).GetKindName() + " erlitt im Alter von " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(x).GetAlter().ToString() + " Jahren den frühen Kindestod.";
            label1.Top = 30;
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Visible = true;
            SpielerInfosEinAusBlenden(false);

            await AufRechtsklickWarten();
            label1.Visible = false;
            SpielerInfosEinAusBlenden(true);

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKindX(x).SetName("");
        }
        #endregion

        #region Brautwerbung
        private async Task Brautwerbung()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID != 0)
            {
                #region Vorbereitung Oberfläche
                lbl_nachrichten_titel.Text = "Brautwerbung";
                label1.Text = "Was wollt Ihr " + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetKompletterName() + ", in \ndiesem Jahr als Beweis Eurer Liebe schenken?";
                label1.ForeColor = Color.Black;
                label1.Left = lbl_nachrichten_text.Left;
                label1.Visible = true;
                label1.Top = lbl_nachrichten_titel.Top + lbl_nachrichten_titel.Height + NormH(20);
                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = true;
                #endregion

                #region Ermitteln der zufälligen Geschenke
                int[] Geschenk = new int[4];

                Geschenk[1] = SW.Statisch.Rnd.Next(1,                                       SW.Statisch.GetWerbegeschenkGrenzeBillig());      //Billiges Geschenk
                Geschenk[2] = SW.Statisch.Rnd.Next(SW.Statisch.GetWerbegeschenkGrenzeBillig(),      SW.Statisch.GetWerbegeschenkGrenzeMittelteuer()); //Mittelteures Geschenk
                Geschenk[3] = SW.Statisch.Rnd.Next(SW.Statisch.GetWerbegeschenkGrenzeMittelteuer(), SW.Statisch.GetMaxWerbegeschenke());              //Teures Geschenk
                #endregion

                #region Berechne den Preis der Geschenke
                int KI_Taler = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetTaler();
                int Hum_Kostenzuschlag = Convert.ToInt32(0.001 * SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetGesamtVermoegen(SW.Dynamisch.GetAktiverSpieler()));
                int[] Geschenkpreis = new int[4];


                Geschenkpreis[1] = Convert.ToInt32(SW.Statisch.GetWerbegeschenk(Geschenk[1]).Basispreis + SW.Statisch.GetWerbegeschenk(Geschenk[1]).Vermoegensfaktor * KI_Taler) + Hum_Kostenzuschlag;
                Geschenkpreis[2] = Convert.ToInt32(SW.Statisch.GetWerbegeschenk(Geschenk[2]).Basispreis + SW.Statisch.GetWerbegeschenk(Geschenk[2]).Vermoegensfaktor * KI_Taler) + Hum_Kostenzuschlag;
                Geschenkpreis[3] = Convert.ToInt32(SW.Statisch.GetWerbegeschenk(Geschenk[3]).Basispreis + SW.Statisch.GetWerbegeschenk(Geschenk[3]).Vermoegensfaktor * KI_Taler) + Hum_Kostenzuschlag;
                #endregion

                #region Darstellung für den Spieler
                label2.Text = SW.Statisch.GetWerbegeschenk(Geschenk[1]).Text + " für " + Geschenkpreis[1].ToStringGeld() + ",";
                label3.Text = SW.Statisch.GetWerbegeschenk(Geschenk[2]).Text + " für " + Geschenkpreis[2].ToStringGeld() + " oder";
                label4.Text = SW.Statisch.GetWerbegeschenk(Geschenk[3]).Text + " für " + Geschenkpreis[3].ToStringGeld() + "?";
                label5.Text = SW.Statisch.GetWerbegeschenk(0).Text;

                btn_brautwerbung_m1.Left = lbl_nachrichten_text.Left + NormB(30);
                btn_brautwerbung_m2.Left = btn_brautwerbung_m1.Left;
                btn_brautwerbung_m3.Left = btn_brautwerbung_m1.Left;
                btn_brautwerbung_m4.Left = btn_brautwerbung_m1.Left;
                

                label2.Left = btn_brautwerbung_m1.Left + btn_brautwerbung_m1.Width + NormB(15);
                label3.Left = label2.Left;
                label4.Left = label2.Left;
                label5.Left = label2.Left;
                label6.Left = btn_brautwerbung_m1.Left;

                btn_brautwerbung_m1.Top = label1.Bottom + NormH(40);
                btn_brautwerbung_m2.Top = btn_brautwerbung_m1.Top + btn_brautwerbung_m1.Height + NormH(15);
                btn_brautwerbung_m3.Top = btn_brautwerbung_m2.Top + btn_brautwerbung_m2.Height + NormH(15);
                btn_brautwerbung_m4.Top = btn_brautwerbung_m3.Top + btn_brautwerbung_m3.Height + NormH(15);

                label2.Top = btn_brautwerbung_m1.Top + (btn_brautwerbung_m1.Height / 2) - (label2.Height / 2);
                label3.Top = btn_brautwerbung_m2.Top + (btn_brautwerbung_m2.Height / 2) - (label3.Height / 2);
                label4.Top = btn_brautwerbung_m3.Top + (btn_brautwerbung_m3.Height / 2) - (label4.Height / 2);
                label5.Top = btn_brautwerbung_m4.Top + (btn_brautwerbung_m4.Height / 2) - (label5.Height / 2); 
                label6.Top = label5.Top + label5.Height + NormH(30);

                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                label4.ForeColor = Color.Black;
                label5.ForeColor = Color.Black;
                label6.ForeColor = Color.Black;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;

                btn_brautwerbung_m1.Visible = true;
                btn_brautwerbung_m2.Visible = true;
                btn_brautwerbung_m3.Visible = true;
                btn_brautwerbung_m4.Visible = true;
                #endregion

                #region Warten auf Input
                BrautwerbungButtonKlick = 0;
                await AufButtonKlickWarten();
                #endregion

                if (BrautwerbungButtonKlick == 4) //kein Geschenk
                {
                    SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).ErhoeheVerliebt(-10);
                    label6.Text = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetName() + " fühlt sich vernachlässigt...";
                    label6.Visible = true;
                }
                else //Geschenk
                {
                    if (BrautwerbungButtonKlick == 0)
                    {
                        SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).ErhoeheVerliebt(-5);
                    }
                    else
                    {
                        int gefallen_min = 0;
                        int gefallen_max = 10;
                        int O_Schranke = 75;
                        int U_Schranke = 25;
                        int O_Randomschranke = 5;
                        int U_Randomschranke = 5;

                        //Ermitteln wie gut dem Partner das Geschenk gefallen hat
                        int boni_Preis = SW.Statisch.GetWerbegeschenk(Geschenk[BrautwerbungButtonKlick]).BonusPreis;
                        int boni_Boese = SW.Statisch.GetWerbegeschenk(Geschenk[BrautwerbungButtonKlick]).BonusBoese;
                        int boni_Roman = SW.Statisch.GetWerbegeschenk(Geschenk[BrautwerbungButtonKlick]).BonusRomantik;
                        int KI_Bosheit = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetBosheit();

                        if (boni_Boese > 0)
                        {
                            if(KI_Bosheit > O_Schranke)
                            {
                                gefallen_min = U_Randomschranke;
                            }
                            else if(KI_Bosheit < U_Schranke)
                            {
                                gefallen_max = O_Randomschranke;
                            }
                        }
                        if(boni_Roman > 0)
                        {
                            if(KI_Bosheit < U_Schranke)
                            {
                                gefallen_min = U_Randomschranke;
                            }
                            else if(KI_Bosheit > O_Schranke)
                            {
                                gefallen_max = O_Randomschranke;
                            }
                        }

                        int gefallen = SW.Statisch.Rnd.Next(gefallen_min, gefallen_max + 1);
                        int plusVerliebt = 6 + Convert.ToInt32((gefallen * (boni_Preis + boni_Boese + boni_Roman)) / 10);
                        SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).ErhoeheVerliebt(plusVerliebt);

                        UI.TalerAendern(-Geschenkpreis[BrautwerbungButtonKlick], ref lbl_Taler);
                        label6.Text = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetName() + SW.Statisch.GetWerbereaktion(gefallen);
                        label6.Visible = true; 
                    }
                }
                

                if (SW.Dynamisch.Testmodus == true)
                {
                    SW.Dynamisch.BelTextAnzeigen("Werbepartner verliebt: " + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetVerliebt().ToString() + "\nGeschenk +: -10" + "\nSumme: " + (-10 + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetVerliebt()).ToString() + "\nZiel: 100");
                }

                await AufRechtsklickWarten();

                #region Oberfläche
                lbl_nachrichten_titel.Visible = false;
                btn_brautwerbung_m1.Visible = false;
                btn_brautwerbung_m2.Visible = false;
                btn_brautwerbung_m3.Visible = false;
                btn_brautwerbung_m4.Visible = false;

                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                label1.ForeColor = Color.Gold;
                label2.ForeColor = Color.Gold;
                label3.ForeColor = Color.Gold;
                label4.ForeColor = Color.Gold;
                label5.ForeColor = Color.Gold;
                label6.ForeColor = Color.Gold;
                #endregion
            }
        }
        #endregion

        #region HumSpielerStirbt
        #region checkHumSpielerStirbt
        private async Task<int> checkHumSpielerStirbt()
        {
            if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetAlter() > 35)
            {
                int alter = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAktiverSpieler()).GetAlter();

                if (alter > SW.Statisch.GetMaxAlter())
                {
                    return await HumSpielerStirbt(); 
                }
                else
                {
                    if (Sterbeformel(SW.Dynamisch.GetAktiverSpieler()))
                    {
                        return await HumSpielerStirbt();
                    }
                }
            }
            return 0;
        }
        #endregion

        #region Sterbeformel
        private bool Sterbeformel(int SpID)
        {
            int spXlebtNoch = SW.Dynamisch.GetSpXlebtNochSoVielJahre(SpID);
            int plusMinus = SW.Statisch.Rnd.Next(-1, 2);

            spXlebtNoch += plusMinus;

            if (spXlebtNoch <= 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region HumSpielerStirbt
        private async Task<int> HumSpielerStirbt()
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            lbl_nachrichten_text.Visible = false;
            lbl_nachrichten_titel.Visible = false;

            PositionWechseln(Posi_Tod);


            int todestextX = SW.Statisch.Rnd.Next(1, 10);
            if (SW.Statisch.Rnd.Next(1, 200) == 1)
            {
                todestextX = 0;
            }

            label1.Text = SW.Statisch.GetTexteTodesursachenX(todestextX);
            label1.Top = this.Height - label1.Height - NormH(20);
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Visible = true;

            await AufRechtsklickWarten();

            label1.Visible = false;

            //Testamentsverlesung
            PositionWechseln(Posi_Testament);
            //Übliche Kommentare einblenden

            //Amt freigeben
            SW.Dynamisch.AmtVonXfreigeben(SW.Dynamisch.GetAktiverSpieler());

            //Von Wahl abmelden
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme() != 0)
            {
                //Position suchen
                int u = 0;
                while (true)
                {
                    if (SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).GetKandidaten()[u] == SW.Dynamisch.GetAktiverSpieler())
                    {
                        SW.Dynamisch.GetWahlX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme()).SetKandidatenXAufY(u, 0);
                        break;
                    }
                    u++;
                }

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetWahlTeilnahme(0);  // Teilnahme zurücksetzen
            }

            label1.Text = "Hier das Testament...";
            label1.Left = (this.Width - label1.Width) / 2;
            label1.Visible = true;
            await AufRechtsklickWarten();
            label1.Visible = false;

            SW.UI.TestamentAnzeigenDialog.ShowDialog(true);

            if (SW.Dynamisch.GetAktivSpielerAnzahl() == 0)
            {
                SW.Dynamisch.BelTextAnzeigen("Da Ihr Euer Vermögen an niemanden vererbt habt, könnt Ihr nicht weiterspielen und dieses Spiel ist vorbei.");
                return 1;
                //HauptmenueAusfuehren();
            }
            else
            {
                SpielerDatenAktualisieren();

                PositionWechseln(Posi_ZugNachrichten);
            }
            return 0;
        }
        #endregion

        #endregion

        #endregion

        #region Statistik erweitern
        private void StatistikErweitern()
        {
            for (int i = 0; i < SW.Statisch.GetMaxKIID(); i++)
            {
                //Sabotagen
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(i).GetDauer() > 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiSabotagen++;
                }

                //Spionagen
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).GetKosten() > 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiSpionagen++;
                }
            }
        }
        #endregion

        #region Finanziell

        #region EinkommenBekommen
        private async Task EinkommenBekommen()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID() != 0)
            {
                await NachrichtenEtwasAnzeigen("Einkommen", "Als " + SW.Dynamisch.GetAmtsnameVonSPIDx(SW.Dynamisch.GetAktiverSpieler()) + " verdient Ihr dieses Jahr " + SW.Statisch.GetAmtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID()).GetEinkommen().ToStringGeld() + ".");
                UI.TalerAendern(SW.Statisch.GetAmtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtID()).GetEinkommen(), ref lbl_Taler);
            }
        }
        #endregion

        #region Anwesen fertiggestellt
        private async Task AnwesenFertiggestellt()
        {
            for (int i = SW.Statisch.GetMinStadtID(); i < SW.Statisch.GetMaxStadtID(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetRestlicheBauzeit() > 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).SetRestlicheBauzeit(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetRestlicheBauzeit() - 1);
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetRestlicheBauzeit() == 0)
                    {
                        //Bei den Nachrichten anzeigen das ein Anwesen fertig ist
                        PositionWechseln(Posi_ZugNachrichten);

                        await NachrichtenEtwasAnzeigen("Eigentümer", SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetNameInklPronomen(false) + " in " + SW.Dynamisch.GetStadtwithID(i).GetGebietsName() + " wurde fertiggestellt.\n");
                    }
                }
                else if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetHausID() != 0 &&
                         SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetStadtID() != 0)  // Ist das Haus vorhanden?
                {
                    // Zustand verringern
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).ZustandInProzent -= 8;   // 8 % Abzug

                    // Renovierung durchführen
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).InDiesemJahrRenovieren)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).ZustandInProzent = 100;
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).InDiesemJahrRenovieren = false;
                    }
                }
            }
        }
        #endregion

        #region KartenSpielen
        private async Task KartenSpielen()
        {
            bool esWirdGespielt = false;

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID() != 0)
            {
                esWirdGespielt = true;
            }

            if (esWirdGespielt)
            {
                if (SW.Dynamisch.GetGesetzX(4) > 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(4);
                }

                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > SW.Statisch.GetKartenSpielenMinTaler())
                {
                    label1.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;

                    string GegnerName = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).GetKompletterName();
                    string GegnerErSie = "er";
                    string GegnerSeinenIhren = "seinen";

                    if (!SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).GetMaennlich())
                    {
                        GegnerErSie = "sie";
                        GegnerSeinenIhren = "ihren";
                    }

                    btn_nachrichten_ksp_ok.Top = NormH(510);
                    btn_nachrichten_ksp_ok.Left = lbl_nachrichten_text.Left + lbl_nachrichten_text.Width / 2 - 40;

                    btn_nachrichten_ksp_setzen.Top = btn_nachrichten_ksp_ok.Top + btn_nachrichten_ksp_ok.Height / 2 - btn_nachrichten_ksp_setzen.Height / 2;
                    btn_nachrichten_ksp_setzen.Left = btn_nachrichten_ksp_ok.Left + btn_nachrichten_ksp_ok.Width + 5;
                    btn_nachrichten_ksp_setzen.MaximalerWert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler();
                    btn_nachrichten_ksp_setzen.MinimalerWert = Convert.ToInt32(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() * 0.05);
                    btn_nachrichten_ksp_setzen.Wert = btn_nachrichten_ksp_setzen.MinimalerWert;

                    lbl_nachrichten_titel.Text = "17 und 4";
                    lbl_nachrichten_text.Text = "Ihr habt Euch entschieden, in diesem Jahr mit " + GegnerName + " eine Runde 17 und 4 zu spielen, wobei " + GegnerErSie + " die Aufgabe des Bankhalters übernimmt." + "\n" + "\n" +
                                                "Nach einem Blick in Euren Geldbeutel legt " + GegnerName + " einen Mindesteinsatz von " + btn_nachrichten_ksp_setzen.MinimalerWert.ToStringGeld() + " fest." + "\n" + "\n" + "Wie viel wollt Ihr setzen?";

                    lbl_nachrichten_titel.Visible = true;
                    lbl_nachrichten_text.Visible = true;

                    btn_nachrichten_ksp_setzen.Visible = true;
                    btn_nachrichten_ksp_ok.Visible = true;

                    await AufButtonKlickWarten();

                    int wert = btn_nachrichten_ksp_setzen.Wert;

                    lbl_nachrichten_text.Text += "\n\n\n" + "Ihr entschließt Euch " + wert.ToStringGeld() + " zu setzen.";
                    btn_nachrichten_ksp_setzen.Visible = false;
                    btn_nachrichten_ksp_ok.Visible = false;

                    await AufRechtsklickWarten();

                    lbl_nachrichten_text.Text = GegnerName + " mischt die Karten und beginnt auszuteilen.";

                    int kartenanzahl = 13;
                    int[] GegnerKarten = new int[10];
                    int[] EigeneKarten = new int[10];

                    int EigenePunkte;
                    int GegnerPunkte;

                    EigeneKarten[0] = SW.Statisch.Rnd.Next(0, kartenanzahl);
                    GegnerKarten[0] = SW.Statisch.Rnd.Next(0, kartenanzahl);
                    EigeneKarten[0] = SW.Statisch.Rnd.Next(0, kartenanzahl);

                    string[] kartennamen = new string[kartenanzahl];
                    int[] kartenwerte = new int[kartenanzahl];

                    kartennamen[0] = "eine Zwei";
                    kartenwerte[0] = 2;
                    kartennamen[1] = "eine Drei";
                    kartenwerte[1] = 3;
                    kartennamen[2] = "eine Vier";
                    kartenwerte[2] = 4;
                    kartennamen[3] = "eine Fünf";
                    kartenwerte[3] = 5;
                    kartennamen[4] = "eine Sechs";
                    kartenwerte[4] = 6;
                    kartennamen[5] = "eine Sieben";
                    kartenwerte[5] = 7;
                    kartennamen[6] = "eine Acht";
                    kartenwerte[6] = 8;
                    kartennamen[7] = "eine Neun";
                    kartenwerte[7] = 9;
                    kartennamen[8] = "eine Zehn";
                    kartenwerte[8] = 10;
                    kartennamen[9] = "einen Buben";
                    kartenwerte[9] = 10;
                    kartennamen[10] = "eine Dame";
                    kartenwerte[10] = 10;
                    kartennamen[11] = "einen König";
                    kartenwerte[11] = 10;
                    kartennamen[12] = "ein Ass";
                    kartenwerte[12] = 11;

                    GegnerPunkte = kartenwerte[GegnerKarten[0]];
                    EigenePunkte = kartenwerte[EigeneKarten[0]] + kartenwerte[EigeneKarten[1]];

                    lbl_nachrichten_text.Text += " Euer Kontrahent erhält als erste Karte " + kartennamen[GegnerKarten[0]] + " und besitzt somit " + GegnerPunkte.ToString() + " Punkte.";
                    await AufRechtsklickWarten();
                    lbl_nachrichten_text.Text += "\n" + "Ihr erhaltet Eure ersten beiden Karten, " + kartennamen[EigeneKarten[0]] + " und " + kartennamen[EigeneKarten[1]] + " und besitzt damit schon " + EigenePunkte.ToString() + " Punkte.";
                    lbl_nachrichten_text.Text += " Wollt Ihr noch eine weitere Karte ziehen?";
                    label1.Text = "Sicher!";
                    label2.Text = "Lieber nicht...";

                    label1.Top = NormH(500);
                    label2.Top = label1.Top + label1.Height + 10;
                    label1.Left = btn_nachrichten_ksp_ok.Left;
                    label2.Left = label1.Left;
                    btn_ja.Top = label1.Top + label1.Height / 2 - btn_ja.Height / 2;
                    btn_nein.Top = label2.Top + label2.Height / 2 - btn_nein.Height / 2;

                    btn_ja.Left = label1.Left - btn_ja.Width - 15;
                    btn_nein.Left = label2.Left - btn_nein.Width - 15;

                    label1.Visible = true;
                    label2.Visible = true;
                    btn_ja.Visible = true;
                    btn_nein.Visible = true;
                    await AufButtonKlickWarten();

                    bool ueberkauft = false;

                    int i = 2;

                    //Eigene Karten kaufen

                    int counter = 0;
                    while (true)
                    {
                        if (SpE.getBoolKurzSpeicher() == true)
                        {
                            counter++;
                            if (counter == 3)
                            {
                                lbl_nachrichten_text.Text = "";
                                label1.Top -= NormH(195);
                                label2.Top -= NormH(195);
                                btn_ja.Top -= NormH(195);
                                btn_nein.Top -= NormH(195);
                            }
                            EigeneKarten[i] = SW.Statisch.Rnd.Next(0, kartenanzahl);
                            EigenePunkte += kartenwerte[EigeneKarten[i]];
                            lbl_nachrichten_text.Text += "\n" + "Ihr erhaltet noch " + kartennamen[EigeneKarten[i]] + " und besitzt damit " + EigenePunkte.ToString() + " Punkte.";
                            if (EigenePunkte > 21)
                            {
                                label1.Visible = false;
                                label2.Visible = false;
                                btn_ja.Visible = false;
                                btn_nein.Visible = false;
                                ueberkauft = true;
                                break;
                            }
                            else if (EigenePunkte == 21)
                            {
                                label1.Visible = false;
                                label2.Visible = false;
                                btn_ja.Visible = false;
                                btn_nein.Visible = false;

                                await AufRechtsklickWarten();
                                break;
                            }
                            else
                            {
                                lbl_nachrichten_text.Text += "\nWollt Ihr noch eine weitere Karte ziehen?";
                                label1.Top += NormH(35);
                                label2.Top += NormH(35);
                                btn_ja.Top += NormH(35);
                                btn_nein.Top += NormH(35);

                                await AufButtonKlickWarten();
                            }
                            i++;
                        }
                        else
                        {
                            label1.Visible = false;
                            label2.Visible = false;
                            btn_ja.Visible = false;
                            btn_nein.Visible = false;
                            break;
                        }
                    }

                    if (ueberkauft)
                    {
                        lbl_nachrichten_text.Text += "\n" + "Ihr habt Euch leider überkauft und damit " + wert.ToStringGeld() + " an " + GegnerName + " verloren.";
                        UI.TalerAendern(-wert, ref lbl_Taler);
                        SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), 50);
                        await AufRechtsklickWarten();
                    }
                    else
                    {
                        //Gegner kauft Karten
                        int j = 1;
                        lbl_nachrichten_text.Text = "";

                        while (GegnerPunkte < 17)
                        {
                            GegnerKarten[j] = SW.Statisch.Rnd.Next(0, kartenanzahl);
                            GegnerPunkte += kartenwerte[GegnerKarten[j]];
                            lbl_nachrichten_text.Text += "\n" + GegnerName + " kauft noch " + kartennamen[GegnerKarten[j]] + " und besitzt damit " + GegnerPunkte.ToString() + " Punkte.";
                            await AufRechtsklickWarten();
                            j++;
                        }
                        if (GegnerPunkte > 21)
                        {
                            lbl_nachrichten_text.Text += "\n" + GegnerName + " hat sich mit " + GegnerPunkte.ToString() + " überkauft und damit " + wert.ToStringGeld() + " an Euch verloren. Triumphierend streicht Ihr den Gewinn ein.";
                            UI.TalerAendern(wert, ref lbl_Taler);
                            SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), 20);
                            await AufRechtsklickWarten();
                        }
                        else
                        {
                            if (GegnerPunkte > EigenePunkte)
                            {
                                lbl_nachrichten_text.Text += "\n" + "Leider konnte " + GegnerName + " Euch mit " + GegnerSeinenIhren + " " + GegnerPunkte.ToString() + " Punkten Eure " + EigenePunkte + " schlagen. Ihr verliert Euren Einsatz in Höhe von " + wert.ToStringGeld() + ".";
                                UI.TalerAendern(-wert, ref lbl_Taler);
                                SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), 50);
                                await AufRechtsklickWarten();
                            }
                            else if (GegnerPunkte < EigenePunkte)
                            {
                                lbl_nachrichten_text.Text += "\n" + "Mit Euren " + EigenePunkte.ToString() + " Punkten konntet Ihr die " + GegnerPunkte.ToString() + " Punkte von " + GegnerName + " übertreffen. Jubelnd streicht Ihr Euren Gewinn in Höhe von " + wert.ToStringGeld() + " ein.";
                                UI.TalerAendern(wert, ref lbl_Taler);
                                SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), 20);
                                await AufRechtsklickWarten();
                            }
                            else if (GegnerPunkte == EigenePunkte)
                            {
                                lbl_nachrichten_text.Text += "\n" + "Ihr besitzt mit " + EigenePunkte.ToString() + " Punkten gleich viele wie " + GegnerName + " und habt daher ein Unentschieden erlangt. Beide gehen ohne Gewinn nach Hause...";
                                SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), 30);
                                await AufRechtsklickWarten();
                            }
                        }
                    }

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetSpieltKartenGegenSpielerID(0);

                    lbl_nachrichten_titel.Visible = false;
                    lbl_nachrichten_text.Visible = false;

                    label1.ForeColor = Color.Gold;
                    label2.ForeColor = Color.Gold;
                }

                else
                {
                    //Spieler besitzt zu wenig Taler
                    lbl_nachrichten_text.Text = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).GetKompletterName() + ": \"Als Ihr mich zum Kartenspielen eingeladen habt,\nsah es so aus als hättet Ihr auch das nötige Geld dafür.\"\n\n " + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).GetKompletterName() + " verlässt wütend den Tisch.";
                    SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpieltKartenGegenSpielerID()).ErhoeheBeziehungZuX(SW.Dynamisch.GetAktiverSpieler(), -20);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetSpieltKartenGegenSpielerID(0);

                    lbl_nachrichten_text.Visible = true;

                    await AufRechtsklickWarten();
                    lbl_nachrichten_text.Visible = false;
                    lbl_nachrichten_titel.Visible = false;
                }
            }

            btn_nachrichten_ksp_setzen.Wert = 0;
        }


        private void btn_nachrichten_ksp_ok_Click(object sender, EventArgs e)
        {
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_ja_Click(object sender, EventArgs e)
        {
            SpE.setBoolKurzSpeicher(true);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_nein_Click(object sender, EventArgs e)
        {
            SpE.setBoolKurzSpeicher(false);
            tcsButtonklick?.TrySetResult(true);
        }
        #endregion

        #endregion

        #region Feste feiern
        private async Task FesteFeiern()
        {
            // Fest feiern (wenn vorhanden)
            var fest = SW.Dynamisch.Spielstand.Feste.FirstOrDefault(x => x.SpielerID == SW.Dynamisch.GetAktiverSpieler() && x.Jahr == SW.Dynamisch.GetAktuellesJahr());

            if (fest != default(Fest))
            {
                var festManager = new FestManager();

                try
                {
                    string message = festManager.FestFeiern(fest);
                    SW.Dynamisch.Spielstand.Feste.Remove(fest);

                    await NachrichtenEtwasAnzeigen("Fest", message);
                }
                catch (Exception ex)
                {
                    SW.UI.TextAnzeigen.ShowDialog(ex.Message);
                }
            }

            lbl_nachrichten_titel.Visible = false;
            lbl_nachrichten_text.Visible = false;
        }
        #endregion

        #region RandomEreignisse

        private async Task RandomEreignisse()
        {
            int gesver = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetGesamtVermoegen(SW.Dynamisch.GetAktiverSpieler());

            int val1 = 0; // Vermoegen
            int val2 = 0; // Aussehen
            int val3 = 0; // Gesundheit
            int wert1 = 0; // Vermoegen
            int wert2 = 0; // Aussehen
            int wert3 = 0; // Gesundheit
            int vwert = 0;

            if (SW.Dynamisch.GetAktuellesJahr() != SW.Statisch.StartJahr)
            {
                val1 = SW.Statisch.Rnd.Next(0, 100);
                val2 = SW.Statisch.Rnd.Next(0, 100);
                val3 = SW.Statisch.Rnd.Next(0, 100);
                wert1 = SW.Statisch.Rnd.Next(5, 30);
                wert2 = SW.Statisch.Rnd.Next(1, 11);
                wert3 = SW.Statisch.Rnd.Next(1, 11);

                #region Vermoegen
                if (gesver <= 0)
                    gesver = SW.Statisch.GetStartgold();  // falls kein Vermögen vorhanden ist (oder Schulden) wird vom Startkapital ausgegangen

                vwert = Convert.ToInt32((wert1 * gesver) / 1000);

                if (val1 < 50)
                {
                    UI.TalerAendern(vwert, ref lbl_Taler);
                }
                else
                {
                    UI.TalerAendern(-vwert, ref lbl_Taler);
                }
                //Da nicht alle 100 Faelle von 0-99 belegt sind, wird im z.B. bei Fall
                //47 der Wert abgezogen/dazuaddiert obwohl kein Ereignis eintritt
                //Daher wird dieser beim Default Fall wieder ausgeglichen

                switch (val1)
                {
                    case 0:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Bei Silberspekulationen gewinnt Ihr " + vwert.ToStringGeld() + ".");
                        break;
                    case 1:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ein Cousin 3. Grades hinterlässt Euch " + vwert.ToStringGeld() + ".");
                        break;
                    case 2:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr findet einen Geldbeutel mit " + vwert.ToStringGeld() + ". Euer mangelnder Gerechtigkeitssinn lässt Euch das Geld behalten.");
                        break;
                    case 3:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Bei einer Wette gewinnt Ihr " + vwert.ToStringGeld() + ".");
                        break;
                    case 4:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr investiert " + (vwert / 2).ToStringGeld() + " in einen gerissenen Unternehmer. Kurz darauf zahlt er Euch das Doppelte zurück.");
                        break;
                    case 5:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ein Geldbeutel mit " + vwert.ToStringGeld() + " Eures Nachbarn wurde fälschlicherweise Euch zugeschickt.");
                        break;
                    case 6:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ein Euch Unbekannter steckt Euch " + vwert.ToStringGeld() + " zu damit Ihr ein Gerücht verbreitet. Guten Gewissens kommt Ihr diesem Angebot nach.");
                        break;
                    case 7:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Euer Großonkel greift Euren Unternehmungen mit " + vwert.ToStringGeld() + " unter die Arme.");
                        break;
                    case 8:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr verkauft eine alte Erzmine für " + vwert.ToStringGeld() + ". Kurz darauf ist die Ader erschöpft.");
                        break;
                    case 9:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Morgens beim Gassi gehn mit Eurem Hund Struppi verschwindet dieser. Nach einiger Sucherei taucht Struppi wieder auf. Im Maul hat er einen Knochen um den ein verdreckter goldener Armreif hängt. Später könnt Ihr den Armreif für " + vwert.ToStringGeld() + " verkaufen.");
                        break;
                    case 10:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Neben Euch stiehlt ein gemeiner Dieb einer alten Dame den Geldbeutel. Beim Davonlaufen stößt der Dieb mit Euch zusammen und lässt dadurch unwissentlich den Geldbeutel fallen. Schnell hebt Ihr den Geldbeutel mit " + vwert.ToStringGeld() + " auf. Euer kaum ausgeprägter Gerechtigkeitssinn lässt Euch das Geld behalten.");
                        break;
                    case 11:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Aus früheren Kirchensteuern bekommt Ihr " + vwert.ToStringGeld() + " zurück.");
                        break;
                    case 12:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ein Unbekannter lässt Euch " + vwert.ToStringGeld() + " zukommen.");
                        break;
                    case 13:
                        await NachrichtenEtwasAnzeigen("Finanziell", "In Eurem Keller findet Ihr ein altes Gemälde. Als Ihr es bei einer Gala ausstellen lasst, kauft es jemand für " + vwert.ToStringGeld() + ".");
                        break;
                    case 14:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr bekommt von den Schmuggelgeschäften eines erfolgreichen Kaufmannes Wind. Darauf lässt er Euch " + vwert.ToStringGeld() + " als Schweigegeld zukommen...");
                        break;
                    case 15:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr nehmt an einer Tombola teil und gewinnt " + vwert.ToStringGeld() + "!");
                        break;


                    case 50:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Bei Erzspekulationen verliert Ihr " + vwert.ToStringGeld() + ".");
                        break;
                    case 51:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr greift einem Verwandten mit " + vwert.ToStringGeld() + " unter die Arme.");
                        break;
                    case 52:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Auf dem Marktplatz rempelt Euch ein kleiner Junge beim Fangen spielen mit seinen Freunden an. Später stellt Ihr entsetzt fest, dass er dabei Euren Geldbeutel mit " + vwert.ToStringGeld() + " entwendet hat.");
                        break;
                    case 53:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Bei einer Wette verliert Ihr " + vwert.ToStringGeld() + ".");
                        break;
                    case 54:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr investiert " + vwert.ToStringGeld() + " in einen sympathischen Unternehmer. Er verschwindet spurlos.");
                        break;
                    case 55:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Nach einem Kneipenabend werdet Ihr beim Singen von unanständigen Liedern ertappt und müsst " + vwert.ToStringGeld() + " bezahlen, um die Sache unter den Tisch zu kehren.");
                        break;
                    case 56:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr spendet " + vwert.ToStringGeld() + " für die Rettung eines Waisenhaus. In der Dankesrede werdet Ihr nicht einmal erwähnt.");
                        break;
                    case 57:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr verkauft einen Teil Eures Schmucks. Der Käufer ist bereits verschwunden als Ihr merkt, dass sich in dem überreichten Geldbeutel inzwischen nur noch Steine befinden. Ihr verliert insgesamt " + vwert.ToStringGeld() + ".");
                        break;
                    case 58:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ein alter Freund aus Kindertagen leiht sich " + vwert.ToStringGeld() + " von Euch. Darauf hört Ihr nie wieder von ihm...");
                        break;
                    case 59:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Finanziell", "Eine junge, hübsche Dame macht Euch schöne Augen. Schon kauft Ihr ihr ein Diamantarmband für " + vwert.ToStringGeld() + ". Sie bedankt sich und geht ihres Weges.");
                        else
                            await NachrichtenEtwasAnzeigen("Finanziell", "Ein hübscher Jüngling macht Euch schöne Augen. Schon kauft Ihr ihm ein Rennpferd für " + vwert.ToStringGeld() + ". Er bedankt sich und geht seines Weges.");
                        break;
                    case 60:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Finanziell", "Eine Hellseherin prophezeit Euch großen Reichtum. Als Bezahlung verlangt sie " + vwert.ToStringGeld() + ". Diese Summe sollte laut ihr in Zukunft für einen Mann wie Euch nur eine Kleinigkeit sein.");
                        else
                            await NachrichtenEtwasAnzeigen("Finanziell", "Eine Hellseherin prophezeit Euch großen Reichtum. Als Bezahlung verlangt sie " + vwert.ToStringGeld() + ". Diese Summe sollte laut ihr in Zukunft für eine Frau wie Euch nur eine Kleinigkeit sein.");
                        break;
                    case 61:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr müsst " + vwert.ToStringGeld() + " für Kirchensteuern nachbezahlen.");
                        break;
                    case 62:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Für " + vwert.ToStringGeld() + " kauft Ihr einem merkwürdigem Mann ein Fläschchen mit magischem Wasser ab. Ihr trinkt es, doch nichts passiert.");
                        break;
                    case 63:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Für " + vwert.ToStringGeld() + " finanziert Ihr die Ausbildung von Waisenkindern.");
                        break;
                    case 64:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Bei einem Fest zerstört Ihr eine wertvolle Vase im Wert von " + vwert.ToStringGeld() + ".");
                        break;
                    case 65:
                        await NachrichtenEtwasAnzeigen("Finanziell", "Ihr steuert " + vwert.ToStringGeld() + " für die Mitgift eines entfernten Verwandten bei...");
                        break;

                    default:
                        if (val1 >= 50)
                        {
                            UI.TalerAendern(vwert, ref lbl_Taler);
                        }
                        else
                        {
                            UI.TalerAendern(-vwert, ref lbl_Taler);
                        }
                        break;
                }
                #endregion

                #region Ansehen
                if (val2 < 50)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(wert2);
                }
                else
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(-wert2);
                }
                //Da nicht alle 100 Faelle von 0-99 belegt sind, wird im z.B. bei Fall
                //47 der Wert abgezogen/dazuaddiert obwohl kein Ereignis eintritt
                //Daher wird dieser beim Default Fall wieder ausgeglichen

                switch (val2)
                {
                    case 0:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ihr entschließt Euch, von nun an öfter einen Kamm zu benutzen.");
                        break;
                    case 1:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr entschließt Euch, öfters eine modische Schecke zu tragen.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr entschließt Euch, öfters eine modische Robe zu tragen.");
                        break;
                    case 2:
                        // Dieses Ereignis kostet zusätzlich auch Geld, da hier etwas gekauft wird (Realismus)
                        vwert /= 2;  // Bisherigen Wert der Finanzereignisse halbieren für die Kosten dieses Ereignisses
                        UI.TalerAendern(-vwert, ref lbl_Taler);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(wert2 / 2);  // Als Bonus für die Kosten das Ansehen noch ein wenig stärker erhöhen

                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", $"Ihr kauft Euch einen eleganten Gehstock für {vwert.ToStringGeld()}.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", $"Ihr kauft Euch einen eleganten, tragbaren Sonnenschirm für {vwert.ToStringGeld()}.");
                        break;
                    case 3:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Bei jedem Treffen mit Euren Geschäftspartnern seid Ihr bereits 5 Minuten vor dem vereinbarten Termin vor Ort.");
                        break;
                    case 4:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Euer hoher Vater lehrte Euch einst: Laut sprechen, damit die anderen glauben, Ihr hättet eine Ahnung wovon Ihr redet. Nun wendet Ihr diese Devise erfolgreich bei jedem Gespräch an.");
                        break;
                    case 5:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ein namhafter Schneider fertigt Euch Kleidung an.");
                        break;
                    case 6:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Brust raus! Bauch rein! An Eurer Haltung können sich viele ein Beispiel nehmen.");
                        break;
                    case 7:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Inspiriert von einem Gemälde eines toten Marschalls, lasst Ihr Euch einen prächtigen Backenbart wachsen.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Inspiriert von einem Gemälde einer französischen Adeligen, legt Ihr Euch einen aufgeklebten, künstlichen Schönheitsfleck zu.");
                        break;
                    case 8:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Jeden Morgen veranstaltet Ihr eine Raserei der Rasierklingen. Nur mit einem glatt rasiertem Kinn verlasst Ihr das Haus.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Jeden Morgen veranstaltet Ihr eine Puderexplosion. Nur mit bleich gepudertem Gesicht verlasst Ihr das Haus.");
                        break;
                    case 9:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Das Lesen einer prätentiösen Lektüre hat Euren Wortschatz verbessert. Unabhängig vom Thema drückt Ihr Euch wie ein Kenner aus.");
                        break;
                    case 10:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Bei hitzigen Diskussionen seid Ihr immer derjenige, der einen kühlen Kopf bewahrt.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Bei hitzigen Diskussionen seid Ihr immer diejenige, die einen kühlen Kopf bewahrt.");
                        break;
                    case 11:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr kopiert die Gangweise eines galanten Herren.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr kopiert die Gangweise einer galanten Dame.");
                        break;
                    case 12:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ihr arbeitet an Euren Tischmanieren...");
                        break;
                    case 13:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Eines Morgens bemerkt Ihr Euer langes Nasenhaar im Spiegel. Prompt entledigt Ihr Euch dessen...");
                        break;
                    case 14:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Jedem Gesprächspartner blickt Ihr offen und ehrlich in die Augen... So als ob Ihr ein guter Mensch wärt.");
                        break;
                    case 15:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Bei jeder Unterhaltung habt Ihr stets das letzte Wort.");
                        break;

                    case 50:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr entschließt Euch, von nun an eine Glatze zu tragen. Die Gassenjungen kichern...");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr entschließt Euch, von nun an auf Eure Perücke zu verzichten. Die Gassenjungen kichern...");
                        break;
                    case 51:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ihr entschließt Euch, von nun an öfter Eure alten, ausgeleierten Glücksstiefel zu tragen.");
                        break;
                    case 52:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Aufgrund einer Beinverletzung gewöhnt Ihr Euch das Hinken an.");
                        break;
                    case 53:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ihr seid spät dran für einen wichtigen Geschäftstermin und könnt keine Droschke finden, also Ihr beschließt den langen Weg zu laufen. Völlig durchgeschwitzt erscheint Ihr gerade noch rechtzeitig zum Treffen.");
                        break;
                    case 54:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Am Marktplatz herumspazierend erinnert Ihr Euch an Eure Kindheitstage. Dabei beginnt Ihr Selbstgespräche zu führen. Alle anwesenden Menschen sehen Euch verdutzt an.");
                        break;
                    case 55:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Als Ihr an einem regnerischen Tag auf dem Weg zur Kirche seid, fährt neben Euch eine Kutsche durch eine Schlammpfütze und Ihr werdet völlig verdreckt. Ihr besucht dennoch den Gottesdienst...");
                        break;
                    case 56:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ihr habt Eure Zunge bei einem heißen Tee verbrannt. Wegen den Schmerzen könnt Ihr nur noch lispeln.");
                        break;
                    case 57:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Eure herzallerliebste Katze verstirbt. Von tiefster Trauer befallen geht Ihr nur noch gebückt.");
                        break;
                    case 58:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Zu Gast bei einem Festmahl betretet Ihr feuertrunken die Tanzfläche.");
                        break;
                    case 59:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Alter und Stress lassen Eure einstige Haarpracht erblassen.");
                        break;
                    case 60:
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich())
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr lasst Euch einen ungepflegten Bart wachsen.");
                        else
                            await NachrichtenEtwasAnzeigen("Ansehen", "Ihr beschließt, Euren Damenbart nicht mehr zu rasieren.");
                        break;
                    case 61:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Bei wichtigen Gesprächen kommt Ihr häufig ins Stottern.");
                        break;
                    case 62:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Bei einem Treffen mit Euren Geschäftspartnern kaut Ihr mit offenem Mund, sprecht zugleich und bekleckert auch noch Eure Kleidung...");
                        break;
                    case 63:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Ein streunender Köter bellt Euch an. Tierlieb, wie Ihr seid, kuschelt Ihr mit dem verlausten Vieh in aller Öffentlichkeit...");
                        break;
                    case 64:
                        await NachrichtenEtwasAnzeigen("Ansehen", "In jedem Gespräch stellt Ihr einen Bezug zu Euren Wurstfingern her...");
                        break;
                    case 65:
                        await NachrichtenEtwasAnzeigen("Ansehen", "Eine angesehene Dame fällt neben Euch hin. Aber anstatt Ihr zu helfen, lacht Ihr sie aus...");
                        break;

                    default:
                        if (val2 >= 50)
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(wert2);
                        }
                        else
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(-wert2);
                        }
                        break;
                }
                #endregion

                #region Gesundheit
                if (val3 < 50)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesundheit(wert3);
                }
                else
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesundheit(-wert3);
                }
                //Da nicht alle 100 Faelle von 0-99 belegt sind, wird im z.B. bei Fall
                //47 der Wert abgezogen/dazuaddiert obwohl kein Ereignis eintritt
                //Daher wird dieser beim Default Fall wieder ausgeglichen

                switch (val3)
                {
                    case 0:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr beschließt, den Ratschlägen Eures Medikus nachzukommen.");
                        break;
                    case 1:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr trinkt seltener Alkohol.");
                        break;
                    case 2:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr esst des Öfteren Obst.");
                        break;
                    case 3:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr beschließt dieses Jahr öfters schwimmen zu gehn.");
                        break;
                    case 4:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr entschließt Euch, dieses Jahr kürzere Wege zu Fuß, statt mit einer Droschke zu bewältigen.");
                        break;
                    case 5:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr gebt das Rauchen auf.");
                        break;
                    case 6:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr entschließt Euch diesen Winter keine Kosten bei der Heizung Eures Anwesens zu scheuen.");
                        break;
                    case 7:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr macht einen großen Bogen um heruntergekommene Bordelle.");
                        break;
                    case 8:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr vermeidet unnötige Reisen.");
                        break;
                    case 9:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr entschließt Euch bei Schlechtwetter einen Schal zu tragen.");
                        break;
                    case 10:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr besucht öfters Badehäuser.");
                        break;
                    case 11:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "In letzter Zeit unternehmt Ihr öfters einen abendlichen Ausritt an der frischen Luft.");
                        break;
                    case 12:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Entspannt sitzt Ihr im Park und genießt die Sonnenstrahlen. Eigentlich solltet Ihr noch Papierkram erledigen aber Ihr bleibt einfach gemütlich sitzen.");
                        break;
                    case 13:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Manchmal entschließt Ihr Euch morgens vor dem Frühstück Laufen zu gehen.");
                        break;
                    case 14:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Beeindruckt von der künstlerischen Darbietung einiger Zigeuner, beginnt Ihr selbst einfache Tricks zu üben.");
                        break;
                    case 15:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr entwickelt eine Vorliebe für Gemüse...");
                        break;

                    case 50:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr missachtet die Ratschläge Eures Medikus.");
                        break;
                    case 51:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr trinkt dieses Jahr öfters über den Durst...");
                        break;
                    case 52:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr rührt das Gemüse auf Eurem Teller nicht einmal mit eurem Schuhlöffel an.");
                        break;
                    case 53:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr gebt Eurer Schwimmtraining auf.");
                        break;
                    case 54:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr entschließt Euch auch kürzere Wegstrecken mit einer Droschke zurückzulegen.");
                        break;
                    case 55:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr beginnt mit dem Rauchen.");
                        break;
                    case 56:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Um Geld zu sparen heizt Ihr diesen Winter weniger.");
                        break;
                    case 57:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr besucht dieses Jahr öfters zweitklassige Bordelle...");
                        break;
                    case 58:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr reist dieses Jahr sehr viel in einer zugigen Droschke.");
                        break;
                    case 59:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Um Euch abzuhärten, tragt Ihr nur leichte Kleidung bei jedem Wetter.");
                        break;
                    case 60:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Aus Scham meidet Ihr die örtlichen Badehäuser.");
                        break;
                    case 61:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ihr verlasst das Haus nur, wenn Ihr keine andere Wahl habt.");
                        break;
                    case 62:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Aus Bequemlichkeit und Eurer geheimen Liebe für Euer Bett beschließt Ihr von nun an sämtlichen Papierkram liegend im Bett zu erledigen.");
                        break;
                    case 63:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Der Rauch einer Schmiede in der Nachbarschaft verraucht des Öfteren Euren Wohnsitz.");
                        break;
                    case 64:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Liebevoll bringt Ihr einem Obdachlosen eine warme Decke. Dabei fangt Ihr Euch aber Läuse ein...");
                        break;
                    case 65:
                        await NachrichtenEtwasAnzeigen("Gesundheit", "Ratten nisten sich in Eurem Anwesen ein...");
                        break;

                    default:
                        if (val3 >= 50)
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesundheit(wert3);
                        }
                        else
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesundheit(-wert3);
                        }
                        break;
                }
                #endregion

                #region Datumsereignisse
                // Aus den gültigen Datumsereignissen ein zufälliges auswählen
                List<Datumsereignis> gueltigeEreignisse = 
                    SW.Statisch.Datumsereignisse.Where(e => e.IstEreignisGueltig(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetReligion(),
                                                                         SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).EreignisseZuletztPassiert)).ToList();

                if (gueltigeEreignisse.Count() > 0)
                {
                    Datumsereignis ereignis = gueltigeEreignisse[SW.Statisch.Rnd.Next(0, gueltigeEreignisse.Count())];

                    // Ereignis anwenden und anzeigen
                    UI.TalerAendern(vwert * ereignis.TalerMultiplikator, ref lbl_Taler);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(wert2 * ereignis.AnsehenMultiplikator);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesundheit(wert3 * ereignis.GesundheitMultiplikator);

                    // Ereignis in der Liste des Spielers speichern
                    var indexZeitpunkt = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).EreignisseZuletztPassiert?.FindIndex(z => z.EreignisID == ereignis.ID);

                    if (indexZeitpunkt.HasValue && indexZeitpunkt.Value != -1)
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).EreignisseZuletztPassiert[indexZeitpunkt.Value].Zeitpunkt = DateTime.Now;
                    else
                    {
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).EreignisseZuletztPassiert == null)
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).EreignisseZuletztPassiert = new List<Ereigniszeitpunkt>();

                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).EreignisseZuletztPassiert.Add(new Ereigniszeitpunkt { EreignisID = ereignis.ID, Zeitpunkt = DateTime.Now });
                    }

                    var nachricht = ereignis.Nachricht;

                    if (ereignis.TalerMultiplikator != 0)
                        nachricht = string.Format(nachricht, Math.Abs(vwert * ereignis.TalerMultiplikator).ToStringGeld());

                    await NachrichtenEtwasAnzeigen(ereignis.Ueberschrift, nachricht);
                }
                #endregion
            }

            lbl_nachrichten_titel.Visible = false;
            lbl_nachrichten_text.Visible = false;
        }

        #endregion

        #region Verbrechen

        #region Kerkerklatsch
        private async Task Kerkerklatsch()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(7))
            {
                int beweismaechtigkeit = SW.Statisch.Rnd.Next(1, 5);
                int opferid = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxAmtStadtID());

                while (SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetAmtX(opferid) == 0 || opferid == 15) // leere id oder eigene sind nicht zugelassen
                {
                    opferid = SW.Statisch.Rnd.Next(1, SW.Statisch.GetMaxAmtStadtID());
                }

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetAmtX(opferid)).SetDelikte(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetAmtX(opferid)).GetDelikte() + beweismaechtigkeit);
                string beweisstaerke;

                if (beweismaechtigkeit > 3)
                {
                    beweisstaerke = "stark belastende";
                }
                else if (beweismaechtigkeit > 2)
                {
                    beweisstaerke = "belastende";
                }
                else if (beweismaechtigkeit > 1)
                {
                    beweisstaerke = "einige";
                }
                else
                {
                    beweisstaerke = "schwache";
                }

                await NachrichtenEtwasAnzeigen("Kerkerklatsch", "Als Kerkermeister habt Ihr dieses Jahr von einem Eurer Gefangenen\n" + beweisstaerke + " Beweise gegen " + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAmtGebiet()).GetAmtX(opferid)).GetKompletterName() + " zugetragen bekommen.");
            }

        }
        #endregion

        #region Korruptionsgelder
        private async Task Korruptionsgelder()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(21))
            {
                int anz = SW.Statisch.Rnd.Next(100, SW.Statisch.GetmaxKorruptionsGelder());

                await NachrichtenEtwasAnzeigen("Korruptionsgelder", "Als " + SW.Dynamisch.GetAmtsnameVonSPIDx(SW.Dynamisch.GetAktiverSpieler()) + " habt Ihr dieses Jahr " + anz.ToStringGeld() + " in Form von kleinen 'Spenden' erhalten.");

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(anz);
                SpielerDatenAktualisieren();
            }
        }
        #endregion

        #region Schmuggel
        private async Task Schmuggelgelder()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).CheckPrivilegX(22))
            {
                int anz = SW.Statisch.Rnd.Next(1000, 10000);

                await NachrichtenEtwasAnzeigen("Schmuggel", "Als " + SW.Dynamisch.GetAmtsnameVonSPIDx(SW.Dynamisch.GetAktiverSpieler()) + " habt Ihr dieses Jahr " + anz.ToStringGeld() + " mit Schmuggelgeschäften verdient.");

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(anz);
                SpielerDatenAktualisieren();
            }
        }
        #endregion

        #region SpionageNachrichten
        private async Task SpionageNachrichten()
        {
            bool EtwasSpioniert = false;
            bool Beweisegefunden = false;

            //Spione
            lbl_nachrichten_titel.Text = "Spionage";
            lbl_nachrichten_text.Text = "";


            for (int i = 1; i < SW.Statisch.GetMaxKIID(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).GetKosten() > 0)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).DauerPlusEins(); //Dauer der Spionage erhoehen
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).SetJahr(SW.Dynamisch.GetAktuellesJahr());
                    int opferdelikte = SW.Dynamisch.GetSpWithID(i).GetDeliktpunkte();
                    int bereitsSpionierteDelikte = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).GetDelikte();
                    opferdelikte -= bereitsSpionierteDelikte;

                    //Wenn die Zielperson durch Privilegien geschützt ist, ist es schwerer für die Spione Beweise zu sammeln
                    if (SW.Dynamisch.GetSpWithID(i).CheckPrivilegX(18))
                    {
                        opferdelikte = Convert.ToInt32((opferdelikte * 2) / 3);
                    }
                    if (SW.Dynamisch.GetSpWithID(i).CheckPrivilegX(19))
                    {
                        opferdelikte = Convert.ToInt32(opferdelikte / 2);
                    }

                    EtwasSpioniert = true;

                    int rndnext = SW.Statisch.Rnd.Next(0, 5);
                    if (opferdelikte > rndnext)
                    {
                        Beweisegefunden = true;

                        //Beweise gefunden
                        int beweismaechtigkeit = SW.Statisch.Rnd.Next(1, rndnext + 1);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).SetDelikte(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSpionage(i).GetDelikte() + beweismaechtigkeit);

                        string beweisstaerke;
                        if (beweismaechtigkeit > 3)
                        {
                            beweisstaerke = "stark belastende";
                        }
                        else if (beweismaechtigkeit > 2)
                        {
                            beweisstaerke = "belastende";
                        }
                        else if (beweismaechtigkeit > 1)
                        {
                            beweisstaerke = "einige";
                        }
                        else
                        {
                            beweisstaerke = "schwache";
                        }

                        //In der Rolle anzeigen
                        lbl_nachrichten_text.Text += "Eure Spione haben Euch " + beweisstaerke + " Beweise gegen " + SW.Dynamisch.GetSpWithID(i).GetKompletterName() + " gebracht." + "\n\n";
                    }
                }
            }

            if (EtwasSpioniert && Beweisegefunden)
            {
                lbl_nachrichten_titel.Visible = true;
                lbl_nachrichten_text.Visible = true;

                await AufRechtsklickWarten();
            }
            lbl_nachrichten_titel.Visible = false;
            lbl_nachrichten_text.Visible = false;
        }
        #endregion

        #region SabotageNachrichten
        private async Task SabotageNachrichten()
        {
            bool etwasSabotiert = false;
            int chancetime = 2;

            lbl_nachrichten_titel.Text = "Sabotage";
            lbl_nachrichten_text.Text = "";

            for (int i = 1; i < SW.Statisch.GetMaxKIID(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(i).GetDauer() > 0)
                {
                    if (SW.Dynamisch.GetSpWithID(i).CheckPrivilegX(18))
                    {
                        chancetime = 3;
                    }
                    if (SW.Dynamisch.GetSpWithID(i).CheckPrivilegX(19))
                    {
                        chancetime = 4;
                    }

                    if (SW.Statisch.Rnd.Next(0, chancetime) == 1)
                    {
                        etwasSabotiert = true;
                        int Schaden;

                        int sabMaechtigkeit = SW.Statisch.Rnd.Next(1, 9);
                        string sabostaerke;

                        if (sabMaechtigkeit > 8)
                        {
                            sabostaerke = "sehr starke";
                        }
                        else if (sabMaechtigkeit > 6)
                        {
                            sabostaerke = "starke";
                        }
                        else if (sabMaechtigkeit > 4)
                        {
                            sabostaerke = "einige";
                        }
                        else if (sabMaechtigkeit > 2)
                        {
                            sabostaerke = "geringe";
                        }
                        else
                        {
                            sabostaerke = "sehr geringe";
                        }

                        Schaden = Convert.ToInt32(SW.Dynamisch.GetSpWithID(i).GetGesamtVermoegen(i) * sabMaechtigkeit / 100);

                        //In der Rolle anzeigen
                        lbl_nachrichten_text.Text += "Es gelang Euren Saboteueren bei " + SW.Dynamisch.GetSpWithID(i).GetKompletterName() + " " + sabostaerke + " Schäden in Höhe von " + Schaden.ToString() + " anzurichten." + "\n\n";

                        SW.Dynamisch.GetSpWithID(i).ErhoeheTaler(-Schaden);

                        //Dauer verringern
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(i).ReduziereDauerUmEins();

                        //Falls Dauer 0 ist, so soll die Sabotage gelöscht werden
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAktiveSabotage(i).GetDauer() <= 0)
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).AktiveSabotageEntfernen(i);
                        }
                    }
                }
            }

            if (etwasSabotiert)
            {
                lbl_nachrichten_titel.Visible = true;
                lbl_nachrichten_text.Visible = true;

                await AufRechtsklickWarten();
            }
            lbl_nachrichten_titel.Visible = false;
            lbl_nachrichten_text.Visible = false;
        }
        #endregion

        #region Ermordung
        private async Task Ermordung()
        {
            int er_id = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetErmordetKISpielerID();
            if (er_id != 0)
            {
                PositionWechseln(Posi_ZugNachrichten);

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetErmordetKISpielerID(0);

                //Erfolg
                int rand = SW.Statisch.Rnd.Next(0, SW.Statisch.GetErmordungsChance());

                if (rand == 0)
                {
                    lbl_nachrichten_text.Text = "Die Ermordung von " + SW.Dynamisch.GetKIwithID(er_id).GetKompletterName() + " wird wie geplant durchgeführt!\n\nMöge die Wahrheit nie ans Licht kommen...";
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().HiErfolgreicheErmordungen++;
                    SW.Dynamisch.GetKIwithID(er_id).SetStirbt(true);
                }
                //Fehlschlag
                else
                {
                    lbl_nachrichten_text.Text = "Die Ermordung von " + SW.Dynamisch.GetKIwithID(er_id).GetKompletterName() + " ist fehlgeschlagen.\n\nDie Männer und Euer Geld sind spurlos verschwunden...";
                }

                lbl_nachrichten_titel.Text = "Ermordung";
                lbl_nachrichten_text.Visible = true;
                lbl_nachrichten_titel.Visible = true;

                await AufRechtsklickWarten();
                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }
        }
        #endregion

        #region VergifteterWein
        private async Task VergifteterWein()
        {
            int vw_id = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVergiftetWeinVonKISpielerID();
            if (vw_id != 0)
            {
                PositionWechseln(Posi_ZugNachrichten);

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetVergiftetWeinVonKISpielerID(0);

                //Erfolg
                int rand = SW.Statisch.Rnd.Next(0, SW.Statisch.GetVergifteterWeinChance());

                lbl_nachrichten_text.Text = "Bei einem Fest mischt Ihr " + SW.Dynamisch.GetKIwithID(vw_id).GetKompletterName() + " einen Tropfen Gift in " + SW.Dynamisch.GetKIwithID(vw_id).GetSeinenIhren() + " Trank. Einige Tage später erfahrt Ihr von Euren Informanten, dass " + SW.Dynamisch.GetKIwithID(vw_id).GetName() + " ein seltsames Leiden hat...\n\n";
                await AufRechtsklickWarten();

                //Menschlicher Spieler leidet nur an Gesundheit
                if (vw_id < SW.Statisch.GetMinKIID())
                {
                    rand = 0;
                }

                if (rand == 1)
                {
                    lbl_nachrichten_text.Text += "Bald wird " + SW.Dynamisch.GetKIwithID(vw_id).GetName() + " " + SW.Dynamisch.GetKIwithID(vw_id).GetSeinerIhrer() + " Krankheit erliegen\nMöge die Wahrheit nie ans Licht kommen...";
                    SW.Dynamisch.GetKIwithID(vw_id).SetStirbt(true);
                }
                //Fehlschlag
                else
                {
                    lbl_nachrichten_text.Text += "Nach kurzer Zeit erholt sich " + SW.Dynamisch.GetKIwithID(vw_id).GetName() + " wieder. " + SW.Dynamisch.GetKIwithID(vw_id).GetSeinerIhrer() + " Gesundheit hat gelitten.";
                    SW.Dynamisch.GetKIwithID(vw_id).ErhoeheGesundheit(-10);
                }

                lbl_nachrichten_titel.Text = "Vergifteter Wein";
                lbl_nachrichten_text.Visible = true;
                lbl_nachrichten_titel.Visible = true;

                await AufRechtsklickWarten();
                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }
        }
        #endregion

        #region VerbrechenZaehlen
        private async Task VerbrechenZaehlen()
        {
            #region #2 Hoechstzahl Anwesen
            int anzniederlassungen = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAnzahlHaeuser();
            int erlaubt = SW.Dynamisch.GetGesetzX(2);
            if (anzniederlassungen > erlaubt)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(2);
                int geldabzug = Convert.ToInt32(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetGesamtVermoegen(SW.Dynamisch.GetAktiverSpieler()) * (0.15 * (anzniederlassungen - erlaubt)));
                if (geldabzug < 1000)
                {
                    geldabzug = 1000;
                }
                lbl_nachrichten_text.Text = "Ihr besitzt " + anzniederlassungen + " Anwesen und habt damit die maximal erlaubte Anzahl\nan Anwesen überschritten. Ihr müsst daher " + geldabzug.ToStringGeld() + " Strafe zahlen";
                lbl_nachrichten_text.Visible = true;
                await AufRechtsklickWarten();
                lbl_nachrichten_text.Visible = false;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-geldabzug);
                SpielerDatenAktualisieren();
            }
            #endregion

            #region #3 Maximale Taler
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() > SW.Dynamisch.GetGesetzX(3) * 100000)
            {
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(3);
                int geldabzug = Convert.ToInt32(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetGesamtVermoegen(SW.Dynamisch.GetAktiverSpieler()) * 0.15);
                lbl_nachrichten_text.Text = "Ihr besitzt " + SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler().ToStringGeld() + " und habt damit die maximale Anzahl an Taler überschritten.\n\nIhr müsst daher " + geldabzug.ToStringGeld() + " Strafe zahlen";
                lbl_nachrichten_text.Visible = true;
                await AufRechtsklickWarten();
                lbl_nachrichten_text.Visible = false;
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheTaler(-geldabzug);
                SpielerDatenAktualisieren();
            }
            #endregion

            #region #42 Schloesser
            if (SW.Dynamisch.GetGesetzX(42) > 0)
            {
                for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(i).GetHausID() == SW.Statisch.GetMaxHausID() - 1)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(42);
                    }
                }
            }
            #endregion
        }
        #endregion

        #endregion

        


        #region Gerichtsverhandlung
        public async Task CheckGerichtsVerhandlungen()
        {
            for (int i = 0; i < SW.Statisch.GetmaxAnzahlGerichtsverhandlungen(); i++)
            {
                if (SW.Dynamisch.GetGerichtsverhandlungX(i).GetAngeklagterID() == SW.Dynamisch.GetAktiverSpieler() || SW.Dynamisch.GetGerichtsverhandlungX(i).GetKlaegerID() == SW.Dynamisch.GetAktiverSpieler() ||  SW.Dynamisch.GetGerichtsverhandlungX(i).GetRichterXID(0) == SW.Dynamisch.GetAktiverSpieler() || SW.Dynamisch.GetGerichtsverhandlungX(i).GetRichterXID(1) == SW.Dynamisch.GetAktiverSpieler() || SW.Dynamisch.GetGerichtsverhandlungX(i).GetRichterXID(2) == SW.Dynamisch.GetAktiverSpieler())
                {
                    await GerichtsverhandlungDurchfuehren(i);

                    SW.Dynamisch.GetGerichtsverhandlungX(i).SetToZero();
                }
            }
        }

        public async Task GerichtsverhandlungDurchfuehren(int x)
        {
            SpielerInfosEinAusBlenden(false);
            PositionWechseln(Posi_Gericht);

            label2.Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetKlaegerID()).GetKompletterName() + " hat einen Prozess gegen " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetKompletterName() + "\ninitiiert. ";

            if (SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID() == SW.Dynamisch.GetAktiverSpieler())
            {
                label2.Text += "Ihr müsst Euch nun für das Euch Vorgeworfene vor\nGericht verantworten.";
            }
            else if (SW.Dynamisch.GetGerichtsverhandlungX(x).GetKlaegerID() == SW.Dynamisch.GetAktiverSpieler())
            {
                if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                {
                    label2.Text += "Ihr müsst das Gericht nun von der Schuld des\nAngeklagten überzeugen.";
                }
                else
                {
                    label2.Text += "Ihr müsst das Gericht nun von der Schuld der\nAngeklagten überzeugen.";
                }
            }
            
            label2.Left = this.Width / 2 - label2.Width / 2;
            label2.Top = this.Height - label2.Height - 20;
            label2.Visible = true;

            #region Verbrechen / Delikte ermitteln

            int sum = 0;
            int deliktpunkteAngeklagter = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetDeliktpunkte();
            int[] delikte = new int[SW.Statisch.GetMaxGesetze()];

            if (SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID() >= SW.Statisch.GetMinKIID())
            {
                // KI-Angeklagter
                for (int i = 0; i < SW.Statisch.GetMaxGesetze(); i++)
                {
                    if (SW.Statisch.GetGerichtsGesetzesvorwurf()[i] != null && SW.Statisch.GetGerichtsGesetzesvorwurf()[i] != "")
                    {
                        int randdelikt = SW.Statisch.Rnd.Next(0, 10);

                        if (randdelikt > 3)   // Liegt Gesetzesbruch vor? (Zufall)
                        {
                            delikte[i] = 1;
                            deliktpunkteAngeklagter -= 2;  // Deliktpunkte abziehen

                            if (deliktpunkteAngeklagter <= 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                // Menschlicher Angeklagter
                for (int i = 0; i < SW.Statisch.GetMaxGesetze(); i++)
                {
                    int begingVerbrechen = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetBegingVerbrechenX(i);

                    if (begingVerbrechen > 0)
                    {
                        sum += begingVerbrechen;
                        delikte[i] = begingVerbrechen;
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).SetBegingVerbrechenX(i, 0);  // Verbrechencounter wieder zurücksetzen, da durch die Verhandlung die Verbrechen "gesühnt" sind
                    }
                }
            }
            #endregion

            int delstrafcounter = 0;
            int delfincounter = 0;
            int delkirchcounter = 0;

            for (int i = 0; i < SW.Statisch.GetGesetzgrenzeFinanz(); i++)
            {
                if (delikte[i] != 0)
                {
                    delfincounter++;
                }
            }

            for (int i = SW.Statisch.GetGesetzgrenzeFinanz(); i < SW.Statisch.GetGesetzgrenzeStraf(); i++)
            {
                if (delikte[i] != 0)
                {
                    delstrafcounter++;
                }
            }

            for (int i = SW.Statisch.GetGesetzgrenzeStraf(); i < SW.Statisch.GetGesetzgrenzeKirche(); i++)
            {
                if (delikte[i] != 0)
                {
                    delkirchcounter++;
                }
            }

            await AufRechtsklickWarten();

            if (delfincounter != 0)
            {
                if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                    label2.Text = "Man beschuldigt den Angeklagten, dass er gegen ";
                else
                    label2.Text = "Man beschuldigt die Angeklagte, dass sie gegen ";

                if (delfincounter == 1)
                {
                    label2.Text += "folgendes Finanzgesetz\n";
                }
                else if (delfincounter >= 2)
                {
                    label2.Text += "folgende Finanzgesetze\n";
                }
                label2.Text += "verstoßen hat:\n";
                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;

                await AufRechtsklickWarten();

                for (int i = 0; i < SW.Statisch.GetGesetzgrenzeFinanz(); i++)
                {
                    if (delikte[i] != 0)
                    {
                        label2.Text = SW.Statisch.GetGerichtsGesetzesvorwurf()[i];
                        label2.Left = this.Width / 2 - label2.Width / 2;
                        label2.Top = this.Height - label2.Height - 60;
                        await AufRechtsklickWarten();
                    }
                }
            }

            if (delstrafcounter != 0)
            {
                if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                    label2.Text = "Man beschuldigt den Angeklagten, dass er gegen ";
                else
                    label2.Text = "Man beschuldigt die Angeklagte, dass sie gegen ";

                if (delstrafcounter == 1)
                {
                    label2.Text += "folgendes Strafgesetz\n";
                }
                else if (delstrafcounter >= 2)
                {
                    label2.Text += "folgende Strafgesetze\n";
                }
                label2.Text += "verstoßen hat:\n";
                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;

                await AufRechtsklickWarten();

                for (int i = SW.Statisch.GetGesetzgrenzeFinanz(); i < SW.Statisch.GetGesetzgrenzeStraf(); i++)
                {
                    if (delikte[i] != 0)
                    {
                        label2.Text = SW.Statisch.GetGerichtsGesetzesvorwurf()[i];
                        label2.Left = this.Width / 2 - label2.Width / 2;
                        label2.Top = this.Height - label2.Height - 60;
                        await AufRechtsklickWarten();
                    }
                }
            }

            if (delkirchcounter != 0)
            {
                if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                    label2.Text = "Man beschuldigt den Angeklagten, dass er gegen ";
                else
                    label2.Text = "Man beschuldigt die Angeklagte, dass sie gegen ";

                if (delkirchcounter == 1)
                {
                    label2.Text += "folgendes Kirchgesetz\n";
                }
                else if (delkirchcounter >= 2)
                {
                    label2.Text += "folgende Kirchgesetze\n";
                }
                label2.Text += "verstoßen hat:\n";
                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;

                await AufRechtsklickWarten();

                for (int i = SW.Statisch.GetGesetzgrenzeStraf(); i < SW.Statisch.GetGesetzgrenzeKirche(); i++)
                {
                    if (delikte[i] != 0)
                    {
                        label2.Text = SW.Statisch.GetGerichtsGesetzesvorwurf()[i];
                        label2.Left = this.Width / 2 - label2.Width / 2;
                        label2.Top = this.Height - label2.Height - 60;
                        await AufRechtsklickWarten();
                    }
                }
            }

            if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                label2.Text = "Angeklagter: \"Nichts von all dem habe ich getan!\"";
            else
                label2.Text = "Angeklagte: \"Nichts von all dem habe ich getan!\"";

            label2.Left = this.Width / 2 - label2.Width / 2;

            await AufRechtsklickWarten();

            // Zeugen

            // Gerichtsentscheidung
            label2.Text = "Das hohe Gericht hat alle Zeugen vernommen.\n Es kommt nun zu einer Entscheidung durch das Gericht.";

            await AufRechtsklickWarten();

            // Richter stimmen ab
            bool[] schuldig = new bool[3];
            int unschuldig = 0;

            label1.Text = "";
            label1.ForeColor = Color.Black;

            for (int i = 0; i < 3; i++)
            {
                int id = SW.Dynamisch.GetGerichtsverhandlungX(x).GetRichterXID(i);

                if (id < SW.Statisch.GetMinKIID())
                {
                    // Spielerwahl
                    if (SW.UI.JaNeinFrage.ShowDialogText("Für welches Urteil wollt Ihr stimmen,\n " + SW.Dynamisch.GetSpWithID(id).GetKompletterName() + "?", "Schuldig", "Nicht schuldig") == DialogResult.Yes)
                    {
                        schuldig[i] = true;
                        SpE.setBoolKurzSpeicher(false);
                    }
                    else
                    {
                        schuldig[i] = false;
                        unschuldig++;
                    }
                }
                else
                {
                    // KI-Wahl
                    int kisymp = SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetRichterXID(i)).GetBeziehungZuKIX(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID());
                    int faktor = sum;

                    switch (SW.Dynamisch.Spielstand.Einstellungen.AggressivitaetKISpieler)
                    {
                        case EnumSchwierigkeitsgrad.Niedrig:
                            faktor -= 2;
                            break;
                        case EnumSchwierigkeitsgrad.Mittel:
                            faktor += 5;
                            break;
                        case EnumSchwierigkeitsgrad.Hoch:
                            faktor += 10;
                            break;
                    }

                    if (SW.Statisch.Rnd.Next(0, kisymp) > faktor)
                    {
                        schuldig[i] = false;
                        unschuldig++;
                    }
                    else
                    {
                        schuldig[i] = true;
                    }
                }

                label2.Text = SW.Dynamisch.GetSpWithID(id).GetKompletterName() + " stimmt für...";
                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;
                await AufRechtsklickWarten();

                if (schuldig[i] == false)
                {
                    label1.Text += "Nicht schuldig\n\n";
                }
                else
                {
                    label1.Text += "Schuldig!\n\n";
                }

                label1.Left = NormH(703) - label1.Width / 2;
                label1.Top = NormH(327);

                label1.Visible = true;

                await AufRechtsklickWarten();
            }

            // Ergebnis
            if (unschuldig > 1)
            {
                if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                    label2.Text = "Damit wird der Angeklagte freigesprochen!";
                else
                    label2.Text = "Damit wird die Angeklagte freigesprochen!";

                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;
            }
            else
            {
                if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID()).GetMaennlich())
                    label2.Text = "Damit ist der Angeklagte schuldig!";
                else
                    label2.Text = "Damit ist die Angeklagte schuldig!";

                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;

                await AufRechtsklickWarten();

                int rndstrafe = SW.Statisch.Rnd.Next(0, SW.Statisch.GetMaxAnzahlStrafen());

                label2.Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetGerichtsverhandlungX(x).GetRichterXID(0)).GetKompletterName() + " entscheidet sich für folgendes Urteil: " + SW.Statisch.GetStrafartX(rndstrafe).Name;
                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;
                await AufRechtsklickWarten();

                label2.Text = SW.Statisch.GetStrafartX(rndstrafe).StrafeExecute(SW.Dynamisch.GetGerichtsverhandlungX(x).GetAngeklagterID(), deliktpunkteAngeklagter);
                label2.Left = this.Width / 2 - label2.Width / 2;
                label2.Top = this.Height - label2.Height - 60;

                SpielerDatenAktualisieren();
            }

            await AufRechtsklickWarten();
            label2.Visible = false;
            label1.Visible = false;
            label1.ForeColor = Color.Gold;

            PositionWechseln(Posi_ZugNachrichten);
            SpielerInfosEinAusBlenden(true);
        }
        #endregion

        #region Check Kerker
        private async Task CheckKerker()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() <= -100)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler() < SW.Statisch.GetMaxSchulden() - SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAnsehen() * 10)
                {
                    lbl_nachrichten_text.Visible = false;
                    lbl_nachrichten_titel.Visible = false;

                    //Zuerst noch ne Abstimmung durchführen
                    bool schuldig = false;

                    PositionWechseln(Posi_Abstimmung);
                    int AnzahlAbstimmender = 11;

                    int breite = NormB(75);
                    int dist = NormB(15);

                    for (int i = 1; i <= AnzahlAbstimmender; i++)
                    {
                        this.Controls["pictureBox" + i.ToString()].Width = breite;
                        this.Controls["pictureBox" + i.ToString()].Height = breite;
                        this.Controls["pictureBox" + i.ToString()].Top = this.Height * 9 / 12;
                        this.Controls["pictureBox" + i.ToString()].Visible = true;
                        this.Controls["pictureBox" + i.ToString()].BackgroundImage = Conspiratio.Properties.Resources.SymbNV;
                    }

                    pictureBox6.Left = (this.Width - pictureBox6.Width) / 2;
                    pictureBox5.Left = pictureBox6.Left - breite - dist;
                    pictureBox4.Left = pictureBox5.Left - breite - dist;
                    pictureBox3.Left = pictureBox4.Left - breite - dist;
                    pictureBox2.Left = pictureBox3.Left - breite - dist;
                    pictureBox1.Left = pictureBox2.Left - breite - dist;
                    pictureBox7.Left = pictureBox6.Left + breite + dist;
                    pictureBox8.Left = pictureBox7.Left + breite + dist;
                    pictureBox9.Left = pictureBox8.Left + breite + dist;
                    pictureBox10.Left = pictureBox9.Left + breite + dist;
                    pictureBox11.Left = pictureBox10.Left + breite + dist;


                    //11 KIs ermitteln die abstimmen
                    int[] AbstimmendeKIs = new int[AnzahlAbstimmender];
                    int rnderg;

                    for (int i = 0; i < AnzahlAbstimmender; i++)
                    {
                        rnderg = SW.Statisch.Rnd.Next(SW.Statisch.GetMinKIID(), SW.Statisch.GetMaxKIID());

                        while (rnderg == AbstimmendeKIs[0] || rnderg == AbstimmendeKIs[1] ||
                            rnderg == AbstimmendeKIs[2] || rnderg == AbstimmendeKIs[3] ||
                            rnderg == AbstimmendeKIs[4] || rnderg == AbstimmendeKIs[5] ||
                            rnderg == AbstimmendeKIs[6] || rnderg == AbstimmendeKIs[7] ||
                            rnderg == AbstimmendeKIs[8] || rnderg == AbstimmendeKIs[9] ||
                            rnderg == AbstimmendeKIs[10])
                        {
                            rnderg = SW.Statisch.Rnd.Next(SW.Statisch.GetMinKIID(), SW.Statisch.GetMaxKIID());
                        }

                        AbstimmendeKIs[i] = rnderg;
                    }



                    label1.Text = "Wegen Euren zahlreichen Schulden müsst Ihr Euch nun vor Euren Gläubigern verantworten!";
                    label1.ForeColor = Color.Gold;
                    label1.Top = this.Height - label1.Height - 30;
                    label1.Left = (this.Width - label1.Width) / 2;
                    label1.Visible = true;

                    await AufRechtsklickWarten();

                    label1.Visible = false;

                    //Abstimmung durchfuehren


                    int schulden = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler();
                    bool[] stschuld = new bool[AnzahlAbstimmender];
                    int counter = 0;
                    int ansehen = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetAnsehen();

                    for (int i = 0; i < AnzahlAbstimmender; i++)
                    {
                        int bez = SW.Dynamisch.GetKIwithID(AbstimmendeKIs[i]).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler());
                        rnderg = SW.Statisch.Rnd.Next(0, 16);

                        if (schulden + bez * 20 + rnderg * 20 + ansehen * 3 < 0)
                        {
                            stschuld[i] = true;
                            label1.Text = SW.Dynamisch.GetKIwithID(AbstimmendeKIs[i]).GetName() + ": schuldig!";
                            this.Controls["pictureBox" + (i + 1).ToString()].BackgroundImage = Conspiratio.Properties.Resources.SymbDoor;
                            counter++;
                        }
                        else
                        {
                            label1.Text = SW.Dynamisch.GetKIwithID(AbstimmendeKIs[i]).GetName() + ": nicht schuldig!";
                            this.Controls["pictureBox" + (i + 1).ToString()].Visible = false;
                        }

                        label1.Left = (this.Width - label1.Width) / 2;
                        label1.Top = this.Height - label1.Height - 30;
                        label1.Visible = true;

                        await AufRechtsklickWarten();
                    }

                    for (int i = 1; i <= AnzahlAbstimmender; i++)
                    {
                        this.Controls["pictureBox" + i.ToString()].Visible = false;
                    }
                    label1.Visible = false;

                    if (counter > (AnzahlAbstimmender - 1) / 2)
                    {
                        schuldig = true;
                    }



                    if (schuldig)
                    {
                        //Dann landet der Spieler im Kerker
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetSitztImKerker(true);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetSpieltKartenGegenSpielerID(0);

                        //Von Wahlen ausschließen
                        if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetWahlTeilnahme() != 0)
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetWahlTeilnahme(0);
                        }

                        //Gesundheit reduzieren
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesundheit(-SW.Statisch.GetKerkerGesundheit());

                        //Ansehen reduzieren
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoehePermaAnsehen(-SW.Statisch.GetKerkerAnsehen());

                        PositionWechseln(Posi_Kerker);

                        label1.Text = "Aufgrund Eurer zahlreichen Schulden müsst Ihr nächstes\nJahr im Schuldturm verbringen";
                        label1.Top = this.Height - NormH(75);
                        label1.Left = this.Width / 2 - label1.Width / 2;
                        label1.Visible = true;
                    }

                    else
                    {
                        label1.Text = "Ihr seid noch einmal mit dem Schrecken davon gekommen...";
                        label1.Left = (this.Width - label1.Width) / 2;
                        label1.Visible = true;
                    }

                    await AufRechtsklickWarten();
                    label1.Visible = false;
                    SpielerDatenAusrichten();

                    PositionWechseln(Posi_ZugNachrichten);
                }
            }
        }
        #endregion

        #region KeineVorkommnisse
        private async Task KeineVorkommnisse()
        {
            lbl_nachrichten_titel.Text = "Resümee";
            lbl_nachrichten_text.Text = "In diesem Jahr gab es keine weiteren besonderen Vorkommnisse";

            lbl_nachrichten_titel.Visible = true;
            lbl_nachrichten_text.Visible = true;

            await AufRechtsklickWarten();

            lbl_nachrichten_titel.Visible = false;
            lbl_nachrichten_text.Visible = false;
        }
        #endregion

        #endregion

        #region RundenEreignisse

        #region RundenEndnachrichten anzeigen
        private async Task RundenEndnachrichtenAnzeigen()
        {
            SpielerInfosEinAusBlenden(false);
            await UebergangVonZugZuRundenNachrichten();
            SW.Dynamisch.RohPreiseRandomSchwanken();
            SW.Dynamisch.RohBedarfAktRundenEnde();
            SW.Dynamisch.RundenBestechungenAbwickeln();
            await KIAktionen();
            await AmtsenthebungenDurchfuehren();
            await MoeglWahlenAbhalten();
            await TodesfaelleAnzeigen();
            SW.Dynamisch.DeliktpunkteBerechnen();
            await FreieAemterAnzeigen();

            frmKampfereignisse frmKampfereignisse = new frmKampfereignisse(ref C_MusikInstanz);
            frmKampfereignisse.ShowDialog();

            SpielerInfosEinAusBlenden(true);
        }
        #endregion

        #region UebergangVonZugZuRundenNachrichten
        private async Task UebergangVonZugZuRundenNachrichten()
        {
            PositionWechseln(Posi_RundenNachrichten);
            lbl_nachrichten_titel.Text = "Ende " + SW.Dynamisch.GetAktuellesJahr().ToString();
            lbl_nachrichten_titel.Visible = true;
            await AufRechtsklickWarten();
            lbl_nachrichten_titel.Visible = false;
        }
        #endregion

        #region KI Aktionen
        private async Task KIAktionen()
        {
            SW.Dynamisch.KIAktionenDurchfuehren();
            SW.Dynamisch.KIVerheiraten();

            #region Gesetze aendern
            //Finanzgesetze
            if (SW.Dynamisch.GetReichWithID(1).GetFinanzminister() >= SW.Statisch.GetMinKIID())
            {
                int randint = SW.Statisch.Rnd.Next(1, 8);

                if (randint == 1)
                {
                    lbl_nachrichten_text.Text = "";

                    lbl_nachrichten_titel.Visible = true;
                    lbl_nachrichten_text.Visible = true;
                    PositionWechseln(Posi_RundenNachrichten);
                    lbl_nachrichten_titel.Text = "Finanzgesetze";
                    lbl_nachrichten_titel.Left = lbl_nachrichten_text.Left + lbl_nachrichten_text.Width / 2 - lbl_nachrichten_titel.Width / 2;

                    lbl_nachrichten_text.Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetFinanzminister()).GetKompletterName() + "\nändert die Finanzgesetze wie folgt:\n\n";
                    for (int i = 0; i < SW.Statisch.GetGesetzAnzahlFinanz(); i++)
                    {
                        randint = SW.Statisch.Rnd.Next(-1, 2);
                        SW.Dynamisch.GesetzXschaltenUmY(i, randint);
                        lbl_nachrichten_text.Text += SW.Dynamisch.GetGesetzXinText(i) + "\n";
                    }
                    await AufRechtsklickWarten();
                }

                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }

            //Strafgesetze
            if (SW.Dynamisch.GetReichWithID(1).GetJustizminister() >= SW.Statisch.GetMinKIID())
            {
                int randint = SW.Statisch.Rnd.Next(1, 8);

                if (randint == 1)
                {
                    lbl_nachrichten_text.Text = "";

                    lbl_nachrichten_titel.Visible = true;
                    lbl_nachrichten_text.Visible = true;
                    PositionWechseln(Posi_RundenNachrichten);
                    lbl_nachrichten_titel.Text = "Strafgesetze";
                    lbl_nachrichten_titel.Left = lbl_nachrichten_text.Left + lbl_nachrichten_text.Width / 2 - lbl_nachrichten_titel.Width / 2;

                    lbl_nachrichten_text.Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetJustizminister()).GetKompletterName() + "\nändert die Strafgesetze wie folgt:\n\n";
                    for (int i = 0; i < SW.Statisch.GetGesetzAnzahlStraf(); i++)
                    {
                        randint = SW.Statisch.Rnd.Next(-1, 2);
                        SW.Dynamisch.GesetzXschaltenUmY(i + SW.Statisch.GetGesetzgrenzeFinanz(), randint);
                        lbl_nachrichten_text.Text += SW.Dynamisch.GetGesetzXinText(i + SW.Statisch.GetGesetzgrenzeFinanz()) + "\n";
                    }
                    await AufRechtsklickWarten();
                }
                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }

            //Kirchgesetze
            if (SW.Dynamisch.GetReichWithID(1).GetErzbischof() >= SW.Statisch.GetMinKIID())
            {
                int randint = SW.Statisch.Rnd.Next(1, 8);

                if (randint == 1)
                {
                    lbl_nachrichten_text.Text = "";

                    lbl_nachrichten_titel.Visible = true;
                    lbl_nachrichten_text.Visible = true;
                    PositionWechseln(Posi_RundenNachrichten);
                    lbl_nachrichten_titel.Text = "Kirchengesetze";
                    lbl_nachrichten_titel.Left = lbl_nachrichten_text.Left + lbl_nachrichten_text.Width / 2 - lbl_nachrichten_titel.Width / 2;

                    lbl_nachrichten_text.Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetReichWithID(1).GetErzbischof()).GetKompletterName() + "\nändert die Kirchengesetze wie folgt:\n\n";
                    for (int i = 0; i < SW.Statisch.GetGesetzAnzahlKirch(); i++)
                    {
                        randint = SW.Statisch.Rnd.Next(-1, 2);
                        SW.Dynamisch.GesetzXschaltenUmY(i + SW.Statisch.GetGesetzgrenzeStraf(), randint);
                        lbl_nachrichten_text.Text += SW.Dynamisch.GetGesetzXinText(i + SW.Statisch.GetGesetzgrenzeStraf()) + "\n";
                    }
                    await AufRechtsklickWarten();
                }
                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }
            #endregion
        }
        #endregion

        #region Amtsenthebungen
        private async Task AmtsenthebungenDurchfuehren()
        {
            for (int i = 1; i < SW.Statisch.GetMaxAnzahlAmtsenthebungen(); i++)
            {
                bool graphdar = false;

                if (SW.Dynamisch.GetAmtsenthebungX(i).OpferID != 0)
                {
                    if (SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAmtsenthebungX(i).OpferID).GetAmtID() != 0)
                    {
                        //Amtsenthebungsprozess durchfuehren

                        if (SW.Dynamisch.GetAmtsenthebungX(i).OpferID < SW.Statisch.GetMinKIID() || (SW.Dynamisch.GetAmtsenthebungX(i).Waehler1 < SW.Statisch.GetMinKIID() && SW.Dynamisch.GetAmtsenthebungX(i).Waehler1 > 0) || (SW.Dynamisch.GetAmtsenthebungX(i).Waehler2 < SW.Statisch.GetMinKIID() && SW.Dynamisch.GetAmtsenthebungX(i).Waehler2 > 0) || (SW.Dynamisch.GetAmtsenthebungX(i).Waehler3 < SW.Statisch.GetMinKIID() && SW.Dynamisch.GetAmtsenthebungX(i).Waehler3 > 0))
                        {
                            graphdar = true;
                        }

                        //Graphische Darstellung nur wenn mind. 1 Spieler beteiligt ist
                        if (graphdar)
                        {
                            PositionWechseln(Posi_Amtsenthebung);
                            SpielerInfosEinAusBlenden(false);

                            label5.Text = "Amtsenthebung";
                            label5.Left = this.Width / 2 - label5.Width / 2;
                            label5.Top = 25;
                            label5.Visible = true;
                            label4.Text = "Eine Absetzung von " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAmtsenthebungX(i).OpferID).GetKompletterName() + " wurde beantragt";
                            label4.Left = this.Width / 2 - label4.Width / 2;
                            label4.Top = 100;
                            label4.Visible = true;
                        }

                        int anzwaehler = 0;
                        int[] w = new int[3];

                        w[0] = SW.Dynamisch.GetAmtsenthebungX(i).Waehler1;
                        w[1] = SW.Dynamisch.GetAmtsenthebungX(i).Waehler2;
                        w[2] = SW.Dynamisch.GetAmtsenthebungX(i).Waehler3;

                        #region Wähler im Array nach vorne schieben (führt im weiteren Verlauf sonst zu Fehlern)
                        if (w[0] == 0 && w[1] == 0 && w[2] != 0)
                        {
                            w[0] = w[2];
                            w[2] = 0;  
                        }
                        if (w[0] == 0 && w[1] != 0 && w[2] != 0)
                        {
                            w[0] = w[1];
                            w[1] = w[2];
                            w[1] = 0;
                            w[2] = 0;
                        }
                        if (w[0] == 0 && w[1] != 0 && w[2] == 0)
                        {
                            w[0] = w[1];
                            w[1] = 0;
                        }
                        if (w[0] != 0 && w[1] == 0 && w[2] != 0)
                        {
                            w[1] = w[2];
                            w[2] = 0;
                        }
                        #endregion

                        //Graphische Darstellung nur wenn mind. 1 Spieler beteiligt ist
                        if (graphdar)
                        {
                            pct_amtsent_1.Top = this.Height / 5 * 2;
                            pct_amtsent_2.Top = pct_amtsent_1.Top;
                            pct_amtsent_3.Top = pct_amtsent_1.Top;
                        }

                        for (int u = 0; u < 3; u++)
                        {
                            if (w[u] != 0)
                            {
                                anzwaehler++;
                                if (graphdar)
                                {
                                    this.Controls["pct_amtsent_" + anzwaehler.ToString()].Visible = true;
                                }
                            }
                        }

                        if (graphdar)
                        {
                            if (anzwaehler == 1)
                            {
                                pct_amtsent_1.Left = this.Width / 2 - pct_amtsent_1.Width / 2;
                            }
                            else if (anzwaehler == 2)
                            {
                                pct_amtsent_1.Left = this.Width / 2 - pct_amtsent_1.Width - pct_amtsent_1.Width / 2;
                                pct_amtsent_2.Left = this.Width / 2 + 30;
                            }
                            else
                            {
                                pct_amtsent_2.Left = this.Width / 2 - pct_amtsent_2.Width / 2;
                                pct_amtsent_1.Left = pct_amtsent_2.Left - pct_amtsent_1.Width - pct_amtsent_1.Width / 2;
                                pct_amtsent_3.Left = pct_amtsent_2.Left + pct_amtsent_2.Width + pct_amtsent_1.Width / 2;
                            }
                            await AufRechtsklickWarten();
                        }

                        bool[] stimmen = new bool[3];

                        if (anzwaehler > 0)
                        {
                            int x = 0;
                            while (x < anzwaehler)
                            {
                                //Wenn es ein HumSpieler ist
                                if (w[x] < SW.Statisch.GetMinKIID())
                                {
                                    //soll eine Stimme abgegeben werden
                                    label1.Left = this.Width / 2 - label1.Width / 2;
                                    label1.Top = this.Height / 5 * 4;
                                    label1.Visible = true;

                                    label2.Left = label1.Left;
                                    label2.Top = label1.Top + 30;
                                    label2.Visible = true;

                                    label3.Text = "Wollt Ihr, " + SW.Dynamisch.GetHumWithID(w[x]).GetName() + ", " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAmtsenthebungX(i).OpferID).GetKompletterName();
                                    label3.Top = this.Height / 5 * 3;
                                    label3.Left = this.Width / 2 - label3.Width / 2;
                                    label3.Visible = true;

                                    btn_ja.Top = label1.Top + label1.Height / 2 - btn_ja.Height / 2;
                                    btn_nein.Top = label2.Top + label2.Height / 2 - btn_nein.Height / 2;
                                    btn_ja.Left = label1.Left - 30;
                                    btn_nein.Left = btn_ja.Left;
                                    btn_ja.Visible = true;
                                    btn_nein.Visible = true;

                                    await AufButtonKlickWarten();

                                    btn_ja.Visible = false;
                                    btn_nein.Visible = false;
                                    label1.Visible = false;
                                    label2.Visible = false;

                                    stimmen[x] = SpE.getBoolKurzSpeicher();
                                    //AufRechtsklickWarten();
                                }

                                //Wenn es eine KI ist
                                else
                                {
                                    //Beziehung ermitteln
                                    if (SW.Dynamisch.GetKIwithID(w[x]).GetBeziehungZuKIX(SW.Dynamisch.GetAmtsenthebungX(i).OpferID) < 30)
                                    {
                                        stimmen[x] = true;
                                    }
                                }


                                //Graphisch abwickeln
                                string[] fuergegen = new string[2];
                                fuergegen[0] = "gegen";
                                fuergegen[1] = "für";

                                //Graphische Darstellung nur wenn mind. 1 Spieler beteiligt ist
                                if (graphdar)
                                {
                                    label3.Text = SW.Dynamisch.GetSpWithID(w[x]).GetKompletterName() + " ist " + fuergegen[Convert.ToInt16(stimmen[x])] + " die Absetzung.";
                                    label3.Left = this.Width / 2 - label3.Width / 2;
                                    label3.Visible = true;

                                    if (stimmen[x] == true)
                                    {
                                        this.Controls["pct_amtsent_" + (x + 1).ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbCrime);
                                    }
                                    else
                                    {
                                        this.Controls["pct_amtsent_" + (x + 1).ToString()].Visible = false;
                                    }
                                }
                                x++;

                                //Graphische Darstellung nur wenn mind. 1 Spieler beteiligt ist
                                if (graphdar)
                                {
                                    await AufRechtsklickWarten();
                                }
                            }

                            //Ergebnis
                            int absetzcounter = 0;
                            int u = 0;

                            while (u < 3)
                            {
                                if (stimmen[u] == true)
                                {
                                    absetzcounter++;
                                }
                                u++;
                            }


                            if (absetzcounter > Convert.ToInt16(anzwaehler / 2))
                            {
                                //Graphische Darstellung nur wenn mind. 1 Spieler beteiligt ist
                                if (graphdar)
                                {
                                    label3.Text = "Damit wurde " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAmtsenthebungX(i).OpferID).GetName() + " mit sofortiger Wirkung des Amtes enthoben!";
                                    label3.Left = this.Width / 2 - label3.Width / 2;
                                    await AufRechtsklickWarten();
                                }

                                //absetzen
                                SW.Dynamisch.AmtVonXfreigeben(SW.Dynamisch.GetAmtsenthebungX(i).OpferID);
                            }
                            else
                            {
                                //Graphische Darstellung nur wenn mind. 1 Spieler beteiligt ist
                                if (graphdar)
                                {
                                    label3.Text = "Damit behält " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAmtsenthebungX(i).OpferID).GetKompletterName() + " " + SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetAmtsenthebungX(i).OpferID).GetSeinIhr() + " Amt bei";
                                    label3.Left = this.Width / 2 - label3.Width / 2;
                                    //nicht absetzen
                                    await AufRechtsklickWarten();
                                }
                            }
                        }
                    }
                    SW.Dynamisch.SetAmtsenthebungDaten(i, 0, 0, 0, 0);
                }
                SW.Dynamisch.SetAmtsenthebungDaten(i, 0, 0, 0, 0);

                if (graphdar)
                {
                    //Controls ausblenden
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    btn_ja.Visible = false;
                    btn_nein.Visible = false;
                    pct_amtsent_1.Visible = false;
                    pct_amtsent_2.Visible = false;
                    pct_amtsent_3.Visible = false;

                    SpielerInfosEinAusBlenden(true);
                    PositionWechseln(Posi_RundenNachrichten);
                }

                this.Controls["pct_amtsent_" + (1).ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbNV);
                this.Controls["pct_amtsent_" + (2).ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbNV);
                this.Controls["pct_amtsent_" + (3).ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbNV);
            }
        }
        #endregion

        #region Wahl

        #region Wahlbuttons
        private void btn_wahl_3_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(3);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_2_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(2);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_1_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(1);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_0_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(0);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_4_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(4);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_5_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(5);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_6_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(6);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_7_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(7);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_8_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(8);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_9_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(9);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_10_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(10);
            tcsButtonklick?.TrySetResult(true);
        }

        private void btn_wahl_11_Click(object sender, EventArgs e)
        {
            SpE.setIntKurzSpeicher(11);
            tcsButtonklick?.TrySetResult(true);
        }
        #endregion

        #region MoeglicheWahlenAbhalten
        private async Task MoeglWahlenAbhalten()
        {
            for (int i = 1; i < SW.Statisch.GetMaxAnzahlWahlen(); i++)
            {
                for (int j = 1; j <= SW.Dynamisch.GetAktivSpielerAnzahl(); j++)
                {
                    //Wenn irgendein Spieler daran teilnimmt
                    if (SW.Dynamisch.GetHumWithID(j).GetWahlTeilnahme() == i)
                    {
                        await WahlMitIDxAbhalten(i);
                    }
                    //Oder ein Spieler wählen muss
                    else
                    {
                        if (SW.Dynamisch.GetWahlX(i).Waehler1 != 0)
                        {
                            if (SW.Dynamisch.GetGebietwithID(SW.Dynamisch.GetWahlX(i).GebietID, SW.Dynamisch.GetWahlX(i).Stufe).GetAmtX(SW.Dynamisch.GetWahlX(i).Waehler1) == j)
                            {
                                await WahlMitIDxAbhalten(i);
                            }
                        }
                        if (SW.Dynamisch.GetWahlX(i).Waehler2 != 0)
                        {
                            if (SW.Dynamisch.GetGebietwithID(SW.Dynamisch.GetWahlX(i).GebietID, SW.Dynamisch.GetWahlX(i).Stufe).GetAmtX(SW.Dynamisch.GetWahlX(i).Waehler2) == j)
                            {
                                await WahlMitIDxAbhalten(i);
                            }
                        }
                        if (SW.Dynamisch.GetWahlX(i).Waehler3 != 0)
                        {
                            if (SW.Dynamisch.GetGebietwithID(SW.Dynamisch.GetWahlX(i).GebietID, SW.Dynamisch.GetWahlX(i).Stufe).GetAmtX(SW.Dynamisch.GetWahlX(i).Waehler3) == j)
                            {
                                await WahlMitIDxAbhalten(i);
                            }
                        }

                    }
                }
            }


            //Restliche leere Ämter auffüllen
            for (int i = 1; i < SW.Statisch.GetMaxAnzahlWahlen(); i++)
            {
                WahlAbhalten wa = SW.Dynamisch.GetWahlX(i);
                if (wa.IstDieWahlVoll() == true)
                {
                    //Amt vergeben
                    int gewinner = SW.Statisch.Rnd.Next(0,SW.Statisch.GetKITeilnehmerProWahl());

                    //Altes Amt von Gewinner freigeben
                    SW.Dynamisch.AmtVonXfreigeben(wa.GetKandidaten()[gewinner]);

                    //Neues Amt an Gewinner vergeben
                    SW.Dynamisch.AmtAufStufeXGebietYidZanWvergeben(wa.Stufe, wa.GebietID, wa.AmtID, wa.GetKandidaten()[gewinner]);

                    //Wahl löschen
                    wa.NullSetzen();
                }
            }
            PositionWechseln(Posi_RundenNachrichten);
        }
        #endregion

        #region Wahl abhalten
        private async Task WahlMitIDxAbhalten(int x)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            int[] stimme = new int[SW.Statisch.GetMaxWahlWaehler()];

            int[] waehlerX = new int[SW.Statisch.GetMaxWahlWaehler()];
            int[] KandX;
            int gewinner = 0;
            int abstand = NormH(33);

            bool randomWahl = false;
            bool esGibtWaehler = true;

            //Die richtigen IDs der Wähler werden hier ermittelt
            //Kopiert nach Bewerbinfos!!!
            for (int i = 0; i < SW.Statisch.GetMaxWahlWaehler(); i++)
            {
                int waehleramtid = SW.Dynamisch.GetWahlX(x).GetWaehler()[i];

                //Stadtebene
                if (waehleramtid < SW.Statisch.GetMaxAmtStadtID())
                {
                    waehlerX[i] = SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetWahlX(x).GebietID).GetAmtX(waehleramtid);
                }
                //Landesebene
                else if (waehleramtid < SW.Statisch.GetMaxAmtLandID())
                {
                    int gebid = SW.Dynamisch.GetWahlX(x).GebietID;
                    int lid;

                    //z.B. Vogt wählt Bürgermeister dann ist das Gebiet noch immer mit der Stadtid angegeben
                    if (SW.Dynamisch.GetWahlX(x).AmtID < SW.Statisch.GetMaxAmtStadtID())
                    {
                        //Hier muss die Stadt zu dem Land zugewiesen werden
                        lid = SW.Dynamisch.GetLandIDzuStadtX(gebid);
                    }
                    else
                    {
                        lid = gebid;
                    }
                    waehlerX[i] = SW.Dynamisch.GetLandWithID(lid).GetAmtX(waehleramtid);
                }
                //Reichsebene
                else
                {
                    waehlerX[i] = SW.Dynamisch.GetReichWithID(1).GetAmtX(waehleramtid);
                }
            }

            //KandidatenIDs laden
            KandX = SW.Dynamisch.GetWahlX(x).GetKandidaten();

            int waehlerAnzahl = 0;


            //Kandidaten zaehlen
            int kandAnzahl = 0;
            for (int u = 0; u < SW.Statisch.GetMaxWahlKandidaten(); u++)
            {
                if (KandX[u] != 0)
                {
                    kandAnzahl++;
                }
            }

            //Graphisch alles darstellen
            PositionWechseln(Posi_Wahl);
            SpielerInfosEinAusBlenden(false);

            label2.Visible = true;

            //Wenn es keinen Wähler gibt -> Randomwahl
            if (waehlerX[0] == 0 && waehlerX[1] == 0 && waehlerX[2] == 0)
            {
                //Namen der Kandidaten eintragen
                for (int y = 0; y < kandAnzahl; y++)
                {
                    this.Controls["lbl_wahl_kand" + y.ToString()].Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetWahlX(x).GetKandidaten()[y]).GetKompletterName();
                    this.Controls["lbl_wahl_kand" + y.ToString()].Left = this.Width / 2 - 250;
                    this.Controls["btn_wahl_" + y.ToString()].Left = this.Controls["lbl_wahl_kand" + y.ToString()].Left - this.Controls["btn_wahl_" + y.ToString()].Width - 10;
                    this.Controls["lbl_wahl_kand" + y.ToString()].Visible = true;
                }

                //Random Wahl mit allen Kandidaten
                esGibtWaehler = false;
                randomWahl = true;

                gewinner = SW.Statisch.Rnd.Next(0, kandAnzahl);
            }

            //Es gibt mind. einen Wähler
            else
            {
                //Wähler zählen
                if (waehlerX[0] != 0)
                {
                    waehlerAnzahl++;
                }
                if (waehlerX[1] != 0)
                {
                    waehlerAnzahl++;
                }
                if (waehlerX[2] != 0)
                {
                    waehlerAnzahl++;
                }

                //Wähler müssen im Array die ersten Stellen einnehmen:
                if (waehlerX[0] == 0 && waehlerX[1] != 0 && waehlerX[2] != 0)
                {
                    waehlerX[0] = waehlerX[1];
                    waehlerX[1] = waehlerX[2];
                }
                else if (waehlerX[0] == 0 && waehlerX[1] == 0 && waehlerX[2] != 0)
                {
                    waehlerX[0] = waehlerX[2];
                }
                else if (waehlerX[0] == 0 && waehlerX[1] != 0 && waehlerX[2] == 0)
                {
                    waehlerX[0] = waehlerX[1];
                }
                else if (waehlerX[0] != 0 && waehlerX[1] == 0 && waehlerX[2] != 0)
                {
                    waehlerX[1] = waehlerX[2];
                }



                string AmtsName = SW.Statisch.GetAmtwithID(SW.Dynamisch.GetWahlX(x).AmtID).GetAmtsname(true);
                string Gebietsname = SW.Dynamisch.GetGebietwithID(SW.Dynamisch.GetWahlX(x).GebietID, SW.Dynamisch.GetWahlX(x).Stufe).GetGebietsName();


                label2.Text = "Für die Wahl des " + AmtsName + "s in " + Gebietsname + "\nhaben sich folgende Bewerber aufgestellt:";
                label2.Left = (this.Width - label2.Width) / 2;
                label2.Top = NormH(200 - kandAnzahl * 13);


                //Namen der Kandidaten eintragen
                for (int y = 0; y < kandAnzahl; y++)
                {
                    this.Controls["lbl_wahl_kand" + y.ToString()].Text = SW.Dynamisch.GetSpWithID(SW.Dynamisch.GetWahlX(x).GetKandidaten()[y]).GetKompletterName();
                    this.Controls["lbl_wahl_kand" + y.ToString()].Left = this.Width / 2 - NormB(250);

                    if (y == 0)
                    {
                        this.Controls["lbl_wahl_kand" + y.ToString()].Top = label2.Bottom + abstand;
                    }
                    else
                    {
                        this.Controls["lbl_wahl_kand" + y.ToString()].Top = this.Controls["lbl_wahl_kand" + (y - 1).ToString()].Bottom + NormH(10);
                    }

                    this.Controls["btn_wahl_" + y.ToString()].Left = this.Controls["lbl_wahl_kand" + y.ToString()].Left - this.Controls["btn_wahl_" + y.ToString()].Width - NormB(10);
                    this.Controls["lbl_wahl_kand" + y.ToString()].Visible = true;
                }


                await AufRechtsklickWarten();

                //Stimmen vergeben
                for (int wc = 0; wc < waehlerAnzahl; wc++)
                {
                    //Ein Spieler darf selbst wählen
                    if (waehlerX[wc] < SW.Statisch.GetMinKIID())
                    {
                        //Buttons einblenden und positionieren
                        for (int c = 0; c < kandAnzahl; c++)
                        {
                            this.Controls["btn_wahl_" + c.ToString()].Visible = true;
                            this.Controls["btn_wahl_" + c.ToString()].Left = this.Controls["lbl_wahl_kand" + c.ToString()].Left - 10 - this.Controls["btn_wahl_" + c.ToString()].Width;
                            this.Controls["btn_wahl_" + c.ToString()].Top = this.Controls["lbl_wahl_kand" + c.ToString()].Top + this.Controls["lbl_wahl_kand" + c.ToString()].Height / 2 - this.Controls["btn_wahl_" + c.ToString()].Height / 2;
                        }

                        label1.Text = SW.Dynamisch.GetSpWithID(waehlerX[wc]).GetKompletterName() + ", bitte trefft Eure Wahl:";
                        label1.Left = (this.Width - label1.Width) / 2;
                        label1.Top = this.Controls["lbl_wahl_kand" + (kandAnzahl-1).ToString()].Bottom + abstand;
                        label1.Visible = true;

                        await AufButtonKlickWarten();
                        stimme[wc] = SpE.getIntKurzSpeicher();
                        SpE.setIntKurzSpeicher(0);

                        //Buttons ausblenden
                        for (int c = 0; c < kandAnzahl; c++)
                        {
                            this.Controls["btn_wahl_" + c.ToString()].Visible = false;
                        }

                        label1.Visible = false;
                    }

                    //Falls es sich um eine KI handelt, wählt die den "Sympathisanten"
                    else
                    {
                        int best = 0;
                        for (int kc = 0; kc < kandAnzahl; kc++)
                        {
                            int bezieh = SW.Dynamisch.GetKIwithID(waehlerX[wc]).GetBeziehungZuKIX(KandX[kc]);
                            int ansehbon = Convert.ToInt32(SW.Dynamisch.GetSpWithID(KandX[kc]).GetAnsehen() / 10);
                            int relsympathie = SW.Dynamisch.GetRelSympathieVonXzuY(waehlerX[wc], KandX[kc]);
                            int value = bezieh + ansehbon + relsympathie;

                            if (value > best)
                            {
                                best = SW.Dynamisch.GetKIwithID(waehlerX[wc]).GetBeziehungZuKIX(KandX[kc]);
                                stimme[wc] = kc;
                            }
                        }
                    }

                    label1.Text = SW.Dynamisch.GetSpWithID(waehlerX[wc]).GetKompletterName() + " stimmt für\n" + SW.Dynamisch.GetSpWithID(KandX[stimme[wc]]).GetKompletterName();
                    label1.Left = this.Width / 2 - label1.Width / 2;
                    label1.Top = this.Controls["lbl_wahl_kand" + (kandAnzahl-1).ToString()].Bottom + abstand;
                    label1.Visible = true;

                    //Stimmen platzieren
                    if (wc == 0)
                    {
                        pct_w_st1.Visible = true;
                        pct_w_st1.Top = this.Controls["lbl_wahl_kand" + stimme[0]].Top;
                        pct_w_st1.Left = this.Controls["lbl_wahl_kand" + stimme[0]].Left + this.Controls["lbl_wahl_kand" + stimme[0]].Width;
                    }

                    if (wc == 1)
                    {
                        pct_w_st2.Visible = true;
                        pct_w_st2.Top = this.Controls["lbl_wahl_kand" + stimme[1]].Top;
                        pct_w_st2.Left = this.Controls["lbl_wahl_kand" + stimme[1]].Left + this.Controls["lbl_wahl_kand" + stimme[1]].Width;
                        if (stimme[1] == stimme[0])
                        {
                            pct_w_st2.Left += 35;
                        }
                    }

                    if (wc == 2)
                    {
                        pct_w_st3.Visible = true;
                        pct_w_st3.Top = this.Controls["lbl_wahl_kand" + stimme[2]].Top;
                        pct_w_st3.Left = this.Controls["lbl_wahl_kand" + stimme[2]].Left + this.Controls["lbl_wahl_kand" + stimme[2]].Width;

                        if (stimme[2] == stimme[0])
                        {
                            pct_w_st3.Left += 35;
                        }
                        if (stimme[2] == stimme[1])
                        {
                            pct_w_st3.Left += 35;
                        }
                    }

                    await AufRechtsklickWarten();
                    label1.Visible = false;
                }

                //Stimmen von jedem Kandidaten zählen
                int[] hatStimmen = new int[SW.Statisch.GetMaxWahlKandidaten()];

                for (int i = 0; i < waehlerAnzahl; i++)
                {
                    hatStimmen[stimme[i]]++;
                }

                //Maximalwert der bekommen Stimmen ermitteln

                //max Stimmen ermitteln
                int max = 0;
                for (int i = 0; i < SW.Statisch.GetMaxWahlKandidaten(); i++)
                {
                    if (hatStimmen[i] > max)
                    {
                        max = hatStimmen[i];
                        gewinner = i;
                    }
                }

                //Prüfen ob mehere die maximale Anzahl an Stimmen haben
                int maxcounter = 0;
                for (int i = 0; i < SW.Statisch.GetMaxWahlKandidaten(); i++)
                {
                    if (hatStimmen[i] == max)
                    {
                        maxcounter++;
                    }
                }

                //Wenn mindesten 2 gleich viele Stimmen haben
                if (maxcounter > 1)
                {
                    //random Wahl
                    randomWahl = true;

                    //Gewinner abändern nach dem Ergebnis
                    int gzaeh = SW.Statisch.Rnd.Next(0, maxcounter);
                    int z_counter = 0;
                    for (int i = 0; i < SW.Statisch.GetMaxWahlKandidaten(); i++)
                    {
                        //Wenn er zu denen mit den meisten Stimmen gehört
                        if (hatStimmen[i] == max)
                        {
                            //Und er das Los gezogen hat
                            if (z_counter == gzaeh)
                            {
                                gewinner = i;
                            }

                            z_counter++;
                        }
                    }
                }
            }

            //Darstellung für Benutzer
            label1.Visible = true;

            //Randomwahl
            if (esGibtWaehler == false && randomWahl == true)
            {
                label2.Visible = false;
                label1.Text = "Diese Wahl wird durch ein Los entschieden";
                label1.Left = (this.Width - label1.Width) / 2;
                label1.Top = this.Controls["lbl_wahl_kand" + (kandAnzahl - 1).ToString()].Bottom + abstand;
                await AufRechtsklickWarten();
                label1.Text = "Und das Los entscheidet für ";
                label1.Left = (this.Width - label1.Width) / 2;
                await AufRechtsklickWarten();
                if (KandX[gewinner] < SW.Statisch.GetMinKIID())
                {
                    label1.Text += SW.Dynamisch.GetHumWithID(KandX[gewinner]).GetKompletterName();
                }
                else
                {
                    label1.Text += SW.Dynamisch.GetKIwithID(KandX[gewinner]).GetKompletterName();
                }
                label1.Left = this.Width / 2 - label1.Width / 2;

                await AufRechtsklickWarten();
            }
            else
            {
                if (randomWahl)
                {
                    label1.Text = "Aufgrund von Stimmengleichheit wird ein Los für die Entscheidung gezogen...";
                    await AufRechtsklickWarten();
                }

                label1.Text = "Damit geht das Amt des " + SW.Statisch.GetAmtwithID(SW.Dynamisch.GetWahlX(x).AmtID).GetAmtsname(true) + "s an\n" + SW.Dynamisch.GetSpWithID(KandX[gewinner]).GetKompletterName();
                label1.Top = this.Controls["lbl_wahl_kand" + (kandAnzahl - 1).ToString()].Bottom + abstand;
                label1.Left = this.Width / 2 - label1.Width / 2;
                await AufRechtsklickWarten();
            }

            int aid = SW.Dynamisch.GetSpWithID(KandX[gewinner]).GetAmtID();

            //Falls der Spieler überhaupt ein Amt hatte...
            if (aid != 0)
            {
                SW.Dynamisch.AmtVonXfreigeben(KandX[gewinner]);
            }

            SW.Dynamisch.AmtAufStufeXGebietYidZanWvergeben(SW.Dynamisch.GetWahlX(x).Stufe, SW.Dynamisch.GetWahlX(x).GebietID, SW.Dynamisch.GetWahlX(x).AmtID, KandX[gewinner]);

            //Alle Wahlteilnahmen auf 0 setzen
            for (int h = 0; h < SW.Statisch.GetMaxWahlKandidaten(); h++)
            {
                if (KandX[h] != 0)
                {
                    SW.Dynamisch.GetSpWithID(KandX[h]).SetWahlTeilnahme(0);
                }
            }

            SpielerInfosEinAusBlenden(true);
            pct_w_st1.Visible = false;
            pct_w_st2.Visible = false;
            pct_w_st3.Visible = false;
            lbl_wahl_kand0.Visible = false;
            lbl_wahl_kand1.Visible = false;
            lbl_wahl_kand2.Visible = false;
            lbl_wahl_kand3.Visible = false;
            label2.Visible = false;
            label1.Visible = false;
            lbl_wahl_kand4.Visible = false;
            lbl_wahl_kand5.Visible = false;
            lbl_wahl_kand6.Visible = false;
            lbl_wahl_kand7.Visible = false;
            lbl_wahl_kand8.Visible = false;
            lbl_wahl_kand9.Visible = false;
            lbl_wahl_kand10.Visible = false;
            lbl_wahl_kand11.Visible = false;

            SW.Dynamisch.GetWahlX(x).NullSetzen();
        }

        #endregion

        #endregion

        #region TodesfaelleAnzeigen
        private async Task TodesfaelleAnzeigen()
        {
            int counter = 0;

            if (SW.Dynamisch.TodesfaelleAnzeigen)
            {
                lbl_nachrichten_text.Text = "";

                lbl_nachrichten_titel.Visible = true;
                lbl_nachrichten_text.Visible = true;
                PositionWechseln(Posi_ZugNachrichten);
                lbl_nachrichten_titel.Text = "Todesfälle in diesem Jahr";
                lbl_nachrichten_titel.Left = lbl_nachrichten_text.Left + lbl_nachrichten_text.Width / 2 - lbl_nachrichten_titel.Width / 2;
            }

            // Fixtode zuerst
            for (int i = SW.Statisch.GetMinKIID(); i < SW.Statisch.GetMaxKIID(); i++)
            {
                if (SW.Dynamisch.GetKIwithID(i).GetStirbt() == true)
                {
                    if (SW.Dynamisch.TodesfaelleAnzeigen)
                    {
                        if (counter >= 10)
                        {
                            await AufRechtsklickWarten();
                            lbl_nachrichten_text.Text = "";
                            counter = 0;
                        }

                        lbl_nachrichten_text.Text += SW.Dynamisch.GetSpWithID(i).GetKompletterName() + " (" + SW.Dynamisch.GetSpWithID(i).GetAlter().ToString() + "†)\n";
                        counter++;
                    }

                    SW.Dynamisch.KIstirbt(i);
                }
            }

            // Dann Chancetode
            for (int i = SW.Statisch.GetMinKIID(); i < SW.Statisch.GetMaxKIID(); i++)
            {
                if (Sterbeformel(i))
                {
                    if (SW.Dynamisch.TodesfaelleAnzeigen)
                    {
                        if (counter >= 10)
                        {
                            await AufRechtsklickWarten();
                            lbl_nachrichten_text.Text = "";
                            counter = 0;
                        }

                        lbl_nachrichten_text.Text += SW.Dynamisch.GetSpWithID(i).GetKompletterName() + " (" + SW.Dynamisch.GetSpWithID(i).GetAlter().ToString() + "†)\n";
                        counter++;
                    }

                    SW.Dynamisch.KIstirbt(i);
                }
            }

            if (SW.Dynamisch.TodesfaelleAnzeigen)
            {
                await AufRechtsklickWarten();

                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }
        }
        #endregion     

        #region FreieAemterAnzeigen
        private async Task FreieAemterAnzeigen()
        {
            int[] wahlids;
            lbl_nachrichten_text.Text = "";
            int amtcounter = 0;

            for (int i = 1; i <= SW.Dynamisch.GetAktivSpielerAnzahl(); i++)
            {
                wahlids = SW.Dynamisch.GetFreieAemterFuerSpX(i);
                for (int j = 0; j < SW.Dynamisch.GetAnzahlFreieAemterFuerSpX(i); j++)
                {
                    string Amtsname = SW.Statisch.GetAmtwithID(SW.Dynamisch.GetWahlX(wahlids[j]).AmtID).GetAmtsname(true);
                    string Gebietsname = SW.Dynamisch.GetGebietwithID(SW.Dynamisch.GetWahlX(wahlids[j]).GebietID, SW.Dynamisch.GetWahlX(wahlids[j]).Stufe).GetGebietsName();

                    lbl_nachrichten_text.Text += Amtsname + " in " + Gebietsname + "\n";

                    amtcounter++;

                    //Damit nicht mehr als 10 freie Aemter pro Seite angezeigt werden
                    if (amtcounter >= 10)
                    {
                        PositionWechseln(Posi_RundenNachrichten);
                        lbl_nachrichten_text.Visible = true;
                        lbl_nachrichten_titel.Text = "Freie Ämter";
                        lbl_nachrichten_titel.Visible = true;

                        await AufRechtsklickWarten();

                        lbl_nachrichten_text.Text = "";
                        amtcounter = 0;
                        lbl_nachrichten_text.Visible = false;
                        lbl_nachrichten_titel.Visible = false;
                    }
                }
            }

            if (lbl_nachrichten_text.Text != "")
            {
                PositionWechseln(Posi_RundenNachrichten);
                lbl_nachrichten_text.Visible = true;
                lbl_nachrichten_titel.Text = "Freie Ämter";
                lbl_nachrichten_titel.Visible = true;

                await AufRechtsklickWarten();

                lbl_nachrichten_text.Visible = false;
                lbl_nachrichten_titel.Visible = false;
            }
        }
        #endregion

        #endregion

        #endregion



        #region Orte und deren Funktionen

        #region Kirche

        #region Hochzeitsglocken
        private void KircheHochzeitsglocken()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetVerheiratet() != 0)
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr seid bereits verheiratet. Nehmt Euch doch eine Mätresse");
            }
            else if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID != 0)
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr werbt bereits um " + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetKompletterName());
            }
            else
            {
                PositionWechseln(Posi_Kupplerin);
            }
        }
        #endregion

        #region Konvertieren
        private void KircheKonvertieren()
        {
            int konvertierkosten = SW.Statisch.GetKonvertierkosten();
            int eigeneRelID = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetReligion();
            int neueID = eigeneRelID + 1;

            if (neueID >= SW.Statisch.GetRelMaxID())
            {
                neueID = SW.Statisch.GetRelMinID() + 1;
            }

            if (SW.Dynamisch.CheckIfenoughGold(konvertierkosten))
            {
                if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr für " + konvertierkosten.ToStringGeld() + "\nzum " + SW.Statisch.GetReligionsNamenX(neueID) + "en Glauben wechseln?", "Ja", "Nein") == DialogResult.Yes)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetReligion(neueID);
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerStatistik().KKonvertierungen++;
                    SpE.setBoolKurzSpeicher(false);
                    UI.TalerAendern(-konvertierkosten, ref lbl_Taler);
                }

                PositionWechseln(Posi_Kirche);
            }
        }
        #endregion

        #region Austreten
        private void KircheAustreten()
        {
            int austrittkosten = SW.Statisch.GetAustrittskosten();

            if (SW.Dynamisch.CheckIfenoughGold(austrittkosten))
            {
                if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr für " + austrittkosten.ToStringGeld() + "\naus der Kirche austreten?", "Ja", "Nein") == DialogResult.Yes)
                {
                    //falls verboten
                    if (SW.Dynamisch.GetGesetzX(40) != 0)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheGesetzXUmEins(40);
                    }

                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetReligion(SW.Statisch.GetRelFreiID());
                    SpE.setBoolKurzSpeicher(false);
                    UI.TalerAendern(-austrittkosten, ref lbl_Taler);
                    PositionWechseln(Posi_Kontor);
                }
            }
        }
        #endregion

        #endregion

        #region Hochzeitsglocken

        #region Partner Wahl selbst
        private void PartnerWaehlenSelbst()
        {
            SW.UI.PolitischeWeltkarteDialog.ShowDialogModus(7, true);
        }
        #endregion

        #region Partner Wahl Kupplerin
        private void PartnerWaehlenKupplerin()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID == 0)
            {
                int optimalerPartner = 0;

                for (int i = SW.Statisch.GetMinKIID(); i < SW.Statisch.GetMaxKIID(); i++)
                {
                    // Wenn sie unterschiedliches Geschlecht vorweisen
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich() != SW.Dynamisch.GetKIwithID(i).GetMaennlich())
                    {
                        // und nicht verheiratet sind
                        if (SW.Dynamisch.GetKIwithID(i).GetVerheiratet() == 0)
                        {
                            // und das Amt nicht höher ist als in der Stadtebene
                            if (SW.Dynamisch.GetKIwithID(i).GetAmtID() < 17)
                            {
                                if (optimalerPartner == 0)
                                {
                                    optimalerPartner = i;
                                }
                                else
                                {
                                    int Preis = Convert.ToInt32(SW.Dynamisch.GetKIwithID(i).GetTaler() * SW.Statisch.GetKupplerProzente());

                                    if (SW.Dynamisch.GetKIwithID(optimalerPartner).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler()) < SW.Dynamisch.GetKIwithID(i).GetBeziehungZuKIX(SW.Dynamisch.GetAktiverSpieler()) + SW.Statisch.Rnd.Next(-15, 16) &&
                                        Preis <= (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetGesamtVermoegen(SW.Dynamisch.GetAktiverSpieler()) * 0.4d))  // Nur die Partner vorschlagen, deren Preis nicht höher liegt als 40 % des Gesamtvermögen des Spielers
                                    {
                                        optimalerPartner = i;
                                    }
                                }
                            }
                        }
                    }
                }

                KupplerinAngebot KA = new KupplerinAngebot(optimalerPartner, SW.Dynamisch.GetAktiverSpieler());
                KA.ShowDialog();
                SpielerDatenAktualisieren();
            }
            else
            {
                SW.Dynamisch.BelTextAnzeigen("Ihr werbt bereits um " + SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).WirbtUmSpielerID).GetKompletterName());
            }
        }
        #endregion

        #endregion


        #region Schreibstube

        #region KreditbuchZeigen
        private async Task KreditbuchZeigen()
        {
            PositionWechseln(Posi_Kreditbuch);
            bool etwasangezeigt = false;
            int count = 0;
            for (int i = 0; i < SW.Statisch.GetMaxKredite(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetDauer() > 0)
                {
                    etwasangezeigt = true;
                    KreditInLabelAnzeigen(count);
                }
                count++;
            }
            if (etwasangezeigt == false)
            {
                lbl_kreditb_0.Visible = true;
                lbl_kreditb_0.Text = "Zum Glück steht Ihr zur Zeit bei niemandem in der Kreide";
                await AufRechtsklickWarten();
            }
        }
        #endregion

        #region KreditInLabelAnzeigen
        private void KreditInLabelAnzeigen(int i)
        {
            int kiid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetKIID();
            int sum = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetTaler();
            int zin = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetZinsen();
            int endjahr = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(i).GetDauer() + SW.Dynamisch.GetAktuellesJahr();

            string sSeineIhre = "ihre";

            if (SW.Dynamisch.GetKIwithID(kiid).GetMaennlich())
            {
                sSeineIhre = "seine";
            }

            this.Controls["lbl_kreditb_" + i.ToString()].Text = SW.Dynamisch.GetKIwithID(kiid).GetKompletterName() + " fordert für " + sSeineIhre + " " + sum.ToStringGeld() + " " + zin.ToString() + "% Zinsen bis zum Jahr " + endjahr.ToString() + ".";
            this.Controls["btn_kreditb_tilg_" + i.ToString()].Visible = true;
            this.Controls["lbl_kreditb_tilg_" + i.ToString()].Visible = true;
            this.Controls["lbl_kreditb_" + i.ToString()].Visible = true;
        }
        #endregion

        #region KreditNehmen
        private void KreditNehmen()
        {
            Geldleiher Gl = new Geldleiher(SW.Dynamisch.GetAktiverSpieler(), ref lbl_Taler);
            Gl.ShowDialog();
        }
        #endregion

        #region KreditTilgen
        private void KreditTilgen(int kreditID)
        {
            int taler = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).GetTaler();

            if (!SW.Dynamisch.CheckIfenoughGold(taler))
                return;

            UI.TalerAendern(-taler, ref lbl_Taler);
            SW.Dynamisch.GetKIwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).GetKIID()).ErhoeheTaler(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).GetTaler());  // KI Geld erhöhen   
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).SetDauer(0);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).SetTaler(0);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).SetKIID(0);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetKreditMitID(kreditID).SetZinsen(0);

            // Im Buch ausblenden
            this.Controls["lbl_kreditb_" + kreditID.ToString()].Visible = false;
            this.Controls["lbl_kreditb_tilg_" + kreditID.ToString()].Visible = false;
            this.Controls["btn_kreditb_tilg_" + kreditID.ToString()].Visible = false;
        }
        #endregion

        #region Bewerben
        private void Bewerben()
        {
            BewerbForm beform = new BewerbForm();
            beform.ShowDialog();
        }
        #endregion

        #region HandelszertifikateAnzeigen
        private void HandelszertifikatAnzeigen()
        {
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBekamHandeslzertifikatX() != 0)
            {
                Handelszertifikat hzft = new Handelszertifikat(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetBekamHandeslzertifikatX());
                hzft.ShowDialog();

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetBekamHandelszertifikatX(0);
            }
        }
        #endregion

        #region Privilegien anzeigen
        private void PrivilegienZeigen()
        {
            PrivilegienAnzeigen PA = new PrivilegienAnzeigen();
            PA.ShowDialog();
            SW.Dynamisch.PrivilegienAktualisieren();
            SpielerDatenAktualisieren();
        }
        #endregion

        #region Kontrahenten anzeigen
        private void KontrahentenZeigen()
        {
            KontrahentenForm kf = new KontrahentenForm(14);
            kf.ShowDialog();
        }
        #endregion

        #endregion


        #region Stadt

        #region StadtWSXclick
        private void StadtWSXclick(bool linksklick, int wks_nr)
        {
            //Wenn die WS vorhanden ist
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(wks_nr, globalAktiveStadt).GetEnabled() == true)
            {
                if (linksklick)
                {
                    WerkstaettenForm wsf = new WerkstaettenForm(globalAktiveStadt, wks_nr, ref lbl_Taler);
                    wsf.ShowDialog();
                }
                else
                {
                    int verkpreis = (SW.Dynamisch.GetRohstoffwithID(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr)).GetWSKaufpreis() * 3) / 4;

                    if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr Eure Werkstätte für " + verkpreis.ToString() + "\nTaler verkaufen?", "Ja", "Nein") == DialogResult.Yes)
                    {
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(wks_nr, globalAktiveStadt).SetEnabled(false);

                        UI.TalerAendern(verkpreis, ref lbl_Taler);

                        //BilderAktualisieren();

                        //Ueberpruefen ob von diesem Rohstoff Werkstaetten eingestellt sind
                        for (int i = 0; i < SW.Statisch.GetMaxProdSlots(); i++)
                        {
                            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, i).GetProduktionRohstoff() == SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr))
                            {
                                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, i).SetProduktionStaetten(0);
                                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, i).SetProduktionArbeiter(0);
                                break;
                            }
                        }

                        //Controls ausblenden
                        this.Controls["btn_stadt_roh" + wks_nr.ToString()].Visible = false;
                        this.Controls["lbl_stadt_roh" + wks_nr.ToString()].Visible = false;
                        this.Controls["label" + wks_nr.ToString()].Visible = false;

                        this.Controls["btn_stadt_ws" + wks_nr.ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbWS);
                    }
                }
            }
            //WS ist nicht vorhanden aber das Rohstoffrecht
            else
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatHausVonStadtAnArraystelle(globalAktiveStadt).GetHausID() != 0)
                {
                    int preis = SW.Dynamisch.GetRohstoffwithID(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr)).GetWSKaufpreis();
                    
                    if (SW.UI.JaNeinFrage.ShowDialogText(textFrage: "Wollt Ihr für " + preis.ToStringGeld() + " in " + SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetGebietsName() + " eine Werkstätte für eine\n" + 
                                                         SW.Dynamisch.GetRohstoffwithID(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr)).GetRohName() + "-Produktion kaufen?") == DialogResult.Yes)
                    {
                        if (SW.Dynamisch.CheckIfenoughGold(preis))
                        {
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(wks_nr, globalAktiveStadt).SetEnabled(true);
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(wks_nr, globalAktiveStadt).SetRohstoffID(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr));
                            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(wks_nr, globalAktiveStadt).SetSkillX(1, SW.Statisch.GetStartLagerraum());
                            UI.TalerAendern(-preis, ref lbl_Taler);

                            // Controls einblenden
                            if (Grafik.GetRohstoffIcons46px().Count >= SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr))
                            {
                                this.Controls["btn_stadt_roh" + wks_nr.ToString()].BackgroundImage = Grafik.GetRohstoffIcons100px()[SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr)];
                                ttRohstoffe.SetToolTip(this.Controls["btn_stadt_roh" + wks_nr.ToString()], SW.Dynamisch.GetRohstoffwithID(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr)).GetRohName());
                            }
                            switchWerkstaetten("btn_stadt_ws" + wks_nr.ToString(), SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(wks_nr));
                            this.Controls["btn_stadt_roh" + wks_nr.ToString()].Visible = true;
                            this.Controls["lbl_stadt_roh" + wks_nr.ToString()].Visible = true;
                            this.Controls["label" + wks_nr.ToString()].Visible = true;
                        }
                    }
                }
                else
                {
                    SW.Dynamisch.BelTextAnzeigen("Ihr benötigt zuerst einen Wohnsitz in dieser Stadt");
                }
            }
        }
        #endregion

        #region StadtRohstoffeAktualisieren
        private void StadtRohstoffeAktualisieren()
        {
            string anzahl;
            int rohid;

            for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
            {
                rohid = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i);
                anzahl = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetStadtRohstoffAnzahl(globalAktiveStadt, rohid).ToString();

                while (anzahl.Length < 6)
                {
                    anzahl = "0" + anzahl;
                }

                anzahl = anzahl.Substring(0, 3) + "." + anzahl.Substring(3, 3);
                this.Controls["lbl_stadt_roh" + i.ToString()].Text = anzahl;
            }
        }
        #endregion

        #region RohstoffAnzahlZubereiten
        private int RohstoffAnzahlZubereiten(string t)
        {
            return Convert.ToInt32(t.Substring(0, 3) + t.Substring(4, 3));
        }
        #endregion

        #region StadtSlotXEinblenden
        private void stadtSlotXEinblenden(int Slot0oder1, bool einblend)
        {
            this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"].Visible = einblend;
            this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"].Visible = einblend;
            this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text1"].Visible = einblend;
            this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text2"].Visible = einblend;
            this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Produkt"].Visible = einblend;
            this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_kosten"].Visible = einblend;
        }
        #endregion

        #region StadtProdTextLaden
        private void StadtProdTextLaden(int Slot0oder1)
        {
            string textges, text1, text3;
            int rohid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetProduktionRohstoff();

            int indexVonRohstoffInStadt = Array.IndexOf(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetRohstoffe(), rohid);
            
            if (!SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(rohid) ||
                !SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(indexVonRohstoffInStadt, globalAktiveStadt).GetEnabled())
            {
                // Der aktuelle Rohstoff ist nicht gültig, selektiere den nächst gültigen

                for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i)) &&
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(i, globalAktiveStadt).GetEnabled())
                    {
                        rohid = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i);
                        break;
                    }
                }
            }

            #region Werte für Input Button setzen
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximalerWert = SW.Statisch.GetMaxArbeiterAnzahl();
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximaleStellen = SW.Statisch.GetMaxArbeiterAnzahl().ToString().Length;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).TausenderTrenner = false;

            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).WertAnzeigen = true;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).NurEinserSchritte = false;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximalerWert = 99;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximaleStellen = 2;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).TausenderTrenner = false;
            #endregion

            textges = SW.Dynamisch.GetRohstoffwithID(rohid).GetProdText();
            text1 = textges.Substring(0, textges.IndexOf(";"));

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetProduktionStaetten() != 1)
            {
                text3 = textges.Substring(textges.IndexOf(".") + 1);
            }
            else
            {
                text3 = textges.Substring(textges.IndexOf(":") + 1, textges.IndexOf(".") - (textges.IndexOf(":") + 1));
            }

            this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Produkt"].Text = text1 + " mit";
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).Wert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetProduktionArbeiter();

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetProduktionArbeiter() != 1)
            {
                this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text1"].Text = "Arbeitern " + textges.Substring(textges.IndexOf(";") + 1, textges.IndexOf(":") - textges.IndexOf(";") - 1);
            }
            else
            {
                this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text1"].Text = "Arbeiter " + textges.Substring(textges.IndexOf(";") + 1, textges.IndexOf(":") - textges.IndexOf(";") - 1);
            }

            this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text2"].Text = text3;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).Wert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetProduktionStaetten();
            int kosten = SW.Dynamisch.BerechneProdKosten(globalAktiveStadt, Slot0oder1);
            this.Controls["lbl_stadt_prod" + Slot0oder1 + "_kosten"].Text = "für " + kosten.ToStringGeld();

            SlotXAusrichten(Slot0oder1);
            stadtSlotXEinblenden(Slot0oder1, true);
        }
        #endregion

        #region StadtVerkTextLaden
        private void StadtVerkTextLaden(int Slot0oder1)
        {
            #region Werte für Input Button setzen
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximalerWert = SW.Statisch.GetMaxAnzahlVonEinemRohstoff();
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximaleStellen = SW.Statisch.GetMaxAnzahlVonEinemRohstoff().ToString().Length;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).TausenderTrenner = true;

            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).WertAnzeigen = false;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).NurEinserSchritte = true;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximalerWert = SW.Statisch.GetMaxStadtID();
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximaleStellen = SW.Statisch.GetMaxStadtID().ToString().Length;
            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).TausenderTrenner = false;
            #endregion

            this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text1"].Text = "Verkauft ";

            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Arbeiter"] as NumericButton).Wert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetVerkaufAnzahl();
            
            this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Produkt"].Text = SW.Dynamisch.GetRohstoffwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetVerkaufRohstoff()).GetRohName();

            (this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).Wert = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetVerkaufStadt();
            this.Controls["btn_stadt_prod" + Slot0oder1.ToString() + "_Werkstaetten"].Text = "in " + SW.Dynamisch.GetStadtwithID(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, Slot0oder1).GetVerkaufStadt()).GetGebietsName();

            this.Controls["lbl_stadt_prod" + Slot0oder1.ToString() + "_text2"].Visible = false;

            this.Controls["lbl_stadt_prod" + Slot0oder1 + "_kosten"].Text = "für " + SW.Dynamisch.BerechneProdKosten(globalAktiveStadt, Slot0oder1).ToStringGeld();
            SlotXAusrichten(Slot0oder1);
        }
        #endregion

        #region SlotXAusrichten
        private void SlotXAusrichten(int slot0oder1)
        {
            //Produzieren
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == 1)
            {
                #region Werte für Input Button setzen
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximalerWert = SW.Statisch.GetMaxArbeiterAnzahl();
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximaleStellen = SW.Statisch.GetMaxArbeiterAnzahl().ToString().Length;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).TausenderTrenner = false;

                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).WertAnzeigen = true;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).NurEinserSchritte = false;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximalerWert = 99;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximaleStellen = 2;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).TausenderTrenner = false;
                #endregion

                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Produkt"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Taetigkeit"].Left + 30;
                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Produkt"].Right;
                this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_text1"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"].Right;
                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"].Left = this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_text1"].Right;
                this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_text2"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"].Right;
                this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_kosten"].Left = this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_text2"].Right;
            }
            //Verkaufen
            else if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == 2 || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == 3)
            {
                #region Werte für Input Button setzen
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximalerWert = SW.Statisch.GetMaxAnzahlVonEinemRohstoff();
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).MaximaleStellen = SW.Statisch.GetMaxAnzahlVonEinemRohstoff().ToString().Length;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).TausenderTrenner = true;

                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).WertAnzeigen = false;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).NurEinserSchritte = true;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximalerWert = SW.Statisch.GetMaxStadtID();
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).MaximaleStellen = SW.Statisch.GetMaxStadtID().ToString().Length;
                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).TausenderTrenner = false;
                #endregion

                this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_text1"].Left = btn_stadt_prod0_Taetigkeit.Left + 30;
                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"].Left = this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_text1"].Right;
                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Produkt"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"].Right;
                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Produkt"].Right;
                this.Controls["lbl_stadt_prod" + slot0oder1.ToString() + "_kosten"].Left = this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"].Right;
            }
        }
        #endregion

        #region StadtelementeAnzeigen
        private void StadtelementeAnzeigen(bool einblenden)
        {
            btn_stadt_Haus.Visible = einblenden;

            btn_stadt_ws1.Visible = einblenden;
            btn_stadt_ws2.Visible = einblenden;
            btn_stadt_ws3.Visible = einblenden;
            btn_stadt_ws4.Visible = einblenden;
            btn_stadt_ws5.Visible = einblenden;
            btn_stadt_ws6.Visible = einblenden;

            btn_stadt_transport.Visible = einblenden;
            btn_stadt_prod0_Taetigkeit.Visible = einblenden;
            btn_stadt_prod1_Taetigkeit.Visible = einblenden;

            if (einblenden == false)
            {
                btn_stadt_roh1.Visible = einblenden;
                btn_stadt_roh2.Visible = einblenden;
                btn_stadt_roh3.Visible = einblenden;
                btn_stadt_roh4.Visible = einblenden;
                btn_stadt_roh5.Visible = einblenden;
                btn_stadt_roh6.Visible = einblenden;

                lbl_stadt_roh1.Visible = einblenden;
                lbl_stadt_roh2.Visible = einblenden;
                lbl_stadt_roh3.Visible = einblenden;
                lbl_stadt_roh4.Visible = einblenden;
                lbl_stadt_roh5.Visible = einblenden;
                lbl_stadt_roh6.Visible = einblenden;

                label1.Visible = einblenden;
                label2.Visible = einblenden;
                label3.Visible = einblenden;
                label4.Visible = einblenden;
                label5.Visible = einblenden;
                label6.Visible = einblenden;
            }

            btn_stadt_prod0_Arbeiter.Visible = einblenden;
            btn_stadt_prod0_Produkt.Visible = einblenden;
            btn_stadt_prod0_Werkstaetten.Visible = einblenden;
            btn_stadt_prod1_Arbeiter.Visible = einblenden;
            btn_stadt_prod1_Produkt.Visible = einblenden;
            btn_stadt_prod1_Werkstaetten.Visible = einblenden;
            lbl_stadt_prod0_kosten.Visible = einblenden;
            lbl_stadt_prod0_text1.Visible = einblenden;
            lbl_stadt_prod0_text2.Visible = einblenden;
            lbl_stadt_prod1_kosten.Visible = einblenden;
            lbl_stadt_prod1_text1.Visible = einblenden;
            lbl_stadt_prod1_text2.Visible = einblenden;
        }
        #endregion

        #region BtnStadtWasTutEr
        private void BtnStadtWasTutEr(bool klick, int prod0oder1)
        {
            int[] prod0 = new int[maxVerschiedeneAuftraege];
            prod0[0] = (int)EnumProduktionsslotAktionsart.KeinAuftrag;
            prod0[1] = (int)EnumProduktionsslotAktionsart.Produzieren;
            prod0[2] = (int)EnumProduktionsslotAktionsart.Verkaufen;
            prod0[3] = (int)EnumProduktionsslotAktionsart.PermanentVerkaufen;
            //prod0[4] = 4; //Holen

            int akt_i;

            //Falls die Methode beim öffnen einer Stadt aufgerufen wird, soll es natürlich nicht weitergeschalten werden
            if (klick)
            {
                akt_i = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, prod0oder1).GetTaetigkeit();
                akt_i++;

                if (akt_i >= maxVerschiedeneAuftraege)
                {
                    akt_i = 0;
                }
            }
            //Hier soll er nur den aktuellen Produktionsslot laden
            else
            {
                akt_i = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, prod0oder1).GetTaetigkeit();
            }


            this.Controls["btn_stadt_prod" + prod0oder1.ToString() + "_Taetigkeit"].Text = ProdZuTextKonv(prod0[akt_i]);
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, prod0oder1).SetTaetigkeit(akt_i);

            switch (akt_i)
            {
                case 0:
                    if (klick == true)
                    {
                        //Verkaufsrohstoff zuruecksetzen
                        int rohid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, prod0oder1).GetVerkaufRohstoff();
                        int verkanz = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, prod0oder1).GetVerkaufAnzahl();
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).VeraenderStadtRohstoffAnzahl(globalAktiveStadt, rohid, verkanz);
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, prod0oder1).SetVerkaufAnzahl(0);
                        StadtRohstoffeAktualisieren();
                    }
                    stadtSlotXEinblenden(prod0oder1, false);
                    break;
                case 1: //Produktion
                    StadtProdTextLaden(prod0oder1);
                    break;
                case 2: //Verkaufen
                    StadtVerkTextLaden(prod0oder1);
                    break;
                case 3: //Permanenter Verkauf
                    StadtVerkTextLaden(prod0oder1);
                    break;
            }
        }
        #endregion

        #region ProdZuTextKonv
        private string ProdZuTextKonv(int i)
        {
            string str_prod = "";
            switch (i)
            {
                case 0:
                    str_prod = "Kein Auftrag";
                    break;
                case 1:
                    str_prod = "Produzieren";
                    break;
                case 2:
                    str_prod = "Verkaufen";
                    break;
                case 3:
                    str_prod = "Permanenter Verkauf";
                    break;
            }
            return str_prod;
        }
        #endregion

        #region prodXProduktClick
        private void prodXProduktClick(int slot0oder1)
        {
            #region Produktion
            //Ist hier der Rohstoff

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Produzieren)
            {
                int akt_roh_id = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetProduktionRohstoff();
                int akt_ws = SW.Dynamisch.GetWerkposInStadtXzuRohIDy(globalAktiveStadt, akt_roh_id);
                int temp_ws = akt_ws;
                bool rohstoffErlaubt = false;

                for (int i = 0; i < SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
                {
                    temp_ws++;

                    if (temp_ws > SW.Statisch.GetMaxWerkstaettenProStadt())
                        temp_ws = 1;

                    // Prüfen, ob der Spieler das Rohstoffrecht oder die Werkstatt zur Produktion für den nächsten Rohstoff besitzt.
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(temp_ws)) &&
                        SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(temp_ws, globalAktiveStadt).GetEnabled())
                    {
                        rohstoffErlaubt = true;
                        break;
                    }
                }

                if (!rohstoffErlaubt || akt_ws == temp_ws)
                    return;
                
                akt_ws = temp_ws;

                int neueRohstoffID = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(akt_ws);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetProduktionRohstoff(neueRohstoffID);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetProduktionStaetten(0);
                BtnStadtWasTutEr(false, slot0oder1);
            }
            #endregion

            #region Verkaufen

            //Ist hier der Rohstoff
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Verkaufen || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.PermanentVerkaufen)
            {
                int akt_rohstoff = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetVerkaufRohstoff();

                //Falls von einem anderen Rohstoff was eingestellt war
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetVerkaufAnzahl() != 0)
                {
                    //Den Rohstoff um die Anzahl erhoehen
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).VeraenderStadtRohstoffAnzahl(globalAktiveStadt, akt_rohstoff, SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetVerkaufAnzahl());
                }

                int akt_ws = SW.Dynamisch.GetWerkposInStadtXzuRohIDy(globalAktiveStadt, akt_rohstoff);
                akt_ws++;

                if (akt_ws > SW.Statisch.GetMaxWerkstaettenProStadt())
                {
                    akt_ws = 1;
                }

                int neueRohID = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(akt_ws);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetVerkaufRohstoff(neueRohID);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetVerkaufAnzahl(0);
                BtnStadtWasTutEr(false, slot0oder1);


                StadtRohstoffeAktualisieren();
            }
            #endregion

            SlotXAusrichten(slot0oder1);
        }
        #endregion

        #region prodXWerkstaettenClick
        private void prodXWerkstaettenClick(int slot0oder1)
        {
            #region Produktion
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Produzieren)
            {
                int rohid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetProduktionRohstoff();

                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(SW.Dynamisch.GetWerkposInStadtXzuRohIDy(globalAktiveStadt, rohid), globalAktiveStadt).GetEnabled() == true)
                {
                    SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetProduktionStaetten((this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).Wert);
                    StadtProdTextLaden(slot0oder1);
                }
                else
                {
                    SW.Dynamisch.BelTextAnzeigen("Ihr besitzt in dieser Stadt keine Werkstätte zur " + SW.Dynamisch.GetRohstoffwithID(rohid).GetRohName() + "-Herstellung");
                }
            }
            #endregion

            #region Verkaufen
            else if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Verkaufen || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.PermanentVerkaufen)
            {
                int i_old = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetVerkaufStadt();
                int i_new = (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"] as NumericButton).Wert;

                //Falls die eigene Stadt eingestellt ist, soll weitergeschalten werden
                if (i_new == globalAktiveStadt)
                {
                    if (i_new > i_old)
                    {
                        i_new++;
                    }
                    else
                    {
                        i_new--;
                    }
                }

                if (i_new >= SW.Statisch.GetMaxStadtID())
                {
                    i_new = SW.Statisch.GetMinStadtID();
                }
                else if (i_new <= SW.Statisch.GetMinStadtID())
                {
                    i_new = SW.Statisch.GetMaxStadtID() - 1; //-1 weil maxStaedte die maxID + 1 speichert
                }

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetVerkaufStadt(i_new);
                this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Werkstaetten"].Text = "in " + SW.Dynamisch.GetStadtwithID(i_new).GetGebietsName();

                StadtVerkTextLaden(slot0oder1);
            }
            #endregion

            this.Controls["lbl_stadt_prod" + slot0oder1 + "_kosten"].Text = "für " + SW.Dynamisch.BerechneProdKosten(globalAktiveStadt, slot0oder1).ToStringGeld();
            SlotXAusrichten(slot0oder1);
        }
        #endregion

        #region RohstoffXverkaufen
        private void RohstoffXverkaufen(int X)
        {
            int roh_id = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(X);
            int akt_anz = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetStadtRohstoffAnzahl(globalAktiveStadt, roh_id);

            //Rohstoff verkaufen
            int verk_anz = akt_anz;
            if (verk_anz > 0)
            {
                SW.Dynamisch.CheckGesetzesVerstossMitRohIDx(roh_id);
            }

            //Verkaufte Anzahl abziehen
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(globalAktiveStadt, roh_id, akt_anz - verk_anz);

            //Aenderung der Rohvorraete der Stadt speichern
            SW.Dynamisch.GetAktHum().ErhoeheEinVerkaeufeInStadtXVonRohstoffIDYUmZ(globalAktiveStadt, roh_id, verk_anz);

            //Geld kassieren
            int preis = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetRohstoffPreisVonIDX(roh_id);
            int gewinn = preis * verk_anz;
            UI.TalerAendern(gewinn, ref lbl_Taler);

            //Einnahmen zum Umsatz hinzuzählen
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheUmsatzInStadtX(gewinn, globalAktiveStadt);

            StadtRohstoffeAktualisieren();
        }
        #endregion

        #region RohstoffEinVerkaufen
        private void RohstoffEinVerkaufen(int btn_nr)
        {
            int i = 1;

            if (mouse_x >= 4 && mouse_x < 90)
            {
                if (mouse_x < 18)
                {
                    i *= 100000;
                }
                else if (mouse_x < 31)
                {
                    i *= 10000;
                }
                else if (mouse_x < 46)
                {
                    i *= 1000;
                }
                else if (mouse_x < 63)
                {
                    i *= 100;
                }
                else if (mouse_x < 77)
                {
                    i *= 10;
                }
            }

            //Plus wenn die Mouse oben ist, sonst Minus
            if (mouse_y >= this.Controls["lbl_stadt_roh" + btn_nr.ToString()].Height / 2)
            {
                i = -i;
            }

            int roh_id = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(btn_nr);
            int akt_anz = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetStadtRohstoffAnzahl(globalAktiveStadt, roh_id);

            //Rohstoff verkaufen
            if (i < 0)
            {
                int verk_anz = i;

                //Überprüfen ob nicht mehr verkauft wird als vorhanden
                if (akt_anz + i < 0)
                {
                    verk_anz = -akt_anz;
                }

                if (verk_anz < 0)
                {
                    SW.Dynamisch.CheckGesetzesVerstossMitRohIDx(roh_id);
                }

                //Verkaufte Anzahl abziehen
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(globalAktiveStadt, roh_id, akt_anz + verk_anz);

                //Aenderung der Rohvorraete der Stadt speichern
                SW.Dynamisch.GetAktHum().ErhoeheEinVerkaeufeInStadtXVonRohstoffIDYUmZ(globalAktiveStadt, roh_id, -verk_anz);

                //Geld kassieren
                int preis = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetRohstoffPreisVonIDX(roh_id);
                int gewinn = preis * (-verk_anz);
                UI.TalerAendern(gewinn, ref lbl_Taler);

                //Einnahmen zum Umsatz hinzuzählen
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).ErhoeheUmsatzInStadtX(gewinn, globalAktiveStadt);
            }
            //Rohstoff einkaufen
            else if (i > 0)
            {
                int eink_anz = i;

                //Ueberpruefen ob nicht zu viel eingekauft wird
                if (akt_anz + i > SW.Statisch.GetMaxAnzahlVonEinemRohstoff())
                {
                    eink_anz = SW.Statisch.GetMaxAnzahlVonEinemRohstoff() - akt_anz;
                }

                // Überprüfen, ob genügend Vorrat in der Stadt vorhanden ist
                if (eink_anz <= SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetRohstoffIDXVorrat(roh_id))
                {
                    // Überprüfen, ob auch genügend Geld vorhanden ist
                    int preis = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetRohstoffPreisVonIDX(roh_id) + SW.Statisch.GetEinkaufspreisZuschlag();
                    if ((eink_anz * preis) < SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetTaler())
                    {
                        //Eingekaufte Anzahl hinzuzaehlen
                        int AnzahlMoeglich = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(globalAktiveStadt, roh_id, akt_anz + eink_anz);

                        if (AnzahlMoeglich < (akt_anz + eink_anz))
                        {
                            if (AnzahlMoeglich != 0)
                            {
                                eink_anz = AnzahlMoeglich;
                                SW.UI.TextAnzeigen.ShowDialog($"Ihr besitzt für diesen Rohstoff nicht genügend Lagerraum. Es konnte nur eine Menge von {AnzahlMoeglich} eingelagert werden.");
                            }
                            else
                            {
                                eink_anz = 0;
                                SW.UI.TextAnzeigen.ShowDialog("Ihr besitzt für diesen Rohstoff keinen ausreichenden Lagerraum.");
                            }
                        }

                        //Aenderung der Rohvorraete der Stadt speichern
                        SW.Dynamisch.GetAktHum().ErhoeheEinVerkaeufeInStadtXVonRohstoffIDYUmZ(globalAktiveStadt, roh_id, -eink_anz);

                        //Geld bezahlen
                        int ausgaben = preis * eink_anz;
                        UI.TalerAendern(-ausgaben, ref lbl_Taler);
                    }
                    else
                    {
                        SW.UI.TextAnzeigen.ShowDialog("Dafür fehlen Euch die Taler.");
                    }
                }
                else
                {
                    SW.UI.TextAnzeigen.ShowDialog("Der Lagerstand in der Stadt reicht nicht aus.");
                }
            }

            StadtRohstoffeAktualisieren();
        }
        #endregion

        #region prodXArbeiterClick
        private void prodXArbeiterClick(int slot0oder1)
        {
            int iAktuellerWert = (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).Wert;

            #region Produktion
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Produzieren)
            {
                //Fuer die Arbeiter
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetProduktionArbeiter(iAktuellerWert);
                StadtProdTextLaden(slot0oder1);
            }
            #endregion

            #region Verkauf
            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.Verkaufen || SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetTaetigkeit() == (int)EnumProduktionsslotAktionsart.PermanentVerkaufen)
            {
                //Fuer die Exportanzahl
                int rohid = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetVerkaufRohstoff();
                int verk_anz_old = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).GetVerkaufAnzahl();
                int vorh_anz = SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetStadtRohstoffAnzahl(globalAktiveStadt, rohid) + verk_anz_old;
                int verk_anz_neu = iAktuellerWert;

                if (verk_anz_neu > vorh_anz)
                {
                    verk_anz_neu = vorh_anz;
                }

                if (verk_anz_neu < 0)
                {
                    verk_anz_neu = 0;
                }

                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetProduktionsslot(globalAktiveStadt, slot0oder1).SetVerkaufAnzahl(verk_anz_neu);
                SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetStadtRohstoffAnzahl(globalAktiveStadt, rohid, vorh_anz - verk_anz_neu);

                (this.Controls["btn_stadt_prod" + slot0oder1.ToString() + "_Arbeiter"] as NumericButton).Wert = verk_anz_neu;

                StadtRohstoffeAktualisieren();
                StadtVerkTextLaden(slot0oder1);
            }
            #endregion

            this.Controls["lbl_stadt_prod" + slot0oder1 + "_kosten"].Text = "für " + SW.Dynamisch.BerechneProdKosten(globalAktiveStadt, slot0oder1).ToStringGeld();
            SlotXAusrichten(slot0oder1);
        }
        #endregion

        #endregion


        #region Handel

        #region VonHandelZuStadtXWechseln
        private void VonHandelZuStadtXWechseln(int id)
        {
            for (int i = SW.Statisch.GetMinStadtID(); i < SW.Statisch.GetMaxStadtID(); i++)
            {
                this.Controls["pictureBox" + i.ToString()].Visible = false;
            }

            globalAktiveStadt = id;
            aktuellePosition = Posi_Stadt;

            lbl_ortdatum.Text = SW.Dynamisch.GetStadtwithID(id).GetGebietsName() + " A.D. " + SW.Dynamisch.GetAktuellesJahr().ToString();
            SpielerDatenAusrichten();

            SpielerInfosEinAusBlenden(true);
            this.BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.Stadt1);

            //Rohstoffbilder laden
            //Werkstättenprofile Bilder laden
            for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
            {
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i)))
                {
                    if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetSpielerHatInStadtXWerkstaettenY(i, globalAktiveStadt).GetEnabled())
                    {
                        switchWerkstaetten("btn_stadt_ws" + (i).ToString(), SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i));
                        if (Grafik.GetRohstoffIcons46px().Count >= SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i))
                        {
                            this.Controls["btn_stadt_roh" + i.ToString()].BackgroundImage = Grafik.GetRohstoffIcons100px()[SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i)];
                            ttRohstoffe.SetToolTip(this.Controls["btn_stadt_roh" + i.ToString()], SW.Dynamisch.GetRohstoffwithID(SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i)).GetRohName());
                        }
                        this.Controls["btn_stadt_roh" + (i).ToString()].Visible = true;
                        this.Controls["lbl_stadt_roh" + i.ToString()].Visible = true;
                        this.Controls["label" + i.ToString()].Visible = true;
                    }
                    else
                    {
                        //switchWerkstaetten("btn_stadt_ws" + (i).ToString(), SW.Dynamisch.getStadtwithID(globalAktiveStadt).getSingleRohstoff(i));
                        this.Controls["btn_stadt_ws" + (i).ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbWS);
                        this.Controls["lbl_stadt_roh" + i.ToString()].Visible = false;
                        this.Controls["label" + i.ToString()].Visible = false;
                    }
                }
                else
                {
                    this.Controls["btn_stadt_ws" + (i).ToString()].BackgroundImage = new Bitmap(Conspiratio.Properties.Resources.SymbNV);

                    this.Controls["btn_stadt_roh" + (i).ToString()].Visible = false;
                    this.Controls["lbl_stadt_roh" + i.ToString()].Visible = false;
                    this.Controls["label" + i.ToString()].Visible = false;
                }

                //Rohstofferechte anwenden
                int roh_id = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i);
                if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetRohstoffrechteX(roh_id) == true)
                {
                    this.Controls["btn_stadt_ws" + i.ToString()].Enabled = true;
                }
                else
                {
                    this.Controls["btn_stadt_ws" + i.ToString()].Enabled = false;
                }
            }

            StadtelementeAnzeigen(true);

            //Rohstoffpreise laden
            for (int i = 1; i <= SW.Statisch.GetMaxWerkstaettenProStadt(); i++)
            {
                int roh_id = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetSingleRohstoff(i);
                this.Controls["label" + i.ToString()].Text = SW.Dynamisch.GetStadtwithID(globalAktiveStadt).GetRohstoffPreisVonIDX(roh_id).ToString();
            }

            StadtRohstoffeAktualisieren();

            //Labels positionieren
            label1.Top = btn_stadt_roh3.Top - label1.Height - 10;
            label2.Top = label1.Top;
            label3.Top = label1.Top;
            label4.Top = label1.Top;
            label5.Top = label1.Top;
            label6.Top = label1.Top;

            label1.Left = btn_stadt_roh1.Left + btn_stadt_roh1.Width / 2 - label1.Width / 2;
            label2.Left = btn_stadt_roh2.Left + btn_stadt_roh2.Width / 2 - label2.Width / 2;
            label3.Left = btn_stadt_roh3.Left + btn_stadt_roh3.Width / 2 - label3.Width / 2;
            label4.Left = btn_stadt_roh4.Left + btn_stadt_roh4.Width / 2 - label4.Width / 2;
            label5.Left = btn_stadt_roh5.Left + btn_stadt_roh5.Width / 2 - label5.Width / 2;
            label6.Left = btn_stadt_roh6.Left + btn_stadt_roh6.Width / 2 - label6.Width / 2;

            //Produktion laden
            BtnStadtWasTutEr(false, 0);
            BtnStadtWasTutEr(false, 1);

            btn_stadt_prod1_Werkstaetten.Focus(); //Damit kein Rand umherum ist
            btn_stadt_prod0_Werkstaetten.Focus();

            HausAnzeigen();
        }
        #endregion

        #endregion


        #region Hauptmenue

        #region SpielBeenden
        private async Task SpielBeenden()
        {
            HauptmenueVerlassen();

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            C_MusikInstanz.RequestStop();

            SpielerInfosEinAusBlenden(false);
            PositionWechseln(Posi_Ende);

            await AufRechtsklickWarten();

            Thread.Sleep(150);  // Verhindert, dass der letzte Rechtsklick ans Betriebssystem gesendet wird
            Application.Exit();  // Verhindert, dass der Prozess evtl. noch offen bleibt und weiter Musik abspielt
            this.Close();
        }
        #endregion

        #region IntroAusfuehren
        private async Task IntroAusfuehren()
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            SpielerInfosEinAusBlenden(false);
            PositionWechseln(Posi_Intro);

            label1.Top = this.Height - label1.Height - 5;
            label1.Text = "(Rechtsklick um fortzufahren)";
            label1.ForeColor = Color.Gold;
            label1.Left = this.Width - label1.Width - 10;
            label1.Visible = true;

            await AufRechtsklickWarten();
            IntroAusfuehrenNachRechtsklick();
        }

        private void IntroAusfuehrenNachRechtsklick()
        {
            var interfaceBindings = new InterfaceBindings();

            SW.Statisch.Initialisieren(interfaceBindings.GetStrafen(), interfaceBindings.GetPrivilegien());

            SW.UI.Initialisieren(interfaceBindings.GetJaNeinFrage(), interfaceBindings.GetTextAnzeigen(), interfaceBindings.GetBeziehungPflegen(), 
                                 interfaceBindings.GetBauwerkStiftenDialog(), interfaceBindings.GetFestGebenDialog(), interfaceBindings.GetPolitischeWeltkarteDialog(),
                                 interfaceBindings.GetTestamentAnzeigenDialog(), interfaceBindings.GetProzentwertFestlegenDialog(), interfaceBindings.GetUntergebeneDialog());

            Grafik.Initialisieren();

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

            #region Markierungen festlegen

            #region Kontor

            kont_handl = NormB(460);
            kont_handr = NormB(918);
            kont_handt = NormH(135);
            kont_handb = NormH(357);

            kont_kircl = NormB(230);
            kont_kircr = NormB(391);
            kont_kirct = NormH(160);
            kont_kircb = NormH(384);

            kont_schrl = NormB(391);
            kont_schrr = NormB(1080);
            kont_schrt = NormH(430);
            kont_schrb = NormH(500);

            kont_hintl = 0;
            kont_hintr = NormB(170);
            kont_hintt = NormH(115);
            kont_hintb = this.Height;

            kont_kampf_l = NormB(960);
            kont_kampf_r = NormB(1180);
            kont_kampf_t = NormH(130);
            kont_kampf_b = NormH(370);

            kont_fenst_l = NormB(1220);
            kont_fenst_r = NormB(1366);
            kont_fenst_t = NormH(100);
            kont_fenst_b = NormH(410);

            #endregion

            #region Hinterzimmer

            hint_spiol = NormB(410);
            hint_spior = NormB(823);
            hint_spiot = NormH(188);
            hint_spiob = NormH(282);

            hint_sabol = NormB(354);
            hint_sabor = NormB(478);
            hint_sabot = NormH(413);
            hint_sabob = NormH(534);

            hint_ermol = NormB(923);
            hint_ermor = NormB(1158);
            hint_ermot = NormH(352);
            hint_ermob = NormH(553);

            hint_erprl = NormB(764);
            hint_erprr = NormB(1150);
            hint_erprt = NormH(583);

            hint_bezil = NormB(0);
            hint_bezir = NormB(280);
            hint_bezit = NormH(367);
            hint_bezib = this.Height;

            hint_anscl = NormB(546);
            hint_anscr = NormB(706);
            hint_ansct = NormH(368);
            hint_anscb = NormH(607);
            #endregion

            #region Schreibstube
            schr_geldl = NormB(706);
            schr_geldr = NormB(941);
            schr_geldt = NormH(435);
            schr_geldb = NormH(707);

            schr_kredl = 53;
            schr_kredr = NormB(411);
            schr_kredt = NormH(500);
            schr_kredb = NormH(682);

            schr_bewel = NormB(0);
            schr_bewer = NormB(290);
            schr_bewet = NormH(320);
            schr_beweb = NormH(483);

            schr_gesel = NormB(1000);
            schr_geser = this.Width;
            schr_geset = NormH(450);
            schr_geseb = NormH(663);

            schr_privl = NormB(425);
            schr_privr = NormB(877);
            schr_privt = NormH(270);
            schr_privb = NormH(422);

            schr_kontl = NormB(941);
            schr_kontr = NormB(1200);
            schr_kontt = NormH(274);
            schr_kontb = NormH(425);
            #endregion

            #region Kirche
            kirc_gangl = NormB(527);
            kirc_gangr = NormB(838);
            kirc_gangt = NormH(343);
            kirc_gangb = this.Height;

            kirc_konvl = NormB(1195);
            kirc_konvr = this.Width;
            kirc_konvt = NormH(284);
            kirc_konvb = NormH(616);

            kirc_austl = 0;
            kirc_austr = NormB(165);
            kirc_austt = NormH(284);
            kirc_austb = NormH(616);

            gang_braul = NormB(603);
            gang_braur = NormB(762);
            gang_braut = NormH(128);
            gang_braub = NormH(288);
            #endregion

            #region Kirchgang
            gang_ablal = 0;
            gang_ablar = NormB(584);
            gang_ablat = NormH(506);
            gang_ablab = this.Height;

            gang_beicl = NormB(903);
            gang_beicr = this.Width;
            gang_beict = NormH(186);
            gang_beicb = this.Height;

            gang_waisenkind_l = NormB(280);
            gang_waisenkind_r = NormB(700);
            gang_waisenkind_t = NormH(110);
            gang_waisenkind_b = NormH(320);

            #endregion

            #region Hauptmenue
            haup_spl = NormB(540);
            haup_spr = NormB(936);
            haup_spt = NormH(255);
            haup_spb = NormH(340);

            haup_netzl = NormB(540);
            haup_netzr = NormB(936);
            haup_netzt = NormH(360);
            haup_netzb = NormH(424);

            haup_optl = NormB(540);
            haup_optr = NormB(936);
            haup_optt = NormH(453);
            haup_optb = NormH(520);

            haup_credl = NormB(540);
            haup_credr = NormB(936);
            haup_credt = NormH(548);
            haup_credb = NormH(617);

            haup_beenl = NormB(540);
            haup_beenr = NormB(936);
            haup_beent = NormH(658);
            haup_beenb = NormH(718);

            #endregion

            #endregion

            #region Controls ausrichten

            #region Stadt
            //Prodtext
            btn_stadt_prod0_Taetigkeit.Top = NormH(590);
            btn_stadt_prod1_Taetigkeit.Top = btn_stadt_prod0_Taetigkeit.Top + NormH(70);
            btn_stadt_prod0_Produkt.Top = btn_stadt_prod0_Taetigkeit.Top + btn_stadt_prod0_Taetigkeit.Height - NormH(5);
            btn_stadt_prod1_Produkt.Top = btn_stadt_prod1_Taetigkeit.Top + btn_stadt_prod0_Taetigkeit.Height - NormH(5);
            btn_stadt_prod0_Arbeiter.Top = btn_stadt_prod0_Produkt.Top;
            btn_stadt_prod0_Werkstaetten.Top = btn_stadt_prod0_Produkt.Top;
            lbl_stadt_prod0_kosten.Top = btn_stadt_prod0_Produkt.Top + btn_stadt_prod0_Produkt.Height / 2 - lbl_stadt_prod0_kosten.Height / 2;
            lbl_stadt_prod0_text1.Top = btn_stadt_prod0_Produkt.Top + btn_stadt_prod0_Produkt.Height / 2 - lbl_stadt_prod0_text1.Height / 2;
            lbl_stadt_prod0_text2.Top = btn_stadt_prod0_Produkt.Top + btn_stadt_prod0_Produkt.Height / 2 - lbl_stadt_prod0_text2.Height / 2;
            btn_stadt_prod1_Arbeiter.Top = btn_stadt_prod1_Produkt.Top;
            lbl_stadt_prod1_text1.Top = btn_stadt_prod1_Produkt.Top + btn_stadt_prod1_Produkt.Height / 2 - lbl_stadt_prod1_text1.Height / 2;
            btn_stadt_prod1_Werkstaetten.Top = btn_stadt_prod1_Produkt.Top;
            lbl_stadt_prod1_text2.Top = btn_stadt_prod1_Produkt.Top + btn_stadt_prod1_Produkt.Height / 2 - lbl_stadt_prod1_text2.Height / 2;
            lbl_stadt_prod1_kosten.Top = btn_stadt_prod1_Produkt.Top + btn_stadt_prod1_Produkt.Height / 2 - lbl_stadt_prod1_kosten.Height / 2;


            btn_stadt_prod0_Taetigkeit.Left = this.Width / 22;
            btn_stadt_prod1_Taetigkeit.Left = btn_stadt_prod0_Taetigkeit.Left;
            btn_stadt_prod0_Produkt.Left = btn_stadt_prod0_Taetigkeit.Left + NormB(30);
            btn_stadt_prod1_Produkt.Left = btn_stadt_prod0_Produkt.Left;



            btn_stadt_ws1.Top = NormH(200);
            btn_stadt_ws2.Top = btn_stadt_ws1.Top;
            btn_stadt_ws3.Top = btn_stadt_ws1.Top;
            btn_stadt_ws4.Top = btn_stadt_ws1.Top;
            btn_stadt_ws5.Top = btn_stadt_ws1.Top;
            btn_stadt_ws6.Top = btn_stadt_ws1.Top;

            btn_stadt_roh1.Top = btn_stadt_roh1.Bottom + NormH(70);
            btn_stadt_roh2.Top = btn_stadt_roh1.Top;
            btn_stadt_roh3.Top = btn_stadt_roh1.Top;
            btn_stadt_roh4.Top = btn_stadt_roh1.Top;
            btn_stadt_roh5.Top = btn_stadt_roh1.Top;
            btn_stadt_roh6.Top = btn_stadt_roh1.Top;

            int diff1 = this.Width - 7 * btn_stadt_roh3.Width;
            int abs1 = diff1 / 8;
            btn_stadt_roh3.Left = this.Width / 2 - btn_stadt_roh3.Width - abs1 / 2;
            btn_stadt_roh4.Left = btn_stadt_roh3.Left + btn_stadt_roh3.Width + abs1;
            btn_stadt_roh5.Left = btn_stadt_roh4.Left + btn_stadt_roh3.Width + abs1;
            btn_stadt_roh6.Left = btn_stadt_roh5.Left + btn_stadt_roh3.Width + abs1;
            btn_stadt_roh2.Left = btn_stadt_roh3.Left - btn_stadt_roh3.Width - abs1;
            btn_stadt_roh1.Left = btn_stadt_roh2.Left - btn_stadt_roh3.Width - abs1;

            btn_stadt_ws1.Left = btn_stadt_roh1.Left;
            btn_stadt_ws2.Left = btn_stadt_roh2.Left;
            btn_stadt_ws3.Left = btn_stadt_roh3.Left;
            btn_stadt_ws4.Left = btn_stadt_roh4.Left;
            btn_stadt_ws5.Left = btn_stadt_roh5.Left;
            btn_stadt_ws6.Left = btn_stadt_roh6.Left;


            lbl_stadt_roh1.Top = btn_stadt_roh3.Top + btn_stadt_roh3.Height + 10;
            lbl_stadt_roh2.Top = lbl_stadt_roh1.Top;
            lbl_stadt_roh3.Top = lbl_stadt_roh1.Top;
            lbl_stadt_roh4.Top = lbl_stadt_roh1.Top;
            lbl_stadt_roh5.Top = lbl_stadt_roh1.Top;
            lbl_stadt_roh6.Top = lbl_stadt_roh1.Top;

            lbl_stadt_roh1.Left = btn_stadt_roh1.Left + btn_stadt_roh1.Width / 2 - lbl_stadt_roh1.Width / 2;
            lbl_stadt_roh2.Left = btn_stadt_roh2.Left + btn_stadt_roh2.Width / 2 - lbl_stadt_roh2.Width / 2;
            lbl_stadt_roh3.Left = btn_stadt_roh3.Left + btn_stadt_roh3.Width / 2 - lbl_stadt_roh3.Width / 2;
            lbl_stadt_roh4.Left = btn_stadt_roh4.Left + btn_stadt_roh4.Width / 2 - lbl_stadt_roh4.Width / 2;
            lbl_stadt_roh5.Left = btn_stadt_roh5.Left + btn_stadt_roh5.Width / 2 - lbl_stadt_roh5.Width / 2;
            lbl_stadt_roh6.Left = btn_stadt_roh6.Left + btn_stadt_roh6.Width / 2 - lbl_stadt_roh6.Width / 2;



            btn_stadt_Haus.Top = this.Height - btn_stadt_Haus.Height - 10;
            btn_stadt_transport.Top = btn_stadt_Haus.Top;

            int absstadt = 10;
            btn_stadt_transport.Left = this.Width - btn_stadt_transport.Width - absstadt;
            btn_stadt_Haus.Left = btn_stadt_transport.Left - btn_stadt_Haus.Width - absstadt;
            #endregion

            #region Buch
            lbl_buch_Produktion.Top = NormH(175);
            lbl_buch_Exporte.Top = lbl_buch_Produktion.Top;

            lbl_buch_Produktion.Left = NormB(100);
            lbl_buch_Exporte.Left = NormB(810);

            //Maße anpassen
            lbl_buch_Produktion.Width = lbl_buch_Produktion.Width * this.Width / 1044;
            lbl_buch_Exporte.Width = lbl_buch_Exporte.Width * this.Width / 1044;

            lbl_buch_Produktion.Height = lbl_buch_Produktion.Height * this.Height / 730;
            lbl_buch_Exporte.Height = lbl_buch_Exporte.Height * this.Height / 730;
            #endregion

            #region Kupplerin
            lbl_kupplerin_text.Top = NormH(510);
            lbl_kupplerin_text.Left = NormB(107);

            lbl_kup_1.Top = lbl_kupplerin_text.Top + lbl_kupplerin_text.Height + 20;
            lbl_kup_2.Top = lbl_kup_1.Top + lbl_kup_1.Height + 10;

            lbl_kup_1.Left = lbl_kupplerin_text.Left + 100;
            lbl_kup_2.Left = lbl_kup_1.Left;

            btn_kup_kupplerin.Top = lbl_kup_1.Top + lbl_kup_1.Height / 2 - btn_kup_kupplerin.Height / 2;
            btn_kup_kupplerin.Left = lbl_kup_1.Left - btn_kup_kupplerin.Width - 15;

            btn_kup_selbst.Top = lbl_kup_2.Top + lbl_kup_2.Height / 2 - btn_kup_selbst.Height / 2;
            btn_kup_selbst.Left = lbl_kup_2.Left - btn_kup_kupplerin.Width - 15;
            #endregion

            #region KartenSpielen


            #endregion

            #region Kreditbuch
            int kred_dist1 = 15;
            int kred_dist2 = 10;
            int kred_heigth1 = this.Height / 4;
            int kred_heigth2 = this.Height / 5 * 3;
            int kred_left1 = this.Width / 12;
            int kred_left2 = (this.Width * 12) / 19;

            //1
            lbl_kreditb_0.Top = kred_heigth1;
            btn_kreditb_tilg_0.Top = lbl_kreditb_0.Top + lbl_kreditb_0.Height + kred_dist1;
            lbl_kreditb_tilg_0.Top = btn_kreditb_tilg_0.Top + btn_kreditb_tilg_0.Height / 2 - lbl_kreditb_tilg_0.Height / 2;

            lbl_kreditb_0.Left = kred_left1;
            btn_kreditb_tilg_0.Left = lbl_kreditb_0.Left;
            lbl_kreditb_tilg_0.Left = lbl_kreditb_0.Left + btn_kreditb_tilg_0.Width + kred_dist2;

            //2
            lbl_kreditb_1.Top = kred_heigth2;
            btn_kreditb_tilg_1.Top = lbl_kreditb_1.Top + lbl_kreditb_1.Height + kred_dist1;
            lbl_kreditb_tilg_1.Top = btn_kreditb_tilg_1.Top + btn_kreditb_tilg_1.Height / 2 - lbl_kreditb_tilg_1.Height / 2;

            lbl_kreditb_1.Left = kred_left1;
            btn_kreditb_tilg_1.Left = lbl_kreditb_0.Left;
            lbl_kreditb_tilg_1.Left = lbl_kreditb_1.Left + btn_kreditb_tilg_1.Width + kred_dist2;

            //3
            lbl_kreditb_2.Top = kred_heigth1;
            btn_kreditb_tilg_2.Top = lbl_kreditb_2.Top + lbl_kreditb_2.Height + kred_dist1;
            lbl_kreditb_tilg_2.Top = btn_kreditb_tilg_2.Top + btn_kreditb_tilg_2.Height / 2 - lbl_kreditb_tilg_2.Height / 2;

            lbl_kreditb_2.Left = kred_left2;
            btn_kreditb_tilg_2.Left = lbl_kreditb_2.Left;
            lbl_kreditb_tilg_2.Left = lbl_kreditb_2.Left + btn_kreditb_tilg_2.Width + kred_dist2;

            //4
            lbl_kreditb_3.Top = kred_heigth2;
            btn_kreditb_tilg_3.Top = lbl_kreditb_3.Top + lbl_kreditb_3.Height + kred_dist1;
            lbl_kreditb_tilg_3.Top = btn_kreditb_tilg_3.Top + btn_kreditb_tilg_3.Height / 2 - lbl_kreditb_tilg_3.Height / 2;

            lbl_kreditb_3.Left = kred_left2;
            btn_kreditb_tilg_3.Left = lbl_kreditb_3.Left;
            lbl_kreditb_tilg_3.Left = lbl_kreditb_3.Left + btn_kreditb_tilg_3.Width + kred_dist2;

            #endregion

            #region Farben ändern
            label1.ForeColor = Grafik.GetStandardSchriftFarbeGold();
            label2.ForeColor = Grafik.GetStandardSchriftFarbeGold();
            label3.ForeColor = Grafik.GetStandardSchriftFarbeGold();
            label4.ForeColor = Grafik.GetStandardSchriftFarbeGold();
            label5.ForeColor = Grafik.GetStandardSchriftFarbeGold();
            label6.ForeColor = Grafik.GetStandardSchriftFarbeGold();
            #endregion

            #endregion

            label1.Visible = false;
            label1.ForeColor = Color.Gold;

            HauptmenueAusfuehren();
        }
        #endregion

        #region CreditsAusfuehren
        private async Task CreditsAusfuehren()
        {
            HauptmenueVerlassen();
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;

            PositionWechseln(Posi_Credits);

            label2.Text = "Programm:\nDerEinzehnte, SirToby";
            label2.Text += "\n\n\n";

            label2.Text += "Grafiken:\nBeetle";
            label2.Text += "\n\n\n";

            label2.Text += "Wiki:\nPommBaer";
            label2.Text += "\n\n\n";

            label2.Text += "Musik:\nJason Shaw (Audionautix.com), Strobotone";
            label2.Text += "\n\n\n";

            label2.Text += "Sounds:\ncsmag, BraveFrog, sarson,\nflorian_reinke, bevibeldesign";
            label2.Text += "\n\n\n";

            label2.Text += "Vector Icons: Vecteezy.com";
            label2.Text += "\n\n";

            //label2.Text += "Tester:\n\nSchweng\nLexx\nHorde\nThomas H Wichtel\nHodg\n";
            //label2.Text += "Nief\nNwee\nGeheimrat\nSeniyad\nSir Toby\n";

            //label2.Text += "und noch viele weitere ;-)";

            int ausrichtungslinie = NormB(180);

            label2.Left = ausrichtungslinie - label1.Width / 2;
            label2.Top = NormH(90);

            label2.Visible = true;

            await AufRechtsklickWarten();

            label2.Visible = false;

            HauptmenueAusfuehren();
        }
        #endregion

        #region HauptmenueAusfuehren
        private void HauptmenueAusfuehren()
        {
            SpE.setIntKurzSpeicher(0);
            SW.Dynamisch.NeuInitialisieren();

            // KI-Spieler erzeugen
            for (int i = 1; i < SW.Statisch.GetMinKIID(); i++)
            {
                SW.Dynamisch.CreateSpielerX(i, 0, "", true, 0, 0);
            }

            SpielerInfosEinAusBlenden(false);
            PositionWechseln(Posi_Hauptmenue);
            label1.Visible = true;
        }
        #endregion

        #region HauptmenueVerlassen
        private void HauptmenueVerlassen()
        {
            label2.Font = Grafik.GetStandardFont(Grafik.GetSchriftgMittel());
            label3.Font = label2.Font;
            label4.Font = label2.Font;
            label5.Font = label2.Font;
            label6.Font = label2.Font;
        }
        #endregion

        #region TutorialHilfefAufrufen
        private void TutorialHilfefAufrufen()
        {
            if (SW.UI.JaNeinFrage.ShowDialogText("Wollt Ihr unsere Hilfeseite in Eurem Standard-Browser öffnen?", "Auf jeden Fall", "Lieber nicht") != DialogResult.Yes)
                return;

            Process.Start("https://github.com/Conspiratio/Conspiratio.Wiki/wiki");
        }
        #endregion

        #region OptionenAusfuehren
        private void OptionenAusfuehren()
        {
            frmEinstellungen oEinstellungen = new frmEinstellungen(ref C_MusikInstanz);
            oEinstellungen.ShowDialog();

            if (Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]))
            {
                C_MusikInstanz.RequestStop();
            }
        }
        #endregion

        #region SpielStarten
        private async Task NeuesSpielStarten()
        {
            Einzelspieler esp = new Einzelspieler();
            esp.ShowDialog();

            // Neues Spiel
            if (SpE.getIntKurzSpeicher() == 2)
            {
                SpE.setIntKurzSpeicher(0);

                if (SW.Dynamisch.GetAktivSpielerAnzahl() != 0)
                {
                    SpielerHinzufuegen sh = new SpielerHinzufuegen(false);

                    if (sh.ShowDialog() == DialogResult.OK)
                    {
                        GameStarted = true;
                        label1.Visible = false;

                        HauptmenueVerlassen();
                        await SpielerDatenLaden(false);
                    }
                }
            }
            // Laden
            else if (SpE.getIntKurzSpeicher() == 1)
            {
                SpE.setIntKurzSpeicher(0);
                await Laden();
            }
            // Letzten Spielstand laden
            else if (SpE.getIntKurzSpeicher() == 3)
            {
                SpE.setIntKurzSpeicher(0);
                await Laden();
            }
        }
        #endregion

        #endregion


        #region Optionen

        #region SpielerHinauswerfen
        private async Task SpielerHinauswerfen()
        {
            bool? result = SW.Dynamisch.AktivenSpielerEntfernen();

            if (result.HasValue)
            {
                if (result.Value)
                {
                    HauptmenueAusfuehren();
                }
                else
                {
                    await SpielerDatenLaden(false);
                }
            }
        }
        #endregion

        #region Speichern und Laden

        #region Speichern
        private bool Speichern(string zielname, bool autosave, bool meldungUnterdruecken = false)
        {
            try
            {
                if (autosave == false)
                {
                    SpE.setBoolKurzSpeicher(false);
                }

                var newPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Conspiratio");
                Directory.CreateDirectory(newPath);
                newPath = Path.Combine(newPath, zielname + ".dat");

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(newPath, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, SW.Dynamisch.Spielstand);
                stream.Close();

                // Letzten Spielstand in den Einstellungen speichern
                Properties.Settings.Default["Letzter_Spielstand"] = zielname;
                Properties.Settings.Default.Save();

                if (autosave == false)
                {
                    if (!meldungUnterdruecken)
                        SW.UI.TextAnzeigen.ShowDialog("Speichervorgang beendet");
                }
                else
                {
                    // Vorvorletzten Autosave löschen
                    try
                    {
                        newPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Conspiratio");
                        Directory.CreateDirectory(newPath);
                        string delName = zielname.Substring(0, zielname.Length - Convert.ToString(SW.Dynamisch.GetAktuellesJahr()).Length) + Convert.ToString((SW.Dynamisch.GetAktuellesJahr() - 2));
                        newPath = Path.Combine(newPath, delName + ".dat");
                        File.Delete(newPath);
                    }
                    catch { }
                }

                return true;
            }
            catch (Exception ex)
            {
                SW.Dynamisch.BelTextAnzeigen($"Fehler beim Speichern des Spielstandes. Meldung: {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Laden
        private async Task Laden()
        {
            string gameName;

            // Vorbereitungen
            if (string.IsNullOrEmpty(SpE.getStringKurzSpeicher()))
            {
                Ladeform lf = new Ladeform();
                lf.ShowDialog();
            }

            if (!string.IsNullOrEmpty(SpE.getStringKurzSpeicher()))
            {
                gameName = SpE.getStringKurzSpeicher();
                SpE.setStringKurzSpeicher("");
                SpE.setBoolKurzSpeicher(false);

                // Gibt es einen serialisierten (neuen) oder nicht serialisierten (alten) Spielstand? Anhand der Dateiendung prüfen:
                var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Conspiratio", gameName + ".dat");

                if (File.Exists(fileName))
                {
                    // Laden: Neuer Weg (deserialisieren)
                    try
                    {
                        IFormatter formatter = new BinaryFormatter
                        {
                            Binder = new ConspiratioDeserializationBinder()
                        };

                        Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        SW.Dynamisch.Spielstand = (Spielstand)formatter.Deserialize(stream);
                        stream.Close();

                        AlteObjekteNachSpeichernAnreichern();  // Wenn Objekte um neue Felder erweitert werden, dann werden diese hier gesetzt oder initialisiert, damit sie beim nächsten speichern korrekt deserialisiert werden 

                        label1.Visible = false;
                        SpielerDatenAktualisieren();

                        SW.Dynamisch.BelTextAnzeigen("Ladevorgang beendet!");
                        HauptmenueVerlassen();

                        GameStarted = true;
                        await SpielerDatenLaden(true);

                        this.Focus();
                        return;
                    }
                    catch (Exception ex)
                    {
                        SW.Dynamisch.BelTextAnzeigen($"Der Spielstand konnte nicht geladen werden, er scheint beschädigt zu sein. Fehler: {ex.Message}");
                        return;
                    }
                }

                #region Laden (alter Weg)

                string Loadtext;

                try
                {
                    #region Vorspiel

                    fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Conspiratio", gameName + ".cons");

                    if (!File.Exists(fileName))
                    {
                        SW.Dynamisch.BelTextAnzeigen($"Es ist kein gültiger Spielstand mit diesem Namen vorhanden: {Path.GetFileName(fileName)}");
                        return;
                    }

                    StreamReader myFile = new StreamReader(fileName.ToString(), System.Text.Encoding.Default);
                    SpE.setStringKurzSpeicher("");
                    Loadtext = myFile.ReadToEnd();
                    myFile.Close();

                    try
                    {
                        //Entschlüsseln
                        Loadtext = Kryptographie.Decrypt(Loadtext);
                    }
                    catch (FormatException) { }  // FileFormat Exception ignorieren, der Spielstand ist dann höchstwahrscheinlich alt und nicht verschlüsselt)

                    //Alte Sachen loeschen... z.B. die von den Gebieten gespeicherten Aemter
                    for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                    {
                        for (int j = 1; j < SW.Statisch.GetMaxAmtStadtID(); j++)
                        {
                            SW.Dynamisch.GetStadtwithID(i).SetAmtXtoY(j, 0);
                        }
                    }
                    for (int i = 1; i < SW.Statisch.GetMaxLandID(); i++)
                    {
                        for (int j = SW.Statisch.GetMaxAmtStadtID(); j < SW.Statisch.GetMaxAmtLandID(); j++)
                        {
                            SW.Dynamisch.GetLandWithID(i).SetAmtXtoY(j, 0);
                        }
                    }
                    for (int i = 1; i < SW.Statisch.GetMaxReichID(); i++)
                    {
                        for (int j = SW.Statisch.GetMaxAmtLandID(); j < SW.Statisch.GetMaxAmtID(); j++)
                        {
                            SW.Dynamisch.GetReichWithID(i).SetAmtXtoY(j, 0);
                        }
                    }


                    //Uebernehmen der Dateien ins Spiel

                    //Zerlegen
                    string[] MegaArray;
                    MegaArray = Loadtext.Split('~');

                    int array_pos = 0;
                    #endregion

                    #region Hauptinformationen
                    SW.Dynamisch.SetAktiverSpieler(Convert.ToInt16(MegaArray[array_pos]));
                    array_pos++;
                    SW.Dynamisch.SetAktivSpielerAnzahl(Convert.ToInt16(MegaArray[array_pos]));
                    array_pos++;
                    SW.Dynamisch.SetAktuellesJahr(Convert.ToInt16(MegaArray[array_pos]));
                    array_pos++;
                    SW.Dynamisch.Cheatmodus = Convert.ToBoolean(Convert.ToInt16(MegaArray[array_pos]));
                    array_pos++;
                    SW.Dynamisch.TodesfaelleAnzeigen = Convert.ToBoolean(Convert.ToInt16(MegaArray[array_pos]));
                    array_pos++;
                    SW.Dynamisch.SpielName = MegaArray[array_pos];
                    array_pos++;
                    SW.Dynamisch.Testmodus = Convert.ToBoolean(Convert.ToInt16(MegaArray[array_pos]));
                    array_pos++;
                    #endregion

                    #region Gesetze
                    for (int i = 0; i < SW.Statisch.GetMaxGesetze(); i++)
                    {
                        SW.Dynamisch.SetGesetzXtoY(i, Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                    }
                    #endregion

                    #region KIs Laden
                    for (int i = SW.Statisch.GetMinKIID(); i < SW.Statisch.GetMaxKIID(); i++)
                    {
                        SW.Dynamisch.GetKIwithID(i).SetName(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetAlter(Convert.ToInt16(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetBosheit(Convert.ToInt16(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetMaennlich(Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos])))); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetVerheiratet(Convert.ToInt16(MegaArray[array_pos])); array_pos++;

                        SW.Dynamisch.GetKIwithID(i).SetVerliebt(Convert.ToInt16(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetNimmtAnWahlTeil(Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos])))); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetTaler(Convert.ToInt32(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetAnsehen(Convert.ToInt32(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetReligion(Convert.ToInt16(MegaArray[array_pos])); array_pos++;

                        SW.Dynamisch.GetKIwithID(i).SetStirbt(Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos])))); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetVerbleibendeJahre(Convert.ToInt16(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetTitel(Convert.ToInt16(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetDeliktpunkte(Convert.ToInt16(MegaArray[array_pos])); array_pos++;
                        SW.Dynamisch.GetKIwithID(i).SetAmtID(Convert.ToInt16(MegaArray[array_pos])); array_pos++;

                        SW.Dynamisch.GetKIwithID(i).SetAmtGebiet(Convert.ToInt16(MegaArray[array_pos])); array_pos++;


                        array_pos++;  //Dieses dient dazu, das der 0-te Arrayeintrag was gespeichert wird, übersprungen wird.
                        for (int j = 1; j < SW.Statisch.GetMaxKIID(); j++)
                        {
                            SW.Dynamisch.GetKIwithID(i).SetBeziehungZuX(j, Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                        }


                        //Dem Amt in dem Gebiet den Spieler zuweisen
                        int amtid = SW.Dynamisch.GetSpWithID(i).GetAmtID();
                        int amtgebiet = SW.Dynamisch.GetSpWithID(i).GetAmtGebiet();

                        if (amtid != 0)
                        {
                            int amtstufe = SW.Dynamisch.GetStufeVonAmtmitIDx(amtid);
                            SW.Dynamisch.GetGebietwithID(amtgebiet, amtstufe).SetAmtXtoY(amtid, i);
                        }
                    }
                    #endregion

                    #region Gebiete laden
                    //Staedte
                    for (int i = 1; i < SW.Statisch.GetMaxStadtID(); i++)
                    {
                        SW.Dynamisch.GetStadtwithID(i).SetReichtumToX(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetStadtwithID(i).SetKriminalitaetAufX(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetStadtwithID(i).SetEinwohnerAufX(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetStadtwithID(i).SetUmsatzsteuerAufX(Convert.ToDouble(MegaArray[array_pos]));
                        array_pos++;

                        for (int j = 1; j < SW.Statisch.GetMaxRohID(); j++)
                        {
                            SW.Dynamisch.GetStadtwithID(i).SetRohstoffVorratWithIDXToY(j, Convert.ToInt32(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetStadtwithID(i).SetRohstoffPreisVonIDXToY(j, Convert.ToInt32(MegaArray[array_pos]));
                            array_pos++;
                        }
                    }
                    #endregion

                    #region Stützpunkte (Zollburgen und Räuberlager)
                    bool bStuetzpunkteGespeichert = false;

                    if (MegaArray[array_pos] == "Stuetzpunkte")
                    {
                        bStuetzpunkteGespeichert = true;
                        array_pos++;
                    }

                    if (bStuetzpunkteGespeichert)
                    {
                        for (int i = 0; i < SW.Dynamisch.GetStuetzpunkte().Length; i++)
                        {
                            // Allgemeine Werte
                            SW.Dynamisch.GetStuetzpunkte()[i].Besitzer = Convert.ToInt16(MegaArray[array_pos]);
                            array_pos++;
                            SW.Dynamisch.GetStuetzpunkte()[i].ZustandInProzent = Convert.ToInt16(MegaArray[array_pos]);
                            array_pos++;
                            SW.Dynamisch.GetStuetzpunkte()[i].SicherheitTarnungInProzent = Convert.ToInt16(MegaArray[array_pos]);
                            array_pos++;
                            SW.Dynamisch.GetStuetzpunkte()[i].Kapazitaet = Convert.ToInt16(MegaArray[array_pos]);
                            array_pos++;
                            SW.Dynamisch.GetStuetzpunkte()[i].MoralTruppeInProzent = Convert.ToInt16(MegaArray[array_pos]);
                            array_pos++;

                            // Spezifische Werte, abhängig von der StuetzpunktArt
                            if (SW.Dynamisch.GetStuetzpunkte()[i].Art == EnumStuetzpunktArt.Zollburg)
                            {
                                SW.Dynamisch.GetZollburgWithIDx(i).Zoll = Convert.ToDouble(MegaArray[array_pos]) / 100;
                                array_pos++;

                                // Truppen
                                SW.Dynamisch.GetZollburgWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollSoeldner), false);
                                array_pos++;
                                SW.Dynamisch.GetZollburgWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollMusketier), false);
                                array_pos++;
                                SW.Dynamisch.GetZollburgWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollKanonier), false);
                                array_pos++;
                                SW.Dynamisch.GetZollburgWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollOffizier), false);
                                array_pos++;

                                // Aktionen
                                if (MegaArray[array_pos] != "null")  // Gibt es eine Aktionsliste für diesen Stützpunkt?
                                {
                                    ZollburgAktion[] aAktionen = new ZollburgAktion[2];

                                    // 1. Aktion
                                    aAktionen[0] = new ZollburgAktion(EnumAktionsartZollburg.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 0, new List<Einheit>())  // mit Dummywerten anlegen
                                    {
                                        Aktionsart = (EnumAktionsartZollburg)Enum.ToObject(typeof(EnumAktionsartZollburg), Convert.ToInt16(MegaArray[array_pos]))
                                    };
                                    array_pos++;
                                    aAktionen[0].ZielLandID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;
                                    aAktionen[0].ZielStuetzpunktID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;

                                    // Truppen
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollSoeldner));
                                    array_pos++;
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollMusketier));
                                    array_pos++;
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollKanonier));
                                    array_pos++;
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollOffizier));
                                    array_pos++;

                                    // 2. Aktion
                                    aAktionen[1] = new ZollburgAktion(EnumAktionsartZollburg.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 1, new List<Einheit>())  // mit Dummywerten anlegen
                                    {
                                        Aktionsart = (EnumAktionsartZollburg)Enum.ToObject(typeof(EnumAktionsartZollburg), Convert.ToInt16(MegaArray[array_pos]))
                                    };
                                    array_pos++;
                                    aAktionen[1].ZielLandID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;
                                    aAktionen[1].ZielStuetzpunktID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;

                                    // Truppen
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollSoeldner));
                                    array_pos++;
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollMusketier));
                                    array_pos++;
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollKanonier));
                                    array_pos++;
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(ZollOffizier));

                                    SW.Dynamisch.GetZollburgWithIDx(i).Aktionen = aAktionen;
                                }
                                else
                                {
                                    SW.Dynamisch.GetZollburgWithIDx(i).Aktionen = new ZollburgAktion[2];  // keine Aktionen vorhanden
                                    SW.Dynamisch.GetZollburgWithIDx(i).Aktionen[0] = new ZollburgAktion(EnumAktionsartZollburg.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 0, new List<Einheit>());   // mit Dummywerten anlegen
                                    SW.Dynamisch.GetZollburgWithIDx(i).Aktionen[1] = new ZollburgAktion(EnumAktionsartZollburg.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 1, new List<Einheit>());   // mit Dummywerten anlegen
                                }
                            }
                            else if (SW.Dynamisch.GetStuetzpunkte()[i].Art == EnumStuetzpunktArt.Raeuberlager)
                            {
                                // Truppen
                                SW.Dynamisch.GetRaeuberlagerWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubRaeuber), false);
                                array_pos++;
                                SW.Dynamisch.GetRaeuberlagerWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubBombenleger), false);
                                array_pos++;
                                SW.Dynamisch.GetRaeuberlagerWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubKanonier), false);
                                array_pos++;
                                SW.Dynamisch.GetRaeuberlagerWithIDx(i).ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubSchuetze), false);
                                array_pos++;

                                // Aktionen
                                if (MegaArray[array_pos] != "null")  // Gibt es eine Aktionsliste für diesen Stützpunkt?
                                {
                                    RaeuberlagerAktion[] aAktionen = new RaeuberlagerAktion[2];

                                    // 1. Aktion
                                    aAktionen[0] = new RaeuberlagerAktion(EnumAktionsartRaeuberlager.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 0, new List<Einheit>())  // mit Dummywerten anlegen
                                    {
                                        Aktionsart = (EnumAktionsartRaeuberlager)Enum.ToObject(typeof(EnumAktionsartRaeuberlager), Convert.ToInt16(MegaArray[array_pos]))
                                    };
                                    array_pos++;
                                    aAktionen[0].ZielLandID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;
                                    aAktionen[0].ZielStuetzpunktID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;

                                    // Truppen
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubRaeuber));
                                    array_pos++;
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubBombenleger));
                                    array_pos++;
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubKanonier));
                                    array_pos++;
                                    aAktionen[0].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubSchuetze));
                                    array_pos++;

                                    // 2. Aktion
                                    aAktionen[1] = new RaeuberlagerAktion(EnumAktionsartRaeuberlager.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 1, new List<Einheit>())  // mit Dummywerten anlegen
                                    {
                                        Aktionsart = (EnumAktionsartRaeuberlager)Enum.ToObject(typeof(EnumAktionsartRaeuberlager), Convert.ToInt16(MegaArray[array_pos]))
                                    };
                                    array_pos++;
                                    aAktionen[1].ZielLandID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;
                                    aAktionen[1].ZielStuetzpunktID = Convert.ToInt16(MegaArray[array_pos]);
                                    array_pos++;

                                    // Truppen
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubRaeuber));
                                    array_pos++;
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubBombenleger));
                                    array_pos++;
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubKanonier));
                                    array_pos++;
                                    aAktionen[1].ErhoeheTruppen(Convert.ToInt16(MegaArray[array_pos]), typeof(RaubSchuetze));

                                    SW.Dynamisch.GetRaeuberlagerWithIDx(i).Aktionen = aAktionen;
                                }
                                else
                                {
                                    SW.Dynamisch.GetRaeuberlagerWithIDx(i).Aktionen = new RaeuberlagerAktion[2];  // keine Aktionen vorhanden
                                    SW.Dynamisch.GetRaeuberlagerWithIDx(i).Aktionen[0] = new RaeuberlagerAktion(EnumAktionsartRaeuberlager.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 0, new List<Einheit>());   // mit Dummywerten anlegen
                                    SW.Dynamisch.GetRaeuberlagerWithIDx(i).Aktionen[1] = new RaeuberlagerAktion(EnumAktionsartRaeuberlager.Kein_Auftrag, 0, 0, SW.Dynamisch.GetStuetzpunkte()[i].ID, 1, new List<Einheit>());   // mit Dummywerten anlegen
                                }
                            }

                            array_pos++;
                        }
                    }
                    else
                    {
                        // Stützpunkte wurden noch nie gespeichert, initialisiere Besitzer neu
                        // Acht KI Spielern jeweils als Besitzer für die Stützpunkte (Zollburgen und Räuberlager) setzen
                        for (int i = 0; i < SW.Dynamisch.GetStuetzpunkte().Length; i++)
                        {
                            SW.Dynamisch.GetStuetzpunkte()[i].BesitzerStuetzpunktZufaelligSetzen(1);
                        }
                    }
                    #endregion

                    #region Wahlen
                    for (int i = 1; i < SW.Statisch.GetMaxAnzahlWahlen(); i++)
                    {
                        SW.Dynamisch.GetWahlX(i).AmtID = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;
                        SW.Dynamisch.GetWahlX(i).GebietID = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;
                        SW.Dynamisch.GetWahlX(i).Stufe = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;

                        for (int t = 0; t < SW.Statisch.GetMaxWahlKandidaten(); t++)
                        {
                            SW.Dynamisch.GetWahlX(i).GetKandidaten()[t] = Convert.ToInt16(MegaArray[array_pos]);
                            array_pos++;
                        }
                        SW.Dynamisch.GetWahlX(i).Waehler1 = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;
                        SW.Dynamisch.GetWahlX(i).Waehler2 = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;
                        SW.Dynamisch.GetWahlX(i).Waehler3 = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;
                    }
                    #endregion

                    #region Spieler laden

                    for (int i = 1; i <= SW.Dynamisch.GetAktivSpielerAnzahl(); i++)
                    {
                        #region Grundsätzliche Daten
                        int j = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;

                        SW.Dynamisch.GetHumWithID(j).SetName(MegaArray[array_pos]);
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetAlter(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetMaennlich(Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos]))));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetVerheiratet(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetTaler(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).WirbtUmSpielerID = Convert.ToInt16(MegaArray[array_pos]);
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetBanner(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetBekamHandelszertifikatX(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetBekamTitelX(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetSpieltKartenGegenSpielerID(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetErmordetKISpielerID(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetErbeSpielerID(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetPermaAnsehen(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetSitztImKerker(Convert.ToBoolean(Convert.ToInt32(MegaArray[array_pos])));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetReligion(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetWirdBereitsVerklagt(Convert.ToBoolean(Convert.ToInt32(MegaArray[array_pos])));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetKlagtSpielerMitIDXAn(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetVergiftetWeinVonKISpielerID(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetVerbleibendeJahre(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetGebeichtet(Convert.ToBoolean(Convert.ToInt32(MegaArray[array_pos])));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetTitel(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetHenkersHand(Convert.ToBoolean(Convert.ToInt32(MegaArray[array_pos])));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(j).SetWahlTeilnahme(Convert.ToInt32(MegaArray[array_pos]));
                        array_pos++;
                        #endregion

                        #region Statistik
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HaDurchschnProfitProVerkWare = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HaentrichteteSteuern = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HaentrichteteZoelle = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HaWarenEingekauft = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HaWarenVerkauft = Convert.ToInt32(MegaArray[array_pos]); array_pos++;

                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiAnschwaerzungen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiBestechungen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiBestechungssumme = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiErfolgreicheErmordungen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiKartenSpielen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiSabotagen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiSpionagen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().HiVersuchteErmordungen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;

                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().KabgelegteBeichten = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().KgekaufteAblaesse = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().KHochzeiten = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().KKonvertierungen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;

                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SgenommeneKredite = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SoAmtseinkommen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().Soangeklagt = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SogebrocheneGesetze = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SoGesamtumsatz = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SogezeugteKinder = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SoHoechstesAmt = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SoSchuldturmaufenthalte = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SWahlenGewonnen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        SW.Dynamisch.GetHumWithID(j).GetSpielerStatistik().SWahlenTeilgenommen = Convert.ToInt32(MegaArray[array_pos]); array_pos++;
                        #endregion

                        #region Umsatz
                        for (int y = 1; y < SW.Statisch.GetMaxStadtID(); y++)
                        {
                            SW.Dynamisch.GetHumWithID(j).SetUmsatzInStadtX(Convert.ToInt32(MegaArray[array_pos]), y);
                            array_pos++;
                        }
                        #endregion

                        #region Amt
                        SW.Dynamisch.GetHumWithID(i).SetAmtID(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        SW.Dynamisch.GetHumWithID(i).SetAmtGebiet(Convert.ToInt16(MegaArray[array_pos]));
                        array_pos++;
                        #endregion

                        #region Dem Amt in dem Gebiet den Spieler zuweisen
                        int amtid = SW.Dynamisch.GetSpWithID(i).GetAmtID();
                        int amtgebiet = SW.Dynamisch.GetSpWithID(i).GetAmtGebiet();

                        if (amtid != 0)
                        {
                            int amtstufe = SW.Dynamisch.GetStufeVonAmtmitIDx(amtid);
                            SW.Dynamisch.GetGebietwithID(amtgebiet, amtstufe).SetAmtXtoY(amtid, i);
                        }
                        #endregion

                        #region Verbrechen
                        for (int z = 0; z < SW.Statisch.GetMaxGesetze(); z++)
                        {
                            SW.Dynamisch.GetHumWithID(j).SetBegingVerbrechenX(z, Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                        }
                        #endregion

                        #region Rohstoffe vom Spieler laden
                        for (int k = 1; k < SW.Statisch.GetMaxStadtID(); k++)
                        {
                            for (int l = 1; l < SW.Statisch.GetMaxRohID(); l++)
                            {
                                SW.Dynamisch.GetHumWithID(j).SetStadtRohstoffAnzahl(k, l, Convert.ToInt32(MegaArray[array_pos]));
                                array_pos++;
                            }
                        }
                        #endregion

                        #region Sabotagen
                        for (int k = 1; k < SW.Statisch.GetMaxKIID(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).GetAktiveSabotage(k).SetKosten(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetAktiveSabotage(k).SetDauer(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                        }
                        #endregion

                        #region Spionagen
                        for (int k = 1; k < SW.Statisch.GetMaxKIID(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).GetAktiveSpionage(k).SetKosten(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetAktiveSpionage(k).SetDauer(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetAktiveSpionage(k).SetDelikte(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetAktiveSpionage(k).SetJahr(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                        }
                        #endregion

                        #region Bestechungen
                        for (int k = 1; k < SW.Statisch.GetMaxKIID(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).SetBestechungVonSpielerMitIDXAufY(k, Convert.ToInt32(MegaArray[array_pos]));
                            array_pos++;
                        }
                        #endregion

                        #region Kredite
                        for (int k = 1; k <= SW.Statisch.GetMaxKredite(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).GetKreditMitID(k).SetDauer(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetKreditMitID(k).SetTaler(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetKreditMitID(k).SetZinsen(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetKreditMitID(k).SetKIID(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                        }
                        #endregion

                        #region Kinder
                        for (int k = 1; k < SW.Statisch.GetMaxKinderAnzahl(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).GetKindX(k).SetAlter(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetKindX(k).SetMaennlich(Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos]))));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetKindX(k).SetName(MegaArray[array_pos]);
                            array_pos++;
                        }
                        #endregion

                        #region Privilegien
                        for (int k = 1; k < SW.Statisch.GetMaxPriv(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).SetPrivilegX(k, Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos]))));
                            array_pos++;
                        }
                        #endregion

                        #region Haeuser
                        bool bErweiterungenGespeichert = false;

                        if (MegaArray[array_pos] == "Haeuser")
                        {
                            bErweiterungenGespeichert = true;
                            array_pos++;
                        }

                        for (int k = 1; k < SW.Statisch.GetMaxStadtID(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).SetHausID(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).SetRestlicheBauzeit(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;
                            SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).SetStadtID(Convert.ToInt16(MegaArray[array_pos]));
                            array_pos++;

                            if (bErweiterungenGespeichert)
                            {
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).ZustandInProzent = Convert.ToInt16(MegaArray[array_pos]);
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).InDiesemJahrRenovieren = Convert.ToBoolean(Convert.ToInt16(MegaArray[array_pos]));
                                array_pos++;

                                if (MegaArray[array_pos] != "null")
                                {
                                    string[] aErweiterungen = MegaArray[array_pos].Split('|');
                                    List<int> lstErweiterungen = new List<int>();

                                    foreach (string sErweiterungID in aErweiterungen)
                                    {
                                        if (sErweiterungID != "")
                                            lstErweiterungen.Add(Convert.ToInt32(sErweiterungID));
                                    }

                                    SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).HausErweiterungen = lstErweiterungen;
                                }
                                else
                                    SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).HausErweiterungen = null;

                                array_pos++;
                            }
                            else
                            {
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).ZustandInProzent = 100;
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).InDiesemJahrRenovieren = false;
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatHausVonStadtAnArraystelle(k).HausErweiterungen = null;
                            }
                        }
                        #endregion

                        #region Werkstaetten
                        for (int k = 1; k < SW.Statisch.GetMaxStadtID(); k++)
                        {
                            for (int l = 1; l < SW.Statisch.GetMaxWerkstaettenProStadt(); l++)
                            {
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatInStadtXWerkstaettenY(l, k).SetRohstoffID(Convert.ToInt16(MegaArray[array_pos]));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetSpielerHatInStadtXWerkstaettenY(l, k).SetEnabled(Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos]))));
                                array_pos++;

                                // Spielstand ergänzen und korrigieren, wenn RohstoffID fehlt
                                if ((SW.Dynamisch.GetHumWithID(j).GetSpielerHatInStadtXWerkstaettenY(l, k).GetEnabled()) && (SW.Dynamisch.GetHumWithID(j).GetSpielerHatInStadtXWerkstaettenY(l, k).GetRohstoffID() == 0))
                                    SW.Dynamisch.GetHumWithID(j).GetSpielerHatInStadtXWerkstaettenY(l, k).SetRohstoffID(SW.Dynamisch.GetStadtwithID(k).GetSingleRohstoff(l));

                                for (int m = 1; m < SW.Statisch.GetMaxAnzahlSkills(); m++)
                                {
                                    SW.Dynamisch.GetHumWithID(j).GetSpielerHatInStadtXWerkstaettenY(l, k).SetSkillX(m, Convert.ToInt16(MegaArray[array_pos]));
                                    array_pos++;
                                }
                            }
                        }
                        #endregion

                        #region Handelszertifikate
                        for (int k = 1; k < SW.Statisch.GetMaxRohID(); k++)
                        {
                            SW.Dynamisch.GetHumWithID(j).SetRohstoffrechteXZuY(k, Convert.ToBoolean(Convert.ToInt16((MegaArray[array_pos]))));
                            array_pos++;
                        }
                        #endregion

                        #region Produktionseinstellungen
                        for (int k = 1; k < SW.Statisch.GetMaxStadtID(); k++)
                        {
                            for (int l = 0; l < SW.Statisch.GetMaxProdSlots(); l++)
                            {
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetTaetigkeit(Convert.ToInt16((MegaArray[array_pos])));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetProduktionArbeiter(Convert.ToInt32((MegaArray[array_pos])));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetProduktionStaetten(Convert.ToInt16((MegaArray[array_pos])));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetProduktionRohstoff(Convert.ToInt16((MegaArray[array_pos])));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetVerkaufAnzahl(Convert.ToInt32((MegaArray[array_pos])));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetVerkaufRohstoff(Convert.ToInt16((MegaArray[array_pos])));
                                array_pos++;
                                SW.Dynamisch.GetHumWithID(j).GetProduktionsslot(k, l).SetVerkaufStadt(Convert.ToInt16((MegaArray[array_pos])));
                                array_pos++;
                            }
                        }
                        #endregion
                    }

                    #endregion

                    #region Nachspiel
                    //prüfen ob alles richtig geladen wurde:
                    if (MegaArray[array_pos] == "Fertig")
                    {
                        if (Speichern(gameName, false, true))
                            File.Delete(fileName);  // Wenn das Speichern im neuen Format erfolgreich war, Spielstand im alten Format löschen

                        label1.Visible = false;
                        SpielerDatenAktualisieren();

                        SW.Dynamisch.BelTextAnzeigen("Ladevorgang beendet!");
                        HauptmenueVerlassen();

                        GameStarted = true;
                        await SpielerDatenLaden(true);

                        this.Focus();
                    }
                    else
                    {
                        SW.Dynamisch.BelTextAnzeigen("Der Spielstand wurde geladen aber er scheint beschädigt zu sein.");
                    }
                    #endregion
                }
                catch
                {
                    SW.Dynamisch.BelTextAnzeigen("Es ist kein gültiger Spielstand mit diesem Namen vorhanden.");
                }
                #endregion
            }
        }

        private void AlteObjekteNachSpeichernAnreichern()
        {
            for (int i = 1; i <= SW.Dynamisch.GetAktivSpielerAnzahl(); i++)
            {
                for (int j = 1; j < SW.Statisch.GetMaxKinderAnzahl(); j++)
                {
                    var kind = SW.Dynamisch.GetHumWithID(i).GetKindX(j);

                    if (!string.IsNullOrEmpty(kind.GetKindName()) && kind.Geburtsjahr <= SW.Statisch.StartJahr)
                        kind.Geburtsjahr = SW.Dynamisch.GetAktuellesJahr() - kind.GetAlter();
                }
            }
        }
        #endregion

        #endregion

        #endregion


        #region Zugnachrichten

        #region Ereignis_Geburt
        private async Task Ereignis_Geburt()
        {
            PositionWechseln(Posi_Kind);

            int randgeschl = SW.Statisch.Rnd.Next(0, 2);
            bool geschl = false;
            if (randgeschl == 0)
            {
                geschl = true;
            }

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich() == true)
            {
                label1.Text = "Eure Frau hat Euch ";
            }
            else
            {
                label1.Text = "Ihr habt ";
            }

            if (geschl == true)
            {
                label1.Text += "einen Sohn ";
            }
            else
            {
                label1.Text += "eine Tochter ";
            }

            if (SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetMaennlich() == true)
            {
                label1.Text += "geschenkt!";
            }
            else
            {
                label1.Text += "geboren!";
            }
            label1.Text += "\nWelchen Namen soll das Kind tragen?";

            txb_namenEingeben.Top = this.Height - txb_namenEingeben.Height - 30;
            txb_namenEingeben.Left = this.Width / 2 - txb_namenEingeben.Width / 2;
            label1.Left = this.Width / 2 - label1.Width / 2;
            label1.Top = txb_namenEingeben.Top - label1.Height - 20;
            txb_namenEingeben.Enabled = true;
            txb_namenEingeben.Focus();

            await AufEnterdruckWarten();

            string nam = txb_namenEingeben.Text;
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetKindX(SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).GetEmptyKindSlot(), geschl, nam);

            label1.Visible = false;
            txb_namenEingeben.Visible = false;
            PositionWechseln(Posi_ZugNachrichten);

            SpielerInfosEinAusBlenden(true);
            txb_namenEingeben.Enabled = false;

            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).SetKindBekommen(false);
        }
        #endregion

        #region Ereignis_SpielerAnkuendigen
        private async Task Ereignis_SpielerAnkuendigen()
        {
            PositionWechseln(Posi_NaechsterSpieler);

            label1.Text = "Nächster Spieler\n\n" + SW.Dynamisch.GetAktHum().GetName() + ",\n" + SW.Dynamisch.GetAktHum().GetAmtNameUndOrt();
            label1.Top = (this.Height * 1) / 7;
            label1.Left = (this.Width - label1.Width) / 2;

            //Sound_Hahn.Play();

            await AufRechtsklickWarten();
            SpielerDatenAusrichten();

            SW.Dynamisch.PrivilegienAktualisieren();
            SW.Dynamisch.GetHumWithID(SW.Dynamisch.GetAktiverSpieler()).AnsehenAktualisieren();

            if (Convert.ToBoolean(Properties.Settings.Default["Tipp_anzeigen"]))
            {
                TippsAnzeigen oTippsAnzeigen = new TippsAnzeigen(true);
                oTippsAnzeigen.ShowDialog();
            }
        }
        #endregion

        #endregion

        #endregion
    }
}
 