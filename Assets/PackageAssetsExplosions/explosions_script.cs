using UnityEngine;
using System.Collections;

public class explosions_script : MonoBehaviour 
{

	void Start () 
	{
		GetComponent<AudioSource>().Play();
        Invoke("destroy",2);
	}

    void destroy()
    {
        Destroy(gameObject);
    }
}
