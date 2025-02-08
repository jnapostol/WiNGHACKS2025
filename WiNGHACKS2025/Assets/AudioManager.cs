using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> SFXList;
    public List<AudioClip> MusicList;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetMusic(AudioClip clip)
    {
        source.clip = clip;
    }

    public void PlayMusic()
    {
        source.Play();
    }

    public void StopMusic()
    {
        source.Stop();
    }
}
