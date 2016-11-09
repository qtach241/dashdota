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

namespace Dashboard.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GetGameState(string key)
        {
            // TODO: Retrieve the last inserted entity in storage.
            var query = await GameStateTable.ReadEntityTopAsync(key, 0, "2519237183479921096", "2519237183502842407" );

            return new JsonNetResult(query);
        }
    }
}