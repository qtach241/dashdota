using Newtonsoft.Json;
using System;

namespace ModelsLibrary
{
    /// <summary>
    /// A class representing various information retaining to Game State Integration of Dota 2
    /// </summary>
    public class GameState
    {
        [JsonProperty(PropertyName = "provider")]
        public Provider Provider { get; set; }
        [JsonProperty(PropertyName = "map")]
        public Map Map { get; set; }
        [JsonProperty(PropertyName = "player")]
        public Player Player { get; set; }
        [JsonProperty(PropertyName = "hero")]
        public Hero Hero { get; set; }
        [JsonProperty(PropertyName = "abilities")]
        public Abilities Abilities { get; set; }
        [JsonProperty(PropertyName = "items")]
        public Items Items { get; set; }
        [JsonProperty(PropertyName = "previously")]
        public GameState Previously { get; set; }
        [JsonProperty(PropertyName = "auth")]
        public Auth Auth { get; set; }
    }
}
