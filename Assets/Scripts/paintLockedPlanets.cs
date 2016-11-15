using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class paintLockedPlanets : MonoBehaviour {
    public FileController fileController;
    // Use this for initialization
    void Start () {
        paint();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void paint()
    {
        for (int i = 0; i < fileController.getWorldCount(); i++)
        {
            if (fileController.isWorldUnlocked(i)) transform.GetChild(i).GetComponentInChildren<Image>().color = Color.white;
        }
    }
}
