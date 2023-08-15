using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ImageResizeFunction
{
    public class ImageResizeBlobTrigger
    {
        [FunctionName("ImageResizeBlobTrigger")]
        public void Run(
            [BlobTrigger("images/{name}", Connection = "az204tryblobtrigger323_STORAGE")] Stream sourceStream,
            [Blob("images-sm/{name}", FileAccess.Write)] Stream destinationStream,
            string name,
            ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {sourceStream.Length} Bytes");

            sourceStream.CopyTo(destinationStream);
        }
    }
}
