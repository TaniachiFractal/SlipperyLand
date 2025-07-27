using Common;
using Common.Types;

namespace ViewModel
{
    /// <summary>
    /// The commands for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel
    {
        #region commands

        /// <summary>
        /// Change a random map cell
        /// </summary>
        public NoParamAction ChangeRandomCellCommand { get; private set; }

        #endregion

        #region methods for commands

        private void ChangeRandomCellAction()
        {
            var col = RandomSh.Shared.Next(Cols);
            var row = RandomSh.Shared.Next(Rows);
            MapLayer.SetCell(row, col, GameTypes.Cells.MapCells.Wall);
            PropertyHasChanged();
        }

        #endregion

    }
}
