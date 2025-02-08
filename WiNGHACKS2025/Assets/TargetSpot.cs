using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpot : MonoBehaviour
{
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log(other);
    //    if (other.tag == "Photo")
    //    {
    //        if (col.bounds.Contains(other.transform.position))
    //        {
    //            Debug.Log("Lock in");
    //            other.gameObject.GetComponent<Photo>().SetPhotoPosition(this.transform);
    //        }
    //    }
    //}
}
