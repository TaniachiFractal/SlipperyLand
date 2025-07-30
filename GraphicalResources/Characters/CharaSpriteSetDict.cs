using System.Collections.Generic;
using GameTypes.TileSpriteSetTypes;

namespace GraphicalResources.Characters
{
    /// <summary>
    /// Holds a Dictionary of <see cref="CharaSpriteSet"/>s
    /// </summary>
    public static class CharaSpriteSetDict
    {
        private readonly static Dictionary<CharaLook, CharaSpriteSet> dict = new()
        {
            {
                CharaLook.RedCat, new CharaSpriteSet()
                {
                    front = CharaSprites.RCfrontStand,
                    back = CharaSprites.RCbackStand,
                    toLeft = CharaSprites.RCtoLeftStand,
                    toRight = CharaSprites.RCtoRightStand,
                }
            },
            {
                CharaLook.IceGolem, new CharaSpriteSet()
                {
                    front = CharaSprites.IGfrontStand,
                    back = CharaSprites.IGbackStand,
                    toLeft = CharaSprites.IGtoLeftStand,
                    toRight = CharaSprites.IGtoRightStand,
                }
            }
        };

        /// <param name="chara">The sprite set ID</param>
        /// <returns>Desired charaType sprite set</returns>
        public static CharaSpriteSet Get(CharaLook chara)
        {
            if (dict.TryGetValue(chara, out var spriteSet))
            {
                return spriteSet;
            }
            return null;
        }
    }
}
