using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShipPosition : MonoBehaviour {

    private List<GameObject> ships;
    private Controller controller;

	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
        ships = controller.getShipsToUIList();
        chargeIcons();
	}
	
	// Update is called once per frame
	void Update () {
        ships = controller.getShipsToUIList();
        chargeIcons();
    }

    private void chargeIcons()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < ships.Count; i++)
        {
            GameObject shipIcon = Instantiate(Resources.Load("Prefabs/Ship"),new Vector3(transform.position.x, transform.position.y-i*60, transform.position.z), transform.rotation) as GameObject;
            shipIcon.transform.SetParent(this.transform);
            shipIcon.transform.localScale = new Vector3(1,1,1);
            shipIcon.GetComponentInChildren<Text>().text = i + 1 + "º";
            if(ships[i].tag=="Player")shipIcon.GetComponentInChildren<Text>().color = Color.yellow;
            shipIcon.GetComponentInChildren<Image>().sprite = ships[i].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
