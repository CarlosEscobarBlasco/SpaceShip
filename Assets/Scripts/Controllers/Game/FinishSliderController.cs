using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishSliderController : MonoBehaviour
{

    private Slider finishSlider;
    private GameObject player;

	// Use this for initialization
	void Awake ()
	{
	    finishSlider = GetComponent<Slider>();
	    finishSlider.minValue = 0;
	}

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
	{
	    finishSlider.value = player.transform.position.y;
	}

    public void setDistance(float distance)
    {
        finishSlider.maxValue = distance;
        
    }
}
