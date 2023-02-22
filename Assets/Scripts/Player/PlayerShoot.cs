using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot : MonoBehaviour
{
    public Transform muzzle;
    public GameObject bullet;
    void Start()
    {
        
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(bullet, muzzle.position, muzzle.rotation);
    }



    void Update()
    {
        
    }
}
