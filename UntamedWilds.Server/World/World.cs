using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntamedWilds.Server
{
    /// <summary>
    /// Contains all zones, civilizations, creatures
    /// </summary>
    public class World
    {
        public const int SEA_LEVEL = 75;
        public const int DIAMETER = 200;

        public World()
        {
            Origin = new Coordinate(DIAMETER / 2, DIAMETER / 2, DIAMETER / 2);
            Areas = new Area[DIAMETER, DIAMETER, DIAMETER];

            for (int x = 0; x < DIAMETER; x++)
            {
                for (int y = 0; y < DIAMETER; y++)
                {
                    for (int z = 0; z < DIAMETER; z++)
                    {
                        // Create the area and pass the offset from the origin
                        Areas[x, y, z] = new Area(new Coordinate(x - Origin.X, y - Origin.Y, z - Origin.Y));
                        Areas[x, y, z].MassChanged += new DoubleValueChangedEventHandler(OnMassChanged);
                        //Areas[x, y, z].Generate();
                    }
                }
            }

            ActiveCivilization = new Civilization();
            AICivilizations = new List<Civilization>();
        }

        public Coordinate Origin { get; set; } // Possibly could represent the center of gravity.  Optionally use a second coordinate
        public Area[, ,] Areas { get; set; }
        public Civilization ActiveCivilization { get; set; }
        public List<Civilization> AICivilizations { get; set; }
        public double Mass { get; private set; }

        private void OnMassChanged(double change)
        {
            this.Mass += change;
        }

        public override string ToString()
        {
            return string.Format("World: {0}³ Areas", DIAMETER);
        }
    }
}