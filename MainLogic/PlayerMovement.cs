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
        /// Execute the movement
        /// </summary>
        public static void MoveHero(this CharaCell hero, Direction dir, KeyboardState ks)
        {
            hero.RotateHero(dir);

            if (ks.LeftKeyDown)
                hero.X++;
            if (ks.RightKeyDown)
                hero.X--;
            if (ks.UpKeyDown)
                hero.Y--;
            if (ks.DownKeyDown)
                hero.Y++;
        }

        /// <summary>
        /// Change hero's visual direction
        /// </summary>
        public static void RotateHero(this CharaCell hero, Direction dir)
            => hero.charaState = dir switch
            {
                Direction.Up => CharaCellStateType.LookBack,
                Direction.Down => CharaCellStateType.LookFront,
                Direction.Right => CharaCellStateType.LookToRight,
                Direction.Left => CharaCellStateType.LookToLeft,
                _ => CharaCellStateType.LookFront,
            };
    }
}
