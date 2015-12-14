using UnityEngine;
using System.Collections;

public class SpeedPowerUp : MonoBehaviour, PowerUp {

	// Use this for initialization
	void Start () {
	    //player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void execute(GameObject ship)
    {
        //subirle la velocidad a tope al player
        Debug.Log("Velocidad a tope!");
        ship.GetComponent<ShipMovement>().setForwardSpeed(ship.GetComponent<ShipMovement>().getMaxSpeed());
    }

    //public GameObject player { get; set; }
}
