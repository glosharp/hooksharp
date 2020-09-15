using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardFact
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}