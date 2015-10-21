using UnityEngine;
using System.Collections;

public class PressStartMenu : MonoBehaviour {

    public GameObject menuControllerGO;
    private MenuController menuController;

	// Use this for initialization
	void Start () {
        menuController = menuControllerGO.GetComponent<MenuController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount >= 1 || Input.GetMouseButton(0))
        {
            menuController.goToShipSelectionMenu();
        }
	}
}
