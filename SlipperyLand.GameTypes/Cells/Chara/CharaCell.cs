using SlipperyLand.Common.Types;
using SlipperyLand.GameTypes.TileSpriteSetTypes;

namespace SlipperyLand.GameTypes.Cells.Chara
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
        /// The size of the sprite
        /// </summary>
        public int SpriteSize = 0;

        /// <summary>
        /// The hitbox of the character
        /// </summary>
        public SimpleRect Hitbox;

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
