using System.Drawing;

namespace SlipperyLand.GraphicalResources
{
    /// <summary>
    /// A set of sprites or tiles
    /// </summary>
    public abstract class GraphicsSet
    {
        private int tileSize = 0;

        /// <summary>
        /// The size of 1 tile or sprite
        /// </summary>
        public int TileSize
        {
            get
            {
                if (tileSize == 0)
                {
                    tileSize = GetDefault().Width;
                }
                return tileSize;
            }
            set
            {
                tileSize = value;
            }
        }

        /// <summary>
        /// Get the default tile or sprite
        /// </summary>
        public abstract Bitmap GetDefault();
    }
}
