using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroLoading : MonoBehaviour {

    public Text loading;
    // Use this for initialization
    void Start()
    {
        blinkerText();
        SceneManager.LoadSceneAsync("Menus2");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void blinkerText()
    {
        loading.text = changeText();
        Invoke("blinkerText", 0.5f);
    }

    private string changeText()
    {
        switch (loading.text)
        {
            case "Loading":
                return "Loading.";
            case "Loading.":
                return "Loading..";
            case "Loading..":
                return "Loading...";
            default:
                return "Loading";
        }
    }
}
