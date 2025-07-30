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
        public readonly CharaCell MainChara = new CharaCell()
        {
            charaLook = CharaLook.RedCat,
            charaState = CharaCellStateType.LookFront,
            charaType = CharaCellType.Hero,
        };

        /// <summary>
        /// The other characters
        /// </summary>
        public readonly List<CharaCell> OtherCharas = new List<CharaCell>();
    }
}
