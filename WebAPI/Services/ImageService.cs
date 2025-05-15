using WebAPI.Contracts;

namespace WebAPI.Services
{
    public class ImageService : IImageService
    {
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            var path = Path.Combine("images", file.FileName);
            Directory.CreateDirectory("images");
            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return path;
        }

        public async Task<(byte[] fileContents, string contentType, string fileName)?> DownloadFileAsync(string fileName)
        {
            var path = Path.Combine("images", fileName);
            if (!File.Exists(path))
                return null;

            var fileContents = await File.ReadAllBytesAsync(path);
            var contentType = GetContentType(fileName);
            return (fileContents, contentType, fileName);
        }

        private string GetContentType(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLowerInvariant();
            return ext switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }
    }
}
