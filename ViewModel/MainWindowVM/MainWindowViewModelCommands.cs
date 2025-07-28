using Common;
using Common.Types;
using GameTypes.Cells;

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
        /// Put a character onto a random tile
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
            PropertyHasChanged();
        }

        private void SetRandomCharacterAction()
        {
            var col = RandomSh.Shared.Next(Cols);
            var row = RandomSh.Shared.Next(Rows);
            CharaLayer.SetCell(row, col, new CharaCellGroup(CharaCellType.Hero, (CharaCellStateType)RandomSh.Shared.Next(1, 5)));
            PropertyHasChanged();
        }

        private void CloseAction()
        {
            application.Close();
        }

        #endregion

    }
}
