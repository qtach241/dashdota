using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;
using System.Collections.Generic;

namespace TableStorage
{
    public abstract class TableStorageClient<T>
        where T : ITableEntity, new()
    {
        protected TimeSpan timeout = TimeSpan.FromMilliseconds(500);
        protected string tableName;

        //private static CloudStorageAccount _account = CloudStorageAccount
        //    .Parse(ConfigurationManager.ConnectionStrings["storage"].ConnectionString);

        private static CloudStorageAccount _account = CloudStorageAccount
            .Parse(CloudConfigurationManager.GetSetting("AzureStorageEmulator"));

        protected TableStorageClient(string tableName)
        {
            this.tableName = tableName;
        }

        /// <summary>
        /// Attempt to get a reference to a storage table on the cloud, or
        /// create the table if it doesn't exist.
        /// </summary>
        /// <returns></returns>
        private CloudTable OpenOrCreateTable()
        {
            var tableClient = _account.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableName);

            table.CreateIfNotExists();

            return table;
        }

        /// <summary>
        /// Add a single entity (i.e. row) into a table.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected async Task AddEntityAsync(T entity)
        {
            CloudTable table = OpenOrCreateTable();

            var cancellationTokenSource = new CancellationTokenSource(timeout);

            await table.ExecuteAsync(TableOperation.Insert(entity),
                cancellationTokenSource.Token);
        }

        /// <summary>
        /// Read a range of entities from a storage table.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<T>> ReadEntityRangeAsync(string queryString)
        {
            CloudTable table = OpenOrCreateTable();

            TableQuery<T> rangeQuery = new TableQuery<T>()
                .Where(queryString);

            List<T> entities = new List<T>();

            TableContinuationToken continuationToken = null;

            do
            {
                var queryResult = await table
                    .ExecuteQuerySegmentedAsync(rangeQuery, continuationToken);

                continuationToken = queryResult.ContinuationToken;

                entities.AddRange(queryResult.Results);

            } while (continuationToken != null);

            return entities;
        }

        /// <summary>
        /// Read a range of entities from a storage table and return only the
        /// top entity.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        protected async Task<IEnumerable<T>> ReadEntityTopAsync(string queryString)
        {
            CloudTable table = OpenOrCreateTable();

            TableQuery<T> rangeQuery = new TableQuery<T>()
                .Where(queryString)
                .Take(1);

            List<T> entities = new List<T>();

            TableQuerySegment<T> currentSegment = null;
            
            do
            {
                currentSegment = await table.ExecuteQuerySegmentedAsync(rangeQuery, 
                    currentSegment != null ? currentSegment.ContinuationToken : null);

                entities.AddRange(currentSegment.Results);

            } while (entities.Count < rangeQuery.TakeCount && (currentSegment == null || currentSegment.ContinuationToken != null));

            return entities;
        }
    }
}
