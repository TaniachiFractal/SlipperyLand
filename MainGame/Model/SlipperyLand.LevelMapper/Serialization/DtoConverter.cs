using SlipperyLand.GameTypes.Layers;
using SlipperyLand.LevelMapper.Serialization.SerializableTypes;

namespace SlipperyLand.LevelMapper.Serialization
{
    /// <summary>
    /// Converts <see cref="MapLayer"/> to <see cref="MapLayerDto"/>
    /// </summary>
    internal static class DtoConverter
    {
        /// <summary>
        /// Convert a <see cref="MapLayer"/> to a <see cref="MapLayerDto"/>
        /// </summary>
        public static MapLayerDto ConvertToDto(this MapLayer mapLayer)
        {
            var mapDto = new MapLayerDto(mapLayer.Rows, mapLayer.Cols);
            mapDto.Grid.Array = mapLayer.Grid;
            return mapDto;
        }
    }
}
