using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSpawner : MonoBehaviour
{

    public GameObject starPrefab;
    public GameObject stars;
    private GameObject starSpawned;
    // Use this for initialization
    void Start()
    {
         StartCoroutine(spawnController(starPrefab, 0.2f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    IEnumerator spawnController(GameObject objectToSpawn, float spawnTimer)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnTimer / 3, spawnTimer));
            spawn(objectToSpawn);
        }
    }

    void spawn(GameObject objectToSpawn)
    {
       starSpawned = Instantiate(objectToSpawn, randomPosition(objectToSpawn), objectToSpawn.transform.rotation) as GameObject;
       starSpawned.transform.SetParent(stars.transform);
    }

    Vector3 randomPosition(GameObject objectToSpawn)
    {
        return new Vector3(objectToSpawn.transform.position.x, Random.Range(600f, 0f), objectToSpawn.transform.position.z);
    }


}
