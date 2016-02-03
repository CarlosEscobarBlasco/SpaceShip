using UnityEngine;
using System.Collections;

public class MeteorDestroyer : MonoBehaviour
{

    public GameObject animation;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void destroyMeteor()
    {
        Instantiate(animation, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
