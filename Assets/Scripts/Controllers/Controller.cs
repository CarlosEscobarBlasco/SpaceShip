using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject destroyer;
    private List<GameObject> ships;
    private GameObject player;
    private bool changePosition;
    private MenuController menuController;

    void Awake()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
        createShips();
        player = GameObject.FindGameObjectWithTag("Player");
        try
        {
            ships = new List<GameObject>(GameObject.FindGameObjectsWithTag("CPU"));
        }
        catch (Exception)
        {
            ships = new List<GameObject>();
        }
        ships.Add(player);
        
    }

	// Use this for initialization
	void Start () {
        setObjects();
    }

    private void setObjects()
    {
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

    private bool sortArrayShips()
    {
        changePosition = false;
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
                    changePosition = true;
                }
            }
        }
        return changePosition;
    }

    private float GetShipY(int j)
    {
        return ships[j].gameObject.transform.position.y;
    }

    public List<GameObject> getShipsToUIList()
    {
        return ships;
    }

    public int positionOf(GameObject ship)
    {
        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i] == ship) return i+1;
        }
        return -1;
    }

    private void createShips(){ //Hacer solo un prefab? y activar/desactivar CPU/Player y el tag?
        Instantiate(Resources.Load("Prefabs/Ships/" + menuController.getSelectedShip()), new Vector3(-2,-3.5f,0), transform.rotation);
        //Instantiate(Resources.Load("Prefabs/Ships/" + menuController.getSelectedShip()), Vector3.zero, transform.rotation);
        //Instantiate(Resources.Load("Prefabs/Ships/" + menuController.getSelectedShip()), Vector3.zero, transform.rotation);
        //Instantiate(Resources.Load("Prefabs/Ships/" + menuController.getSelectedShip()), Vector3.zero, transform.rotation);
    }
}
