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
                Left = 0,
                Right = cell.SpriteSize,
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
    }
}
