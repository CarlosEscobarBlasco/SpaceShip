using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

    public Camera mainCamera;
    public GameObject destroyer;
    //public GameObject spawner;
    public PauseController PauseController;
    public Text backCount;
    public GameObject pointer;

    private List<GameObject> ships;
    private GameObject player;
    private bool changePosition;
    private MenuController menuController;
    private List<string> rivalShips;
    private AudioController audioController;

    private string selectedWorld;
    private int difficulty;

    void Awake()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
        ships = new List<GameObject>();
        createShips();
        selectedWorld = menuController.getSelectedWorld();
        difficulty = menuController.getDifficulty();
    }

	// Use this for initialization
	void Start () {
        setPlayerToCamera();
	    audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
        StartCoroutine(startBackCount());
    }


	// Update is called once per frame
	void Update ()
	{
	    sortArrayShips();
	    updateDestroyer();
	    //updateSpawner();
	}

    private void updateDestroyer()
    {
        if (ships[ships.Count - 1] != destroyer.GetComponent<FollowShip>().getObjectToFollow()) setLastShipToDestroyer(ships[ships.Count - 1]);
    }

    //private void updateSpawner()
    //{
    //    if (ships[0] != spawner.GetComponent<FollowShip>().getObjectToFollow() && spawner) setFirstShipToSpawner(ships[0]);
    //}

    private void setPlayerToCamera()
    {
        mainCamera.GetComponent<FollowShip>().setObjectToFollow(player,3);
    }

    private void setLastShipToDestroyer(GameObject lastShip)
    {
        destroyer.GetComponent<FollowShip>().setObjectToFollow(lastShip, -4);
    }

    //private void setFirstShipToSpawner(GameObject firstShip)
    //{
    //    spawner.GetComponent<FollowShip>().setObjectToFollow(firstShip, 12);
    //}

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
        pointer.SetActive(true);
        foreach (var ship in ships)
        {
            ship.GetComponent<ShipMovement>().enabled = false;
            if (ship.tag != "Player") continue;
            if (SystemInfo.deviceType == DeviceType.Handheld)ship.GetComponent<TouchListener>().enabled = false;
            if (SystemInfo.deviceType == DeviceType.Desktop)ship.GetComponent<KeyListener>().enabled = false;         
        }
        audioController.playCountDownSound();
        backCount.text = "3";
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponentInChildren<Image>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponentInChildren<Image>().enabled = true;
        audioController.playCountDownSound();
        backCount.text = "2";
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponentInChildren<Image>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponentInChildren<Image>().enabled = true;
        audioController.playCountDownSound();
        backCount.text = "1";
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponentInChildren<Image>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        pointer.GetComponentInChildren<Image>().enabled = true;
        audioController.playStartSound();
        yield return new WaitForSeconds(0.5f);
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game Earth": audioController.playWorldMusic(0);
                break;
            case "Game Mars": audioController.playWorldMusic(1);
                break;
            case "Game Saturn": audioController.playWorldMusic(2);
                break;
        }
        backCount.text = "";
        foreach (var ship in ships)
        {
            ship.GetComponent<ShipMovement>().enabled = true;
            if (ship.tag != "Player") continue;
            if (SystemInfo.deviceType == DeviceType.Handheld) ship.GetComponent<TouchListener>().enabled = true;
            if (SystemInfo.deviceType == DeviceType.Desktop) ship.GetComponent<KeyListener>().enabled = true;
        }
        pointer.SetActive(false);
    }

    public int getDifficulty()
    {
        return difficulty;
    }

    public string getSelectedWorld()
    {
        return selectedWorld;
    }

    public void restartGame()
    {
        menuController.startQuickRace(menuController.getSceneName());
    }

    public void goToMainMenu()
    {
        menuController.returnMenu();
    }

    public void goToSelectWorld()
    {
        menuController.returnWorldSelectionMenu();
    }

}
