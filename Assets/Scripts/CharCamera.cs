using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCamera : MonoBehaviour
{

    public GameObject Player;

    // public float offsetX = 0f;
    // public float offsetY = 0f;
    public float offsetZ = -0.5f;

    Vector3 cameraPosition;

    void Update()
    {
        cameraPosition.x = Player.transform.position.x;
        cameraPosition.y = Player.transform.position.y;
        cameraPosition.z = Player.transform.position.z + offsetZ;

        transform.position = cameraPosition;
    }
}