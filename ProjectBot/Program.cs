using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using ProjectBot.Configuration;
using ProjectBot.Domain;
using ProjectBot.Logging;

namespace ProjectBot
{
    class Program
    {
        private CommandService commands;
        private DiscordSocketClient client;
        private IServiceProvider services;

        //https://discordapp.com/oauth2/authorize?client_id=540833609435840533&scope=bot&permissions=1610087505

        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            try
            {
                Edit.ReadToken("Core/token.txt");
            }
            catch(Exception e)
            {
                Log.Fatal(e.Message);
                Console.ReadKey();
                return;
            } //Imports token

            client = new DiscordSocketClient();
            commands = new CommandService();

            services = new ServiceCollection()
                .BuildServiceProvider();

            client.Log += Log.StatusLog;

            await InstallCommands();

            await client.LoginAsync(TokenType.Bot, Config.token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task InstallCommands()
        {
            // Hook the MessageReceived Event into our Command Handler
            client.MessageReceived += HandleCommand;
            // Discover all of the commands in this assembly and load them.
            await commands.AddModulesAsync(assembly: Assembly.GetEntryAssembly(),
                services: null);
        }

        public async Task HandleCommand(SocketMessage messageParam)
        {
            // Don't process the command if it was a System Message
            var message = messageParam as SocketUserMessage;
            if (message == null) return;
            // Create a number to track where the prefix ends and the command begins
            int argPos = 0;
            // Determine if the message is a command, based on if it starts with '!' or a mention prefix
            if (!(message.HasStringPrefix(PrefixHelper.Get(message.Channel as SocketGuildChannel), ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) return;
            // Create a Command Context
            var context = new SocketCommandContext(client, message);
            // Execute the command. (result does not indicate a return value, 
            // rather an object stating if the command executed successfully)
            var result = await commands.ExecuteAsync(context, argPos, services);
            if (!result.IsSuccess)
                await MessageHelper.Warning(context, "Error", result.ErrorReason);
        }
    }
}
