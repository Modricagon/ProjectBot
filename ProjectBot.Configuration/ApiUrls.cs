using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBot.Configuration
{
    public static class ApiUrls
    {
        public static string opinionatedQuotesUrl { get; set; } =
            "https://opinionated-quotes-api.gigalixirapp.com/v1/quotes";

        public static string randomQuotesUrl { get; } =
            "https://sumitgohil-random-quotes-v1.p.rapidapi.com/fetch/randomQuote";

        public static string randomQuotesKey { get; } =
            "bbb8e2dff4msh79f70d5bbf04ec4p172c97jsn6f5bee234637";
    }
}
