using System.Collections.Generic;
using System.IO;
using SlipperyLand.GameTypes;
using SlipperyLand.LevelMapper.Serialization;

namespace SlipperyLand.ViewModel
{
    /// <summary>
    /// Loads the levels
    /// </summary>
    internal static class LevelLoader
    {
        private readonly static string levelsDir = Path.Combine(Directory.GetCurrentDirectory(), "Levels");

        /// <summary>
        /// Get all levels from the folder
        /// </summary>
        public static IReadOnlyList<Level> GetLevels()
        {
            var levelFiles = Directory.GetFiles(levelsDir);
            var levels = new List<Level>();
            foreach (var levelFile in levelFiles)
            {
                var levelXml = File.ReadAllText(levelFile);
                levels.Add(LevelSerializer.Deserialize(levelXml));
            }
            return levels;
        }
    }
}
