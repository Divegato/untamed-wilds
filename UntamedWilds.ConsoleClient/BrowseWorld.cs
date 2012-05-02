using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UntamedWilds.Server;

namespace UntamedWilds.ConsoleClient
{
    internal class BrowseWorld
    {
        public BrowseWorld(World world)
        {
            this.GameWorld = world;
        }

        public World GameWorld { get; set; }
        public Coordinate CameraLocation { get; set; }

        internal void Browse()
        {
            this.CameraLocation = new Coordinate(GameWorld.Origin);

            do
            {
                Render();
            }
            while (ExecuteCommand(Console.ReadLine()));
        }

        private void Render()
        {
            // Assume camera vector is -z, orientation is top y
            Console.Clear();

            Area currentArea = GetCurrentArea();
            for (int x = 0; x < Area.SIZE; x++)
            {
                for (int y = 0; y < Area.SIZE; y++)
                {
                    Console.Write(RenderTile( currentArea.Tiles[x, y, 0]));
                }
                Console.WriteLine();
            }
        }

        private Area GetCurrentArea()
        {
            // For starters, lets just grab the first area
            return GameWorld.Areas[0, 0, 0];
        }

        private char RenderTile(Tile tile)
        {
            if (tile.Fill is Gas)
            {
                return ' ';
            }
            else if (tile.Fill is Liquid)
            {
                return '~';
            }
            else if (tile.Fill is Solid)
            {
                return 'X';
            }
            else
            {
                return tile.Fill.ToString().ToCharArray()[0];
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
