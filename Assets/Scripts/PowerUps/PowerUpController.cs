using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    public Image powerUpImage;
    private int currentPowerUp;
    public GameObject powerUpButton;
    private GameObject player;

    public Sprite ShieldSprite;
    public Sprite SpeedSprite;
    public Sprite RocketSprite;

	// Use this for initialization
	void Start ()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(player);
	    changePowerUp();
        disabledPowerUpButton();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (player.GetComponent<ShipPowerUp>().isPowerUpActive())
	    {
	        activePowerUpButton();
            changePowerUp();
	    }
        else disabledPowerUpButton();
	    currentPowerUp = player.GetComponent<ShipPowerUp>().getPowerUp();
	}

    private void changePowerUp()
    {
        switch (currentPowerUp)
        {
            case 1:
                powerUpImage.sprite = RocketSprite;
                break;
            case 2:
                powerUpImage.sprite = ShieldSprite;
                break;
            case 3:
                powerUpImage.sprite = SpeedSprite;
                break;
        }
    }

    private void activePowerUpButton()
    {
        powerUpButton.SetActive(true);
    }

    private void disabledPowerUpButton()
    {
        powerUpButton.SetActive(false);
    }
}
