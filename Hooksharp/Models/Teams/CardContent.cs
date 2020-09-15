using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardContent
    {
        [JsonProperty("type")]
        public string Type { get; } = "AdaptiveCard";

        [JsonProperty("$schema")]
        public string Schema { get; } = "http://adaptivecards.io/schemas/adaptive-card.json";

        [JsonProperty("version")]
        public string Version { get; } = "1.2";
        
        [JsonProperty("body")]
        public List<ICardItem> Body { get; set; }
        
        [JsonProperty("actions")]
        public List<ICardAction> Actions { get; set; }
    }
}