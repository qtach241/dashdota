using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using ModelsLibrary;
using TableStorage.Models;

namespace TableStorage
{
    public class TeamTable : TableStorageClient<TeamEntity>
    {
        public static TeamTable Instance = new TeamTable();

        public TeamTable() : base(TableStorageNamespace.TeamTable)
        {
        }

        /// <summary>
        /// Format the table storage partition key.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        private static string GetPartitionKey(long matchId)
        {
            // TODO: Need to somehow get the side (radiant/dire) and
            // concatenate with matchId to form partition key.
            return matchId.ToString();
        }

        private static string GetPartitionKey(string matchId)
        {
            return matchId;
        }

        /// <summary>
        /// Insert a new entity into this table asynchronously.
        /// </summary>
        /// <param name="gs"></param>
        /// <returns></returns>
        public static async Task AddEntityAsync(GameState gs)
        {
            try
            {
                await Instance.AddEntityAsync(new TeamEntity()
                {
                    PartitionKey = GetPartitionKey(gs.Map.MatchId),
                    RowKey = gs.Player.SteamID,
                });
            }
            catch (Exception ex)
            {
                //await ExceptionTable.AddEntityAsync(ex);
            }
        }

        /// <summary>
        /// Get a list of steamIds that are in the specified match.
        /// TODO: Currently gets all steamIds regardless of team, need to
        /// implement separation of teams.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<TeamEntity>> GetTeamMembers(string matchId)
        {
            string partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal, GetPartitionKey(matchId));

            return await Instance.ReadEntityRangeAsync(partitionKeyFilter);
        }
    }
}
