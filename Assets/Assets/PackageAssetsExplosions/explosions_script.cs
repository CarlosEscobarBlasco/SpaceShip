using System;
using UnityEngine;
using System.Collections;
using System.IO;

public class explosions_script : MonoBehaviour
{
    private static AudioController audioController;

    void Awake()
    {
        if (audioController) return;
        audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
    }

	void Start () 
	{
		if(audioController.getStatus())GetComponent<AudioSource>().Play();
        Invoke("destroy",2);
	}


    void destroy()
    {
        Destroy(gameObject);
    }
}
