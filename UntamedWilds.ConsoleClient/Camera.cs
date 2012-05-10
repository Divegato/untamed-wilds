using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UntamedWilds.Server;

namespace UntamedWilds.ConsoleClient
{
    public class Camera
    {
        public Camera(Coordinate location)
        {
            this.Location = location;
            this.HorizontalAxis = new ViewAxis() { Start = 0, End = 70, Scale = 1, Type = AxisTypes.X };
            this.VerticalAxis = new ViewAxis() { Start = 0, End = 30, Scale = 1, Type = AxisTypes.Y };
            this.DepthAxis = new ViewAxis() { Start = 0, End = 0, Scale = 1, Type = AxisTypes.Z };
        }

        public Coordinate Location { get; set; }
        public ViewAxis HorizontalAxis { get; set; }
        public ViewAxis VerticalAxis { get; set; }
        public ViewAxis DepthAxis { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    VerticalAxis.Decrement();
                    break;
                case Direction.Down:
                    VerticalAxis.Increment();
                    break;
                case Direction.Left:
                    HorizontalAxis.Decrement();
                    break;
                case Direction.Right:
                    HorizontalAxis.Increment();
                    break;
                case Direction.Backward:
                    DepthAxis.Decrement();
                    break;
                case Direction.Forward:
                    DepthAxis.Increment();
                    break;
                default:
                    break;
            }
        }

        public void Rotate(Rotation direction)
        {
            ViewAxis temp = new ViewAxis();
            switch (direction)
            {
                case Rotation.Clockwise:
                    temp = this.HorizontalAxis;
                    this.HorizontalAxis = this.VerticalAxis;
                    this.VerticalAxis = temp;
                    this.HorizontalAxis.Invert();
                    break;
                case Rotation.CounterClockwise:
                    temp = this.HorizontalAxis;
                    this.HorizontalAxis = this.VerticalAxis;
                    this.VerticalAxis = temp;
                    this.VerticalAxis.Invert();
                    break;
                case Rotation.Up:
                    temp.Type = this.DepthAxis.Type;
                    this.DepthAxis.Type = this.VerticalAxis.Type;
                    this.VerticalAxis.Type = temp.Type;
                    this.VerticalAxis.Invert();
                    break;
                case Rotation.Down:
                    temp.Type = this.DepthAxis.Type;
                    this.DepthAxis.Type = this.VerticalAxis.Type;
                    this.VerticalAxis.Type = temp.Type;
                    this.VerticalAxis.Invert();
                    break;
            }
        }
    }

    public class ViewAxis
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Scale { get; set; }
        public AxisTypes Type { get; set; }

        public void Increment()
        {
            this.Start += this.Scale;
            this.End += this.Scale;
        }

        public void Decrement()
        {
            this.Start -= this.Scale;
            this.End -= this.Scale;
        }

        public void Invert()
        {
            int tempCoordinate = this.Start;
            this.Start = this.End;
            this.End = tempCoordinate;
            this.Scale *= -1;
        }

        public override string ToString()
        {
            return string.Format("{o} {1}-{2} ({3})", this.Type, this.Start, this.End, this.Scale);
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Forward,
        Backward
    }

    public enum Rotation
    {
        Clockwise,
        CounterClockwise,
        Left,
        Right,
        Up,
        Down
    }

    public enum AxisTypes
    {
        X,
        Y,
        Z
    }
}
