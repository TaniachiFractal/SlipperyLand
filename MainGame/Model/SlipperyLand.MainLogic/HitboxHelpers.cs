using SlipperyLand.Common.Types;
using SlipperyLand.GameTypes.Cells.Chara;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.MainLogic
{
    /// <summary>
    /// Helpers for <see cref="SimpleRect"/> hitboxes of <see cref="CharaCell"/>s
    /// </summary>
    internal static class HitboxHelpers
    {
        /// <summary>
        /// Get the <see cref="MapCellType"/>s of the cells that <see cref="CharaCell"/>'s hitbox intersects
        /// </summary>
        public static SetOfMapInters GetIntersections(this CharaCell chara, MapLayer map, int tileSize)
        {
            var h = chara.Hitbox;
            var x = chara.X;
            var y = chara.Y;
            var TL = map.GetCellOnCoord(h.Left + x, h.Top + y, tileSize);
            var TR = map.GetCellOnCoord(h.Right + x, h.Top + y, tileSize);
            var BL = map.GetCellOnCoord(h.Left + x, h.Bottom + y, tileSize);
            var BR = map.GetCellOnCoord(h.Right + x, h.Bottom + y, tileSize);
            return new SetOfMapInters(TL, TR, BL, BR);
        }

        private static MapCellType GetCellOnCoord(this MapLayer map, int X, int Y, int tileSize)
        {
            var col = X / tileSize;
            var row = Y / tileSize;

            return map.ReadCell(row, col).mapCellType;
        }
    }
}
