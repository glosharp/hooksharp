using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hooksharp.Models.Teams
{
    public class CardImage : ICardItem
    {
        [JsonProperty("type")]
        public string Type { get; } = "Image";
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("style")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardImageStyle Style { get; set; }
        
        [JsonProperty("size")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardImageSize Size { get; set; }
        
        
    }
}