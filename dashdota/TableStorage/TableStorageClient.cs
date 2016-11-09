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
        /// Read a single entity (i.e. row) from a table.
        /// </summary>
        /// <param name="partitionKey"></param>
        /// <param name="rowKey"></param>
        /// <returns></returns>
        protected async Task<T> ReadEntityAsync(string partitionKey, string rowKey)
        {
            CloudTable table = OpenOrCreateTable();

            var cancellationTokenSource = new CancellationTokenSource(timeout);

            TableResult retrievedResult = await table.ExecuteAsync(TableOperation.Retrieve<T>(partitionKey, rowKey), 
                cancellationTokenSource.Token);

            return (T)retrievedResult.Result;
        }

        /// <summary>
        /// Completely replace an entire row, or add it if it does not exist.
        /// This function is mainly intended for key value pairs (single property)
        /// tables as there is no read-modify-write of individual properties.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected async Task AddOrReplaceEntityAsync(T entity)
        {
            CloudTable table = OpenOrCreateTable();

            var cancellationTokenSource = new CancellationTokenSource(timeout);

            TableResult retrievedResult = await table.ExecuteAsync(TableOperation.Retrieve<T>(entity.PartitionKey, entity.RowKey),
                cancellationTokenSource.Token);

            T updateEntity = (T)retrievedResult.Result;

            if (updateEntity != null)
            {
                updateEntity = entity;

                await table.ExecuteAsync(TableOperation.InsertOrReplace(updateEntity),
                    cancellationTokenSource.Token);
            }
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

        /// <summary>
        /// Delete a single entity (i.e. row) from a table.
        /// </summary>
        /// <param name="partitionKey"></param>
        /// <param name="rowKey"></param>
        /// <returns></returns>
        protected async Task DeleteEntityAsync(string partitionKey, string rowKey)
        {
            CloudTable table = OpenOrCreateTable();

            var cancellationTokenSource = new CancellationTokenSource(timeout);

            TableResult retrievedResult = await table.ExecuteAsync(TableOperation.Retrieve<T>(partitionKey, rowKey),
                cancellationTokenSource.Token);

            T deleteEntity = (T)retrievedResult.Result;

            if (deleteEntity != null)
            {
                await table.ExecuteAsync(TableOperation.Delete(deleteEntity),
                    cancellationTokenSource.Token);
            }
        }
    }
}
