using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{

    public GameObject pausePanel;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void pauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }


}
