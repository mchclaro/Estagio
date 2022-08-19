using System.IO;
using System.Threading.Tasks;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.FileService
{
    public class LocalStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly string _folder;
        public LocalStorageService(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _folder = "uploads";
        }

        public async Task DeleteFile(string bucket, string objectName)
        {
            await Task.Run(() => System.IO.File.Delete($"{_hostEnvironment.WebRootPath}/{_folder}/{objectName}"));
        }

        public async Task DeleteFileFromUrl(string url)
        {
            await Task.Run(() => System.IO.File.Delete($"{_hostEnvironment.WebRootPath}/{url}"));
        }

        public string GetFileUrl(string bucket, string objectName)
        {
            return $"/{_folder}/{objectName}";
        }

        public async Task UploadFile(Stream stream, string bucket, string objectName)
        {
            var dir = $"{_hostEnvironment.WebRootPath}/{_folder}";
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            using (var fileStream = new FileStream($"{dir}/{objectName}", FileMode.Create))
            {
                await stream.CopyToAsync(fileStream);
            }
        }

        public async Task<byte[]> GetFileFromStorage(string bucket, string objectName)
        {
            await Task.Delay(100);
            return new byte[] { };
        }

        public async Task UploadFileFromHttpIFormFile(IFormFile file, string bucket, string objectName)
        {
            using (var stream = file.OpenReadStream())
            {
                await UploadFile(stream, bucket, objectName);
            }
        }
    }
}