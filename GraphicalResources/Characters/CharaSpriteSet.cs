using System.Drawing;
using GameTypes.Cells;

namespace GraphicalResources.Characters
{
    /// <summary>
    /// A set of character sprites
    /// </summary>
    public class CharaSpriteSet
    {
        private readonly Bitmap front;
        private readonly Bitmap back;
        private readonly Bitmap toLeft;
        private readonly Bitmap toRight;

        /// <summary>
        /// ctor
        /// </summary>
        public CharaSpriteSet(Bitmap front, Bitmap back, Bitmap toLeft, Bitmap toRight)
        {
            this.front = front;
            this.back = back;
            this.toLeft = toLeft;
            this.toRight = toRight;
        }

        /// <summary>
        /// Get the desired image
        /// </summary>
        public Bitmap Get(CharaCellStateType? type)
        {
            if (type != null)
            {
                return type switch
                {
                    CharaCellStateType.LookFront => front,
                    CharaCellStateType.LookBack => back,
                    CharaCellStateType.LookToLeft => toLeft,
                    CharaCellStateType.LookToRight => toRight,
                    _ => CharaSprites.Default,
                };
            }
            return CharaSprites.Empty;
        }
    }
}
