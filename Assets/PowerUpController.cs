using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{
    private float powerUpCoolDown;
    public Image powerUpImage;
    private PowerUp actualPoweUp;
    public Button powerUpButton;

	// Use this for initialization
	void Start ()
	{
	    powerUpCoolDown = 10;
	    changePowerUp();
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
        actualPoweUp.execute();
        changePowerUp();
        disabledPowerUpButton();
    }

    private void changePowerUp()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                actualPoweUp = new RocketPowerUp();
                break;
            case 2:
                actualPoweUp = new ShieldPowerUp();
                break;
            case 3:
                actualPoweUp = new SpeedPowerUp();
                break;
        }
        powerUpImage.sprite = actualPoweUp.icon;
    }

    private void activePowerUpButton()
    {
        powerUpButton.enabled = true;
    }

    private void disabledPowerUpButton()
    {
        powerUpButton.enabled = false;
    }
}
