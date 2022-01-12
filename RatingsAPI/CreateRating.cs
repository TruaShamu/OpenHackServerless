using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using OpenHackServerless.RatingsAPI.Model;

namespace OpenHackServerless.RatingsAPI
{
    public static class CreateRating
    {
        private const string V = "AccountEndpoint=https://serverless-openhack-team5-cosmosdb.documents.azure.com:443/; AccountKey=YoBSwM8z0O1kl5o0HZFn6xj4PDfQe6AwmOeOQ1BdmPbSFDA9qKK8WkaoHZDlzJxKAYANgFD1Ovv8gxinbAXzDQ==";

        [FunctionName("CreateRating")]
        /*public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)*/

        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: "BFYOC",collectionName: "Data-Container", 
            ConnectionStringSetting = "CosmosDBConnection")]
            IAsyncCollector<dynamic> documentsOut, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];
            string productId, userId, locationName, userNotes;
            int rating;

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            productId = data?.productId;
            userId = data?.userId;
            locationName = data?.locationName;
            userNotes = data?.userNotes;
            string guid = Guid.NewGuid().ToString();
            DateTime currentTime = DateTime.Now;
            rating = data?.rating;

            /*var ratingResponse = new RatingModel {
                ID=guid,
                UserId=userId,
                ProductId=productId,
                userNotes=userNotes,
                Timestamp=currentTime,
                locationName=locationName,
                Rating=rating
            };*/


            //Database Connection

            string responseMessage = string.IsNullOrEmpty(productId)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, Rating for {productId} submitted successfully.";

            return new OkObjectResult(responseMessage);
        }
    }

}
