//toolbarqueries.google.com
//Import this  SystemSystem.Web.Mvc; //<%@ Master Language="C#" Inherits="System.Web.Mvc.ViewMasterPage" %>
//Loved this implementation
#pragma warning disable SYSLIB0014

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;



namespace PageRank
{
    public class MainClass
    {
        public void run()
        {
            Main(new String[0]);
        }
        public static void Main(string[] args)
        {
            string url = "http://www.google.com/search?q=site:www.google.com";
            try {
                string html = GetHtml(url);
                int pr = MyPR(url);
                string[] links = GetLinks(html);
                foreach (string link in links)
                {
                    Console.WriteLine(link);
                    Console.WriteLine(pr);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static string GetHtml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36";
            try {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string html = reader.ReadToEnd();
                return html;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "";
            }

        }
        public static string[] GetLinks(string html)
        {
            List<string> links = new List<string>();
            string pattern = @"<a[^>]+href=[""'](?<href>[^""']*)[""']";
            MatchCollection matches = Regex.Matches(html, pattern);
            foreach (Match match in matches)
            {
                links.Add(match.Groups["href"].Value);
            }
            return links.ToArray();
        }
        private const UInt32 myConst = 0xE6359A60;
            private static void _Hashing(ref UInt32 a, ref UInt32 b, ref UInt32 c)
            {
                a -= b; a -= c; a ^= c >> 13;
                b -= c; b -= a; b ^= a << 8;
                c -= a; c -= b; c ^= b >> 13;
                a -= b; a -= c; a ^= c >> 12;
                b -= c; b -= a; b ^= a << 16;
                c -= a; c -= b; c ^= b >> 5;
                a -= b; a -= c; a ^= c >> 3;
                b -= c; b -= a; b ^= a << 10;
                c -= a; c -= b; c ^= b >> 15;
            }
            public static string PerfectHash(string theURL = "http://www.google.com/search?q=site:www.google.com")
            {
                string url = "http://www.google.com/search?q=site:www.google.com";

                url = string.Format("info:{0}", theURL);

                int length = url.Length;

                UInt32 a, b;
                UInt32 c = myConst;

                int k = 0;
                int len = length;

                a = b = 0x9E3779B9;

                while (len >= 12)
                {
                    a += (UInt32)(url[k + 0] + (url[k + 1] << 8) +
                         (url[k + 2] << 16) + (url[k + 3] << 24));
                    b += (UInt32)(url[k + 4] + (url[k + 5] << 8) +
                         (url[k + 6] << 16) + (url[k + 7] << 24));
                    c += (UInt32)(url[k + 8] + (url[k + 9] << 8) +
                         (url[k + 10] << 16) + (url[k + 11] << 24));
                    _Hashing(ref a, ref b, ref c);
                    k += 12;
                    len -= 12;
                }
                c += (UInt32)length;
                switch (len)
                {
                    case 11:
                        c += (UInt32)(url[k + 10] << 24);
                        goto case 10;
                    case 10:
                        c += (UInt32)(url[k + 9] << 16);
                        goto case 9;
                    case 9:
                        c += (UInt32)(url[k + 8] << 8);
                        goto case 8;
                    case 8:
                        b += (UInt32)(url[k + 7] << 24);
                        goto case 7;
                    case 7:
                        b += (UInt32)(url[k + 6] << 16);
                        goto case 6;
                    case 6:
                        b += (UInt32)(url[k + 5] << 8);
                        goto case 5;
                    case 5:
                        b += (UInt32)(url[k + 4]);
                        goto case 4;
                    case 4:
                        a += (UInt32)(url[k + 3] << 24);
                        goto case 3;
                    case 3:
                        a += (UInt32)(url[k + 2] << 16);
                        goto case 2;
                    case 2:
                        a += (UInt32)(url[k + 1] << 8);
                        goto case 1;
                    case 1:
                        a += (UInt32)(url[k + 0]);
                        break;
                    default:
                        break;
                }

                _Hashing(ref a, ref b, ref c);

                return string.Format("6{0}", c);
            }

            public static int MyPR(string myURL)//calculates the PageRank of a given URL
            {
                string strDomainHash = PerfectHash(myURL);
                string myRequestURL = string.Format("http://toolbarqueries.google.com/" +
                       "search?client=navclient-auto&ch={0}&features=Rank&q=info:{1}",
                       strDomainHash, myURL);

                try
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(myRequestURL);
                    string myResponse = new StreamReader(
                           myRequest.GetResponse().GetResponseStream()).ReadToEnd();
                    if (myResponse.Length == 0)
                        return 0;
                    else
                        return int.Parse(Regex.Match(myResponse,
                               "Rank_1:[0-9]:([0-9]+)").Groups[1].Value);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
    }
}