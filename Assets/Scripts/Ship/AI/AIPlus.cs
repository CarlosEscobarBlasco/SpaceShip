using UnityEngine;
using System.Collections;
using System;

public class AIPlus : MonoBehaviour
{
    private GameObject player;
    public int distance;
	// Use this for initialization
    
	void Start ()
	{
	    player = GameObject.FindGameObjectWithTag("Player");
	    //distance = 10;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (player.transform.position.y > gameObject.transform.position.y + distance) setCollider(false);
        else setCollider(true);
	}

    private void setCollider(bool status)
    {
        gameObject.GetComponent<Collider2D>().enabled = status;
    }

    public void setDistance(int distance)
    {
        this.distance = distance;
    }

}
