using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBlobStorage.Models
{
    public class UploadFileRequest
    {
        public Stream fileData { get; set; }

        public string fileName { get; set; }
    }
}
