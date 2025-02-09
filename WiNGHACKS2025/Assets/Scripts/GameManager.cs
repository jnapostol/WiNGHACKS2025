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
    public List<Photo> PhotoList;
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

        isPaused = false;
        PauseUI.SetActive(false);
    }
    void Update()
    {
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


        if (PhotoList != null)
        {
            switch (PhotoList.Count)
            {
                case 1:
                    //dialogueManager.SetTrigger(PhotoTriggers[0]);
                    //DialogueUI.SetActive(true);
                    //dialogueManager.StartDialogue();
                    break;
                case 2:
                    //dialogueManager.SetTrigger(PhotoTriggers[1]);
                    //dialogueManager.StartDialogue();
                    //DialogueUI.SetActive(true);
                    break;
                case 3:
                    //dialogueManager.SetTrigger(PhotoTriggers[2]);
                    //dialogueManager.StartDialogue();
                    //DialogueUI.SetActive(true);
                    break;
                case 4:
                    Debug.Log("All photos are found");
                    // 
                    //dialogueManager.SetTrigger(PhotoTriggers[3]); // set new dialogue trigger to the 4th one in the list
                    //dialogueManager.StartDialogue();
                    //DialogueUI.SetActive(true);

                    // scene change
                    break;

            }
        }    
    }

    public void SetIsOpenBool(bool value)
    {
        isOpen = value;
    }
    public void LoadNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        // fading to black
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
