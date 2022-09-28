using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBlobStorage.Models
{
    public class UploadContentRequest
    {
        public string content { get; set; }
        public string fileName { get; set; }
    }
}
