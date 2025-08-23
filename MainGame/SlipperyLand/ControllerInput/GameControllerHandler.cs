using System;
using System.Linq;
using System.Timers;
using SharpDX.DirectInput;
using SlipperyLand.ControllerInput;

namespace SlipperyLand
{
    /// <summary>
    /// Handles <see cref="SharpDX"/> controller input
    /// </summary>
    public class GameControllerHandler
    {
        /// <summary>
        /// Invoked upon the change of the game controller state
        /// </summary>
        public event EventHandler<ControllerStateEventArgs> ControllerStateChanged;

        private readonly DirectInput directInput;
        private readonly Joystick controller;
        private readonly Timer controllerTimer;
        private readonly bool enabled = false;

        /// <summary>
        /// ctor
        /// </summary>
        public GameControllerHandler()
        {
            directInput = new();
            try
            {
                controller = InitController();
                enabled = true;

                controllerTimer.AutoReset = true;
                controllerTimer.Elapsed += ControllerTimer_Elapsed;
                controllerTimer.Start();
            }
            catch (InvalidOperationException)
            {
                return;
            }
        }

        private void ControllerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckControllerState();
        }

        private void CheckControllerState()
        {
            if (enabled)
            {
                var controllerState = GetGamePadState();
                if (IsDifferent(controllerState))
                {
                    ControllerStateChanged.Invoke(this, controllerState);
                }
            }
        }

        private const int StickChangedPositionMargin = 10000;
        private const int DefaultStickPosition = 32767;

        private bool IsDifferent(ControllerStateEventArgs controllerState)
        {
            static int abs(int val) => Math.Abs(val);

            if (controllerState == null)
            {
                return false;
            }
            if (controllerState.Buttons.Count > 0)
            {
                return true;
            }
            if (controllerState.Direction != DpadDirection.None)
            {
                return true;
            }
            if (controllerState.L2 > 0 || controllerState.R2 > 0)
            {
                return true;
            }
            if (abs(controllerState.RX) > StickChangedPositionMargin ||
                abs(controllerState.RY) > StickChangedPositionMargin ||
                abs(controllerState.LX) > StickChangedPositionMargin ||
                abs(controllerState.LY) > StickChangedPositionMargin
                )
            {
                return true;
            }
            return false;
        }

        private ControllerStateEventArgs GetGamePadState()
        {
            var controllerState = new ControllerStateEventArgs();
            controller.Poll();

            var bufferedData = controller.GetBufferedData();
            foreach (var state in bufferedData)
            {
                if (state.Offset >= JoystickOffset.Buttons0 && state.Offset <= JoystickOffset.Buttons13)
                {
                    controllerState.Buttons.Add((ControllerButton)state.Offset);
                }
            }

            var axesState = controller.GetCurrentState();

            controllerState.LX = axesState.X - DefaultStickPosition;
            controllerState.LY = axesState.Y - DefaultStickPosition;

            controllerState.RX = axesState.Z - DefaultStickPosition;
            controllerState.RY = axesState.RotationZ - DefaultStickPosition;

            controllerState.L2 = axesState.RotationX;
            controllerState.R2 = axesState.RotationY;

            controllerState.Direction = (DpadDirection)axesState.PointOfViewControllers.FirstOrDefault();

            return controllerState;
        }

        private Joystick InitController()
        {
            var pad = new Joystick(directInput, GetControllerGuid());
            pad.Properties.BufferSize = byte.MaxValue;
            pad.Acquire();
            return pad;
        }

        private Guid GetControllerGuid()
        {
            var gameDevices = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            if (gameDevices == null || gameDevices.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var gameDevice = gameDevices.FirstOrDefault() ?? throw new InvalidOperationException();
            var padGuid = gameDevice.InstanceGuid;
            return padGuid;
        }

    }
}
