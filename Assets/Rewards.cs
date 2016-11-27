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
        double position = gameObject.GetComponent<Controller>().positionOf(player);
        int difficulty = gameObject.GetComponent<Controller>().getDifficulty();
        reward -= collisions + time;
        reward = Math.Round(reward*difficulty/position);
        return reward < 20 ? 20 : (int)reward;
    }
}
