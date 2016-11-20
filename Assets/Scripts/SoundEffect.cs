using UnityEngine;
using System.Collections;


public class SoundEffect : MonoBehaviour
{


    private static AudioController audioController;
    private AudioSource audioSource;


    void Awake()
    {
        if (audioController) return;
        audioController = GameObject.FindGameObjectWithTag("MusicSource").GetComponent<AudioController>();
    }

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!audioController.getStatus()) return;
        if (collider.tag != "Player" && collider.tag != "CPU") return;
        audioSource.Play();
    }
}
