namespace SlipperyLand.GameTypes.Cells.Map
{
    /// <summary>
    /// The possible cell states of the map layer
    /// </summary>
    public enum MapCellType : byte
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Continue moving
        /// </summary>
        Slippery = 1,

        /// <summary>
        /// Stop moving and stay on it
        /// </summary>
        Rough = 2,

        /// <summary>
        /// Stop moving and stay on previous
        /// </summary>
        Wall = 3,

        /// <summary>
        /// The start cell
        /// </summary>
        Start = 4,

        /// <summary>
        /// The end cell
        /// </summary>
        End = 5,
    }
}
