using System.Collections.Generic;
using System.Drawing;
using GameTypes.Cells;
using Common;

namespace GraphicalResources.Map
{
    /// <summary>
    /// A set of map tile images
    /// </summary>
    public class MapTileSet
    {
        /// <summary>
        /// The size of 1 tile
        /// </summary>
        public int TileSize = 0;

        /// <summary>
        /// The set of slippery tiles
        /// </summary>
        public List<Bitmap> slippery = new();

        /// <summary>
        /// The set of rough tiles
        /// </summary>
        public List<Bitmap> rough = new();

        /// <summary>
        /// The set of wall tiles
        /// </summary>
        public List<Bitmap> wall = new();

        /// <summary>
        /// The set of start tiles
        /// </summary>
        public List<Bitmap> start = new();

        /// <summary>
        /// The set of end tiles
        /// </summary>
        public List<Bitmap> end = new();

        /// <summary>
        /// Get the desired image by <see cref="MapCell"/>
        /// </summary>
        public Bitmap Get(MapCell cell)
            => cell != null ? cell.mapCellType switch
            {
                MapCellType.Slippery => slippery.ItemOrFirst(cell.mapCellLookId),
                MapCellType.Rough => rough.ItemOrFirst(cell.mapCellLookId),
                MapCellType.Wall => wall.ItemOrFirst(cell.mapCellLookId),
                MapCellType.Start => start.ItemOrFirst(cell.mapCellLookId),
                MapCellType.End => end.ItemOrFirst(cell.mapCellLookId),
                MapCellType.None => MapTiles.Default,
                _ => MapTiles.Default,
            } : MapTiles.Default;

        /// <summary>
        /// Get the default tile
        /// </summary>
        public Bitmap GetDefault() => slippery.ItemOrFirst(0);
    }
}
