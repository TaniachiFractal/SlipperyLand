using System.Collections.Generic;
using SlipperyLand.GameTypes.Cells.Chara;
using SlipperyLand.GameTypes.TileSpriteSetTypes;

namespace SlipperyLand.GameTypes.Layers
{
    /// <summary>
    /// The chara layer
    /// </summary>
    public class CharaLayer
    {
        /// <summary>
        /// The main chara
        /// </summary>
        public CharaCell MainChara = new()
        {
            charaState = CharaCellStateType.LookFront,
            charaType = CharaCellType.Hero,
        };

        /// <summary>
        /// The other characters
        /// </summary>
        public readonly List<CharaCell> OtherCharas = [];

        /// <summary>
        /// ctor
        /// </summary>
        public CharaLayer(CharaLook mainCharacter)
        {
            MainChara.charaLook = mainCharacter;
        }
    }
}
