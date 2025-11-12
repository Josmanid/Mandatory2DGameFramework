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
        public static WorldObject Create(string type, int x, int y, string name, int value, int range = 0) {
            switch (type.ToLower())
            {
                case "attack":
                    return new AttackItem(x, y, name, hit: value, range: range);
                case "defence":
                    return new DefenceItem(x, y, name, reduce: value);
                default:
                    throw new ArgumentNullException($"Unkown world object: {type} do not exist ");
            }
        }
    }
}
