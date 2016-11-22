using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Hosting;
using ModelsLibrary;
using TableStorage;

namespace TelemetryEndpoint.Controllers
{
    public class GameController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Index(GameState gs)
        {
            // Return a bad request if gamestate fails to bind.
            if (gs == null)
            {
                return BadRequest();
            }

            // Failed to bind player's steam Id or authentication token. Cannot proceed
            // with validiating the request.
            if ((gs.Player?.SteamID == null) || (gs.Auth?.Token == null))
            {
                return Ok();
            }

            // Prevent logging gamestate if the map has not yet loaded.
            if (gs.Map == null)
            {
                return Ok();
            }

            // Prevent logging game state for local lobbies or custom maps.
            if ((gs.Map.MatchId == "0") || (!string.IsNullOrEmpty(gs.Map.CustomeGameName)))
            {
                return Ok();
            }

            // Prevent logging game state if the game is not in-progress.
            if (gs.Map.GameState != DOTA_GameState.DOTA_GAMERULES_STATE_GAME_IN_PROGRESS)
            {
                return Ok();
            }

            // Check if the authentication token provided in the request is valid for
            // the user sending it.
            // TODO: We really need cache-aside for this.
            if (!await AuthTokenTable.IsTokenValidAsync(gs.Player.SteamID, gs.Auth.Token))
            {
                return Ok();
            }

            // Log gamestate in table storage.
            HostingEnvironment.QueueBackgroundWorkItem(ct =>
                GameStateTable.AddEntityAsync(gs));

            // Log match info in table storage.
            HostingEnvironment.QueueBackgroundWorkItem(ct =>
                TeamTable.AddOrReplaceEntityAsync(gs));

            return Ok();
        }
    }
}
