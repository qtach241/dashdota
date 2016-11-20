using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ModelsLibrary;
using TableStorage;
using TableStorage.Models;
using Dashboard.Models;

namespace Dashboard.Controllers
{
    public class GameController : Controller
    {
        /// <summary>
        /// AJAX handler that returns a list of game state objects in Json form,
        /// one for each team member.
        /// </summary>
        /// <param name="id">steam Id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetGameState(string id)
        {
            // Create an empty list of game states.
            List<GameStateEntity> gameStates = new List<GameStateEntity>();

            // Return immediately if Id is empty.
            if (string.IsNullOrEmpty(id))
            {
                return new JsonNetResult(new GameStateModel());
            }

            // Set valid time range to 10 seconds in the past. Otherwise,
            // the game state is considered stale and won't be queried.
            var rowKeyLower = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString();
            var rowKeyUpper = (DateTime.MaxValue.Ticks - (DateTime.UtcNow.Ticks - TimeSpan.FromSeconds(10).Ticks)).ToString();

            // Get the most recent game state from the steam Id passed in.
            var gameState = await GameStateTable.GetLastGameStateAsync(id, rowKeyLower, rowKeyUpper);

            // If game state exists and valid for the current steam Id.
            if (gameState != null)
            {
                // Add the current game state to the list.
                gameStates.Add(gameState);

                // Use the current game state's MatchId and Team name to see if any other
                // players are sending game sense telemetry within the same team.
                var team = await TeamTable.GetTeamMembersAsync(gameState.MatchId, gameState.Team);

                foreach (var member in team)
                {
                    // Get each member's steam Id from the RowKey property.
                    var steamId = member.RowKey;

                    // Skip the case when we're querying ourselves twice.
                    if (steamId == id)
                    {
                        continue;
                    }

                    // Get the most recent game state for each member found.
                    var memberGameState = await GameStateTable.GetLastGameStateAsync(steamId, rowKeyLower, rowKeyUpper);

                    if (memberGameState != null)
                    {
                        // If game state exists and valid, add it to the list.
                        gameStates.Add(memberGameState);
                    }
                }
            }

            // Order the complete list of game states by networth.
            gameStates.OrderByDescending(o => o.Networth);

            // Return the game state model in Json format.
            return new JsonNetResult(new GameStateModel(gameStates));
        }

        /// <summary>
        /// Action handler that generates and downloads the game sense integration
        /// configuration file.
        /// </summary>
        /// <param name="id">steam Id</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DownloadConfig(string id)
        {
            // Check if this user already has an auth token.
            var token = await AuthTokenTable.GetAuthTokenAsync(id);

            if (string.IsNullOrEmpty(token))
            {
                // Generate a new auth token.
                token = Guid.NewGuid().ToString();

                // Store the steam Id and auth token.
                await AuthTokenTable.AddEntityAsync(id, token);
            }

            // Generate and download the config file.
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);

            tw.WriteLine("\"Dota 2 Integration Configuration\"");
            tw.WriteLine("{");
            tw.WriteLine("    \"uri\"           \"http://dashdota-api.azurewebsites.net/api/game\"");
            tw.WriteLine("    \"timeout\"       \"5.0\"");
            tw.WriteLine("    \"buffer\"        \"0.1\"");
            tw.WriteLine("    \"throttle\"      \"0.1\"");
            tw.WriteLine("    \"heartbeat\"     \"50.0\"");
            tw.WriteLine("    \"auth\"");
            tw.WriteLine("    {");
            tw.WriteLine("        \"token\"         \"{0}\"", token);
            tw.WriteLine("    }");
            tw.WriteLine("    \"data\"");
            tw.WriteLine("    {");
            tw.WriteLine("        \"provider\"      \"1\"");
            tw.WriteLine("        \"map\"           \"1\"");
            tw.WriteLine("        \"player\"        \"1\"");
            tw.WriteLine("        \"hero\"          \"1\"");
            tw.WriteLine("        \"abilities\"     \"1\"");
            tw.WriteLine("        \"items\"         \"1\"");
            tw.WriteLine("    }");
            tw.WriteLine("}");
            tw.Flush();
            tw.Close();

            return File(memoryStream.GetBuffer(), "text/plain", "gamestate_integration_dashdota.cfg");
        }
    }
}