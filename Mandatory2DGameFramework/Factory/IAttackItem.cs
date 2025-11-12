using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Factory
{
    public interface IAttackItem
    {
        string Name { get; }
        int Hit { get; }
        int Range { get; }
        void Display();
    }

}
