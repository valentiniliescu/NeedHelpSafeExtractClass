namespace FeedChecker
{
    public class FeedUrl
    {
        public FeedUrl(string feed)
        {
            Feed = feed;
        }

        public string Feed { get; set; }

        public string GetPackageUrl()
        {
            if (!Feed.EndsWith("/"))
                Feed = Feed + "/";

            var packageUrl = Feed + "main/binary-amd64/Packages";
            return packageUrl;
        }
    }
}