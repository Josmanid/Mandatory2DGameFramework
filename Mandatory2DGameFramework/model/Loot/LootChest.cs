//using Mandatory2DGameFramework.worlds;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace Mandatory2DGameFramework.model.Loot
//{
//    public class LootChest : WorldObject
//    {
//        public List<WorldObject> Items { get; private set; }

//        public LootChest() : base(x, y, name, lootable: true) {
//            Name = "Loot Chest";
//            Lootable = true;
//            Removeable = true;
//            Items = new List<WorldObject>();
//        }

//        public void AddItem(WorldObject item) {
//            Items.Add(item);
//        }

//        public override string ToString() {
//            return $"{Name} containing {Items.Count} items.";
//        }


//    }
//}
