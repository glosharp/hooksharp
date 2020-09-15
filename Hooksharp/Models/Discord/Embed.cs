using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Discord
{
    public class Embed
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("color")]
        public int Color { get; set; }
        
        [JsonProperty("footer")]
        public EmbedFooter Footer { get; set; }
        
        [JsonProperty("fields")]
        public List<EmbedField> Fields { get; set; }
        
        [JsonProperty("author")]
        public EmbedAuthor Author { get; set; }
        
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore)]
        public EmbedImage Image { get; set; }
    }
}