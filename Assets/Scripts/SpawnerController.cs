using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
    public GameObject[] objectsToSpawn;
    private GameObject objectToSpawn;
	// Use this for initialization
	void Start () {
        foreach(GameObject objectToSpawn in objectsToSpawn)
        {
            ObjectData data = objectToSpawn.GetComponent<ObjectData>();
            //InvokeRepeating("spawnObject",data.getTimeToSpawn(), data.getSpawnTimer());
            StartCoroutine(spawnController(objectToSpawn, data.getSpawnTimer(), data.getTimeToSpawn()));
        }
	}
	
	// Update is called once per frame
	void Update () {

	}


    IEnumerator spawnController(GameObject objectToSpawn, float spawnTimer, float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        while (true)
        {
            spawn(objectToSpawn);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void spawn(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn, randomPosition(), objectToSpawn.transform.rotation);
    }

    Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-2.4f, 2.4f), gameObject.transform.position.y, 0);
    }

}
