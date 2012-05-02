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
        internal static IGame Game;

        static void Main(string[] args)
        {
            Game = new Game();

            MainMenu menu = new MainMenu();
            menu.Render();
        }
    }
}
