using System.Collections.Generic;
using GameTypes.Cells;
using GameTypes.TileSpriteSetTypes;

namespace GameTypes.Layers
{
    /// <summary>
    /// The chara layer
    /// </summary>
    public class CharaLayer
    {
        /// <summary>
        /// The main chara
        /// </summary>
        public readonly CharaCellGroup MainChara = new CharaCellGroup(CharaCellType.Hero, CharaCellStateType.LookFront, CharaLook.RedCat);

        /// <summary>
        /// The other characters
        /// </summary>
        public readonly List<CharaCellGroup> OtherCharas = new List<CharaCellGroup>();
    }
}
