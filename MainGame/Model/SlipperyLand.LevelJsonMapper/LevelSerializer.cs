using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.LevelJsonMapper
{
    /// <summary>
    /// Serializes the <see cref="CharaLayer"/> and <see cref="MapLayer"/> level data into JSON
    /// </summary>
    public static class LevelSerializer
    {
        public static string ToJson(MapLayer mapLayer);
    }
}
