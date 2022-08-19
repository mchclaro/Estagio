using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace Domain.Interfaces.Services
{
    public interface IFileStorageService
    {
        Task UploadFile(Stream stream, string bucket, string objectName);
        Task UploadFileFromHttpIFormFile(IFormFile file, string bucket, string objectName);
        Task DeleteFile(string bucket, string objectName);
        Task DeleteFileFromUrl(string url);
        Task<byte[]> GetFileFromStorage(string bucket, string objectName);
        string GetFileUrl(string bucket, string objectName);
    }
}