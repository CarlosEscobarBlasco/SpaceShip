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

	// Use this for initialization
	void Start ()
	{
	    controller = gameController.GetComponent<Controller>();
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
            Debug.Log(collider.gameObject.name);
            collider.gameObject.GetComponent<ShipMovement>().stopShip();
            if(collider.tag=="Player") showPosition(collider.gameObject);
        }else if (collider.tag == "Spawner")
        {
            spawner = collider.gameObject;
            Invoke("destroySpawner",1);
        }
    }

    void destroySpawner()
    {
        Destroy(spawner);
    }

    void showPosition(GameObject ship)
    {
        finalPosition.text = controller.GetComponent<Controller>().positionOf(ship) + "º";
    }
}
