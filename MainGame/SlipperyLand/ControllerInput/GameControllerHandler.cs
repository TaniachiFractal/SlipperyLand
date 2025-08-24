using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;
using SharpDX.DirectInput;
using SlipperyLand.ControllerInput;

namespace SlipperyLand
{
    /// <summary>
    /// Handles <see cref="DirectInput"/> controller input
    /// </summary>
    public class GameControllerHandler
    {
        /// <summary>
        /// Invoked when the state of the controller is changed
        /// </summary>
        public event EventHandler<ControllerStateEventArgs> ControllerStateChanged;

        private readonly DirectInput directInput;
        private Joystick controller;
        private readonly Timer controllerTimer;

        private bool controllerConnected = false;

        /// <summary>
        /// ctor
        /// </summary>
        public GameControllerHandler()
        {
            directInput = new();

            controllerTimer = new Timer();
            controllerTimer.Elapsed += ControllerTimer_Elapsed;
            controllerTimer.Start();
        }
        private void ControllerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckControllerState();
        }

        private ControllerStateEventArgs previousState;
        private void CheckControllerState()
        {
            if (controllerConnected)
            {
                if (TryGetGamePadState(out var controllerState))
                {
                    if (controllerState != previousState)
                    {
                        ControllerStateChanged?.Invoke(this, controllerState);
                        previousState = controllerState;
                    }
                }
                else
                {
                    controllerConnected = false;
                }
            }
            else
            {
                controllerConnected = TryInitController(out controller);
            }
        }

        private const int DefaultStickPosition = 32767;

        private bool TryGetGamePadState(out ControllerStateEventArgs controllerState)
        {
            controllerState = new ControllerStateEventArgs();
            JoystickUpdate[] bufferedData;
            JoystickState axesState;
            try
            {
                controller.Poll();
                bufferedData = controller.GetBufferedData();
                axesState = controller.GetCurrentState();
            }
            catch (SharpDX.SharpDXException)
            {
                return false;
            }

            foreach (var state in bufferedData)
            {
                if (state.Offset >= JoystickOffset.Buttons0 && state.Offset <= JoystickOffset.Buttons13)
                {
                    controllerState.Buttons.Add((ControllerButton)state.Offset);
                }
            }

            controllerState.LX = axesState.X - DefaultStickPosition;
            controllerState.LY = axesState.Y - DefaultStickPosition;

            controllerState.RX = axesState.Z - DefaultStickPosition;
            controllerState.RY = axesState.RotationZ - DefaultStickPosition;

            controllerState.L2 = axesState.RotationX;
            controllerState.R2 = axesState.RotationY;

            controllerState.Direction = (DpadDirection)axesState.PointOfViewControllers.FirstOrDefault();

            return true;
        }

        private bool TryInitController(out Joystick pad)
        {
            pad = null;
            if (TryGetControllerGuid(out var padGuid))
            {
                pad = new Joystick(directInput, padGuid);
                pad.Properties.BufferSize = byte.MaxValue;
                pad.Acquire();
                return true;
            }
            return false;
        }

        private bool TryGetControllerGuid(out Guid padGuid)
        {
            padGuid = Guid.Empty;
            var gameDevices = directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AttachedOnly);
            if (gameDevices == null || gameDevices.Count == 0)
            {
                return false;
            }
            var gameDevice = gameDevices.FirstOrDefault();
            if (gameDevice == null)
            {
                return false;
            }
            padGuid = gameDevice.InstanceGuid;
            return true;
        }

    }
}
