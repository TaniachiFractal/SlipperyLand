using System.Collections.Generic;
using CellTypes.TileSpriteSetTypes;

namespace GraphicalResources.Characters.MainChara
{
    /// <summary>
    /// Holds a Dictionary of <see cref="MainCharaSpriteSets"/> to <see cref="MainCharaSpriteSet"/>
    /// </summary>
    public static class MainCharaSpriteSetDict
    {
        private readonly static Dictionary<MainCharaSpriteSets, MainCharaSpriteSet> dict = new()
        {
            { MainCharaSpriteSets.RedCat, new MainCharaSpriteSet(MainCharaSprites.RCfrontStand, MainCharaSprites.RCbackStand,
                MainCharaSprites.RCtoLeftStand, MainCharaSprites.RCtoRightStand) }
        };

        /// <param name="type">The sprite set ID</param>
        /// <returns>Desired main chara sprite set</returns>
        public static MainCharaSpriteSet Get(MainCharaSpriteSets type) => dict[type];
    }
}
