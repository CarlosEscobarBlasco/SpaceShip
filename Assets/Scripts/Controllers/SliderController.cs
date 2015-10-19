using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

    private ShipMovement shipData;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = shipData.getForwardSpeed();
	}

    public void setPlayer(GameObject player)
    {
        shipData = player.GetComponent<ShipMovement>();
        GetComponent<Slider>().maxValue = shipData.getMaxSpeed();
    }
}
