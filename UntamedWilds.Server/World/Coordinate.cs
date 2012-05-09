namespace UntamedWilds.Server
{
    public class Coordinate
    {
        public Coordinate()
            : this(0, 0, 0) { }
        public Coordinate(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        public Coordinate(Coordinate coordinate)
            : this(coordinate.X, coordinate.Y, coordinate.Z) { }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
        }
    }
}