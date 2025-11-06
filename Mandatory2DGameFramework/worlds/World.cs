using Mandatory2DGameFramework.Configuration;
using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public string GameDifficulty { get; private set; }

        // world objects
        private List<WorldObject> _worldObjects;
        // world creatures
        private List<Creature> _creatures;

        public World(GameConfig config) {
            MaxX = config.MaxX;
            MaxY = config.MaxY;
            GameDifficulty = config.GameDiffculty;

            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        public override string ToString() {
            return $"World Size: {MaxX}x{MaxY}, Difficulty: {GameDifficulty}";
        }
    }
}
