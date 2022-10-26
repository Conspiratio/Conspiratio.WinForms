using System;
using System.IO;

namespace Conspiratio.Musik
{
    public enum SoundType
    {
        Effect = 0,
        Voice = 1
    }

    /// <summary>
    /// POCO class for a sound to be played in a queue
    /// </summary>
    public class QueuedSound
    {
        /// <summary>
        /// Create a new sound for the queue
        /// </summary>
        /// <param name="sound">Sound as stream (example: from a .wav file from the resources)</param>
        /// <param name="soundType">OPTIONAL: The sound type, it's necessary for getting the default volume from the setting, if the volume was not passed as a parameter)</param>
        /// <param name="volumeInPercent">OPTIONAL: The sound volume in percent (1 - 100 are allowed), it if's not passed, it will be readed from the settings (for the given sound type)</param>
        /// <param name="startMillisecondsEarlier">OPTIONAL: The milliseconds, this sound will be played earlier (while the sound before is still playing). This will only taken into account, if
        /// there is a sound before this sound in the queue.
        /// Example: When the sound before this sound has a length of 6000 milliseconds and we say, 
        /// this sound should start, when the sound before has played 4000 milliseconds, then we have to set 2000 as a value for this parameter.
        /// This sound will then played 2000 milliseconds earlier then normal (normal is just after the sound before is completely played) and will
        /// start at 4000 milliseconds of the sound before this sound in the queue. THis is useful, if the pause between to sounds are to long and we want to shortend it (for voice acting for example).
        /// </param>
        public QueuedSound(Stream sound, SoundType soundType = SoundType.Effect, int volumeInPercent = 0, int startMillisecondsEarlier = 0)
        {
            Sound = sound;
            SoundType = soundType;

            if (volumeInPercent == 0)
            {
                // get the volume from the settings
                switch (soundType)
                {
                    case SoundType.Effect:
                        VolumeInPercent = Convert.ToInt32(Properties.Settings.Default["Sound_Lautstaerke"]); ;
                        break;
                    case SoundType.Voice:
                        VolumeInPercent = 65;  // TODO: get from new setting
                        break;
                }
            }
            else
                VolumeInPercent = volumeInPercent;

            StartMillisecondsEarlier = startMillisecondsEarlier;
        }

        public Stream Sound { get; private set; }
        public int VolumeInPercent { get; private set; }
        public int StartMillisecondsEarlier { get; private set; }
        public SoundType SoundType { get; private set; }
    }
}
