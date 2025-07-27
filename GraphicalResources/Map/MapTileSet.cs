using System.Drawing;
using GameTypes.Cells;

namespace GraphicalResources.Map
{
    /// <summary>
    /// A set of map tile images
    /// </summary>
    public class MapTileSet
    {
        /// <inheritdoc cref="MapCellType.Slippery"/>
        public readonly Bitmap Slippery;

        /// <inheritdoc cref="MapCellType.Rough"/>
        public readonly Bitmap Rough;

        /// <inheritdoc cref="MapCellType.Wall"/>
        public readonly Bitmap Wall;

        /// <inheritdoc cref="MapCellType.Start"/>
        public readonly Bitmap Start;

        /// <inheritdoc cref="MapCellType.End"/>
        public readonly Bitmap End;

        /// <summary>
        /// ctor
        /// </summary>
        public MapTileSet(Bitmap slippery, Bitmap rough, Bitmap wall, Bitmap start, Bitmap end)
        {
            Slippery = slippery;
            Rough = rough;
            Wall = wall;
            Start = start;
            End = end;
        }

        /// <summary>
        /// Get the desired image by <see cref="MapCellType"/>
        /// </summary>
        public Bitmap Get(MapCellType type)
        {
            return type switch
            {
                MapCellType.Slippery => Slippery,
                MapCellType.Rough => Rough,
                MapCellType.Wall => Wall,
                MapCellType.Start => Start,
                MapCellType.End => End,
                MapCellType.None => MapTiles.Default,
                _ => MapTiles.Default,
            };
        }
    }
}
