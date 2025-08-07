using System.Diagnostics;
using System.Numerics;
using Common;
using Common.Types;
using GameTypes.Cells;
using GameTypes.Extensions;
using GameTypes.Layers;

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
        public static void UpdateHero(this CharaCell hero, MapLayer map, int tileSize, KeyboardState ks)
        {
            hero.RotateHero(ks);
            hero.UpdateLocationOfHero(map, tileSize, ks);
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

        private const float SpeedPerMs = 0.065f;
        private readonly static Stopwatch stopwatch = new();

        private static Vector2 GetVelocity(KeyboardState ks)
        {
            stopwatch.Stop();
            var velocity = Vector2.Zero;
            var speed = SpeedPerMs * stopwatch.ElapsedMilliseconds;

            if (ks.LeftKeyDown)
                velocity.X--;
            if (ks.RightKeyDown)
                velocity.X++;
            if (ks.UpKeyDown)
                velocity.Y--;
            if (ks.DownKeyDown)
                velocity.Y++;

            if (velocity.X != 0 || velocity.Y != 0)
            {
                velocity = Vector2.Normalize(velocity);
                velocity *= speed;
            }
            stopwatch.Restart();
            return velocity;
        }

        private static void MoveHero(this CharaCell hero, KeyboardState ks)
        {
            var velocity = GetVelocity(ks);
            hero.XAcum += velocity.X;
            hero.YAcum += velocity.Y;
            var moveX = hero.XAcum;
            var moveY = hero.YAcum;
            hero.X += moveX.Round();
            hero.Y += moveY.Round();
            hero.XAcum -= moveX;
            hero.YAcum -= moveY;
        }

        private readonly static CharaCell futureHero = new();

        private static void UpdateLocationOfHero(this CharaCell hero, MapLayer map, int tileSize, KeyboardState ks)
        {
            hero.CopyLocationTo(futureHero);
            futureHero.MoveHero(ks);

            var heroCol = futureHero.X / tileSize;
            var heroRow = futureHero.Y / tileSize;

            var heroCellType = map.ReadCell(heroRow, heroCol).mapCellType;

            if (heroCellType != MapCellType.Wall)
            {
                futureHero.CopyLocationTo(hero);
            }
        }
    }
}
