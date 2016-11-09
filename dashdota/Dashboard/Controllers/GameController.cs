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
        [HttpGet]
        public async Task<ActionResult> GetGameState(string key)
        {
            List<GameStateEntity> gameStates = new List<GameStateEntity>();
            // TODO: Retrieve the last inserted entity in storage.
            //var query = await GameStateTable.ReadEntityTopAsync(key, 0, "2519237183479921096", "2519237183502842407" );

            var rowKeyLower = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString();
            var rowKeyUpper = rowKeyLower + TimeSpan.FromSeconds(10).Ticks;

            var test = TimeSpan.FromSeconds(10).Ticks;

            var query = await GameStateTable.ReadEntityTopAsync(key, rowKeyLower, rowKeyUpper);
            var first = query.FirstOrDefault();

            if (first != null)
            {
                var matchId = first.MatchId;

                var team = await TeamTable.GetTeamMembers(matchId);

                foreach (var member in team)
                {
                    var steamId = member.RowKey;

                    var memberQuery = await GameStateTable.ReadEntityTopAsync(key, rowKeyLower, rowKeyUpper);

                    if (memberQuery != null)
                    {
                        gameStates.Add(memberQuery.First());
                    }
                }
            }

            return new JsonNetResult(gameStates);
        }
    }
}