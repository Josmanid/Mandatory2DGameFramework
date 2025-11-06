using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.attack
{
    public class AttackItem : WorldObject
    {
        
        public int Hit { get; set; }
        public int Range { get; set; }

        public AttackItem()
        {
            Name = "Unknown Weapon";
            Hit = 5;
            Range = 1;
            Lootable = true;
        }

        public override string ToString()
        {
            return $"{{Name={Name}, Hit={Hit}, Range={Range}}}";
        }
    }
}
