using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Contracts
{
    public interface IImageService
    {
        Task<string> UploadFileAsync(IFormFile file);

        // Add this method for file download
        Task<(byte[] fileContents, string contentType, string fileName)?> DownloadFileAsync(string fileName);
    }
}
