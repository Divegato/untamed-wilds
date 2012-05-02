using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UntamedWilds.Server
{
    public class Area
    {
        public const int SIZE = 10;

        public Area(Coordinate offset)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            this.Offset = offset;

            this.Tiles = new Tile[SIZE, SIZE, SIZE];

            for (int x = 0; x < SIZE; x++)
            {
                for (int y = 0; y < SIZE; y++)
                {
                    for (int z = 0; z < SIZE; z++)
                    {
                        Material fill;

                        int i = r.Next(3);
                        switch (i)
                        {
                            case 1:
                                fill = new Solid();
                                break;
                            case 2:
                                fill = new Liquid();
                                break;
                            default :
                                fill = new Gas();
                                break;
                        }

                        this.Tiles[x, y, z] = new Tile(fill);
                    }
                }
            }
        }

        public Coordinate Offset { get; set; }
        public Tile[, ,] Tiles { get; set; }

        public override string ToString()
        {
            return string.Format("Area: {0}³ Tiles at {1}", SIZE, this.Offset);
        }
    }
}
