using UnityEngine;
using System.Collections;
using System.Net.Mime;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public GameObject tutorial;
    public AudioController audioController;
    public GameObject audioOn;
    public GameObject audioOff;

    // Use this for initialization
    void Start () {
	    changeImage();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showTutorial()
    {
        tutorial.SetActive(true);
    }

    public void musicOnOff()
    {       
        audioController.setStatus(!audioController.getStatus());
        changeImage();
    }

    public void exit()
    {
        Application.Quit();
    }

    public void closeMenu()
    {
        this.gameObject.SetActive(false);
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
}
