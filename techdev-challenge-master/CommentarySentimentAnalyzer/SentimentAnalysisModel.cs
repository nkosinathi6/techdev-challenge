using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommentarySentimentAnalyzer
{
    public class SentimentAnalysisModel
    {
        private readonly string _file;
        private readonly IstatementSentimentCount _sentimentCount;

        public SentimentAnalysisModel(string file)
        {
            _file = file;
            _sentimentCount = new statementSentimentCount();
        }

        public string analyzeSentiment()
        {
            var statementSentimentCount = new Dictionary<string, int>();
            ReportHelper.initializeSentimentCounters(statementSentimentCount);

            var statements = File.ReadAllLines(_file);
            string sentiment;

            Parallel.ForEach(statements, statement =>
            {

                sentiment = _sentimentCount.sentimentLabel(statement);
                // add positive sentiment
                if (sentiment == Constants.PositiveSentimentLabel)
                {
                    statementSentimentCount[Constants.PositiveSentimentLabel] =
                        statementSentimentCount[Constants.PositiveSentimentLabel] + 1;
                }
                // add negative sentiment
                else if (sentiment == Constants.NegativeSentimentLabel)
                {
                    statementSentimentCount[Constants.NegativeSentimentLabel] =
                        statementSentimentCount[Constants.NegativeSentimentLabel] + 1;
                }
                // add neutral sentiment
                else if (sentiment == Constants.NeutralSentimentLabel)
                {
                    statementSentimentCount[Constants.NeutralSentimentLabel] =
                        statementSentimentCount[Constants.NeutralSentimentLabel] + 1;
                }
            });

            var finalSentiment = determineSentiment(statementSentimentCount);

            return (finalSentiment);
        }

        /// <summary>
        /// Determine the final sentiment of the commentary based on the sentiment
        /// of the individual statements within the commentary
        /// </summary>
        /// <param name="statementSentimentCount">Sentiments for each statement in a file</param>
        /// <returns>Returns the final sentiment</returns>
        private string determineSentiment(Dictionary<string, int> statementSentimentCount)
        {
            var finalSentiment = string.Empty;

            if (statementSentimentCount[Constants.PositiveSentimentLabel] > statementSentimentCount[Constants.NegativeSentimentLabel])
            {
                finalSentiment = Constants.PositiveSentimentLabel;
            }
            else if (statementSentimentCount[Constants.PositiveSentimentLabel] < statementSentimentCount[Constants.NegativeSentimentLabel])
            {
                finalSentiment = Constants.NegativeSentimentLabel;
            }
            else
            {
                finalSentiment = Constants.NeutralSentimentLabel;
            }

            return (finalSentiment);
        }

        private void readFile()
        {

        }

    }
}
