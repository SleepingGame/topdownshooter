using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerOne, playerTwo, lookAt;
    public float offsetX, offsetY, offsetZ;

    void Start()
    {
        
    }


    void Update()
    {
        lookAt.transform.position = (playerOne.position + playerTwo.position) / 2;
        transform.LookAt(lookAt);
        this.transform.position = new Vector3(lookAt.position.x + offsetX, lookAt.position.y + offsetY, lookAt.position.z + offsetZ);
    }
}
