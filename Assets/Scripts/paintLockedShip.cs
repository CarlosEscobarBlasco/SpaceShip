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
	    //ships = fileController.getShipsColor();
	    paint();
	}

    // Update is called once per frame
	void Update () {
	
	}

    //TODO implement this function
    public void paint()
    {
        //for (int i = 0; i < ships.Length; i++)
        //{
        //    if(ships[i]=="1") transform.GetChild(i).GetComponentInChildren<Image>().color = Color.white;
        //}
    }
}
