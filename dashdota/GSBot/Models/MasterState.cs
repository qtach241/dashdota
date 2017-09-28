using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBot.Models
{
    public class MasterState : GameStateCache
    {
        public MasterState() : base()
        {
        }

        public string sPreviousHeroName { get; set; }
        public int sPreviousTogglePacket { get; set; }
        public bool sPullReadyFlag { get; set; }
        public bool sPullCountdownFlag { get; set; }
    }
}
