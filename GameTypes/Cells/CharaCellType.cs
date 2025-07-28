namespace GameTypes.Cells
{
    /// <summary>
    /// The possible cell states of the character layer
    /// </summary>
    public enum CharaCellType : byte
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Player
        /// </summary>
        Hero,

        /// <summary>
        /// Cell with no characters
        /// </summary>
        Empty
    }
}
