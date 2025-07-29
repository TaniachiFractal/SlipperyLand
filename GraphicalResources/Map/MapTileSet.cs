using System.Drawing;
using GameTypes.Cells;

namespace GraphicalResources.Map
{
    /// <summary>
    /// A set of map tile images
    /// </summary>
    public class MapTileSet
    {
        private readonly Bitmap slippery;
        private readonly Bitmap rough;
        private readonly Bitmap wall;
        private readonly Bitmap start;
        private readonly Bitmap end;

        /// <summary>
        /// ctor
        /// </summary>
        public MapTileSet(Bitmap slippery, Bitmap rough, Bitmap wall, Bitmap start, Bitmap end)
        {
            this.slippery = slippery;
            this.rough = rough;
            this.wall = wall;
            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Get the desired image by <see cref="MapCellType"/>
        /// </summary>
        public Bitmap Get(MapCellType type)
            => type switch
            {
                MapCellType.Slippery => slippery,
                MapCellType.Rough => rough,
                MapCellType.Wall => wall,
                MapCellType.Start => start,
                MapCellType.End => end,
                MapCellType.None => MapTiles.Default,
                _ => MapTiles.Default,
            };

        /// <summary>
        /// Get the default tile
        /// </summary>
        public Bitmap GetDefault() => slippery;
    }
}
