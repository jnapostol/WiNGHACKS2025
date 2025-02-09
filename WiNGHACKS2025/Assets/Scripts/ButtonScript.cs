using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
   [SerializeField] private AudioManager audioManager;
    [SerializeField] private int audioIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        SetMusic();
    }
    private void SetMusic()
    {
        List<AudioClip> sfxList = audioManager.SFXList;
        if (audioManager != null)
        {
            audioManager.SetMusic(sfxList[audioIndex]);
        }
    }

    public void PlaySound()
    {

    }

}
