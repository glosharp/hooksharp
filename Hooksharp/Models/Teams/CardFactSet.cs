using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardFactSet
    {
        [JsonProperty("type")]
        public string Type { get; } = "FactSet";
        
        [JsonProperty("facts")]
        public List<CardFact> Facts { get; set; }
    }
}