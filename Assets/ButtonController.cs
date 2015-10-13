using System;
using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    private static String input;
    private bool pressed;
    // Use this for initialization
    void Start()
    {
        pressed = false;

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnMouseOver()
    {
        if (!pressed)
        {
            input = "NoInput";
            return;
        }
        else if (gameObject.name == "RightButton")
        {
            input = "Right";
        }
        else
        {
            input = "Left";
        }
    }

    void OnMouseDown()
    {
        pressed = true;
    }

    void OnMouseUp()
    {
        pressed = false;
    }

    public static string getInput()
    {
        return input;
    }
}
