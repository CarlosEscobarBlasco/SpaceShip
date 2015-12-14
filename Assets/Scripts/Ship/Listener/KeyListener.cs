using UnityEngine;
using System.Collections;

public class KeyListener : MonoBehaviour {
    ShipMovement shipMovement;
    private float timer;
    // Use this for initialization
	void Start () {
        shipMovement=GetComponent<ShipMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (right()&&!left()) shipMovement.move(true);
        else if (left()&&!right()) shipMovement.move(false);
        else if (right() && left()) powerUp();
        else shipMovement.noInput();
    }

    private void powerUp()
    {
        if (timer <= 0)
        {
            GetComponent<ShipPowerUp>().activatePowerUp();
            //print("Lanzar power up");
            timer = 0.5f;
        }
        else timer -= Time.deltaTime;
    }

    private bool left()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
    }

    private bool right()
    {
        return Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }
}
