using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectBot.Configuration;
using ProjectBot.Logging;

namespace ProjectBot.Domain
{
    public static class QuotesHelper
    {
        public static string OpinionatedQuotes()
        {
            var data = DownloadHelper.DownloadJObject(ApiUrls.opinionatedQuotesUrl).Result;

            var jo = (JObject) data;
            var a = jo.First.First.First;

            string quote = "";

            foreach (JToken token in a)
            {
                if (token.Path.Contains("quote") && !token.Path.Contains("quotes"))
                {
                    quote = token.First.ToString();
                }
            }

            return "";
        }
    }
}
