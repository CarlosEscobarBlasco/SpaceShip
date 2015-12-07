using UnityEngine;
using System.Collections;

public class RocketPowerUp : MonoBehaviour, PowerUp {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void execute()
    {
        //disparar el misil
    }

    public Sprite icon { get; set; }

    public GameObject player { get; set; }
}
