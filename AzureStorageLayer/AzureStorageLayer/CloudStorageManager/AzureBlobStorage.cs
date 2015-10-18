using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageLayer.CloudStorageManager
{
    public partial class AzureStorageManager
    {
        /// <summary>
        /// returns the blob container. it creates the blob if not exits.
        /// make sure azure as pay you go can make you paid for the blob and queue.
        /// </summary>
        /// <param name="blobName"></param>
        /// <returns></returns>
        public CloudBlobContainer getBlobContainer(string blobName)
        {
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(blobName);
            blobContainer.CreateIfNotExists();
            return blobContainer;
        }
        /// <summary>
        /// returns you the blob object.
        /// </summary>
        /// <param name="containerName">blob container name. In which container the blob is present.</param>
        /// <param name="blobName">blob name.</param>
        /// <returns></returns>
        public CloudBlockBlob getBlob(string containerName, string blobName)
        {
            return getBlobContainer(containerName).GetBlockBlobReference(blobName);
        }

        /// <summary>
        /// upload the stuff to the blob.
        /// </summary>
        /// <param name="FilePath">File path of the</param>
        public void UploadToBlob(string containerName, string blobName, string FilePath)
        {
            using (var fileStream = System.IO.File.OpenRead(FilePath))
            {
                getBlob(containerName, blobName).UploadFromStream(fileStream);
            }
        }

        /// <summary>
        /// upload the stuff to the blob.
        /// </summary>
        /// <param name="file">File</param>
        public void UploadToBlob(string containerName, string blobName, FileStream file)
        {
            using (var fileStream = file)
            {
                getBlob(containerName, blobName).UploadFromStream(fileStream);
            }
        }
        
    }
}
