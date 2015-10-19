using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject shipsPanel;

	// Use this for initialization
	void Start () {
        shipsPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void quickRace()
    {
        shipsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
}
