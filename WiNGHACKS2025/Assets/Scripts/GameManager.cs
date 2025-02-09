using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Control quit system
    // Audio

    public GameObject PauseUI, DialogueUI;
    public static GameManager Instance; // singleton
    public List<DialogueTrigger> PhotoTriggers;
    public GameObject Album;
    [SerializeField] GameObject albumButton;
    [SerializeField] AudioClip startMusic;

    bool isOpen;
    bool isPaused;
    DialogueManager dialogueManager;
    AudioManager audioManager;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        audioManager = GetComponent<AudioManager>();
        dialogueManager = GetComponent<DialogueManager>();

        if (startMusic != null)
        {
            audioManager.SetMusic(startMusic);
            audioManager.PlayMusic();
        }

        if (PauseUI != null) {
            isPaused = false;
            PauseUI.SetActive(false);
        }
        
    }
    void Update()
    {
        // Deal with opening the album and pausing the game

        if (Input.GetKey(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            isPaused = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameObject.Find("Album on Bed"))
            {
                GameObject.Find("Album on Bed").SetActive(false);
            }
            if (isOpen == false)
            {
                isOpen = true;
                Album.SetActive(true);
                albumButton.SetActive(false);
            }
            else
            {
                isOpen = false;
                Album.SetActive(false);
                albumButton.SetActive(true);
            }
        }   
    }

    public void SetIsOpenBool(bool value)
    {
        // Set if the album is open
        isOpen = value;
    }
    public void LoadNextScene(string sceneName)
    {
        // Load next scene
        SceneManager.LoadScene(sceneName);
        
        // fading to black?
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        isPaused = false;
        PauseUI.SetActive(false); 
        // might need to set time scale?
    }

    public AudioManager GetAudioManager()
    {
        return audioManager;
    }
    public DialogueManager GetDialogueManager()
    {
        return dialogueManager;
    }

}
