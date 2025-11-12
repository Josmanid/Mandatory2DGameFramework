using Mandatory2DGameFramework.Decorator;
using Mandatory2DGameFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Composite
{
    public class DefenceComposite : IDefenceItem
    {
        MyLogger logger = MyLogger.Instance;
        public readonly List<IDefenceItem> _defenceItems = new List<IDefenceItem>();
        public string Name { get; private set; }

       
        public int ReduceHitPoint
        {
            get
            {
                int total = 0;
                foreach (IDefenceItem defenceitem in _defenceItems)
                {
                    total += defenceitem.ReduceHitPoint;
                }
                return total;
            }
        }

        public DefenceComposite(string name) {
            Name = name;
        }
        // need to make en add and delete to the list
        public void Add(IDefenceItem item) {
            _defenceItems.Add(item);
        }
        public void Remove(IDefenceItem item) {

            _defenceItems.Remove(item);
        }
        public void Display() {
            logger.LogInfo($"{Name} contains: ");
            foreach(IDefenceItem defenceItem in _defenceItems)
            {
                defenceItem.Display();
            }
            logger.LogInfo($"Total defence of: {ReduceHitPoint} HitPoints ");
        }
    }
}
