using System;
using System.Collections.Generic;

namespace ProjectBot.Configuration
{
    public static class Config
    {

        public static string token { get; set; }

        public static string defaultPrefix { get; set; } = ",";

        public static List<ServerConfigs> ServerConfigs { get; set; } = new List<ServerConfigs>();
    }
}
