namespace GameTypes.Cells
{
    /// <summary>
    /// The possible cell states of the character layer
    /// </summary>
    public enum CharacterCellType : byte
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Player looks front
        /// </summary>
        PFront,

        /// <summary>
        /// Player looks back
        /// </summary>
        PBack,

        /// <summary>
        /// Player looks to left
        /// </summary>
        PtoLeft,

        /// <summary>
        /// Player looks to right
        /// </summary>
        PtoRight,

        /// <summary>
        /// Cell with no characters
        /// </summary>
        Empty
    }
}
