using UnityEngine;
using System.Collections;

public class SpawnData : MonoBehaviour {

    public float timeToSpawn;
    public float spawnTimer;
   
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

}
