﻿using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;
using TableStorage.Models;
using System.Linq;

namespace TableStorage
{
    public class GameStateTable : TableStorageClient<GameStateEntity>
    {
        public static GameStateTable Instance = new GameStateTable();

        public GameStateTable() : base(TableStorageNamespace.GameStateTable)
        {
        }

        /// <summary>
        /// Format the table storage partition key.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        private static string GetPartitionKey(string steamId)
        {
            return steamId;
        }

        /// <summary>
        /// Insert a new entity into this table asynchronously.
        /// </summary>
        /// <param name="gs">GameState object</param>
        /// <returns></returns>
        public static async Task AddEntityAsync(GameState gs)
        {
            try
            {
                await Instance.AddEntityAsync(new GameStateEntity(gs)
                {
                    PartitionKey = GetPartitionKey(gs.Player.SteamID),
                    RowKey = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString(),
                });
            }
            catch (Exception e)
            {
                await ExceptionTable.AddEntityAsync(e);
            }
        }

        /// <summary>
        /// Query a range of entities from this table asynchronously. The query
        /// will only return the top result.
        /// </summary>
        /// <param name="steamId">steam Id string</param>
        /// <param name="rowKeyLower">lower rowkey bound</param>
        /// <param name="rowKeyUpper">upper rowkey bound</param>
        /// <returns></returns>
        public static async Task<GameStateEntity> GetLastGameStateAsync(string steamId,
            string rowKeyLower, string rowKeyUpper)
        {
            string partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal, GetPartitionKey(steamId));

            string rowKeyFilterLower = TableQuery.GenerateFilterCondition("RowKey",
                QueryComparisons.GreaterThanOrEqual, rowKeyLower);

            string rowKeyFilterUpper = TableQuery.GenerateFilterCondition("RowKey",
                QueryComparisons.LessThan, rowKeyUpper);

            string combinedRowKeyFilter = TableQuery.CombineFilters(rowKeyFilterLower,
                TableOperators.And, rowKeyFilterUpper);

            string combinedFilter = TableQuery.CombineFilters(partitionKeyFilter,
                TableOperators.And, combinedRowKeyFilter);

            var entities = await Instance.ReadEntityTopAsync(combinedFilter, 1);

            return entities.FirstOrDefault();
        }
    }
}
