using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public float spawnInterval = 10f;
    public float powerUpDuration = 5f;

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnPowerUp();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnPowerUp()
    {

        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        GameObject powerUpPrefab = powerUpPrefabs[randomIndex];

        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));

        GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        PowerUp powerUpComponent = powerUp.GetComponent<PowerUp>();
        powerUpComponent.duration = powerUpDuration;
    }
}