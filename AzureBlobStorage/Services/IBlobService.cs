
using AzureBlobStorage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBlobStorage.Services
{
    public interface IBlobService
    {
        public Task<BlobInfo> GetBlobAsync( string name);
        public Task<IEnumerable<string>>ListBlobAsync();
        public Task UploadFileBlobAsync(Stream fileData , string fileNames);
        public Task UploadContentBlobAsync(string content, string fileName);
        public Task DeleteBlobAsync(string blobName);
    }
}
