using Newtonsoft.Json;

namespace Hooksharp.Models.Discord
{
    public class EmbedImage
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
    }
}