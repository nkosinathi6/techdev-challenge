using System.Collections.Generic;

namespace CommentarySentimentAnalyzer
{
    public static class ReportHelper
    {
        public static void initializeSentimentCounters(Dictionary<string, int> sentimentReport)
        {
            sentimentReport.Add(Constants.PositiveSentimentLabel, 0);
            sentimentReport.Add(Constants.NeutralSentimentLabel, 0);
            sentimentReport.Add(Constants.NegativeSentimentLabel, 0);
        }
    }
}
