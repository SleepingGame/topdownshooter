using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletDestroyTime = 2f;
    public Transform gunPosition;
    public float bulletSpeed = 10f;
    public float bulletDamage = 20f;

    private PlayerHealth playerHealth;

    public void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 shootDirection = hit.point - gunPosition.position;
            shootDirection.y = 0f;
            shootDirection.Normalize();

            GameObject bullet = Instantiate(bulletPrefab, gunPosition.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;

            Destroy(bullet, bulletDestroyTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(bulletDamage);
            Debug.Log("player health :" + playerHealth.currentHealth);
        }
    }
}