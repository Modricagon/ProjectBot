using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectBot.Configuration;
using ProjectBot.Logging;

namespace ProjectBot.Domain
{
    public static class QuotesHelper
    {
        public static string RandomQuotes()
        {
            Task<HttpResponse<MyClass>> response = Unirest.get("https://sumitgohil-random-quotes-v1.p.rapidapi.com/fetch/randomQuote")
                .header("X-RapidAPI-Key", "bbb8e2dff4msh79f70d5bbf04ec4p172c97jsn6f5bee234637")
                .asJson();

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
