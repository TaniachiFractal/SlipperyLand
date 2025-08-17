using SlipperyLand.GameTypes.Layers;
using SlipperyLand.LevelMapper.Serialization.SerializableTypes;

namespace SlipperyLand.LevelMapper.Serialization
{
    /// <summary>
    /// Converts <see cref="MapLayer"/> to <see cref="SerializableMapLayerDto"/>
    /// </summary>
    internal static class DtoConverter
    {
        /// <summary>
        /// Convert a <see cref="MapLayer"/> to a <see cref="SerializableMapLayerDto"/>
        /// </summary>
        public static SerializableMapLayerDto ConvertToDto(this MapLayer mapLayer)
        {
            var mapDto = new SerializableMapLayerDto(mapLayer.Rows, mapLayer.Cols);
            mapDto.SerialGrid.Array = mapLayer.Grid;
            return mapDto;
        }
    }
}
