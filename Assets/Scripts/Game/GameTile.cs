using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTile
{
  public Vector3Int LocalPosition { get; set; }
  public Vector3 WorldPosition { get; set; }
  
  public TileBase TileBase { get; set; }
  public Tilemap TilemapMember { get; set; }

  public string TileName { get; set; }
}

