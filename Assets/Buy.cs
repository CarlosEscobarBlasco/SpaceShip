using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buy : MonoBehaviour {

    public FileController fileController;
    public ShipMenuSlidersController shipController;
    public WorldMenuSlidersController worldController;
    public ShowMoney showMoney;
    public Text amount;
    public paintLockedShip paintShips;
    public paintLockedPlanets paintPlanets;
    public GameObject nextButton;
    public GameObject difficultyButtons;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void purchaseShip()
    {
        if (showMoney.getAmount() < int.Parse(amount.text)) return;
        fileController.purchaseShip(shipController.getActualShip()-1, shipController.getActualColor()-1, int.Parse(amount.text));
        showMoney.refreshValue();
        paintShips.paint();
        nextButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void purchaseWorld()
    {
        if (showMoney.getAmount() < int.Parse(amount.text)) return;
        fileController.purchaseWorld(worldController.getActualWorld()-1,int.Parse(amount.text));
        showMoney.refreshValue();
        paintPlanets.paint();
        difficultyButtons.SetActive(true); 
        gameObject.SetActive(false);

    }
}
