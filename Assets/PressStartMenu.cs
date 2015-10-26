using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PressStartMenu : MonoBehaviour {

    public GameObject menuControllerGO;
    private MenuController menuController;
    public Text pressStart; 
    private float counter;
    private float initialCounter;
    // Use this for initialization
	void Start () {
        menuController = menuControllerGO.GetComponent<MenuController>();
	    initialCounter = 0.5f;
	    counter = initialCounter;
        blinkerText();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount >= 1 || Input.GetMouseButton(0)) menuController.goToShipSelectionMenu();
	}

    private void blinkerText()
    {
        pressStart.text = changeText();
        Invoke("blinkerText", 0.5f);
    }

    private string changeText()
    {
        return pressStart.text.Length > 0 ? "" : "Press To Start";
    }

}
