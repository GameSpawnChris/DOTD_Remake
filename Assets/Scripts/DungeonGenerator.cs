using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;

    public int widthMinRoom;
    public int widthMaxRoom;
    public int heightMinRoom;
    public int heightMaxRoom;

    public int maxCOrridorLength;
    public int maxFeatures;

    public void InitializeDungeon()
    {
        MapManager.map = new Tile[mapWidth, mapHeight];
    }
}
