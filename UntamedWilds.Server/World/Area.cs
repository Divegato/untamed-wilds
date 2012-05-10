using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UntamedWilds.Server
{
    public class Area
    {
        public const int SIZE = 100;

        public Area(Coordinate offset)
        {
            this.Offset = offset;
        }

        private bool initialized;

        private void Generate()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            this.Tiles = new Tile[SIZE, SIZE, SIZE];
            this.Mass = 0;
            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    for (int z = 0; z < SIZE; z++)
                    {
                        double xDistance = Math.Pow((this.Offset.X * SIZE) + x, 2);
                        double yDistance = Math.Pow((this.Offset.Y * SIZE) + y, 2);
                        double zDistance = Math.Pow((this.Offset.Z * SIZE) + z, 2);
                        double totalDistance = Math.Pow(xDistance + yDistance + zDistance, 0.5);
                        double seaLevel = World.SEA_LEVEL * SIZE;

                        Material fill = new Gas();

                        if (totalDistance < seaLevel)
                        {
                            fill = new Solid();
                            Mass++;
                        }

                        this.Tiles[x, y, z] = new Tile(fill);
                    }
                }
            }
        }

        public Coordinate Offset { get; set; }

        private Tile[, ,] Tiles;
        public Tile GetTile(int x, int y, int z)
        {
            if (!initialized)
            {
                this.Generate();
                this.initialized = true;
            }

            return this.Tiles[z, y, z];
        }

        private double mass;
        public double Mass
        {
            get { return mass; }
            set
            {
                if (value != mass && MassChanged != null)
                    MassChanged(value - mass);

                mass = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Area: {0}³ Tiles at {1}", SIZE, this.Offset);
        }

        public event DoubleValueChangedEventHandler MassChanged;
    }

    public delegate void DoubleValueChangedEventHandler(double change);
}
