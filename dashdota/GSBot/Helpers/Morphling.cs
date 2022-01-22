using System;
using System.Windows.Forms;
using GSBot.Models;
using SIClass;

namespace GSBot.Helpers
{
    public class Morphling
    {
        public static void Morph(MasterState state)
        {
            switch(state.sMorphlingState)
            {
                case MorphState.Idle:
                    if (state.HealthPercent < 33 || state.LinkensDown)
                    {
                        if (state.Abilities[3].CanCastActual)
                        {
                            Console.WriteLine("Morphing Strength");
                            MorphStrength();
                            state.sMorphlingState = MorphState.StartMorphStrength;
                            break;
                        }
                        Console.WriteLine("Tried to morph strength but couldn't cast... trying again.");
                    }
                    break;

                case MorphState.StartMorphStrength:
                    if (state.HealthPercent >= 50)
                    {
                        if (state.Abilities[3].CanCastActual)
                        {
                            Console.WriteLine("Stop Morphing");
                            StopMorphing();
                            state.sMorphlingState = MorphState.Idle;
                            break;
                        }
                        Console.WriteLine("Tried to stop morphing but couldn't cast... trying again");
                    }
                    break;
            }
        }

        public static void MorphAgility()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad1);
        }

        public static void MorphStrength()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad0);
        }

        public static void StopMorphing()
        {
            // This combination will stop morphing regardless of state
            MorphStrength();
            MorphAgility();
            MorphAgility();
        }

        //private MorphState morphState { get; set; } = MorphState.Idle;
    }
}
