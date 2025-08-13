using System;
using System.Diagnostics;

namespace SlipperyLand.Common
{
    /// <summary>
    /// Breakpoint state
    /// </summary>
    public static class BP
    {
        /// <summary>
        /// Invoked upon setting the breakpoint state
        /// </summary>
        public static event EventHandler<EventArgs> BreakpointSet;

        /// <summary>
        /// Invoked upon releasing the breakpoint state
        /// </summary>
        public static event EventHandler<EventArgs> Released;

        /// <summary>
        /// Set the breakpoint state
        /// </summary>
        public static void Break()
        {
            BreakpointSet?.Invoke(null, null);
            Debugger.Break();
        }

        /// <summary>
        /// Release the breakpoint state
        /// </summary>
        public static void Release() => Released?.Invoke(null, null);
    }
}
