using System.Drawing;
using SlipperyLand.GameTypes.Cells.Chara;

namespace SlipperyLand.GraphicalResources.Characters
{
    /// <summary>
    /// A set of charaLook sprites
    /// </summary>
    public class CharaSpriteSet : GraphicsSet
    {
        /// <inheritdoc cref="CharaCellStateType.LookFront"/>
        public Bitmap front = CharaSprites.Default;
        /// <inheritdoc cref="CharaCellStateType.LookBack"/>
        public Bitmap back = CharaSprites.Default;
        /// <inheritdoc cref="CharaCellStateType.LookToLeft"/>
        public Bitmap toLeft = CharaSprites.Default;
        /// <inheritdoc cref="CharaCellStateType.LookToRight"/>
        public Bitmap toRight = CharaSprites.Default;

        /// <summary>
        /// Get the desired image
        /// </summary>
        public Bitmap Get(CharaCellStateType type)
            => type switch
            {
                CharaCellStateType.LookFront => front,
                CharaCellStateType.LookBack => back,
                CharaCellStateType.LookToLeft => toLeft,
                CharaCellStateType.LookToRight => toRight,
                _ => CharaSprites.Default,
            };

        /// <inheritdoc/>
        public override Bitmap GetDefault() => front;
    }
}
