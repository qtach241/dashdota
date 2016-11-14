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

            // Failed to bind player's steam Id. Cannot proceed.
            if (gs.Player?.SteamID == null)
            {
                return BadRequest();
            }

            // Check if this game state was sent by a valid client.
            //if (gs.Auth.Token != "placeholder")
            //{
            //    return BadRequest();
            //}

            // Wait until we load into the map before logging game state.
            if (gs.Map == null)
            {
                return Ok();
            }

            // Valid game state must have a non-zero match Id.
            if (gs.Map.MatchId == "0")
            {
                return Ok();
            }

            // Only start logging game state if game is in progress.
            if (gs.Map.GameState != DOTA_GameState.DOTA_GAMERULES_STATE_GAME_IN_PROGRESS)
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
