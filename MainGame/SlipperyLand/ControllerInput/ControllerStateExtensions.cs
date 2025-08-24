using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SlipperyLand.ControllerInput
{
    /// <summary>
    /// Extensions for <see cref="ControllerStateEventArgs"/>
    /// </summary>
    public static class ControllerStateExtensions
    {
        private const int StickChangedPositionMargin = 10000;

        private readonly static HashSet<DpadDirection> leftDpad = [DpadDirection.Left, DpadDirection.UpLeft, DpadDirection.DownLeft];
        private readonly static HashSet<DpadDirection> rightDpad = [DpadDirection.Right, DpadDirection.UpRight, DpadDirection.DownRight];
        private readonly static HashSet<DpadDirection> upDpad = [DpadDirection.Up, DpadDirection.UpLeft, DpadDirection.UpRight];
        private readonly static HashSet<DpadDirection> downDpad = [DpadDirection.Down, DpadDirection.DownLeft, DpadDirection.DownRight];

        /// <summary>
        /// Get a <see cref="List{T}"/> of keyboard <see cref="Key"/>s that corresponds to the <paramref name="controllerState"/>
        /// </summary>
        public static HashSet<Key> ToKeyboardKeySet(this ControllerStateEventArgs controllerState)
        {
            static int abs(int val) => Math.Abs(val);

            var keyboardKeySet = new HashSet<Key>();

            foreach (var button in controllerState.Buttons)
            {
                if (controllerBtKeyboardKeys.TryGetValue(button, out var key))
                {
                    keyboardKeySet.Add(key);
                }
            }

            var dir = controllerState.Direction;
            if (leftDpad.Contains(dir))
            {
                keyboardKeySet.Add(Key.Left);
            }
            if (rightDpad.Contains(dir))
            {
                keyboardKeySet.Add(Key.Right);
            }
            if (upDpad.Contains(dir))
            {
                keyboardKeySet.Add(Key.Up);
            }
            if (downDpad.Contains(dir))
            {
                keyboardKeySet.Add(Key.Down);
            }

            if (abs(controllerState.LX) > StickChangedPositionMargin)
            {
                if (controllerState.LX < 0)
                {
                    keyboardKeySet.Add(Key.Left);
                }
                else if (controllerState.LX > 0)
                {
                    keyboardKeySet.Add(Key.Right);
                }
            }
            if (abs(controllerState.LY) > StickChangedPositionMargin)
            {
                if (controllerState.LY < 0)
                {
                    keyboardKeySet.Add(Key.Up);
                }
                else if (controllerState.LY > 0)
                {
                    keyboardKeySet.Add(Key.Down);
                }
            }
            return keyboardKeySet;
        }

        private static readonly Dictionary<ControllerButton, Key> controllerBtKeyboardKeys = new()
        {
            {ControllerButton.A_Cross, Key.E },
            {ControllerButton.B_Circle, Key.Q },
            {ControllerButton.X_Square, Key.Z },
            {ControllerButton.Y_Triangle, Key.X },
            {ControllerButton.L1, Key.R },
            {ControllerButton.L2, Key.T },
            {ControllerButton.R1, Key.Y },
            {ControllerButton.R2, Key.U },
            {ControllerButton.Select_Share, Key.Tab },
            {ControllerButton.Start_Options, Key.Escape },
            {ControllerButton.HardLPress, Key.F },
            {ControllerButton.HardRPress, Key.G },
            {ControllerButton.Icon, Key.B },
            {ControllerButton.Touchpad, Key.Space},
        };
    }
}
