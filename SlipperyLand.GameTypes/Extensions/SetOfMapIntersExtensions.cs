using SlipperyLand.GameTypes.Cells.Map;

namespace SlipperyLand.GameTypes.Extensions
{
    /// <summary>
    /// Extensions for <see cref="SetOfMapInters"/>
    /// </summary>
    public static class SetOfMapIntersExtensions
    {
        /// <summary>
        /// If the set has a <see cref="MapCellType.Wall"/>
        /// </summary>
        public static bool HasWall(this SetOfMapInters inters) => inters.HasType(MapCellType.Wall);

        /// <summary>
        /// If the set has a <see cref="MapCellType.Slippery"/>
        /// </summary>
        public static bool HasSlip(this SetOfMapInters inters) => inters.HasType(MapCellType.Slippery);

        /// <summary>
        /// If the set has a <see cref="MapCellType.End"/>
        /// </summary>
        public static bool HasEnd(this SetOfMapInters inters) => inters.HasType(MapCellType.End);

        private static bool HasType(this SetOfMapInters inters, MapCellType type)
            => inters.TL == type || inters.TR == type || inters.BL == type || inters.BR == type;
    }
}
