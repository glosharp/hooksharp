using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerProperties
    {
        [JsonProperty("repositoryId")]
        public int RepositoryId;

        [JsonProperty("mergeCommit")]
        public BitbucketServerMergeCommit MergeCommit;
    }
}