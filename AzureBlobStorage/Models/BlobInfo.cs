using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBlobStorage.Models
{
    public class BlobInfo
    { 

        public BlobInfo(Stream stream ,string fileType)
        {
            this.Content = stream;
            this.contentType = fileType;
        }

        public Stream Content { get; set; }

        public string contentType { get; set; }
    }
}
