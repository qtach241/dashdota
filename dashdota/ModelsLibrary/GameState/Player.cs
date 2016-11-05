using Newtonsoft.Json;

namespace ModelsLibrary
{

    public enum PlayerActivity
    {
        Undefined,
        Menu,
        Playing
    }

    /// <summary>
    /// Structure containing information about local player.
    /// </summary>
    public class Player
    {
        [JsonProperty(PropertyName = "steamid")]
        public string SteamID { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "activity")]
        public PlayerActivity Activity { get; set; }
        [JsonProperty(PropertyName = "kills")]
        public int Kills { get; set; }
        [JsonProperty(PropertyName = "deaths")]
        public int Deaths { get; set; }
        [JsonProperty(PropertyName = "assists")]
        public int Assists { get; set; }
        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }
        [JsonProperty(PropertyName = "denies")]
        public int Denies { get; set; }
        [JsonProperty(PropertyName = "kill_streak")]
        public int KillStreak { get; set; }
        [JsonProperty(PropertyName = "team_name")]
        public PlayerTeam Team { get; set; }
        [JsonProperty(PropertyName = "gold")]
        public int Gold { get; set; }
        [JsonProperty(PropertyName = "gold_reliable")]
        public int GoldReliable { get; set; }
        [JsonProperty(PropertyName = "gold_unreliable")]
        public int GoldUnreliable { get; set; }
        [JsonProperty(PropertyName = "gpm")]
        public int GoldPerMinute { get; set; }
        [JsonProperty(PropertyName = "xpm")]
        public int ExperiencePerMinute { get; set; }
    }
}
