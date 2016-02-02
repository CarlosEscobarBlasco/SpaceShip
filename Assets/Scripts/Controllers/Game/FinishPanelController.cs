using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class FinishPanelController : MonoBehaviour
{

    public Controller controller;
    public Text position;
    public Text time;
    public Text collisions;
    private MenuController menuController;
	// Use this for initialization
	void Start () {
        menuController = GameObject.FindGameObjectWithTag("MenuController").GetComponent<MenuController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPosition(int position)
    {
        this.position.text = position + "º";
    }

    public void show()
    {      
        gameObject.SetActive(true);
        time.text = "Time: "+controller.getTimeOfPlayer();
        collisions.text = "Collisions: "+controller.getCollisionsOfPlayer();

    }

    public void playAgain()
    {
       menuController.startQuickRace(EditorApplication.currentScene.Split(' ')[1].Split('.')[0]);
    }

    public void goToMainMenu()
    {
        menuController.returnMenu();
    }
}
