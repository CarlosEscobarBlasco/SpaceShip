using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class FinishController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Reset()
    {
        gameObject.GetComponent<Collider2D>().transform.localScale = new Vector3(10, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "CPU" || collider.tag == "Player") Debug.Log("Llego");
    }
}
