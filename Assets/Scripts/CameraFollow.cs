using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;

    void FixedUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
    }
}
