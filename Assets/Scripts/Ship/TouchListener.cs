using UnityEngine;
using System.Collections;

public class TouchListener : MonoBehaviour
{
    private ShipMovement movement;
    // Use this for initialization
    void Start ()
    {
        movement = gameObject.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
	void Update () {
	    if (ButtonController.getInput() == "Right")
	    {
	        movement.lateralMovement(true);
	    }else if (ButtonController.getInput() == "Left")
	    {
            movement.lateralMovement(false);
        }
	    else
	    {
            movement.noInput();
        }
	}

}
