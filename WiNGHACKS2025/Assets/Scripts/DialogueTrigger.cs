using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool hasSceneChange;
    [SerializeField] TextAsset textFile;
    [SerializeField] string nextScene;
    public TextAsset GetTextFile()
    {
        return textFile;
    }

    public string GetSceneName()
    {
        return nextScene;
    }
}
