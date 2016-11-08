using Dashboard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TableStorage;

namespace Dashboard.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> GetGameState(string key)
        {
            // TODO: Retrieve the last inserted entity in storage.
            var query = await GameStateTable.ReadEntityTopAsync(key, 0, "2519237194871412652", "2519237194890803761" );

            return new JsonNetResult(query);
        }
    }
}