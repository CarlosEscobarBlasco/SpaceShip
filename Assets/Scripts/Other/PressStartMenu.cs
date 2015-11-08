using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PressStartMenu : MonoBehaviour {

    public GameObject menuControllerGO;
    private MenuController menuController;
    public Text pressStart; 
    // Use this for initialization
	void Start () {
        menuController = menuControllerGO.GetComponent<MenuController>();
        blinkerText();
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (checkInput()) menuController.goToShipSelectionMenu();
	}

    private static bool checkInput()
    {
        return Input.touchCount >= 1 || Input.GetMouseButton(0);
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
