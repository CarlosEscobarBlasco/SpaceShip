using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldPowerUp : MonoBehaviour, PowerUp
{
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void execute()
    {
        //Activar Escudo
    }

    public Sprite icon { get; set; }

    public GameObject player { get; set; }
}
