using UnityEngine;
using System.Collections;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class ObjectData : MonoBehaviour {
    private GameObject spawnObject;
    public float timeToSpawn;
    public float spawnTimer;

    void Start()
    {
        spawnObject = gameObject;
    }

    void Reset()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
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
