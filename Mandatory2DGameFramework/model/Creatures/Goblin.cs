using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class Goblin : Creature
    {
        MyLogger logger = MyLogger.Instance;
        public Goblin() {
            Name = "Weak Goblin";
            HitPoint = 30;
        }
    }
}
