using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBot.Configuration
{
    public class ServerConfigs
    {
        public ulong serverId { get; set; }

        public string prefix { get; set; } = ",";

        public ServerConfigs(ulong ServerId)
        {
            serverId = ServerId;
        }
    }
}
