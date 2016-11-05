using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;

namespace TableStorage.Models
{
    public class GameStateEntity : TableEntity
    {
        public GameStateEntity()
        {
        }

        public GameStateEntity(GameState gs)
        {
            PartitionKey = gs.Player.SteamID.ToString();
            RowKey = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString();

            MatchId = gs.Map.MatchId.ToString();
            ClockTime = gs.Map.ClockTime;
            GoldPerMinute = gs.Player.GoldPerMinute;
            ExperiencePerMinute = gs.Player.ExperiencePerMinute;
        }

        public string MatchId { get; set; }
        public int ClockTime { get; set; }
        public int GoldPerMinute { get; set; }
        public int ExperiencePerMinute { get; set; }
        public int Networth { get; set; }
    }
}
