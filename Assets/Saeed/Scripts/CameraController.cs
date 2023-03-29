using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float distance = 10f; 
    public float orbitSpeed = 1f; 
    public float lookSpeed = 1f; 

    void Update()
    {
        transform.LookAt(target);
        transform.RotateAround(target.position, Vector3.up, orbitSpeed * Time.deltaTime);
        transform.position = target.position - transform.forward * distance;
    }
}
