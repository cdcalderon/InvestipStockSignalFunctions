using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using InvestipsSignalFunctions.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace InvestipsSignalFunctions
{
    public static class Stoch307SignalCreator
    {
        [FunctionName("Stoch307SignalCreator")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            try
            {
                log.Info("C# HTTP trigger function processed a request.");

                // parse query parameter
                string name = req.GetQueryNameValuePairs()
                    .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                    .Value;

                if (name == null)
                {
                    // Get request body
                    dynamic data = await req.Content.ReadAsAsync<object>();
                    name = data?.name;
                }

                using (var db = new SignalContext())
                {
                    db.Signals.Add(new Signal { Date = DateTime.Now, Symbol = "AAPL", Type = "STOCH307" });
                    await db.SaveChangesAsync();
                    log.Info("Signal Created");
                }

                return name == null
                    ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                    : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
            }
            catch (Exception e)
            {
               return req.CreateResponse(HttpStatusCode.InternalServerError, e);
            }
            
        }
    }
}
