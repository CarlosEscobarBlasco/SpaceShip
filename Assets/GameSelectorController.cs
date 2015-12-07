using UnityEngine;
using System.Collections;

public class GameSelectorController : MonoBehaviour
{
    public MenuController menuController;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void quickRace()
    {
        menuController.goToShipSelectionMenu();
    }
}
