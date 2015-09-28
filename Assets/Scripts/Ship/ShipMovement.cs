using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
    public float forwardSpeed;
    public float lateralSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, forwardSpeed*Time.deltaTime, 0);
        increaseSpeed();
	}


    public void lateralMovement(bool right)
    {
        if(insideBounds(right))transform.Translate(right ? lateralSpeed * Time.deltaTime : (-1)* lateralSpeed * Time.deltaTime, 0, 0);
    }

    private void increaseSpeed()
    {
        if(forwardSpeed < 3) forwardSpeed += 0.1f;
    }

    private bool insideBounds(bool right)
    {
        if (right ? transform.position.x < 2.4f : transform.position.x > -2.4f ) return true;
        return false;
    }
}
