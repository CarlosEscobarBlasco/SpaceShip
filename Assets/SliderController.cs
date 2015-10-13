using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderController : MonoBehaviour {

    private GameObject player;
    private ShipMovement shipData;

	// Use this for initialization
	void Start () {
        player = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Slider>().value = shipData.getForwardSpeed();
	}

    public void setPlayer(GameObject player)
    {
        this.player = player;
        shipData = player.GetComponent<ShipMovement>();
        GetComponent<Slider>().maxValue = shipData.getMaxSpeed();
    }
}
