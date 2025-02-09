using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Photo : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    bool isFound; 
    bool inPosition;
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
        // Update Z position 
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
     void FixedUpdate()
     {
        if (isFound)
        {
            // When photo is found, turn on gameobject in album
            gameObject.SetActive(true);
        }

        if (inPosition)
        {
            // Animate photo into completed version
            SetPhotoPosition(target);
            anim.SetBool("CompletePhoto", true);

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
            transform.position = target.position;
            return;
       }
     }

    public void OnDrag(PointerEventData eventData)
    {
        if (isComplete)
        {
            transform.position = target.position;
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
            // When the photo is close to the target position, lock it in place and trigger dialogue

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
            // Clicking on photo loads the photo's scene

            transform.position = target.position;
            GameManager.Instance.LoadNextScene(this.GetComponent<DialogueTrigger>().GetSceneName());
        }
    }
}
