using System.Collections.Generic;
using GameTypes.TileSpriteSetTypes;

namespace GraphicalResources.Map
{
    /// <summary>
    /// Holds a Dictionary of <see cref="MapTileSet"/>s
    /// </summary>
    public static class MapTileSetDict
    {
        private readonly static Dictionary<MapTileSetType, MapTileSet> dict = new()
        {
            {MapTileSetType.Ice, new MapTileSet()
                {
                    slippery = {MapTiles.Ice},
                    rough = {MapTiles.IceGround},
                    wall = {MapTiles.IceWall, MapTiles.IceWallFront},
                    start = {MapTiles.IceStart},
                    end = {MapTiles.IceEnd},
                }
            }
        };

        /// <param name="type">The tile set ID</param>
        /// <returns>Desired map tile set</returns>
        public static MapTileSet Get(MapTileSetType type) => dict[type];
    }
}
