using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CloudStorageManager
{
    partial class AzureStorageManager
    {
        /// <summary>
        /// This method saves the data to azure table.
        /// </summary>
        /// <typeparam name="T">Table Type name</typeparam>
        /// <param name="tableName">azure table name</param>
        /// <param name="AzureTable">Azure Table object</param>
        public void SaveToTable<T>(string tableName, T AzureTable)
        {
            if (storageAccount == null)
                throw new NullReferenceException("Storage Account is null please check constructor.");
            
        }
    }
}
