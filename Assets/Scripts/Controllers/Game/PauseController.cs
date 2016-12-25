using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour
{

    private MenuController menuController;
    public GameObject pausePanel;
    public GameObject spawner;
    public Controller gameController;

    private AudioController audioController;
    public GameObject audioOn;
    public GameObject audioOff;

    // Use this for initialization
    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
        audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
        changeImage();
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

    public void restartGame()
    {
        resumeGame();
        gameController.restartGame();
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

    public void musicOnOff()
    {
        audioController.setStatus(!audioController.getStatus());
        changeImage();
    }

    private void changeImage()
    {
        if (!audioController.getStatus())
        {
            audioOn.SetActive(false);
            audioOff.SetActive(true);
        }
        else
        {
            audioOn.SetActive(true);
            audioOff.SetActive(false);
        }
    }

    void resumeGame()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        }
        if (spawner) spawner.SendMessage("OnResumeGame", SendMessageOptions.DontRequireReceiver);
        Time.timeScale = 1;
        
    }

    public void pauseGame()
    {
        Time.timeScale = 0.0f;
        if(spawner)spawner.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject go in objects)
        {
            go.SendMessage("OnPauseGame", SendMessageOptions.DontRequireReceiver);
        }
    }
}

