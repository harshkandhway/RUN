using UnityEngine.Audio;
using UnityEngine;
using System;

public class audioScript : MonoBehaviour
{
    // Start is called before the first frame update

    public sound[] sounds;
    public static audioScript instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        if(MainMenu.isMusicOn==0)
            playSound("theme");
    }
    public void StopPlaying(string sound)
    {
        sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        //s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        //s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));

        s.source.Stop();
    }
    public void playSound(string name)
    {
        
        sound s = Array.Find(sounds, item => item.name == name);
        if (s == null)
        {
            Debug.Log("sound not found :" + name);
        }
        //s.source.volume = s.volume;
        //s.source.pitch = s.pitch;
        s.source.Play();
    }
    /*public void volume(float v)
    {
        sound s = Array.Find(sounds, item => item.name == name);
        //s.volume = v;
    }*/
}
