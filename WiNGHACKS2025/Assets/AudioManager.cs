using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public List<AudioClip> SFXList;
    public List<AudioClip> MusicList;
    public GameObject PersistentSFX;

    public AudioSource source;
    AudioSource SFXsource;

    void Start()
    {
        source = GetComponent<AudioSource>();
    
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "StartScene" || currentScene.name == "Scene2" || currentScene.name == "Scene3" || currentScene.name == "Scene4")
        {
            source.clip = MusicList[0];
            PlayMusic();
        }
        else if (currentScene.name == "Photo1")
        {
            source.clip = MusicList[1];
            PlayMusic();
        }
        else if (currentScene.name == "Photo2")
        {
            source.clip = MusicList[2];
            PlayMusic();
        }
        else if (currentScene.name == "Photo3")
        {
            source.clip = MusicList[3];
            PlayMusic();
        }
        else if (currentScene.name == "Photo4" || currentScene.name == "End")
        {
            source.clip = MusicList[4];
            PlayMusic();
        }
    }
    private void FixedUpdate()
    {
       
    }

    public void SetSFXSource(AudioSource sfxSource)
    {
        // put this function on the continue button's onclick function
        SFXsource = sfxSource;
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
        SFXsource.Play();
    }

    public AudioClip GetFromSFXList(int index)
    {
        return SFXList[index];
    }

    public void SetSFXClip(int index)
    {
        SFXsource.clip = GetFromSFXList(index);
    }
}
