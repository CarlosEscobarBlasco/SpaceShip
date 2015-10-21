using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuShipData : MonoBehaviour {

    public Slider max;
    public Slider acce;
    public Slider grip;
    private ShipData data;
	// Use this for initialization
	void Start () {
        data = (Resources.Load("Prefabs/Ships/Ship1") as GameObject).GetComponent<ShipData>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(data.getAcceleration());
	}

}
