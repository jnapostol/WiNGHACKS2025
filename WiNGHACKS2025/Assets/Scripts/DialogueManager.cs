using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
    public bool TriggerOnStart;
    public float Speed; //text speed
    public TextMeshProUGUI Textbox;
    public TextAsset CurrentTextFile;
    [SerializeField] DialogueTrigger currentTrigger;
    [SerializeField] float startDelay;
    [SerializeField] GameObject albumOnBed;

    string[] lines;
    int index;
    bool isTyping;
    void Start()
    {
        if (Textbox != null)
        {
            Textbox.text = string.Empty;
        }
        
        index = 0;

        if (CurrentTextFile != null)
        {
            ReadFile();
            if (TriggerOnStart)
            {
                StartCoroutine(DelayStartDialogue());
            }
        }
    }

    void ReadFile()
    {
        // Initializes string array
        lines = CurrentTextFile.text.Split("\n");
    }

    IEnumerator DelayStartDialogue()
    {
        // Coroutine to delay the start dialogue
        yield return new WaitForSeconds(startDelay);
        StartDialogue();
    }

    public void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    public void SetTrigger (DialogueTrigger newTrigger)
    {
        Array.Clear(lines, 0, lines.Length);
        index = 0;
        Textbox.text = string.Empty;

        currentTrigger = newTrigger;
        CurrentTextFile = newTrigger.GetTextFile();        
        ReadFile();
    }
 
    public void Continue()
    {
        if (isTyping)
        {
            // Stop typing, show the rest of the dialogue
            StopAllCoroutines();
            Textbox.text = lines[index];
            isTyping = false;
        }
        else
        {
            // Types the next line of dialogue
            index++;
            Textbox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        // Types the characters as long as we haven't reached the end of the string array
        if(index < lines.Length)
        {
            isTyping = true;
            foreach (char c in lines[index].ToCharArray())
            {
                Textbox.text += c;
                yield return new WaitForSeconds(Speed);

            }
            isTyping = false;
        }
        else
        {
            EndTrigger();
        }
        
    }

    void EndTrigger()
    {
        // Ends the entire dialogue trigger when all text has been read
        Debug.Log("END");

        Array.Clear(lines, 0, lines.Length);
        index = 0;
        Textbox.text = string.Empty;
        GameManager.Instance.DialogueUI.SetActive(false);

        if (albumOnBed != null)
        {
            albumOnBed.SetActive(true);
        }

        if (currentTrigger != null)
        {
            if (currentTrigger.hasSceneChange)
            {
                GameManager.Instance.LoadNextScene(currentTrigger.GetSceneName());
            }
        }
    }

    public void ClearAlbumOnBed()
    {
        albumOnBed = null;
    }
}
