using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Hooksharp.Models.Teams
{
    public class CardColumn
    {
        [JsonProperty("type")]
        public string Type { get; } = "Column";
        
        [JsonProperty("items")]
        public List<ICardItem> Items { get; set; }

        [JsonProperty("width")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardColumnWidth Width { get; set; }
    }
}