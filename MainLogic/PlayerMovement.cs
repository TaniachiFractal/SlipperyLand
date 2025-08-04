using System.Diagnostics;
using Common.Types;
using GameTypes;
using GameTypes.Cells;

namespace MainLogic
{
    /// <summary>
    /// Implementations for player movement
    /// </summary>
    public static class PlayerMovement
    {
        /// <summary>
        /// Update the hero
        /// </summary>
        public static void UpdateHero(this CharaCell hero, KeyboardState ks)
        {
           // Debug.WriteLine(ks.ToString());
            hero.RotateHero(ks);
            hero.MoveHero(ks);
        }

        private static void RotateHero(this CharaCell hero, KeyboardState ks)
        {
            if (ks.LeftKeyDown)
                hero.charaState = CharaCellStateType.LookToLeft;
            if (ks.RightKeyDown)
                hero.charaState = CharaCellStateType.LookToRight;
            if (ks.UpKeyDown)
                hero.charaState = CharaCellStateType.LookBack;
            if (ks.DownKeyDown)
                hero.charaState = CharaCellStateType.LookFront;
        }

        private static void MoveHero(this CharaCell hero, KeyboardState ks)
        {
            if (ks.LeftKeyDown)
                hero.X--;
            if (ks.RightKeyDown)
                hero.X++;
            if (ks.UpKeyDown)
                hero.Y--;
            if (ks.DownKeyDown)
                hero.Y++;
        }
    }
}
