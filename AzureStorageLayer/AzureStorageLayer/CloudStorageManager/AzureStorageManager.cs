using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using System.Configuration;
using Common.StorageManagerExceptions;

namespace Common.CloudStorageManager
{
    partial class AzureStorageManager
    {
        CloudStorageAccount storageAccount;

        /// <summary>
        /// Initialize the StorageAccount. 
        /// If you are using this method please set storage connection string name as 'CloudStorageConnection'
        /// </summary>
        public AzureStorageManager()
        {
            try
            {
                storageAccount = CloudStorageAccount.Parse(
                        ConfigurationManager.ConnectionStrings["CloudStorageConnection"].ConnectionString);
            }
            catch (ConfigurationException ex)
            {
                throw new StorageConnectionNameNotFoundException(ex);
            }
        }
        /// <summary>
        /// Initilize the StorageAccount.
        /// </summary>
        /// <param name="storageConnectionName">storage conneciton string name same as in web.config/app.config</param>
        public AzureStorageManager(String storageConnectionName)
        {
            try
            {
                if (storageConnectionName != "")
                    storageAccount = CloudStorageAccount.Parse(
                        ConfigurationManager.ConnectionStrings[storageConnectionName].ConnectionString);
                else
                    throw new StorageConnectionNameNotFoundException("Storage Connection Name Not Found. Please Pass Connection Name In Constructor");
            }
            catch (ConfigurationException ex)
            {
                throw new StorageConnectionNameNotFoundException("please see inner exception for more details.",ex);
            }
        }
    }
}
