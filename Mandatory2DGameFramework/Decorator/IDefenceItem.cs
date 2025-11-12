using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public interface IDefenceItem
    {
        public string Name { get; }
        public int ReduceHitPoint { get; }
        public void Display();


    }
}
