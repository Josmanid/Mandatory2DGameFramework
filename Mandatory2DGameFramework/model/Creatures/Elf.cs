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
    public class Elf : Creature
    {
        MyLogger logger = MyLogger.Instance;
        public Elf() {
            Name = "Elf on the shelf";
            Attack = new AttackItem(0, 0, "Elven Bow", hit: 10, range: 3);
            Defence = new DefenceItem(0, 0, "Leather Armor",reduce: 5);
        }

        protected override int PrepareAttack() {
            return base.PrepareAttack();
        }
        protected override void ReceiveHit(int hit) {
            base.ReceiveHit(hit);
            logger.LogInfo($"{Name} dodges gracefully but still takes {hit} damage!");
        }


    }
}
