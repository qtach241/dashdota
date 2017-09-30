using GSBot.Models;
using SIClass;

namespace GSBot.Helpers
{
    public class Invoker
    {
        private enum Spells
        {
            None,
            Coldsnap,
            Ghostwalk,
            Icewall,
            Tornado,
            Emp,
            Alacrity,
            Forge,
            Meteor,
            Sunstrike,
            DeafeningBlast
        }

        private enum ComboState
        {
            Waiting,
            Invoke,
            Cast,
            WaitForCastFinish,
        }

        static Spells SpellSlot1 = Spells.None;
        static Spells SpellSlot2 = Spells.None;

        static ComboState comboState;

        /// <summary>
        /// Deafening Blast, Meteor, Sunstrike combo
        /// </summary>
        /// <param name="state"></param>
        public static void Combo(MasterState state)
        {
            switch (comboState)
            {
                case ComboState.Waiting:
                    break;

                case ComboState.Cast:
                    CastSunstrike(state);
                    break;

                case ComboState.WaitForCastFinish:

                    break;
            }
        }

        private static void CastGhostwalk(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("ability_ghost_walk"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                SendGameInput.T();
                return;
            }

            if (Slot2.Name.Equals("ability_ghost_walk"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                SendGameInput.G();
                return;
            }

            InvokeGhostwalk();
            CastGhostwalk(state);
        }

        private static void CastSunstrike(MasterState state)
        {
            if (state.Abilities[3].Name.Equals("ability_sunstrike"))
            {
                SendGameInput.T();
                comboState = ComboState.WaitForCastFinish;
                return;
            }

            if (state.Abilities[4].Name.Equals("ability_sunstrike"))
            {
                SendGameInput.G();
                comboState = ComboState.WaitForCastFinish;
                return;
            }

            InvokeSunstrike();
        }

        public static void CastDeafeningBlast(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("ability_deafening_blast"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                SendGameInput.T();
                return;
            }

            if (Slot2.Name.Equals("ability_deafening_blast"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                SendGameInput.G();
                return;
            }

            InvokeDeafeningBlast();
            CastDeafeningBlast(state);
        }

        private static void InvokeColdsnap()
        {
            SendGameInput.Q();
            SendGameInput.Q();
            SendGameInput.Q();
            SendGameInput.R();
        }

        private static void InvokeGhostwalk()
        {
            SendGameInput.Q();
            SendGameInput.Q();
            SendGameInput.W();
            SendGameInput.R();
        }

        private static void InvokeIcewall()
        {
            SendGameInput.Q();
            SendGameInput.Q();
            SendGameInput.E();
            SendGameInput.R();
        }

        private static void InvokeTornado()
        {
            SendGameInput.W();
            SendGameInput.W();
            SendGameInput.Q();
            SendGameInput.R();
        }

        private static void InvokeEmp()
        {
            SendGameInput.W();
            SendGameInput.W();
            SendGameInput.W();
            SendGameInput.R();
        }

        private static void InvokeAlacrity()
        {
            SendGameInput.W();
            SendGameInput.W();
            SendGameInput.E();
            SendGameInput.R();
        }

        private static void InvokeForgeSpirits()
        {
            SendGameInput.E();
            SendGameInput.E();
            SendGameInput.Q();
            SendGameInput.R();
        }

        private static void InvokeMeteor()
        {
            SendGameInput.E();
            SendGameInput.E();
            SendGameInput.W();
            SendGameInput.R();
        }

        private static void InvokeSunstrike()
        {
            SendGameInput.E();
            SendGameInput.E();
            SendGameInput.E();
            SendGameInput.R();
        }

        public static void InvokeDeafeningBlast()
        {
            SendGameInput.Q();
            SendGameInput.W();
            SendGameInput.E();
            SendGameInput.R();
        }
    }
}
