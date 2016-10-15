using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour {

    public FileController controller;
    public Text amount;
	// Use this for initialization
	void Start () {
        refreshValue();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void refreshValue()
    {
        amount.text = controller.getMoney().ToString();
    }

    public int getAmount()
    {
        return int.Parse(amount.text);
    }
}
