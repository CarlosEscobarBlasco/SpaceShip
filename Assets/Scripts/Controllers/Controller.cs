using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject destroyer;
    public PauseController PauseController;
    public Text backCount;

    private List<GameObject> ships;
    private GameObject player;
    private bool changePosition;
    private MenuController menuController;
    private List<string> rivalShips;

    void Awake()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
        ships = new List<GameObject>();
        createShips();
    }

	// Use this for initialization
	void Start () {
        setPlayerToCamera();
        StartCoroutine(startBackCount());
    }


	// Update is called once per frame
	void Update ()
	{
	    sortArrayShips();
	    setDestroyerToLastShip();
	}

    private void setDestroyerToLastShip()
    {
        if (ships[ships.Count - 1] != destroyer.GetComponent<FollowShip>().getObjectToFollow()) setLastShipToDestroyer(ships[ships.Count - 1]);
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

    public GameObject getPlayer()
    {
        return player;
    }

    public int getCollisionsOfPlayer()
    {
        return player.GetComponent<ShipStatistics>().getCollisions();
    }

    public string getTimeOfPlayer()
    {
        return trasnformTimeFormt(player.GetComponent<ShipStatistics>().getDuration());
    }

    private string trasnformTimeFormt(float time)
    {
        int min = (int)time/60;
        float sec;
        float.TryParse((time%60).ToString().Split('.')[0], out sec);
        float milSec;
        float.TryParse(time.ToString().Split('.')[1].Substring(0, 2),out milSec);
        return (min>9?min.ToString():"0"+ min) + ":" + (sec>9?sec.ToString():"0"+sec) + ":" + (milSec>9?milSec.ToString():milSec+"0");
    }

    private void createShips(){
        rivalShips = menuController.getRivalShips();
        createPlayerShip(menuController.getSelectedShip(), new Vector3(-2, -3.5f, 0));
        createRivalShip(rivalShips[0], new Vector3(2, -3.5f, 0));
        createRivalShip(rivalShips[1], new Vector3(-0.75f, -3.5f, 0));
        createRivalShip(rivalShips[2], new Vector3(0.75f, -3.5f, 0));
    }

    private void createPlayerShip(string name, Vector3 position)
    {
        GameObject ship = Instantiate(Resources.Load("Prefabs/Ships/" +name), position, transform.rotation) as GameObject;
        if (SystemInfo.deviceType == DeviceType.Handheld) ship.GetComponent<TouchListener>().enabled = true;
        else ship.GetComponent<KeyListener>().enabled = true;
        ship.GetComponent<ShipStatistics>().startStatistics();
        player = ship;
        ship.tag = "Player";
        ships.Add(ship);
    }

    private void createRivalShip(string name, Vector3 position)
    {
        GameObject ship = Instantiate(Resources.Load("Prefabs/Ships/" + name), position, transform.rotation) as GameObject;
        ship.GetComponent<AIPlus>().enabled = true;
        ship.GetComponent<ArtificialIntelligence>().enabled = true;
        ship.GetComponent<ArtificialIntelligence>().setDifficulty(menuController.getDifficulty());
        ship.GetComponent<ShipStatistics>().startStatistics();      
        ship.tag = "CPU";
        ships.Add(ship);
    }

    private IEnumerator startBackCount()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i].tag == "Player" && SystemInfo.deviceType == DeviceType.Handheld) ships[i].GetComponent<TouchListener>().enabled = false;
            if (ships[i].tag == "Player" && SystemInfo.deviceType == DeviceType.Console) ships[i].GetComponent<ShipMovement>().enabled = false;
            ships[i].GetComponent<ShipMovement>().enabled = false;
        }
        backCount.text = "3";
        yield return new WaitForSeconds(1);
        backCount.text = "2";
        yield return new WaitForSeconds(1);
        backCount.text = "1";
        yield return new WaitForSeconds(1);
        backCount.text = "";
        for (int i = 0; i < ships.Count; i++)
        {
            if (ships[i].tag == "Player" && SystemInfo.deviceType == DeviceType.Handheld) ships[i].GetComponent<TouchListener>().enabled = true;
            if (ships[i].tag == "Player" && SystemInfo.deviceType == DeviceType.Console) ships[i].GetComponent<ShipMovement>().enabled = true;
            ships[i].GetComponent<ShipMovement>().enabled = true;
        }
    }

}
