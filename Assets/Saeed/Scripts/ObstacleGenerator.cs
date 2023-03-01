using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectList;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private int maxObjects = 5;
    [SerializeField] private float spawnRadius = 1f;

    private void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        int objectsToSpawn = Mathf.Min(maxObjects, objectList.Count, spawnPoints.Count);

        for (int i = 0; i < objectsToSpawn; i++)
        {
            GameObject objectPrefab = objectList[Random.Range(0, objectList.Count)];
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
            Vector3 spawnPos = GetRandomSpawnPosition(spawnPoint.position);

            GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition(Vector3 center)
    {
        Vector3 spawnPos = Vector3.zero;
        bool emptyPlace = false;
        int maxAttempts = 4; // Maximum number of attempts to find an empty spawn position
        int attemptCount = 0;

        while (!emptyPlace && attemptCount < maxAttempts)
        {
            // Generate a random position within a sphere with a radius of spawnRadius around the center
            spawnPos = center + Random.insideUnitSphere * spawnRadius;

            // Check if there are any colliders within a sphere around the spawn position with a radius of spawnRadius
            Collider[] colliders = Physics.OverlapSphere(spawnPos, spawnRadius);
            emptyPlace = colliders.Length == 0;

            // Increment the attempt count
            attemptCount++;
        }

        // Return the spawn position
        return spawnPos;
    }
}