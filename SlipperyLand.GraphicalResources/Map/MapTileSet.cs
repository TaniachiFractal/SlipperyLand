using System.Collections.Generic;
using System.Drawing;
using SlipperyLand.Common.Extensions;
using SlipperyLand.GameTypes.Cells.Map;

namespace SlipperyLand.GraphicalResources.Map
{
    /// <summary>
    /// A set of map tile images
    /// </summary>
    public class MapTileSet : GraphicsSet
    {
        /// <summary>
        /// The set of slippery tiles
        /// </summary>
        public List<Bitmap> slippery = [];

        /// <summary>
        /// The set of rough tiles
        /// </summary>
        public List<Bitmap> rough = [];

        /// <summary>
        /// The set of wall tiles
        /// </summary>
        public List<Bitmap> wall = [];

        /// <summary>
        /// The set of start tiles
        /// </summary>
        public List<Bitmap> start = [];

        /// <summary>
        /// The set of end tiles
        /// </summary>
        public List<Bitmap> end = [];

        /// <summary>
        /// Get the desired image by <see cref="MapCell"/>
        /// </summary>
        public Bitmap Get(MapCell cell)
            => cell != null ? cell.mapCellType switch
            {
                MapCellType.Slippery => slippery.ItemOrFirst(cell.mapCellLookId, MapTiles.Default),
                MapCellType.Rough => rough.ItemOrFirst(cell.mapCellLookId, MapTiles.Default),
                MapCellType.Wall => wall.ItemOrFirst(cell.mapCellLookId, MapTiles.Default),
                MapCellType.Start => start.ItemOrFirst(cell.mapCellLookId, MapTiles.Default),
                MapCellType.End => end.ItemOrFirst(cell.mapCellLookId, MapTiles.Default),
                MapCellType.None => MapTiles.Default,
                _ => MapTiles.Default,
            } : MapTiles.Default;

        /// <inheritdoc/>
        public override Bitmap GetDefault() => slippery.ItemOrFirst(0, MapTiles.Default);
    }
}
