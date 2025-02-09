using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Photo : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    bool isFound; // opening drawer makes this true
    bool inPosition; // when player puts the photo in the correct position make it true
    bool isComplete;

    Animator anim;
    AudioSource audioSource;

    [SerializeField] Transform target;
    [SerializeField] string scene;

     void Start()
     {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
     }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
     void FixedUpdate()
     {

        Debug.Log("pp " + isFound);
        if (isFound)
        {
            gameObject.SetActive(true);
        }

        if (inPosition)
        {
            SetPhotoPosition(target);
            anim.SetBool("CompletePhoto", true); // Plays completed version

            //  ---------- PLAY AUDIO ----------
            AudioManager AM = GameManager.Instance.GetAudioManager();
            // GET CLIP FROM AUDIO MANAGER SFX LIST
            // PLAY CLIP

            isComplete = true;
        }
     }

    public string GetNextScene()
    {
        return scene; 
    }

    public bool GetIsCompleteBool()
    {
        return isComplete;
    }

    public void SetFoundBool(bool value)
    {
        isFound = value;
    }

    public void SetPositionBool(bool value)
    {
        inPosition = value;
    }

   public void SetPhotoPosition(Transform target)
    {
        this.transform.position = target.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       if (isComplete)
       {
            return;
       }
     }

    public void OnDrag(PointerEventData eventData)
    {
        if (isComplete)
        {
            return;
        }
        else
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
     }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (Vector2.Distance(transform.position, target.position) < 2)
        {
            Debug.Log("end drag");
            GameManager.Instance.PhotoList.Add(this);

            GameManager.Instance.GetDialogueManager().SetTrigger(this.GetComponent<DialogueTrigger>());
            GameManager.Instance.DialogueUI.SetActive(true);
            GameManager.Instance.GetDialogueManager().StartDialogue();
            SetPositionBool(true);
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isComplete)
        {
            Debug.Log("loading next scene and clicked on photo");
            GameManager.Instance.LoadNextScene(this.GetComponent<DialogueTrigger>().GetSceneName());
        }
    }
}
