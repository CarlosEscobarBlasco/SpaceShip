using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishPanelController : MonoBehaviour
{

    public FinishController finishController;
    public Text position;
    public Text time;
    public Text collisions;
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
        time.text = "Time: "+finishController.getTimeOfPlayer();
        collisions.text = "Collisions: "+finishController.getCollisionsOfPlayer();
        reward.text = "Reward: "+finishController.getReward();

    }

    
}
