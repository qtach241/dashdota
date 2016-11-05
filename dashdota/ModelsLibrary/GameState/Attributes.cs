using Newtonsoft.Json;

namespace ModelsLibrary
{
    /// <summary>
    /// Class representing ability attributes
    /// </summary>
    public class Attributes
    {
        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
    }
}
