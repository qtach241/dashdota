using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using GSClient;
using GSBot.Helpers;
using GSBot.Models;

namespace GSBot
{
    class Program
    {
        static GameStateListener _gsl;
        static MasterState state = new MasterState();

        public delegate void HeroProfile(MasterState state);

        static string versionStr = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        static string buildStr = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime.ToString();
        static string scriptsDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Scripts/bin/";

        /// <summary>
        /// Main initialization routine.
        /// </summary>
        static void Initialize()
        {
            ConsoleLog("Initializing GSBot version " + versionStr);
            ConsoleLog("Date built: " + buildStr);

            CfgCreateIfNotExists();

            Process[] processName = Process.GetProcessesByName("Dota2");

            if (processName.Length == 0)
            {
                ConsoleLog("Dota 2 is not running. Please start Dota 2 and relaunch the program.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                ConsoleLog("Dota 2 is currently running. Starting GameState Listener...");
            }

            _gsl = new GameStateListener(4000);
            _gsl.NewGameState += OnNewGameState;

            if (!_gsl.Start())
            {
                ConsoleLog("GameState Listener could not start. Try running this program as Administrator. Exiting.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            ConsoleLog("GSBot successfully initialized. Listening for GameState data...");
        }

        /// <summary>
        /// Helper function that creates the cfg file.
        /// </summary>
        static void CfgCreateIfNotExists()
        {
            // TODO: Fix for multipe steam install paths.
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\Valve\Steam");

            if (regKey != null)
            {
                //string gsifolder = regKey.GetValue("SteamPath") +
                //                   @"\steamapps\common\dota 2 beta\game\dota\cfg\gamestate_integration";

                string gsFolder = @"C:\Program Files (x86)\SteamLibrary\steamapps\common\dota 2 beta\game\dota\cfg\gamestate_integration";
                Directory.CreateDirectory(gsFolder);
                string gsFile = gsFolder + @"\gamestate_integration_gsbot.cfg";

                if (File.Exists(gsFile))
                {
                    ConsoleLog("Configuration file found.");
                    return;
                }

                ConsoleLog("Creating configuration file.");

                string[] gsFileContents =
                {
                    "\"Dota 2 Integration Configuration\"",
                    "{",
                    "    \"uri\"           \"http://localhost:4000\"",
                    "    \"timeout\"       \"5.0\"",
                    "    \"buffer\"        \"0\"",
                    "    \"throttle\"      \"0\"",
                    "    \"heartbeat\"     \"30.0\"",
                    "    \"data\"",
                    "    {",
                    "        \"provider\"      \"1\"",
                    "        \"map\"           \"1\"",
                    "        \"player\"        \"1\"",
                    "        \"hero\"          \"1\"",
                    "        \"abilities\"     \"1\"",
                    "        \"items\"         \"1\"",
                    "    }",
                    "}",
                };

                File.WriteAllLines(gsFile, gsFileContents);
            }
            else
            {
                ConsoleLog("Registry key for steam not found, cannot create Gamestate Integration file.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Event handler when we receive a new gamestate.
        /// Update all state variables and do some actions if needed.
        /// </summary>
        /// <param name="gs"></param>
        static void OnNewGameState(GameState gs)
        {
            state.UpdateCache(gs);

            if (state.ArmletToggleIsAble)
                Armlet.ToggleArmlet(state);
        }

        /// <summary>
        /// Main program entry.
        /// Runs init routine and monitors state for a new hero.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Initialize();

            HeroProfile profile = delegate { };

            do
            {
                while (!Console.KeyAvailable)
                {
                    // Detected a new hero in our game state cache.
                    if (state.HeroName != state.sPreviousHeroName)
                    {
                        // Kill any hero scripts currently running.
                        List<Process> script_process = Process.GetProcessesByName("ahk_" + state.sPreviousHeroName).ToList();
                        script_process.AddRange(Process.GetProcessesByName("ahk_default").ToList());

                        // Reset delegate
                        profile = delegate { };

                        foreach (Process s in script_process)
                        {
                            ConsoleLog("Unloading: " + s.ProcessName);
                            s.Kill();
                        }

                        // Store the new hero.
                        state.sPreviousHeroName = state.HeroName;

                        if (!string.IsNullOrEmpty(state.sPreviousHeroName))
                        {
                            ConsoleLog("Loading hero script: " + state.sPreviousHeroName);
                            switch (state.sPreviousHeroName)
                            {
                                case "npc_dota_hero_alchemist":
                                case "npc_dota_hero_axe":
                                case "npc_dota_hero_bristleback":
                                case "npc_dota_hero_centaur":
                                case "npc_dota_hero_chaos_knight":
                                case "npc_dota_hero_dragon_knight":
                                case "npc_dota_hero_huskar":
                                case "npc_dota_hero_legion_commander":
                                case "npc_dota_hero_life_stealer":
                                case "npc_dota_hero_magnataur":
                                case "npc_dota_hero_nevermore":
                                case "npc_dota_hero_omniknight":
                                case "npc_dota_hero_skeleton_king":
                                case "npc_dota_hero_skywrath_mage":
                                case "npc_dota_hero_slardar":
                                case "npc_dota_hero_slark":
                                case "npc_dota_hero_treant":
                                    profile += new HeroProfile(SupportHelper.PullTimers);
                                    Process.Start(scriptsDir + "ahk_" + state.sPreviousHeroName);
                                    break;
                                default:
                                    Process.Start(scriptsDir + "ahk_default");
                                    break;
                            }
                        }
                    }

                    //profile(state);

                    Thread.Sleep(100);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Print message in console window with timestamp.
        /// </summary>
        /// <param name="msg"></param>
        static void ConsoleLog(string msg)
        {
            msg = "[" + DateTime.Now.ToShortTimeString() + "] " + msg;
            Console.WriteLine(msg);
        }
    }
}
