using System;

namespace CellTypes.Layers
{
    /// <summary>
    /// Template for a layer class
    /// </summary>
    /// <typeparam name="TCells">Possible cell types</typeparam>
    public abstract class BasicLayer<TCells> where TCells : Enum
    {
        private TCells[,] grid;
        /// <summary>
        /// The cell grid of the layer
        /// </summary>
        public TCells[,] Grid
        {
            get => grid;
            private set => grid = value;
        }

        /// <summary>
        /// Empty grid constructor
        /// </summary>
        /// <param name="width">Grid width</param>
        /// <param name="height">Grid height</param>
        public BasicLayer(int width, int height)
        {
            grid = new TCells[width, height];
        }



    }
}
