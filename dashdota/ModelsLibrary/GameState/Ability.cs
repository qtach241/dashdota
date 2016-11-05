using Newtonsoft.Json;

namespace ModelsLibrary
{
    /// <summary>
    /// Structure representing a single hero ability.
    /// </summary>
    public class Ability
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
        [JsonProperty(PropertyName = "can_cast")]
        public bool CanCast { get; set; }
        [JsonProperty(PropertyName = "passive")]
        public bool IsPassive { get; set; }
        [JsonProperty(PropertyName = "ability_active")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "cooldown")]
        public int Cooldown { get; set; }
        [JsonProperty(PropertyName = "ultimate")]
        public bool IsUltimate { get; set; }
    }
}
