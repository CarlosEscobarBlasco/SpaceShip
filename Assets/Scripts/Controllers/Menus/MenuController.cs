using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject worldsPanel;
    public GameObject shipsPanel;
    public GameObject gameSelector;

    private string selectedShip;
    private List<string> rivalShips = new List<string>();
    private string selectedWorld;

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

    private void startQuickRace()
    {
        Application.LoadLevel("Game");
    }

    public void selectShip(string ship)
    {
        selectedShip = ship;
        for (int i = 1; i <= 5; i++)
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
        shuffle(rivalShips);
        return rivalShips;
    }

    public static void shuffle(IList<string> list)  
    {
        int n = list.Count;  
        while (n > 1) {  
            n--;
            int k = Random.Range(n, list.Count);
            string value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

    public void selectWorld(string world, int difficulty)
    {
        selectedWorld = world;
        startQuickRace();
    }

    public string getSelectedWorld()
    {
        return selectedWorld;
    }

}
