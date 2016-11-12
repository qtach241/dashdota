using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        private static string GetPartitionKey()
        {
            return "Token";
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
                await Instance.AddEntityAsync(new AuthTokenEntity(token)
                {
                    PartitionKey = GetPartitionKey(),
                    RowKey = steamId,
                });
            }
            catch (Exception e)
            {
                await ExceptionTable.AddEntityAsync(e);
            }
        }

        /// <summary>
        /// Read the authentication token associated with steam Id asynchronously.
        /// Return null if doesn't exist.
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns>Token string</returns>
        public static async Task<string> GetAuthTokenAsync(string steamId)
        {
            AuthTokenEntity entity = await Instance.ReadEntityAsync(GetPartitionKey(), steamId);

            return entity?.Token;
        }
    }
}
