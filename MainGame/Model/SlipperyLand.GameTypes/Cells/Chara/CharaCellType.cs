namespace SlipperyLand.GameTypes.Cells.Chara
{
    /// <summary>
    /// The possible cell states of the charaLook layer
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
