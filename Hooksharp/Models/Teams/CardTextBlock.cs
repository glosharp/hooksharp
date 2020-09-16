using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hooksharp.Models.Teams
{
    public class CardTextBlock : ICardItem
    {
        [JsonProperty("type")]
        public string Type { get; } = "TextBlock";
        
        [JsonProperty("weight")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardTextBlockWeight Weight { get; set; }
        
        [JsonProperty("size")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardTextBlockSize Size { get; set; }
        
        [JsonProperty("color")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardTextBlockColor Color { get; set; }
        
        [JsonProperty("text")]
        public string Text { get; set; }
        
        [JsonProperty(PropertyName = "isSubtle", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSubtle { get; set; }
        
        [JsonProperty(PropertyName = "wrap", NullValueHandling = NullValueHandling.Ignore)]
        public bool Wrap { get; set; }  
    }
}