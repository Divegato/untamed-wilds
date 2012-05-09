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
            this.View = new Camera(GameWorld.Origin);
        }

        public World GameWorld { get; set; }
        public Camera View { get; set; }

        internal void Browse()
        {
            do
            {
                Render();
            }
            while (ExecuteCommand(Console.ReadKey()));
        }


        private int X { get; set; }
        private int Y { get; set; }
        private int Z { get; set; }
        private int Depth
        {
            get
            {
                switch (this.View.DepthAxis.Type)
                {
                    case AxisTypes.X:
                        return X;
                    case AxisTypes.Y:
                        return Y;
                    case AxisTypes.Z:
                        return Z;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (this.View.DepthAxis.Type)
                {
                    case AxisTypes.X:
                        this.X = value;
                        break;
                    case AxisTypes.Y:
                        this.Y = value;
                        break;
                    case AxisTypes.Z:
                        this.Z = value;
                        break;
                }
            }
        }
        private int Vertical
        {
            get
            {
                switch (this.View.VerticalAxis.Type)
                {
                    case AxisTypes.X:
                        return X;
                    case AxisTypes.Y:
                        return Y;
                    case AxisTypes.Z:
                        return Z;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (this.View.VerticalAxis.Type)
                {
                    case AxisTypes.X:
                        this.X = value;
                        break;
                    case AxisTypes.Y:
                        this.Y = value;
                        break;
                    case AxisTypes.Z:
                        this.Z = value;
                        break;
                }
            }
        }
        private int Horizontal
        {
            get
            {
                switch (this.View.HorizontalAxis.Type)
                {
                    case AxisTypes.X:
                        return X;
                    case AxisTypes.Y:
                        return Y;
                    case AxisTypes.Z:
                        return Z;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (this.View.HorizontalAxis.Type)
                {
                    case AxisTypes.X:
                        this.X = value;
                        break;
                    case AxisTypes.Y:
                        this.Y = value;
                        break;
                    case AxisTypes.Z:
                        this.Z = value;
                        break;
                }
            }
        }

        private void Render()
        {
            // Assume camera vector is -z, orientation is top y
            Console.Clear();

            Area currentArea = GetCurrentArea();

            for (this.Depth = this.View.DepthAxis.Start; Between(this.View.DepthAxis.Start, this.View.DepthAxis.End, this.Depth); this.Depth += this.View.DepthAxis.Scale)
            {
                for (this.Vertical = this.View.VerticalAxis.Start; Between(this.View.VerticalAxis.Start, this.View.VerticalAxis.End, this.Vertical); this.Vertical += this.View.VerticalAxis.Scale)
                {
                    for (this.Horizontal = this.View.HorizontalAxis.Start; Between(this.View.HorizontalAxis.Start, this.View.HorizontalAxis.End, this.Horizontal); this.Horizontal += this.View.HorizontalAxis.Scale)
                    {
                        PrintTile(currentArea, this.X, this.Y, this.Z);
                    }
                    Console.WriteLine();
                }
            }
        }

        private void PrintTile(Area currentArea, int x, int y, int z)
        {
            try
            {
                if (
                    ((currentArea.Tiles.GetLowerBound(0) <= x) && (x <= currentArea.Tiles.GetUpperBound(0))) &&
                    ((currentArea.Tiles.GetLowerBound(1) <= y) && (y <= currentArea.Tiles.GetUpperBound(1))) &&
                    ((currentArea.Tiles.GetLowerBound(2) <= z) && (z <= currentArea.Tiles.GetUpperBound(2))))
                {
                    Console.Write(RenderTile(currentArea.Tiles[x, y, z]));
                }
                else
                {
                    Console.Write(' ');
                }
            }
            catch
            {
                Console.Write(' ');
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

        private bool ExecuteCommand(ConsoleKeyInfo command)
        {
            if (command.Key == ConsoleKey.Escape)
                return false;

            switch (command.KeyChar)
            {
                case '+':
                    View.Move(Direction.Forward);
                    break;
                case '-':
                    View.Move(Direction.Backward);
                    break;
                case 'w':
                    View.Move(Direction.Up);
                    break;
                case 'a':
                    View.Move(Direction.Left);
                    break;
                case 's':
                    View.Move(Direction.Down);
                    break;
                case 'd':
                    View.Move(Direction.Right);
                    break;
                case 'q':
                    View.Rotate(Rotation.CounterClockwise);
                    break;
                case 'e':
                    View.Rotate(Rotation.Clockwise);
                    break;
                case 'W':
                    View.Rotate(Rotation.Down);
                    break;
                case 'A':
                    View.Rotate(Rotation.Right);
                    break;
                case 'S':
                    View.Rotate(Rotation.Up);
                    break;
                case 'D':
                    View.Rotate(Rotation.Left);
                    break;
                default:
                    Console.Write(command.KeyChar);
                    break;
            }

            return true;
        }

        private bool ExecuteCommand(string command)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(command))
                {
                    int number = 0;

                    if (int.TryParse(command, out number))
                    {
                    }
                    else if (command.Length == 1)
                    {
                        switch (command.ToArray()[0])
                        {
                            case '+':
                                View.Move(Direction.Forward);
                                break;
                            case '-':
                                View.Move(Direction.Backward);
                                break;
                            case 'w':
                                View.Move(Direction.Up);
                                break;
                            case 'a':
                                View.Move(Direction.Left);
                                break;
                            case 's':
                                View.Move(Direction.Down);
                                break;
                            case 'd':
                                View.Move(Direction.Right);
                                break;
                            case 'q':
                                View.Rotate(Rotation.CounterClockwise);
                                break;
                            case 'e':
                                View.Rotate(Rotation.Clockwise);
                                break;
                            case 'W':
                                View.Rotate(Rotation.Down);
                                break;
                            case 'A':
                                View.Rotate(Rotation.Right);
                                break;
                            case 'S':
                                View.Rotate(Rotation.Up);
                                break;
                            case 'D':
                                View.Rotate(Rotation.Left);
                                break;
                            default:
                                break;
                        }
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

        private bool Between(int p1, int p2, int value)
        {
            if (p1 < p2)
            {
                return p1 <= value && value <= p2;
            }
            else
            {
                return p1 >= value && value >= p2;
            }
        }
    }
}
