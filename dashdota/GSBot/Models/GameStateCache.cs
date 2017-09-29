using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBot.Models
{
    public class GameStateCache
    {
        private readonly int chunkDamageThreshold = 10;

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
            PacketsSinceLastChunked++;

            ClockTime = gs?.Map?.ClockTime;
            HeroName = gs?.Hero?.Name;

            if (ClockTime != null)
            {
                GameClock = TimeSpan.FromSeconds(gs.Map.ClockTime);
            }

            for (int i = 0; i < gs.Abilities.Count; i++)
            {
                Abilities[i].Name = gs.Abilities[i].Name;
                Abilities[i].Level = gs.Abilities[i].Level;
                Abilities[i].CanCast = gs.Abilities[i].CanCast;
                Abilities[i].IsPassive = gs.Abilities[i].IsPassive;
                Abilities[i].Cooldown = gs.Abilities[i].Cooldown;
                Abilities[i].IsUltimate = gs.Abilities[i].IsUltimate;
            }

            // If new health is less than 500, start keeping track of damage taken.
            LastDamageTaken = gs.Hero.Health < 500 ? (LastHealth - gs.Hero.Health) : 0;

            if (LastDamageTaken > chunkDamageThreshold)
            {
                //LastChunkDamageTaken = LastDamageTaken;
                LastChunkDamageTaken = gs.Hero.Health > 2 ? LastDamageTaken : 0;
                PacketsSinceLastChunked = 0;
            }

            HasArmlet = gs.Items.GetInventoryAt(3).Name == "item_armlet";

            ArmletToggleIsAble = HasArmlet && (gs.Items.GetInventoryAt(3).CanCast == true) && gs.Hero.IsAlive && !(gs.Hero.IsStunned || gs.Hero.IsHexed || gs.Hero.IsMuted);

            ArmletToggleFlag = ((gs.Hero.Health < LastChunkDamageTaken) || (gs.Hero.Health < 100 && PacketsSinceLastChunked == 0)) || gs.Hero.Health <= 2;

            LastHealth = gs.Hero.Health;

            /* Update Flags */
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
        public bool HasArmlet { get; set; } = false;
        public bool ArmletToggleIsAble { get; set; } = false;
        public bool ArmletToggleFlag { get; set; } = false;
        public bool WasHit { get; set; } = false;
        public int PacketsSinceLastChunked { get; set; }
        public Ability[] Abilities { get; set; } = new Ability[6];
        public int LastHealth { get; set; }
        public int LastDamageTaken { get; set; }
        public int LastChunkDamageTaken { get; set; }

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
