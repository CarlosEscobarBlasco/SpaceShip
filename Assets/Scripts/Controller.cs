using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject destroyer;
    public GameObject spawner;

    private List<GameObject> ships;
    private GameObject player;
    private GameObject first;
    private GameObject last;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        try
        {
            ships = new List<GameObject>(GameObject.FindGameObjectsWithTag("CPU"));
        }
        catch (Exception e)
        {
            ships = new List<GameObject>();
        }
        ships.Add(player);
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
        spawner.GetComponent<FollowShip>().setObjectToFollow(firstShip, 8);
    }

    private GameObject trackFirstShip()
    {
        int firstShipPos = 0;
        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i].transform.position.y > ships[firstShipPos].transform.position.y) firstShipPos = i;
        }
        return ships[firstShipPos];
    }

    private GameObject trackLastShip()
    {
        int lastShipPos = 0;
        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i].transform.position.y < ships[lastShipPos].transform.position.y) lastShipPos = i;
        }
        return ships[lastShipPos];
    }
}
