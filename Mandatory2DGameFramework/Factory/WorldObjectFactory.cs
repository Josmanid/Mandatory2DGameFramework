using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Factory
{
    public static class WorldObjectFactory
    {

        public static IAttackItem CreateAttackItem(int x, int y, string name, int hit, int range) {
            return new AttackItem(x, y, name, hit, range);
        }

        public static IDefenceItem CreateDefenceItem(int x, int y, string name, int reduce) {
            return new DefenceItem(x, y, name, reduce);
        }


    }
}
