using UnityEngine;
using System.Collections;

public class ShipData : MonoBehaviour
{
    public float forwardSpeed;
    public float lateralSpeed;
    public float acceleration;
    public float maxSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float getForwardSpeed()
    {
        return forwardSpeed*0.1f;
    }

    public float getLateralSpeeed()
    {
        return lateralSpeed*0.1f;
    }

    public float getAcceleration()
    {
        return acceleration*0.0003f;
    }

    public float getMaxSpeed()
    {
        return maxSpeed*0.33f;
    }
}
