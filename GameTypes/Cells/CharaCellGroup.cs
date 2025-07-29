using GameTypes.TileSpriteSetTypes;

namespace GameTypes.Cells
{
    /// <summary>
    /// State of a charaLook cell
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
        /// The charaLook type
        /// </summary>
        public CharaCellType charaType;

        /// <summary>
        /// The charaLook state
        /// </summary>
        public CharaCellStateType state;

        /// <summary>
        /// The characterLook
        /// </summary>
        public CharaLook charaLook;

        /// <summary>
        /// ctor
        /// </summary>
        public CharaCellGroup(CharaCellType charaType, CharaCellStateType state, CharaLook charaLook)
        {
            this.charaType = charaType;
            this.state = state;
            this.charaLook = charaLook;
        }
    }
}
