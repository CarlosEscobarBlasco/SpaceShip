using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

    private ShipMovement shipMovement;

	// Use this for initialization
	void Start () {
        GetComponent<Slider>().minValue = 0;
        
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = shipMovement.getForwardSpeed();
	}

    public void setPlayer(GameObject player)
    {
        shipMovement = player.GetComponent<ShipMovement>();
        GetComponent<Slider>().maxValue = player.GetComponent<ShipData>().getMaxSpeed();
    }
}
