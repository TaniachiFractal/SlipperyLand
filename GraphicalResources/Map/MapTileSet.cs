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

        /// <summary>
        /// ctor
        /// </summary>
        public MapTileSet(Bitmap slippery, Bitmap rough, Bitmap wall)
        {
            Slippery = slippery;
            Rough = rough;
            Wall = wall;
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
                MapCellType.None => null,
                _ => null,
            };
        }
    }
}
