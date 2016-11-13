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

    private void paint()
    {
        string[] worlds = fileController.getWorlds();
        for (int i = 0; i < worlds.Length; i++)
        {
            if (worlds[i] == "1") transform.GetChild(i).GetComponentInChildren<Image>().color = Color.white;
        }
    }
}
