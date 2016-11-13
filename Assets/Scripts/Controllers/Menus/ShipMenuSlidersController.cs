using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShipMenuSlidersController : MonoBehaviour, MenuSliderController {

    public Slider accelerationSlider;
    public Slider maxSpeedSlider;
    public Slider gripSlider;
    public Text shipNameText;
    public FileController fileController;
    public GameObject buyButton;
    public Text price;
    public GameObject nextButton;

    private string[] unlockedShips;
    private MenuController menuController;
    private float maxAcc;
    private float maxGrip;
    private float maxSpeed;
    private int actualShip;
    private int actualColor;

	// Use this for initialization
	void Start () {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
	    unlockedShips = fileController.getShipColors(0);
        accelerationSlider.maxValue = 0.015f;
        accelerationSlider.minValue = 0;
        maxSpeedSlider.maxValue = 15;
        maxSpeedSlider.minValue = 0;
        gripSlider.maxValue = 5;
        gripSlider.minValue = 0;
        refreshValues(1);
	}
	
	// Update is called once per frame
	void Update () {
        if(accelerationSlider.value < maxAcc) accelerationSlider.value += 0.015f * Time.deltaTime;
        if (maxSpeedSlider.value < maxSpeed) maxSpeedSlider.value += 15 * Time.deltaTime;
        if (gripSlider.value < maxGrip) gripSlider.value += 5 * Time.deltaTime;
	}

    public void refreshValues(int actualShip)
    {
        unlockedShips = fileController.getShipColors(actualShip - 1); 
        unlock(1);
        //mirar para hacer en animacion
        accelerationSlider.value = 0;
        maxSpeedSlider.value = 0;
        gripSlider.value = 0;
        maxAcc = (Resources.Load("Prefabs/Ships/Ship" + actualShip + "-1") as GameObject).GetComponent<ShipData>().getAcceleration();
        maxSpeed = (Resources.Load("Prefabs/Ships/Ship" + actualShip + "-1") as GameObject).GetComponent<ShipData>().getMaxSpeed();
        maxGrip = (Resources.Load("Prefabs/Ships/Ship" + actualShip + "-1") as GameObject).GetComponent<ShipData>().getLateralSpeeed();
        shipNameText.text = (Resources.Load("Prefabs/Ships/Ship" + actualShip + "-1") as GameObject).GetComponent<ShipData>().getShipName();
        this.actualShip=actualShip;
    }

    public void refreshColorValues(int actualColor)
    {
        unlock(actualColor);
        shipNameText.text = (Resources.Load("Prefabs/Ships/Ship" + actualShip+"-"+actualColor) as GameObject).GetComponent<ShipData>().getShipName();
        this.actualColor = actualColor;
    }

    public void setShipToController()
    {
        menuController.selectShip("Ship" + actualShip);
    }

    void unlock(int actualColor)
    {
        if (unlockedShips[actualColor - 1] == "1")
        {
            buyButton.SetActive(false);
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
            buyButton.SetActive(true);
            price.text = (Resources.Load("Prefabs/Ships/Ship" + actualShip + "-" + actualColor) as GameObject).GetComponent<ShipData>().getPrice().ToString();
        }
    }

    public int getActualShip()
    {
        return actualShip;
    }

    public int getActualColor()
    {
        return actualColor;
    }
}
