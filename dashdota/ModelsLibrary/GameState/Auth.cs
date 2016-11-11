using Newtonsoft.Json;

namespace ModelsLibrary
{
    /// <summary>
    /// Authentication token for this request
    /// </summary>
    public class Auth
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
