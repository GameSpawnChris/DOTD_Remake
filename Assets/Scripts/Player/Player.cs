using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    bool isMoving;


    // Update is called once per frame
    void Update()
    {
        float h = System.Math.Sign(Input.GetAxisRaw("Horizontal")); // system.Math.sign Rounds movment
        float v = System.Math.Sign(Input.GetAxisRaw("Vertical"));

        if(!isMoving)
        {
            if(Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0)
            {
                if (Mathf.Abs(h) > 0)
                {
                    targetPos = new Vector3(transform.position.x + h, transform.position.y, transform.position.z);
                }
                else if (Mathf.Abs(v) > 0)
                {
                    targetPos = new Vector3(transform.position.x, transform.position.y + v, transform.position.z);
                }

                Vector3 targetTilePos = new Vector3(targetPos.x - 0.5f, targetPos.y - 0.5f, targetPos.z);

                var tiles = TileManager.instance.tiles;
                GameTile tile;

                if(tiles.TryGetValue(targetTilePos, out tile))
                {
                    if (tile.TileBase.name != "Wall_test")
                    {
                        StartCoroutine(Move());
                    }
                }
            }
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        while(Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
