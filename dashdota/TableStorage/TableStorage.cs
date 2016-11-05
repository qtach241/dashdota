using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableStorage
{
    public class TableStorage
    {
        private static Lazy<CloudStorageAccount> storageAccount;

        public TableStorage()
        {
            GetStorageAccount();
        }

        /// <summary>
        /// Get the storage account client from the cloud storage account connection string.
        /// </summary>
        private void GetStorageAccount()
        {
            storageAccount = new Lazy<CloudStorageAccount>(() =>
                CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureStorageEmulator")));
        }

        /// <summary>
        /// Get the reference to the storage table on the cloud. A valid table name must
        /// follow Azure storage naming rules:
        /// https://blogs.msdn.microsoft.com/jmstall/2014/06/12/azure-storage-naming-rules/
        /// </summary>
        /// <param name="table"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool GetTableReference(out CloudTable table, string tableName)
        {
            try
            {
                var tableClient = storageAccount.Value.CreateCloudTableClient();

                table = tableClient.GetTableReference(tableName);
                table.CreateIfNotExists();
                return true;

            }
            catch (Exception)
            {
                GetStorageAccount();
                table = null;
                return false;
            }
        }

        /// <summary>
        /// Asynchronously add an entity (i.e. row) to a table.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public async Task AddEntityAsync(ITableEntity entity, string tableName)
        {
            CloudTable table;

            var success = GetTableReference(out table, tableName);

            if (success)
            {
                try
                {
                    await table.ExecuteAsync(TableOperation.Insert(entity));
                }
                catch (Exception)
                {
                    // TODO: Log Exceptions
                }
            }
        }

        /// <summary>
        /// Asynchronously add an entity (i.e. row) to a table using a cancellation
        /// token to handle timeouts.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddEntityAsync(ITableEntity entity, string tableName, CancellationToken cancellationToken)
        {
            CloudTable table;

            var success = GetTableReference(out table, tableName);

            if (success)
            {
                try
                {
                    await table.ExecuteAsync(TableOperation.Insert(entity), cancellationToken);
                }
                catch (Exception)
                {
                    // TODO: Log Exceptions
                }
            }
        }

        /// <summary>
        /// Asynchronously replace an entity in a table.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="tableName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ReplaceEntityAsync(ITableEntity entity, string tableName, CancellationToken cancellationToken)
        {
            CloudTable table;

            var success = GetTableReference(out table, tableName);

            if (success)
            {
                try
                {
                    await table.ExecuteAsync(TableOperation.Replace(entity), cancellationToken);
                }
                catch (Exception)
                {
                    // TODO: Log Exceptions
                }
            }
        }
    }
}
