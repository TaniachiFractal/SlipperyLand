namespace GameTypes.Cells
{
    /// <summary>
    /// State of a character cell
    /// </summary>
    public class CharaCellGroup
    {
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
