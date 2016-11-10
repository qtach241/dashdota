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
