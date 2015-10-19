using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject shipsPanel;
    private string selectedShip;

	// Use this for initialization
	void Start () {
        shipsPanel.SetActive(false);
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void quickRace()
    {
        shipsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    private void startQuickRace()
    {
        Application.LoadLevel("Game");
        Debug.Log(selectedShip);
    }

    public void selectShip(GameObject ship)
    {
        selectedShip = ship.name;
        startQuickRace();
    }
}
