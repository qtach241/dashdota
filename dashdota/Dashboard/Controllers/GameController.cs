using Dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary;
using TableStorage;
using TableStorage.Models;

namespace Dashboard.Controllers
{
    public class GameController : Controller
    {
        /// <summary>
        /// AJAX handler that returns a list of game state objects in Json form,
        /// one for each team member.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetGameState(string key)
        {
            // Create an empty list of game states.
            List<GameStateEntity> gameStates = new List<GameStateEntity>();

            // Set valid time range to 10 seconds in the past. Otherwise,
            // the game state is considered stale and won't be queried.
            var rowKeyLower = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString();
            var rowKeyUpper = ((DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks)
                + TimeSpan.FromSeconds(10).Ticks).ToString();

            // Get the most recent game state from the steam Id passed in.
            var gameState = await GameStateTable.GetLastGameState(key, rowKeyLower, rowKeyUpper);

            // If game state exists and valid for the current steam Id.
            if (gameState != null)
            {
                // Add the current game state to the list.
                gameStates.Add(gameState);

                // Use the current game state's MatchId to see if any other
                // users are sending game sense telemetry within the same match.
                var team = await TeamTable.GetTeamMembers(gameState.MatchId);

                foreach (var member in team)
                {
                    // Get each member's steam Id from the RowKey property.
                    var steamId = member.RowKey;

                    // Skip the case when we're querying ourselves twice.
                    if (steamId == key)
                    {
                        continue;
                    }

                    // Get the most recent game state for each member found.
                    var memberGameState = await GameStateTable.GetLastGameState(steamId, rowKeyLower, rowKeyUpper);

                    if (memberGameState != null)
                    {
                        // If game state exists and valid, add it to the list.
                        gameStates.Add(memberGameState);
                    }
                }
            }

            // Return the game state list in Json format.
            return new JsonNetResult(gameStates);
        }
    }
}