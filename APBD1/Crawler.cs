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
                if (!list.Contains(match.Value))
                {
                    list.Add(match.Value);
                }
            }
            if (list.Count < 0)
            {
                Console.WriteLine("Nie znaleziono adresów e-mail");
            }
            else
            {
                foreach (String s in list)
                {
                    Console.WriteLine(s);
                }
            }
        }
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentNullException("Podaj URL");
            }
            string websiteUrl = args[0];
            if(!(Uri.IsWellFormedUriString(websiteUrl, UriKind.Absolute)))
            {
                throw new ArgumentException("Podaj poprawny adres URL");
            }
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(websiteUrl);
                if (response.IsSuccessStatusCode)
                {
                    string websiteContent = await response.Content.ReadAsStringAsync();
                    showEmails(websiteContent);
                }
            } catch (Exception e) {
                Console.WriteLine("Błąd podczas ładowania strony");
            } finally {
                httpClient.Dispose();
            }
        }
    }
}
