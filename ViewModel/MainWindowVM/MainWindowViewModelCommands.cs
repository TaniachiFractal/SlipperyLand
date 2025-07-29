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

        /// <summary>
        /// Change a random map cell
        /// </summary>
        public NoParamAction ChangeRandomCellCommand { get; private set; }

        /// <summary>
        /// Put a charaLook onto a random tile
        /// </summary>
        public NoParamAction SetRandomCharacterCommand { get; private set; }

        /// <summary>
        /// Close the app
        /// </summary>
        public NoParamAction CloseCommand { get; private set; }

        #endregion

        #region methods for commands

        private void ChangeRandomCellAction()
        {
            var col = RandomSh.Shared.Next(Cols);
            var row = RandomSh.Shared.Next(Rows);
            MapLayer.SetCell(row, col, (MapCellType)RandomSh.Shared.Next(1, 6));
        }

        private void SetRandomCharacterAction()
        {
            PropertyHasChanged();
        }

        private void CloseAction()
        {
            application.Close();
        }

        #endregion

    }
}
