namespace SlipperyLand.GameTypes.Cells.Map
{
    /// <summary>
    /// A set of intersections against map cells
    /// </summary>
    public class SetOfMapInters
    {
        /// <summary>
        /// Top left
        /// </summary>
        public MapCellType TL;

        /// <summary>
        /// Top right
        /// </summary>
        public MapCellType TR;

        /// <summary>
        /// Bottom left
        /// </summary>
        public MapCellType BL;

        /// <summary>
        /// Bottom right
        /// </summary>
        public MapCellType BR;

        /// <summary>
        /// ctor
        /// </summary>
        public SetOfMapInters(MapCellType TL, MapCellType TR, MapCellType BL, MapCellType BR)
        {
            this.TL = TL;
            this.TR = TR;
            this.BL = BL;
            this.BR = BR;
        }

        /// <summary>
        /// If the set has a <see cref="MapCellType.Wall"/>
        /// </summary>
        public bool HasWall => TL == MapCellType.Wall || TR == MapCellType.Wall || BL == MapCellType.Wall || BR == MapCellType.Wall;

    }
}
