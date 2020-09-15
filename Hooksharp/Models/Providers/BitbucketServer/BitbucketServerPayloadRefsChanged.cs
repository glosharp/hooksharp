using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerPayloadRefsChanged
    {
        [JsonProperty("eventKey")]
        public string EventKey; 

        [JsonProperty("date")]
        public DateTime Date; 

        [JsonProperty("actor")]
        public BitbucketServerActor Actor; 

        [JsonProperty("repository")]
        public BitbucketServerRepository Repository; 

        [JsonProperty("changes")]
        public List<BitbucketServerChange> Changes;
    }
}