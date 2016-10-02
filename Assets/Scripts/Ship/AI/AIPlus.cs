using UnityEngine;
using System.Collections;
using System;

public class AIPlus : MonoBehaviour
{
    private const float SPEED_REDUCER = 0.75f;
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

    private void boost(bool enable)
    {
        gameObject.GetComponent<ShipMovement>().setMaxSpeed(enable && (originalMaxSpeed>8) ? originalMaxSpeed * SPEED_REDUCER : originalMaxSpeed);
        gameObject.GetComponent<Collider2D>().enabled = !enable;
    }

    public void setDistance(int distance)
    {
        this.distance = distance;
    }

}
