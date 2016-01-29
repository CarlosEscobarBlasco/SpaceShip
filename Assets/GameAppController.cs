using UnityEngine;
using System.Collections;

public class GameAppController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void exitGame()
    {
        
    }

    public void pauseGame()
    {
        Time.timeScale = 0.0f;
    }
}
