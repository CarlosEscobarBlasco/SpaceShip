using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject destroyer;
    public GameObject spawner;

    private GameObject[] ships;
    private GameObject player;
    private GameObject first;
    private GameObject last;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        ships = GameObject.FindGameObjectsWithTag("CPU");
        setPlayerToCamera();
    }
	
	// Update is called once per frame
	void Update () {
        first = trackFirstShip();
        last = trackLastShip();
        if (first != spawner.GetComponent<FollowShip>().getObjectToFollow()) setFirstShipToSpawner(first);
        if (last != destroyer.GetComponent<FollowShip>().getObjectToFollow()) setLastShipToDestroyer(last);
	}

    private void setPlayerToCamera()
    {
        mainCamera.GetComponent<FollowShip>().setObjectToFollow(player,3);
    }

    private void setLastShipToDestroyer(GameObject lastShip)
    {
        destroyer.GetComponent<FollowShip>().setObjectToFollow(lastShip, -3);
    }

    private void setFirstShipToSpawner(GameObject firstShip)
    {
        spawner.GetComponent<FollowShip>().setObjectToFollow(firstShip, 3);
    }

    private GameObject trackFirstShip()
    {
        int firstShipPos = 0;
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i].transform.position.y > ships[firstShipPos].transform.position.y) firstShipPos = i;
        }
        return ships[firstShipPos];
    }

    private GameObject trackLastShip()
    {
        int lastShipPos = 0;
        for (int i = 0; i < ships.Length; i++)
        {
            if (ships[i].transform.position.y < ships[lastShipPos].transform.position.y) lastShipPos = i;
        }
        return ships[lastShipPos];
    }
}
