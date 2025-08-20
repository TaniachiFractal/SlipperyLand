using System;
using System.Collections.Generic;
using System.IO;
using SlipperyLand.Contracts;
using SlipperyLand.GameTypes;
using SlipperyLand.LevelMapper.Serialization;
using SlipperyLand.LevelMapper.Res;

namespace SlipperyLand.ViewModel
{
    /// <summary>
    /// Loads the levels
    /// </summary>
    internal static class LevelLoader
    {
        private readonly static string levelsDir = Path.Combine(Directory.GetCurrentDirectory(), "Levels");
        private readonly static string levelExtension = "*.slipland";

        /// <summary>
        /// Get all levels from the folder
        /// </summary>
        public static IReadOnlyList<Level> GetLevels(IDialogProvider dialogProvider, IApplication application)
        {
            var levelFiles = Directory.GetFiles(levelsDir, levelExtension);
            Array.Sort(levelFiles);
            var levels = new List<Level>();
            var errors = string.Empty;
            for (var i = 0; i < levelFiles.Length; i++)
            {
                var levelFile = levelFiles[i];
                var levelXml = File.ReadAllText(levelFile);
                try
                {
                    var level = LevelSerializer.Deserialize(levelXml);
                    levels.Add(level);
                }
                catch (InvalidOperationException ex)
                {
                    errors += $"{Path.GetFileName(levelFile)}: {ex.InnerException.Message} \n";
                }
            }
            if (errors.Length > 0)
            {
                dialogProvider.ShowErrorMessage(ErrorText.ErrorsInLevelFiles + "\n" + errors);
                application.Close();
            }
            return levels;
        }
    }
}
