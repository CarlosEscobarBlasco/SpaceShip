using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {
    public GameObject[] objectsToSpawn;
    private GameObject objectToSpawn;
    public int speed = 0;

    private bool paused;

	// Use this for initialization
	void Start ()
	{
	    paused = false;
        foreach(GameObject objectToSpawn in objectsToSpawn)
        {
            SpawnData data = objectToSpawn.GetComponent<SpawnData>();
            StartCoroutine(spawnController(objectToSpawn, data.getSpawnTimer(), data.getTimeToSpawn()));
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }

    IEnumerator spawnController(GameObject objectToSpawn, float spawnTimer, float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);
        while (!paused)
        {
            Debug.Log(paused);
            yield return new WaitForSeconds(Random.Range(spawnTimer / 3, spawnTimer));
            spawn(objectToSpawn);
        }
        StartCoroutine(spawnController(objectToSpawn, spawnTimer, 0));
    }

    void spawn(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn, randomPosition(objectToSpawn), objectToSpawn.transform.rotation);
    }

    Vector3 randomPosition(GameObject objectToSpawn)
    {
        return new Vector3(Random.Range(-2.4f, 2.4f), gameObject.transform.position.y, objectToSpawn.transform.position.z);
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
