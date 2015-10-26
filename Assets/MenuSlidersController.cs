using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuSlidersController : MonoBehaviour {

    public Slider accelerationSlider;
    public Slider maxSpeedSlider;
    public Slider gripSlider;

	// Use this for initialization
	void Start () {
        accelerationSlider.maxValue = 0.015f;
        accelerationSlider.minValue = 0.005f;
        maxSpeedSlider.maxValue = 15;
        maxSpeedSlider.minValue = 5;
        gripSlider.maxValue = 3;
        gripSlider.minValue = 1;
        refreshValues();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void refreshValues()
    {
        accelerationSlider.value = (Resources.Load("Prefabs/Ships/Ship1") as GameObject).GetComponent<ShipData>().getAcceleration();
        maxSpeedSlider.value = (Resources.Load("Prefabs/Ships/Ship1") as GameObject).GetComponent<ShipData>().getMaxSpeed();
        gripSlider.value = (Resources.Load("Prefabs/Ships/Ship1") as GameObject).GetComponent<ShipData>().getLateralSpeeed();
    }
}
