using System;
using System.IO;

using Conspiratio.Lib.Gameplay.Spielwelt;

using NAudio.Wave;

namespace Conspiratio.Musik
{
    public class MusicAndSoundPlayer
    {
        #region Variablen

        private IWavePlayer _wavePlayer = new WaveOutEvent();
        private WaveStream _sourceStream;
        private WaveChannel32 _inputStream;
        private FadeInOutWithStateSampleProvider _fadeInOut;

        private IWavePlayer _wavePlayerEinschieben = new WaveOutEvent();
        private WaveStream _sourceStreamEinschieben;
        private WaveChannel32 _inputStreamEinschieben;
        private FadeInOutWithStateSampleProvider _fadeInOutEinschieben;

        private IWavePlayer _wavePlayerSounds = null;

        private byte[] Song_Intro;
        private byte[][] Songs_Outro;
        private byte[][] Songs_Standard;
        private byte[][] Songs_HZ;
        private byte[][] Songs_Tod;
        private byte[][] Songs_Orient;
        private byte[][] Songs_Katastrophe;
        private byte[][] Songs_Geburt;
        private byte[][] Songs_Hochzeit;
        private byte[][] Songs_Kirche;
        private byte[][] Songs_Kampf;

        private readonly int _dauerEinblendungStart = 500;
        private readonly int _dauerEinblendungUebergang = 3000;

        private int _musikLautstaerke = Convert.ToInt32(Properties.Settings.Default["Musik_Lautstaerke"]);

        private bool _start;
        private bool _initialisiert = false;

        private string _letzteEinschiebeKategorie = "";

        #endregion

        #region Konstruktor
        public MusicAndSoundPlayer()
        {
            _start = true;

            _wavePlayer.PlaybackStopped += WavePlayer_PlaybackStopped;
            _wavePlayerEinschieben.PlaybackStopped += WavePlayerEinschieben_PlaybackStopped;
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
            Songs_Standard[0] = Properties.Resources.Song_Standard_Strobotone_Medieval_Theme_02;
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

        #region CheckMusik
        public void CheckMusik()
        {
            Initialisieren();

            if (!Convert.ToBoolean(Properties.Settings.Default["Musik_ausschalten"]))
            {
                if (_wavePlayerEinschieben.PlaybackState == PlaybackState.Playing)
                {
                    if (_fadeInOutEinschieben.State == FadeInOutWithStateSampleProvider.FadeState.FullVolume)
                    {
                        if (_fadeInOutEinschieben != null)
                            _fadeInOutEinschieben.BeginFadeOut(_dauerEinblendungUebergang);
                    }
                }

                if (_wavePlayer.PlaybackState == PlaybackState.Playing ||
                    _wavePlayer.PlaybackState == PlaybackState.Paused)
                {
                    if (_fadeInOut.State == FadeInOutWithStateSampleProvider.FadeState.Silence)
                    {
                        if (_fadeInOut != null)
                            _fadeInOut.BeginFadeIn(_dauerEinblendungUebergang);
                    }

                    if(_wavePlayer.PlaybackState == PlaybackState.Paused)
                        _wavePlayer.Play();

                    return;
                }

                if (_start)
                {
                    _sourceStream = new Mp3FileReader(new MemoryStream(Song_Intro));
                    _inputStream = new WaveChannel32(_sourceStream);
                    _fadeInOut = new FadeInOutWithStateSampleProvider(_inputStream.ToSampleProvider());
                    _fadeInOut.FadeFinished += FadeInOut_FadeFinished;

                    _inputStream.Volume = (float)Convert.ToDouble(_musikLautstaerke) / 100;
                    _inputStream.PadWithZeroes = false;

                    _wavePlayer.Init(_fadeInOut);

                    if (_fadeInOut != null)
                        _fadeInOut.BeginFadeIn(_dauerEinblendungStart);

                    _wavePlayer.Play();
                    _start = false;
                }
                else
                {
                    int next = SW.Statisch.Rnd.Next(0, Songs_Standard.Length);

                    _sourceStream = new Mp3FileReader(new MemoryStream(Songs_Standard[next]));
                    _inputStream = new WaveChannel32(_sourceStream);
                    _fadeInOut = new FadeInOutWithStateSampleProvider(_inputStream.ToSampleProvider());
                    _fadeInOut.FadeFinished += FadeInOut_FadeFinished;

                    _inputStream.Volume = (float)Convert.ToDouble(_musikLautstaerke) / 100;
                    _inputStream.PadWithZeroes = false;

                    _wavePlayer.Init(_fadeInOut);

                    if (_fadeInOut != null)
                        _fadeInOut.BeginFadeIn(_dauerEinblendungStart);

                    _wavePlayer.Play();
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
                if (_wavePlayer.PlaybackState == PlaybackState.Playing)
                {
                    if (_fadeInOut.State == FadeInOutWithStateSampleProvider.FadeState.FullVolume)
                    {
                        if (_fadeInOut != null)
                            _fadeInOut.BeginFadeOut(_dauerEinblendungUebergang);
                    }
                }

                if ((_wavePlayerEinschieben.PlaybackState == PlaybackState.Playing || _wavePlayerEinschieben.PlaybackState == PlaybackState.Paused) &&
                    _letzteEinschiebeKategorie == sEinschiebeKategorie)
                {
                    if (_fadeInOutEinschieben.State == FadeInOutWithStateSampleProvider.FadeState.Silence)
                    {
                        if (_fadeInOutEinschieben != null)
                            _fadeInOutEinschieben.BeginFadeIn(_dauerEinblendungUebergang);
                    }

                    if (_wavePlayerEinschieben.PlaybackState == PlaybackState.Paused)
                        _wavePlayerEinschieben.Play();

                    return;
                }
                else if (_wavePlayerEinschieben.PlaybackState == PlaybackState.Playing || _wavePlayerEinschieben.PlaybackState == PlaybackState.Paused)
                {
                    _wavePlayerEinschieben.Stop();
                }

                int next = SW.Statisch.Rnd.Next(0, aSongs.Length);

                _sourceStreamEinschieben = new Mp3FileReader(new MemoryStream(aSongs[next]));
                _inputStreamEinschieben = new WaveChannel32(_sourceStreamEinschieben);
                _fadeInOutEinschieben = new FadeInOutWithStateSampleProvider(_inputStreamEinschieben.ToSampleProvider());
                _fadeInOutEinschieben.FadeFinished += FadeInOutEinschieben_FadeFinished;

                _inputStreamEinschieben.Volume = (float)Convert.ToDouble(_musikLautstaerke) / 100;
                _inputStreamEinschieben.PadWithZeroes = false;

                _wavePlayerEinschieben.Init(_fadeInOutEinschieben);

                if (_fadeInOutEinschieben != null)
                    _fadeInOutEinschieben.BeginFadeIn(_dauerEinblendungStart);

                _wavePlayerEinschieben.Play();
                _letzteEinschiebeKategorie = sEinschiebeKategorie;
            }
        }
        #endregion

        #region PlaySound
        public void PlaySound(Stream sound)
        {
            _wavePlayerSounds = new WaveOutEvent();
            _wavePlayerSounds.PlaybackStopped += WavePlayerSounds_PlaybackStopped;

            WaveStream sourceStreamSounds = new WaveFileReader(sound);
            WaveChannel32 inputStreamSounds = new WaveChannel32(sourceStreamSounds)
            {
                Volume = (float)Convert.ToDouble(Properties.Settings.Default["Sound_Lautstaerke"]) / 100,
                PadWithZeroes = false
            };

            _wavePlayerSounds.Init(inputStreamSounds);
            _wavePlayerSounds.Play();
        }
        #endregion

        #region StopSound
        public void StopSound()
        {
            if (_wavePlayerSounds != null)
            {
                _wavePlayerSounds.Stop();
                _wavePlayerSounds.Dispose();
            }
        }
        #endregion

        #region WavePlayer_PlaybackStopped
        private void WavePlayer_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (_wavePlayerEinschieben.PlaybackState != PlaybackState.Playing)
            {
                // neues Standardlied laden (indirekter Loop)
                CheckMusik();
            }
        }
        #endregion

        #region WavePlayerEinschieben_PlaybackStopped
        private void WavePlayerEinschieben_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (_wavePlayer.PlaybackState != PlaybackState.Playing)
            {
                // neues Einschiebelied laden (indirekter Loop)
                if (_letzteEinschiebeKategorie == "HZ")
                    MusikEinschieben_HZ();
                else if (_letzteEinschiebeKategorie == "Outro")
                    MusikEinschieben_Outro();
            }
        }
        #endregion

        #region WavePlayerSounds_PlaybackStopped
        private void WavePlayerSounds_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (sender is WaveOutEvent)
            {
                var wavePlayer = sender as WaveOutEvent;

                wavePlayer.Stop();
                wavePlayer.Dispose();
            }
        }
        #endregion

        #region FadeInOut_FadeFinished
        private void FadeInOut_FadeFinished(FadeInOutWithStateSampleProvider.FadeState State)
        {
            if (State == FadeInOutWithStateSampleProvider.FadeState.Silence)  // wurde ausgeblendet?
                _wavePlayer.Pause();   // Player anhalten
        }
        #endregion

        #region FadeInOutEinschieben_FadeFinished
        private void FadeInOutEinschieben_FadeFinished(FadeInOutWithStateSampleProvider.FadeState State)
        {
            if (State == FadeInOutWithStateSampleProvider.FadeState.Silence)  // wurde ausgeblendet?
                _wavePlayerEinschieben.Pause();   // Player anhalten
        }
        #endregion

        #region CleanUp
        private void CleanUp()
        {
            if (_wavePlayer != null)
            {
                _wavePlayer.Dispose();
                _wavePlayer = null;
            }

            if (_wavePlayerEinschieben != null)
            {
                _wavePlayerEinschieben.Dispose();
                _wavePlayerEinschieben = null;
            }

            _fadeInOut = null;
            _fadeInOutEinschieben = null;
        }
        #endregion

        #region RequestStop
        public void RequestStop()
        {
            _wavePlayer.Stop();
            _wavePlayerEinschieben.Stop();
            _wavePlayerSounds?.Stop();
        }
        #endregion


        #region Properties
        public int MusikLautstaerke
        {
            get { return _musikLautstaerke; }

            set
            {
                if (_musikLautstaerke >= 0 && _musikLautstaerke <= 100)
                {
                    _musikLautstaerke = value;

                    if (_inputStream != null)
                        _inputStream.Volume = (float)Convert.ToDouble(_musikLautstaerke) / 100;

                    if (_inputStreamEinschieben != null)
                        _inputStreamEinschieben.Volume = (float)Convert.ToDouble(_musikLautstaerke) / 100;
                }
            }
        }
        #endregion
    }
}