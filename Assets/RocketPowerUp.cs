using UnityEngine;
using System.Collections;

public class RocketPowerUp : MonoBehaviour, PowerUp {

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void execute()
    {
        //disparar el misil
        Debug.Log("Misil lanzado");
    }

    public GameObject player { get; set; }
}
