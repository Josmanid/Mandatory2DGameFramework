using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mandatory2DGameFramework.Observer
{
    public class CombatLogger : ICreatureObserver
    {
       MyLogger logger = MyLogger.Instance;
        public void OnCreatureHit(Creature attacker, Creature target, int damageDealt) {
            logger.LogInfo($"[CombatLogger] {attacker.Name} hit {target.Name} for {damageDealt} HP!");
        }
    }
}
