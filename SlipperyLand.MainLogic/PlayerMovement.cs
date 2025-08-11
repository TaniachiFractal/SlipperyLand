using System;
using System.Diagnostics;
using System.Numerics;
using SlipperyLand.Common;
using SlipperyLand.Common.Extensions;
using SlipperyLand.Common.Types;
using SlipperyLand.GameTypes.Cells.Chara;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.MainLogic
{
    /// <summary>
    /// Implementations for player movement
    /// </summary>
    public static class PlayerMovement
    {
        /// <summary>
        /// The map tile size
        /// </summary>
        public static int TileSize = 0;

        private static CharaCell futureHeroY;
        private static CharaCell futureHeroX;

        /// <summary>
        /// Update the hero
        /// </summary>
        public static void UpdateHero(this CharaCell hero, MapLayer map, KeyboardState ks)
        {
            void IfFutureNullCopyFromHero(ref CharaCell futureHero)
            {
                if (futureHero == null)
                {
                    futureHero = new();
                    hero.CopyTo(futureHero);
                }
            }
            IfFutureNullCopyFromHero(ref futureHeroX);
            IfFutureNullCopyFromHero(ref futureHeroY);

            hero.RotateHero(ks);
            hero.UpdateLocationOfHero(map, ks);
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

        private static void MoveHero(this CharaCell hero, Vector2 velocity, bool onX)
        {
            if (onX)
            {
                hero.XAcum += velocity.X;
                var moveX = hero.XAcum;
                hero.X += moveX.Round();
                hero.XAcum -= moveX;
            }
            else
            {
                hero.YAcum += velocity.Y;
                var moveY = hero.YAcum;
                hero.Y += moveY.Round();
                hero.YAcum -= moveY;
            }
        }

        private static void UpdateLocationOfHero(this CharaCell hero, MapLayer map, KeyboardState ks)
        {
            hero.CopyXLocatDataTo(futureHeroX);
            hero.CopyYLocatDataTo(futureHeroY);
            var velocity = GetVelocity(ks);
            futureHeroX.MoveHero(velocity, onX: true);
            futureHeroY.MoveHero(velocity, onX: false);
            BP.Break();
            if (!futureHeroX.IntersectsWall(map))
            {
                futureHeroX.CopyXLocatDataTo(hero);
                futureHeroX.CopyXLocatDataTo(futureHeroY);
            }
            if (!futureHeroY.IntersectsWall(map))
            {
                futureHeroY.CopyYLocatDataTo(hero);
                futureHeroY.CopyYLocatDataTo(futureHeroX);
            }
            BP.Release();
        }

        private static bool IntersectsWall(this CharaCell hero, MapLayer map)
            => hero.GetIntersections(map, TileSize).HasWall;
    }
}
