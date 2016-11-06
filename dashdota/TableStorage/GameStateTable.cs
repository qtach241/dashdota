using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;
using TableStorage.Models;


namespace TableStorage
{
    public class GameStateTable
    {
        private static readonly TableStorage client = new TableStorage();

        /// <summary>
        /// Adds an entity to the specific table.
        /// </summary>
        /// <param name="gameState"></param>
        /// <returns></returns>
        public static async Task AddEntityAsync(GameState gameState)
        {
            try
            {
                CancellationTokenSource source = new CancellationTokenSource(
                    TimeSpan.FromMilliseconds(30000));

                await client.AddEntityAsync(new GameStateEntity(gameState),
                    "GameStateTable",
                    source.Token);
            }
            catch (Exception)
            {
                // TODO: Log Exceptions.
            }
        }

        /// <summary>
        /// Read a range of entities from the specific table.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<GameStateEntity>> ReadRangeAsync(int userId,
            string start, string end)
        {
            CloudTable table;

            if (client.GetTableReference(out table, "GameStateTable"))
            {
                string partitionKeyFilter = TableQuery
                    .GenerateFilterCondition(
                        "PartitionKey",
                        QueryComparisons.Equal,
                        userId.ToString());

                string rowKeyLowerFilter = TableQuery
                    .GenerateFilterCondition(
                        "RowKey",
                        QueryComparisons.GreaterThanOrEqual,
                        start);

                string rowKeyUpperFilter = TableQuery
                    .GenerateFilterCondition(
                        "RowKey",
                        QueryComparisons.LessThan,
                        end);

                string combinedRowKeyFilter = TableQuery
                    .CombineFilters(
                        rowKeyLowerFilter,
                        TableOperators.And,
                        rowKeyUpperFilter);

                string combinedFilter = TableQuery
                    .CombineFilters(
                        partitionKeyFilter,
                        TableOperators.And,
                        combinedRowKeyFilter);

                TableQuery<GameStateEntity> rangeQuery = new TableQuery<GameStateEntity>()
                    .Where(combinedFilter);

                List<GameStateEntity> entities = new List<GameStateEntity>();

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

            return null;
        }
    }
}




