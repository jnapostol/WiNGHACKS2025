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
        Textbox.text = "";
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
        lines = CurrentTextFile.text.Split("\n"); // should split lines up by new line

        //foreach (string line in lines)
        //{
        //    Debug.Log(line);
        //}
    }

    IEnumerator DelayStartDialogue()
    {
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

        currentTrigger = newTrigger;
        CurrentTextFile = newTrigger.GetTextFile();        
        ReadFile();
    }
 
    public void Continue()
    {
        if (isTyping)
        {
            // stop typing play rest of dialogue
            StopAllCoroutines();
            Textbox.text = lines[index];
            isTyping = false;
        }
        else
        {
            index++;
            Textbox.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
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
        Debug.Log("END");
        Array.Clear(lines, 0, lines.Length);
        index = 0;
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
