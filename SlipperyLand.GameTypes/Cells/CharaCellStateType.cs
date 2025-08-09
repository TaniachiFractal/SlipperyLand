namespace SlipperyLand.GameTypes.Cells
{
    /// <summary>
    /// The possible additional states of charaLook cells
    /// </summary>
    public enum CharaCellStateType : byte
    {
        /// <summary>
        /// Default
        /// </summary>
        None = 0,

        /// <summary>
        /// CharaLook looks front
        /// </summary>
        LookFront,

        /// <summary>
        /// CharaLook looks back
        /// </summary>
        LookBack,

        /// <summary>
        /// CharaLook looks to left
        /// </summary>
        LookToLeft,

        /// <summary>
        /// CharaLook looks to right
        /// </summary>
        LookToRight,
    }
}
