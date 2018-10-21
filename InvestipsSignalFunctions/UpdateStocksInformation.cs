using System;
using System.IO;
using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Net.Code.Csv;

namespace InvestipsSignalFunctions
{
    public static class UpdateStocksInformation
    {
        [FunctionName("UpdateStocksInformation")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.nasdaq.com/screening/companies-by-name.aspx?letter=0&exchange=nasdaq&render=download");
            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //StreamReader sr = new StreamReader(resp.GetResponseStream());
            //string results = sr.ReadToEnd();

            //using (var reader = ReadCsv.FromString(results))
            //{
            //    var t = "";
            //}






            //sr.Close();
            
        }
    }
}
