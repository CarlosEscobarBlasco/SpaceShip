using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class paintLockedShip : MonoBehaviour
{
    public FileController fileController;
	// Use this for initialization
	void Start ()
	{
	    paint();
	}

    // Update is called once per frame
	void Update () {
	
	}

    private void paint()
    {
        for (int i = 2; i <= fileController.getNShip(); i++)
        {
            transform.GetChild(i).GetComponentInChildren<Image>().color = Color.white;
        }
    }


}
