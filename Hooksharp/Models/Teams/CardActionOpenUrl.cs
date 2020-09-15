using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardActionOpenUrl : ICardAction
    {
        [JsonProperty("type")]
        public string Type { get; } = "Action.OpenUrl";
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}