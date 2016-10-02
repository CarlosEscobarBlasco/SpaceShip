using UnityEngine;
using System.Collections;

public class OptionButton : MonoBehaviour
{
    public GameObject optionPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showPanel()
    {
        optionPanel.SetActive(true);
    }
}
