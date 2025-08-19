using SlipperyLand.GameTypes;
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
        /// Convert <see cref="LevelDto"/> to <see cref="Level"/>
        /// </summary>
        public static LevelDto ConvertToDto(this Level level)
            => new()
            {
                CharaLayer = level.CharaLayer,
                MapLayer = level.MapLayer.ConvertToDto(),
                MapTileSetType = level.MapTileSetType,
            };

        /// <summary>
        /// Convert <see cref="LevelDto"/> to <see cref="Level"/>
        /// </summary>
        public static Level ConvertToNormal(this LevelDto levelDto)
            => new()
            {
                CharaLayer = levelDto.CharaLayer,
                MapLayer = levelDto.MapLayer.ConvertToNormal()
            };

        private static MapLayerDto ConvertToDto(this MapLayer mapLayer)
        {
            var mapDto = new MapLayerDto(mapLayer.Rows, mapLayer.Cols);
            mapDto.Grid.Array = mapLayer.Grid;
            return mapDto;
        }

        private static MapLayer ConvertToNormal(this MapLayerDto mapLayerDto)
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
