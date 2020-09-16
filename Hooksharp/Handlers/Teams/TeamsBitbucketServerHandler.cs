using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hooksharp.Models.Providers.BitbucketServer;
using Hooksharp.Models.Teams;
using Newtonsoft.Json.Linq;

namespace Hooksharp.Handlers.Teams
{
    public class TeamsBitbucketServerHandler : TeamsBaseHandler
    {
        public override string GetName()
        {
            return "Bitbucket Server";
        }
        
        public async Task<string> GetPayload(JObject raw, string eventKey)
        {
            await ParseData(raw, eventKey);
            return Parse();
        }

        private Task ParseData(JObject raw, string eventKey)
        {
            switch (eventKey)
            {
                case "diagnostics:ping":
                    DiagnosticsPing();
                    break;
            }
            
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the Diagnostic Pings for Connection Testing.
        /// </summary>
        private void DiagnosticsPing()
        {
            var title = new CardTextBlock
            {
                Text = "Hooksharp, a Teams Webhook Parsing Engine",
                Weight = CardTextBlockWeight.Bolder,
                Size = CardTextBlockSize.Medium
            };

            var description = new CardTextBlock
            {
                Text = "You have successfully configured Hooksharp with your Bitbucket Server Instance!\n" +
                       "Happy Coding!",
                Size = CardTextBlockSize.Default,
                Wrap = true,
                Color = CardTextBlockColor.Default
            };

            var githubLink = new CardActionOpenUrl
            {
                Title = "Find us on GitHub!",
                Url = "https://github.com/glosharp/hooksharp"
            };
            
            AddToBody(title);
            AddToBody(description);
            
            AddToAction(githubLink);
        }

        private List<CardFact> ExtractPullRequestFields(BitbucketServerPullRequest pullRequest)
        {
            var facts = new List<CardFact>();
            var fromFact = new CardFact
            {
                Title = "From",
                Value = pullRequest.FromRef.DisplayId
            };

            var toFact = new CardFact
            {
                Title = "To",
                Value = pullRequest.ToRef.DisplayId
            };
            
            facts.Add(fromFact);
            facts.Add(toFact);

            var fieldCount = 0;
            
            foreach (var reviewer in pullRequest.Reviewers)
            {
                fieldCount++;
                
                if (fieldCount > 10)
                {
                    break;
                }

                var reviewerFact = new CardFact
                {
                    Title = "Reviewer",
                    Value = reviewer.User.DisplayName
                };

                var reviewerFactStatus = new CardFact
                {
                    Title = "Status",
                    Value = reviewer.Status
                };
                
                facts.Add(reviewerFact);
                facts.Add(reviewerFactStatus);
            }

            return facts;
        }
        
        private static List<CardFact> ExtractRepoChangesField(IEnumerable<BitbucketServerChange> changes)
        {
            var facts = new List<CardFact>();

            var changeCount = 0;
            
            foreach (var change in changes)
            {
                changeCount++;

                if (changeCount > 10)
                {
                    break;
                }
                
                var branch = change.Ref.DisplayId;
                var hash = change.ToHash.Substring(0,10);
                var type = change.Type;

                var branchFact = new CardFact
                {
                    Title = "Branch",
                    Value = branch
                };

                var hashFact = new CardFact
                {
                    Title = "Hash",
                    Value = hash
                };

                var typeFact = new CardFact
                {
                    Title = "Type",
                    Value = type
                };
                
                facts.Add(branchFact);
                facts.Add(hashFact);
                facts.Add(typeFact);
            }

            return facts;
        }

        private static string ExtractCommitCommentUrl(BitbucketServerPayloadRefsChanged payload)
        {
            return $"{ExtractBaseLink(payload.Actor)}/projects/{payload.Repository.Project.Key}" +
                   $"/repos/{payload.Repository.Slug}/{payload.Changes[0].FromHash}";
        }
        
        private static string ExtractBaseLink(BitbucketServerActor actor)
        {
            return string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BITBUCKET_SERVER_URL")) 
                ? actor.Links.Self[0].Href 
                : Environment.GetEnvironmentVariable("BITBUCKET_SERVER_URL");
        }
    }
}