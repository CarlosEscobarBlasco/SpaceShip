using System;
using UnityEngine;
using System.Collections;
using System.IO;

public class explosions_script : MonoBehaviour
{

    private static bool status;
	void Start () 
	{
        readFile();
		if(status)GetComponent<AudioSource>().Play();
        Invoke("destroy",2);
	}

    static void readFile()
    {
        string filePath = Application.persistentDataPath + "/audio.txt";
        status = Boolean.Parse(File.ReadAllText(filePath));
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
