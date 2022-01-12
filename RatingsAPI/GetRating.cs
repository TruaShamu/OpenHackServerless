using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Company.Function
{
    public static class GetRating
    {
        [FunctionName("GetRating")]

    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        [CosmosDB(
            databaseName: "BFYOC",
            collectionName: "Data-Container",
            ConnectionStringSetting = "AccountEndpoint=https://serverless-openhack-team5-cosmosdb.documents.azure.com:443/;AccountKey=YoBSwM8z0O1kl5o0HZFn6xj4PDfQe6AwmOeOQ1BdmPbSFDA9qKK8WkaoHZDlzJxKAYANgFD1Ovv8gxinbAXzDQ==")]IAsyncCollector<dynamic> documentsOut,
        ILogger log)

        {
            log.LogInformation("C# HTTP trigger function processed a request.");

        return new NotFoundObjectResult("Rating");
 
        }
    }
}
