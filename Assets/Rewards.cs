using System;
using UnityEngine;
using System.Collections;

public class Rewards : MonoBehaviour
{
    private GameObject player;
	// Use this for initialization
	void Start () {
	    player = gameObject.GetComponent<Controller>().getPlayer();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getInitialReward()
    {
        return 150;
    }

    public int getReward(int collisions, float time)
    {
        double reward = getInitialReward();
        switch (gameObject.GetComponent<Controller>().getSelectedWorld())
        {
            case "Earth":
                reward += 0;
                break;
            case "Mars":
                reward += 20;
                break;
            case "Saturn":
                reward += 40;
                break;
            default:
                reward += 0;
                break;
        }
        double position = gameObject.GetComponent<Controller>().positionOf(player);
        int difficulty = gameObject.GetComponent<Controller>().getDifficulty();
        reward -= collisions + Math.Round(time);
        reward = Math.Round(reward*difficulty/position);
        Debug.Log(reward);
        return reward < 20 ? 20 : (int)reward;
    }
}
