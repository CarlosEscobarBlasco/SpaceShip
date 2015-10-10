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
        sortArrayShips();
        if (ships[ships.Count - 1] != destroyer.GetComponent<FollowShip>().getObjectToFollow()) setLastShipToDestroyer(ships[ships.Count-1]);
	}

    private void setPlayerToCamera()
    {
        mainCamera.GetComponent<FollowShip>().setObjectToFollow(player,3);
    }

    private void setLastShipToDestroyer(GameObject lastShip)
    {
        destroyer.GetComponent<FollowShip>().setObjectToFollow(lastShip, -4);
    }

    private void sortArrayShips()
    {
        GameObject auxShip;

        for (int i = 0; i < ships.Count; i++)
        {
            for (int j = 0; j < ships.Count - 1; j++)
            {
                if (GetShipY(j) < GetShipY(j+1))
                {
                    auxShip = ships[j];
                    ships[j] = ships[j + 1];
                    ships[j + 1] = auxShip;
                }
            }
        }
    }

    private float GetShipY(int j)
    {
        return ships[j].gameObject.transform.position.y;
    }
}
