using Microsoft.AspNetCore.Mvc;
using react_movies_api_net.Services.Storage;

namespace react_movies_api_net.Features.Storage
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileStorageService _storageService;

        public FileController(IFileStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost("/upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var response = await _storageService.Store(file);
            return Ok(response);
        }

        [HttpGet("/download/{filename}")]
        public async Task<IActionResult> DownloadFile([FromRoute] string filename)
        {
            var response = await _storageService.Load(filename);
            return File(response.Item1, response.Item3, response.Item2);
        }
    }
}
