using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{

    private MenuController menuController;
    public GameObject pausePanel;
    public GameObject spawner;

    // Use this for initialization
    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exitRace()
    {
        Time.timeScale = 1;
        menuController.returnMenu();
    }

    public void activePauseGame()
    {
        pausePanel.SetActive(true);
        pauseGame();
    }

    public void cancelPauseGame()
    {
        pausePanel.SetActive(false);
        resumeGame();
    }

    public void resumeGame()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
        spawner.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        Time.timeScale = 1;
        
    }

    public void pauseGame()
    {
        Time.timeScale = 0.0f;
        spawner.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
    }
}

