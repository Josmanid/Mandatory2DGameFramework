using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    /// <summary>
    /// Creature class functions as the template.
    /// It defines the sequence of steps, but lets subclasses override specific steps if they need custom behavior.
    /// </summary>
    public abstract class Creature
    {
        MyLogger logger = MyLogger.Instance;
        public string Name { get; set; }
        public int HitPoint { get; set; }


        // Todo consider how many attack / defence weapons are allowed
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        public Creature() {
            Name = string.Empty;
            HitPoint = 100;

        }


        // Template method
        public void PerformAttack(Creature target) {
            logger.LogInfo($"{Name} prepares to attack {target.Name}!");
            int attackValue = PrepareAttack();
            int finalDamage = CalculateDamage(attackValue, target.Defence);
            target.ReceiveHit(finalDamage);

            NotifyObservers(target, finalDamage);
        }

        //Optional stuff = virtuel?? or should i make it Mandatory = abstract??
        protected virtual int PrepareAttack() {
            return Attack?.Hit ?? 10;
        }

        protected virtual void ReceiveHit(int hit) {
            HitPoint -= hit;
            logger.LogInfo($"{Name} received {hit} damage! Remaining HP: {HitPoint}");

            if (HitPoint <= 0) {
                logger.LogWarning($"{Name} has fallen in battle!");
            }
        }

        protected virtual int CalculateDamage(int attackValue, DefenceItem? defence) {
            int defenceValue = defence != null ? defence.ReduceHitPoint : 0;
            int finalDamage = attackValue - defenceValue;

            if (finalDamage < 0)
                finalDamage = 0;

            return finalDamage;
        }

        protected virtual void NotifyObservers(Creature target, int damage) {

            logger.LogInfo($"[Observer] {Name} hit {target.Name} for {damage} damage.");
        }

        public override string ToString() {
            return $"{{Name={Name}, HitPoint={HitPoint}, Attack={Attack}, Defence={Defence}}}";
        }
    }
}
