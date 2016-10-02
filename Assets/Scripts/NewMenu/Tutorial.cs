using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject menu;
    public GameObject nextArrow;
    public GameObject backArrow;
    public Text pageNumber;
    private int index;
    private string filePath;
    // Use this for initialization


    void Start ()
	{
	    index = 0;
        pages[index].SetActive(true);
        //backArrow.SetActive(false);
        
        nextArrow.GetComponent<Image>().color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        pageNumber.text = (index + 1) + "/" + pages.Length;
	    nextArrow.GetComponent<Image>().color = index == pages.Length - 1 ? Color.blue : Color.white;
        backArrow.GetComponent<Image>().color = index == 0 ? new Color(0,0,0,0) : Color.white;

    }

    public void closeTutorial()
    {
        pages[index].SetActive(false);
        index = 0;
        pages[index].SetActive(true);
        //menu.SetActive(true);
        //pageNumber.text = (index+1) + "/" + pages.Length;
        //nextArrow.GetComponent<Image>().color = Color.white;
        this.gameObject.SetActive(false);
    }

    public void next()
    {
        if (index == pages.Length - 1)
        {
            closeTutorial();
            return;
        }
        pages[index].SetActive(false);
        index++;
        pages[index].SetActive(true);
        backArrow.SetActive(true);
        //pageNumber.text = index + "/" + pages.Length;
        
    }

    public void back()
    {
        if (index == 0) return;
        pages[index].SetActive(false);
        index--;
        pages[index].SetActive(true);
    }

    public void showFirstTime()
    {
        filePath = Application.persistentDataPath + "/tutorial";
        if (File.Exists(filePath)) return;
        File.Create(filePath);
        gameObject.SetActive(true);
    }

}
