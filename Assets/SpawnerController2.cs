using UnityEngine;
using System.Collections;

public class SpawnerController2 : MonoBehaviour
{

    public GameObject[] objectsToSpawn;

    private float lastSpawnPosition;
    private float minSpawnDistance;
    private float maxSpawnDistance;
    private float currentSpawnDistance;
    private bool paused;

    // Use this for initialization
    void Start()
    {
        lastSpawnPosition = gameObject.transform.position.y;
        maxSpawnDistance = 3f;
        minSpawnDistance = 0f;
        currentSpawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (lastSpawnPosition + currentSpawnDistance <= gameObject.transform.position.y)
        {
            spawn();
            lastSpawnPosition = gameObject.transform.position.y;
            currentSpawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        }

    }

    private void spawn()
    {
        GameObject objectToSpawn = objectSelector();
        Instantiate(objectToSpawn, randomPosition(objectToSpawn), objectToSpawn.transform.rotation);
    }

    private GameObject objectSelector()
    {
        float r = Random.Range(0, 100);
        if (r <= 15)
        {
            return objectsToSpawn[0];
        }
        else if (15 < r && r <= 50)
        {
            return objectsToSpawn[1];
        }
        else
        {
            return objectsToSpawn[2];
        }
    }

    Vector3 randomPosition(GameObject objectToSpawn)
    {
        return new Vector3(Random.Range(-3.0f, 3.0f), gameObject.transform.position.y, objectToSpawn.transform.position.z);
    }

    void OnPauseGame()
    {
        paused = true;
    }

    void OnResumeGame()
    {
        paused = false;
    }
}
