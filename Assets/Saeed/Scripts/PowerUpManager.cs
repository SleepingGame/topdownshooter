using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpPrefabs;
    public GameObject[] spawnPoints;
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

    // check next spawn time 

    void SpawnPowerUp()
    {
        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        GameObject powerUpPrefab = powerUpPrefabs[randomIndex];

        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomSpawnIndex].transform.position;

        GameObject powerUp = Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        PowerUp powerUpComponent = powerUp.GetComponent<PowerUp>();
        powerUpComponent.duration = powerUpDuration;
    }
}