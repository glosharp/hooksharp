using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Discord
{
    public class DiscordPayload
    {
        [JsonProperty(PropertyName = "content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
        
        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "avatar_url", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }

        [JsonProperty("embeds")]
        public List<Embed> Embeds { get; set; }
    }
}