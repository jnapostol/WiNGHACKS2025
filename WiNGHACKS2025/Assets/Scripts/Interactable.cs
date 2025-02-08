using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Animator anim;
    bool hasInteracted;
    void Start()
    {
        anim = GetComponent<Animator>();
        hasInteracted = false;
    }
    void FixedUpdate()
    {

        if (hasInteracted)
        {
            Activate();
        }
    }

    public void Activate()
    {
        anim.SetTrigger("Activate");
    }

    public bool GetInteractedBool()
    {
        return hasInteracted;
    }

}
