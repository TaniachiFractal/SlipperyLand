using System.Collections.Generic;
using GameTypes.TileSpriteSetTypes;

namespace GraphicalResources.Map
{
    /// <summary>
    /// Holds a Dictionary of <see cref="MapTileSetType"/> to <see cref="MapTileSet"/>
    /// </summary>
    public static class MapTileSetDict
    {
        private readonly static Dictionary<MapTileSetType, MapTileSet> dict = new()
        {
            {MapTileSetType.Ice, new MapTileSet(MapTiles.Ice, MapTiles.IceGround, MapTiles.IceWall,
                MapTiles.IceStart, MapTiles.IceEnd) }
        };

        /// <param name="type">The tile set ID</param>
        /// <returns>Desired map tile set</returns>
        public static MapTileSet Get(MapTileSetType type) => dict[type];
    }
}
