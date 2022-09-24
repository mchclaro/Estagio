using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.FileService
{
    public class CloudStorageService : IFileStorageServiceS3
    {
        public string AwsKeyID { get; set; }
        public string AwsKeySecret { get; set; }
        public BasicAWSCredentials AWSCredentials { get; private set; }
        private readonly IAmazonS3 _awsS3Client;
        private const string BucketName = "service-manager-estagio";

        public CloudStorageService()
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
            var request = new GetPreSignedUrlRequest()
            {
                BucketName = BucketName,
                Key = fileName,
                Expires = DateTime.UtcNow.AddMinutes(5),
            };

            return _awsS3Client.GetPreSignedURL(request);
        }

        public async Task DeleteFileFromUrlS3(string url)
        {
            var response = await _awsS3Client.DeleteObjectAsync(BucketName, url);
            // var response = new DeleteObjectRequest
            // {
            //     BucketName = BucketName,
            //     Key = url
            // };

            // await _awsS3Client.DeleteObjectAsync(response);
        }
    }
}