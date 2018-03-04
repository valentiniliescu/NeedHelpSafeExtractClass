namespace FeedChecker
{
    public class FeedUrl
    {
        public FeedUrl(string feed)
        {
            Feed = feed;
        }

        public string Feed { get; set; }

        public static string GetPackageUrl(FeedUrl feedUrl)
        {
            if (!feedUrl.Feed.EndsWith("/"))
                feedUrl.Feed = feedUrl.Feed + "/";

            var packageUrl = feedUrl.Feed + "main/binary-amd64/Packages";
            return packageUrl;
        }
    }
}