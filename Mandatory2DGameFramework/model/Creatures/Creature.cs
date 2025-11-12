using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.Observer;
using Mandatory2DGameFramework.Strategy;
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
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        private List<ICreatureObserver> _observers = new List<ICreatureObserver>();
        private readonly Dictionary<Type, ILootStrategy> _lootStrategies = new Dictionary<Type, ILootStrategy>();
        // Todo consider how many attack / defence weapons are allowed
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        public Creature() {
            Name = string.Empty;
            HitPoint = 100;

            _lootStrategies[typeof(AttackItem)] = new WeaponLootStrategy();
            _lootStrategies[typeof(DefenceItem)] = new ArmourLootStrategy();

        }


        // Template method
        public void PerformAttack(Creature target) {
            logger.LogInfo($"{Name} prepares to attack {target.Name}!");

            if (Attack == null)
            {
                logger.LogWarning($"{Name} has no weapon to attack with!");
                return;
            }


            int distance = Math.Abs(PositionX - target.PositionX) + Math.Abs(PositionY - target.PositionY);

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

            if (HitPoint <= 0)
            {

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
            foreach (var observer in _observers)
            {
                observer.OnCreatureHit(this, target, damage);
            }

        }
        public void Move(int deltaX, int deltaY, World world) {
            int newX = PositionX + deltaX;
            int newY = PositionY + deltaY;

            if (world.CanMoveTo(newX, newY))
            {
                PositionX = newX;
                PositionY = newY;
                logger.LogInfo($"{Name} moved to ({PositionX},{PositionY}).");
            }
            else
            {
                logger.LogWarning($"{Name} cannot move outside the world boundaries!");
            }
        }



        public void Loot(World world) {
            var loot = world.GetObjectAtPosition(PositionX, PositionY);

            if (loot == null)
            {

                logger.LogInfo($"{Name} found nothing to loot at ({PositionX},{PositionY}).");
                return;
            }

            var lootType = loot.GetType();
            if (_lootStrategies.TryGetValue(lootType, out ILootStrategy? strategy))
            {
                strategy.LootItem(this, world, loot);
            }
            else
            {
                logger.LogWarning($"No loot strategy defined for {lootType.Name}! Using NotFoundStrategy as fallback.");
               
            }
        }




        protected virtual void Die() {
            logger.LogWarning($"{Name} has fallen in battle!");
        }


        public void AddObserver(ICreatureObserver observer) {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void RemoveObserver(ICreatureObserver observer) {
            if (_observers.Contains(observer))
                _observers.Remove(observer);
        }
        public override string ToString() {
            return $"{{Name={Name}, HitPoint={HitPoint}, Attack={Attack}, Defence={Defence}}}";
        }


    }
}
