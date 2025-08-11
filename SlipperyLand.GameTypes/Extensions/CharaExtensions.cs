using SlipperyLand.Common.Extensions;
using SlipperyLand.GameTypes.Cells.Chara;

namespace SlipperyLand.GameTypes.Extensions
{
    /// <summary>
    /// Extensions for Charas
    /// </summary>
    public static class CharaExtensions
    {
        private const float DefaultHitboxTop = 0.6f;
        private const int DefaultHitboxSidesOffset = 2;

        /// <summary>
        /// Set the size of the sprite
        /// </summary>
        public static void SetSpriteSize(this CharaCell cell, int size)
            => cell.SpriteSize = size;

        /// <summary>
        /// Setup the default hitbox
        /// </summary>
        public static void SetupHitbox(this CharaCell cell)
            => cell.Hitbox = new()
            {
                Bottom = cell.SpriteSize,
                Left = DefaultHitboxSidesOffset,
                Right = cell.SpriteSize - DefaultHitboxSidesOffset,
                Top = (cell.SpriteSize * DefaultHitboxTop).Round()
            };

        /// <summary>
        /// Set the position of a <see cref="CharaCell"/> based on map row and col
        /// </summary>
        public static void SetCharaRowColPos(this CharaCell chara, int row, int col, int tileSize)
        {
            chara.X = row * tileSize;
            chara.Y = (col * tileSize) - (tileSize / 3);
        }

        /// <summary>
        /// Copy only the X AXIS location data from <paramref name="source"/> <see cref="CharaCell"/> to the <paramref name="target"/> one
        /// </summary>
        public static void CopyXLocatDataTo(this CharaCell source, CharaCell target)
        {
            target.X = source.X;
            target.XAcum = source.XAcum;
        }

        /// <summary>
        /// Copy only the Y AXIS location data from <paramref name="source"/> <see cref="CharaCell"/> to the <paramref name="target"/> one
        /// </summary>
        public static void CopyYLocatDataTo(this CharaCell source, CharaCell target)
        {
            target.Y = source.Y;
            target.YAcum = source.YAcum;
        }
    }
}
