using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buy : MonoBehaviour {

    public FileController fileController;
    public ShipMenuSlidersController shipController;
    public ShowMoney showMoney;
    public Text amount;
    public paintLockedShip paintShips;
    public GameObject nextButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void purchase()
    {
        if (showMoney.getAmount() < int.Parse(amount.text)) return;
        //fileController.purchaseShip(shipController.getActualShip()-1,int.Parse(amount.text));
        showMoney.refreshValue();
        paintShips.paint();
        nextButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
