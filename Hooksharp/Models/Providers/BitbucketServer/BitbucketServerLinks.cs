using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerLinks
    {
        [JsonProperty("clone")]
        public List<BitbucketServerClone> Clone; 

        [JsonProperty("self")]
        public List<BitbucketServerSelf> Self;
    }
}