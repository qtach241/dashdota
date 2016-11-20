using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TableStorage.Models;

namespace Dashboard.Models
{
    public class GameStateModel
    {
        public GameStateModel()
        {
        }

        public GameStateModel(List<GameStateEntity> gameStateEntities)
        {
            GameStates = gameStateEntities;

            foreach (var entity in gameStateEntities)
            {
                if (!entity.NoDetection)
                {
                    Alerts.NoDetection = false;
                    break;
                }
            }

            foreach (var entity in gameStateEntities)
            {
                if (entity.ObsOffCooldown)
                {
                    Alerts.ObsOffCooldown = true;
                    break;
                }
            }
        }

        public List<GameStateEntity> GameStates { get; set; }  = new List<GameStateEntity>();

        // Team wide alerts
        public TeamWideAlerts Alerts { get; set; } = new TeamWideAlerts();
    }

    public class TeamWideAlerts
    {
        public TeamWideAlerts()
        {
        }

        public bool NoDetection { get; set; } = true;
        public bool ObsOffCooldown { get; set; } = false;
    }
}