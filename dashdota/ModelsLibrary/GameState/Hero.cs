using Newtonsoft.Json;

namespace ModelsLibrary
{
    /// <summary>
    /// Structure containing information about local player's hero.
    /// </summary>
    public class Hero
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
        [JsonProperty(PropertyName = "alive")]
        public bool IsAlive { get; set; }
        [JsonProperty(PropertyName = "respawn_seconds")]
        public int SecondsToRespawn { get; set; }
        [JsonProperty(PropertyName = "buyback_cost")]
        public int BuybackCost { get; set; }
        [JsonProperty(PropertyName = "buyback_cooldown")]
        public int BuybackCooldown { get; set; }
        [JsonProperty(PropertyName = "health")]
        public int Health { get; set; }
        [JsonProperty(PropertyName = "max_health")]
        public int MaxHealth { get; set; }
        [JsonProperty(PropertyName = "health_percent")]
        public int HealthPercent { get; set; }
        [JsonProperty(PropertyName = "mana")]
        public int Mana { get; set; }
        [JsonProperty(PropertyName = "max_mana")]
        public int MaxMana { get; set; }
        [JsonProperty(PropertyName = "mana_percent")]
        public int ManaPercent { get; set; }
        [JsonProperty(PropertyName = "silenced")]
        public bool IsSilenced { get; set; }
        [JsonProperty(PropertyName = "stunned")]
        public bool IsStunned { get; set; }
        [JsonProperty(PropertyName = "disarmed")]
        public bool IsDisarmed { get; set; }
        [JsonProperty(PropertyName = "magicimmune")]
        public bool IsMagicImmune { get; set; }
        [JsonProperty(PropertyName = "hexed")]
        public bool IsHexed { get; set; }
        [JsonProperty(PropertyName = "muted")]
        public bool IsMuted { get; set; }
        [JsonProperty(PropertyName = "break")]
        public bool IsBreak { get; set; }
        [JsonProperty(PropertyName = "has_debuff")]
        public bool HasDebuff { get; set; }
    }
}
