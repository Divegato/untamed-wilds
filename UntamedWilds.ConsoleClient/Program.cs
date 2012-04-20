using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UntamedWilds.Server;

namespace UntamedWilds.ConsoleClient
{
    public static class Program
    {
        private static Game Game;

        static void Main(string[] args)
        {
            Game = new Game();
            RenderMenu(Game.GetCurrentMenu());

            do
            {
                Render();
            }
            while (ExecuteCommand(Console.ReadLine()));
        }

        private static void Render()
        {
            Console.Clear();
            RenderMenu(Game.GetCurrentMenu());
        }

        private static void RenderMenu(Menu menu)
        {
            foreach (Menu.Option option in menu.Options)
            {
                Console.WriteLine(string.Format("{0}: {1}", option.Value, option.Text));
            }
        }

        private static bool ExecuteCommand(string command)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(command))
                {
                    int number = 0;

                    if (int.TryParse(command, out number))
                    {
                        Game.ExecuteCommand(number);
                    }
                    else
                    {

                    }
                }
            }
            catch (InvalidCommandException) { }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
                command = "quit";
            }

            return command != "quit";
        }
    }
}
