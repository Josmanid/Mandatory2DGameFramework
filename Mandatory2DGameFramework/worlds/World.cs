using Mandatory2DGameFramework.Configuration;
using Mandatory2DGameFramework.Logging;
using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    /// <summary>
    /// Represents the game world grid that contains creatures and world objects.
    /// Responsible for bounds checking and storing world objects / creatures.
    /// </summary>
    public class World
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public string GameDifficulty { get; private set; }

     
        private List<WorldObject> _worldObjects;
  
        private List<Creature> _creatures;

        public World(GameConfig config) {
            MaxX = config.MaxX;
            MaxY = config.MaxY;
            GameDifficulty = config.GameDiffculty;

            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        private bool IsWithinBounds(int newXPosition, int newYPosition) {
            return newXPosition >= 0 && newXPosition < MaxX &&
                   newYPosition >= 0 && newYPosition < MaxY;
        }

        public bool CanMoveTo(int newX, int newY) {
            return IsWithinBounds(newX, newY);
        }

        public bool AddWorldObject(WorldObject obj) {
            if (!IsWithinBounds(obj.WorldObjectPositionX, obj.WorldObjectPositionY))
            {
                MyLogger.Instance.LogWarning($"Cannot place {obj.Name} outside world boundaries!");
                return false;
            }

            _worldObjects.Add(obj);
            MyLogger.Instance.LogInfo($"{obj.Name} placed at ({obj.WorldObjectPositionX},{obj.WorldObjectPositionY}).");
            return true;
        }

        public bool AddCreature(Creature creature, int x, int y) {
            if (!IsWithinBounds(x, y))
            {
                MyLogger.Instance.LogWarning($"Cannot place {creature.Name} outside world boundaries!");
                return false;
            }

            creature.PositionX = x;
            creature.PositionY = y;
            _creatures.Add(creature);
            MyLogger.Instance.LogInfo($"{creature.Name} added at ({x},{y}).");
            return true;
        }
        public WorldObject? GetObjectAtPosition(int newX, int newY) {
            return _worldObjects.FirstOrDefault(o => o.WorldObjectPositionX == newX && o.WorldObjectPositionY == newY && !o.IsRemoved);
        }

        public void RemoveWorldObject(WorldObject obj) {
            obj.IsRemoved = true;
            _worldObjects.Remove(obj);
        }


        public override string ToString() {
            return $"World Size: {MaxX}x{MaxY}, Difficulty: {GameDifficulty}";
        }
    }
}
