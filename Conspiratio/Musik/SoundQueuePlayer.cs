using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Timers;

using NAudio.Wave;

namespace Conspiratio.Musik
{
    public class SoundQueuePlayer
    {
        private Timer _timerNextSound;  // TODO: If we can get rid of this, this class can be made static, because then it's stateless :) (maybe a job for future refactoring)

        /// <summary>
        /// Play all Sounds from Queue in the order of being added to the queue (first added, first played and so on) and clear the queue.
        /// </summary>
        /// <param name="soundQueue">The queue which should be played</param>
        public void PlayAllSoundsFromQueue(List<QueuedSound> soundQueue)
        {
            if (soundQueue.Count == 0)
                return;

            PlayNextSoundFromQueue(soundQueue);
        }

        private void PlayNextSoundFromQueue(List<QueuedSound> soundQueue)
        {
            if (soundQueue.Count == 0)
                return;

            var queueSound = soundQueue.First();
            var lengthOfSound = PlaySoundFromQueue(queueSound.Sound, queueSound.VolumeInPercent, soundQueue);

            soundQueue.Remove(queueSound);

            var nextSound = soundQueue.FirstOrDefault();

            if (nextSound == null)
                return;

            if (nextSound.StartMillisecondsEarlier > 0)
            {
                // clean up timer
                if (_timerNextSound != null)
                {
                    _timerNextSound.Stop();
                    _timerNextSound.Dispose();
                }

                _timerNextSound = new Timer(lengthOfSound.TotalMilliseconds - nextSound.StartMillisecondsEarlier);
                _timerNextSound.Elapsed += (object source, ElapsedEventArgs e) => PlayNextSoundFromQueue(soundQueue);
                _timerNextSound.AutoReset = false;
                _timerNextSound.Enabled = true;
            }
        }

        private TimeSpan PlaySoundFromQueue(Stream sound, int volumeInPercent, List<QueuedSound> soundQueue)
        {
            if (sound == null)
                return TimeSpan.Zero;

            IWavePlayer wavePlayerSoundFromQueue = new WaveOutEvent();

            if (soundQueue.Count <= 1)
                wavePlayerSoundFromQueue.PlaybackStopped += WavePlayerSoundFromQueue_LastSound_PlaybackStopped;
            else
                wavePlayerSoundFromQueue.PlaybackStopped += WavePlayerSoundFromQueue_PlaybackStopped;

            WaveStream sourceStreamSounds = new WaveFileReader(sound);
            WaveChannel32 inputStreamSounds = new WaveChannel32(sourceStreamSounds)
            {
                Volume = (float)Convert.ToDouble(volumeInPercent) / 100,
                PadWithZeroes = false
            };

            var lengthOfSound = inputStreamSounds.TotalTime;

            wavePlayerSoundFromQueue.Init(inputStreamSounds);
            wavePlayerSoundFromQueue.Play();

            return lengthOfSound;
        }

        private void WavePlayerSoundFromQueue_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (sender is WaveOutEvent)
            {
                // clean up wave player
                var wavePlayer = sender as WaveOutEvent;

                wavePlayer.Stop();
                wavePlayer.Dispose();
            }
        }

        private void WavePlayerSoundFromQueue_LastSound_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            WavePlayerSoundFromQueue_PlaybackStopped(sender, e);

            // clean up timer
            if (_timerNextSound != null)
            {
                _timerNextSound.Stop();
                _timerNextSound.Dispose();
            }
        }
    }
}
