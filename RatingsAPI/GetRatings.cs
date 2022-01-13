using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;


namespace Company.Function
{
    public static class GetRatings
    {
        [FunctionName("GetRatings")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "getRatings/{UserId}")] HttpRequest request,
            [CosmosDB( databaseName: "BFYOC",
            collectionName: "Data-Container",
            ConnectionStringSetting = "CosmosDBConnection",
            SqlQuery = "select * from BFYOC r where r.UserId = {UserId}")]
                IEnumerable<Rating> ratings,
            ILogger log)
        {
            int ratNum = ratings.Count();
            if (ratNum == 0) {
                return new NotFoundObjectResult("RatingId Broken");
            }

            //Idk what I'm doing bro
            return new OkObjectResult(ratings);
        }
    }
}
