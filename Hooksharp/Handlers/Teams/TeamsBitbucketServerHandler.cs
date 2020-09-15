using System.Collections.Generic;
using System.Threading.Tasks;
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
                Text = "Hooksharp, a Teams Parsing Engine",
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
    }
}