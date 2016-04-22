using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class FinishController : MonoBehaviour
{
    public GameObject gameController;
    private Controller controller;
    private GameObject spawner;
    public Text finalPosition;
    public FinishPanelController finalPanel;

    public FinishSliderController finishSliderController;
    public UIPositionController positionController;
    private AudioController audioController;
    private FileController fileController;

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
                audioController.playFinishSound();
                showPosition(collider.gameObject);
                finalPanel.setPosition(controller.GetComponent<Controller>().positionOf(collider.gameObject));
                Invoke("showFinalPanel",2);
                if (controller.GetComponent<Controller>().positionOf(collider.gameObject)==1) unlocker();
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

    void unlocker()
    {
        if (controller.getSelectedWorld().Equals(fileController.getLastUnlockedWorldName()) && fileController.getNWorld() < 2)
        {
            fileController.writeUnlockeables(fileController.getNShip(), fileController.getNWorld() + 1);
        }
        if (controller.getDifficulty() == 3 && fileController.isWorldPassedInHard(controller.getSelectedWorld()))
        {
            fileController.writeUnlockeables(fileController.getNShip() + 1, fileController.getNWorld());
            fileController.writeHardWorldPassed(controller.getSelectedWorld());
        }
    }
}
