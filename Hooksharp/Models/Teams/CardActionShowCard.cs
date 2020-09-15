using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardActionShowCard : ICardAction
    {
        [JsonProperty("type")]
        public string Type { get; } = "Action.ShowCard";
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("card")]
        public CardActionCard Card { get; set; }
    }
}