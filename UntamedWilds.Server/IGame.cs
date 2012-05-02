using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntamedWilds.Server
{
    public interface IGame
    {
        void New();
        World GetWorld();
    }
}
