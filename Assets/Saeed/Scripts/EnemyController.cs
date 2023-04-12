using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IAi
{
    public GameObject bulletPrefab;
    public float fireDelay = 0.5f;
    public float bulletSpeed = 10f;
    public float shootingRange = 10f;

    private NavMeshAgent agent;
    public GameObject target;
    private float lastFireTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        agent.SetDestination(target.transform.position);

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < shootingRange && Time.time > lastFireTime + fireDelay)
        {
       
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;
        lastFireTime = Time.time;
    }

    public void Spawn()
    {

    }
}
