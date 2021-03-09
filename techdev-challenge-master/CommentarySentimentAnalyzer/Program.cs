using System;
using System.Collections.Generic;
using System.IO;

namespace CommentarySentimentAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            var finalReport = new Dictionary<string, int>();
            ReportHelper.initializeSentimentCounters(finalReport);

            var files = new List<string>(Directory.EnumerateFiles("commentary"));

            foreach (var file in files)
            {
                var model = new SentimentAnalysisModel(file);
                var sentiment = model.analyzeSentiment();

                updateReportResults(finalReport, sentiment);
            }

            Console.WriteLine("Final Report\n=============");
            foreach(var analytic in finalReport)
            {
                Console.WriteLine($"{analytic.Key} : {analytic.Value}");
            }
            Console.ReadLine();
        }

        static void updateReportResults(Dictionary<string, int> finalReport, string sentiment)
        {
            finalReport[sentiment] = finalReport[sentiment] + 1;
        }
    }
}
