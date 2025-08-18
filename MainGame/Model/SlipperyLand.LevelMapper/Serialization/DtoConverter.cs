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

        /// <summary>
        /// Convert a <see cref="MapLayerDto"/> to a <see cref="MapLayer"/>
        /// </summary>
        public static MapLayer ConvertToNormal(this MapLayerDto mapLayerDto)
        {
            var rows = mapLayerDto.Grid.Array.GetLength(0);
            var cols = mapLayerDto.Grid.Array.GetLength(1);
            var mapLayer = new MapLayer(rows, cols)
            {
                Grid = mapLayerDto.Grid.Array
            };
            return mapLayer;
        }
    }
}
