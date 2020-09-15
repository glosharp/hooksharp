using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardAttachment
    {
        [JsonProperty("contentType")]
        public string ContentType { get; } = "application/vnd.microsoft.card.adaptive";
        
        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }
        
        [JsonProperty("content")]
        public CardContent Content { get; set; }
    }
}