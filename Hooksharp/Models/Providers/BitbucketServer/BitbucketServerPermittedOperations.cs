using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerPermittedOperations
    {
        [JsonProperty("editable")]
        public bool Editable; 

        [JsonProperty("deletable")]
        public bool Deletable; 
    }
}