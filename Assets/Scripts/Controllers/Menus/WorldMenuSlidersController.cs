using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldMenuSlidersController : MonoBehaviour, MenuSliderController{

    public Text worldName;
    public Text worldPrice;
    private int actualWorld;
    private MenuController menuController;
    public FileController fileController;
    public GameObject buyButton;
    public GameObject difficultyButton;
    public Text price;

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
        unlock(actualWorld);
        worldName.text = transform.GetChild(0).GetChild(actualWorld - 1).name;
        this.actualWorld = actualWorld;
    }

    public void setPlanetToController(int difficulty)
    {
        menuController.selectWorld(worldName.text, difficulty);
    }

    public int getActualWorld()
    {
        return actualWorld;
    }

    void unlock(int actualWorld)
    {
        if (fileController.isWorldUnlocked(actualWorld-1))
        {
            buyButton.SetActive(false);
            difficultyButton.SetActive(true);
        }
        else
        {
            difficultyButton.SetActive(false);
            buyButton.SetActive(true);
            price.text = (Resources.Load("Prefabs/Worlds/World" + actualWorld) as GameObject).GetComponent<worldData>().getPrice().ToString();
        }
    }
}
