using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FeedChecker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            foreach (var l in GetAllCoreFxPreview1(new FeedUrl("http://apt-mo.trafficmanager.net/repos/dotnet/dists/jessie")))
                Console.WriteLine(l);
        }

        public static IEnumerable<string> GetAllCoreFxPreview1(FeedUrl feedUrl)
        {
            var packageUrl = feedUrl.GetPackageUrl();
            var result = GetFeed(packageUrl);
            var feed = new Feed(result);
            return Feed.GetCoreFx20Preview1(feed);
        }

        private static string GetFeed(string packageUrl)
        {
            var request = (HttpWebRequest) WebRequest.Create(packageUrl);

            var result = "";
            var response = request.GetResponse();
            using (var responseStream = response.GetResponseStream())
            {
                var reader = new StreamReader(responseStream, Encoding.UTF8);
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}