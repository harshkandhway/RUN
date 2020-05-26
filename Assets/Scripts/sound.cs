using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class sound
{
    public AudioClip clip;
    public string name;

    public float volume =  0.5f;
    public float pitch = 1;
    [HideInInspector]
    public AudioSource source;
    public bool loop;

}
