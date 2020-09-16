using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hooksharp.Models.Providers.BitbucketServer
{
    public class BitbucketServerPayloadPullRequest
    {
        [JsonProperty("eventKey")]
        public string EventKey; 

        [JsonProperty("date")]
        public DateTime Date; 

        [JsonProperty("actor")]
        public BitbucketServerActor Actor; 

        [JsonProperty("pullRequest")]
        public BitbucketServerPullRequest PullRequest;

        [JsonProperty("participant")]
        public BitbucketServerAuthor Participant;

        [JsonProperty("addedReviewers")]
        public List<BitbucketServerAuthor> AddedReviewers;

        [JsonProperty("removedReviewers")]
        public List<BitbucketServerAuthor> RemovedReviewers;

        [JsonProperty("previousState")]
        public string PreviousState;

        [JsonProperty("comment")]
        public BitbucketServerComment Comment;
    }
}