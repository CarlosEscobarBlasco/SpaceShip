using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MenuController : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject worldsPanel;
    public GameObject shipsPanel;
    public GameObject instructions;
    public GameObject credits;

    private string sceneName;
    private static string selectedShip;
    private static List<string> rivalShips = new List<string>();
    private string selectedWorld;
    private int difficulty;
    private static bool changeWorld;
    private AudioController audioController;

    void Awake()
    {
        //changeWorld = false;
    }

	// Use this for initialization
	void Start ()
	{
	    sceneName = "Menus";
        mainPanel.SetActive(true);
        shipsPanel.SetActive(false);
        worldsPanel.SetActive(false);
        instructions.SetActive(false);
	    audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
        audioController.playMainMenuMusic();
        if (changeWorld) goToWorldSelectionMenu();
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        
	    if(Input.GetKeyDown(KeyCode.Escape)){
            if (shipsPanel.activeSelf) goToGameSelector();
            else if (worldsPanel.activeSelf) goToShipSelectionMenu();
            else if(instructions.activeSelf) goToMainMenu();
            else if(mainPanel.activeSelf) exitApp();
        }
	}

    public void exitApp()
    {
        Application.Quit();
    }

    public void goToWorldSelectionMenu()
    {
        changeWorld = false;
        audioController.playButtonSound();
        shipsPanel.SetActive(false);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(true);
        instructions.SetActive(false);
        credits.SetActive(false);
    }

    public void goToShipSelectionMenu()
    {
        audioController.playButtonSound();
        shipsPanel.SetActive(true);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(false);
        instructions.SetActive(false);
        credits.SetActive(false);
    }

    public void goToMainMenu()
    {
        audioController.playButtonSound();
        shipsPanel.SetActive(false);
        mainPanel.SetActive(true);
        worldsPanel.SetActive(false);
        instructions.SetActive(false);
        credits.SetActive(false);
    }

    public void goToGameSelector()
    {
        audioController.playButtonSound();
        shipsPanel.SetActive(false);
        mainPanel.SetActive(true);
        worldsPanel.SetActive(false);
        instructions.SetActive(false);
        credits.SetActive(false);
    }

    public void goToInstructions()
    {
        audioController.playButtonSound();
        shipsPanel.SetActive(false);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(false);
        instructions.SetActive(true);
        credits.SetActive(false);
    }

    public void goToCredits()
    {
        audioController.playButtonSound();
        shipsPanel.SetActive(false);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(false);
        instructions.SetActive(false);
        credits.SetActive(true);
    }

    public void startQuickRace(string world)
    {
        SceneManager.LoadScene("Game "+ world);
        changeWorld = false;
        sceneName = world;
    }

    public void returnMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("FileController"));
        Destroy(audioController.gameObject);
        SceneManager.LoadScene("Menus");
        sceneName = "Menus";
        changeWorld = false;
        Destroy(this.gameObject);
    }

    public void selectShip(string ship)
    {
        selectedShip = ship;
        rivalShips.Clear();
        int rivalShip = 0;
        int rivalColor = 0;
        for (int i = 0; i < 4; i = i) // 4 es el numero de rivales
        {
            rivalShip = Random.Range(1, 5);
            rivalColor = Random.Range(1, 5);
            if (selectedShip != "Ship" + rivalShip + "-" + rivalColor && !rivalShips.Contains("Ship" + rivalShip + "-" + rivalColor))
            {
                rivalShips.Add("Ship" + rivalShip + "-" + rivalColor);
                i++;
            }
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
    }

    public List<string> shuffle(List<string> list)
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
        startQuickRace(world);
    }

    public int getDifficulty()
    {
        return difficulty;
    }

    public string getSelectedWorld()
    {
        return selectedWorld;
    }

    public string getSceneName()
    {
        return sceneName;
    }

    public void returnWorldSelectionMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("FileController"));
        changeWorld = true;
        SceneManager.LoadScene("Menus");
        sceneName = "Menus";
        Destroy(this.gameObject);
    }
}
