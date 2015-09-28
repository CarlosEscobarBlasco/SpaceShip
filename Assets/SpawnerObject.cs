using UnityEngine;
using System.Collections;

public class SpawnerObject  {

    private GameObject objectToSpawn;
    private float timeToSpawn;
    private float spawnTimer;

    public SpawnerObject(GameObject objectToSpawn, float timeToSpawn,float spawnTimer)
    {
        this.objectToSpawn = objectToSpawn;
        this.timeToSpawn = timeToSpawn;
        this.spawnTimer = spawnTimer;
    }

    public GameObject getObjectToSpawn()
    {
        return objectToSpawn;
    }

    public float getTimeToSpawn()
    {
        return timeToSpawn;
    }

    public float getSpawnTimer()
    {
        return spawnTimer;
    }
}
