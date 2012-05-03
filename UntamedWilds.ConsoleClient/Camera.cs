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
        }

        public Coordinate Location { get; set; }
        
        public void Move(Direction direction)
        {
        }

        public void Rotate(Rotation direction)
        {

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

    public class Facing
    {

    }
}
