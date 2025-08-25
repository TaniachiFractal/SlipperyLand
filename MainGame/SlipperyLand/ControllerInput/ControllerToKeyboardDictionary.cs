using System.Collections.Generic;
using System.Windows.Input;

namespace SlipperyLand.ControllerInput
{
    internal class ControllerToKeyboardDictionary
    {
        /// <summary>
        /// Controller buttons to keyboard keys
        /// </summary>
        public static readonly Dictionary<ControllerButton, Key> Dict = new()
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
            {ControllerButton.DpadDown, Key.Down},
            {ControllerButton.DpadUp, Key.Up},
            {ControllerButton.DpadLeft, Key.Left},
            {ControllerButton.DpadRight, Key.Right},
        };
    }
}
