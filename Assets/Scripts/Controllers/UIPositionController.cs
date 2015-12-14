using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPositionController : MonoBehaviour
{
    
    public Text actualPosition;
    public Text totalShips;

    public Controller controller;
    private GameObject player;

	// Use this for initialization
	void Start ()
	{
	    totalShips.text = 4 + "";
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    actualPosition.text = controller.positionOf(player).ToString() + "º";
	}
}
