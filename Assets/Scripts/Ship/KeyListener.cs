using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {
    ShipMovement shipMovement;
	// Use this for initialization
	void Start () {
        shipMovement=GetComponent<ShipMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (right()) shipMovement.checkSideToMove(true);
        else if (left()) shipMovement.checkSideToMove(false);
        else shipMovement.noInput();
    }

    private static bool left()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    }

    private static bool right()
    {
        return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }
}
