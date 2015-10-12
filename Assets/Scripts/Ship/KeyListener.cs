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
        if (Input.GetKey(KeyCode.RightArrow)) shipMovement.lateralMovement(true);
        else if (Input.GetKey(KeyCode.LeftArrow)) shipMovement.lateralMovement(false);
        else shipMovement.noInput();
    }
}
