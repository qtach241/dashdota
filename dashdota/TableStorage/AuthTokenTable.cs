using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using TableStorage.Models;

namespace TableStorage
{
    public class AuthTokenTable : TableStorageClient<AuthTokenEntity>
    {
        public static AuthTokenTable Instance = new AuthTokenTable();

        public AuthTokenTable() : base(TableStorageNamespace.AuthTokenTable)
        {
        }

        /// <summary>
        /// Format the table storage partition key.
        /// </summary>
        /// <returns></returns>
        private static string GetPartitionKey(string steamId)
        {
            return steamId;
        }

        /// <summary>
        /// Replace an entity in this table asynchronously, or create
        /// the entity if it does not exist.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task AddEntityAsync(string steamId, string token)
        {
            try
            {
                await Instance.AddEntityAsync(new AuthTokenEntity(true)
                {
                    PartitionKey = GetPartitionKey(steamId),
                    RowKey = token,
                });
            }
            catch (Exception e)
            {
                await ExceptionTable.AddEntityAsync(e);
            }
        }

        /// <summary>
        /// Read the authentication token associated with steam Id asynchronously,
        /// which is stored as the row key. Return null if doesn't exist.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns>Token string as Rowkey</returns>
        public static async Task<string> GetAuthTokenAsync(string steamId)
        {
            string partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal, GetPartitionKey(steamId));

            var entities = await Instance.ReadEntityRangeAsync(partitionKeyFilter);

            return entities.FirstOrDefault()?.RowKey;
        }

        /// <summary>
        /// Check if the auth token associated with the steam Id is valid. Returns true if
        /// valid. Returns false if invalid or null.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static async Task<bool> IsTokenValidAsync(string steamId, string token)
        {
            AuthTokenEntity entity = await Instance.ReadEntityAsync(GetPartitionKey(steamId), token);

            if (entity == null)
            {
                return false;
            }

            return entity.IsValid;
        }

        /// <summary>
        /// Look up the table entity for a particular steam Id and auth token and modify
        /// the isValid property to the specified value.
        /// </summary>
        /// <param name="steamId"></param>
        /// <param name="token"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public static async Task ModifyTokenValidAsync(string steamId, string token, bool isValid)
        {
            AuthTokenEntity entity = await Instance.ReadEntityAsync(GetPartitionKey(steamId), token);

            if (entity == null)
            {
                return;
            }

            entity.IsValid = isValid;

            try
            {
                await Instance.AddOrReplaceEntityAsync(entity);
            }
            catch (Exception e)
            {
                await ExceptionTable.AddEntityAsync(e);
            }
        }
    }
}
