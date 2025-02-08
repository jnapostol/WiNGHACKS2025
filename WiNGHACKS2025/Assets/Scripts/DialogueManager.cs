using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    // Functions: continue/next, peak (see if it ends)
    // Current trigger
    public bool TriggerOnStart;
    public float Speed; //text speed
    public TextMeshProUGUI Textbox;
    public TextAsset CurrentTrigger;

    string[] lines;
    int index;
    bool isTyping;

    // Start is called before the first frame update
    void Start()
    {
        Textbox.text = "";
        index = 0;
        if (CurrentTrigger != null)
        {
            ReadFile();
            if (TriggerOnStart)
            {
                StartDialogue();
            }
        }
    }

    void ReadFile()
    {
        lines = CurrentTrigger.text.Split("\n"); // should split lines up by new line

        foreach (string line in lines) { 
            Debug.Log(line);
        }
    }

    public void StartDialogue()
    {
        StartCoroutine(TypeLine());
    }

    public void SetTrigger (TextAsset newTrigger)
    {
        CurrentTrigger = newTrigger;
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
       
        
        
        // click once to stop typing and play rest of dialogue
        // click again to go to next line
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
        GameManager.Instance.DialogueUI.SetActive(false);
    }

    // check if done somewhere, turn off the UI to explore
}
