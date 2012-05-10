using System;
using System.Linq;
using System.Text;
using UntamedWilds.Server;

namespace UntamedWilds.ConsoleClient
{
    internal class BrowseWorld
    {
        internal BrowseWorld(World world)
        {
            this.GameWorld = world;
            this.View = new Camera(GameWorld.Origin);
        }

        private World GameWorld { get; set; }
        private Camera View { get; set; }

        private int X { get; set; }
        private int Y { get; set; }
        private int Z { get; set; }

        private int Depth
        {
            get { return GetCoordinate(this.View.DepthAxis.Type); }
            set { SetCoordinate(this.View.DepthAxis.Type, value); }
        }
        private int Vertical
        {
            get { return GetCoordinate(this.View.VerticalAxis.Type); }
            set { SetCoordinate(this.View.VerticalAxis.Type, value); }
        }
        private int Horizontal
        {
            get { return GetCoordinate(this.View.HorizontalAxis.Type); }
            set { SetCoordinate(this.View.HorizontalAxis.Type, value); }
        }

        internal void Browse()
        {
            do
            {
                Render();
            }
            while (ExecuteCommand(Console.ReadKey()));
        }

        private int GetCoordinate(AxisTypes axis)
        {
            switch (axis)
            {
                case AxisTypes.X:
                    return X;
                case AxisTypes.Y:
                    return Y;
                case AxisTypes.Z:
                    return Z;
                default:
                    throw new Exception(axis.ToString() + " is not a valid axis type.");
            }
        }
        private void SetCoordinate(AxisTypes axis, int value)
        {
            switch (axis)
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

        private void Render()
        {
            // Assume camera vector is -z, orientation is top y
            StringBuilder sb = new StringBuilder();

            for (this.Depth = this.View.DepthAxis.Start; Between(this.View.DepthAxis.Start, this.View.DepthAxis.End, this.Depth); this.Depth += this.View.DepthAxis.Scale)
            {
                for (this.Vertical = this.View.VerticalAxis.Start; Between(this.View.VerticalAxis.Start, this.View.VerticalAxis.End, this.Vertical); this.Vertical += this.View.VerticalAxis.Scale)
                {
                    for (this.Horizontal = this.View.HorizontalAxis.Start; Between(this.View.HorizontalAxis.Start, this.View.HorizontalAxis.End, this.Horizontal); this.Horizontal += this.View.HorizontalAxis.Scale)
                    {
                        sb.Append(RenderTile(this.X, this.Y, this.Z));
                    }
                    sb.AppendLine();
                }
            }

            Console.Clear();
            Console.Write(sb.ToString());
        }

        private char RenderTile(int x, int y, int z)
        {
            int xArea = World.DIAMETER / 2;
            int yArea = World.DIAMETER / 2;
            int zArea = (World.DIAMETER / 2) - World.SEA_LEVEL;

            try
            {
                Area currentArea = GameWorld.Areas[xArea, yArea, zArea];

                bool outOfRange = true;

                while (outOfRange)
                {
                    outOfRange = false;
                    if (x < 0)
                    {
                        xArea--;
                        x += Area.SIZE;
                        outOfRange = true;
                    }
                    if (x >= Area.SIZE)
                    {
                        xArea++;
                        x -= Area.SIZE;
                        outOfRange = true;
                    }
                    if (y < 0)
                    {
                        yArea--;
                        y += Area.SIZE;
                        outOfRange = true;
                    }
                    if (y >= Area.SIZE)
                    {
                        yArea++;
                        y -= Area.SIZE;
                        outOfRange = true;
                    }
                    if (z < 0)
                    {
                        zArea--;
                        z += Area.SIZE;
                        outOfRange = true;
                    }
                    if (z >= Area.SIZE)
                    {
                        zArea++;
                        z -= Area.SIZE;
                        outOfRange = true;
                    }
                }

                if (
                    ((GameWorld.Areas.GetLowerBound(0) <= xArea) && (xArea <= GameWorld.Areas.GetUpperBound(0))) &&
                    ((GameWorld.Areas.GetLowerBound(1) <= yArea) && (yArea <= GameWorld.Areas.GetUpperBound(1))) &&
                    ((GameWorld.Areas.GetLowerBound(2) <= zArea) && (zArea <= GameWorld.Areas.GetUpperBound(2))))
                {
                    return RenderTile(GameWorld.Areas[xArea, yArea, zArea].GetTile(x, y, z));
                }
                else
                {
                    return ' ';
                }
            }
            catch
            {
                return ' ';
            }
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
