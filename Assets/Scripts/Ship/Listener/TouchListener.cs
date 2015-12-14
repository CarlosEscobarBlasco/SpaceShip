using UnityEngine;
using System.Collections;

public class TouchListener : MonoBehaviour
{
    private ShipMovement movement;
    //private bool lastMove;
    private float timer;

    // Use this for initialization
    void Start ()
    {
        movement = gameObject.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
	void Update () {
	    if (Input.touchCount == 1)
	    {
	        if (Input.GetTouch(0).position.x < Camera.main.pixelWidth/2) movement.move(false);
	        if (Input.GetTouch(0).position.x >= Camera.main.pixelWidth/2) movement.move(true);
	        //movement.move(lastMove);
	    } //else if (Input.touchCount > 1) movement.move(!lastMove);
	    else
	    {
	        if (timer <= 0 && GetComponent<ShipPowerUp>().isPowerUpActive())
	        {
	            GetComponent<ShipPowerUp>().activatePowerUp();
                //print("Lanzar power up");
                timer = 0.5f;
	        }
	        else timer -= Time.deltaTime;
	        movement.noInput();
	    }
    }
}
