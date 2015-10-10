using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShipData))]
[RequireComponent(typeof(BoxCollider2D))]
public class ShipMovement : MonoBehaviour {

    private float forwardSpeed;
    private float lateralSpeed;
    private float acceleration;
    private float maxSpeed;

    // Use this for initialization
    void Start ()
    {
        forwardSpeed = gameObject.GetComponent<ShipData>().getForwardSpeed();
        lateralSpeed = gameObject.GetComponent<ShipData>().getLateralSpeeed();
        acceleration = gameObject.GetComponent<ShipData>().getAcceleration();
        maxSpeed= gameObject.GetComponent<ShipData>().getMaxSpeed();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, forwardSpeed*Time.deltaTime, 0);
        increaseSpeed();
        Debug.Log(forwardSpeed);
	}


    public void lateralMovement(bool right)
    {
        if(insideBounds(right))transform.Translate(right ? lateralSpeed * Time.deltaTime : (-1)* lateralSpeed * Time.deltaTime, 0, 0);
    }

    private void increaseSpeed()
    {
        if(forwardSpeed < maxSpeed) forwardSpeed += acceleration;
    }

    private void decreaseSpeed(float amount)
    {
        if (forwardSpeed > 0) forwardSpeed -= amount;
        if (forwardSpeed < 0) forwardSpeed = 0;
        /**
        * Decrease Speed by percentage
        */
        //if (forwardSpeed > 0) forwardSpeed -= (forwardSpeed*amount)/100;
        //if (forwardSpeed < 0) forwardSpeed = 0;
    }

    private bool insideBounds(bool right)
    {
        if (right ? transform.position.x < 2.4f : transform.position.x > -2.4f ) return true;
        return false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Obstacle")
        {
            Destroy(collider.gameObject);
            decreaseSpeed((collider.gameObject.GetComponent<CollisionData>().getSlowAmount()));
        }
    }
}
