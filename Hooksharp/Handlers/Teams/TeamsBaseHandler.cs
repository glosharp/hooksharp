using System.Collections.Generic;
using System.Threading.Tasks;
using Hooksharp.Models.Teams;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hooksharp.Handlers.Teams
{
    public class TeamsBaseHandler
    {
        public TeamsPayload TeamsPayload;
        public List<CardAttachment> Attachments;
        public CardAttachment Attachment;
        public CardContent CardContent;
        public List<ICardItem> CardBody;
        public List<ICardAction> CardActions;
        
        public TeamsBaseHandler()
        {
            TeamsPayload = new TeamsPayload();
            Attachments = new List<CardAttachment>();
            Attachment = new CardAttachment();
            CardContent = new CardContent();
            CardBody = new List<ICardItem>();
            CardActions = new List<ICardAction>();
        }

        /// <summary>
        /// Used to get the name of the Handler.
        /// </summary>
        /// <returns></returns>
        public virtual string GetName()
        {
            return null;
        }
        

        /// <summary>
        /// Add item to the Body.
        /// </summary>
        /// <param name="item"></param>
        protected void AddToBody(ICardItem item)
        {
            CardBody.Add(item);
        }

        /// <summary>
        /// Add item to the Actions.
        /// </summary>
        /// <param name="action"></param>
        protected void AddToAction(ICardAction action)
        {
            CardActions.Add(action);
        }

        /// <summary>
        /// Adds the standard footer to the card. 
        /// </summary>
        private void AddFooter()
        {
            var footer = new CardTextBlock
            {
                IsSubtle = true,
                Text = "Powered by Hooksharp",
                Size = CardTextBlockSize.Small,
                Weight = CardTextBlockWeight.Lighter,
                Color = CardTextBlockColor.Accent
            };
            
            CardBody.Add(footer);
        }

        /// <summary>
        /// Parse the TeamPayload object into JSON.
        /// </summary>
        /// <returns>JSON String</returns>
        public string Parse()
        {
            AddFooter();
            CardContent.Body = CardBody;
            CardContent.Actions = CardActions;
            Attachment.Content = CardContent;
            Attachments.Add(Attachment);
            TeamsPayload.Attachments = Attachments;

            return JsonConvert.SerializeObject(TeamsPayload);
        }
    }
}