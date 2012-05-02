using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UntamedWilds.Server;

namespace UntamedWilds.Server
{
    /// <summary>
    /// Question: is a ceiling identical to the floor above it or can they be different.
    ///     Option A: Same - Remove Ceiling, West Wall and South Wall.  Reference neighboring tile.
    ///     Option B: Different - When modifying a tile, generally have to modify two tiles.
    ///     *Option C: Handle walls, ceilings and floors as objects on the tile
    /// </summary>
    public class Tile
    {
        public Tile()
        {
            Fill = new Solid();
        }

        //public Wall Ceiling { get; set; }
        //public Wall NorthWall { get; set; }
        //public Wall WestWall { get; set; }
        //public Wall EastWall { get; set; }
        //public Wall SouthWall { get; set; }
        //public Wall Floor { get; set; }

        public Material Fill { get; set; }
    }
}
