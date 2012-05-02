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
        private static IGame Game;

        static void Main(string[] args)
        {
            Game = new Game();
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1: Start Game");
            Console.WriteLine("2: Quit");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Game.New();
                    break;
                case "2":
                    return;
                default:
                    MainMenu();
                    break;
            }            
        }

        private static void MainLoop()
        {
            do
            {
                Render();
            }
            while (ExecuteCommand(Console.ReadLine()));
        }

        private static void Render()
        {
            Console.Clear();
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
