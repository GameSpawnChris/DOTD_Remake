using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //use serialization commands

public class MapManager 
{
    public static Tile[,] map; //2d map ith the info for all the tiles
}

[Serializable] //makes the class serializble so it can be saved to a a file
public class Tile //holds information for each tile on the map
{
    public int xPosition; //position on the x axis
    public int yPosition; //position on the y axis
    [NonSerialized]
    public GameObject baseObject; //map game object attached to the position: floor, wall, etc.

}
