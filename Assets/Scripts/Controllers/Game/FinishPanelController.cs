using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishPanelController : MonoBehaviour
{

    public FinishController finishController;
    public Text position;
    public Text position2;
    public Text time;
    public Text collisions;
    public Text planet;
    public Text difficulty;
    public Text reward;

    private GameObject Controller;
	
    // Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setPosition(int position)
    {
        this.position.text = " "+position + "º";
    }

    public void show()
    {      
        gameObject.SetActive(true);
        StartCoroutine(CalculateBase());
    }

    IEnumerator CalculateBase()
    {
        Controller = GameObject.FindWithTag("GameController");
        for (int i = 0; i <= finishController.getInitialReward(); i++)
        {
            reward.text = "Reward: " + i;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.3f);
        time.text = "Time: " + finishController.getTimeOfPlayer();
        yield return new WaitForSeconds(0.3f);
        time.text = time.text + "(-" + Math.Round(finishController.getTimeOfPlayerNoFormat()) + ")";

        yield return new WaitForSeconds(0.3f);
        int rewardPrice = 0;
        for (int i = 0; i <= finishController.getTimeOfPlayerNoFormat(); i++)
        {
            rewardPrice = finishController.getInitialReward() - i;
            reward.text = "Reward: " + rewardPrice;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.3f);
        collisions.text = "Collisions: " + finishController.getCollisionsOfPlayer();
        yield return new WaitForSeconds(0.3f);
        collisions.text = collisions.text + "(-" + finishController.getCollisionsOfPlayer() + ")";

        yield return new WaitForSeconds(0.3f);
        int rewardCollision = 0;
        for (int i = 0; i <= finishController.getCollisionsOfPlayer(); i++)
        {
            rewardCollision = rewardPrice - i;
            reward.text = "Reward: " + rewardCollision;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.3f);
        planet.text = "Planet: " + Controller.GetComponent<Controller>().getSelectedWorld();
        yield return new WaitForSeconds(0.3f);
        int planetReward = 0;
        switch (Controller.GetComponent<Controller>().getSelectedWorld())
        {
            case "Earth":
                planetReward = 0;
                break;
            case "Mars":
                planetReward = 20;
                break;
            case "Saturn":
                planetReward = 40;
                break;
            default:
                planetReward = 0;
                break;
        }
        planet.text = planet.text + "(+" + planetReward + ")";

        yield return new WaitForSeconds(0.3f);
        int rewardPlanet = 0;
        planetReward += rewardCollision;
        for (int i = rewardCollision; i <= planetReward; i++)
        {
            rewardPlanet = i;
            reward.text = "Reward: " + rewardPlanet;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.3f);
        difficulty.text = "Dificulty: " + Controller.GetComponent<Controller>().getDifficulty();
        yield return new WaitForSeconds(0.3f);
        difficulty.text = difficulty.text + "(x" + Controller.GetComponent<Controller>().getDifficulty() + ")";

        yield return new WaitForSeconds(0.3f);
        int rewardDifficulty = 0;
        for (int i = rewardPlanet; i <= rewardPlanet * Controller.GetComponent<Controller>().getDifficulty(); i++)
        {
            rewardDifficulty = i;
            reward.text = "Reward: " + rewardDifficulty;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(0.3f);
        position2.text = "Position: " + finishController.getPosition();
        yield return new WaitForSeconds(0.3f);
        position2.text = position2.text + "(/" + finishController.getPosition() + ")";

        yield return new WaitForSeconds(0.3f);
        int rewardPos = 0;
        float finalReward = rewardDifficulty/finishController.getPosition();
        for (int i = rewardDifficulty; i >= Math.Round(finalReward); i--)
        {
            rewardPos = i;
            reward.text = "Reward: " + rewardPos;
            yield return new WaitForSeconds(0.01f);
        }
    }

    
}
