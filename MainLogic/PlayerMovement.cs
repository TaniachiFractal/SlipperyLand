using System.Diagnostics;
using System.Numerics;
using Common.Types;
using GameTypes.Cells;

namespace MainLogic
{
    /// <summary>
    /// Implementations for player movement
    /// </summary>
    public static class PlayerMovement
    {
        private static Stopwatch stopwatch = new();

        /// <summary>
        /// Update the hero
        /// </summary>
        public static void UpdateHero(this CharaCell hero, KeyboardState ks)
        {
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

        private static Vector2 GetVelocity(KeyboardState ks)
        {
            stopwatch.Stop();
            var velocity = Vector2.Zero;
            var speed = 1;

            if (ks.LeftKeyDown)
                velocity.X -= speed;
            if (ks.RightKeyDown)
                velocity.X += speed;
            if (ks.UpKeyDown)
                velocity.Y -= speed;
            if (ks.DownKeyDown)
                velocity.Y += speed;

            return velocity;
        }

        private static void MoveHero(this CharaCell hero, KeyboardState ks)
        {
            var velocity = GetVelocity(ks);
            hero.X += velocity.X;
            hero.Y += velocity.Y;
        }
    }
}
