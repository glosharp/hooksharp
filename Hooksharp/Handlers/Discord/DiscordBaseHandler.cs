using System.Collections.Generic;
using Hooksharp.Models.Discord;
using Newtonsoft.Json;

namespace Hooksharp.Handlers.Discord
{
    public class DiscordBaseHandler
    {
        public DiscordPayload DiscordPayload;
        private int _embedColor = 0;
        protected string Headers;

        public DiscordBaseHandler()
        {
            DiscordPayload = new DiscordPayload();
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
        /// Add a new Embed.
        /// </summary>
        /// <param name="embed"><see cref="Embed"/>Embed to add.</param>
        protected void AddEmbed(Embed embed)
        {
            // Set the footer on the Embed.
            embed.Footer = new EmbedFooter
            {
                Text = "Powered by Hooksharp, inspired by Skyhook",
                IconUrl = "https://glosharp.com/content/images/size/w1000/2020/09/glosharp_white-3.png"
            };
            
            // Set the standard Embed color.
            embed.Color = _embedColor;

            // Check to see if the Embed object is initialized, if not, create it.
            DiscordPayload.Embeds ??= new List<Embed>();
            
            // Add the new Embed to the List.
            DiscordPayload.Embeds.Add(embed);

        }
        
        /// <summary>
        /// Set the color of the Embed.
        /// </summary>
        /// <param name="color"></param>
        protected void SetEmbedColor(int color)
        {
            _embedColor = color;
        }
        
        /// <summary>
        /// Parse the Discord Payload to a JSON Object
        /// </summary>
        /// <returns></returns>
        public string Parse()
        {
            return JsonConvert.SerializeObject(DiscordPayload);
        }
    }
}