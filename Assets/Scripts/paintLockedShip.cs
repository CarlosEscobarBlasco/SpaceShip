using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class paintLockedShip : MonoBehaviour
{
    public FileController fileController;
    public GameObject colorContainer;

    private string[] ships;
    private int nShips;
	// Use this for initialization
	void Start ()
	{
	    nShips = fileController.getShipCount();
	    paint();
	}

    // Update is called once per frame
	void Update () {
	
	}

    //TODO implement this function
    public void paint()
    {
        string[] colors; 
        for (int i = 0; i < nShips; i++)
        {
            colors = fileController.getShipColors(i);
            if (colors[i] == "1") transform.GetChild(i+1).GetComponentInChildren<Image>().color = Color.white;
            int counter = 0;
            foreach (string color in colors)
            {
                if (color == "1") colorContainer.transform.GetChild(i).transform.GetChild(counter).GetComponentInChildren<Image>().color = Color.white;
                counter++;
            }
        }
    }
}
