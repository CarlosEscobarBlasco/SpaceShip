using UnityEngine;
using System.Collections;

public class ShipStatistics : MonoBehaviour
{

    private int collisions;
    private float duration;
    private bool flag;

	// Use this for initialization
	void Start ()
	{
	    duration = 0;
	    collisions = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    if(flag)duration += Time.deltaTime;
	}

    public void startStatistics()
    {
        duration = 0;
        collisions = 0;
        flag = true;
    }

    public void stopStatistics()
    {
        flag = false;
    }

    public void increaseCollisionStatistic()
    {
        collisions++;
    }

    public int getCollisions()
    {
        return collisions;
    }

    public float getDuration()
    {
        return duration;
    }
}
