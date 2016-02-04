using UnityEngine;
using System.Collections;

public class BlackHole : MonoBehaviour
{
    public float minSpeedInside;
    public float slowAmount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public float getSlowAmount()
    {
        return slowAmount;
    }

    public float getMinSpeedInside()
    {
        return minSpeedInside;
    }

    
}
