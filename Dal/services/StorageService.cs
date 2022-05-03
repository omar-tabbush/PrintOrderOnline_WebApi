/*using Azure.Storage.Blobs;
using Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace WebApiFileUpload.Services
{
    public class StorageService : IStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        private readonly IConfiguration _configuration;
        public StorageService(
            BlobServiceClient blobServiceClient,
            IConfiguration configuration)
        {
            _blobServiceClient = blobServiceClient;
            _configuration = configuration;
        }


        public void Upload(IFormFile files, DocumentFiles document)
        {
            int x = 0;
            string systemFileName = x++ + "_" + files.FileName + "_" + DateTime.Now;
            document.DocumentFileName = systemFileName;
            document.FileSize = files.Length;
            document.UploadDate = DateTime.Now;
            document.FileFormat = files.ContentType;
            string blobstorageconnection = _configuration.GetValue<string>("BlobConnectionString");
            // Retrieve storage account from connection string.    
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            // Create the blob client.    
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            // Retrieve a reference to a container.    
            CloudBlobContainer container = blobClient.GetContainerReference(_configuration.GetValue<string>("BlobContainerName"));
            // This also does not make a service call; it only creates a local object.    
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(systemFileName);
            using (var data = files.OpenReadStream())
            {
                blockBlob.UploadFromStreamAsync(data);
            }

        }
        public void DownloadFile(string fileName)
        {
            CloudBlockBlob blockBlob;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                string blobstorageconnection = _configuration.GetValue<string>("BlobConnectionString");
                CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
                CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(_configuration.GetValue<string>("BlobContainerName"));
                blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                blockBlob.DownloadToStreamAsync(memoryStream);
            }
            Stream blobStream = blockBlob.OpenReadAsync().Result;
        }
        public void DeleteFile(string fileName)
        {
            string blobstorageconnection = _configuration.GetValue<string>("BlobConnectionString");
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            string strContainerName = _configuration.GetValue<string>("BlobContainerName");
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
            var blob = cloudBlobContainer.GetBlobReference(fileName);
            blob.DeleteIfExistsAsync();
        }
    }
}*/