using System.Drawing;
using GameTypes.Extensions;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;
using GraphicalResources.Map;

namespace GraphicsEngine
{
    /// <summary>
    /// Game graphics renderer
    /// </summary>
    public class GraphicsRenderer
    {
        private const int Ups = 2;

        private readonly int tileSize = 0;

        private readonly int height = 0;
        private readonly int width = 0;
        private readonly int upsHeight = 0;
        private readonly int upsWidth = 0;

        #region map
        private readonly MapLayer mapLayer;
        private readonly MapTileSet mapTileSet;
        private readonly Bitmap mapBitmap;
        private readonly Graphics mapCanvas;
        private readonly Bitmap mapBitmapHigh;
        private readonly Graphics mapCanvasHigh;
        #endregion

        #region chara
        private readonly CharaLayer charaLayer;
        private readonly Bitmap charaBitmap;
        private readonly Graphics charaCanvas;
        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public GraphicsRenderer(MapLayer mapLayer, MapTileSetType mapTileSetType, CharaLayer charaLayer)
        {
            this.mapLayer = mapLayer;
            mapTileSet = MapTileSetDict.Get(mapTileSetType);
            this.charaLayer = charaLayer;

            tileSize = mapTileSet.GetDefault().Width;

            height = mapLayer.Cols * tileSize;
            width = mapLayer.Rows * tileSize;
            upsHeight = height * Ups;
            upsWidth = width * Ups;

            charaBitmap = GenerateEmptyBitmap(width, height);
            charaCanvas = Graphics.FromImage(charaBitmap);

            mapBitmap = GenerateEmptyBitmap(width, height);
            mapCanvas = Graphics.FromImage(mapBitmap);

            mapBitmapHigh = GenerateEmptyBitmap(upsWidth, upsHeight);
            mapCanvasHigh = Graphics.FromImage(mapBitmapHigh);
            mapCanvasHigh.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        }

        /// <summary>
        /// Get the map image
        /// </summary>
        public Bitmap GetMapImage()
        {
            RenderMap();
            UpscaleMap();
            return mapBitmapHigh;
        }

        private void RenderMap()
        {
            for (var row = 0; row < mapLayer.Rows; row++)
            {
                for (var col = 0; col < mapLayer.Cols; col++)
                {
                    mapCanvas.DrawImage(mapTileSet.Get(mapLayer.ReadCell(row, col)), col * tileSize, row * tileSize);
                }
            }
        }

        private void UpscaleMap()
        {
            mapCanvasHigh.DrawImage(mapBitmap, 0, 0, upsWidth, upsHeight);
        }

        private Bitmap GenerateEmptyBitmap(int width, int height) => new Bitmap(width, height);
    }
}
