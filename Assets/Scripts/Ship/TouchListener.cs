using UnityEngine;
using System.Collections;

public class TouchListener : MonoBehaviour
{
    private ShipMovement movement;
    private bool lastMove;

    // Use this for initialization
    void Start ()
    {
        movement = gameObject.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
	void Update () {
	    if (Input.touchCount == 1)
	    {
	        if (Input.GetTouch(0).position.x < 180)lastMove = false;
	        if (Input.GetTouch(0).position.x >= 180)lastMove = true;
            movement.checkSideToMove(lastMove);
        }else if (Input.touchCount > 1)movement.checkSideToMove(!lastMove);
        else movement.noInput();
    }
}
