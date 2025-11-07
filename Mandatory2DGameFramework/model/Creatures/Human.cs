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
            Attack = new AttackItem(0, 0, "Sword of Fury", hit: 20, range: 1);
            Defence = new DefenceItem(0, 0, "Iron Shield", reduce: 5);
        }

    
        protected override int PrepareAttack() {
            logger.LogInfo($"{Name} swings their {Attack.Name}");
            return base.PrepareAttack() + 5;
        }
    }
}
