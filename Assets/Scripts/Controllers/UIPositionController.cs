using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPositionController : MonoBehaviour
{
    
    public Text actualPosition;
    public Text totalShips;

    public Controller controller;
    private GameObject player;
    private bool finish;

	// Use this for initialization
	void Start ()
	{
	    totalShips.text = 4 + "";
	    finish = false;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!finish)
	    {
	        actualPosition.text = controller.positionOf(player).ToString() + "º";
	    }
	}

    public void setPosition(String position)
    {
        actualPosition.text = position;
        finish = true;
    }
}
