using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class paintLockedShip : MonoBehaviour
{
    //public FileController fileController;
    public FileController fileController;

    private string[] ships;
	// Use this for initialization
	void Start ()
	{
	    ships = fileController.getShips();
	    paint();
	}

    // Update is called once per frame
	void Update () {
	
	}

    public void paint()
    {
        
        for (int i = 0; i <= ships.Length-1; i++)
        {
            if(ships[i]=="1")transform.GetChild(i).GetComponentInChildren<Image>().color = Color.white;
        }
    }


}
