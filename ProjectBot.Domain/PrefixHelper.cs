using ProjectBot.Configuration;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace ProjectBot.Domain
{
    public static class PrefixHelper
    {
        public static string Get(SocketGuildChannel channel)
        {
            ulong serverID = channel.Guild.Id;
            return Config.ServerConfigs.FirstOrDefault(x => x.serverId == serverID)?.prefix ??
                   AddServer(serverID);
        }

        public static async Task<string> Update(SocketGuildChannel channel, string prefix)
        {
            try
            {
                ulong serverID = channel.Guild.Id;
                Config.ServerConfigs.FirstOrDefault(x => x.serverId == serverID).prefix = prefix;
                await Task.Delay(0);
                return $"Prefix set to \"{prefix}\" for guild {channel.Guild.Name}";
            }
            catch(Exception e)
            {
                throw  new Exception($"Could not update prefix! {e.Message}");
            }
        }

        private static string AddServer(ulong serverID)
        {
            var newServer = new ServerConfigs(serverID);
            Config.ServerConfigs.Add(newServer);
            return newServer.prefix;
        }
    }
}
