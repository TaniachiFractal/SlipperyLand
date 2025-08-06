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
        public int X = 0;

        /// <summary>
        /// Vertical position [row]
        /// </summary>
        public int Y = 0;

        /// <summary>
        /// Accumulator for the fractional part of the <see cref="X"/> coordinate
        /// </summary>
        public float XAcum = 0;

        /// <summary>
        /// Accumulator for the fractional part of the <see cref="Y"/> coordinate
        /// </summary>
        public float YAcum = 0;

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
