using KeystrokeClient;
using System;
using System.Windows.Forms;
using GSBot.Helpers;
using SIClass;
using System.Threading;
using GSBot.Models;
using GSClient;

namespace ConsoleApplicationTest
{
    class Program
    {
        static GameStateListener _gsl;
        static KeystrokeListener _ksl = new KeystrokeListener();
        static MasterState state = new MasterState();

        static void OnNewGameState(GameState gs)
        {
            state.UpdateCache(gs);
        }

        static void Main(string[] args)
        {
            _gsl = new GameStateListener(4000);
            _gsl.NewGameState += OnNewGameState;

            if (!_gsl.Start())
            {
                Console.WriteLine("GameState Listener could not start. Try running this program as Administrator. Exiting.");
                Console.ReadLine();
                Environment.Exit(0);
            }

            _ksl.CreateKeyboardHook((character) =>
            {
                Console.WriteLine(character);
                switch (character.KeyCode)
                {
                    case KeyCode.P:
                        Application.ExitThread();
                        break;

                    case KeyCode.Q:
                        Invoker.CastDeafeningBlast(state);
                        break;

                    case KeyCode.W:
                        Invoker.CastMeteor(state);
                        break;

                    case KeyCode.E:
                        Invoker.CastSunstrike(state);
                        break;

                    case KeyCode.PageUp:
                        Invoker.CastAlacrity(state);
                        break;

                    case KeyCode.PageDown:
                        Invoker.CastForgeSpirit(state);
                        break;

                    case KeyCode.D1:
                        Invoker.CastIcewall(state);
                        break;

                    case KeyCode.D2:
                        Invoker.CastTornado(state);
                        break;

                    case KeyCode.D3:
                        Invoker.CastEmp(state);
                        break;

                    case KeyCode.D4:
                        Invoker.CastColdsnap(state);
                        break;

                    case KeyCode.D5:
                        Invoker.CastGhostwalk(state);
                        break;
                }
            });
            Application.Run();
        }
    }
}
