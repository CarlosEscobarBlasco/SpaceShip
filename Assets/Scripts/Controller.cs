using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
        setPlayerToCamera();
        setLastPlayerToDestroyer();
        setFirstPlayerToSpawner();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void setPlayerToCamera()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowShip>().setObjectToFollow(GameObject.FindGameObjectWithTag("Player"));
    }

    private void setLastPlayerToDestroyer()
    {

    }

    private void setFirstPlayerToSpawner()
    {

    }
}
