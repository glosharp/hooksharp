using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerPayloadMirrorSync
    {
        [JsonProperty("eventKey")]
        public string EventKey; 

        [JsonProperty("date")]
        public DateTime Date; 

        [JsonProperty("mirrorServer")]
        public BitbucketServerMirrorServer MirrorServer; 

        [JsonProperty("syncType")]
        public string SyncType; 

        [JsonProperty("refLimitExceeded")]
        public bool RefLimitExceeded; 

        [JsonProperty("repository")]
        public BitbucketServerRepository Repository; 

        [JsonProperty("changes")]
        public List<BitbucketServerChange> Changes;
    }
}