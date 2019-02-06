using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProjectBot.Domain
{
    public static class DownloadHelper
    {
        public async static Task<object> DownloadJObject(string url)
        {
            var client = new WebClient();
            var uri = new Uri(url);

            var source = client.DownloadStringTaskAsync(uri).GetAwaiter().GetResult();

            return JsonConvert.DeserializeObject(source);
        }
    }
}
