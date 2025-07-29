using System.Collections.Generic;
using GameTypes.TileSpriteSetTypes;

namespace GraphicalResources.Characters
{
    /// <summary>
    /// Holds a Dictionary of <see cref="CharaSpriteSet"/>s
    /// </summary>
    public static class CharaSpriteSetDict
    {
        private readonly static Dictionary<Chara, CharaSpriteSet> dict = new()
        {
            {
                Chara.RedCat, new CharaSpriteSet()
                {
                    front = CharaSprites.RCfrontStand,
                    back = CharaSprites.RCbackStand,
                    toLeft = CharaSprites.RCtoLeftStand,
                    toRight = CharaSprites.RCtoRightStand,
                }
            }
        };

        /// <param name="chara">The sprite set ID</param>
        /// <returns>Desired chara sprite set</returns>
        public static CharaSpriteSet Get(Chara chara)
        {
            if (dict.TryGetValue(chara, out var spriteSet))
            {
                return spriteSet;
            }
            return null;
        }
    }
}
