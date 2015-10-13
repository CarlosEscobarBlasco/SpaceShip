﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject destroyer;
    public GameObject spawner;
    public Slider slider;
    public Text remainingDistance;
    public GameObject finish;

    private List<GameObject> ships;
    private GameObject player;

    private bool changePosition;

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
        setObjects();
    }

    private void setObjects()
    {
        setPlayerToCamera();
        setPlayerToSlider();
        setFinishToRemainingDistance();
        setPlayertToRemainingDistance();
    }
	
	// Update is called once per frame
	void Update () {
        if (sortArrayShips()) setShipsToUIList();
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

    private void setPlayerToSlider()
    {
        slider.GetComponent<SliderController>().setPlayer(player);
    }

    private void setFinishToRemainingDistance()
    {
        remainingDistance.GetComponent<RemainingDistanceController>().setDistance(finish.transform.position.y);
    }

    private void setPlayertToRemainingDistance()
    {
        remainingDistance.GetComponent<RemainingDistanceController>().setPlayer(player);
    }

    private void setShipsToUIList()
    {
        
    }
}
