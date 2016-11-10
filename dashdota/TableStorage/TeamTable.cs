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
        private static string GetPartitionKey(string matchId)
        {
            // TODO: Need to somehow get the side (radiant/dire) and
            // concatenate with matchId to form partition key.
            return matchId + "_" + "radiant";
        }

        /// <summary>
        /// Replace an entity in this table asynchronously, or create
        /// the entity if it does not exist.
        /// </summary>
        /// <param name="gs">GameState object</param>
        /// <returns></returns>
        public static async Task AddOrReplaceEntityAsync(GameState gs)
        {
            try
            {
                await Instance.AddOrReplaceEntityAsync(new TeamEntity()
                {
                    PartitionKey = GetPartitionKey(gs.Map.MatchId),
                    RowKey = gs.Player.SteamID,
                });
            }
            catch (Exception e)
            {
                await ExceptionTable.AddEntityAsync(e);
            }
        }

        /// <summary>
        /// Get a list of steamIds that are in the specified match.
        /// TODO: Currently gets all steamIds regardless of team, need to
        /// implement separation of teams.
        /// </summary>
        /// <param name="matchId"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<TeamEntity>> GetTeamMembersAsync(string matchId)
        {
            string partitionKeyFilter = TableQuery.GenerateFilterCondition("PartitionKey",
                QueryComparisons.Equal, GetPartitionKey(matchId));

            return await Instance.ReadEntityRangeAsync(partitionKeyFilter);
        }
    }
}
