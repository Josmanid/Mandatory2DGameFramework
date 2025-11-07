using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem : WorldObject
    {
       
        public int ReduceHitPoint { get; set; }

        public DefenceItem(int x, int y, string name, int reduce)
            : base(x, y,name, lootable: true) {
            ReduceHitPoint = reduce;
        }
    }

}
