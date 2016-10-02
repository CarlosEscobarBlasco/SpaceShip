using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logoAnimation : MonoBehaviour
{

    public Image image;
    public Text text;
    private bool start;

    // Use this for initialization
	void Start ()
	{
        Invoke("startAnimation",1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	    if (start)
	    {
	        changeTextAlpha();
	        changeImageAlpha();
	    }
	}

    private void changeImageAlpha()
    {
        Color color = image.color;
        color.a -= 0.01f;
        image.color = color;
        if(color.a<=0)Invoke("changeScene",0.5f);
    }

    private void changeTextAlpha()
    {
        Color color = text.color;
        color.a -= 0.01f;
        text.color = color;
    }

    private void startAnimation()
    {
        start = true;
    }

    private void changeScene()
    {
        SceneManager.LoadScene("Intro");
    }
}
