using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class MenuController : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject worldsPanel;
    public GameObject shipsPanel;
    public GameObject gameSelector;

    private string selectedShip;
    private List<string> rivalShips = new List<string>();
    private string selectedWorld;
    private int difficulty;

	// Use this for initialization
	void Start () {
        mainPanel.SetActive(true);
        shipsPanel.SetActive(false);
        worldsPanel.SetActive(false);
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape)){
            if (shipsPanel.activeSelf) goToGameSelector();
            else if (worldsPanel.activeSelf) goToShipSelectionMenu();
            else if(gameSelector.activeSelf) goToMainMenu();
            else if(mainPanel.activeSelf) Application.Quit();
        }
	}

    public void goToWorldSelectionMenu()
    {
        shipsPanel.SetActive(false);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(true);
        gameSelector.SetActive(false);
    }

    public void goToShipSelectionMenu()
    {
        shipsPanel.SetActive(true);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(false);
        gameSelector.SetActive(false);
    }

    public void goToMainMenu()
    {
        shipsPanel.SetActive(false);
        mainPanel.SetActive(true);
        worldsPanel.SetActive(false);
        gameSelector.SetActive(false);
    }

    public void goToGameSelector()
    {
        shipsPanel.SetActive(false);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(false);
        gameSelector.SetActive(true);
    }

    public void startQuickRace()
    {
        Application.LoadLevel("Game");
    }

    public void returnMenu()
    {
        Application.LoadLevel("Menus");
        Destroy(this.gameObject);
    }

    public void selectShip(string ship)
    {
        selectedShip = ship;
        rivalShips.Clear();
        for (int i = 1; i <= 6; i++)
        {
            if(selectedShip!="Ship"+i)rivalShips.Add("Ship"+i);
        }

        goToWorldSelectionMenu();
    }

    public string getSelectedShip()
    {
        return selectedShip;
    }

    public List<string> getRivalShips()
    {
        return shuffle(rivalShips);
       // return rivalShips;
    }

    public List<string>  shuffle(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            var n = Random.Range(0, list.Count - 1);
            var aux = list[n];
            var n2 = Random.Range(0, list.Count - 1);
            list[n] = list[n2];
            list[n2] = aux;
        }
        return list;
    }

    public void selectWorld(string world, int difficulty)
    {
        selectedWorld = world;
        this.difficulty = difficulty;
        startQuickRace();
    }

    public int getDifficulty()
    {
        return difficulty;
    }
    public string getSelectedWorld()
    {
        return selectedWorld;
    }

}
