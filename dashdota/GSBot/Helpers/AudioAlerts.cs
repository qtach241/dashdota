using GSBot.Models;
using System.IO;

namespace GSBot.Helpers
{
    public class AudioAlerts
    {
        static string soundsDir = Directory
            .GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Sounds/";

        /// <summary>
        /// Plays a sound to alert player to stack/pull camps soon.
        /// </summary>
        /// <param name="state"></param>
        public static void StackCamps(MasterState state)
        {
            if (!state.sPullReadyFlag && state.PullReadyFlag)
            {
                using (System.Media.SoundPlayer player = new System.Media
                    .SoundPlayer(soundsDir + "jensen_ready.wav"))
                {
                    player.Play();
                }
            }

            if (!state.sPullCountdownFlag && state.PullCountdownFlag)
            {
                using (System.Media.SoundPlayer player = new System.Media
                    .SoundPlayer(soundsDir + "jensen_countdown.wav"))
                {
                    player.Play();
                }
            }

            state.sPullReadyFlag = state.PullReadyFlag;
            state.sPullCountdownFlag = state.PullCountdownFlag;
        }

        /// <summary>
        /// Plays a sound to alert player when midas is off cooldown.
        /// </summary>
        /// <param name="state"></param>
        public static void MidasReady(MasterState state)
        {

        }

        /// <summary>
        /// Plays a sound to alert player that tree heal is off cooldown. Heal a tower!
        /// </summary>
        /// <param name="state"></param>
        public static void LivingArmorReady(MasterState state)
        {
            if (state.Abilities[2].Cooldown == 0)
            {
                // Alert Living Armor is off cooldown
            }
        }
    }
}
