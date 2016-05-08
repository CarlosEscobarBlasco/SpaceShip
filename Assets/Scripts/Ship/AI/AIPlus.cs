using UnityEngine;
using System.Collections;
using System;

public class AIPlus : MonoBehaviour
{
    private const float SPEED_REDUCER = 0.7f;
    private GameObject player;
    public int distance;
    private float originalMaxSpeed;

	// Use this for initialization   
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	    originalMaxSpeed = gameObject.GetComponent<ShipMovement>().getMaxSpeed();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    boost(player.transform.position.y > gameObject.transform.position.y + distance);
	}

    private void boost(bool status)
    {
        print("original: "+ originalMaxSpeed);
        print("actual: "+ gameObject.GetComponent<ShipMovement>().getMaxSpeed());
        gameObject.GetComponent<ShipMovement>().setMaxSpeed(status ? 0 : originalMaxSpeed);
        gameObject.GetComponent<Collider2D>().enabled = !status;
    }

    public void setDistance(int distance)
    {
        this.distance = distance;
    }

}
