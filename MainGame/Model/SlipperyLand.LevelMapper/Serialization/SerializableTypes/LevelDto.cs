using SlipperyLand.GameTypes;
using SlipperyLand.GameTypes.TileSpriteSetTypes;

namespace SlipperyLand.LevelMapper.Serialization.SerializableTypes
{
    /// <summary>
    /// A data transfer object for XML representation of <see cref="Level"/>
    /// </summary>
    public class LevelDto
    {
        /// <inheritdoc cref="MapLayerDto"/>
        public MapLayerDto MapLayer;

        /// <summary>
        /// The tile set type
        /// </summary>
        public MapTileSetType MapTileSetType;

        /// <summary>
        /// The appearance of the main character
        /// </summary>
        public CharaLook MainCharaLook;
    }
}
