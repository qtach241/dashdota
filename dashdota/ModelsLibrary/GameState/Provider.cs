using Newtonsoft.Json;

namespace ModelsLibrary
{
    /// <summary>
    /// Information about the provider of the game state.
    /// </summary>
    public class Provider
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "appid")]
        public int AppId { get; set; }
        [JsonProperty(PropertyName = "version")]
        public int Version { get; set; }
        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }
    }
}
