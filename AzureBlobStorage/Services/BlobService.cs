using Azure.Storage.Blobs;
using BlobHeaders =  Azure.Storage.Blobs.Models.BlobHttpHeaders;
using AzureBlobStorage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBlobStorage.Extensions;

namespace AzureBlobStorage.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        
        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task DeleteBlobAsync(string blobName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("youtube");
            var blobClient = containerClient.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();

        }

        public async Task<BlobInfo> GetBlobAsync(string name)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("youtube");

            var blobClient = containerClient.GetBlobClient(name);

            var blobDownloadInfo= await blobClient.DownloadAsync();

            return new BlobInfo(blobDownloadInfo.Value.Content,blobDownloadInfo.Value.ContentType);
        }

        public async Task<IEnumerable<string>> ListBlobAsync()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("youtube");
            var items = new List<string>();
            await foreach (var blobItem in containerClient.GetBlobsAsync())
            {
                items.Add(blobItem.Name);
            }
            return items;
        }

        public async Task UploadContentBlobAsync(string content, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("youtube");
            var blobClient = containerClient.GetBlobClient(fileName);
            var bytes = Encoding.UTF8.GetBytes(content);
            using var mermoryStream = new MemoryStream(bytes);
            await blobClient.UploadAsync(mermoryStream,new BlobHeaders{ContentType = fileName.GetContentType() });
        }

        public async Task UploadFileBlobAsync(Stream fileData, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("youtube");
            var blobClient = containerClient.GetBlobClient(fileName);
            await blobClient.UploadAsync(fileData, new BlobHeaders { ContentType = fileName.GetContentType() });
        }

    }
}
