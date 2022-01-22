using System;
using System.Windows.Forms;
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
            //Console.WriteLine($"H: {state.LastHealth}, D: {state.LastDamageTaken}, C: {state.LastChunkDamageTaken}, PSLC: {state.PacketsSinceLastChunked}");

            if (state.ArmletToggleFlag && (state.SessionPackets > (state.sPreviousTogglePacket + 10)))
            {
                SendGameInput.SendKeyAsInput(Keys.T);
                //Console.WriteLine("Toggling Armlet");
                state.sPreviousTogglePacket = state.SessionPackets;
            }
        }
    }
}
