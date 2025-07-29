namespace GameTypes.Cells
{
    /// <summary>
    /// State of a character cell
    /// </summary>
    public class CharaCellGroup
    {
        /// <summary>
        /// Horizontal position [col]
        /// </summary>
        public int X = 0;

        /// <summary>
        /// Vertical position [row]
        /// </summary>
        public int Y = 0;

        /// <summary>
        /// The character
        /// </summary>
        public CharaCellType chara;

        /// <summary>
        /// The character state
        /// </summary>
        public CharaCellStateType state;

        /// <summary>
        /// ctor
        /// </summary>
        public CharaCellGroup(CharaCellType chara, CharaCellStateType state)
        {
            this.chara = chara;
            this.state = state;
        }
    }
}
