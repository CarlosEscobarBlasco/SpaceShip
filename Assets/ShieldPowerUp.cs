using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldPowerUp : MonoBehaviour, PowerUp
{
    // Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void execute()
    {
        //Activar Escudo
        Debug.Log("Escudo activado!");
        player.GetComponent<ShipMovement>().activeShield();
    }

    public GameObject player { get; set; }
}
