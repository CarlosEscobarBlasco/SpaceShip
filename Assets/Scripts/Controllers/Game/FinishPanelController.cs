using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishPanelController : MonoBehaviour
{

    public FinishController finishController;
    public Text position;
    public Text time;
    public Text collisions;
    public Text planet;
    public Text dificulty;
    public Text reward;
	
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
        dificulty.text = "Dificulty: "+finishController.getTimeOfPlayer();
        planet.text = "Planet: "+finishController.getCollisionsOfPlayer();
        reward.text = "Reward: "+finishController.getReward();
    }

    IEnumerator CalculateBase()
    {
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
        for (int i = 0; i <= finishController.getCollisionsOfPlayer(); i++)
        {
            int rewardCollision = rewardPrice - i;
            reward.text = "Reward: " + rewardCollision;
            yield return new WaitForSeconds(0.01f);
        }
    }

    
}
