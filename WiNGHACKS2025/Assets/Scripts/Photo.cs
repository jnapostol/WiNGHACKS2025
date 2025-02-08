using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Photo : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    bool isFound; // opening drawer makes this true
    bool inPosition; // when player puts the photo in the correct position make it true
    bool isComplete;

    Animator anim;
    Collider2D col;

    [SerializeField] Transform target;
    [SerializeField] string scene;

     void Start()
     {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
     }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        //if (Vector2.Distance(transform.position, target.position) < 2)
        //{
        //    Debug.Log("From update");
        //    SetPositionBool(true);
        //}
    }
     void FixedUpdate()
     {
        if (inPosition)
        {
            SetPhotoPosition(target);
            anim.SetBool("CompletePhoto", true); // Plays completed version
            isComplete = true;
        }

        if (isComplete)
        {
            // click on image to change scene
           
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
            SetPositionBool(true);
        }

    }


}
