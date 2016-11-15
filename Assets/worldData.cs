using UnityEngine;
using System.Collections;

public class worldData : MonoBehaviour
{

    public string name;
    public int price;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getPrice()
    {
        return price;
    }

    public string getName()
    {
        return name;
    }

}
