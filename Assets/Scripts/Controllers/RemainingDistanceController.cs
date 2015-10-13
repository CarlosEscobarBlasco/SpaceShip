using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RemainingDistanceController : MonoBehaviour {

    private float distance;
    private GameObject player;
    private int totalDistance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        totalDistance = (int) (distance - player.transform.position.y);
        this.GetComponentInChildren<Text>().text = totalDistance.ToString();
	}

    public void setDistance(float distance)
    {
        this.distance = distance;
    }

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }
}
