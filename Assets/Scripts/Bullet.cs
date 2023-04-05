using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public int speed, damage;
    PlayerHealth pHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pHealth = other.gameObject.GetComponent<PlayerHealth>();
          //  pHealth.Damage(damage);
        }
        Destroy(this.gameObject);
    }
}
