using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class FinishController : MonoBehaviour
{
    //public Rewards rewards;
    public GameObject gameController;
    private Controller controller;
    private GameObject spawner;
    public Text finalPosition;
    public FinishPanelController finalPanel;

    public FinishSliderController finishSliderController;
    public UIPositionController positionController;
    private AudioController audioController;
    private GameObject player;
    private FileController fileController;
    private int reward;

    // Use this for initialization
    void Start ()
	{
        fileController = GameObject.FindGameObjectWithTag("FileController").GetComponent<FileController>();
        controller = gameController.GetComponent<Controller>();
	    finishSliderController.setDistance(this.transform.position.y);
        audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
    }
	
	// Update is called once per frame
	void Update () {
	}

    void Reset()
    {
        gameObject.GetComponent<Collider2D>().transform.localScale = new Vector3(10, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "CPU" || collider.tag == "Player")
        {
            collider.gameObject.GetComponent<ShipStatistics>().stopStatistics();
            if (collider.tag == "Player")
            {
                player = collider.gameObject;
                reward = gameController.GetComponent<Rewards>().getReward();
                fileController.increaseMoney(reward);
                audioController.playFinishSound();
                showPosition(collider.gameObject);
                finalPanel.setPosition(controller.GetComponent<Controller>().positionOf(collider.gameObject));
                Invoke("showFinalPanel",2);
                //if (finishController.GetComponent<Controller>().positionOf(collider.gameObject)==1) unlocker();
            }
        }else if (collider.tag == "Spawner")
        {
            spawner = collider.gameObject;
            Invoke("destroySpawner",2.5f);
        }
    }

    void destroySpawner()
    {
        Destroy(spawner);
    }

    void showPosition(GameObject ship)
    {
        finalPosition.text = controller.GetComponent<Controller>().positionOf(ship) + "º";
        positionController.setPosition(finalPosition.text);
    }

    void showFinalPanel()
    {
        finalPanel.show();
    }

    public int getCollisionsOfPlayer()
    {
        return player.GetComponent<ShipStatistics>().getCollisions();
    }

    public string getTimeOfPlayer()
    {
        return trasnformTimeFormat(player.GetComponent<ShipStatistics>().getDuration());
    }

    public int getReward()
    {
        return reward;
    }

    private string trasnformTimeFormat(float time)
    {
        int min = (int)time / 60;
        float sec;
        float.TryParse((time % 60).ToString().Split('.')[0], out sec);
        float milSec;
        float.TryParse(time.ToString().Split('.')[1].Substring(0, 2), out milSec);
        return (min > 9 ? min.ToString() : "0" + min) + ":" + (sec > 9 ? sec.ToString() : "0" + sec) + ":" + (milSec > 9 ? milSec.ToString() : milSec + "0");
    }

    /*void unlocker()
    {
        if (finishController.getSelectedWorld().Equals(fileController.getLastUnlockedWorldName()) && fileController.getNWorld() < 2)
        {
            fileController.writeUnlockeables(fileController.getNShip(), fileController.getNWorld() + 1);
        }
        if (finishController.getDifficulty() == 3 && fileController.isWorldPassedInHard(finishController.getSelectedWorld()))
        {
            fileController.writeUnlockeables(fileController.getNShip() + 1, fileController.getNWorld());
            fileController.writeHardWorldPassed(finishController.getSelectedWorld());
        }
    }*/
}
