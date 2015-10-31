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
	void Update ()
    {
        calculateDistance();
        this.GetComponentInChildren<Text>().text = totalDistance.ToString();
    }

    private void calculateDistance()
    {
        totalDistance = (int)(distance - player.transform.position.y);
        if (totalDistance <= 0) totalDistance = 0;
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
