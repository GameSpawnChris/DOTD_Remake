using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;

    public Tilemap blockers;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {

                StartCoroutine(MovePlayer(Vector3.up));
            
        }

        if (Input.GetKey(KeyCode.A) && !isMoving)
        {

                StartCoroutine(MovePlayer(Vector3.left));
            
        }

        if (Input.GetKey(KeyCode.S) && !isMoving)
        {

                StartCoroutine(MovePlayer(Vector3.down));
            
        }


        if (Input.GetKey(KeyCode.D) && !isMoving)
        {

                StartCoroutine(MovePlayer(Vector3.right));
            
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        Vector3Int blockerMapTile = blockers.WorldToCell(targetPos - new Vector3(0, 0.5f, 0));
        if (blockers.GetTile(blockerMapTile) == null)
        { 
            while (elapsedTime < timeToMove)
            {
                transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
        
            transform.position = targetPos;
        }


        isMoving = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPos - new Vector3(0, 0.5f, 0), 0.2f);
    }
}
