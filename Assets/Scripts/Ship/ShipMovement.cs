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
        goForward();
        increaseSpeed();
	}

    private void goForward()
    {
        transform.Translate(0, forwardSpeed * Time.deltaTime, 0, Space.World);
    }

    public void checkSideToMove(bool right)
    {
        if (insideBounds(right)) lateralMovement(right);
        else noInput();
    }

    private void lateralMovement(bool right)
    {
        transform.Translate(right ? moveRight() : moveLeft(), 0, 0, Space.World);
    }

    private float moveLeft()
    {
        transform.Translate(-lateralSpeed * Time.deltaTime, 0, 0, Space.World);
        rotateLeft();
        return (-1) * lateralSpeed * Time.deltaTime;
    }

    private float moveRight()
    {
        transform.Translate(lateralSpeed * Time.deltaTime, 0, 0, Space.World);
        rotateRight();
        return lateralSpeed * Time.deltaTime;
    }

    private void rotateLeft()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, 0.2f, 1.0f);
    }

    private void rotateRight()
    {
        transform.rotation = new Quaternion(0.0f, 0.0f, -0.2f, 1.0f);
    }

    private void increaseSpeed()
    {
        if(forwardSpeed < maxSpeed) forwardSpeed += acceleration;
    }

    private void decreaseSpeed(float amount)
    {
        if (forwardSpeed > 0) forwardSpeed -= (forwardSpeed*amount)/100;
        if (forwardSpeed < 0) forwardSpeed = 0;
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
            //animacion roto
            decreaseSpeed((collider.gameObject.GetComponent<CollisionData>().getSlowAmountPercentage()));
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

    public float getMaxSpeed()
    {
        return maxSpeed;
    }
}
