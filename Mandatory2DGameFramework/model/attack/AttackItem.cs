using Mandatory2DGameFramework.Factory;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject, IAttackItem
    {
        MyLogger logger = MyLogger.Instance;
        public int Range { get; set; }
        public int Hit { get; set; }

        public AttackItem(int x, int y, string name, int hit, int range)
            : base(x, y, name, false) {
            Hit = hit;
            Range = range;
        }

        public static bool operator >(AttackItem a, AttackItem b) {
            return a.Hit > b.Hit;
        }

        public static bool operator <(AttackItem a, AttackItem b) {
            return a.Hit < b.Hit;
        }

        public void Display() {
            logger.LogInfo($"{Name} have {Hit} points and {Range} range.");

        }
    }

}
