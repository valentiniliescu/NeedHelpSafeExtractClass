using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FeedChecker
{
    public class Feed
    {
        public Feed(string result)
        {
            Result = result;
        }

        public string Result { get; private set; }
    }

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
            var lines = SplitFeedIntoLines(feed);

            return GetCoreFx20Preview1(lines);
        }

        private static IEnumerable<string> GetCoreFx20Preview1(string[] lines)
        {
            var onlyCoreFxPreview1ButWithPackgeInFront =
                lines.Where(l => l.StartsWith("Package: dotnet-hostfxr-2.0.0-preview1"));

            // imagine there is more code

            return onlyCoreFxPreview1ButWithPackgeInFront.Select(l => l.Replace("Package: ", ""));
        }

        private static string[] SplitFeedIntoLines(Feed feed)
        {
            var lines = feed.Result.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
            return lines;
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