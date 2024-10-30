using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCheck : MonoBehaviour
{

    private bool foundTrail;
    // Start is called before the first frame update
    void Start()
    {
        foundTrail = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Trail"))
        {
            foundTrail = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Trail"))
        {
            foundTrail = false;
        }
    }

    public bool IsAboveTrail()
    {
        return foundTrail;
    }
}
