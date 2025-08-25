using System;
using System.Collections.Generic;

namespace SlipperyLand.ControllerInput
{
    /// <summary>
    /// State of a controller
    /// </summary>
    public class ControllerState
    {
        /// <summary>
        /// <see cref="HashSet{T}"/> of <see cref="ControllerButton"/>s
        /// </summary>
        public HashSet<ControllerButton> Buttons = [];

        /// <summary>
        /// X value of the left stick
        /// </summary>
        public int LX;
        /// <summary>
        /// Y value of the left stick
        /// </summary>
        public int LY;

        /// <summary>
        /// X value of the right stick
        /// </summary>
        public int RX;
        /// <summary>
        /// Y value of the right stick
        /// </summary>
        public int RY;

        /// <summary>
        /// The value of the left trigger
        /// </summary>
        public int L2;
        /// <summary>
        /// The value of the right trigger
        /// </summary>
        public int R2;
    }
}
