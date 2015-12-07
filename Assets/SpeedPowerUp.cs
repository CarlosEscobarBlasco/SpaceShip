using UnityEngine;
using System.Collections;

public class SpeedPowerUp : MonoBehaviour, PowerUp {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void execute()
    {
        //subirle la velocidad a tope al player
        Debug.Log("Velocidad a tope!");
    }

    public GameObject player { get; set; }
}
