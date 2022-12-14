using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.FileService
{
    public class S3AmazonStorageService : IFileStorageServiceS3
    {
        public string AwsKeyID { get; set; }
        public string AwsKeySecret { get; set; }
        public BasicAWSCredentials AWSCredentials { get; private set; }
        private readonly IAmazonS3 _awsS3Client;
        private const string BucketName = "service-manager-estagio";

        public S3AmazonStorageService()
        {
            AwsKeyID = "AKIAXLC2NDNZSM7ZKL6S";
            AwsKeySecret = "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";
            AWSCredentials = new BasicAWSCredentials(AwsKeyID, AwsKeySecret);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };
            _awsS3Client = new AmazonS3Client(AWSCredentials, config);
        }

        public async Task<bool> UploadFileFromHttpIFormFile(string bucket, string key, IFormFile file)
        {
            using var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);

            var fileTransferUtility = new TransferUtility(_awsS3Client);

            await fileTransferUtility.UploadAsync(new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                Key = key,
                BucketName = bucket,
                ContentType = file.ContentType
            });

            return true;
        }

        public string GetFileUrlS3(string fileName)
        {
            // var client = new AmazonS3Client();

            var request = new GetPreSignedUrlRequest()
            {
                BucketName = BucketName,
                Key = fileName,
                Expires = DateTime.UtcNow.AddSeconds(300),
            };

            // var presignedUrlResponse = client.GetPreSignedURL(request);
            // return presignedUrlResponse;

            return _awsS3Client.GetPreSignedURL(request);

            // var client = new AmazonS3Client();
            // var request = new GetPreSignedUrlRequest()
            // {
            //     BucketName = BucketName,
            //     Key = fileName,
            // };
            // var file = await client.GetObjectAsync(BucketName, fileName);
            // return GetIActionResult(file.ResponseStream, file.Headers.ContentType);

        }

        public async Task DeleteFileFromUrlS3(string url)
        {
            var client = new AmazonS3Client();
            var response = await client.DeleteObjectAsync(BucketName, url);
        }
        
    }
}