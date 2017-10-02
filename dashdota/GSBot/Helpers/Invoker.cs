using System.Windows.Forms;
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
            CastMeteor,
            WaitForMeteorCastFinish,
            CastDeafeningBlast,
            WaitForDeafeningBlastFinish,
            InvokeSunstrike,
            CastSunstrike,
            WaitForSunstrikeFinish,
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
            }
        }

        public static void CastColdsnap(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_cold_snap"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_cold_snap"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeColdsnap();
        }

        public static void CastGhostwalk(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_ghost_walk"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_ghost_walk"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeGhostwalk();
        }

        public static void CastIcewall(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_ice_wall"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_ice_wall"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeIcewall();
        }

        public static void CastTornado(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_tornado"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_tornado"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeTornado();
        }

        public static void CastEmp(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_emp"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_emp"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeEmp();
        }

        public static void CastAlacrity(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_alacrity"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_alacrity"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeAlacrity();
        }

        public static void CastForgeSpirit(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_forge_spirit"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_forge_spirit"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeForgeSpirit();
        }

        public static void CastMeteor(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_chaos_meteor"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_chaos_meteor"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeMeteor();
        }

        public static void CastSunstrike(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_sun_strike"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_sun_strike"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeSunstrike();
        }

        public static void CastDeafeningBlast(MasterState state)
        {
            var Slot1 = state.Abilities[3];
            var Slot2 = state.Abilities[4];

            if (Slot1.Name.Equals("invoker_deafening_blast"))
            {
                if (Slot1.Cooldown > 0)
                    return;

                CastSpellSlot1();
                return;
            }

            if (Slot2.Name.Equals("invoker_deafening_blast"))
            {
                if (Slot2.Cooldown > 0)
                    return;

                CastSpellSlot2();
                return;
            }

            InvokeDeafeningBlast();
        }

        private static void InvokeColdsnap()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad1);
        }

        private static void InvokeGhostwalk()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad2);
        }

        private static void InvokeIcewall()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad3);
        }

        private static void InvokeTornado()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad4);
        }

        private static void InvokeEmp()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad5);
        }

        private static void InvokeAlacrity()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad6);
        }

        private static void InvokeForgeSpirit()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad7);
        }

        private static void InvokeMeteor()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad8);
        }

        private static void InvokeSunstrike()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad9);
        }

        public static void InvokeDeafeningBlast()
        {
            SendGameInput.SendKeyAsInput(Keys.NumPad0);
        }

        public static void CastSpellSlot1()
        {
            SendGameInput.SendKeyAsInput(Keys.Divide);
        }

        public static void CastSpellSlot2()
        {
            SendGameInput.SendKeyAsInput(Keys.Multiply);
        }
    }
}
