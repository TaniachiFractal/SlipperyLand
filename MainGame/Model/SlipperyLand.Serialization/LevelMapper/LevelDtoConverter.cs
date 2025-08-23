using SlipperyLand.GameTypes;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.Serialization.LevelMapper.SerializableTypes;

namespace SlipperyLand.Serialization.LevelMapper
{
    /// <summary>
    /// Converts <see cref="Level"/> to <see cref="LevelDto"/> and back
    /// </summary>
    internal static class LevelDtoConverter
    {
        /// <summary>
        /// Convert <see cref="LevelDto"/> to <see cref="Level"/>
        /// </summary>
        public static LevelDto ConvertToDto(this Level level)
            => new()
            {
                MapLayer = level.MapLayer.ConvertToDto(),
                MapTileSetType = level.MapTileSetType,
                MainCharaLook = level.CharaLayer.MainChara.CharaLook,
            };

        /// <summary>
        /// Convert <see cref="LevelDto"/> to <see cref="Level"/>
        /// </summary>
        public static Level ConvertToNormal(this LevelDto levelDto)
        {
            var charaLayer = new CharaLayer(levelDto.MainCharaLook);
            var mapLayer = levelDto.MapLayer.ConvertToNormal();
            var (row, col) = mapLayer.FindStartCell();
            return new()
            {
                CharaLayer = charaLayer,
                MapLayer = mapLayer,
                MapTileSetType = levelDto.MapTileSetType,
                StartCol = col,
                StartRow = row,
            };
        }

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
