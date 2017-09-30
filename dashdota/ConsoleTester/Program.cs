using KeystrokeClient;
using System;
using System.Windows.Forms;
using GSBot.Helpers;

namespace ConsoleApplicationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var api = new KeystrokeListener())
            {
                api.CreateKeyboardHook((character) =>
                {
                    switch (character.KeyCode)
                    {
                        case KeyCode.M:
                            Invoker.InvokeDeafeningBlast();
                            break;
                    }
                    Console.Write(character);
                });
                Application.Run();
                //Console.ReadKey();
            }
            //Console.ReadKey();
        }
    }
}
