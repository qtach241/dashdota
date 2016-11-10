using Newtonsoft.Json;

namespace ModelsLibrary
{
    public enum DOTA_GameState
    {
        Undefined,
        DOTA_GAMERULES_STATE_DISCONNECT,
        DOTA_GAMERULES_STATE_GAME_IN_PROGRESS,
        DOTA_GAMERULES_STATE_HERO_SELECTION,
        DOTA_GAMERULES_STATE_INIT,
        DOTA_GAMERULES_STATE_LAST,
        DOTA_GAMERULES_STATE_POST_GAME,
        DOTA_GAMERULES_STATE_PRE_GAME,
        DOTA_GAMERULES_STATE_STRATEGY_TIME,
        DOTA_GAMERULES_STATE_WAIT_FOR_PLAYERS_TO_LOAD,
        DOTA_GAMERULES_STATE_CUSTOM_GAME_SETUP
    }

    public enum PlayerTeam
    {
        Undefined,
        None,
        Dire,
        Radiant
    }

    /// <summary>
    /// Structure containing information about the map state.
    /// </summary>
    public class Map
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "matchid")]
        public string MatchId { get; set; }
        [JsonProperty(PropertyName = "game_time")]
        public int GameTime { get; set; }
        [JsonProperty(PropertyName = "clock_time")]
        public int ClockTime { get; set; }
        [JsonProperty(PropertyName = "daytime")]
        public bool IsDayTime { get; set; }
        [JsonProperty(PropertyName = "nightstalker_night")]
        public bool IsNightstalkerNight { get; set; }
        [JsonProperty(PropertyName = "game_state")]
        public DOTA_GameState GameState { get; set; }
        [JsonProperty(PropertyName = "win_team")]
        public PlayerTeam WinTeam { get; set; }
        [JsonProperty(PropertyName = "customgamename")]
        public string CustomeGameName { get; set; }
        [JsonProperty(PropertyName = "ward_purchase_cooldown")]
        public int WardPurchaseCooldown { get; set; }
    }
}
