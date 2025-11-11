using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Strategy
{
    public class WeaponLootStrategy : ILootStrategy
    {
        MyLogger logger = MyLogger.Instance;
        public void LootItem(Creature creature, World world, WorldObject loot) {
            if (loot is AttackItem weapon)
            {
                creature.Attack = weapon;
                logger.LogInfo($"{creature.Name} looted a new weapon: {weapon.Name} " +
                    $"with Hit: {weapon.Hit} and range: {weapon.Range}");
                world.RemoveWorldObject(loot);
            }
        }
    }
}
