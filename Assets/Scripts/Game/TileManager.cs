using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public Tilemap tilemap;
    public Dictionary<Vector3, GameTile> tiles;

    void Awake()
    {
        instance = this;
        GetGameTiles();
    }

    private void GetGameTiles()
    {
        tiles = new Dictionary<Vector3, GameTile>();

        foreach(Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            var localPosition = new Vector3Int(pos.x, pos.y, pos.z);

            if(!tilemap.HasTile(localPosition)) continue;
            var tile = new GameTile
            {
                LocalPosition = localPosition,
                WorldPosition = tilemap.CellToWorld(localPosition),

                TileBase = tilemap.GetTile(localPosition),
                TilemapMember = tilemap,

                TileName = localPosition.x + "," + localPosition.y,

            };

            tiles.Add(tile.WorldPosition, tile);
        }
    }
}
