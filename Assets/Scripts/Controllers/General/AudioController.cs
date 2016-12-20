using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Threading;

public class AudioController : MonoBehaviour {

    public AudioSource musicAudioSource;
    public AudioClip mainMusic;
    public AudioClip[] worldsMusic;

    public AudioSource effectsAudioSource;
    public AudioClip buttonClip;
    public AudioClip countDownClip;
    public AudioClip startClip;
    public AudioClip finishClip;
    public AudioClip coinClip;

    private bool status;
    private string filePath;
    //public AudioClip turboClip;
    
	// Use this for initialization
	void Start () {
        if(GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length > 1) Destroy(this.gameObject);
        filePath = Application.persistentDataPath + "/audio.txt";
        readStatus();
        DontDestroyOnLoad(transform.gameObject);
        musicAudioSource.clip = mainMusic;
        musicAudioSource.Play();
	}

    // Update is called once per frame
	void Update () {
	
	}

    public void playButtonSound()
    {
        effectsAudioSource.clip = buttonClip;
        effectsAudioSource.Play();
    }

    public void playCountDownSound()
    {
        musicAudioSource.Stop();
        effectsAudioSource.clip = countDownClip;
        effectsAudioSource.Play();
    }

    public void playStartSound()
    {
        effectsAudioSource.clip = startClip;
        effectsAudioSource.Play();
    }

    public void playFinishSound()
    {
        effectsAudioSource.clip = finishClip;
        effectsAudioSource.Play();
    }

    public void playBlackHoleSound()
    {
        if(!status)return;
        effectsAudioSource.volume = 0.3f;
        musicAudioSource.volume = 0.3f;
    }

    public void restoreMusicSound()
    {
        if (!status) return;
        effectsAudioSource.volume = 1f;
        musicAudioSource.volume = 1f;
    }

    public void playMainMenuMusic()
    {
        musicAudioSource.clip = mainMusic;
        musicAudioSource.Play();
    }

    public void playWorldMusic(int world)
    {
        musicAudioSource.clip = worldsMusic[world];
        musicAudioSource.Play();
    }

    public void playCoinSound()
    {
        effectsAudioSource.clip = coinClip;
        effectsAudioSource.GetComponent<AudioSource>().loop = true;
        effectsAudioSource.Play();
    }
    public void stopCoinSound()
    {
        effectsAudioSource.GetComponent<AudioSource>().loop = false;
        effectsAudioSource.Stop();
    }

    public void setStatus(bool status)
    {
        this.status = status;
        writeStatus(status);
        mute(!status);
    }

    public bool getStatus()
    {
        return status;
    }

    private void readStatus()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, Boolean.TrueString);
            status=true;
        }
        else
        {
            status=Boolean.Parse(File.ReadAllText(filePath));
                
        }
        mute(!status);
    }

    private void writeStatus(bool status)
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, status.ToString());
            this.status = status;
        }
        else
        {
            File.WriteAllText(filePath, status.ToString());

        }       
    }

    private void mute(bool mute)
    {
        if (mute)
        {
            effectsAudioSource.volume = 0;
            musicAudioSource.volume = 0;
        }
        else
        {
            effectsAudioSource.volume = 1;
            musicAudioSource.volume = 1;
        }
    }

}
