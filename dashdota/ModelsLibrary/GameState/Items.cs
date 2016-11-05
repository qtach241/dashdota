using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ModelsLibrary
{
    /// <summary>
    /// Structure containing information about the local hero's item slots.
    /// </summary>
    public class Items
    {
        [JsonProperty(PropertyName = "slot0")]
        public Item Slot0 { get; set; }
        [JsonProperty(PropertyName = "slot1")]
        public Item Slot1 { get; set; }
        [JsonProperty(PropertyName = "slot2")]
        public Item Slot2 { get; set; }
        [JsonProperty(PropertyName = "slot3")]
        public Item Slot3 { get; set; }
        [JsonProperty(PropertyName = "slot4")]
        public Item Slot4 { get; set; }
        [JsonProperty(PropertyName = "slot5")]
        public Item Slot5 { get; set; }
        [JsonProperty(PropertyName = "stash0")]
        public Item Stash0 { get; set; }
        [JsonProperty(PropertyName = "stash1")]
        public Item Stash1 { get; set; }
        [JsonProperty(PropertyName = "stash2")]
        public Item Stash2 { get; set; }
        [JsonProperty(PropertyName = "stash3")]
        public Item Stash3 { get; set; }
        [JsonProperty(PropertyName = "stash4")]
        public Item Stash4 { get; set; }
        [JsonProperty(PropertyName = "stash5")]
        public Item Stash5 { get; set; }
    }
}
