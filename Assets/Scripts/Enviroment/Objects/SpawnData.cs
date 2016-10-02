using UnityEngine;
using System.Collections;

public class SpawnData : MonoBehaviour {

    public float timeToSpawn;
    public float spawnTimer;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    void Start()
    {
    }

    void Update()
    {
    }

    public float getTimeToSpawn()
    {
        return timeToSpawn;
    }

    public float getSpawnTimer()
    {
        return spawnTimer;
    }

    public float getMinSpawnDistance()
    {
        return minSpawnDistance;
    }
    public float getMaxSpawnDistance()
    {
        return maxSpawnDistance;
    }

}
