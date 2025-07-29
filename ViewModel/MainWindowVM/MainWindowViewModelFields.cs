using System.Drawing;
using GameTypes.Layers;
using Common;
using Common.Interfaces;
using GameTypes.TileSpriteSetTypes;
using GraphicsEngine;

namespace ViewModel
{
    /// <summary>
    /// The fields for <see cref="MainWindowViewModel"/>
    /// </summary>
    public partial class MainWindowViewModel : NotifyPropertyChanged
    {
        private readonly IDialogProvider dialogProvider;
        private readonly IApplication application;

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

        /// <summary>
        /// The image for map layer
        /// </summary>
        public Bitmap MapLayerImage => MapLayer.Render(MapTileSetType);

        #endregion

        #region charaLayer

        private Chara mainChara;

        /// <summary>
        /// The main character
        /// </summary>
        public Chara MainChara
        {
            get => mainChara;
            set
            {
                mainChara = value;
                PropertyHasChanged();
            }
        }

        private CharaLayer charaLayer;

        /// <summary>
        /// The character layer
        /// </summary>
        public CharaLayer CharaLayer
        {
            get => charaLayer;
            set
            {
                charaLayer = value;
                PropertyHasChanged();
            }
        }

        /// <summary>
        /// The image for the character layer
        /// </summary>
        public Bitmap CharaLayerImage => CharaLayer.Render(MainChara, MapLayerImage.Width, MapLayerImage.Height);

        #endregion
    }
}
