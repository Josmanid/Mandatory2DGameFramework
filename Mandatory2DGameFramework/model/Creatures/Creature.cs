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
        public int X { get; set; }
        public int Y { get; set; }


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

            if (Attack == null)
            {
                logger.LogWarning($"{Name} has no weapon to attack with!");
                return;
            }

            
            int distance = Math.Abs(X - target.X) + Math.Abs(Y - target.Y);

            if (distance > Attack.Range)
            {
                logger.LogWarning($"{Name} tried to attack {target.Name}, but is out of range! (Distance: {distance}, Range: {Attack.Range})");
                return;
            }

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

                Die();
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
        public void Move(int deltaX, int deltaY, World world) {
            int newX = X + deltaX;
            int newY = Y + deltaY;

            // Tjek om man bevæger sig udenfor verdens grænser
            if (newX < 0 || newY < 0 || newX >= world.MaxX || newY >= world.MaxY)
            {
                logger.LogWarning($"{Name} tried to move outside world boundaries ({newX},{newY}).");
                return;
            }

            X = newX;
            Y = newY;

            logger.LogInfo($"{Name} moved to ({X},{Y}).");

            // Tjek om der ligger noget på den nye position
            var obj = world.GetObjectAtPosition(X, Y);
            if (obj != null)
            {
                logger.LogInfo($"{Name} found something at ({X},{Y}): {obj.GetType().Name}!");
            }
        }


        public void Loot(World world) {
            var obj = world.GetObjectAtPosition(X, Y);
            if (obj == null)
            {
                logger.LogWarning($"{Name} tried to loot, but found nothing at ({X},{Y}).");
                return;
            }

            if (obj is AttackItem attack)
            {
                Attack = attack;
                logger.LogInfo($"{Name} looted a new weapon: {attack.Name} (Hit: {attack.Hit})!");
                world.RemoveWorldObject(obj);
            }
            else if (obj is DefenceItem defence)
            {
                Defence = defence;
                logger.LogInfo($"{Name} looted new armor: {defence.Name} (Defence: {defence.ReduceHitPoint})!");
                world.RemoveWorldObject(obj);
            }
            else
            {
                logger.LogInfo($"{Name} found an object at ({X},{Y}), but couldn’t use it.");
            }
        }
        protected virtual void Die() {
            logger.LogWarning($"{Name} has fallen in battle!");
        }
        public override string ToString() {
            return $"{{Name={Name}, HitPoint={HitPoint}, Attack={Attack}, Defence={Defence}}}";
        }
    }
}
