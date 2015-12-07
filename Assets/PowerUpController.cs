using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    private float powerUpCoolDown;
    public Image powerUpImage;
    private PowerUp actualPowerUp;
    public GameObject powerUpButton;

    public Sprite ShieldSprite;
    public Sprite SpeedSprite;
    public Sprite RocketSprite;

	// Use this for initialization
	void Start ()
	{
	    powerUpCoolDown = 10;
	    changePowerUp();
        disabledPowerUpButton();
	}
	
	// Update is called once per frame
	void Update ()
	{
        powerUpCoolDown -= Time.deltaTime;
	    if (powerUpCoolDown <= 0)
	    {
	        activePowerUpButton();
	    }
	}

    public void activatePowerUp()
    {
        powerUpCoolDown = 10;
        actualPowerUp.execute();
        changePowerUp();
        disabledPowerUpButton();
    }

    private void changePowerUp()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                actualPowerUp = gameObject.AddComponent<RocketPowerUp>();
                powerUpImage.sprite = RocketSprite;
                break;
            case 2:
                actualPowerUp = gameObject.AddComponent<ShieldPowerUp>();
                powerUpImage.sprite = ShieldSprite;
                break;
            case 3:
                actualPowerUp = gameObject.AddComponent<SpeedPowerUp>();
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
