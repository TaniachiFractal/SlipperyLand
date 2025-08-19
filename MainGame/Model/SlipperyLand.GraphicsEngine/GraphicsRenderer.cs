using System.Drawing;
using SlipperyLand.GameTypes.Cells.Chara;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.GameTypes.TileSpriteSetTypes;
using SlipperyLand.GraphicalResources.Characters;
using SlipperyLand.GraphicalResources.Map;

namespace SlipperyLand.GraphicsEngine
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

        #region main data

        #region map
        private readonly MapLayer mapLayer;
        private readonly MapTileSet mapTileSet;
        private readonly Bitmap mapBitmap;
        private readonly Graphics mapCanvas;
        #endregion

        #region chara
        private readonly CharaLayer charaLayer;
        private Bitmap charaBitmap;
        private Graphics charaCanvas;
        #endregion

        private readonly Bitmap fullBitmapHigh;
        private readonly Graphics fullCanvasHigh;

        #endregion

        /// <summary>
        /// ctor
        /// </summary>
        public GraphicsRenderer(MapLayer mapLayer, MapTileSetType mapTileSetType, CharaLayer charaLayer)
        {
            this.mapLayer = mapLayer;
            this.charaLayer = charaLayer;
            mapTileSet = MapTileSetDict.Get(mapTileSetType);
            tileSize = mapTileSet.TileSize;

            height = mapLayer.Cols * tileSize;
            width = mapLayer.Rows * tileSize;
            upsHeight = height * Ups;
            upsWidth = width * Ups;

            charaBitmap = GenerateEmptyBitmap(width, height);
            charaCanvas = Graphics.FromImage(charaBitmap);

            mapBitmap = GenerateEmptyBitmap(width, height);
            mapCanvas = Graphics.FromImage(mapBitmap);

            fullBitmapHigh = GenerateEmptyBitmap(upsWidth, upsHeight);
            fullCanvasHigh = Graphics.FromImage(fullBitmapHigh);
            fullCanvasHigh.SetNearInterMode();
        }

        /// <summary>
        /// Get the image of the game field with map and characters
        /// </summary>
        public Bitmap GetGameImage()
        {
            RenderMap();
            RenderCharas();
            mapBitmap.UpscaleTo(fullCanvasHigh, upsWidth, upsHeight);
            charaBitmap.UpscaleTo(fullCanvasHigh, upsWidth, upsHeight);
            return fullBitmapHigh;
        }

        private void ReInitCharas()
        {
            charaBitmap.Dispose();
            charaCanvas.Dispose();
            charaBitmap = GenerateEmptyBitmap(width, height);
            charaCanvas = Graphics.FromImage(charaBitmap);
        }

        private void RenderCharas()
        {
            void Draw(CharaCell chara) => charaCanvas.DrawImage(CharaSpriteSetDict.Get(chara.CharaLook).Get(chara.CharaState), chara.X, chara.Y);
            ReInitCharas();
            Draw(charaLayer.MainChara);
        }

        private bool noImage = true;
        private void RenderMap()
        {
            if (noImage)
            {
                for (var row = 0; row < mapLayer.Rows; row++)
                {
                    for (var col = 0; col < mapLayer.Cols; col++)
                    {
                        var bmp = mapTileSet.Get(mapLayer.ReadCell(row, col));
                        mapCanvas.DrawImage(bmp, col * tileSize, row * tileSize);
                    }
                }
            }
            noImage = false;
        }


        private static Bitmap GenerateEmptyBitmap(int width, int height) => new(width, height);
    }
}
