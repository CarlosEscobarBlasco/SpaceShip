using UnityEngine;
using System.Collections;

public class ShipPowerUp : MonoBehaviour {

    private float powerUpCoolDown;
    private PowerUp currentPowerUp;
    private int currentPowerUpIndex;
    private bool isActive;

    // Use this for initialization
    void Start()
    {
        powerUpCoolDown = 10;
        changePowerUp();
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        powerUpCoolDown -= Time.deltaTime;
        if (powerUpCoolDown <= 0)
        {
            isActive = true;
        }
    }

    public void activatePowerUp()
    {
        powerUpCoolDown = 10;
        currentPowerUp.execute(this.gameObject);
        changePowerUp();
        isActive = false;
    }

    private void changePowerUp()
    {
        currentPowerUpIndex = Random.Range(1, 4);
        switch (currentPowerUpIndex)
        {
            case 1:
                currentPowerUp = gameObject.AddComponent<RocketPowerUp>();
                break;
            case 2:
                currentPowerUp = gameObject.AddComponent<ShieldPowerUp>();
                break;
            case 3:
                currentPowerUp = gameObject.AddComponent<SpeedPowerUp>();
                break;
        }
    }

    public bool isPowerUpActive()
    {
        return isActive;
    }

    public int getPowerUp()
    {
        return currentPowerUpIndex;
    }
}
