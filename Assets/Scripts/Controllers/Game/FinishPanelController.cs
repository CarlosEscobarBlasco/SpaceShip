using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishPanelController : MonoBehaviour
{

    public FinishController finishController;
    public Text position;
    public Text bonus;
    public Text reward;
    private AudioController audioController;
    private GameObject Controller;
	
    // Use this for initialization
	void Start () {
        audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
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
            //yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(1f);
        bonus.text = "Time: " + finishController.getTimeOfPlayer();
        yield return new WaitForSeconds(1f);
        bonus.text = bonus.text + "(-" + Math.Round(finishController.getTimeOfPlayerNoFormat()) + ")";

        yield return new WaitForSeconds(1f);
        int rewardPrice = 0;
        audioController.playCoinSound();
        
        for (int i = 0; i <= finishController.getTimeOfPlayerNoFormat(); i++)
        {
            rewardPrice = finishController.getInitialReward() - i;
            reward.text = "Reward: " + rewardPrice;
            
            yield return new WaitForSeconds(0.01f);
        }
        audioController.stopCoinSound();

        yield return new WaitForSeconds(1f);
        bonus.text = "Collisions: " + finishController.getCollisionsOfPlayer();
        yield return new WaitForSeconds(1f);
        bonus.text = bonus.text + "(-" + finishController.getCollisionsOfPlayer() + ")";

        yield return new WaitForSeconds(1f);
        int rewardCollision = 0;
        audioController.playCoinSound();
        for (int i = 0; i <= finishController.getCollisionsOfPlayer(); i++)
        {
            rewardCollision = rewardPrice - i;
            reward.text = "Reward: " + rewardCollision;
            
            yield return new WaitForSeconds(0.01f);
        }
        audioController.stopCoinSound();
        yield return new WaitForSeconds(1f);
        bonus.text = "Planet: " + Controller.GetComponent<Controller>().getSelectedWorld();
        yield return new WaitForSeconds(1f);
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
        bonus.text = bonus.text + "(+" + planetReward + ")";

        yield return new WaitForSeconds(1f);
        int rewardPlanet = 0;
        planetReward += rewardCollision;
        audioController.playCoinSound();
        for (int i = rewardCollision; i <= planetReward; i++)
        {
            rewardPlanet = i;
            reward.text = "Reward: " + rewardPlanet;
            yield return new WaitForSeconds(0.01f);
        }
        audioController.stopCoinSound();
        yield return new WaitForSeconds(1f);
        bonus.text = "Dificulty: " + Controller.GetComponent<Controller>().getDifficulty();
        float difficultyBonus = rewardPlanet*Controller.GetComponent<Controller>().getDifficulty();
        yield return new WaitForSeconds(1f);
        bonus.text = bonus.text + "(+" + (difficultyBonus-rewardPlanet) + ")";

        yield return new WaitForSeconds(1f);
        int rewardDifficulty = 0;
        audioController.playCoinSound();
        for (int i = rewardPlanet; i <= rewardPlanet * Controller.GetComponent<Controller>().getDifficulty(); i++)
        {
            rewardDifficulty = i;
            
            reward.text = "Reward: " + rewardDifficulty;
            yield return new WaitForSeconds(0.01f);
        }
        audioController.stopCoinSound();
        yield return new WaitForSeconds(1f);
        bonus.text = "Position: " + finishController.getPosition();
        yield return new WaitForSeconds(1f);
        float finalReward = rewardDifficulty / finishController.getPosition();
        bonus.text = bonus.text + "(-" + (rewardDifficulty - finalReward) + ")";
        print("FR "+ rewardDifficulty);
        yield return new WaitForSeconds(1f);
        int rewardPos = 0;
        audioController.playCoinSound();
        for (int i = rewardDifficulty; i >= Math.Round(finalReward); i--)
        {
            rewardPos = i;
            reward.text = "Reward: " + rewardPos;
            audioController.playCoinSound();
            yield return new WaitForSeconds(0.01f);
        }
        audioController.stopCoinSound();
    }

    
}
