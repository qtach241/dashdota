using Newtonsoft.Json;

namespace ModelsLibrary
{
    /// <summary>
    /// Structure containing information about a single item.
    /// </summary>
    public class Item
    {
        [JsonProperty(PropertyName ="name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "contains_rune")]
        public string ContainsRune { get; set; }
        [JsonProperty(PropertyName = "can_cast")]
        public bool CanCast { get; set; }
        [JsonProperty(PropertyName = "cooldown")]
        public int Cooldown { get; set; }
        [JsonProperty(PropertyName = "passive")]
        public bool IsPassive { get; set; }
        [JsonProperty(PropertyName = "charges")]
        public int Charges { get; set; }
    }
}
