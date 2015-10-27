using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject worldsPanel;
    public GameObject shipsPanel;

    private string selectedShip;
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
	    if(Input.GetKey(KeyCode.Escape)){
            if (shipsPanel.activeSelf)
            {
                goToWorldSelectionMenu();
            }
            else if (worldsPanel.activeSelf)
            {
                goToMainMenu();
            }
        }
	}

    public void goToWorldSelectionMenu()
    {
        shipsPanel.SetActive(false);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(true);
    }

    public void goToShipSelectionMenu()
    {
        shipsPanel.SetActive(true);
        mainPanel.SetActive(false);
        worldsPanel.SetActive(false);
    }

    public void goToMainMenu()
    {
        shipsPanel.SetActive(false);
        mainPanel.SetActive(true);
        worldsPanel.SetActive(false);
    }

    private void startQuickRace()
    {
        Application.LoadLevel("Game");
    }

    public void selectShip(GameObject ship)
    {
        selectedShip = ship.name;
        startQuickRace();
    }

    public string getSelectedShip()
    {
        return selectedShip;
    }

    public void selectWorld(GameObject world)
    {
        selectedWorld = world.name;
        goToShipSelectionMenu();
    }

    public string getSelectedWorld()
    {
        return selectedWorld;
    }

}
