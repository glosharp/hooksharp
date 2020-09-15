using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardActionCard : ICardAction
    {
        [JsonProperty("type")]
        public string Type { get; } = "AdaptiveCard";
        
        [JsonProperty("body")]
        public List<ICardItem> Body { get; set; }

        [JsonProperty("$schema")]
        public string Schema { get; } = "http://adaptivecards.io/schemas/adaptive-card.json";
    }
}