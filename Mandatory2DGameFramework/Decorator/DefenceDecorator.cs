using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public abstract class DefenceDecorator : IDefenceItem
    {
        protected readonly IDefenceItem _innerDefence;
       
        public DefenceDecorator(IDefenceItem inner) {
            _innerDefence = inner;
        }
        public virtual string Name => _innerDefence.Name;
        public virtual int ReduceHitPoint => _innerDefence.ReduceHitPoint;

        public virtual void Display() {
            _innerDefence.Display();
        }
    }
}
