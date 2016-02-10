using UnityEngine;
using System.Collections;

public class InstructionNavigator : MonoBehaviour {

    public GameObject[] panels;
    public MenuController menuController;
    private int index;

	// Use this for initialization
	void Start ()
	{
	    init();
	}

    public void init()
    {
        index = 0;
        panels[index].SetActive(true);
        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    // Update is called once per frame
	void Update () {
	
	}

    public void moveNext()
    {
        panels[index].SetActive(false);
        index++;
        panels[index].SetActive(true);
    }

    public void moveBack()
    {
        panels[index].SetActive(false);
        index--;
        if (index == -1)
        {
            init();
            menuController.goToMainMenu();
        }
        else panels[index].SetActive(true);
    }
}
