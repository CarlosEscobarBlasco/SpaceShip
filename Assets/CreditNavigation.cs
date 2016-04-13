using UnityEngine;
using System.Collections;

public class CreditNavigation : MonoBehaviour {
    public GameObject[] panels;
    public MenuController menuController;
    private int index;

    // Use this for initialization
    void Start()
    {
       
    }



    // Update is called once per frame
    void Update()
    {

    }


    public void moveBack()
    {
        menuController.goToGameSelector();
    }
}