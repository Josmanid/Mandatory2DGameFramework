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
    public class Human : Creature
    {
        MyLogger logger = MyLogger.Instance;
        public Human() {
            Name = "Human Warrior";
            Attack = new AttackItem { Name = "Sword", Hit = 20 };
            Defence = new DefenceItem { Name = "Shield", ReduceHitPoint = 5 };
        }

    
        protected override int PrepareAttack() {
            logger.LogInfo($"{Name} swings their {Attack.Name}");
            return base.PrepareAttack() + 5;
        }
    }
}
