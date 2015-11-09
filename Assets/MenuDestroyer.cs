using UnityEngine;
using System.Collections;

public class MenuDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        Debug.Log(obj);
        Destroy(obj.gameObject);
    }
}
