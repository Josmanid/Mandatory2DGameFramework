using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Observer
{
    public interface ICreatureObserver
    {
        void OnCreatureHit(Creature attacker, Creature target, int damageDealt);
    }
}
