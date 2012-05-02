using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UntamedWilds.Server;

namespace UntamedWilds.ConsoleClient
{
    public class MainMenu
    {
        internal void Render()
        {
            Console.Clear();
            Console.WriteLine("1: Start Game");
            Console.WriteLine("2: Quit");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Program.Game.New();
                    BrowseWorld browser = new BrowseWorld(Program.Game.GetWorld());
                    browser.Browse();
                    break;
                case "2":
                    return;
                default:
                    Render();
                    break;
            }            
        }
    }
}
