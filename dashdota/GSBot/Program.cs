using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using Dota2GSI;

namespace GSBot
{
    class Program
    {
        static GameStateListener _gsl;

        static string heroNameLast;

        static void Initialize()
        {
            Console.WriteLine("Initializing GSBot v1.0.0");

            CfgCreateIfNotExists();

            Process[] processName = Process.GetProcessesByName("Dota2");

            if (processName.Length == 0)
            {
                Console.WriteLine("Dota 2 is not running. Please start Dota 2 and relaunch the program.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Dota 2 is currently running. Starting GameState Listener...");
            }

            _gsl = new GameStateListener(4000);
            _gsl.NewGameState += OnNewGameState;

            if (!_gsl.Start())
            {
                Console.WriteLine("GameState Listener could not start. Try running this program as Administrator. Exiting.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            Console.WriteLine("GSBot successfully initialized. Listening for GameState data...");
        }

        static void OnNewGameState(GameState gs)
        {

            string heroName = gs?.Hero?.Name;

            if (!string.IsNullOrEmpty(heroName) && heroName != heroNameLast)
            {
                heroNameLast = heroName;
                Console.WriteLine("New hero detected... Loading profile for {0}", heroNameLast);

                switch (heroNameLast)
                {
                    case "dota_npc_hero_bristleback":
                        break;
                }
            }
        }

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
                    Console.WriteLine("Configuration file found.");
                    return;
                }

                Console.WriteLine("Creating configuration file.");

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
                Console.WriteLine("Registry key for steam not found, cannot create Gamestate Integration file.");
                Console.ReadLine();
                Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {
            Initialize();

            do
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(1000);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
