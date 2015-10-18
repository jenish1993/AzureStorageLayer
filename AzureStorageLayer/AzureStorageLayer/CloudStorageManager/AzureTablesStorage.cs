using AzureStorageLayer.StorageManagerExceptions;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageLayer.CloudStorageManager
{
    partial class AzureStorageManager
    {
        #region Public code minimizer methods
        /// <summary>
        /// creates and save the azure table to azure table storage.
        /// </summary>
        /// <typeparam name="T">Table Type name</typeparam>
        /// <param name="tableName">azure table name</param>
        /// <param name="AzureTable">Azure Table object</param>
        public void SaveToTable(string tableName, TableEntity AzureTable)
        {
            if (storageAccount == null)
                throw new NullReferenceException("Storage Account is null please check constructor.");
            CloudTable table = getTable(tableName);
            TableOperation insertOperation = TableOperation.Insert(AzureTable);
            table.Execute(insertOperation);
        }
        /// <summary>
        /// Insert or Replaces the azure table to azure table storage.
        /// </summary>
        /// <param name="tableName">azure table name</param>
        /// <param name="AzureTable">table object</param>
        public void UpdateToTable(string tableName, TableEntity AzureTable)
        {
            if (storageAccount == null)
                throw new NullReferenceException("Storage Account is null please check constructor.");
            try
            {
                CloudTable table = getTable(tableName);
                TableOperation updateOperation = TableOperation.InsertOrReplace(AzureTable);
                table.Execute(updateOperation);
            }
            catch (Exception ex)
            {
                throw new StorageOperationException("Table Updation Excetion.  please see inner exception for more details.", ex);
            }
        }

        public void DeleteToTable(string tableName, TableEntity AzureTable)
        {
            if (storageAccount == null)
                throw new NullReferenceException("Storage Account is null please check constructor.");
            try
            {
                CloudTable table = getTable(tableName);
                TableOperation deleteOperation = TableOperation.Delete(AzureTable);
                table.Execute(deleteOperation);
            }
            catch (Exception ex)
            {
                throw new StorageOperationException("Table Deletation Exception. please see inner exception for more details.", ex);
            }
        }

        /// <summary>
        /// Gets all table record based on the table name form the azure table storage.
        /// </summary>
        /// <param name="tableName">azure table name</param>
        /// <param name="filter">filter</param>
        /// <param name="columns">column to select</param>
        /// <returns></returns>
        public IEnumerable<DynamicTableEntity> GetTableData(
            string tableName,
            string filter = "",
            IList<string> columns = null)
        {
            CloudTable table = getTable(tableName);
            TableQuery query = new TableQuery();

            if (filter != string.Empty)
                query.FilterString = filter;
            if (columns != null)
                query.Select(columns);

            return table.ExecuteQuery(query);
        }
        #endregion

        #region Azure Table Storage Utility Methods
        /// <summary>
        /// returns the azure table based on the table name.
        /// </summary>
        /// <param name="tableName">azure table name</param>
        /// <returns></returns>
        private CloudTable getTable(string tableName)
        {
            CloudTableClient cloudTable = storageAccount.CreateCloudTableClient();
            CloudTable table = cloudTable.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }
        #endregion
    }
}
