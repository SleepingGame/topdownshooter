using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Debug.Log(this.gameObject.name + " is dead!");
        }
    }
}
