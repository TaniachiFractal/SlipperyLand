using Common;
using Common.Types;
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
