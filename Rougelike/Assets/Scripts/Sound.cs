using UnityEngine.Audio;
using UnityEngine;

[System.Serializable] // Makes the Sound class appear in the Unity inspector
public class Sound
{
    public string name; // Name for audio element
    public AudioClip clip;
    
    [Range(0f, 1f)] // Slider for volume
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
