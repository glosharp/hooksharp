﻿using Newtonsoft.Json;

namespace Hooksharp.Models.Discord
{
    public class EmbedAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }
    }
}