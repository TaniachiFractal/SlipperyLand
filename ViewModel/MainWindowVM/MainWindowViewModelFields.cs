using System.Drawing;
using CellTypes.Layers;
using Common;
using Common.Interfaces;
using GameTypes.TileSetTypes;

namespace ViewModel
{
    /// <summary>
    /// The fields for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly IDialogProvider dialogProvider;

        #region cols rows

        private int cols, rows;

        /// <summary>
        /// Col count of the field
        /// </summary>
        public int Cols
        {
            get => cols;
            set => cols = value;
        }

        /// <summary>
        /// Row count of the field
        /// </summary>
        public int Rows
        {
            get => rows;
            set => rows = value;
        }

        #endregion

        #region mapLayer

        private MapTileSetType mapTileSetType;

        /// <summary>
        /// The tile set type
        /// </summary>
        public MapTileSetType MapTileSetType
        {
            get => mapTileSetType;
            set
            {
                mapTileSetType = value;
                PropertyHasChanged();
            }
        }

        private MapLayer mapLayer;

        /// <summary>
        /// The map layer
        /// </summary>
        public MapLayer MapLayer
        {
            get => mapLayer;
            set
            {
                mapLayer = value;
                PropertyHasChanged();
            }
        }

        public Bitmap MapLayerImage => GraphicsEngine.MapRenderer.Render(MapLayer)

        #endregion
    }
}
