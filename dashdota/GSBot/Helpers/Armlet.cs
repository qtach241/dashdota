using System;
using GSBot.Models;
using SIClass;

namespace GSBot.Helpers
{
    public class Armlet
    {
        /// <summary>
        /// Invokes the armlet toggle macro when flag is raised.
        /// </summary>
        /// <param name="state"></param>
        public static void ToggleArmlet(MasterState state)
        {
            //Console.WriteLine($"H: {gameStateCache.LastHealth}, D: {gameStateCache.LastDamageTaken}, C: {gameStateCache.LastChunkDamageTaken}, PSLC: {gameStateCache.PacketsSinceLastChunked}");

            if (state.ArmletToggleFlag && (state.SessionPackets > (state.sPreviousTogglePacket + 10)))
            {
                SendGameInput.T();
                //Console.WriteLine("Toggling Armlet");
                state.sPreviousTogglePacket = state.SessionPackets;
            }
        }
    }
}
