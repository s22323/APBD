using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APBD1
{
   class Crawler
    {
        private static void showEmails(string text)
        {
            String pattern = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            MatchCollection matchCollection = Regex.Matches(text, pattern);
            ArrayList list = new ArrayList();
            foreach (Match match in matchCollection)
            {
                list.Add(match.Value);
            }
                foreach (String s in list)
                {
                Console.WriteLine(s);
                }
        }
        static async Task Main(string[] args)
        {
            string websiteUrl = args[0];
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);
            string websiteContent = await response.Content.ReadAsStringAsync();
            showEmails(websiteContent);
        }
    }
}
