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
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsLootable { get; set; }
        public bool IsRemoved { get; set; }

        protected WorldObject(int x, int y, string name, bool lootable = false) {
            X = x;
            Y = y;
            IsLootable = lootable;
            IsRemoved = false;
            Name = name;
        }

        public override string ToString() {
            return $"({X},{Y}) Lootable={IsLootable} Removed={IsRemoved}";
        }
    }
}

