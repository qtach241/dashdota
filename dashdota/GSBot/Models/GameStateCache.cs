using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBot.Models
{
    public class GameStateCache
    {
        public GameStateCache()
        {
        }

        public void UpdateCache(Dota2GSI.GameState gs)
        {
            SessionPackets++;

            ClockTime = gs?.Map?.ClockTime;
            HeroName = gs?.Hero?.Name;

            if (ClockTime != null)
            {
                GameClock = TimeSpan.FromSeconds(gs.Map.ClockTime);
            }

            PullReadyFlag = ((GameClock.Minutes < 30) && IsEven(GameClock.Minutes) && (GameClock.Seconds > 38));
            PullCountdownFlag = ((GameClock.Minutes < 30) && IsEven(GameClock.Minutes) && (GameClock.Seconds > 43));
        }

        private static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public int SessionPackets { get; set; } = 0;
        public string HeroName { get; set; }
        public int? ClockTime { get; set; }
        public TimeSpan GameClock { get; set; }
        public bool PullReadyFlag { get; set; } = false;
        public bool PullCountdownFlag { get; set; } = false;
    }
}
