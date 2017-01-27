﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using Dota2GSI;
using GSBot.Models;

namespace GSBot
{
    class Program
    {
        static GameStateListener _gsl;
        static GameStateCache gameStateCache = new GameStateCache();

        public delegate void HeroProfile(GameStateCache gs);

        static string versionStr = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        static string buildStr = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime.ToString();
        static string scriptsDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Scripts/bin/";
        static string soundsDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Sounds/";

        static string heroNameLast;
        static bool flag_ready;
        static bool flag_countdown;

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

        static void OnNewGameState(GameState gs)
        {
            gameStateCache.UpdateCache(gs);
        }

        static void Main(string[] args)
        {
            Initialize();

            //HeroProfile profile = delegate (GameStateCache gs)
            //{
            //    Console.WriteLine("Initializing hero profile delegate...");
            //};

            do
            {
                while (!Console.KeyAvailable)
                {
                    // Detected a new hero in our game state cache.
                    if (!string.IsNullOrEmpty(gameStateCache.HeroName) && gameStateCache.HeroName != heroNameLast)
                    {
                        ConsoleLog("New hero detected...");

                        // Kill any hero scripts currently running.
                        List<Process> script_process = Process.GetProcessesByName("ahk_" + heroNameLast).ToList();
                        script_process.AddRange(Process.GetProcessesByName("ahk_default").ToList());

                        foreach (Process s in script_process)
                        {
                            ConsoleLog("Unloading: " + s.ProcessName);
                            s.Kill();
                        }

                        // Store the new hero.
                        heroNameLast = gameStateCache.HeroName;

                        // Load new hero script.
                        switch (heroNameLast)
                        {
                            case "npc_dota_hero_magnataur":
                                Process.Start(scriptsDir + "ahk_" + heroNameLast);
                                break;
                            default:
                                Process.Start(scriptsDir + "ahk_default");
                                break;
                        }

                        ConsoleLog("New hero script loaded for: " + heroNameLast);
                        ConsoleLog("Total session packet count is at: " + gameStateCache.SessionPackets);
                    }

                    //profile(gameStateCache);
                    PullTimers(gameStateCache);

                    Thread.Sleep(100);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static void PullTimers(GameStateCache gameStateCache)
        {
            if (!flag_ready && gameStateCache.PullReadyFlag)
            {
                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundsDir + "jensen_ready.wav"))
                {
                    player.Play();
                }
            }

            if (!flag_countdown && gameStateCache.PullCountdownFlag)
            {
                using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundsDir + "jensen_countdown.wav"))
                {
                    player.Play();
                }
            }

            flag_ready = gameStateCache.PullReadyFlag;
            flag_countdown = gameStateCache.PullCountdownFlag;
        }

        static void ConsoleLog(string msg)
        {
            msg = "[" + DateTime.Now.ToShortTimeString() + "] " + msg;
            Console.WriteLine(msg);
        }
    }
}
