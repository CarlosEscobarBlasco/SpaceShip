using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorldMenuSlidersController : MonoBehaviour, MenuSliderController{

    public Text name;

    void Start()
    {
        refreshValues(1);
    }

    void Update()
    {

    }

    public void refreshValues(int actualWorld)
    {
        name.text=transform.GetChild(0).GetChild(actualWorld - 1).name;
    }
}
