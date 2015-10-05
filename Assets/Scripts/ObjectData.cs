using UnityEngine;
using System.Collections;

public class ObjectData : MonoBehaviour{
    private GameObject spawnObject;
    public float timeToSpawn;
    public float spawnTimer;

    void Start()
    {
        spawnObject = gameObject;
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
}
