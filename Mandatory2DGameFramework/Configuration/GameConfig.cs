using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Mandatory2DGameFramework.Configuration
{
    public class GameConfig
    {
        public string ServerName { get; private set; }
        public string DebugLevel { get; private set; }
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        public string GameDiffculty { get; private set; }

        public void StartReadConfigfile(string configFilePath) {
            XmlDocument cnf = new XmlDocument();
            cnf.Load(configFilePath);

            XmlNode? nameNode = cnf.DocumentElement.SelectSingleNode("ServerName");
            if (nameNode != null)
            {
                ServerName = nameNode.InnerText.Trim();
            }
            else { ServerName = "Unknown"; }

            XmlNode? debugNode = cnf.DocumentElement.SelectSingleNode("DebugLevel");
            if (debugNode != null)
            {
                DebugLevel = debugNode.InnerText.Trim();
            }
            else { DebugLevel = "Info"; }

            XmlNode? maxXNode = cnf.DocumentElement.SelectSingleNode("World/MaxX");
            if (maxXNode != null)
            {
                string MaxXStr = maxXNode.InnerText.Trim();
                MaxX = Convert.ToInt32(MaxXStr);
            }
            else { MaxX = 10; }

            XmlNode? maxYNode = cnf.DocumentElement.SelectSingleNode("World/MaxY");
            if (maxYNode != null)
            {
                string MaxYStr = maxYNode.InnerText.Trim();
                MaxY = Convert.ToInt32(MaxYStr);
            }
            else { MaxY = 10; }

            XmlNode? gameDifficultyNode = cnf.DocumentElement.SelectSingleNode("GameDifficulty/GameLevel");
            if (gameDifficultyNode != null)
            {
                GameDiffculty = gameDifficultyNode.InnerText.Trim();
            }
            else { GameDiffculty = "Beginner"; }

        }

        public override string ToString() {
            return $"Server: {ServerName}, DebugLevel: {DebugLevel}, World: {MaxX}x{MaxY}, Difficulty: {GameDiffculty}";
        }
    }
}
