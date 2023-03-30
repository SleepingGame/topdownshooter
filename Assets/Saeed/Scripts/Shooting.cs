using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPosition;
    public float bulletSpeed = 10f;
    public float destroybullet = 2f;

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

           
            StartCoroutine(DestroyBulletAfterDelay(bullet, destroybullet));
        }
    }

    IEnumerator DestroyBulletAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(destroybullet);
        if (bullet != null)
        {
            Destroy(bullet);
        }
    }
}