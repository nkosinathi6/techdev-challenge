using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CommentarySentimentAnalyzer
{
    public class statementSentimentCount : IstatementSentimentCount
    {
        private string sentiment;
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
     
        public string sentimentLabel(string statement)
        {
            Match emailMatched = regex.Match(statement);

            // rule: happy word exists
            if (statement.Contains("unhappy"))
            {
                sentiment = Constants.NegativeSentimentLabel;
            }
            // rule: unhappy word exists
            else if (statement.Contains("happy"))
            {
                sentiment = Constants.PositiveSentimentLabel;
            }
            // rule: question mark symbol occurs more that once
            else if (statement.Count(s => s == '?') >= 2)
            {
                sentiment = Constants.NegativeSentimentLabel;
            }
            // rule: complaint word exists
            else if (statement.Contains("complaint") && emailMatched.Success)
            {
                sentiment = Constants.NegativeSentimentLabel;
            }
            // rule: exclamation mark symbol occurs at least once 
            else if (statement.Count(s => s == '!') >= 1)
            {
                sentiment = Constants.NegativeSentimentLabel;
            }
            // rule: sadly word exists 
            else if (statement.Contains("sad"))
            {
                sentiment = Constants.NegativeSentimentLabel;
            }
            // rule: satisfied word exists (additional sentiment since it is also positive)
            else if (statement.Contains("satisfied"))
            {
                sentiment = Constants.PositiveSentimentLabel;
            }

            return sentiment;
        }
    }
}
