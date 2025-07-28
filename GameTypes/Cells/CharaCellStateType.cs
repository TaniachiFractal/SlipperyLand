namespace GameTypes.Cells
{
    /// <summary>
    /// The possible additional states of character cells
    /// </summary>
    public enum CharaCellStateType : byte
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// Chara looks front
        /// </summary>
        LookFront,

        /// <summary>
        /// Chara looks back
        /// </summary>
        LookBack,

        /// <summary>
        /// Chara looks to left
        /// </summary>
        LookToLeft,

        /// <summary>
        /// Chara looks to right
        /// </summary>
        LookToRight,
    }
}
