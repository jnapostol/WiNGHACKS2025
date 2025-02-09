using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> SFXList;
    public List<AudioClip> MusicList;

    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "StartScene")
        {
            // Set source clip to appropriate clip from music list
            // Play music
        }
        else if (currentScene.name == "Photo1")
        {
            // copy else if statements with all build scenes 
        }
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

    public void PlaySFX()
    {
        source.Play();
        Debug.Log("ran" + source.name) ;
    }

    public void SetSource()
    {
        
    }

    public AudioClip GetFromSFXList(int index)
    {
        return SFXList[index];
    }
}
