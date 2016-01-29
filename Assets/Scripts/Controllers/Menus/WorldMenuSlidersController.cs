using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldMenuSlidersController : MonoBehaviour, MenuSliderController{

    public Text worldName;
    //private int actualWorld;
    private MenuController menuController;

    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
        refreshValues(1);
    }

    void Update()
    {

    }

    public void refreshValues(int actualWorld)
    {
        worldName.text = transform.GetChild(0).GetChild(actualWorld - 1).name;
        //this.actualWorld = actualWorld;
    }

    public void setPlanetToController(int difficulty)
    {
        menuController.selectWorld(worldName.text, difficulty);
    }
}
