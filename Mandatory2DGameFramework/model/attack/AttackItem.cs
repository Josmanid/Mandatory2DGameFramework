using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject
    {
       public int Range { get; set; }
        public int Hit { get; set; }

        public AttackItem(int x, int y,string name, int hit, int range)
            : base(x, y, name, false) {
            Hit = hit;
            Range = range;
        }
    }

}
