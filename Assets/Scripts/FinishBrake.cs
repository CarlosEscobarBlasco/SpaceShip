using UnityEngine;
using System.Collections;

public class FinishBrake : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "CPU" || collider.tag == "Player")
        {
            collider.gameObject.GetComponent<ShipMovement>().stopShip();
        }
    }
}
