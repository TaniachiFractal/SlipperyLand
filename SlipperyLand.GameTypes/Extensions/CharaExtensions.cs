using SlipperyLand.GameTypes.Cells;

namespace SlipperyLand.GameTypes.Extensions
{
    /// <summary>
    /// Extensions for Charas
    /// </summary>
    public static class CharaExtensions
    {
        /// <summary>
        /// Copy only the <see cref="CharaCell"/> location data from <paramref name="source"/> to <paramref name="target"/>
        /// </summary>
        public static void CopyLocationTo(this CharaCell source, CharaCell target)
        {
            if (target != null)
            {
                target.X = source.X;
                target.Y = source.Y;
                target.XAcum = source.XAcum;
                target.YAcum = source.YAcum;
            }
        }
    }
}
