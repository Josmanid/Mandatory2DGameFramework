using Mandatory2DGameFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public class DefenceBoostDecorator : DefenceDecorator
    {
        MyLogger logger = MyLogger.Instance;
        public DefenceBoostDecorator(IDefenceItem inner) : base(inner) { }

        public override int ReduceHitPoint => base.ReduceHitPoint + 5;

        public override void Display() {
            base.Display();
            logger.LogInfo("Boosted defence with +5");
        }
    }
}
