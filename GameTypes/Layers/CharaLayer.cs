using System.Collections.Generic;
using GameTypes.Cells;

namespace GameTypes.Layers
{
    /// <summary>
    /// The character layer
    /// </summary>
    public class CharaLayer
    {
        /// <summary>
        /// The main character
        /// </summary>
        public readonly CharaCellGroup MainChara = new CharaCellGroup(CharaCellType.Hero, CharaCellStateType.LookFront);

        /// <summary>
        /// The other characters
        /// </summary>
        public readonly List<CharaCellGroup> OtherCharas = new List<CharaCellGroup>();
    }
}
