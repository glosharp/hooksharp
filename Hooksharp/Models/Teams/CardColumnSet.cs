using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class CardColumnSet
    {
        [JsonProperty("type")]
        public string Type { get; } = "ColumnSet";
        
        [JsonProperty("columns")]
        public List<CardColumn> Columns { get; set; }
        
    }
}