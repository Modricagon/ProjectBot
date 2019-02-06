using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace ProjectBot.Domain
{
    public static class MessageHelper
    {
        public static async Task Success(ICommandContext context, string title, string message)
        {
            var builder = new EmbedBuilder()
                .WithTitle($"{title} :white_check_mark:")
                .WithDescription($"{message}")
                .WithColor(Color.Green);
            await context.Channel.SendMessageAsync("", false, builder.Build());
        }

        public static async Task Failure(ICommandContext context, string title, string message)
        {
            var builder = new EmbedBuilder()
                .WithTitle($"{title} :x:")
                .WithDescription($"{message}")
                .WithColor(Color.Red);
            await context.Channel.SendMessageAsync("", false, builder.Build());
        }

        public static async Task Warning(ICommandContext context, string title, string message)
        {
            var builder = new EmbedBuilder()
                .WithTitle($"{title} :warning:")
                .WithDescription($"{message}")
                .WithColor(Color.Orange);
            await context.Channel.SendMessageAsync("", false, builder.Build());
        }

        public static async Task Info(ICommandContext context, string title, string message)
        {
            var builder = new EmbedBuilder()
                .WithTitle(title)
                .WithDescription(message)
                .WithColor(Color.Blue);
            await context.Channel.SendMessageAsync("", false, builder.Build());
        }
    }
}
