﻿using UnityEngine;
using System.Collections;

public class ShipData : MonoBehaviour
{
    public float forwardSpeed;
    public float lateralSpeed;
    public float acceleration;
    public float maxSpeed;
    public string shipName;
    public int price;

    void Start()
    {
    }

    void Update()
    {
    }

    public float getForwardSpeed(){ return forwardSpeed; }

    public float getLateralSpeeed(){ return lateralSpeed; }

    public float getAcceleration(){ return acceleration; }

    public float getMaxSpeed() { return maxSpeed; }
    
    public string getShipName() { return shipName; }

    public int getPrice() { return price; }
}
