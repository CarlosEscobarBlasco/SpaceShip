using System;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShipData))]
[RequireComponent(typeof(BoxCollider2D))]
//mirar si se puede hacer si tiene tag X require Y para cpu y player
public class ShipMovement : MonoBehaviour {

    private float forwardSpeed;
    private float lateralSpeed;
    private float acceleration;
    private float maxSpeed;
    private bool shield;

    // Use this for initialization
    void Start ()
    {
        forwardSpeed = gameObject.GetComponent<ShipData>().getForwardSpeed();
        lateralSpeed = gameObject.GetComponent<ShipData>().getLateralSpeeed();
        acceleration = gameObject.GetComponent<ShipData>().getAcceleration();
        maxSpeed= gameObject.GetComponent<ShipData>().getMaxSpeed();
        shield = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        goForward();
        ChangeSpeed();
	}

    private void goForward()
    {
        transform.Translate(0, forwardSpeed * Time.deltaTime, 0, Space.World);
    }

    public void move(bool right)
    {
        if (insideBounds(right)) if (right) moveRight(); else moveLeft();
        else noInput();
    }

    private void moveLeft()
    {
        transform.Translate(-lateralSpeed * Time.deltaTime, 0, 0, Space.World);
        rotateLeft();
    }

    private void moveRight()
    {
        transform.Translate(lateralSpeed * Time.deltaTime, 0, 0, Space.World);
        rotateRight();
    }

    private void rotateLeft()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.2f, 1.0f);
    }

    private void rotateRight()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, -0.2f, 1.0f);
    }

    public void activeShield()
    {
        //animacion shield
        shield = true;
    }

    private void ChangeSpeed()
    {
        if (forwardSpeed < maxSpeed && forwardSpeed > 0) forwardSpeed += acceleration;
    }

    private void speedReductionByPercentage(float percentage)
    {
        if (forwardSpeed > 0) forwardSpeed -= (forwardSpeed*percentage)/100;
        if (forwardSpeed < 0) forwardSpeed = 0;
    }

    private void speedIncreaseByPercentage(float amount)
    {
        if (forwardSpeed < maxSpeed && forwardSpeed > 0) forwardSpeed += amount;
    }

    private bool insideBounds(bool right)
    {
        if (right ? transform.position.x < 2.4f : transform.position.x > -2.4f ) return true;
        return false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Meteor")
        {
            if (!shield)
            {
                collider.gameObject.GetComponent<MeteorDestroyer>().destroyMeteor();
                speedReductionByPercentage(collider.gameObject.GetComponent<CollisionData>().getSlowAmountPercentage());
                GetComponent<ShipStatistics>().increaseCollisionStatistic();
            }
            else shield = false;
        }else if (collider.tag == "TurboSpeed")
        {
            speedIncreaseByPercentage(collider.gameObject.GetComponent<CollisionData>().getSlowAmountPercentage());
        }

    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "BlackHole")
        {
            if (forwardSpeed <= 1f) acceleration = gameObject.GetComponent<ShipData>().getAcceleration();
            else acceleration = gameObject.GetComponent<ShipData>().getAcceleration() * -5 * forwardSpeed;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag=="BlackHole")
        {
            acceleration = gameObject.GetComponent<ShipData>().getAcceleration();
            if (forwardSpeed <= 0) forwardSpeed = 0.5f;
        }
    }

    public void noInput()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
    }

    public float getForwardSpeed()
    {
        return forwardSpeed;
    }

    public void setForwardSpeed(float speed)
    {
        forwardSpeed = speed;
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
    }

    public void stopShip()
    {
        acceleration *= -30;
        forwardSpeed -= 1;
        Invoke("disableScript", 1);
    }

    private void disableScript()
    {
        gameObject.GetComponent<ShipMovement>().enabled = false;
        if (gameObject.tag == "Player")
        {
            try
            {
                gameObject.GetComponent<KeyListener>().enabled = false;
                gameObject.GetComponent<TouchListener>().enabled = false;
            }
            catch
            {
            }
        }
        else gameObject.GetComponent<ArtificialIntelligence>().enabled = false;
    }
}
