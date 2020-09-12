using System;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerFork
    {
        [JsonProperty("eventKey")]
        public string EventKey; 

        [JsonProperty("date")]
        public DateTime Date; 

        [JsonProperty("actor")]
        public BitbucketServerActor Actor; 

        [JsonProperty("repository")]
        public BitbucketServerRepository Repository;
    }
}