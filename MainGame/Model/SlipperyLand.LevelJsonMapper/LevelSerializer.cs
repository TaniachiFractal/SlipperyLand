using System.IO;
using Newtonsoft.Json;
using SlipperyLand.GameTypes;

namespace SlipperyLand.LevelJsonMapper
{
    /// <summary>
    /// Serializes the <see cref="Level"/> data into JSON
    /// </summary>
    public static class LevelSerializer
    {
        public static void ToJson(this Level level)
        {
            var outp = JsonConvert.SerializeObject(level);
            File.WriteAllText("D:\\test.txt", outp);
        }
    }
}
