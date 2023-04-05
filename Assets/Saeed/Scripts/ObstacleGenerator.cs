using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleGenerator : MonoBehaviour
{
    public List<Transform> spawnPositions = new List<Transform>();
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public int numObjectsToSpawn = 10;

    void Start()
    {
        List<Transform> availableSpawnPositions = new List<Transform>(spawnPositions);

        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            int randomIndex = Random.Range(0, availableSpawnPositions.Count);
            Transform spawnPosition = availableSpawnPositions[randomIndex];

            availableSpawnPositions.RemoveAt(randomIndex);

            int randomObjectIndex = Random.Range(0, objectsToSpawn.Count);
            GameObject objectToSpawn = objectsToSpawn[randomObjectIndex];
            Instantiate(objectToSpawn, spawnPosition.position, spawnPosition.rotation);
        }
    }
}