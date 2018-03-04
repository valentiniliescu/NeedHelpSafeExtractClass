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
}