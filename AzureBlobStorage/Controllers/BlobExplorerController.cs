using AzureBlobStorage.Models;
using AzureBlobStorage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureBlobStorage.Controllers
{
    [Route("api/BlobExplorer")]
    [ApiController]
    public class BlobExplorerController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public BlobExplorerController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpGet]
        [Route("GetBlob")]
        public async Task<IActionResult> GetBlob(string blobName)
        {
            var data = await _blobService.GetBlobAsync(blobName);
            return File(data.Content,data.contentType);
        }

        [HttpGet]
        [Route("DeleteBlob")]
        public async Task<IActionResult> DeleteBlob(string blobName)
        {
            await _blobService.DeleteBlobAsync(blobName);
            return Ok();
        }
        [HttpGet]
        [Route("GetBlobList")]
        public async Task<IActionResult> GetBlobList()
        {
            return Ok(await _blobService.ListBlobAsync());
        }

        [HttpPost]
        [Route("UploadFile")]
        public async Task<IActionResult> UploadFile([FromBody] UploadFileRequest resquest)
        {
            await _blobService.UploadFileBlobAsync(resquest.fileData, resquest.fileName);
            return Ok();
        }

        [HttpPost]
        [Route("UploadContent")]
        public async Task<IActionResult> UploadContent([FromBody] UploadContentRequest resquest)
        {
            await _blobService.UploadContentBlobAsync(resquest.content, resquest.fileName);
            return Ok();
        }
    }
}
