using System;
using System.Diagnostics;
using System.Numerics;
using SlipperyLand.Common.Extensions;
using SlipperyLand.Common.Types;
using SlipperyLand.GameTypes.Cells.Chara;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.MainLogic
{
    /// <summary>
    /// Implementations for player movement
    /// </summary>
    public static class PlayerMovement
    {
        #region public fields

        /// <summary>
        /// Invoked upon reaching a win cell
        /// </summary>
        public static event EventHandler<EventArgs> OnWinCell;

        /// <summary>
        /// The map tile size
        /// </summary>
        public static int TileSize = 0;

        #endregion

        private static CharaCell futureHeroY;
        private static CharaCell futureHeroX;
        private static Vector2 oldDirection = new();

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

        private static void UpdateLocationOfHero(this CharaCell hero, MapLayer map, KeyboardState ks)
        {
            var heroInter = hero.GetIntersections(map, TileSize);
            var direction = DetermineDirection(heroInter, ks);
            var velocity = direction.GetVelocity();

            hero.CopyLocatDataTo(futureHeroX, xData: true);
            hero.CopyLocatDataTo(futureHeroY, xData: false);

            futureHeroX.MoveHero(velocity, onX: true);
            futureHeroY.MoveHero(velocity, onX: false);
            var futureXInter = futureHeroX.GetIntersections(map, TileSize);
            var futureYInter = futureHeroY.GetIntersections(map, TileSize);

            void HandleInter(bool HasWall, CharaCell source, ref CharaCell target, bool xData)
            {
                if (HasWall)
                {
                    oldDirection.Reset();
                    direction.Reset();
                }
                else
                {
                    source.CopyLocatDataTo(hero, xData);
                    source.CopyLocatDataTo(target, xData);
                }
            }
            HandleInter(futureXInter.HasWall, futureHeroX, ref futureHeroY, xData: true);
            HandleInter(futureYInter.HasWall, futureHeroY, ref futureHeroX, xData: false);

            heroInter = hero.GetIntersections(map, TileSize);
            CheckWin(heroInter);

            oldDirection = direction;
        }

        #region direction and velocity

        private static Vector2 GetDirection(KeyboardState ks)
        {
            var velocity = Vector2.Zero;

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
            }
            return velocity;
        }

        private const float SpeedPerMs = 0.065f;
        private readonly static Stopwatch stopwatch = new();

        private static Vector2 GetVelocity(this Vector2 direction)
        {
            stopwatch.Stop();
            var speed = SpeedPerMs * stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();
            return direction * speed;
        }

        #endregion

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

        private static Vector2 DetermineDirection(SetOfMapInters heroInter, KeyboardState ks)
        {
            if (heroInter.HasSlip && !oldDirection.IsZero())
            {
                return oldDirection;
            }
            return GetDirection(ks);
        }

        private static bool playing = true;
        private static void CheckWin(SetOfMapInters inters)
        {
            if (inters.HasEnd && oldDirection.IsZero() && playing)
            {
                playing = false;
                OnWinCell?.Invoke(null, EventArgs.Empty);
            }
        }

        private static void Reset(this ref Vector2 vector)
        {
            vector.X = 0;
            vector.Y = 0;
        }

        private static bool IsZero(this Vector2 vector)
            => vector.X == 0 && vector.Y == 0;
    }
}
