using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerPayloadComment
    {
        [JsonProperty("eventKey")]
        public string EventKey; 

        [JsonProperty("date")]
        public DateTime Date; 

        [JsonProperty("actor")]
        public BitbucketServerActor Actor; 

        [JsonProperty("comment")]
        public BitbucketServerComment Comment; 

        [JsonProperty("repository")]
        public BitbucketServerRepository Repository; 

        [JsonProperty("commit")]
        public string Commit;

        [JsonProperty("previousComment")]
        public string PreviousComment;
    }
}