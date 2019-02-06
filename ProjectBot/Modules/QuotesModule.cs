using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using ProjectBot.Domain;

namespace ProjectBot.Modules
{
    public class QuotesModule : ModuleBase<SocketCommandContext>
    {
        [Command("quote"), Summary("Posts quote")]
        public async Task ImgurImageAsync()
        {
            try
            {
                await MessageHelper.Info(Context, "Quote", QuotesHelper.OpinionatedQuotes());
            }
            catch (Exception e)
            {
                await MessageHelper.Failure(Context, "Failure", e.Message);
            }
        }
    }
}
