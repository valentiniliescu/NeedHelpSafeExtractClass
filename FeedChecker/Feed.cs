using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedChecker
{
    public class Feed
    {
        public Feed(string result)
        {
            Result = result;
        }

        public string Result { get; private set; }

        public IEnumerable<string> GetCoreFx20Preview1()
        {
            var lines = SplitFeedIntoLines();

            return GetCoreFx20Preview1(lines);
        }

        private static IEnumerable<string> GetCoreFx20Preview1(string[] lines)
        {
            var onlyCoreFxPreview1ButWithPackgeInFront =
                lines.Where(l => l.StartsWith("Package: dotnet-hostfxr-2.0.0-preview1"));

            // imagine there is more code

            return onlyCoreFxPreview1ButWithPackgeInFront.Select(l => l.Replace("Package: ", ""));
        }

        public string[] SplitFeedIntoLines()
        {
            var lines = Result.Split(
                new[] {"\r\n", "\r", "\n"},
                StringSplitOptions.None);
            return lines;
        }
    }
}