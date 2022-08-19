// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Domain.Interfaces.Services;
// using Microsoft.AspNetCore.Http;

// namespace Infrastructure.FileService
// {
//     public class CloudStorageService : IFileStorageService
//     {
//         private readonly StorageClient _storage;

//         private readonly string _baseUrl;

//         public CloudStorageService()
//         {
//             //aqui seria o da aws s3
//             _storage = StorageClient.Create();
//             _baseUrl = "https://storage.googleapis.com/";
//         }

//         public async Task DeleteFile(string bucket, string objectName)
//         {
//             await _storage.DeleteObjectAsync(bucket, objectName);
//         }

//         public async Task DeleteFileFromUrl(string url)
//         {
//             (string bucket, string objectName) = GetBucketAndNameFromUrl(url);
//             await DeleteFile(bucket, objectName);
//         }

//         public string GetFileUrl(string bucket, string objectName)
//         {
//             return $"{_baseUrl}{bucket}/{objectName}";
//         }

//         public async Task UploadFile(Stream stream, string bucket, string objectName)
//         {
//             await _storage.UploadObjectAsync(bucket, objectName, null, stream);
//         }

//         public async Task UploadFileFromHttpIFormFile(IFormFile file, string bucket, string objectName)
//         {
//             using (var stream = file.OpenReadStream())
//             {
//                 await UploadFile(stream, bucket, objectName);
//             }
//         }

//         public async Task<byte[]> GetFileFromStorage(string bucket, string objectName)
//         {
//             using (var stream = new MemoryStream())
//             {
//                 await _storage.DownloadObjectAsync(bucket, objectName, stream);

//                 return stream.ToArray();
//             }
//         }

//         private (string bucket, string objectName) GetBucketAndNameFromUrl(string url)
//         {
//             url = url.Replace(_baseUrl, "");
//             var split = url.Split("/");
//             return (split[0], string.Join("/", split.Skip(1)));
//         }
//     }
// }