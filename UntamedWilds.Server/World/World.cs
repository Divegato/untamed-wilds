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
        private const int SEA_LEVEL = 0;  // Equal to radius of planet if cube structure is used
        private const int Dimensions = 1; // Goal to make spherical worlds eventually (perhaps donut shaped)

        public World()
        {
            // For now, the world will be a single area
            Areas = new Area[Dimensions, Dimensions, Dimensions];
            Areas[0, 0, 0] = new Area();
            ActiveCivilization = new Civilization();
            AICivilizations = new List<Civilization>();
        }

        public Area[,,] Areas { get; set; }
        public Civilization ActiveCivilization { get; set; }
        public List<Civilization> AICivilizations { get; set; }
    }
}