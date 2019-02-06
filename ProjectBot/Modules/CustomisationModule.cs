using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ProjectBot.Domain;

namespace ProjectBot.Modules
{ 
    public class CustomisationModule : ModuleBase<SocketCommandContext>
    {
        [Command("prefix"), Summary("Changes command prefix")]
        public async Task PrefixUpdateAsync([Remainder, Summary("The prefix to use")] string prefix)
        {
            try
            {
                await MessageHelper.Success(Context, "Success",
                    await PrefixHelper.Update(Context.Channel as SocketGuildChannel, prefix));
            }
            catch(Exception e)
            {
                await MessageHelper.Failure(Context, "Failure", e.Message);
            }
        }
    }
}
