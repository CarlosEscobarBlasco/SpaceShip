using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{

    private MenuController menuController;
    public GameObject pausePanel;

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

    public void pauseGame()
    {
        Time.timeScale = 0.0f;
        pausePanel.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}

