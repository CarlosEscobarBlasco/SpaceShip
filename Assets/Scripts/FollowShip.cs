using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {

    private GameObject objectToFollow;
    private int distance;

	// Use this for initialization
	void Start () {
        objectToFollow = gameObject;
        distance = 3;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y + distance , transform.position.z);
	}

    public void setObjectToFollow(GameObject objectToFollow)
    {
        this.objectToFollow = objectToFollow;
    }

    public void setObjectToFollow(GameObject objectToFollow, int distance)
    {
        this.objectToFollow = objectToFollow;
        this.distance = distance;
    }

    public GameObject getObjectToFollow()
    {
        return objectToFollow;
    }
}
