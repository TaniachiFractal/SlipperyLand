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
            CharaState = CharaCellStateType.LookFront,
            CharaType = CharaCellType.Hero,
        };

        /// <summary>
        /// ctor
        /// </summary>
        public CharaLayer(CharaLook mainCharacter)
        {
            MainChara.CharaLook = mainCharacter;
        }

        /// <summary>
        /// basic ctor
        /// </summary>
        public CharaLayer()
        { }
    }
}
