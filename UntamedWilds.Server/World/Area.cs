using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UntamedWilds.Server
{
    public class Area
    {
        private const int AREA_SIZE = 10;

        public Area()
        {
            Tiles = new Tile[AREA_SIZE, AREA_SIZE, AREA_SIZE];

            for (int i = 0; i < AREA_SIZE; i++)
            {
                for (int j = 0; j < AREA_SIZE; j++)
                {
                    for (int k = 0; k < AREA_SIZE; k++)
                    {
                        Tiles[i, j, k] = new Tile();
                    }
                }
            }
        }

        public Tile[, ,] Tiles { get; set; }
    }
}
