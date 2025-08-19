using System.IO;

namespace SlipperyLand.ViewModel
{
    /// <summary>
    /// Loads the levels
    /// </summary>
    internal static class LevelLoader
    {
        private readonly static string levelsDir = Path.Combine(Directory.GetCurrentDirectory(), "Levels");
    }
}
