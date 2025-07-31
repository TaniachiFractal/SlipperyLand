using Common;
using Common.Types;
using GameTypes;
using GameTypes.Cells;
using GameTypes.Extensions;

namespace ViewModel
{
    /// <summary>
    /// The commands for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel
    {
        #region commands

        #region movement

        /// <summary>
        /// Move hero up
        /// </summary>
        public NoParamCommand MoveUpCommand { get; private set; }

        /// <summary>
        /// Move hero down
        /// </summary>
        public NoParamCommand MoveDownCommand { get; private set; }

        /// <summary>
        /// Move hero left
        /// </summary>
        public NoParamCommand MoveLeftCommand { get; private set; }

        /// <summary>
        /// Move hero right
        /// </summary>
        public NoParamCommand MoveRightCommand { get; private set; }

        #endregion

        #region misc

        /// <summary>
        /// Change a random map cell
        /// </summary>
        public NoParamCommand ChangeRandomCellCommand { get; private set; }

        /// <summary>
        /// Close the app
        /// </summary>
        public NoParamCommand CloseCommand { get; private set; }

        #endregion

        #endregion

        #region methods for commands

        private void ChangeDir(Direction dir) => MainCharaDir = dir;

        #region misc

        private void ChangeRandomCell()
        {
            var col = RandomSh.Shared.Next(Cols);
            var row = RandomSh.Shared.Next(Rows);
            MapLayer.SetCell(row, col, (MapCellType)RandomSh.Shared.Next(1, 6));
        }

        private void Close()
        {
            application.Close();
        }

        #endregion

        #endregion

    }
}
