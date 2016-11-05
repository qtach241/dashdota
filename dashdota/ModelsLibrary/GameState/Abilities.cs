using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ModelsLibrary
{
    /// <summary>
    /// Structure containing information about hero abilities.
    /// </summary>
    public class Abilities
    {
        [JsonProperty(PropertyName = "ability0")]
        public Ability Ability0 { get; set; }
        [JsonProperty(PropertyName = "ability1")]
        public Ability Ability1 { get; set; }
        [JsonProperty(PropertyName = "ability2")]
        public Ability Ability2 { get; set; }
        [JsonProperty(PropertyName = "ability3")]
        public Ability Ability3 { get; set; }
        [JsonProperty(PropertyName = "ability4")]
        public Ability Ability4 { get; set; }
        [JsonProperty(PropertyName = "ability5")]
        public Ability Ability5 { get; set; }
        [JsonProperty(PropertyName = "attributes")]
        public Attributes Attributes { get; set; }
    }
}
