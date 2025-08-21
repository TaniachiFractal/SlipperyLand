using SlipperyLand.Contracts;
using SlipperyLand.GameTypes.Extensions;

namespace SlipperyLand.ViewModel
{
#nullable enable
    /// <summary>
    /// The commands for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel
    {
        #region commands

        /// <summary>
        /// Restart the level from the start cell
        /// </summary>
        public NoParamCommand ResetLevelCommand { get; private set; }

        #endregion

        #region methods for commands

        private void ResetLevel()
        {
            SwithingLevels?.Invoke(null, null);
            level.CharaLayer.MainChara.SetCharaRowColPos(level.StartRow, level.StartCol, tileSize);
            SwitchedLevels?.Invoke(null, null);
        }

        #endregion

    }
}
