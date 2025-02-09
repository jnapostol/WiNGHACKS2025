using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    Photo photo;

    Animator anim;
    bool hasInteracted;
    bool isActivated;
    Button button;

    void Start()
    {
        anim = GetComponent<Animator>();
        hasInteracted = false;
        isActivated = false;
        button = GetComponent<Button>();
    }
    void FixedUpdate()
    {
        if (hasInteracted)
        {
            Activate();
        }
    }

    public void CollectPhoto()
    {
        // Collect the photo, do animation if applicable, disable button, make the photo appear in album to move

        anim.SetTrigger("Collect");
        button.enabled = false;
        photo.gameObject.SetActive(true);
        photo.SetFoundBool(true);
    }

    public void Activate()
    {
        //  ---------- PLAY AUDIO ----------
        AudioManager AM = GameManager.Instance.GetAudioManager();
        // GET CLIP FROM AUDIO MANAGER SFX LIST
        // PLAY CLIP

        anim.SetTrigger("Activate");
        isActivated = true;
    }

    public bool GetInteractedBool()
    {
        return hasInteracted;
    }

    public bool GetIsActivatedBool()
    {
        return isActivated; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // When interacted, collect the photo

        if (isActivated)
        {
            Debug.Log("Enters");
            CollectPhoto();
        }
    }
}
