using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Control quit system
    // Audio
    // Raycasting, click and dragging

    public GameObject PauseUI, DialogueUI;
    public static GameManager Instance; // singleton
    public List<Photo> PhotoList;
    public List<DialogueTrigger> PhotoTriggers;
    public GameObject Album;
    [SerializeField] GameObject albumButton;

    bool isOpen;
    bool isPaused;
    DialogueManager dialogueManager;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        dialogueManager = GetComponent<DialogueManager>();
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Photo" && !isPaused && hit.collider.gameObject.GetComponent<Photo>() != null)
                {
                    Photo hitPhoto = hit.collider.gameObject.GetComponent<Photo>();

                }
                if (hit.collider.tag == "Interactable")
                {
                    Interactable obj = hit.collider.gameObject.GetComponent<Interactable>();
                    if (obj.GetInteractedBool() == false)
                    {
                        obj.Activate();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
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
                    dialogueManager.SetTrigger(PhotoTriggers[0]);
                    dialogueManager.StartDialogue();
                    break;
                case 2:
                    dialogueManager.SetTrigger(PhotoTriggers[1]);
                    dialogueManager.StartDialogue();
                    break;
                case 3:
                    dialogueManager.SetTrigger(PhotoTriggers[2]);
                    dialogueManager.StartDialogue();
                    break;
                case 4:
                    Debug.Log("All photos are found");
                    // 
                    dialogueManager.SetTrigger(PhotoTriggers[3]); // set new dialogue trigger to the 4th one in the list
                    dialogueManager.StartDialogue();
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

}
