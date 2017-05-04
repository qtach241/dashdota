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
            // Initialize ability array.
            for (int i = 0; i < 6; i++)
            {
                Abilities[i] = new Ability();
            }
        }

        public void UpdateCache(GSClient.GameState gs)
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

            for (int i = 0; i < gs.Abilities.Count; i++)
            {
                Abilities[i].Name = gs.Abilities[i].Name;
                Abilities[i].Level = gs.Abilities[i].Level;
                Abilities[i].CanCast = gs.Abilities[i].CanCast;
                Abilities[i].IsPassive = gs.Abilities[i].IsPassive;
                Abilities[i].Cooldown = gs.Abilities[i].Cooldown;
                Abilities[i].IsUltimate = gs.Abilities[i].IsUltimate;
            }
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
        public Ability[] Abilities { get; set; } = new Ability[6];

        public class Ability
        {
            public string Name { get; set; }
            public int Level { get; set; } = 0;
            public bool CanCast { get; set; } = false;
            public bool IsPassive { get; set; } = false;
            public int Cooldown { get; set; } = 0;
            public bool IsUltimate { get; set; } = false;
        }
    }
}
