using System.Drawing;
using GameTypes.Cells;
using GraphicalResources.Map;

namespace GraphicalResources.Characters.MainChara
{
    /// <summary>
    /// A set of main character sprites
    /// </summary>
    public class MainCharaSpriteSet
    {
        /// <inheritdoc cref="CharacterCellType.PFront"/>
        public readonly Bitmap PFront;

        /// <inheritdoc cref="CharacterCellType.PBack"/>
        public readonly Bitmap PBack;

        /// <inheritdoc cref="CharacterCellType.PtoLeft"/>
        public readonly Bitmap PtoLeft;

        /// <inheritdoc cref="CharacterCellType.PtoRight"/>
        public readonly Bitmap PtoRight;

        /// <summary>
        /// ctor
        /// </summary>
        public MainCharaSpriteSet(Bitmap pFront, Bitmap pBack, Bitmap ptoLeft, Bitmap ptoRight)
        {
            PFront = pFront;
            PBack = pBack;
            PtoLeft = ptoLeft;
            PtoRight = ptoRight;
        }

        /// <summary>
        /// Get the desired image by <see cref="CharacterCellType"/>
        /// </summary>
        public Bitmap Get(CharacterCellType type)
        {
            return type switch
            {
                CharacterCellType.PFront => PFront,
                CharacterCellType.PBack => PBack,
                CharacterCellType.PtoLeft => PtoLeft,
                CharacterCellType.PtoRight => PtoRight,
                CharacterCellType.None => MapTiles.Default,
                _ => MapTiles.Default,
            };
        }

    }
}
