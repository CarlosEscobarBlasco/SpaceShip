using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldMenuSlidersController : MonoBehaviour, MenuSliderController{

    public Slider accelerationSlider;
    public Slider maxSpeedSlider;

    void Start()
    {
        refreshValues(1);
    }

    void Update()
    {

    }

    public void refreshValues(int actualShip)
    {
        
    }
}
