using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem : WorldObject, IDefenceItem
    {
        MyLogger logger = MyLogger.Instance;

        public int ReduceHitPoint { get; private set; }


        public DefenceItem(int x, int y, string name, int reduce)
            : base(x, y, name, lootable: true) {
            ReduceHitPoint = reduce;
        }

        public void Display() {
            logger.LogInfo($"{Name} provides {ReduceHitPoint} defence.");
        }
    }

}
