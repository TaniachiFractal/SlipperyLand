using System;
using System.Collections.Generic;
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
        /// When a button on the controller is pressed
        /// </summary>
        public event EventHandler<ControllerButton> ControllerButtonDown;

        /// <summary>
        /// When a button on the controller is released
        /// </summary>
        public event EventHandler<ControllerButton> ControllerButtonUp;

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

        private readonly static HashSet<ControllerButton> previousButtons = [];
        private void CheckControllerState()
        {
            if (controllerConnected)
            {
                if (TryGetGamePadState(out var controllerState))
                {
                    var justUnpressedButtons = previousButtons.Except(controllerState.Buttons);
                    foreach (var button in justUnpressedButtons)
                    {
                        ControllerButtonUp?.Invoke(this, button);
                    }
                    previousButtons.Clear();
                    foreach (var button in controllerState.Buttons)
                    {
                        ControllerButtonDown?.Invoke(this, button);
                        previousButtons.Add(button);
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

        private bool TryGetGamePadState(out ControllerState controllerState)
        {
            controllerState = new ControllerState();
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

            var dir = (DpadDirection)axesState.PointOfViewControllers.FirstOrDefault();

            if (leftDpad.Contains(dir))
            {
                controllerState.Buttons.Add(ControllerButton.DpadLeft);
            }
            if (rightDpad.Contains(dir))
            {
                controllerState.Buttons.Add(ControllerButton.DpadRight);
            }
            if (upDpad.Contains(dir))
            {
                controllerState.Buttons.Add(ControllerButton.DpadUp);
            }
            if (downDpad.Contains(dir))
            {
                controllerState.Buttons.Add(ControllerButton.DpadDown);
            }

            return true;
        }
        private readonly static HashSet<DpadDirection> leftDpad = [DpadDirection.Left, DpadDirection.UpLeft, DpadDirection.DownLeft];
        private readonly static HashSet<DpadDirection> rightDpad = [DpadDirection.Right, DpadDirection.UpRight, DpadDirection.DownRight];
        private readonly static HashSet<DpadDirection> upDpad = [DpadDirection.Up, DpadDirection.UpLeft, DpadDirection.UpRight];
        private readonly static HashSet<DpadDirection> downDpad = [DpadDirection.Down, DpadDirection.DownLeft, DpadDirection.DownRight];

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
