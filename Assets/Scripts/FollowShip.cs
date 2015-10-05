using UnityEngine;
using System.Collections;

public class FollowShip : MonoBehaviour {
    private GameObject objectToFollow;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, objectToFollow.transform.position.y + 4 , transform.position.z);
	}

    public void setObjectToFollow(GameObject objectToFollow)
    {
        this.objectToFollow = objectToFollow;
    }
}
