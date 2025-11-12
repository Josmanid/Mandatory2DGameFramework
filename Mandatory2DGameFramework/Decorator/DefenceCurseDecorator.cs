using Mandatory2DGameFramework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Decorator
{
    public class DefenceCurseDecorator : DefenceDecorator
    {
        MyLogger logger = MyLogger.Instance;
        public DefenceCurseDecorator(IDefenceItem inner) : base(inner) { }

        public override int ReduceHitPoint => base.ReduceHitPoint - 5;

        public override void Display() {
            base.Display();
            logger.LogInfo("Defence reduced by -5");
        }
    }
}
