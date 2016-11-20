using UnityEngine;
using System.Collections;

public class MenuStarReorganiniser : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    gameObject.transform.position = new Vector3(Screen.width+10,Screen.height/2,70);
        gameObject.transform.localScale = new Vector3(1,Screen.height,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        collider.transform.position = randomPosition();
    }

    Vector3 randomPosition()
    {
        return new Vector3(-10, Random.Range(0, Screen.height), 70);
    }
}
