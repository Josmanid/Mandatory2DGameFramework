using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Strategy
{
    public class ArmourLootStrategy : ILootStrategy
    {
        MyLogger logger = MyLogger.Instance;
        public void LootItem(Creature creature, World world, WorldObject loot) {
            if (loot is DefenceItem shield)
            {
                creature.Defence = shield;
                logger.LogInfo($"{creature.Name} loots an shield: {shield.Name} which can reduce {shield.ReduceHitPoint} Hitpoints");
                world.RemoveWorldObject(loot);
            }
        }
    }
}
