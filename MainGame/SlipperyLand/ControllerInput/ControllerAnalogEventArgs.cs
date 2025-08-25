namespace SlipperyLand.ControllerInput
{
    /// <summary>
    /// Event arguments for analog input from a controller
    /// </summary>
    public class ControllerAnalogEventArgs
    {
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
