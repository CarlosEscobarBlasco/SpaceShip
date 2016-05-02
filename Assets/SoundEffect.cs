using UnityEngine;
using System.Collections;


public class SoundEffect : MonoBehaviour
{

    public AudioClip clip;
    //private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" || collider.tag=="CPU")
        {
            //GetComponent<AudioSource>().Play();
            AudioSource audio = gameObject.AddComponent<AudioSource>();
            audio.clip = clip;
            audio.minDistance = 5;
            audio.maxDistance = 15;
            audio.spatialBlend = 1;
            audio.priority = 256;
            audio.Play();

        }
    }
}
