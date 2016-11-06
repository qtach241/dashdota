﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ModelsLibrary;
using TableStorage;

namespace TelemetryEndpoint.Controllers
{
    public class GameController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Index(GameState gs)
        {
            var stream = await Request.Content.ReadAsStreamAsync();

            // Log gamestate in table storage.
            await GameStateTable.AddEntityAsync(gs);

            return Ok();
        }
    }
}
