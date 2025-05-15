using Microsoft.AspNetCore.Mvc;
using WebAPI.Contracts;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IImageService _imageService;

    public FileController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var path = await _imageService.UploadFileAsync(file);
        return Ok(new { path });
    }

    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> Download(string fileName)
    {
        var result = await _imageService.DownloadFileAsync(fileName);
        if (result == null)
            return NotFound();

        var (fileContents, contentType, downloadFileName) = result.Value;
        return File(fileContents, contentType, downloadFileName);
    }
}
