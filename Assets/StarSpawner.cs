using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour
{

    public GameObject[] stars;

    private float lastSpawnPosition;
    private float minSpawnDistance;
    private float maxSpawnDistance;
    private float currentSpawnDistance;

	// Use this for initialization
	void Start ()
	{
	    lastSpawnPosition = gameObject.transform.position.y;
	    maxSpawnDistance = 0.3f;
	    minSpawnDistance = 0.001f;
	    currentSpawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
	}
	
	// Update is called once per frame
	void Update () {
	    if (lastSpawnPosition+currentSpawnDistance<=gameObject.transform.position.y)
	    {
	        spawnStar();
            lastSpawnPosition = gameObject.transform.position.y;
            currentSpawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        }
	    
	}

    private void spawnStar()
    {
        GameObject objectToSpawn = starSelector();
        Instantiate(objectToSpawn, randomPosition(objectToSpawn), objectToSpawn.transform.rotation);
    }

    private GameObject starSelector()
    {
        return stars[Random.Range(0,stars.Length)];
    }

    Vector3 randomPosition(GameObject objectToSpawn)
    {
        
        return new Vector3(Random.Range(-4.0f, 4.0f), gameObject.transform.position.y, objectToSpawn.transform.position.z);
    }
}
