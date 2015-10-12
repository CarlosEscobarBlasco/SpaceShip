using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CollisionData : MonoBehaviour {

    public float slowAmount;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Reset()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    public float getSlowAmountPercentage()
    {
        return slowAmount;
    }
}
