using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestructor : MonoBehaviour
{
    public string TagToDestroy;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagToDestroy))
            Destroy(other.gameObject);

    }
}

