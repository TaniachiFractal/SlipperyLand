using SlipperyLand.Contracts;
using SlipperyLand.GameTypes.Extensions;

namespace SlipperyLand.ViewModel
{
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
            SwitchingLevels?.Invoke(null, null);
            level.CharaLayer.MainChara.SetCharaRowColPos(level.StartRow, level.StartCol, tileSize);
            SwitchedLevels?.Invoke(null, null);
        }

        #endregion

    }
}
