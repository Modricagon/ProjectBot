using ProjectBot.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectBot.Configuration
{
    public static class Edit
    {
        public static void ReadToken(string path)
        {
            try
            {
                Config.token = File.ReadAllLines(path).FirstOrDefault();
                Log.Info($"Imported token: {Config.token}");
            }
            catch (Exception e)
            {
                throw new Exception($"Token could not be read! {e.Message}");
            }
        }
    }
}
