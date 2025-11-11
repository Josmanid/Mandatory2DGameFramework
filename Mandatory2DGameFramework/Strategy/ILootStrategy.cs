using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Strategy
{
    public interface ILootStrategy
    {
        public void LootItem(Creature  creature, World world, WorldObject loot);
    }
}
