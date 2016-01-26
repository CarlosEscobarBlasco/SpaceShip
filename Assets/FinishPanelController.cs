using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishPanelController : MonoBehaviour
{

    public Controller controller;
    public Text position;
    public Text time;
    public Text collisions;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void show()
    {
        gameObject.SetActive(true);
        position.text = "position: "+ controller.GetComponent<Controller>().positionOf(controller.getPlayer());

    }
}
