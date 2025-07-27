namespace GameTypes.Cells
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
        Slippery,

        /// <summary>
        /// Stop moving and stay on it
        /// </summary>
        Rough,

        /// <summary>
        /// Stop moving and stay on previous
        /// </summary>
        Wall
    }
}
