using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Domain.Interfaces.Services
{
    public interface IFileStorageServiceS3
    {
        Task<bool> UploadFileFromHttpIFormFile(string bucket, string key, IFormFile file);
        Task DeleteFileFromUrlS3(string url);
        string GetFileUrlS3(string fileName);
    }
}