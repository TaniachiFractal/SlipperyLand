using GameTypes.Cells;

namespace GameTypes.Extensions
{
    /// <summary>
    /// Extensions for Charas
    /// </summary>
    public static class CharaExtensions
    {
        /// <summary>
        /// Change charaType position
        /// </summary>
        public static void ChangePosition(this CharaCell cellGroup, int X, int Y)
        {
            cellGroup.X = X;
            cellGroup.Y = Y;
        }
    }
}
