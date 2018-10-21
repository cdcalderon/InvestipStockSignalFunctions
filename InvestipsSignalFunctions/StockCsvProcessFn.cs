using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InvestipsSignalFunctions.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace InvestipsSignalFunctions
{
    public static class StockCsvProcessFn
    {
        [FunctionName("StockCsvProcessFn")]
        public static async Task Run([BlobTrigger("import/{name}", Connection = "AzureWebJobsStorage")]Stream myBlob, string name, TraceWriter log)
        {
            log.Info($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            if (myBlob.Length > 0)
            {
                using (var reader = new StreamReader(myBlob))
                {
                    var lineNumber = 1;
                    var line = await reader.ReadLineAsync();
                    while (line != null)
                    {
                        await ProcessLine(name, line, lineNumber, log);
                        line = await reader.ReadLineAsync();
                        lineNumber++;
                    }
                }
            }
        }

        private static async Task ProcessLine(string name, string line, int lineNumber, TraceWriter log)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                log.Warning($"{name}: {lineNumber} is empty.");
                return;
            }

            var parts = line.Split(',');
            if (parts.Length != 8)
            {
                log.Error($"{name}: {lineNumber} invalid data: {line}.");
                return;
            }

            var item = new StockSecurity() { Symbol = parts[0] };
            //if ((int.TryParse(parts[1], out int complete) == false) || complete < 0 || complete > 1)
            //{
            //    log.Error($"{name}: {lineNumber} bad complete flag: {parts[1]}.");
            //}

            using (var context = new SignalContext())
            {
                if (context.StockSecurities.Any(todo => todo.Symbol == item.Symbol))
                {
                    log.Error($"{name}: {lineNumber} duplicate Stock Security: \"{item.Symbol}\".");
                    return;
                }
                context.StockSecurities.Add(item);
                await context.SaveChangesAsync();
                log.Info($"{name}: {lineNumber} inserted Stock Security: \"{item.Symbol}\" with id: {item.Id}.");
            }
        }
    }


}
