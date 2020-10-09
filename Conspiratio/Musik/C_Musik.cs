using System;
using System.IO;
using Conspiratio.Lib.Gameplay.Spielwelt;
using Conspiratio.Musik;
using NAudio.Wave;

namespace Conspiratio
{
    public class C_Musik
    {
        #region Variablen

        private IWavePlayer wavePlayer = new WaveOutEvent();
        private WaveStream sourceStream;
        private WaveChannel32 inputStream;
        private FadeInOutWithStateSampleProvider fadeInOut;

        private IWavePlayer wavePlayerEinschieben = new WaveOutEvent();
        private WaveStream sourceStreamEinschieben;
        private WaveChannel32 inputStreamEinschieben;
        private FadeInOutWithStateSampleProvider fadeInOutEinschieben;

        private IWavePlayer wavePlayerSounds = null;

        byte[] Song_Intro;
        byte[][] Songs_Outro;
        byte[][] Songs_Standard;
        byte[][] Songs_HZ;
        byte[][] Songs_Tod;
        byte[][] Songs_Orient;
        byte[][] Songs_Katastrophe;
        byte[][] Songs_Geburt;
        byte[][] Songs_Hochzeit;
        byte[][] Songs_Kirche;
        byte[][] Songs_Kampf;

        private int iDauerEinblendungStart = 500;
        private int iDauerEinblendungUebergang = 3000;

        private int iMusikLautstaerke = Convert.ToInt32(Properties.Settings.Default["Musik_Lautstaerke"]);
        private int iSoundLautstaerke = Convert.ToInt32(Properties.Settings.Default["Sound_Lautstaerke"]);

        private bool start;
        private bool _initialisiert = false;

        private string sLetzteEinschiebeKategorie = "";

        #endregion

        #region Konstruktor
        public C_Musik()
        {
            start = true;

            wavePlayer.PlaybackStopped += wavePlayer_PlaybackStopped;
            wavePlayerEinschieben.PlaybackStopped += wavePlayerEinschieben_PlaybackStopped;
        }
        #endregion


        #region Initialisieren
        private void Initialisieren()
        {
            if (_initialisiert)
                return;

            Song_Intro = Properties.Resources.Song_Intro_BigHornsIntro2;

            Songs_Outro = new byte[1][];
            Songs_Outro[0] = Properties.Resources.Song_Outro_PartingGlass;

            Songs_Standard = new byte[11][];
            Songs_Standard[0] = Properties.Resources.Song_Standard_Assasins;
            Songs_Standard[1] = Properties.Resources.Song_Standard_ATallShip;
            Songs_Standard[2] = Properties.Resources.Song_Standard_LegendsOfTheRiver;
            Songs_Standard[3] = Properties.Resources.Song_Standard_Renaissance;
            Songs_Standard[4] = Properties.Resources.Song_Standard_SundaysChild;
            Songs_Standard[5] = Properties.Resources.Song_Standard_TheMaster;
            Songs_Standard[6] = Properties.Resources.Song_Standard_TheMightyKingdom;
            Songs_Standard[7] = Properties.Resources.Song_Standard_TriumphantReturn;
            Songs_Standard[8] = Properties.Resources.Song_Standard_TroubledBridges;
            Songs_Standard[9] = Properties.Resources.Song_Standard_TurkishDance;
            Songs_Standard[10] = Properties.Resources.Song_Standard_WhatChildIsThis;

            Songs_HZ = new byte[3][];
            Songs_HZ[0] = Properties.Resources.Song_HZ_TemptingFate;
            Songs_HZ[1] = Properties.Resources.Song_HZ_TheDeadlyYear;
            Songs_HZ[2] = Properties.Resources.Song_HZ_TheTalk;

            Songs_Tod = new byte[1][];
            Songs_Tod[0] = Properties.Resources.Song_Tod_TheBigDecision;

            Songs_Orient = new byte[3][];
            Songs_Orient[0] = Properties.Resources.Song_Orient_EgyptianCrawl;
            Songs_Orient[1] = Properties.Resources.Song_Orient_TemptationMarch;
            Songs_Orient[2] = Properties.Resources.Song_Orient_WheelOfKarma;

            Songs_Katastrophe = new byte[2][];
            Songs_Katastrophe[0] = Properties.Resources.Song_Katastrophe_PendulumWaltz;
            Songs_Katastrophe[1] = Properties.Resources.Song_Katastrophe_RoadToKilcoo;

            Songs_Geburt = new byte[1][];
            Songs_Geburt[0] = Properties.Resources.Song_Geburt_Noel;

            Songs_Hochzeit = new byte[1][];
            Songs_Hochzeit[0] = Properties.Resources.Song_Hochzeit_30SecondClassical;

            Songs_Kirche = new byte[1][];
            Songs_Kirche[0] = Properties.Resources.Song_Kirche_TheAngelsWeep;

            Songs_Kampf = new byte[7][];
            Songs_Kampf[0] = Properties.Resources.Song_Kampf_EnemyShips;
            Songs_Kampf[1] = Properties.Resources.Song_Kampf_EpicTVTheme;
            Songs_Kampf[2] = Properties.Resources.Song_Kampf_HeroInPeril;
            Songs_Kampf[3] = Properties.Resources.Song_Kampf_HighTension;
            Songs_Kampf[4] = Properties.Resources.Song_Kampf_NightRunner;
            Songs_Kampf[5] = Properties.Resources.Song_Kampf_StalkingPrey;
            Songs_Kampf[6] = Properties.Resources.Song_Kampf_WarfareBed;

            // Evtl. andere Kampfsongs, passen aber nicht für den aktuellen Überfall
            // Songs_Kampf_Sieg[0] = Properties.Resources.Song_Kampf_ImperialMorning;
            // Songs_Kampf_Vorbereitung[0] = Properties.Resources.Song_Kampf_RememberTheHeroes;

            _initialisiert = true;
        }
        #endregion

        #region checkMusik
        public void checkMusik()
        {
            Initialisieren();

            if (!Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]))
            {
                if (wavePlayerEinschieben.PlaybackState == PlaybackState.Playing)
                {
                    if (fadeInOutEinschieben.State == FadeInOutWithStateSampleProvider.FadeState.FullVolume)
                    {
                        if (fadeInOutEinschieben != null)
                            fadeInOutEinschieben.BeginFadeOut(iDauerEinblendungUebergang);
                    }
                }

                if (wavePlayer.PlaybackState == PlaybackState.Playing ||
                    wavePlayer.PlaybackState == PlaybackState.Paused)
                {
                    if (fadeInOut.State == FadeInOutWithStateSampleProvider.FadeState.Silence)
                    {
                        if (fadeInOut != null)
                            fadeInOut.BeginFadeIn(iDauerEinblendungUebergang);
                    }

                    if(wavePlayer.PlaybackState == PlaybackState.Paused)
                        wavePlayer.Play();

                    return;
                }

                if (start)
                {
                    sourceStream = new Mp3FileReader(new MemoryStream(Song_Intro));
                    inputStream = new WaveChannel32(sourceStream);
                    fadeInOut = new FadeInOutWithStateSampleProvider(inputStream.ToSampleProvider());
                    fadeInOut.FadeFinished += fadeInOut_FadeFinished;

                    inputStream.Volume = (float)Convert.ToDouble(iMusikLautstaerke) / 100;
                    inputStream.PadWithZeroes = false;

                    wavePlayer.Init(fadeInOut);

                    if (fadeInOut != null)
                        fadeInOut.BeginFadeIn(iDauerEinblendungStart);

                    wavePlayer.Play();
                    start = false;
                }
                else
                {
                    int next = SW.Statisch.Rnd.Next(0, Songs_Standard.Length);

                    sourceStream = new Mp3FileReader(new MemoryStream(Songs_Standard[next]));
                    inputStream = new WaveChannel32(sourceStream);
                    fadeInOut = new FadeInOutWithStateSampleProvider(inputStream.ToSampleProvider());
                    fadeInOut.FadeFinished += fadeInOut_FadeFinished;

                    inputStream.Volume = (float)Convert.ToDouble(iMusikLautstaerke) / 100;
                    inputStream.PadWithZeroes = false;

                    wavePlayer.Init(fadeInOut);

                    if (fadeInOut != null)
                        fadeInOut.BeginFadeIn(iDauerEinblendungStart);

                    wavePlayer.Play();
                }
            }
        }
        #endregion

        #region MusikEinschieben_ Funktionen
        public void MusikEinschieben_HZ()
        {
            MusikEinschieben(Songs_HZ, "HZ");
        }

        public void MusikEinschieben_Tod()
        {
            MusikEinschieben(Songs_Tod, "Tod");
        }

        public void MusikEinschieben_Outro()
        {
            MusikEinschieben(Songs_Outro, "Outro");
        }

        public void MusikEinschieben_Orient()
        {
            MusikEinschieben(Songs_Orient, "Orient");
        }

        public void MusikEinschieben_Katastrophe()
        {
            MusikEinschieben(Songs_Katastrophe, "Katastrophe");
        }

        public void MusikEinschieben_Geburt()
        {
            MusikEinschieben(Songs_Geburt, "Geburt");
        }

        public void MusikEinschieben_Hochzeit()
        {
            MusikEinschieben(Songs_Hochzeit, "Hochzeit");
        }

        public void MusikEinschieben_Kirche()
        {
            MusikEinschieben(Songs_Kirche, "Kirche");
        }

        public void MusikEinschieben_Kampf()
        {
            MusikEinschieben(Songs_Kampf, "Kampf");
        }
        #endregion

        #region MusikEinschieben
        private void MusikEinschieben(byte[][] aSongs, string sEinschiebeKategorie)
        {
            Initialisieren();

            if (!Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]))
            {
                if (wavePlayer.PlaybackState == PlaybackState.Playing)
                {
                    if (fadeInOut.State == FadeInOutWithStateSampleProvider.FadeState.FullVolume)
                    {
                        if (fadeInOut != null)
                            fadeInOut.BeginFadeOut(iDauerEinblendungUebergang);
                    }
                }

                if ((wavePlayerEinschieben.PlaybackState == PlaybackState.Playing || wavePlayerEinschieben.PlaybackState == PlaybackState.Paused) &&
                    sLetzteEinschiebeKategorie == sEinschiebeKategorie)
                {
                    if (fadeInOutEinschieben.State == FadeInOutWithStateSampleProvider.FadeState.Silence)
                    {
                        if (fadeInOutEinschieben != null)
                            fadeInOutEinschieben.BeginFadeIn(iDauerEinblendungUebergang);
                    }

                    if (wavePlayerEinschieben.PlaybackState == PlaybackState.Paused)
                        wavePlayerEinschieben.Play();

                    return;
                }
                else if (wavePlayerEinschieben.PlaybackState == PlaybackState.Playing || wavePlayerEinschieben.PlaybackState == PlaybackState.Paused)
                {
                    wavePlayerEinschieben.Stop();
                }

                int next = SW.Statisch.Rnd.Next(0, aSongs.Length);

                sourceStreamEinschieben = new Mp3FileReader(new MemoryStream(aSongs[next]));
                inputStreamEinschieben = new WaveChannel32(sourceStreamEinschieben);
                fadeInOutEinschieben = new FadeInOutWithStateSampleProvider(inputStreamEinschieben.ToSampleProvider());
                fadeInOutEinschieben.FadeFinished += fadeInOutEinschieben_FadeFinished;

                inputStreamEinschieben.Volume = (float)Convert.ToDouble(iMusikLautstaerke) / 100;
                inputStreamEinschieben.PadWithZeroes = false;

                wavePlayerEinschieben.Init(fadeInOutEinschieben);

                if (fadeInOutEinschieben != null)
                    fadeInOutEinschieben.BeginFadeIn(iDauerEinblendungStart);

                wavePlayerEinschieben.Play();
                sLetzteEinschiebeKategorie = sEinschiebeKategorie;
            }
        }
        #endregion

        #region PlaySound
        public void PlaySound(Stream Sound)
        {
            if (Sound == null)
                return;

            wavePlayerSounds = new WaveOutEvent();
            wavePlayerSounds.PlaybackStopped += wavePlayerSounds_PlaybackStopped;

            WaveStream sourceStreamSounds = new WaveFileReader(Sound);
            WaveChannel32 inputStreamSounds = new WaveChannel32(sourceStreamSounds);

            inputStreamSounds.Volume = (float)Convert.ToDouble(iSoundLautstaerke) / 100;
            inputStreamSounds.PadWithZeroes = false;

            wavePlayerSounds.Init(inputStreamSounds);
            wavePlayerSounds.Play();
        }
        #endregion

        #region StopSound
        public void StopSound()
        {
            if (wavePlayerSounds != null)
            {
                wavePlayerSounds.Stop();
                wavePlayerSounds.Dispose();
                wavePlayerSounds = null;
            }
        }
        #endregion

        #region wavePlayer_PlaybackStopped
        private void wavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (wavePlayerEinschieben.PlaybackState != PlaybackState.Playing)
            {
                // neues Standardlied laden (indirekter Loop)
                checkMusik();
            }
        }
        #endregion

        #region wavePlayerEinschieben_PlaybackStopped
        private void wavePlayerEinschieben_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (wavePlayer.PlaybackState != PlaybackState.Playing)
            {
                // neues Einschiebelied laden (indirekter Loop)
                if (sLetzteEinschiebeKategorie == "HZ")
                    MusikEinschieben_HZ();
                else if (sLetzteEinschiebeKategorie == "Outro")
                    MusikEinschieben_Outro();
            }
        }
        #endregion

        #region wavePlayerSounds_PlaybackStopped
        private void wavePlayerSounds_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (wavePlayerSounds != null)
            {
                wavePlayerSounds.Dispose();
                wavePlayerSounds = null;
            }
        }
        #endregion

        #region fadeInOut_FadeFinished
        private void fadeInOut_FadeFinished(FadeInOutWithStateSampleProvider.FadeState State)
        {
            if (State == FadeInOutWithStateSampleProvider.FadeState.Silence)  // wurde ausgeblendet?
                wavePlayer.Pause();   // Player anhalten
        }
        #endregion

        #region fadeInOutEinschieben_FadeFinished
        private void fadeInOutEinschieben_FadeFinished(FadeInOutWithStateSampleProvider.FadeState State)
        {
            if (State == FadeInOutWithStateSampleProvider.FadeState.Silence)  // wurde ausgeblendet?
                wavePlayerEinschieben.Pause();   // Player anhalten
        }
        #endregion

        #region CleanUp
        private void CleanUp()
        {
            if (wavePlayer != null)
            {
                wavePlayer.Dispose();
                wavePlayer = null;
            }

            if (wavePlayerEinschieben != null)
            {
                wavePlayerEinschieben.Dispose();
                wavePlayerEinschieben = null;
            }

            fadeInOut = null;
            fadeInOutEinschieben = null;
        }
        #endregion

        #region RequestStop
        public void RequestStop()
        {
            wavePlayer.Stop();
            wavePlayerEinschieben.Stop();
            wavePlayerSounds?.Stop();
        }
        #endregion


        #region Properties

        public int MusikLautstaerke
        {
            get { return iMusikLautstaerke; }

            set
            {
                if (iMusikLautstaerke >= 0 && iMusikLautstaerke <= 100)
                {
                    iMusikLautstaerke = value;

                    if (inputStream != null)
                        inputStream.Volume = (float)Convert.ToDouble(iMusikLautstaerke) / 100;

                    if (inputStreamEinschieben != null)
                        inputStreamEinschieben.Volume = (float)Convert.ToDouble(iMusikLautstaerke) / 100;
                }
            }
        }

        public int SoundLautstaerke
        {
            get { return iSoundLautstaerke; }

            set
            {
                if (iSoundLautstaerke >= 0 && iSoundLautstaerke <= 100)
                    iSoundLautstaerke = value;
            }
        }
        #endregion
    }
}