using GameTypes.TileSpriteSetTypes;

namespace GameTypes.Cells
{
    /// <summary>
    /// A character cell
    /// </summary>
    public class CharaCell
    {
        /// <summary>
        /// Horizontal position [col]
        /// </summary>
        public float X = 0;

        /// <summary>
        /// Vertical position [row]
        /// </summary>
        public float Y = 0;

        /// <summary>
        /// The chara type
        /// </summary>
        public CharaCellType charaType;

        /// <summary>
        /// The chara state
        /// </summary>
        public CharaCellStateType charaState;

        /// <summary>
        /// The character look
        /// </summary>
        public CharaLook charaLook;
    }
}
