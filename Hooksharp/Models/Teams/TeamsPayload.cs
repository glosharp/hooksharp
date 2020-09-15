using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Teams
{
    public class TeamsPayload
    {
        [JsonProperty("type")]
        public string Type { get; } = "message";
        
        [JsonProperty("attachments")]
        public List<CardAttachment> Attachments { get; set; }
    }
}