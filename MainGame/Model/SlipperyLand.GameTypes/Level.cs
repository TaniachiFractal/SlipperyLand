using SlipperyLand.GameTypes.Layers;
using SlipperyLand.GameTypes.TileSpriteSetTypes;

namespace SlipperyLand.GameTypes
{
    /// <summary>
    /// A game level consisting of a <see cref="CharaLayer"/> and a <see cref="MapLayer"/>
    /// </summary>
    public class Level
    {
        /// <summary>
        /// The tile set type
        /// </summary>
        public MapTileSetType MapTileSetType;

        /// <summary>
        /// The map layer
        /// </summary>
        public MapLayer MapLayer;

        /// <summary>
        /// The charaLook layer
        /// </summary>
        public CharaLayer CharaLayer;

    }
}
