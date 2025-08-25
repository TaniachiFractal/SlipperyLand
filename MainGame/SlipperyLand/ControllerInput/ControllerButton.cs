using SharpDX.DirectInput;

namespace SlipperyLand.ControllerInput
{
    /// <summary>
    /// The buttons on a game controller
    /// </summary>
    public enum ControllerButton
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        None = 0,

        X_Square = JoystickOffset.Buttons0,
        A_Cross = JoystickOffset.Buttons1,
        B_Circle = JoystickOffset.Buttons2,
        Y_Triangle = JoystickOffset.Buttons3,

        L1 = JoystickOffset.Buttons4,
        R1 = JoystickOffset.Buttons5,

        L2 = JoystickOffset.Buttons6,
        R2 = JoystickOffset.Buttons7,

        Select_Share = JoystickOffset.Buttons8,
        Start_Options = JoystickOffset.Buttons9,

        HardLPress = JoystickOffset.Buttons10,
        HardRPress = JoystickOffset.Buttons11,

        Icon = JoystickOffset.Buttons12,

        Touchpad = JoystickOffset.Buttons13,

        DpadUp,
        DpadDown,
        DpadLeft,
        DpadRight,
    }
}
