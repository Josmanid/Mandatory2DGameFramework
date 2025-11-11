using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public abstract class WorldObject
    {
        public string Name { get; set; }
        public int WorldObjectPositionX { get; set; }
        public int WorldObjectPositionY { get; set; }
        public bool IsLootable { get; set; }
        public bool IsRemoved { get; set; }

        protected WorldObject(int x, int y, string name, bool lootable = false) {
            WorldObjectPositionX = x;
            WorldObjectPositionY = y;
            IsLootable = lootable;
            IsRemoved = false;
            Name = name;
        }

        public override string ToString() {
            return $"({WorldObjectPositionX},{WorldObjectPositionY}) Lootable={IsLootable} Removed={IsRemoved}";
        }
    }
}

